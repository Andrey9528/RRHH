using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using System.IO;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

namespace RRHH.UI
{
    public partial class consultaVacaciones : System.Web.UI.Page
    {
      public static int valor = 0;
        public static DateTime LaMalditaFecha;
        protected void Page_Load(object sender, EventArgs e)
        {
            gvdatos.DataSource = Singleton.opsolicitud.Listarsolicitudes();
            gvdatos.DataBind();
            DDLAño.Enabled = false;
            DDLcondicion.Enabled = false;
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            string y = "116130806";
            try
            {
                gvdatos.DataSource = Singleton.opsolicitud.ListarVacaciones(LaMalditaFecha, y);//Singleton.opsolicitud.BuscarsolicitudPorId(y).Where(x => x.FechaFinal == Convert.ToDateTime(DDLAño.Text) && x.Cedula == y && x.Condicion == false);
                gvdatos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnexportar_Click(object sender, EventArgs e)
        {
            try
            {

                //using (StringWriter sw = new StringWriter())
                //{
                //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                //    {
                //        gvdatos.RenderControl(hw);
                //        StringReader sr = new StringReader(sw.ToString());
                //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //        pdfDoc.Open();
                //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                //        pdfDoc.Close();
                //        Response.ContentType = "application/pdf";
                //        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //        Response.Write(pdfDoc);
                //        Response.End();
                //    }
                //}
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition",
                // "attachment;filename=GridViewExport.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //gvdatos.AllowPaging = false;
                //gvdatos.DataBind();
                //gvdatos.RenderControl(hw);
                //StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                ////HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

                ////htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();

                //-----------------
                //Exportar a excel
                //Response.Clear();
                //Response.Buffer = true;
                //Response.Charset = "";
                //Response.AddHeader("content-disposition","attachment;filename=GridViewExport.xls");
                //Response.ContentType = "application/ms-excel";
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //gvdatos.AllowPaging = false;
                //gvdatos.DataBind();
                //gvdatos.RenderControl(hw);
                //Response.Output.Write(sw.ToString());
                //Response.Flush();
                //Response.End();
                //------------------

                //Exportar a word
                //-----------
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");
                Response.ContentType = "application/vnd.ms-word";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvdatos.AllowPaging = false;
                gvdatos.DataBind();
                gvdatos.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

                //Exportar a pdf
                // --------------
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition",
                // "attachment;filename=GridViewExport.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //gvdatos.AllowPaging = false;
                //gvdatos.DataBind();
                //gvdatos.RenderControl(hw);
                //StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();

                //-------------

                //---??


            }
            catch (Exception ex)
            {
            
            }

        }
        private void CargarAños()
        {
            try
            {
                string y = "116130806";
                List<SolicitudVacaciones> AñosPrueba = Singleton.opsolicitud.BuscarsolicitudPorId(y);
                foreach (var x in AñosPrueba)
                {
                    var fecha = (AñosPrueba[valor].FechaFinal.Year).ToString();
                    DDLAño.Items.Add(fecha);
                    DDLAño.DataBind();
                    valor = valor + 1;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
       
        protected void DDLAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerControlesConsulta();
        }

        protected void RB_personalizada_CheckedChanged(object sender, EventArgs e)
        {
            VerControlesConsulta();
            CargarAños();
            
        }

        private void VerControlesConsulta()
        {
            try
            {
                if (RB_busquedageneral.Checked )
                {
                    DDLAño.Enabled = false;
                    DDLcondicion.Enabled = false;
                }
                else if (RB_personalizada.Checked)
                {
                    DDLAño.Enabled = true;
                    DDLcondicion.Enabled = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RB_busquedageneral_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}