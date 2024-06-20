using Analisis;
using BlueCare;

namespace PHCTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnalisisForm analisisForm = new AnalisisForm();
            analisisForm.Show();
            analisisForm.mainForm = this;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BluecareForm bluecareForm = new BluecareForm();
            bluecareForm.Show();
            bluecareForm.mainForm = this;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DirCreator dirCreator = new DirCreator();
            dirCreator.Show();
            dirCreator.mainForm = this;
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}