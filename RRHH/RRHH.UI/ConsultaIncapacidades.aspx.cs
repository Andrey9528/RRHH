using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;




namespace RRHH.UI
{
    public partial class ConsultaIncapacidades : System.Web.UI.Page
    {
        public static int dias;
        protected void Page_Load(object sender, EventArgs e)
        {
            gvdatos.DataSource = Singleton.opIncapacidad.ListarIncapacidades();
            gvdatos.DataBind();
            txtfechafinal.Enabled = false;
            txtfechainicio.Enabled = false;
            mensajeinfo.Visible = false;
            mensajeError.Visible = false;
            Btnbusca.Enabled = false;
            
        }

       
       
        protected void RB_personalizada_CheckedChanged(object sender, EventArgs e)
        {
            VerControlesConsulta();


        }

        protected void RB_busquedageneral_CheckedChanged(object sender, EventArgs e)
        {
            VerControlesConsulta();


        }

        protected void Btnbusca_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(txtfechafinal.Text)) && (!string.IsNullOrEmpty(txtfechainicio.Text)))
                {
                    if (ValidacionDias(Convert.ToDateTime(txtfechafinal.Text), Convert.ToDateTime(txtfechainicio.Text)))
                    {
                        
                        
                            DateTime inicio = Convert.ToDateTime(txtfechainicio.Text);
                            DateTime final = Convert.ToDateTime(txtfechafinal.Text);
                            gvdatos.DataSource = Singleton.opIncapacidad.ListarIncapacidades(inicio, final, Login.EmpleadoGlobal.Cedula);//Singleton.opsolicitud.BuscarsolicitudPorId(y).Where(x => x.FechaFinal == Convert.ToDateTime(DDLAño.Text) && x.Cedula == y && x.Condicion == false);
                            gvdatos.DataBind();
                            txtfechafinal.Enabled = true;
                            txtfechainicio.Enabled = true;
                            mensajeinfo.Visible = false;
                            mensajeError.Visible = false;
                        
                        
                        
                    }
                    else
                    {
                        mensajeinfo.Visible = true;
                        mensajeError.Visible = false;
                        textomensajeinfo.InnerHtml = "El rango de fechas elegido no es valido";
                    }

                }
                else
                {
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = true;
                    textoMensajeError.InnerHtml = "Debes elegir un rango de fechas valido";
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnexportar_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=Article.pdf";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/pdf";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvdatos.RenderControl(htextw);
            Document document = new Document();
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            StringReader str = new StringReader(stw.ToString());
            HTMLWorker htmlworker = new HTMLWorker(document);
            htmlworker.Parse(str);
            document.Close();
            Response.Write(document);
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        
        private void VerControlesConsulta()
        {
            try
            {
                if (RB_busquedageneral.Checked)
                {
                    txtfechainicio.Enabled = false;
                    txtfechafinal.Enabled = false;
                    Btnbusca.Enabled = false;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;

                }
                else if (RB_personalizada.Checked)
                {
                    txtfechainicio.Enabled = true;
                    txtfechafinal.Enabled = true;
                    Btnbusca.Enabled = true;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ValidacionDias(DateTime fechaFinal, DateTime fechadeInicio)
        {
            try
            {
                TimeSpan diferencia = fechaFinal - fechadeInicio;
                dias = Convert.ToInt32(diferencia.TotalDays);
                if (dias > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}