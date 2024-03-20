namespace scrprnt
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
            textBox2 = new TextBox();
            label3 = new Label();
            checkBox1 = new CheckBox();
            button7 = new Button();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.screenshot;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Location = new Point(470, 152);
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
            button2.Location = new Point(218, 268);
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
            label1.Location = new Point(27, 124);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 2;
            label1.Text = "Add Your Comment";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 152);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(364, 96);
            textBox1.TabIndex = 3;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.reset;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Location = new Point(403, 152);
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
            button4.Location = new Point(403, 208);
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
            label2.Location = new Point(27, 291);
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
            button5.Location = new Point(338, 268);
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
            button6.Location = new Point(457, 268);
            button6.Name = "button6";
            button6.Size = new Size(93, 89);
            button6.TabIndex = 8;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(26, 360);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(399, 20);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Click to open the result folder - This contains (docx,pdf,zip)";
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
            // textBox2
            // 
            textBox2.Location = new Point(206, 54);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(357, 27);
            textBox2.TabIndex = 11;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 53);
            label3.Name = "label3";
            label3.Size = new Size(120, 25);
            label3.TabIndex = 13;
            label3.Text = "Jira issue key";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(33, 97);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(327, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "On Save Document Will be Uploaded In JIRA";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.BackgroundImage = Properties.Resources.jira1;
            button7.BackgroundImageLayout = ImageLayout.Center;
            button7.Location = new Point(457, 360);
            button7.Name = "button7";
            button7.Size = new Size(93, 89);
            button7.TabIndex = 14;
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Enabled = false;
            linkLabel2.Location = new Point(27, 405);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(212, 20);
            linkLabel2.TabIndex = 15;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Click here to view the Jira issue";
            linkLabel2.Visible = false;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.duck_21863;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(580, 443);
            Controls.Add(linkLabel2);
            Controls.Add(button7);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
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
            MaximumSize = new Size(598, 490);
            MinimumSize = new Size(598, 490);
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
        private Label label3;
        private Button button7;
        public static LinkLabel linkLabel2;
        public static TextBox textBox2;
        public  static CheckBox checkBox1;
    }
}
