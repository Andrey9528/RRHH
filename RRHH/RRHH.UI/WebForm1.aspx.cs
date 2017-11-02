using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace RRHH.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int dias;
        public static string nombrearchivo;
        public static int count; // desmadre
        public static int IdSolicitudVacaciones; ///
        List<DateTime> fechas = new List<DateTime>(); //desmadre
        //DateTime FechaMinima = Convert.ToDateTime(Singleton.OpRangoFechas.RangoFechasVacaciones(Login.EmpleadoGlobal.Cedula).Select(x => x.FechaInicioMenor)); //
        //DateTime FechaMaxima = Convert.ToDateTime(Singleton.OpRangoFechas.RangoFechasVacaciones(Login.EmpleadoGlobal.Cedula).Select(x => x.FechaInicioMayor)); //
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string correo = Session["emple"].ToString();  
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                if (Request.QueryString["ROL"] != null)
                {

                    mensajawarning.Visible = false;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = false;
                    lblnombre.Text = "Nombre: " + Login.EmpleadoGlobal.Nombre;
                    lblCedula.Text = "Cédula:" + Login.EmpleadoGlobal.Cedula;
                    lblDirreccion.Text = "Dirreccion:" + Login.EmpleadoGlobal.Direccion;
                    lblTelefono.Text = "Telefono: " + Login.EmpleadoGlobal.Telefono;
                    lblCorreo.Text = "Correo: " + Login.EmpleadoGlobal.Correo;
                    lblestadocivil.Text = "Estado Civil: " + Login.EmpleadoGlobal.EstadoCivil;
                    lblfechaNaci.Text = "Fecha nacimiento: " + Login.EmpleadoGlobal.FechaNacimiento;
                    lbldepa.Text = "Departamento: " + Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).Nombre;
                    //lblRol.Text = "Rol: " + Singleton.oproles.BuscarRoles(Login.EmpleadoGlobal.IdRol).Nombre;
                    imgPerfil.ImageUrl = Login.EmpleadoGlobal.Imagen;
                    Image1.ImageUrl = Login.EmpleadoGlobal.Imagen;
                    lblNombre2.Text = Login.EmpleadoGlobal.Nombre;
                    lblcorreo2.Text = "Correo: " + Login.EmpleadoGlobal.Correo;
                    lbldirreccion2.Text = "Dirección:" + Login.EmpleadoGlobal.Direccion;
                    lblGenero2.Text = "Genero:" + Login.EmpleadoGlobal.Genero;
                    lblSaldoVaca.Text = "Saldo de vacaciones:" + Login.EmpleadoGlobal.DiasVacaciones;
                    if (Login.EmpleadoGlobal.DiasAntesCaducidad < 3)
                    {
                        mensaje.Visible = false;
                        mensajeError.Visible = false;
                        mensajeinfo.Visible = true;
                        mensajawarning.Visible = false;
                        mensajeinfo.InnerHtml= "Recuerda cambiar tu contraseña al menos una vez cada tres meses\nLa contraseña actual caduca en " + Login.EmpleadoGlobal.DiasAntesCaducidad + " dias";
                       
                    }
                }
                else
                {
                    Response.Redirect("Error.aspx");
                }
                }
            catch
            {
                Response.Redirect("Login.aspx?men=1");

            }

        }

        public bool ValidarRangoFechas(string fechainicio,string fechafinal)
        {
            try
            {
                var listaId = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).ToList();
                foreach (var IdSolicitud in listaId)
                {

                    if (Convert.ToDateTime(fechainicio) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechainicio) <= Convert.ToDateTime(IdSolicitud.FechaFinal)
                        || Convert.ToDateTime(fechafinal) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechafinal) <= Convert.ToDateTime(IdSolicitud.FechaFinal))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textomensajeError.InnerHtml = "Ha ocurrido un error";
            }
            return false;
        }

        public static int DiasRestantes(DateTime startDate, DateTime endDate, Boolean excludeWeekends, List<DateTime> excludeDates)
        {
             count = 0;
            for (DateTime index = startDate; index < endDate; index = index.AddDays(1))
            {
                if (excludeWeekends && index.DayOfWeek != DayOfWeek.Sunday)
                {
                    bool excluded = false; ;
                    for (int i = 0; i < excludeDates.Count; i++)
                    {
                        if (index.Date.CompareTo(excludeDates[i].Date) == 0)
                        {
                            excluded = true;
                            break;
                        }
                    }

                    if (!excluded)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

  

        protected void btnvaca_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacionDias(txtfechafinal.Text, txtfechadeincio.Text))
                {
                    if (Login.EmpleadoGlobal.DiasVacaciones >= dias)
                    {
                        if (ValidarRangoFechas(txtfechadeincio.Text,txtfechafinal.Text))
                        {
                            mensajeinfo.Visible = false;
                            mensajeError.Visible = true;
                            mensaje.Visible = false;
                            textomensajeError.InnerHtml = "Ya existe una solitud previa para el rango de fechas seleccionado";
                        }
                        else
                        {
                            fechas = Singleton.OpFeriados.ListarFeriados().Select(x => x.Fecha).ToList();
                            DiasRestantes(Convert.ToDateTime(txtfechadeincio.Text), Convert.ToDateTime(txtfechafinal.Text), true,fechas ); // desmadre
                            var vacaciones = new SolicitudVacaciones()
                            {
                                FechaFinal = Convert.ToDateTime(txtfechafinal.Text),
                                FechaInicio = Convert.ToDateTime(txtfechadeincio.Text),
                                Cedula = Login.EmpleadoGlobal.Cedula,
                                TotalDias = count,
                                Condicion = null,
                            };

                            Singleton.opsolicitud.InsertarSolicitud(vacaciones);
                            IdSolicitudVacaciones = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).Select(x => x.IdSolicitud).LastOrDefault();
                            Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, true, false, false, false, false, false, false);

                            mensaje.Visible = true;
                            mensajeError.Visible = false;
                            mensajeinfo.Visible = false;
                            mensajawarning.Visible = false;
                            
                            //TimeSpan diferencia = Convert.ToDateTime(txtfechafinal.Text) - Convert.ToDateTime(txtfechadeincio.Text);
                            //var dias = diferencia.TotalDays;
                            //txttotaldias.Text = dias.ToString();
                            textoMensaje.InnerHtml = "Solicitud generada";
                            limpiarCamposFechas();
                            //string mail = Singleton.opNotificacion.CorreoJefe(Login.EmpleadoGlobal.Cedula).Select(x => x.EmailJefeDpto).ToString();
                            //bueno   
                            //string mail = Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).EmailJefeDpto.ToString();
                            //Email.Notificacion("dollars.chat.room@hotmail.com", "fidelitasw2", mail, "Nueva solicitud de vacaciones", "se ha recibido una nueva solicitud de vacaciones de parte del empleado\nNombre:" + Login.EmpleadoGlobal.Nombre + "\nUsuario:" + Login.EmpleadoGlobal.Correo);
                            //termina bueno

                            ThreadStart delegado = new ThreadStart(EnvioCorreo);
                            Thread hilo = new Thread(delegado);
                            hilo.Start();
                            mensajeinfo.Visible = true;
                            mensajeError.Visible = false;
                            mensaje.Visible = false;
                            textomensajeinfo.InnerHtml = "Tu solicitud ha sido enviada";
                            //}
                        }
                    }
                    else
                    {
                        mensajeError.Visible = true;
                        mensajeinfo.Visible = false;
                        mensajawarning.Visible = false;
                        mensaje.Visible = false;
                        textomensajeError.InnerHtml = "La cantidad de dias solicitados excede la cantidad de dias disponibles";
                        txtfechafinal.Focus();
                    }
               }

                else
                {
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    mensaje.Visible = false;
                    textomensajeError.InnerHtml = "Cantidad de dias incorrecta";
                    txtfechafinal.Focus();
                }





            }
            catch (Exception)
            {
                mensajawarning.Visible = false;
                mensajeinfo.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                textomensajeError.InnerHtml = "Hubo un error";
            }


        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            try
            {
                Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, true, false, false, false, false, false, false, false, false, false, false);
                ClientScript.RegisterStartupScript(GetType(), "Modal", "popupCerrarPerfil();", true);

            }
            catch (Exception)
            {

                
            }
        }

        protected void btnConfirmarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdminView.FormatoContraseña(txtContraseñaActualEmpleado.Text.ToString()))
                {
                    txtNuevaContraseña.Enabled = true;
                    txtNuevaContraseñaConfirmar.Enabled = true;
                    btnCambiarEmpleado.Enabled = true;
                    ClientScript.RegisterStartupScript(GetType(), "Modal", "popup();", true);


                }
                else
                {

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnCambiarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevaContraseña.Text == txtNuevaContraseñaConfirmar.Text)
                {
                    if (PasswordPolicy.FormatoContraseña(txtNuevaContraseña.Text))

                    {
                        Empleado empleado = new Empleado()
                        {
                            Cedula = Login.EmpleadoGlobal.Cedula,
                            Nombre = Login.EmpleadoGlobal.Nombre,
                            Direccion = Login.EmpleadoGlobal.Direccion,
                            Telefono = Login.EmpleadoGlobal.Telefono,
                            Correo = Login.EmpleadoGlobal.Correo,
                            EstadoCivil = Login.EmpleadoGlobal.EstadoCivil,
                            Password = Encriptacion.Encriptar(txtNuevaContraseñaConfirmar.Text, Encriptacion.Llave),
                            FechaNacimiento = Login.EmpleadoGlobal.FechaNacimiento,
                            IdDepartamento = Login.EmpleadoGlobal.IdDepartamento,
                            IdRol = Login.EmpleadoGlobal.IdRol,
                            Imagen = Login.EmpleadoGlobal.Imagen,
                            Genero = Login.EmpleadoGlobal.Genero,
                            Estado = true,
                            DiasAntesCaducidad = 90,
                            ContraseñaCaducada = false,
                            DiasVacaciones=Login.EmpleadoGlobal.DiasVacaciones
                        };
                        Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña ha sido modificada, por favor vuelve a iniciar sesión')", true);
                        Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, true, false, false, false);

                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña debe contener al menos:/n un carácter , una letra mayúscula,una letra minúscula y un numero')", true);

                        //ClientScript.RegisterStartupScript(GetType(), "Modal", "popup();", true);

                    }
                }
                else
                {
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Las contraseñas no son iguales')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void EnvioCorreo()
        {
            string mail = Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).EmailJefeDpto.ToString();
            using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
            {
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential("dollars.chat.room@hotmail.com", "fidelitasw2");
                MailMessage msj = new MailMessage("dollars.chat.room@hotmail.com", mail, "Nueva solicitud de vacaciones", "Se ha recibido una nueva solicitud de vacaciones de parte del empleado\nNombre:  " + Login.EmpleadoGlobal.Nombre + "\nUsuario:" + Login.EmpleadoGlobal.Correo+ "\nEl número de la solicitud es: "+ IdSolicitudVacaciones );
                cliente.Send(msj);
            }
        }

        protected void btnSalirEmpleado_Click(object sender, EventArgs e)
        {

        }
        public bool ValidacionDias(string fechaFinal, string fechadeInicio)
        {
            try
            {
                TimeSpan diferencia = Convert.ToDateTime(fechaFinal) - Convert.ToDateTime(fechadeInicio);
                dias = Convert.ToInt32(diferencia.TotalDays);
                if (dias >= 1)
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

        protected void LbSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("emple");
            Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, true, false, false);

            Response.Redirect("Login.aspx");
        }

        protected void LKB_Ayuda_Click(object sender, EventArgs e)
        {
            Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, true,false, false, false, false);


            Response.Redirect("Ayuda.aspx");
        }

        public void limpiarCamposFechas()
        {
            txtfechadeincio.Text = string.Empty;
            txtfechafinal.Text = string.Empty;
        }
    }
}