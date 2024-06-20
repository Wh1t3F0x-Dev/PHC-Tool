namespace PHCTool
{
    public partial class DirCreator : Form
    {
        public MainForm mainForm;

        bool needToClose = true;

        bool configFileExists = false;

        string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        string configPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "configure.conf");

        string favouritePath = "";


        public DirCreator()
        {
            InitializeComponent();
            checkConfigFile();
            retFavouritePath();
            this.FormClosed += DirCreator_FormClosed;
        }

        private void DirCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needToClose)
            {
                setFavouritePath();
                Application.Exit();
            }

        }

        private void checkConfigFile()
        {
            if (File.Exists(configPath))
            {
                configFileExists = true;
            }
            else
            {
                configFileExists = false;
            }
        }

        private void setFavouritePath()
        {

            if (configFileExists) configureFile();

            try
            {
                using (StreamWriter writer = new StreamWriter(configPath, false))
                {
                    writer.Write($"favPath={favouritePath}");
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Ocurrió un error al leer el archivo de configuración: " + ioex.Message);
            }

        }

        private void retFavouritePath()
        {
            if (!configFileExists)
            {
                textBox1.Text = defaultPath;
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(configPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("favPath"))
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length == 2)
                            {
                                if (parts[1] == "")
                                {
                                    favouritePath = defaultPath;
                                }
                                else
                                {
                                    favouritePath = parts[1].Trim();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al leer el archivo de configuración: " + ex.Message);
            }

            textBox1.Text = favouritePath;

            if (favouritePath == defaultPath)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }

        }

        private void configureFile()
        {
            if (configFileExists) return;

            try
            {
                using (StreamWriter writer = new StreamWriter(configPath, false))
                {
                    writer.Write("favPath=");
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Comprueba que has cerrado dicho CSV antes de volver a generar el mismo.");
            }
        }

        private void createAllDirs()
        {

            if (textBox1.Text == "" || comboBox1.SelectedIndex < 0 || textBox2.Text == "")
            {
                MessageBox.Show("Rellena todos los campos necesarios para la creacion de carpetas.");
                return;
            }


            string cambioDir = Path.Combine(Path.Combine(textBox1.Text, comboBox1.Text), textBox2.Text);

            foreach (string hostname in textBox3.Lines)
            {

                string hostnameDir = Path.Combine(cambioDir, hostname);

                if (!Directory.Exists(hostnameDir))
                {
                    Directory.CreateDirectory(hostnameDir);

                }
                else
                {
                    MessageBox.Show("Ya existe dicho sistema de carpetas");
                }

            }

        }

        private void createDirsWithFiles()
        {
            if (textBox1.Text == "" || comboBox1.SelectedIndex < 0 || textBox2.Text == "")
            {
                MessageBox.Show("Rellena todos los campos necesarios para la creacion de carpetas.");
                return;
            }


            string cambioDir = Path.Combine(Path.Combine(textBox1.Text, comboBox1.Text), textBox2.Text);

            foreach (string hostname in textBox3.Lines)
            {

                string hostnameDir = Path.Combine(cambioDir, hostname);
                string fileNameBefore = Path.Combine(hostnameDir, $"Evidences_{hostname}_Before.txt");
                string fileNameAfter = Path.Combine(hostnameDir, $"Evidences_{hostname}_After.txt");


                if (!Directory.Exists(hostnameDir) && !File.Exists(fileNameBefore) && !File.Exists(fileNameAfter))
                {
                    Directory.CreateDirectory(hostnameDir);
                    File.Create(fileNameBefore).Close();
                    File.Create(fileNameAfter).Close();

                    if (checkBox2.Checked)
                    {
                        string fileAplicativosBefore = Path.Combine(hostnameDir, $"Evidences_{hostname}_Aplicativos_Before.txt");
                        string fileAplicativosAfter = Path.Combine(hostnameDir, $"Evidences_{hostname}_Aplicativos_After.txt");

                        File.Create(fileAplicativosBefore).Close();
                        File.Create(fileAplicativosAfter).Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe dicho sistema de carpetas");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            needToClose = false;
            mainForm.Show();
            setFavouritePath();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                createDirsWithFiles();
            }
            else
            {
                createAllDirs();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.InitialDirectory = defaultPath;
            folderBrowserDialog.ShowDialog();

            textBox1.Text = folderBrowserDialog.SelectedPath;
            favouritePath = folderBrowserDialog.SelectedPath;

            setFavouritePath();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                label5.Enabled = false;
                textBox1.Enabled = false;
                button4.Enabled = false;
                textBox1.Text = defaultPath;
                favouritePath = defaultPath;
            }
            else
            {
                label5.Enabled = true;
                textBox1.Enabled = true;
                button4.Enabled = true;
            }
        }
    }
}
