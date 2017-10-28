using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using System.Net.Mail;
using System.Net;
using System.Threading;

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
                if (string.IsNullOrEmpty(txtcedula.Text))
                {
                    mensajeinfo.Visible = true;
                    mensaje.Visible = false;
                    mensajawarning.Visible = false;
                    mensajeError.Visible = false;
                    textomensajeinfo.InnerHtml = "Cedula es requerida";
                }
                else


                {




                    empleado = Singleton.OpEmpleados.BuscarEmpleados(txtcedula.Text);

                    //List<Empleado> listaEmpleados = Singleton.OpEmpleados.BuscarEmpleados(txtcedula.Text);


                    if (empleado != null)
                    {
                        mensajeError.Visible = false;
                        mensaje.Visible = false;
                        mensajawarning.Visible = false;
                        mensajeinfo.Visible = false;
                        gvdatos.DataSource = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == empleado.Cedula);
                        //var lista = Singleton.opsolicitud.BuscarsolicitudPorId2(empleado.Cedula).Select(x => x.IdSolicitud).ToList();
                        gvdatos.DataSource = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == empleado.Cedula);
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

                    DDLidsolicitud.DataSource = Singleton.opsolicitud.BuscarsolicitudPorId(empleado.Cedula).Select(x => x.IdSolicitud); //Singleton.opsolicitud.Listarsolicitudes().Select(x=>x.IdSolicitud).ToList();
                    DDLidsolicitud.DataBind();



                }


                   
            }
            catch
            {

                mensajeinfo.Visible = false;
                mensajeError.Visible = true;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
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

                    var CantidadDias = Singleton.OpEmpleados.BuscarEmpleados(cedula).DiasVacaciones;


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
                        Condicion = true,
                    };
                    Singleton.opsolicitud.ActualizarSolicitud(soli);

                     Empleado EmpleadoGlobal2 = new Empleado();
                     EmpleadoGlobal2 =Singleton.OpEmpleados.BuscarEmpleados(txtcedula.Text);
                     Empleado emple = new Empleado()
                    {
                        Cedula = EmpleadoGlobal2.Cedula,
                        Nombre = EmpleadoGlobal2.Nombre,
                         Direccion = EmpleadoGlobal2.Direccion,
                         Telefono = EmpleadoGlobal2.Telefono,
                         Correo = EmpleadoGlobal2.Correo,
                         EstadoCivil = EmpleadoGlobal2.EstadoCivil,
                         FechaNacimiento = Convert.ToDateTime(EmpleadoGlobal2.FechaNacimiento),
                        IdDepartamento = Convert.ToInt32(EmpleadoGlobal2.IdDepartamento),
                        IdRol = Convert.ToInt32(EmpleadoGlobal2.IdRol),
                        Estado = EmpleadoGlobal2.Estado,
                        Bloqueado = EmpleadoGlobal2.Bloqueado,
                        Imagen = EmpleadoGlobal2.Imagen,
                        //  Genero = DDLgenero.SelectedItem.ToString(),
                        Genero = EmpleadoGlobal2.Genero,
                        Password = EmpleadoGlobal2.Password,
                        IntentosFallidos = Convert.ToInt32(EmpleadoGlobal2.IntentosFallidos),
                        DiasVacaciones = EmpleadoGlobal2.DiasVacaciones-soli2.TotalDias,
                        DiasAntesCaducidad=EmpleadoGlobal2.DiasAntesCaducidad
                    };
                    Singleton.OpEmpleados.ActualizarEmpleados(emple);





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
                    ThreadStart delegado = new ThreadStart(EnvioCorreo);
                    Thread hilo = new Thread(delegado);
                    textoMensaje.InnerHtml = "Solicitud aprobada";
                    hilo.Start();
                    //codigo bueno
                    //textoMensaje.InnerHtml = "Solicitud aprobada";


                    //Email.Notificacion("soporte.biblioteca@hotmail.com", "soporte123.", correo, "Estado de solicitud de vacaciones", "se ha aprobado su solicitud de vacaciones para el empleado \nNombre:" + nombre + "\nUsuario:" + correo);
                    //termina bueno





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

                mensajeinfo.Visible = false;
                mensaje.Visible = false;
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                textoMensajeError.InnerHtml = "Hubo un error";

                }
            
        }

        private void EnvioCorreo()
        {
            try
            {
                var cedula = Singleton.opsolicitud.BuscarSolicitud(Convert.ToInt32(DDLidsolicitud.Text)).Cedula;

                var correo = Singleton.OpEmpleados.BuscarEmpleados(cedula).Correo;
                var nombre = Singleton.OpEmpleados.BuscarEmpleados(cedula).Nombre;

                Email.Notificacion("soporte.biblioteca@hotmail.com", "soporte123.", correo, "Estado de solicitud de vacaciones", "se ha aprobado su solicitud de vacaciones para el empleado \nNombre:" + nombre + "\nUsuario:" + correo);
            }
            catch
            {
                mensajeinfo.Visible = false;
                mensaje.Visible = false;
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("VistaJefe.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

        }
    }
   
}