using OfficeOpenXml;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using static OfficeOpenXml.ExcelErrorValue;

namespace PHCTool
{

    public partial class MDCreator : Form
    {
        List<string> filesList = new List<string>();

        public MainForm mainForm;

        bool needToClose = true;

        string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

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
            CreateMDFiles();
        }

        private void CreateLabels(string[] array)
        {
            try
            {
                if (array.Length != 0 && array.Length < 2)
                {
                    Label labelTittle = new Label();
                    labelTittle.Width = 500;
                    labelTittle.Text = $"File: {Path.GetFileName(array[0])}";
                    labelTittle.Location = new Point(0, 0);
                    panel1.Controls.Add(labelTittle);
                }
                else
                {
                    MessageBox.Show("Introduce un archivo por favor.");
                }
            }
            catch
            {
                MessageBox.Show("Introduce un archivo compatible con la aplicacion por favor.");
            }

        }

        /// <summary>
        /// Logic to create the MD files from a TechSpecs file
        /// </summary>

        private List<InfoCelda> GetFieldsFromExcel()
        {
            List<InfoCelda> fields = new List<InfoCelda>();
            try
            {
                string file = "";
                if (filesList.Count != 0) file = filesList[0];

                FileInfo fileInfo = new FileInfo(file);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int i = 2; i <= rowCount; i++)
                    {
                        bool value = false;
                        if (worksheet.Cells[i, 1].Text == "N/A") value = true;

                        fields.Add(new InfoCelda(
                                value,
                                worksheet.Cells[i, 4].Text,
                                worksheet.Cells[i, 5].Text,
                                worksheet.Cells[i, 6].Text,
                                worksheet.Cells[i, 7].Text,
                                worksheet.Cells[i, 8].Text,
                                worksheet.Cells[i, 11].Text,
                                worksheet.Cells[i, 12].Text,
                                worksheet.Cells[i, 13].Text
                            )
                        );

                    }

                }

            }
            catch
            {
                MessageBox.Show($"Es necesario que insertes solo un archivo.");
            }

            return fields;
        }

        private void CreateMDFiles()
        {
            string ruta = CreateDir();
            List<InfoCelda> files = GetFieldsFromExcel();

            if (CheckPlantillaIsOk())
            {
                string contenidoPlantilla = File.ReadAllText(Path.Combine(path, "Plantilla.mdx"));
                string contenidoPersonalizado = "";


                foreach (var file in files)
                {

                    if (!file.notApplicable)
                    {
                        contenidoPersonalizado = contenidoPlantilla.Replace("--Titulo--", file.tittle + $" {textBox2.Text}")
                                                                .Replace("--SubTitulo--", file.subtittle)
                                                                .Replace("--SubSubTitulo--", file.subsubtittle)
                                                                .Replace("--Description--", file.description)
                                                                .Replace("--RecommendedValue--", file.recommendeValue)
                                                                .Replace("--SecurityRationale--", file.securityRationale)
                                                                .Replace("--Comprobacion--", file.validation)
                                                                .Replace("--Modificacion--", file.configuration)
                                                                .Replace("{/*", " ")
                                                                .Replace("*/}", " ");
                    }
                    else
                    {

                        contenidoPersonalizado = contenidoPlantilla.Replace("--Titulo--", file.tittle + $" {textBox2.Text}")
                                                                .Replace("--SubTitulo--", file.subtittle)
                                                                .Replace("--SubSubTitulo--", file.subsubtittle)
                                                                .Replace("--Description--", file.description)
                                                                .Replace("--RecommendedValue--", file.recommendeValue)
                                                                .Replace("--SecurityRationale--", file.securityRationale)
                                                                .Replace("--Comprobacion--", file.validation)
                                                                .Replace("--Modificacion--", file.configuration);

                    }


                    string nombreArchivo = file.tittle + "_" + textBox2.Text + ".mdx";

                    string newPath = Path.Combine(ruta, nombreArchivo);

                    File.WriteAllText(newPath, contenidoPersonalizado);
                }
            }
            else
            {
                MessageBox.Show("Falta la plantilla (Plantilla.mdx) en el directorio de la aplicacion.");
                return;
            }
        }

        private bool CheckPlantillaIsOk()
        {
            if (File.Exists(Path.Combine(path, "Plantilla.mdx")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string CreateDir()
        {
            string temporalDir = "";
            try
            {
                if (filesList.Count > 0)
                {
                    string dirName = "";
                    if (textBox2.Text != null)
                    {
                        dirName = textBox2.Text;
                    }
                    else {
                        dirName = Path.GetFileName(filesList[0]).Split('.')[0].Replace(" ", "_");
                    }
                    

                    temporalDir = Path.Combine(path, dirName);
                    if (!Directory.Exists(temporalDir)) Directory.CreateDirectory(temporalDir);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al crear la carpeta temporal: {ex.Message}.");

            }

            return temporalDir;

        }

    }
}
