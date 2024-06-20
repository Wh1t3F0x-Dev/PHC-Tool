using OfficeOpenXml;
using PHCTool;
using System.IO.Compression;

namespace Analisis
{
    public partial class AnalisisForm : Form
    {
        List<string> filesList = new List<string>();

        public MainForm mainForm;

        bool needToClose = true;

        public AnalisisForm()
        {
            InitializeComponent();

            this.FormClosed += AnalisisForm_FormClosed;

        }

        private void AnalisisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needToClose)
            {
                Application.Exit();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filesList.Count > 0)
            {

                string[] files = filesList.ToArray();
                string path = Path.GetDirectoryName(files[0]);

                //

                string newPath = CreateTemporalDir(path);
                string[] newFiles = null;

                if (checkBox2.Checked)
                {
                    newFiles = MoveFiles(newPath, files);
                }
                else
                {
                    newFiles = CopyFiles(newPath, files);
                }


                ChangeValue(newFiles);
                CreateZip(path, newPath);

            }
            else
            {
                MessageBox.Show("Necesitas agregar archivos para crear su analisis");
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

        private void CreateLabels(string[] array)
        {
            try
            {
                if (array.Length != 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        Label labelTittle = new Label();
                        string[] tittle = array[i].Split('_');
                        labelTittle.Width = 500;
                        labelTittle.Text = $"Ticket_{tittle[2]} -> {Path.GetFileName(array[i])}";
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

        private void ChangeValue(string[] array)
        {
            foreach (string file in array)
            {
                //MessageBox.Show($"The file is {file}");
                FileInfo fileInfo = new FileInfo(file);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {


                    //MessageBox.Show($"The number of the worksheets is {package.Workbook.Worksheets.Count}");
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    ExcelRangeBase codeCell = FindCellWithValueInFirstRow(worksheet, "code");


                    if (codeCell != null)
                    {
                        int column = codeCell.Start.Column;

                        // Obtiene la fila en la que se encuentra la celda "code"
                        int row = codeCell.Start.Row;

                        // Actualiza los valores de las celdas debajo de la celda "code" en la misma columna
                        for (int i = row + 1; i <= worksheet.Dimension.End.Row; i++)
                        {
                            ExcelRangeBase cellToUpdate = worksheet.Cells[i, column];
                            // Aquí puedes establecer el nuevo valor para la celda
                            cellToUpdate.Value = "fixed";
                        }

                        // Guarda los cambios en el archivo
                        package.Save();
                    }
                    else
                    {
                        MessageBox.Show($"No se encontro el valor de Code comprueba a meter otro archivo valido");
                    }

                }

            }
        }

        private ExcelRangeBase FindCellWithValueInFirstRow(ExcelWorksheet worksheet, string value)
        {
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                if (cell.Value != null && cell.Value.ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return cell;
                }
            }
            return null;
        }

        private string CreateTemporalDir(string path)
        {
            string temporalDir = "";
            try
            {

                temporalDir = Path.Combine(path, "Analisis");
                if (!Directory.Exists(temporalDir)) Directory.CreateDirectory(temporalDir);


            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al crear la carpeta temporal: {ex.Message}.");

            }

            return temporalDir;
        }

        private string[] MoveFiles(string path, string[] array)
        {
            string[] files = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                string shortname = Path.GetFileName(array[i]);

                string[] tittle = (string[])shortname.Split('.');
                string newShortName = tittle[0] + "_ANALISIS." + tittle[1];

                //MessageBox.Show($"The Shortname is {tittle[0]}");

                File.Move(array[i], Path.Combine(path, newShortName));
                files[i] = Path.Combine(path, newShortName);
            }

            panel1.Controls.Clear();
            filesList.Clear();
            return files;
        }

        private string[] CopyFiles(string path, string[] array)
        {
            string[] files = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                string shortname = Path.GetFileName(array[i]);

                string[] tittle = (string[])shortname.Split('.');
                string newShortName = tittle[0] + "_ANALISIS." + tittle[1];

                //MessageBox.Show($"The Shortname is {tittle[0]}");

                File.Copy(array[i], Path.Combine(path, newShortName));
                files[i] = Path.Combine(path, newShortName);
            }

            return files;
        }

        private void CreateZip(string oldPath, string newPath)
        {
            string fileName = "";

            if (!checkBox1.Checked)
            {
                fileName = $"{textBox1.Text}";
            }
            else
            {
                fileName = "Analisis";
            }


            string archivoZIP = Path.Combine(oldPath, fileName);

            if (!File.Exists(archivoZIP + ".zip"))
            {
                ZipFile.CreateFromDirectory(newPath, archivoZIP + ".zip");
                Directory.Delete(newPath, true);
            }
            else
            {
                archivoZIP = Path.Combine(oldPath, $"{fileName}_{DateTime.Now.ToString("ddMMyyyyhhmmss")}.zip");
                ZipFile.CreateFromDirectory(newPath, archivoZIP);
                Directory.Delete(newPath, true);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            needToClose = false;
            mainForm.Show();
            this.Close();
        }
    }
}