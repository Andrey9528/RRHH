﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using RRHH.DS.Metodos;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace RRHH.UI
{
    public partial class Login : System.Web.UI.Page
    {
        public static string contrasena;
        public static Empleado EmpleadoGlobal = new Empleado();
        public static Empleado EmpleadoBloqueo = new Empleado();

        public static string Correo;
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnRegistrar.Attributes.Add("onclick", "window.open('popup.aspx','','height=300,width=300');return false");

        }

        private void ValidarVacios()
        {
            if (string.IsNullOrEmpty(txtcorreo.Text) || string.IsNullOrEmpty(txtcontra.Text))
            {

                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Debes ingresar tu usuario y contraseña";
                txtcontra.Text = string.Empty;
                txtcorreo.Text = string.Empty;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                ValidarVacios();

                if (txtcorreo.Text != null && txtcontra.Text != null)
                {
                    if (Singleton.OpEmpleados.ExisteEmpleado(txtcorreo.Text))
                    {
                        EmpleadoGlobal = Singleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text);
                        Correo = EmpleadoGlobal.Correo;

                        if (EmpleadoGlobal.Bloqueado)
                        {
                            mensaje.Visible = false;
                            mensajeinfo.Visible = false;
                            mensajeError.Visible = true;
                            textoMensajeError.InnerHtml = "La cuenta se encuentra bloqueda, favor contactar un administrador";
                            txtcontra.Text = string.Empty;
                            txtcorreo.Text = string.Empty;
                        }

                        else if (EmpleadoGlobal.IntentosFallidos <= 3)
                        {
                            if (EmpleadoGlobal.Password ==
                                 Encriptacion.Encriptar(txtcontra.Text, Encriptacion.Llave) && EmpleadoGlobal.Bloqueado == false)
                            {
                                //Sigleton.OpAudistoria.InsertarEnLogin(PersonaGlobal.Cedula, PersonaGlobal.Nombre, PersonaGlobal.PrimerApellido);
                                if (EmpleadoGlobal.IdRol == 1)
                                {
                                    Session["ROL"] = EmpleadoGlobal.IdRol;

                                    Empleado emple = new Empleado()
                                    {
                                        Cedula = EmpleadoGlobal.Cedula,
                                        Nombre = EmpleadoGlobal.Nombre,
                                        Direccion = EmpleadoGlobal.Direccion,
                                        Telefono = EmpleadoGlobal.Telefono,
                                        Correo = EmpleadoGlobal.Correo,
                                        EstadoCivil = EmpleadoGlobal.EstadoCivil,
                                        FechaNacimiento = EmpleadoGlobal.FechaNacimiento,
                                        IdDepartamento = EmpleadoGlobal.IdDepartamento,
                                        IdRol = EmpleadoGlobal.IdRol,
                                        Estado = EmpleadoGlobal.Estado,
                                        Genero = EmpleadoGlobal.Genero,
                                        Imagen = EmpleadoGlobal.Imagen,
                                        Password = Encriptacion.Encriptar(txtcontra.Text, Encriptacion.Llave),
                                        Bloqueado = false,
                                        IntentosFallidos = 0,
                                        DiasVacaciones = EmpleadoGlobal.DiasVacaciones,
                                    };
                                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                                    Singleton.opAudiEmple.InsertarAuditoriasEmpleado(EmpleadoGlobal.Nombre, EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, true, false);
                                    Response.Redirect("WebForm1.aspx?ROL="+EmpleadoGlobal.IdRol);
                                }
                                else if (EmpleadoGlobal.IdRol == 2 && EmpleadoGlobal.Bloqueado == false)
                                {
                                    Session["ROL"] = EmpleadoGlobal.IdRol;

                                    Empleado emple = new Empleado()
                                    {
                                        Cedula = EmpleadoGlobal.Cedula,
                                        Nombre = EmpleadoGlobal.Nombre,
                                        Direccion = EmpleadoGlobal.Direccion,
                                        Telefono = EmpleadoGlobal.Telefono,
                                        Correo = EmpleadoGlobal.Correo,
                                        EstadoCivil = EmpleadoGlobal.EstadoCivil,
                                        FechaNacimiento = EmpleadoGlobal.FechaNacimiento,
                                        IdDepartamento = EmpleadoGlobal.IdDepartamento,
                                        IdRol = EmpleadoGlobal.IdRol,
                                        Estado = EmpleadoGlobal.Estado,
                                        Imagen = EmpleadoGlobal.Imagen,
                                        Genero = EmpleadoGlobal.Genero,
                                        Password = Encriptacion.Encriptar(txtcontra.Text, Encriptacion.Llave),
                                        Bloqueado = false,
                                        IntentosFallidos = 0,
                                        DiasVacaciones = EmpleadoGlobal.DiasVacaciones,

                                    };
                                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                                    Singleton.opAudiJefe.InsertarAuditoriasJefe(EmpleadoGlobal.Nombre, EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, true, false);
                                    Response.Redirect("VistaJefe.aspx?ROL="+EmpleadoGlobal.IdRol);

                                }
                                else if (EmpleadoGlobal.IdRol == 3 && EmpleadoGlobal.Bloqueado == false)
                                {
                                    Session["ROL"] = EmpleadoGlobal.IdRol;
                                    
                                    Empleado emple = new Empleado()
                                    {
                                       
                                        Cedula = EmpleadoGlobal.Cedula,
                                        Nombre = EmpleadoGlobal.Nombre,
                                        Direccion = EmpleadoGlobal.Direccion,
                                        Telefono = EmpleadoGlobal.Telefono,
                                        Correo = EmpleadoGlobal.Correo,
                                        EstadoCivil = EmpleadoGlobal.EstadoCivil,
                                        FechaNacimiento = EmpleadoGlobal.FechaNacimiento,
                                        IdDepartamento = EmpleadoGlobal.IdDepartamento,
                                        IdRol = EmpleadoGlobal.IdRol,
                                        Estado = EmpleadoGlobal.Estado,
                                        Genero = EmpleadoGlobal.Genero,
                                        Imagen = EmpleadoGlobal.Imagen,
                                        Password = Encriptacion.Encriptar(txtcontra.Text, Encriptacion.Llave),
                                        Bloqueado = false,
                                        IntentosFallidos = 0,
                                        DiasVacaciones = EmpleadoGlobal.DiasVacaciones,

                                    };
                                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                                    Singleton.opaudi.InsertarAuditoriasAdmin(EmpleadoGlobal.Nombre, EmpleadoGlobal.Cedula, true, false, false, false, false, false, false, false, false, false, false, false, false, false);
                                    Response.Redirect("AdminView.aspx?ROL="+EmpleadoGlobal.IdRol);
                                }
                            }


                            if (EmpleadoGlobal.Password !=
                                Encriptacion.Encriptar(txtcontra.Text, Encriptacion.Llave) && EmpleadoGlobal.Bloqueado == false)//Sigleton.Encriptar(txtPassword.Text, Utilitarios.Llave))
                            {
                                if (EmpleadoGlobal.IdRol == 1)
                                {
                                    Singleton.opAudiEmple.InsertarAuditoriasEmpleado(EmpleadoGlobal.Nombre, EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, false, true);
                                }
                                else if (EmpleadoGlobal.IdRol == 2)
                                {

                                }
                                else
                                {

                                }

                                if (EmpleadoGlobal.IntentosFallidos <= 2)
                                {
                                    EmpleadoGlobal = Singleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text);
                                    mensaje.Visible = false;
                                    mensajeinfo.Visible = false;
                                    mensajeError.Visible = true;
                                    textoMensajeError.InnerHtml = "Contraseña Incorrecta";
                                    txtcontra.Text = string.Empty;
                                    txtcorreo.Text = string.Empty;
                                    // Correo = txtcorreo.Text; // aqui se toma el correo para luego usarlo en el bloqueo de contraseña
                                    //Utilitarios.OpAuditoria.InsertarEnLoginFallido(PersonaGlobal.Cedula, PersonaGlobal.Nombre, PersonaGlobal.PrimerApellido);
                                    Empleado emple = new Empleado()
                                    {
                                        Cedula = EmpleadoGlobal.Cedula,
                                        Nombre = EmpleadoGlobal.Nombre,
                                        Direccion = EmpleadoGlobal.Direccion,
                                        Telefono = EmpleadoGlobal.Telefono,
                                        Correo = EmpleadoGlobal.Correo,
                                        EstadoCivil = EmpleadoGlobal.EstadoCivil,
                                        FechaNacimiento = EmpleadoGlobal.FechaNacimiento,
                                        IdDepartamento = EmpleadoGlobal.IdDepartamento,
                                        IdRol = EmpleadoGlobal.IdRol,
                                        Estado = EmpleadoGlobal.Estado,
                                        Genero = EmpleadoGlobal.Genero,
                                        Imagen = EmpleadoGlobal.Imagen,
                                        Password = EmpleadoGlobal.Password,
                                        Bloqueado = false,
                                        IntentosFallidos = EmpleadoGlobal.IntentosFallidos + 1,
                                        DiasVacaciones = EmpleadoGlobal.DiasVacaciones,

                                    };
                                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                                }
                                else if (EmpleadoGlobal.IntentosFallidos == 3)
                                {
                                    mensaje.Visible = false;
                                    mensajeError.Visible = true;
                                    mensajeinfo.Visible = false;
                                    textomensajeinfo.InnerHtml = "La cuenta se encuentra bloqueada por exceso de intentos fallidos";
                                    txtcontra.Text = string.Empty;
                                    txtcorreo.Text = string.Empty;
                                    EmpleadoBloqueo = Singleton.OpEmpleados.BuscarEmpleadoCorreo(Correo);
                                    Empleado emple = new Empleado()
                                    {
                                        Cedula = EmpleadoBloqueo.Cedula,
                                        Nombre = EmpleadoBloqueo.Nombre,
                                        Direccion = EmpleadoBloqueo.Direccion,
                                        Telefono = EmpleadoBloqueo.Telefono,
                                        Correo = EmpleadoBloqueo.Correo,
                                        EstadoCivil = EmpleadoBloqueo.EstadoCivil,
                                        FechaNacimiento = EmpleadoBloqueo.FechaNacimiento,
                                        IdDepartamento = EmpleadoBloqueo.IdDepartamento,
                                        IdRol = EmpleadoBloqueo.IdRol,
                                        Estado = EmpleadoBloqueo.Estado,
                                        Imagen = EmpleadoGlobal.Imagen,
                                        Genero = EmpleadoBloqueo.Genero,
                                        Password = EmpleadoGlobal.Password,
                                        Bloqueado = true,
                                        IntentosFallidos = EmpleadoGlobal.IntentosFallidos + 1,
                                        DiasVacaciones = EmpleadoGlobal.DiasVacaciones,

                                    };
                                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                                }
                            }
                            else
                            {
                                mensaje.Visible = false;
                                mensajeError.Visible = false;
                                mensajeinfo.Visible = true;
                                textomensajeinfo.InnerHtml = "Usuario no existe";
                                txtcontra.Text = string.Empty;
                                txtcorreo.Text = string.Empty;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
                //mensaje.Visible = false;
                //mensajeError.Visible = true;
                //mensajeinfo.Visible = false;
                //textoMensajeError.InnerHtml = "error";
                //ImprimirMensajeError(ex.Message);
                //Utilitarios.OpErrores.InsertarEnErrores(PersonaGlobal.Nombre, PersonaGlobal.Cedula, ex.ToString());
            }


        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Singleton.OpEmpleados.ExisteEmpleado(txtemail.Text))
                {
                    EmpleadoGlobal = Singleton.OpEmpleados.BuscarEmpleadoCorreo(txtemail.Text);
                    CodigoPin();
                    Empleado empleado = new Empleado()
                    {
                        Cedula = EmpleadoGlobal.Cedula,
                        Nombre = EmpleadoGlobal.Nombre,
                        Direccion = EmpleadoGlobal.Direccion,
                        Telefono = EmpleadoGlobal.Telefono,
                        Correo = EmpleadoGlobal.Correo,
                        EstadoCivil = EmpleadoGlobal.EstadoCivil,
                        Password = Encriptacion.Encriptar(contrasena, Encriptacion.Llave),
                        FechaNacimiento = EmpleadoGlobal.FechaNacimiento,
                        IdDepartamento = EmpleadoGlobal.IdDepartamento,
                        IdRol = EmpleadoGlobal.IdRol,
                        Estado = true,
                        Genero = EmpleadoGlobal.Genero,
                        Imagen = EmpleadoGlobal.Imagen,
                        DiasVacaciones = EmpleadoGlobal.DiasVacaciones,


                    };
                    Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                    ThreadStart delegado = new ThreadStart(EnvioCorreo);
                    Thread hilo = new Thread(delegado);
                    hilo.Start();
                    mensajeError.Visible = false;
                    mensaje.Visible = false;
                    mensajeinfo.Visible = true;
                    textomensajeinfo.InnerHtml = "Se envio un codigo pin a tu dirreccion de correo";
                    //using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
                    //{
                    //    cliente.EnableSsl = true;
                    //    cliente.Credentials = new NetworkCredential("soporte.biblioteca@hotmail.com", "soporte123.");
                    //    MailMessage msj = new MailMessage("soporte.biblioteca@hotmail.com", txtemail.Text, "Restauración de contraseña", "Has recibido una nueva contraseña:  " + contrasena + ":" + "Para tu usuario: " + txtemail.Text);
                    //    cliente.Send(msj);

                    //    mensajeinfo.Visible = true;
                    //    mensajeError.Visible = false;
                    //    mensaje.Visible = false;
                    //    textomensajeinfo.InnerHtml = "Correo enviado";


                    //}
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dirección de Correo invalida!')", true);

                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;
                    mensaje.Visible = false;
                }
            }

            catch (Exception ex)
            {
                //ImprimirMensajeError(ex.Message);
                //Utilitarios.OpErrores.InsertarEnErrores(PersonaGlobal.Nombre, PersonaGlobal.Cedula, ex.ToString());

            }
        }
        private void EnvioCorreo()
        {
            using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
            {
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential("soporte.biblioteca@hotmail.com", "soporte123.");
                MailMessage msj = new MailMessage("soporte.biblioteca@hotmail.com", txtemail.Text, "Restauración de contraseña", "Has recibido una nueva contraseña:  " + contrasena + ":" + "Para tu usuario: " + txtemail.Text);
                cliente.Send(msj);

                mensajeinfo.Visible = true;
                mensajeError.Visible = false;
                mensaje.Visible = false;
                textomensajeinfo.InnerHtml = "Correo enviado";


            }
        }
        private void CodigoPin()
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            contrasena = rd.Next(100000, 999999).ToString();
        }
    }
}