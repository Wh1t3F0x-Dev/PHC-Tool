namespace BlueCare
{
    partial class BluecareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BluecareForm));
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 10);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 0;
            label1.Text = "Prefijo:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(389, 25);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 70);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(129, 17);
            label2.TabIndex = 2;
            label2.Text = "Nombre del Archivo:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 147);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Both;
            textBox3.Size = new Size(389, 125);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 127);
            label3.Name = "label3";
            label3.Size = new Size(176, 17);
            label3.TabIndex = 4;
            label3.Text = "Hostnames de las Maquinas:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ass", "euf", "jgc", "gct", "pla", "gci", "cec", "itd", "lbk", "ico", "ein", "gsi" });
            comboBox1.Location = new Point(116, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(284, 25);
            comboBox1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(11, 287);
            button1.Name = "button1";
            button1.Size = new Size(388, 43);
            button1.TabIndex = 7;
            button1.Text = "Crear Archivo CSV";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(12, 9);
            button2.Name = "button2";
            button2.Size = new Size(46, 46);
            button2.TabIndex = 10;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(64, 9);
            button3.Name = "button3";
            button3.Size = new Size(46, 46);
            button3.TabIndex = 11;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // BluecareForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 349);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(427, 390);
            MinimumSize = new Size(427, 390);
            Name = "BluecareForm";
            Text = "Bluecare CSV Maker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private ComboBox comboBox1;
        private Button button1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button2;
        private Button button3;
    }
}