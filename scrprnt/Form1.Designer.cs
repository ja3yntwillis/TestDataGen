﻿namespace scrprnt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            button5 = new Button();
            button6 = new Button();
            linkLabel1 = new LinkLabel();
            pixieText = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.screenshot;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Location = new Point(404, 61);
            button1.Name = "button1";
            button1.Size = new Size(93, 90);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.word;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.Enabled = false;
            button2.Location = new Point(180, 184);
            button2.Name = "button2";
            button2.Size = new Size(96, 89);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(26, 33);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 2;
            label1.Text = "Add Your Comment";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 61);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 90);
            textBox1.TabIndex = 3;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.reset;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Location = new Point(341, 61);
            button3.Name = "button3";
            button3.Size = new Size(40, 40);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.microphone;
            button4.BackgroundImageLayout = ImageLayout.Center;
            button4.Location = new Point(339, 111);
            button4.Name = "button4";
            button4.Size = new Size(40, 40);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 214);
            label2.Name = "label2";
            label2.Size = new Size(132, 25);
            label2.TabIndex = 6;
            label2.Text = "Save Result As";
            // 
            // button5
            // 
            button5.BackgroundImage = Properties.Resources.pdf;
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.Enabled = false;
            button5.Location = new Point(294, 184);
            button5.Name = "button5";
            button5.Size = new Size(96, 89);
            button5.TabIndex = 7;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackgroundImage = Properties.Resources.zipped;
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.Enabled = false;
            button6.Location = new Point(404, 184);
            button6.Name = "button6";
            button6.Size = new Size(93, 89);
            button6.TabIndex = 8;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(35, 280);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(432, 20);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Click here to open the result folder - This contains (docx,pdf,zip)";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pixieText
            // 
            pixieText.AutoSize = true;
            pixieText.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            pixieText.Location = new Point(35, 9);
            pixieText.Name = "pixieText";
            pixieText.Size = new Size(437, 20);
            pixieText.TabIndex = 10;
            pixieText.Text = "Activate Pixie by saying \"Hi Pixie\" to initiate your conversation";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.duck_21863;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(522, 309);
            Controls.Add(pixieText);
            Controls.Add(linkLabel1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(540, 356);
            MinimumSize = new Size(540, 356);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pixie";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
        private Label label2;
        private Button button5;
        private Button button6;
        private LinkLabel linkLabel1;
        private Label pixieText;
    }
}
