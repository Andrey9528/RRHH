using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Data;
using Spire.DataExport;
using Spire.DataExport.ResourceMgr;
using Spire.License;

namespace RRHH.UI
{
    public partial class Lista_de_Empleados : System.Web.UI.Page
    {
        public static Empleado EmpleaoGlobal = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                    List<Empleado> listar = Singleton.OpEmpleados.ListarEmpleados();
                    var listaEmple = listar.Select(x => new {x.Cedula, x.Nombre, x.Direccion, x.Telefono, x.Correo, x.EstadoCivil, x.Genero, x.FechaNacimiento, x.Estado ,x.Imagen});
                   
                    //gv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    //gv_datos.DataBind();
                    //listview
                    //lv_empleados.DataSource = listaEmple.Where(x=>x.Estado==true);
                    //lv_empleados.DataBind();
                    lv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    lv_datos.DataBind();
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DDLActivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Empleado> listar = Singleton.OpEmpleados.ListarEmpleados();
            var listaEmple = listar.Select(x => new {x.Cedula, x.Nombre, x.Direccion, x.Telefono, x.Correo, x.EstadoCivil, x.Genero, x.FechaNacimiento, x.Estado,x.Imagen });

            if (DDLActivos.Text == "Activo" && EmpleaoGlobal.Estado==true )
            {
                
                lv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    lv_datos.DataBind();
            }
            else if (DDLActivos.Text == "Inactivo" && EmpleaoGlobal.Estado==false)    
            {

                lv_datos.DataSource = listaEmple.Where(x => x.Estado == false);
                lv_datos.DataBind();
            }
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            CargarPdf(lv_datos);
        }
        public void CargarPdf(ListView lvdatos)
        {
          

            //DataTable dt = new DataTable();
            //foreach (ListViewItem item in lvdatos.Items)
            //{

            //}


            //Spire.DataExport.PDF.PDFExport PDFExport = new Spire.DataExport.PDF.PDFExport();
            //PDFExport.DataSource = Spire.DataExport.Common.ExportSource.DataTable;
            //PDFExport.DataTable = dt;
            //PDFExport.SaveToFile("SpireExport.pdf");

            //

            //pdf
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=Listado de empleados.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //lv_datos.AllowPaging = false;
            //lv_datos.DataBind();
            //lv_datos.RenderControl(hw);
            //lv_datos.HeaderRow.Style.Add("width", "15%");
            //lv_datos.HeaderRow.Style.Add("font-size", "10px");
            //lv_datos.Style.Add("text-decoration", "none");
            //lv_datos.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            //lv_datos.Style.Add("font-size", "8px");
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);

            ////

            ////
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Add(new Chunk("\n"));
            //pdfDoc.Add(new Chunk("\n"));
            //Paragraph prgGeneratedBY = new Paragraph();
            //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
            //prgGeneratedBY.Add(new Chunk("Reporte generado por : RRHH Farmacias San Gabriel"));
            //prgGeneratedBY.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString()));
            //pdfDoc.Add(prgGeneratedBY);
            ////
            //pdfDoc.Close();
            ////Response.AddHeader("content-disposition", "attachment;" + "filename=Reporte de Incapacidades.pdf");
            ////Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Write(pdfDoc);
            //Response.End();

        }
    }
}