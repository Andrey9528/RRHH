    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using System.Net.Mail;
using System.Net;

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
                    var cedula = Singleton.opsolicitud.BuscarSolicitud(Convert.ToInt32(DDLidsolicitud.Text)).Cedula;

                    var correo = Singleton.OpEmpleados.BuscarEmpleados(cedula).Correo;
                    var nombre = Singleton.OpEmpleados.BuscarEmpleados(cedula).Nombre;



                    SolicitudVacaciones soli2 = new SolicitudVacaciones();
                    int id = Convert.ToInt32(DDLidsolicitud.Text);

                    soli2 = Singleton.opsolicitud.BuscarSolicitud(id);
                    SolicitudVacaciones soli = new SolicitudVacaciones()
                    {
                        IdSolicitud = soli2.IdSolicitud,
                        Cedula = txtcedula.Text,
                        FechaInicio = soli2.FechaInicio,
                        FechaFinal = soli2.FechaFinal,
                        TotalDias = soli2.TotalDias,
                        Condicion = true
                    };
                    Singleton.opsolicitud.ActualizarSolicitud(soli);
                    




                    
                    //using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
                    //{
                    //    cliente.EnableSsl = true;
                    //    cliente.Credentials = new NetworkCredential("dollars.chat.room@hotmail.com", "fidelitasw2");
                    //    MailMessage msj = new MailMessage("dollars.chat.room@hotmail.com", correo, "Estado de solicitud de vacaciones", "Se ha aprobado su  solicitud de vacaciones de para el  empleado\nNombre:  " + nombre + "\nUsuario:" + correo);
                    //    cliente.Send(msj);



                    //}
                    mensaje.Visible = true;
                    mensajawarning.Visible = false;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    textoMensaje.InnerHtml = "Solicitud aprobada";
                    Email.Notificacion("soporte.biblioteca@hotmail.com", "soporte123.", correo, "Estado de solicitud de vacaciones", "se ha aprobado su solicitud de vacaciones para el empleado \nNombre:" + nombre + "\nUsuario:" + correo);






                }
                else
                {
                    string cedula = Singleton.opsolicitud.BuscarSolicitud(Convert.ToInt32(DDLidsolicitud.Text)).Cedula.ToString();

                    string correo = Singleton.OpEmpleados.BuscarEmpleados(cedula).Correo;
                   string nombre = Singleton.OpEmpleados.BuscarEmpleados(cedula).Nombre;


                    SolicitudVacaciones soli2 = new SolicitudVacaciones();
                    int id = Convert.ToInt32(DDLidsolicitud.Text);

                    soli2 = Singleton.opsolicitud.BuscarSolicitud(id);
                    SolicitudVacaciones soli = new SolicitudVacaciones()
                    {
                        IdSolicitud = soli2.IdSolicitud,
                        Cedula = txtcedula.Text,
                        FechaInicio = soli2.FechaInicio,
                        FechaFinal = soli2.FechaFinal,
                        TotalDias = soli2.TotalDias,
                        Condicion = false
                    };
                    Singleton.opsolicitud.ActualizarSolicitud(soli);
                    mensaje.Visible = false;
                    mensajawarning.Visible = false;
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    textoMensajeError.InnerHtml = "Solicitud denegada";
                    Email.Notificacion("soporte.biblioteca@hotmail.com", "soporte123.", correo, "Estado de solicitud de vacaciones", "se ha denegado su solicitud  de vacaciones para el empleado \nNombre: " + nombre + "\nUsuario: " + correo);

                   


                }
            }
                catch (Exception)
                {

                    throw;
                }
            
        }
    }
   
}