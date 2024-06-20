using PHCTool;

namespace BlueCare
{
    public partial class BluecareForm : Form
    {

        public MainForm mainForm;
        bool needToClose = true;
        public BluecareForm()
        {
            InitializeComponent();

            // Suscribe al evento FormClosed
            this.FormClosed += BluecareForm_FormClosed;
        }

        private void BluecareForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needToClose)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateCSV();
        }

        private void GenerateCSV()
        {
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            if (CheckInputs() == false)
            {

                MessageBox.Show("Completa todas las inputs por favor.");

            }
            else
            {
                try
                {

                    CreateTheFile(path);

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.ToString());

                }

            }
        }

        private void CreateTheFile(string path)
        {
            string newPath = path + $"\\{textBox2.Text}.csv";
            string csvLine = "";
            //Tests(newPath);

            foreach (string line in textBox3.Lines)
            {
                if (line != "") csvLine += $"{comboBox1.Text}_{line};";
            }




            try
            {
                using (StreamWriter writer = new StreamWriter(newPath, false))
                {
                    //writer.Write("\"" + csvLine + "\"");
                    writer.Write(csvLine);
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Comprueba que has cerrado dicho CSV antes de volver a generar el mismo.");
            }


        }

        private bool CheckInputs()
        {

            bool checked_Inputs = true;
            if (comboBox1.SelectedIndex < 0) checked_Inputs = false;
            if ((textBox2.Text == "") || (textBox3.Text == "")) checked_Inputs = false;

            return checked_Inputs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            needToClose = false;
            mainForm.Show();
            this.Close();
        }

    }
}