namespace Belt_Parser
{
    using System.Collections.Generic;
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(12, 2);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(97, 39);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(323, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Saved Angle";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(270, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(65, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "39.5";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Calculated Angle";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(270, 210);
            this.textBox3.Name = "textBox3";
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox3.Size = new System.Drawing.Size(65, 20);
            this.textBox3.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 14;
            this.button1.Text = "Apply calculated angle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ApplyAngle);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Number of layers: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Layer:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(268, 268);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(65, 20);
            this.textBox4.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "            ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 199);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 40);
            this.button3.TabIndex = 25;
            this.button3.Text = "Recalculate optimal angle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RecalculateAngle);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 256);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 42);
            this.button4.TabIndex = 26;
            this.button4.Text = "Recalculate at Layer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.RecalculateLayer);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(178, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "     ";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 418);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 41);
            this.button5.TabIndex = 28;
            this.button5.Text = "Parse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Parse_method_two);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(270, 333);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(65, 20);
            this.textBox5.TabIndex = 29;
            this.textBox5.Text = "0.0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox5.TextChanged += new System.EventHandler(this.ApplySlope);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Slope (%)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 469);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.openFile);
            this.Name = "Form1";
            this.Text = "Belt Parser 0.5 by Neochrome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private double Angle;
        private double Slope;
        private double minY;
        private double ZminY;
        private double newAngle;
        private double Yoffset;
        private List <string> lines;
        //private System.IO.Stream GcodeStream;
        private System.Windows.Forms.OpenFileDialog selectedFile;
        private System.Windows.Forms.SaveFileDialog saveSelectedFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button checkFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
    }
}

