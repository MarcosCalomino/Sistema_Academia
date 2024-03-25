using Business.Entities;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharp.tool.xml;
using System.IO;
using System.Linq;

namespace Util
{
    public class ReportesManagment
    {
        public void GenerarPDF(string fileName, string paginaHtmlTexto)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (Document pdfDoc = GetDocument())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));
                    pdfDoc.Add(GetImagen(pdfDoc));
                    using (StringReader sr = new StringReader(paginaHtmlTexto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                }
            }
        }
        public Document GetDocument()
        {
            return new Document(PageSize.A4, 25, 25, 25, 25);
        }
        public Image GetImagen(Document pdfDoc)
        {
            iTextSharp.text.Image img = Image.GetInstance(Properties.Resources.logo);
            img.ScaleToFit(80, 60);
            img.Alignment = iTextSharp.text.Image.UNDERLYING;
            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 40);
            return img;
        }
        public string SetValoresInReporteHtml<T>(List<T> listaDeElementos)
        {
            try
            {
                string filas = string.Empty;
                string paginaHtmlTexto = string.Empty;

                paginaHtmlTexto = GetPlantilla(listaDeElementos);

                paginaHtmlTexto = paginaHtmlTexto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
     
                foreach (T item in listaDeElementos)
                {
                    filas += "<tr>";
                    if (typeof(T) == typeof(Curso))
                    {
                        var curso = item as Curso;
                        filas += "<td>" + curso.DescripcionComision + "</td>";
                        filas += "<td>" + curso.Descripcion + "</td>";
                        filas += "<td>" + curso.DescripcionMateria + "</td>";
                        filas += "<td>" + curso.AnioCalendario + "</td>";
                        filas += "<td>" + curso.Cupo + "</td>";
                    }
                    else if (typeof(T) == typeof(Plan))
                    {
                        var plan = item as Plan;
                        filas += "<td>" + plan.Descripcion + "</td>";
                        filas += "<td>" + plan.DescripcionEspecialidad + "</td>";
                    }
                    filas += "</tr>";
                }
                paginaHtmlTexto = paginaHtmlTexto.Replace("@FILAS", filas);
                return paginaHtmlTexto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetPlantilla<T>(List<T> listaDeElementos)
        {
            bool listaDeCursos = listaDeElementos.OfType<Curso>().Any();
            if (listaDeCursos)
                return Properties.Resources.plantillaCursos.ToString();
            else
                return  Properties.Resources.plantillaPlanes.ToString();
        }
    }
}
