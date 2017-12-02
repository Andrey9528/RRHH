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
    public partial class AdminView : System.Web.UI.Page
    {
        public static int dias;
        public static int count;
        public static bool estado;
        public static int IdSolicitudVacaciones;
        List<DateTime> fechas = new List<DateTime>();
        public static Empleado EmpleadoGlobal = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["ROL"] =Login.EmpleadoGlobal.IdRol;
                string AdminCorreo = Session["AdminCorreo"].ToString();
                if (Request.QueryString["ROL"] != null)
                {

                    lblnombre.Text = "Nombre: " + Login.EmpleadoGlobal.Nombre;
                    lblCedula.Text = "Cédula:" + Login.EmpleadoGlobal.Cedula;
                    lblDirreccion.Text = "Direccion:" + Login.EmpleadoGlobal.Direccion;
                    lblTelefono.Text = "Telefono: " + Login.EmpleadoGlobal.Telefono;
                    lblCorreo.Text = "Correo: " + Login.EmpleadoGlobal.Correo;
                    lblestadocivil.Text = "Estado Civil: " + Login.EmpleadoGlobal.EstadoCivil;
                    lblfechaNaci.Text = "Fecha nacimiento: " + Login.EmpleadoGlobal.FechaNacimiento;
                    lbldepa.Text = "Departamento: " + Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).Nombre;
                    lblRol.Text = "Rol: " + Singleton.oproles.BuscarRoles(Login.EmpleadoGlobal.IdRol).Nombre;
                    imgPerfil.ImageUrl = Login.EmpleadoGlobal.Imagen;
                    lblSaldoVaca.Text = "Saldo de vacaciones:" + Login.EmpleadoGlobal.DiasVacaciones;

                    if (Login.EmpleadoGlobal.DiasAntesCaducidad < 3)
                    {
                        mensaje.Visible = false;
                        mensajeError.Visible = false;
                        mensajeinfo.Visible = true;
                        mensajawarning.Visible = false;
                        mensajeinfo.InnerHtml = "Recuerda cambiar tu contraseña al menos una vez cada tres meses\nLa contraseña actual caduca en " + Login.EmpleadoGlobal.DiasAntesCaducidad + " dias";
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
        //
        public static bool FormatoContraseña(string contraseña)
        {
            try
            {

                if (Login.EmpleadoGlobal.Password == Encriptacion.Encriptar(contraseña, Encriptacion.Llave))
                {
                    return true;
                }
                else
                {
                    return false;
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Contraseña incorrecta')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


       //
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormatoContraseña(txtContraseñaActual.Text.ToString()))
                {
                    txtNuevaContraseña.Enabled = true;
                    txtNuevaContraseñaConfirmar.Enabled = true;
                    btnCambiar.Enabled = true;
                    txtContraseñaActual.Enabled = false;
                    btnConfirmar.Enabled = false;
                    ClientScript.RegisterStartupScript(GetType(), "Modal", "popup();", true);

                }

            }
            catch (Exception)
            {

                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
           
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevaContraseña.Text == txtNuevaContraseñaConfirmar.Text)
                {
                    if (PasswordPolicy.FormatoContraseña(txtNuevaContraseña.Text.ToString()))
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
                            Genero = Login.EmpleadoGlobal.Genero,
                            Imagen = Login.EmpleadoGlobal.Imagen,

                            IdRol = Login.EmpleadoGlobal.IdRol,
                            Estado = true,
                            DiasAntesCaducidad = 90,
                            ContraseñaCaducada = false,
                            DiasVacaciones=Login.EmpleadoGlobal.DiasVacaciones,
                            FechaCaducidadContraseña=Login.EmpleadoGlobal.FechaCaducidadContraseña,
                            SesionIniciada=false,
                            FechaIngreso=Login.EmpleadoGlobal.FechaIngreso
                        };
                        Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña ha sido modificada, por favor vuelve a iniciar sesión')", true);
                        Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, false, false, false, true, false);
                        Session.Remove("AdminCorreo");
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña debe contener al menos:/n un carácter , una letra mayúscula,una letra minúscula y un numero')", true);

                       
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
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

        }

        protected void btndepa_Click(object sender, EventArgs e)
        {
            try
            {
                var depart = new departamento()
                {

                    Nombre = txtnombre.Text,
                    EmailJefeDpto = txtemailjefedepa.Text,
                    NombreJefe = txtnombrejefe.Text,
                    Estado = true
                };
                Singleton.opdepartamento.InsertarDepartamentos(depart);
                Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, true, false, false, false, false, false);

                mensaje.Visible = true;
                mensajawarning.Visible = false;
                mensajeError.Visible = false;
                mensajeinfo.Visible = false;
                textoMensaje.InnerHtml = "Departamento agregado";
                limpiarCamposDepa();
                txtnombre.Text = string.Empty;
                txtemailjefedepa.Text = string.Empty;
                txtnombrejefe.Text = string.Empty;


            }
            catch (Exception)
            {

                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }
        public void limpiarCamposDepa()
        {
            txtnombre.Text = string.Empty;
            txtemailjefedepa.Text = string.Empty;
            txtnombrejefe.Text = string.Empty;

            
        }

       

        //protected void LB_Agregar_Click(object sender, EventArgs e)
        //{
        //    Server.Transfer("RegistroEmpleado.aspx");
        //}

        protected void LnkHome_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);
            }
            catch
            {

                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void LKB_AdminSession_Click(object sender, EventArgs e)
        {
            try
            {

                
                Empleado empleado = new Empleado()
                {
                    Cedula = Login.EmpleadoGlobal.Cedula,
                    Nombre =  Login.EmpleadoGlobal.Nombre,
                    Direccion =Login.EmpleadoGlobal.Direccion,
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

                };
                Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, false, false, false, false, true);

                Session.Remove("AdminCorreo");
                Response.Redirect("Login.aspx");
            }
            catch
            {

                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";

            }
        }

        protected void btnCerrarPopup_Click(object sender, EventArgs e)
        {
            try
            {
                Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, true, false, false, false, false, false, false, false, false, false, false, false);

                ClientScript.RegisterStartupScript(GetType(), "Modal", "popupCerrarPerfil();", true);
            }
            catch
            {

                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void LKB_AyudaAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, false, true, false, false, false);

                Response.Redirect("AyudaAdmin.aspx");
            }
            catch
            {

                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void LKB_Auditorias_Click(object sender, EventArgs e)
        {
            try
            {
                
                Response.Redirect("AuditoriasAdmin.aspx");
            }
            catch
            {
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";

            }
        }

        public bool ValidarRangoFechas(string fechainicio, string fechafinal)
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
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
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
        public void limpiarCamposFechas()
        {
            txtfechadeincio.Text = string.Empty;
            txtfechafinal.Text = string.Empty;
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
                    textoMensajeError.InnerHtml = "Debes ingresar un rango de fechas";
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
                            textoMensajeError.InnerHtml = "Ya existe una solitud previa para el rango de fechas seleccionado";
                            limpiarCamposFechas();
                        }
                        else if (VacacionesIncapacitado(Convert.ToDateTime(txtfechafinal.Text), Convert.ToDateTime(txtfechadeincio.Text)))
                        {
                            mensajeinfo.Visible = false;
                            mensajeError.Visible = true;
                            mensaje.Visible = false;
                            textoMensajeError.InnerHtml = "El usuario actual se encuentra incapacitado, la solicitud no puede completarse";
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
                        textoMensajeError.InnerHtml = "La cantidad de dias solicitados excede la cantidad de dias disponibles";
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
                    textoMensajeError.InnerHtml = "Cantidad de dias incorrecta";
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
                textoMensajeError.InnerHtml = "Hubo un error";
            }

        }

        private void EnvioCorreo()
        {
           string mail = Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).EmailJefeDpto.ToString();
            using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
            {
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential("dollars.chat.room@hotmail.com", "fidelitasw2");
                MailMessage msj = new MailMessage("dollars.chat.room@hotmail.com", mail, "Nueva solicitud de vacaciones", "Se ha recibido una nueva solicitud de vacaciones de parte del empleado\nNombre:  " + Login.EmpleadoGlobal.Nombre + "\nUsuario:" + Login.EmpleadoGlobal.Correo + "\nEl número de la solicitud es: " + IdSolicitudVacaciones);
                cliente.Send(msj);
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            limpiarCamposFechas(); 
          

        }

        protected void btnSalirpopupDepa_Click(object sender, EventArgs e)
        {
            limpiarCamposDepa();
        }

        //protected void ChkVerContraseña_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ChkVerContraseña.Checked)
        //            txtNuevaContraseña.TextMode = TextBoxMode.SingleLine;
        //        else
        //        {
        //            txtNuevaContraseña.TextMode = TextBoxMode.Password;

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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
                textoMensajeError.InnerHtml = "Hubo un error";
            }
            return estado;
        } // desmadre

    }



}