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

            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                string AdminCorreo = Session["AdminCorreo"].ToString();
                Gv_datos.DataSource = Singleton.opsolicitud.Listarsolicitudes();
                Gv_datos.DataBind();
                txtfechafinal.Enabled = false;
                txtfechaincio.Enabled = false;
                if (!IsPostBack)
                {
                    DDLidsoli.DataSource = Singleton.opsolicitud.Listarsolicitudes().Select(x => x.IdSolicitud).ToList();
                    DDLidsoli.DataBind();
                }
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<SolicitudVacaciones> lista = Singleton.opsolicitud.Listarsolicitudes();
                var vaca = lista.FirstOrDefault(x => x.IdSolicitud == Convert.ToInt32(DDLidsoli.Text));

                if (vaca != null)
                {

                    txtfechafinal.Enabled = true;
                    txtfechaincio.Enabled = true;
                    txtfechaincio.Text = vaca.FechaInicio.ToString();
                    txtfechafinal.Text = vaca.FechaFinal.ToString();
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    mensaje.Visible = false;
                }
                else
                {
                    mensajawarning.Visible = false;
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = false;
                    textoMensajeError.InnerHtml = "Hubo un error";

                }

            }
            catch
            {
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensaje.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtfechaincio.Text) && string.IsNullOrEmpty(txtfechafinal.Text))
                {
                    mensajeError.Visible = false;
                    mensajawarning.Visible = false;
                    mensaje.Visible = false;
                    mensajeinfo.Visible = true;
                    textomensajeinfo.InnerHtml = "Los campos son requeridos";

                }
                else
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
                        NombreEmpleado=vaca.NombreEmpleado
                    };
                    Singleton.opsolicitud.ActualizarSolicitud(vacaciones);
                    Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, true, false, false, false, false, false, false);
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
               


            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";

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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);
            }
            catch
            {
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensaje.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }
    }
}