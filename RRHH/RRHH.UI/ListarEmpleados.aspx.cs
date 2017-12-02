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
                string correoLogin = Session["jefeCorreo"].ToString();
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                List<Empleado> listar = Singleton.OpEmpleados.ListarEmpleados();
                    var listaEmple = listar.Select(x => new {x.Cedula, x.Nombre, x.Direccion, x.Telefono, x.Correo, x.EstadoCivil, x.Genero, x.FechaNacimiento, x.Estado ,x.Imagen});
                   
                    //gv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    //gv_datos.DataBind();
                    //listview
                    //lv_empleados.DataSource = listaEmple.Where(x=>x.Estado==true);
                    //lv_empleados.DataBind();
                    //lv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    //lv_datos.DataBind();
                GV_personas.DataSource = listaEmple.Where(x => x.Estado == true);
                GV_personas.DataBind();
                

            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }
        }

        protected void DDLActivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
        List<Empleado> listar = Singleton.OpEmpleados.ListarEmpleados();
            var listaEmple = listar.Select(x => new {x.Cedula, x.Nombre, x.Direccion, x.Telefono, x.Correo, x.EstadoCivil, x.Genero, x.FechaNacimiento, x.Estado,x.Imagen });

            if (DDLActivos.Text == "Activo" && EmpleaoGlobal.Estado==true )
            {

                //lv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                //lv_datos.DataBind();
                mensajeError.Visible = false;
                GV_personas.DataSource = listaEmple.Where(x => x.Estado == true);
               GV_personas.DataBind();
               Singleton.opAudiJefe.InsertarAuditoriasJefe(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, true, false, false, false, false, false, false, false);

                }
                else if (DDLActivos.Text == "Inactivo" && EmpleaoGlobal.Estado==false)    
            {

                //lv_datos.DataSource = listaEmple.Where(x => x.Estado == false);
                //lv_datos.DataBind();
                mensajeError.Visible = false;
                GV_personas.DataSource = listaEmple.Where(x => x.Estado == false);
                GV_personas.DataBind();
                Singleton.opAudiJefe.InsertarAuditoriasJefe(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, true, false, false, false, false, false, false, false);


                }

            }

            catch
            {

                mensajeError.Visible = true;
                textoMensajeError.InnerHtml = "Hubo un error";
                
            }
           
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {

            //CargarPdf(GV_personas);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        public void CargarPdf(GridView gvdatos)
        {



            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
                "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GV_personas.AllowPaging = false;
            GV_personas.DataBind();
            GV_personas.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            //


            //
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=Reporte de Vacaciones.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //gvdatos.AllowPaging = false;
            //gvdatos.DataBind();
            //gvdatos.RenderControl(hw);
            //gvdatos.HeaderRow.Style.Add("width", "15%");
            //gvdatos.HeaderRow.Style.Add("font-size", "10px");
            //gvdatos.Style.Add("text-decoration", "none");
            //gvdatos.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            //gvdatos.Style.Add("font-size", "8px");
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

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("VistaJefe.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

        }
    }
}