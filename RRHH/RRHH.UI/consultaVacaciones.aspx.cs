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


namespace RRHH.UI
{
    public partial class consultaVacaciones : System.Web.UI.Page
    {
      //public static int valor = 0;
        
        public static int dias;
        protected void Page_Load(object sender, EventArgs e)
        {
            gvdatos.DataSource = Singleton.opsolicitud.Listarsolicitudes().Where(x=> x.Cedula ==Login.EmpleadoGlobal.Cedula);
            gvdatos.DataBind();
            txtfechainicio.Enabled = false;
            DDLcondicion.Enabled = false;
            txtfechafinal.Enabled = false;
           // btnbuscar.Enabled = false;
            mensajeinfo.Visible = false;
            mensajeError.Visible = false;
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

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(txtfechafinal.Text))&&(!string.IsNullOrEmpty(txtfechainicio.Text)))
                {
                    if (ValidacionDias(Convert.ToDateTime(txtfechafinal.Text),Convert.ToDateTime(txtfechainicio.Text)))
                    {
                        if (DDLcondicion.Text == "Aceptado")
                        {
                        DateTime inicio = Convert.ToDateTime(txtfechainicio.Text);
                        DateTime final = Convert.ToDateTime(txtfechafinal.Text);
                        gvdatos.DataSource = Singleton.opsolicitud.ListarVacaciones(inicio, final, Login.EmpleadoGlobal.Cedula, true);//Singleton.opsolicitud.BuscarsolicitudPorId(y).Where(x => x.FechaFinal == Convert.ToDateTime(DDLAño.Text) && x.Cedula == y && x.Condicion == false);
                        gvdatos.DataBind();
                        txtfechafinal.Enabled = true;
                        DDLcondicion.Enabled = true;
                        txtfechainicio.Enabled = true;
                        mensajeinfo.Visible = false;
                        mensajeError.Visible = false;
                        }
                        else if (DDLcondicion.Text == "Denegado")
                        {
                        DateTime inicio = Convert.ToDateTime(txtfechainicio.Text);
                        DateTime final = Convert.ToDateTime(txtfechafinal.Text);
                        gvdatos.DataSource = Singleton.opsolicitud.ListarVacaciones(inicio, final, Login.EmpleadoGlobal.Cedula, false);//Singleton.opsolicitud.BuscarsolicitudPorId(y).Where(x => x.FechaFinal == Convert.ToDateTime(DDLAño.Text) && x.Cedula == y && x.Condicion == false);
                        gvdatos.DataBind();
                        txtfechafinal.Enabled = true;
                        DDLcondicion.Enabled = true;
                        txtfechainicio.Enabled = true;
                        mensajeinfo.Visible = false;
                        mensajeError.Visible = false;
                       }
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnexportar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
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
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();


            }
            catch (Exception ex)
            {
            
            }

        }
        //private void CargarAños()
        //{
        //    try
        //    {
        //        string y = "116130806";
        //        List<SolicitudVacaciones> AñosPrueba = Singleton.opsolicitud.BuscarsolicitudPorId(y);
        //        foreach (var x in AñosPrueba)
        //        {
        //            var fecha = (AñosPrueba[valor].FechaFinal.Year).ToString();
        //            DDLAño.Items.Add(fecha);
        //            DDLAño.DataBind();
        //            valor = valor + 1;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
       
        protected void DDLAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void RB_personalizada_CheckedChanged(object sender, EventArgs e)
        {
            VerControlesConsulta();
          
            
        }

        private void VerControlesConsulta()
        {
            try
            {
                if (RB_busquedageneral.Checked )
                {
                    txtfechainicio.Enabled = false;
                    DDLcondicion.Enabled = false;
                    txtfechafinal.Enabled = false;
                    btnbuscar.Enabled = false;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;

                }
                else if (RB_personalizada.Checked)
                {
                    txtfechainicio.Enabled = true;
                    DDLcondicion.Enabled = true;
                    txtfechafinal.Enabled = true;
                    btnbuscar.Enabled = true;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;
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

        protected void btnreportar_Click(object sender, EventArgs e)
        {

        }
    }
}