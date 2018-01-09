using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Belt_Parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Angle = 39.5f;
            Yoffset = -1000000;
            ZminY = 45f;
            minY = 10000f;
            selectedFile = new OpenFileDialog();
            textBox2.Text = GetSetting("angle");
            bool result = double.TryParse(textBox2.Text, out Angle);
            if (!result)
            {
                label1.Text = "Angle not valid";
            }
            else
            {
                label1.Text = "Angle";
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a file.  
            bool result = double.TryParse(textBox2.Text, out Angle);
            if (!result)
            {
                label1.Text = "Angle not valid";
            }
            else
            {
                label1.Text = "Angle";
            }
            Yoffset = -1000000;
            ZminY = 45f;
            minY = 10000f;
            selectedFile.Filter = "Cura Files|*.gcode|All files (*.*)|*.*";
            selectedFile.Title = "Select a Cura GCODE File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .gcode file was selected, open it.  
            if (selectedFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = selectedFile.FileName;
                textBox1.Update();
                FindLayerCount();
                CheckAngle();
                label10.Text = "   ";
            }
        }
        private void FindLayerCount()
        {
            foreach (string line in File.ReadLines(selectedFile.FileName))
            {
                if (line.StartsWith(";LAYER_COUNT:"))
                {
                    string lineCount=line.Replace(";LAYER_COUNT:", "");
                    label8.Text = lineCount;
                }
            }
        }
        private void CheckAngle()
        {

            double currentY = 10000;
            double Zlayer = 0;
            double firstZ = 10000;
            double firstY = 10000;
            int layerCount = 0;
            string lineCount="0";
            bool codeStart = false;
            foreach (string line in File.ReadLines(selectedFile.FileName))
            {
                if (line.StartsWith(";LAYER:"))//make sure we are reading layers and not the start gcode
                {
                    codeStart = true;
                    lineCount = line.Replace(";LAYER:", "");
                }
                if (line.Contains("G0") && codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                    {
                        if (substring.Contains("Z"))
                        {
                            Zlayer = Convert.ToDouble(substring.Remove(0, 1));
                            if (firstZ == 10000)
                                firstZ = Zlayer;
                        }
                    }
                }
                    if (line.Contains("G1") && codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                    {
                        if (substring.Contains("Y"))
                        {
                            currentY = Convert.ToDouble(substring.Remove(0, 1));
                            if (firstY == 10000)
                                firstY = currentY;
                            if (currentY < minY)
                            {
                                minY = currentY;
                                ZminY = Zlayer;
                                layerCount = Convert.ToInt32(lineCount);
                                textBox4.Text = lineCount;
                            }
                        }
                    }
                }
            }
            newAngle = Math.Atan((ZminY - firstZ) / (firstY - minY)) * 180.0 / Math.PI;
            newAngle = Math.Round(newAngle, 5);
            textBox3.Text = newAngle.ToString("G");

        }
        private void button5_Click(object sender, EventArgs e)
        {
            saveSelectedFile = new SaveFileDialog();
            if (saveSelectedFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = saveSelectedFile.FileName;
                System.IO.File.WriteAllLines(saveSelectedFile.FileName, lines);

            }
        }

        private void ApplyAngle(object sender, EventArgs e)
        {
            if (selectedFile.Title == "")
            {
                label10.Text = "Open file first.";
                return;
            }
            textBox2.Text = textBox3.Text;
            bool result = double.TryParse(textBox2.Text, out Angle);
            if (!result)
            {
                label1.Text = "Angle not valid";
            }
            else
            {
                label1.Text = "Angle";
                SetSetting("angle", textBox2.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool result = double.TryParse(textBox2.Text, out Angle);
            if (!result)
            {
                label1.Text = "Angle not valid";
            }
            else
            {
                label1.Text = "Angle";
                SetSetting("angle", textBox2.Text);
            }
        }
        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static void SetSetting(string key, string value)
        {
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void CheckDeviation(object sender, EventArgs e)
        {
            double currentY = 10000;
            double Zlayer = 0;
            double deltaZ = 0;
            double maxiY = -10000;
            double miniY = 10000;
            lines = new List<string>();
            string newLine;
            bool codeStart = false;
            foreach (string line in File.ReadLines(selectedFile.FileName))
            {
                newLine = line;
                if (line.StartsWith(";LAYER:"))//make sure we are reading layers and not the start gcode
                    codeStart = true;
                if (line.Contains("G0") && codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                    {
                        if (substring.Contains("Z"))
                        {
                            Zlayer = Convert.ToDouble(substring.Remove(0, 1));
                        }
                    }
                }
                if (line.Contains("G1") && codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    int k = 0;
                    foreach (var substring in substrings)
                    {

                        if (substring.Contains("Y"))
                        {
                            currentY = Convert.ToDouble(substring.Remove(0, 1));
                            deltaZ = ZminY - Zlayer;
                            double newValue = Math.Round((currentY - minY - deltaZ / Math.Tan(Angle * (Math.PI / 180.0))), 5);
                            if (newValue < miniY)
                            {
                                miniY = newValue;
                                label3.Text = Convert.ToString(miniY);
                            }
                            if (newValue > maxiY)
                            {
                                maxiY = newValue;
                                label4.Text = Convert.ToString(maxiY);
                            }
                        }
                        k++;
                    }
                }
            }
        }

        private void RecalculateAngle(object sender, EventArgs e)
        {
            CheckAngle();
        }
        private void CheckLayer(int layer)
        {

            double currentY = 10000;
            double Zlayer = 0;
            double firstZ = 10000;
            double firstY = 10000;
            minY = 10000;
            int layerCount = 0;
            string lineCount = "0";
            bool codeStart = false;
            foreach (string line in File.ReadLines(selectedFile.FileName))
            {
                if (line.StartsWith(";LAYER:"))//make sure we are reading layers and not the start gcode
                {
                    codeStart = true;
                    lineCount = line.Replace(";LAYER:", "");
                }
                if (line.Contains("G0") && codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                    {
                        if (substring.Contains("Z"))
                        {
                            Zlayer = Convert.ToDouble(substring.Remove(0, 1));
                            if (firstZ == 10000)
                                firstZ = Zlayer;
                        }
                    }
                }
                if (line.Contains("G1") && codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                    {
                        if (substring.Contains("Y"))
                        {
                            currentY = Convert.ToDouble(substring.Remove(0, 1));
                            if (firstY == 10000)
                                firstY = currentY;
                            if ((Convert.ToInt32(lineCount) == layer) && (currentY < minY)) 
                            {
                                minY = currentY;
                                ZminY = Zlayer;
                                layerCount = Convert.ToInt32(lineCount);
                                textBox4.Text = lineCount;
                            }
                        }
                    }
                }
            }
            newAngle = Math.Atan((ZminY - firstZ) / (firstY - minY)) * 180.0 / Math.PI;
            newAngle = Math.Round(newAngle, 5);
            textBox3.Text = newAngle.ToString("G");

        }

        private void RecalculateLayer(object sender, EventArgs e)
        {
            int layer = 0;
            bool result = int.TryParse(textBox4.Text, out layer);
            if (!result)
            {
                label11.Text = "Layer not valid";
            }
            else
            {
                label11.Text = "    ";
            }
            CheckLayer(layer);
        }
        private void Parse(object sender, EventArgs e)
        {
            double currentY = 10000;
            double Zlayer = 0;
            double deltaZ = 0;
            lines = new List<string>();
            string newLine;
            bool codeStart = false;
            foreach (string line in File.ReadLines(selectedFile.FileName))
            {
                newLine = line;
                if (line.StartsWith(";LAYER:"))//make sure we are reading layers and not the start gcode
                    codeStart = true;
                if ((line.Contains("G1") || line.Contains("G0")) & codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                    {
                        if (substring.Contains("Z"))
                        {
                            Zlayer = Convert.ToDouble(substring.Remove(0, 1));
                        }
                    }
                    int k = 0;
                    foreach (var substring in substrings)
                    {

                        if (substring.Contains("Y"))
                        {
                            currentY = Convert.ToDouble(substring.Remove(0, 1));
                            deltaZ = ZminY - Zlayer;
                            double newValue = Math.Round((currentY - minY - deltaZ / Math.Tan(Angle * (Math.PI / 180.0))), 5);
                            if (newValue < 0)
                                newValue = 0.001;
                            newLine = line.Replace(substring, "Y" + newValue.ToString("G"));
                        }
                        k++;
                    }
                }
                lines.Add(newLine.ToString());
                if (line.Contains(";Home"))
                {
                    lines.Add("G0 Y10.00000");
                }
            }
            saveSelectedFile = new SaveFileDialog();
            string fileName = Path.GetFileNameWithoutExtension(selectedFile.FileName);
            saveSelectedFile.FileName = fileName + "_Belt.gcode";
            if (saveSelectedFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.WriteAllLines(saveSelectedFile.FileName, lines);

            }

        }

        private void Parse_method_two(object sender, EventArgs e)
        {
            double currentY = 10000;
            double Zlayer = 0;
            double deltaZ = 0;
            lines = new List<string>();
            string newLine;
            bool codeStart = false;
            int layerCount = 0;
            foreach (string line in File.ReadLines(selectedFile.FileName))
            {
                newLine = line;
                if (line.StartsWith(";LAYER:"))//make sure we are reading layers and not the start gcode
                {
                    codeStart = true;
                    layerCount = (Convert.ToInt32(line.Replace(";LAYER:", "")));
                }
                    if ((line.Contains("G1") || line.Contains("G0")) & codeStart)
                {
                    String value = line.ToString();
                    Char delimiter = ' ';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                    {
                        if (substring.Contains("Z"))
                        {
                            Zlayer = Convert.ToDouble(substring.Remove(0, 1));
                        }
                    }
                    int k = 0;
                    foreach (var substring in substrings)
                    {

                        if (substring.Contains("Y"))
                        {
                            currentY = Convert.ToDouble(substring.Remove(0, 1));
                            if ((layerCount == 0) && (currentY > Yoffset)) 
                            {
                                Yoffset = currentY+Zlayer/Math.Tan(Angle * (Math.PI / 180.0));
                                ZminY = Zlayer;
                            }
                            deltaZ = Zlayer - ZminY;
                            double newValue = Math.Round((currentY - Yoffset + deltaZ / Math.Tan(Angle * (Math.PI / 180.0))), 5);
                            if (newValue < 0)
                                newValue = 0.001;
                            newLine = line.Replace(substring, "Y" + newValue.ToString("G"));
                        }
                        k++;
                    }
                }
                lines.Add(newLine.ToString());
                if (line.Contains(";Home"))
                {
                    lines.Add("G0 Y10.00000");
                }
            }
            saveSelectedFile = new SaveFileDialog();
            string fileName = Path.GetFileNameWithoutExtension(selectedFile.FileName);
            saveSelectedFile.FileName = fileName + "_Belt.gcode";
            if (saveSelectedFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.WriteAllLines(saveSelectedFile.FileName, lines);

            }

        }
    }
}
