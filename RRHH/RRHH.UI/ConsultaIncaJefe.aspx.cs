using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;

namespace RRHH.UI
{
    public partial class ConsultaIncaJefe : System.Web.UI.Page
    {
        public static int dias;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string correoLogin = Session["jefeCorreo"].ToString();
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                if (!IsPostBack)
                {
                    gvdatos.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula);
                    gvdatos.DataBind();
                    txtfechafinal.Enabled = false;
                    txtfechainicio.Enabled = false;
                    Btnbusca.Enabled = false;
                }
                else
                {
                    gvdatos.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula);
                    gvdatos.DataBind();
                    txtfechafinal.Enabled = false;
                    txtfechainicio.Enabled = false;
                    Btnbusca.Enabled = true;
                }
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
               
        }

        protected void RB_personalizada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                VerControlesConsulta();
                txtfechafinal.Enabled = true;
                txtfechainicio.Enabled = true;
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }
        }

        protected void RB_busquedageneral_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                VerControlesConsulta();
                gvdatos.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula);
                gvdatos.DataBind();
                txtfechafinal.Enabled = false;
                txtfechainicio.Enabled = false;
                txtfechafinal.Text = string.Empty;
                txtfechainicio.Text = string.Empty;
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }
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
                        gvdatos.DataSource = Singleton.opIncapacidad.ListarIncapacidades2(inicio, final, Login.EmpleadoGlobal.Cedula);//Singleton.opsolicitud.BuscarsolicitudPorId(y).Where(x => x.FechaFinal == Convert.ToDateTime(DDLAño.Text) && x.Cedula == y && x.Condicion == false);
                        gvdatos.DataBind();
                        btnexportar.Enabled = true;
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
                        txtfechafinal.Text = string.Empty;
                        txtfechainicio.Text = string.Empty;
                        txtfechafinal.Enabled = true;
                        txtfechainicio.Enabled = true;
                        Btnbusca.Enabled = true;
                    }

                }
                else
                {
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = true;
                    textoMensajeError.InnerHtml = "Debes elegir un rango de fechas valido";
                    txtfechafinal.Text = string.Empty;
                    txtfechainicio.Text = string.Empty;
                    txtfechafinal.Enabled = true;
                    txtfechainicio.Enabled = true;
                    Btnbusca.Enabled = true;

                }



            }
            catch (Exception)
            {

                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }

        }
        public void CargarPdf(GridView gvdatos)
        {


            //


            //
            try
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Reporte de Incapacidades.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvdatos.AllowPaging = false;
                gvdatos.DataBind();
                gvdatos.RenderControl(hw);
                gvdatos.HeaderRow.Style.Add("width", "15%");
                gvdatos.HeaderRow.Style.Add("font-size", "10px");
                gvdatos.Style.Add("text-decoration", "none");
                gvdatos.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                gvdatos.Style.Add("font-size", "8px");
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);

                //

                //
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Add(new Chunk("\n"));
                pdfDoc.Add(new Chunk("\n"));
                Paragraph prgGeneratedBY = new Paragraph();
                BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
                prgGeneratedBY.Add(new Chunk("Reporte generado por : RRHH Farmacias San Gabriel"));
                prgGeneratedBY.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString()));
                pdfDoc.Add(prgGeneratedBY);
                //
                pdfDoc.Close();
                //Response.AddHeader("content-disposition", "attachment;" + "filename=Reporte de Incapacidades.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }
        }

        protected void btnexportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (RB_busquedageneral.Checked)
                {
                    CargarPdf(gvdatos);
                }
                else if (RB_personalizada.Checked)
                {
                    DateTime inicio = Convert.ToDateTime(txtfechainicio.Text);
                    DateTime final = Convert.ToDateTime(txtfechafinal.Text);
                    gvdatos.DataSource = null;
                    gvdatos.DataSource = Singleton.opIncapacidad.ListarIncapacidades2(inicio, final, Login.EmpleadoGlobal.Cedula);//Singleton.opsolicitud.BuscarsolicitudPorId(y).Where(x => x.FechaFinal == Convert.ToDateTime(DDLAño.Text) && x.Cedula == y && x.Condicion == false);
                    gvdatos.DataBind();
                    CargarPdf(gvdatos);
                    Btnbusca.Enabled = true;
                }


            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }

        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("VistaJefe.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }
        }

        private void VerControlesConsulta()
        {
            try
            {
                if (RB_busquedageneral.Checked)
                {
                    btnexportar.Enabled = true;
                    txtfechainicio.Enabled = false;
                    txtfechafinal.Enabled = false;
                    Btnbusca.Enabled = false;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;

                }
                else if (RB_personalizada.Checked)
                {
                    btnexportar.Enabled = false;
                    txtfechainicio.Enabled = true;
                    txtfechafinal.Enabled = true;
                    Btnbusca.Enabled = true;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;
                }

            }
            catch (Exception)
            {

                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
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