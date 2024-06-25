namespace PHCTool
{
    partial class MDCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDCreator));
            button2 = new Button();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(17, 13);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(66, 68);
            button2.TabIndex = 10;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(17, 114);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(665, 342);
            panel1.TabIndex = 11;
            panel1.DragDrop += panel1_DragDrop;
            panel1.DragEnter += panel1_DragEnter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 183);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(485, 25);
            label3.TabIndex = 1;
            label3.Text = "(Las tech spects se reemplazan por los nuevos arrastrandos)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(69, 129);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(537, 54);
            label2.TabIndex = 0;
            label2.Text = "Arrastra aqui las tech spects. ";
            // 
            // button1
            // 
            button1.Location = new Point(16, 466);
            button1.Margin = new Padding(143, 147, 143, 147);
            button1.Name = "button1";
            button1.Size = new Size(666, 69);
            button1.TabIndex = 12;
            button1.Text = "Crear Archivos de Mark Down";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 85);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(222, 25);
            label1.TabIndex = 13;
            label1.Text = "Tech Spects Seleccionadas:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(87, 50);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(596, 31);
            textBox2.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 13);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(216, 25);
            label4.TabIndex = 14;
            label4.Text = "Titulo Adicional Tech Spec\r\n";
            // 
            // MDCreator
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 543);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(button2);
            Margin = new Padding(4);
            MaximumSize = new Size(713, 599);
            MinimumSize = new Size(713, 599);
            Name = "MDCreator";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Button button1;
        private Label label1;
        private TextBox textBox2;
        private Label label4;
    }
}