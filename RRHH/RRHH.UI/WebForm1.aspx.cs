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
        public static int count;
       public static bool estado; // desmadre
        //public static int Vacaciones;
        public static int IdSolicitudVacaciones; 
        List<DateTime> fechas = new List<DateTime>(); 
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //CalculoDiasVacaciones();
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
                    lblDirreccion.Text = "Direccion:" + Login.EmpleadoGlobal.Direccion;
                    lblTelefono.Text = "Telefono: " + Login.EmpleadoGlobal.Telefono;
                    lblCorreo.Text = "Correo: " + Login.EmpleadoGlobal.Correo ;
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
                    //lblSaldoVaca.Text = "Saldo de vacaciones:" + Login.EmpleadoGlobal.DiasVacaciones;
                    //lblSaldoVaca.Text = "Saldo de vacaciones:" + Vacaciones;
                    lblSaldoVaca.Text = "Saldo de vacaciones:" + Login.EmpleadoGlobal.DiasVacaciones;
                    //if (Login.EmpleadoGlobal.DiasAntesCaducidad < 3)
                    if ((Login.EmpleadoGlobal.FechaCaducidadContraseña - DateTime.Today).TotalDays < 3)
                    {
                        mensaje.Visible = false;
                        mensajeError.Visible = false;
                        mensajeinfo.Visible = true;
                        mensajawarning.Visible = false;
                        mensajeinfo.InnerHtml= "Recuerda cambiar tu contraseña al menos una vez cada tres meses\nLa contraseña actual caduca el: " + Login.EmpleadoGlobal.FechaCaducidadContraseña.ToShortDateString();
                       
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

        //public void CalculoDiasVacaciones()
        //{
        //    DateTime FechaIngresoEmpleado = Singleton.OpEmpleados.BuscarEmpleados(Login.EmpleadoGlobal.Cedula).FechaIngreso;
        //    var VacacionesSolcitadas = Singleton.opsolicitud.BuscarsolicitudPorId(Login.EmpleadoGlobal.Cedula).Where(x => x.Condicion == true).Sum(x => x.TotalDias);
        //    Vacaciones = Convert.ToInt32((( DateTime.Today - FechaIngresoEmpleado ).TotalDays/30)-VacacionesSolcitadas);
        //    //int Vacaciones = 12 * (FechaIngresoEmpleado.Year - DateTime.Today.Year) + FechaIngresoEmpleado.Month - DateTime.Today.Month;
        //    //return Math.Abs(monthsApart);

        //}
        public bool ValidarRangoFechas(string fechainicio,string fechafinal)
        {
            try
            {
                //bool estado = true;
                var listaId = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).ToList();
                if (listaId.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (var IdSolicitud in listaId)
                    {

                        if (Convert.ToDateTime(fechainicio) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechainicio) <= Convert.ToDateTime(IdSolicitud.FechaFinal)
                            || Convert.ToDateTime(fechafinal) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechafinal) <= Convert.ToDateTime(IdSolicitud.FechaFinal))
                        {
                            estado = true;     
                        }
                        else
                        {
                            estado = false;
                        }
                    }
                    return estado;
                }  
            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textomensajeError.InnerHtml = "Ha ocurrido un error";
            }
            return estado; 
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
                if (string.IsNullOrEmpty(txtfechadeincio.Text) || string.IsNullOrEmpty(txtfechafinal.Text))
                {

                    mensaje.Visible = false;
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    textomensajeError.InnerHtml = "Debes ingresar un rango de fechas";
                    txtfechafinal.Text = string.Empty;
                    txtfechadeincio.Text = string.Empty;
                }
                else if (ValidacionDias(txtfechafinal.Text, txtfechadeincio.Text))
                {
                    if (Login.EmpleadoGlobal.DiasVacaciones >= dias)
                    {
                        if (ValidarRangoFechas(txtfechadeincio.Text, txtfechafinal.Text))
                        {
                            mensajeinfo.Visible = false;
                            mensajeError.Visible = true;
                            mensaje.Visible = false;
                            textomensajeError.InnerHtml = "Ya existe una solitud previa para el rango de fechas seleccionado";
                            limpiarCamposFechas();
                        }
                        else if (VacacionesIncapacitado(Convert.ToDateTime(txtfechafinal.Text),Convert.ToDateTime(txtfechadeincio.Text)))
                        {
                            mensajeinfo.Visible = false;
                            mensajeError.Visible = true;
                            mensaje.Visible = false;
                            textomensajeError.InnerHtml = "El usuario actual se encuentra incapacitado, la solicitud no puede completarse";
                            limpiarCamposFechas();
                        }
                        else
                        {
                            fechas = Singleton.OpFeriados.ListarFeriados().Select(x => x.Fecha).ToList();
                            DiasRestantes(Convert.ToDateTime(txtfechadeincio.Text), Convert.ToDateTime(txtfechafinal.Text), true, fechas);
                            //IncapacidadEnVacaciones(Convert.ToDateTime(txtfechadeincio.Text), Convert.ToDateTime(txtfechafinal.Text)); // desmadre
                            var vacaciones = new SolicitudVacaciones()
                            {
                                FechaFinal = Convert.ToDateTime(txtfechafinal.Text),
                                FechaInicio = Convert.ToDateTime(txtfechadeincio.Text),
                                Cedula = Login.EmpleadoGlobal.Cedula,
                                TotalDias = count,
                                Condicion = null,
                                NombreEmpleado = Login.EmpleadoGlobal.Nombre

                            };

                            Singleton.opsolicitud.InsertarSolicitud(vacaciones);
                            IdSolicitudVacaciones = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).Select(x => x.IdSolicitud).LastOrDefault();
                            Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, true, false, false, false, false, false, false);

                            mensaje.Visible = true;
                            mensajeError.Visible = false;
                            mensajeinfo.Visible = false;
                            mensajawarning.Visible = false;
                            textoMensaje.InnerHtml = "Solicitud generada";
                            limpiarCamposFechas();

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
                        limpiarCamposFechas();
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
                    limpiarCamposFechas();
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
                Empleado empleado = new Empleado()
                {
                    Cedula = Login.EmpleadoGlobal.Cedula,
                    Nombre = Login.EmpleadoGlobal.Nombre,
                    Direccion = Login.EmpleadoGlobal.Direccion,
                    Telefono = Login.EmpleadoGlobal.Telefono,
                    Correo = Login.EmpleadoGlobal.Correo,
                    EstadoCivil = Login.EmpleadoGlobal.EstadoCivil,
                    Password = Login.EmpleadoGlobal.Password,
                    FechaNacimiento = Login.EmpleadoGlobal.FechaNacimiento,
                    IdDepartamento = Login.EmpleadoGlobal.IdDepartamento,
                    IdRol = Login.EmpleadoGlobal.IdRol,
                    Estado = true,
                    Genero = Login.EmpleadoGlobal.Genero,
                    Imagen = Login.EmpleadoGlobal.Imagen,
                    DiasVacaciones = Login.EmpleadoGlobal.DiasVacaciones,
                    DiasAntesCaducidad = 90,
                    ContraseñaCaducada = false,
                    FechaCaducidadContraseña = Login.EmpleadoGlobal.FechaCaducidadContraseña,
                    FechaIngreso = Login.EmpleadoGlobal.FechaIngreso,
                    SesionIniciada = false,
                    Bloqueado=Login.EmpleadoGlobal.Bloqueado,
                    IntentosFallidos=Login.EmpleadoGlobal.IntentosFallidos

                };
                Singleton.OpEmpleados.ActualizarEmpleados(empleado);

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

        protected void btnConfirmarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdminView.FormatoContraseña(txtContraseñaActualEmpleado.Text.ToString()))
                {
                    txtNuevaContraseña.Enabled = true;
                    txtNuevaContraseñaConfirmar.Enabled = true;
                    btnCambiarEmpleado.Enabled = true;
                    txtContraseñaActualEmpleado.Enabled = false;
                    btnConfirmarEmpleado.Enabled = false;
                    ClientScript.RegisterStartupScript(GetType(), "Modal", "popup();", true);
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

        protected void btnCambiarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (Encriptacion.Decriptar(Login.EmpleadoGlobal.Password ,Encriptacion.Llave)==txtNuevaContraseña.Text)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Las contraseñas no puede ser igual')", true);
                }

              else  if (txtNuevaContraseña.Text == txtNuevaContraseñaConfirmar.Text)
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
                            DiasVacaciones = Login.EmpleadoGlobal.DiasVacaciones,
                            FechaCaducidadContraseña = DateTime.Today.AddMonths(3),
                            FechaIngreso = Login.EmpleadoGlobal.FechaIngreso,
                            SesionIniciada = false,
                            Bloqueado=Login.EmpleadoGlobal.Bloqueado,
                            IntentosFallidos=Login.EmpleadoGlobal.IntentosFallidos,
                        };
                        Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña ha sido modificada, por favor vuelve a iniciar sesión')", true);
                        Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, true, false, false, false);

                        Response.Redirect("Login.aspx");
                        Session.Remove("emple");
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña debe contener al menos:/n un carácter , una letra mayúscula,una letra minúscula y un numero')", true);

                        //ClientScript.RegisterStartupScript(GetType(), "Modal", "popup();", true);

                    }
                }
                
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Las contraseñas no son iguales')", true);
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

        private void EnvioCorreo()
        {
            try
            {
                string mail = Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).EmailJefeDpto.ToString();
                using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
                {
                    cliente.EnableSsl = true;
                    cliente.Credentials = new NetworkCredential("soporte.biblioteca@hotmail.com", "soporte123.");
                    MailMessage msj = new MailMessage("soporte.biblioteca@hotmail.com", mail, "Nueva solicitud de vacaciones", "Se ha recibido una nueva solicitud de vacaciones de parte del empleado\nNombre:  " + Login.EmpleadoGlobal.Nombre + "\nUsuario:" + Login.EmpleadoGlobal.Correo + "\nEl número de la solicitud es: " + IdSolicitudVacaciones);
                    cliente.Send(msj);
                }
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textomensajeError.InnerHtml = "Ha ocurrido un error";
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
                    estado = true;
                }
                else
                {
                    estado = false;
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
            return estado;
        }

        public bool VacacionesIncapacitado(DateTime fechaFinal, DateTime fechadeInicio) // desmadre
        {
           
            try
            {
                
                var ListaIncapacidades = Singleton.opIncapacidad.ListarIncapacidades().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).ToList();
                if (ListaIncapacidades.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (var item in ListaIncapacidades)
                    {
                        if (DateTime.Today == Convert.ToDateTime(item.Fecha_Inicio) || DateTime.Today <= Convert.ToDateTime(item.Fecha_finalizacion))
                        {
                            estado = true;
                        }
                        else
                        {
                            estado = false;
                        }
                    }
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
            return estado;  
        } // desmadre

        protected void LbSesion_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                Cedula = Login.EmpleadoGlobal.Cedula,
                Nombre = Login.EmpleadoGlobal.Nombre,
                Direccion = Login.EmpleadoGlobal.Direccion,
                Telefono = Login.EmpleadoGlobal.Telefono,
                Correo = Login.EmpleadoGlobal.Correo,
                EstadoCivil = Login.EmpleadoGlobal.EstadoCivil,
                Password = Login.EmpleadoGlobal.Password,
                FechaNacimiento = Login.EmpleadoGlobal.FechaNacimiento,
                IdDepartamento = Login.EmpleadoGlobal.IdDepartamento,
                IdRol = Login.EmpleadoGlobal.IdRol,
                Estado = true,
                Genero = Login.EmpleadoGlobal.Genero,
                Imagen = Login.EmpleadoGlobal.Imagen,
                DiasVacaciones = Login.EmpleadoGlobal.DiasVacaciones,
                DiasAntesCaducidad = 90,
                ContraseñaCaducada = false,
                FechaCaducidadContraseña = Login.EmpleadoGlobal.FechaCaducidadContraseña,
                FechaIngreso = Login.EmpleadoGlobal.FechaIngreso,
                SesionIniciada = false,
                Bloqueado=Login.EmpleadoGlobal.Bloqueado,
                IntentosFallidos=Login.EmpleadoGlobal.IntentosFallidos

            };
            Singleton.OpEmpleados.ActualizarEmpleados(empleado);
            Session.Remove("emple");
            Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, true, false, false);

            Response.Redirect("Login.aspx");
        }

        protected void LKB_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, true, false, false, false, false);


                Response.Redirect("Ayuda.aspx");
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textomensajeError.InnerHtml = "Ha ocurrido un error";
            }
        }

        public void limpiarCamposFechas()
        {
            try
            {
                txtfechadeincio.Text = string.Empty;
                txtfechafinal.Text = string.Empty;
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textomensajeError.InnerHtml = "Ha ocurrido un error";
            }
        }

        protected void CerrarPopupVaca_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarCamposFechas();
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textomensajeError.InnerHtml = "Ha ocurrido un error";
            }

        }
    }
}