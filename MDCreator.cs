using OfficeOpenXml;
using System.IO.Compression;
using static OfficeOpenXml.ExcelErrorValue;

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
                if (array.Length != 0 && array.Length < 2)
                {
                    Label labelTittle = new Label();
                    labelTittle.Width = 500;
                    labelTittle.Text = $"File: {Path.GetFileName(array[0])}";
                    labelTittle.Location = new Point(0, 0);
                    panel1.Controls.Add(labelTittle);
                }
                else {
                    MessageBox.Show("Introduce un archivo por favor.");
                }
            }
            catch
            {
                MessageBox.Show("Introduce un archivo compatible con la aplicacion por favor.");
            }

        }

        private void CreateMDFiles() {

        }

        private void FindCellWithValue(ExcelWorksheet worksheet, string value) {
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                if (cell.Value != null && cell.Value.ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return cell;
                }
            }
            return null;
        }

        private void CreateDir() { 
            
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
                            cellToUpdate.Value = "Fixed";
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
    }
}
