namespace PHCTool
{
    public partial class MDCreator : Form
    {
        List<string> filesList = new List<string>();

        public MainForm mainForm;

        bool needToClose = true;


        /// <summary>
        /// UI Things
        /// </summary>

        public MDCreator()
        {
            InitializeComponent();

            this.FormClosed += MDCreator_FormClosed;

        }

        private void MDCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needToClose)
            {
                Application.Exit();
            }

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            panel1.Controls.Clear();
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            filesList = files.ToList();
            CreateLabels(files);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            needToClose = false;
            mainForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Logic to create the MD files from a TechSpecs file
        /// </summary>

        private void CreateLabels(string[] array)
        {
            try
            {
                if (array.Length != 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        Label labelTittle = new Label();
                        labelTittle.Width = 1000;
                        labelTittle.Text = $"File: {Path.GetFileName(array[i])} -> {array[i]}";
                        labelTittle.Location = new Point(0, 0 + (20 * i + 1));
                        panel1.Controls.Add(labelTittle);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Introduce un archivo compatible con la aplicacion por favor.");
            }

        }

        private void CreateMDFiles() {

        }

        private 

    }
}
