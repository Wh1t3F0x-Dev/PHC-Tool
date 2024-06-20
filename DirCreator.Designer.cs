namespace PHCTool
{
    partial class DirCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirCreator));
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            button4 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(63, 14);
            button3.Name = "button3";
            button3.Size = new Size(46, 46);
            button3.TabIndex = 20;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(11, 14);
            button2.Name = "button2";
            button2.Size = new Size(46, 46);
            button2.TabIndex = 19;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 294);
            button1.Name = "button1";
            button1.Size = new Size(388, 43);
            button1.TabIndex = 18;
            button1.Text = "Crear Carpeta del Cambio\r\n";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ALFUNDS-BANK", "INFRA-AIX", "INFRA-LINUX", "LIBERBANK", "CECABANK", "CESCE", "ASISA", "CTTI" });
            comboBox1.Location = new Point(115, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(284, 25);
            comboBox1.TabIndex = 17;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(11, 131);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Both;
            textBox3.Size = new Size(176, 157);
            textBox3.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 111);
            label3.Name = "label3";
            label3.Size = new Size(176, 17);
            label3.TabIndex = 15;
            label3.Text = "Hostnames de las Maquinas:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 83);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(389, 25);
            textBox2.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 63);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(125, 17);
            label2.TabIndex = 13;
            label2.Text = "Numero de cambio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(115, 15);
            label1.Name = "label1";
            label1.Size = new Size(50, 17);
            label1.TabIndex = 12;
            label1.Text = "Cliente:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Location = new Point(193, 131);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 157);
            panel1.TabIndex = 21;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.FlatAppearance.BorderColor = Color.White;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = SystemColors.ControlDark;
            button4.Location = new Point(177, 101);
            button4.Name = "button4";
            button4.Size = new Size(25, 25);
            button4.TabIndex = 6;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(3, 101);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 25);
            textBox1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Enabled = false;
            label5.Location = new Point(3, 81);
            label5.Name = "label5";
            label5.Size = new Size(104, 17);
            label5.TabIndex = 4;
            label5.Text = "Seleccionar ruta:";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(3, 57);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(126, 21);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Ruta por defecto";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(3, 30);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(181, 21);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Creacion de Aplicativos txt";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(165, 21);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Creacion de ficheros txt";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(193, 111);
            label4.Name = "label4";
            label4.Size = new Size(120, 17);
            label4.TabIndex = 22;
            label4.Text = "Panel de Opciones:";
            // 
            // DirCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 349);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(427, 390);
            MinimumSize = new Size(427, 390);
            Name = "DirCreator";
            Text = "DirCreator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Button button4;
    }
}