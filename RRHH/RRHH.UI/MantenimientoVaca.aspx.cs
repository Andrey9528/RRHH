using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class MantenimientoVaca : System.Web.UI.Page
    {
        public static Empleado empleado = new Empleado();
        public static SolicitudVacaciones vaca = new SolicitudVacaciones();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                 empleado = Singleton.OpEmpleados.BuscarEmpleados(txtcedula.Text);
                
                //List<Empleado> listaEmpleados = Singleton.OpEmpleados.BuscarEmpleados(txtcedula.Text);
               
               
                if (empleado != null)
                {
                    gvdatos.DataSource = Singleton.opsolicitud.Listarsolicitudes().Where(x=>x.Cedula==empleado.Cedula);
                    gvdatos.DataBind();
                }
                else
                {

                     
                    mensajeError.Visible = true;
                    mensaje.Visible = false;
                    mensajawarning.Visible = false;
                    mensajeinfo.Visible = false;
                    textoMensajeError.InnerHtml = "Empleado no existe";

                }

                DDLidsolicitud.DataSource = Singleton.opsolicitud.Listarsolicitudes().Select(x=>x.IdSolicitud).ToList();
                DDLidsolicitud.DataBind();
            }
            catch
            {
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Condicion = DDLestado.Text;
                if (Condicion == "Aprobado")
                {
                    SolicitudVacaciones soli2 = new SolicitudVacaciones();
                    int id = Convert.ToInt32(DDLidsolicitud.Text);

                    soli2 = Singleton.opsolicitud.BuscarSolicitud(id);
                    SolicitudVacaciones soli = new SolicitudVacaciones()
                    {
                        IdSolicitud=soli2.IdSolicitud,
                        Cedula = txtcedula.Text,
                        FechaInicio = soli2.FechaInicio,
                        FechaFinal = soli2.FechaFinal,
                        TotalDias = soli2.TotalDias,
                        Condicion = true
                    };
                    Singleton.opsolicitud.ActualizarSolicitud(soli);
                    mensaje.Visible = true;
                    mensajawarning.Visible = false;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    textoMensaje.InnerHtml = "Solicitud aprobada";


                }
                else
                {
                    SolicitudVacaciones soli2 = new SolicitudVacaciones();
                    int id = Convert.ToInt32(DDLidsolicitud.Text);

                    soli2 = Singleton.opsolicitud.BuscarSolicitud(id);
                    SolicitudVacaciones soli = new SolicitudVacaciones()
                    {
                        IdSolicitud=soli2.IdSolicitud,
                        Cedula = txtcedula.Text,
                        FechaInicio = soli2.FechaInicio,
                        FechaFinal = soli2.FechaFinal,
                        TotalDias = soli2.TotalDias,
                        Condicion =false
                    };
                    Singleton.opsolicitud.ActualizarSolicitud(soli);
                    mensaje.Visible = false;
                    mensajawarning.Visible = false;
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    textoMensajeError.InnerHtml = "Solicitud denegada";


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}