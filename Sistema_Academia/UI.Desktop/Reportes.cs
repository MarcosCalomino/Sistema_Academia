using Business.Entities;
using Business.Logic;
using Util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace UI.Desktop
{
    public partial class Reportes : Form
    {
        SaveFileDialog? saveFile;
        ReportesManagment reportesManagment { get; set; }
        public Reportes()
        {
            InitializeComponent();
            reportesManagment = new ReportesManagment();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        private async void btnReportePlanes_Click(object sender, EventArgs e)
        {
            try
            {
                List<Plan> listaPlanes = new PlanLogic().GetAll();
                saveFile = GetSaveFileDialog("Planes");
                string paginaHtmlTexto = reportesManagment.SetValoresInReporteHtml(listaPlanes);
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    await Task.Run(() => reportesManagment.GenerarPDF(saveFile.FileName, paginaHtmlTexto));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private async void btnReporteCursos_Click(object sender, EventArgs e)
        {
            try
            {
                List<Curso> listaCursos = new CursoLogic().GetAll();
                saveFile = GetSaveFileDialog("Cursos");
                string paginaHtmlTexto = reportesManagment.SetValoresInReporteHtml(listaCursos);
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    await Task.Run(() => reportesManagment.GenerarPDF(saveFile.FileName, paginaHtmlTexto));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }      
        private SaveFileDialog GetSaveFileDialog(string name)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = name + "-" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            return saveFile;
        }
        
    }
}
