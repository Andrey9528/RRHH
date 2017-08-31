using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using RRHH.DS.Metodos;

namespace RRHH.UI
{
    public partial class InsertarSolicitud : System.Web.UI.Page
    {
        public static int dias;
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtfechadeincio.Text = System.DateTime.Now.ToString();
        }

        protected void btninsertar_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime FechaSalida = Convert.ToDateTime(txtidsolicitud.Text);
                //DateTime FechaRetorno = Convert.ToDateTime(txtfechafinal.Text);
                //int TotalDias = Convert.ToInt32(FechaRetorno - FechaSalida);
                if (ValidacionDias(txtfechafinal.Text,txtfechadeincio.Text))
                {
                    var vacaciones = new SolicitudVacaciones()
                    {
                        IdSolicitud = Convert.ToInt32(txtidsolicitud.Text),
                        FechaFinal = Convert.ToDateTime(txtfechafinal.Text),
                        FechaInicio = Convert.ToDateTime(txtfechadeincio.Text),
                        Cedula = Login.EmpleadoGlobal.Cedula,
                        TotalDias = dias,
                        Condicion = false,      
                   };
                Singleton.opsolicitud.InsertarSolicitud(vacaciones);
                mensaje.Visible = true;
                //TimeSpan diferencia = Convert.ToDateTime(txtfechafinal.Text) - Convert.ToDateTime(txtfechadeincio.Text);
                //var dias = diferencia.TotalDays;
                //txttotaldias.Text = dias.ToString();
                textoMensaje.InnerHtml = "Solicitud generada";
                }
                else
                {
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    mensaje.Visible = false;
                    textoMensajeError.InnerHtml = "Cantidad de dias incorrecta";
                    txtfechafinal.Focus();
                }
                

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidacionDias(string fechaFinal, string fechadeInicio)
        {
            try
            {
                TimeSpan diferencia = Convert.ToDateTime(fechaFinal) - Convert.ToDateTime(fechadeInicio);
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
        protected void txttotaldias_TextChanged(object sender, EventArgs e)
        {
        
            //var TotalDias = ((txtfechafinal.Text).Date - FechaSalida).TotalDays;

            //txttotaldias.Text = TotalDias.ToString();
            //TimeSpan diferencia = Convert.ToDateTime(txtfechafinal.Text) - Convert.ToDateTime(txtfechadeincio.Text);
            //var dias =diferencia.TotalDays;
            //txttotaldias.Text = dias.ToString();
        }

        //protected void txtfechafinal_TextChanged(object sender, EventArgs e)
        //{
        //    TimeSpan diferencia2 = Convert.ToDateTime(txtfechafinal.Text) - Convert.ToDateTime(txtfechadeincio.Text);
        //    int dias2 = Convert.ToInt32(diferencia2.TotalDays);
        //    txttotaldias.Text = dias2.ToString();
        //}
    }
}