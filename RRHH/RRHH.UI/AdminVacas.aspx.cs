using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class AdminVacas : System.Web.UI.Page
    {
        public static int dias;
        SolicitudVacaciones soli = new SolicitudVacaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            Gv_datos.DataSource = Singleton.opsolicitud.Listarsolicitudes();
            Gv_datos.DataBind();
            if (!IsPostBack)
            {
                DDLidsoli.DataSource = Singleton.opsolicitud.Listarsolicitudes().Select(x => x.IdSolicitud).ToList();
                DDLidsoli.DataBind();
            }

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            List<SolicitudVacaciones> lista = Singleton.opsolicitud.Listarsolicitudes();
            var vaca = lista.FirstOrDefault(x => x.IdSolicitud == Convert.ToInt32(DDLidsoli.Text));

            if (vaca != null)
            {


                txtfechaincio.Text = vaca.FechaInicio.ToString();
                txtfechafinal.Text = vaca.FechaFinal.ToString();
                mensajeError.Visible = false;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
            }
            else
            {

            }


        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                List<SolicitudVacaciones> lista = Singleton.opsolicitud.Listarsolicitudes();
                var vaca = lista.FirstOrDefault(x => x.IdSolicitud == Convert.ToInt32(DDLidsoli.Text));


                if (ValidacionDias(txtfechafinal.Text, txtfechaincio.Text))
                {
                    var vacaciones = new SolicitudVacaciones()
                    {
                        IdSolicitud = Convert.ToInt32(DDLidsoli.Text),
                        FechaFinal = Convert.ToDateTime(txtfechafinal.Text),
                        FechaInicio = Convert.ToDateTime(txtfechaincio.Text),
                        Cedula = vaca.Cedula,
                        TotalDias = dias,
                        Condicion = vaca.Condicion,
                    };
                    Singleton.opsolicitud.ActualizarSolicitud(vacaciones);
                    mensaje.Visible = false;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = true;
                    //TimeSpan diferencia = Convert.ToDateTime(txtfechafinal.Text) - Convert.ToDateTime(txtfechadeincio.Text);
                    //var dias = diferencia.TotalDays;
                    //txttotaldias.Text = dias.ToString();
                    textomensajewarning.InnerHtml = "Solicitud actualizada";
                    DDLidsoli.DataSource = Singleton.opsolicitud.Listarsolicitudes().Select(x => x.IdSolicitud).ToList();
                    DDLidsoli.DataBind();
                    txtfechafinal.Text = string.Empty;
                    txtfechaincio.Text = string.Empty;

                }
                else
                {
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    mensaje.Visible = false;
                    textoMensajeError.InnerHtml = "Cantidad de dias incorrecta";

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

    }
}