using System;
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

namespace RRHH.UI
{
    public partial class Login : System.Web.UI.Page
    {
        public static string contrasena;
        public static Empleado EmpleadoGlobal = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnRegistrar.Attributes.Add("onclick", "window.open('popup.aspx','','height=300,width=300');return false");

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
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
                if (txtcorreo.Text != null && txtcontra.Text != null)
                {
                    if (Singleton.OpEmpleados.ExisteEmpleado(txtcorreo.Text))
                    {
                        if (Singleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text).Password ==
                             Encriptacion.Encriptar(txtcontra.Text,Encriptacion.Llave))//Sigleton.Encriptar(txtPassword.Text, Utilitarios.Llave))
                        {
                            EmpleadoGlobal = Singleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text);
                            //Sigleton.OpAuditoria.InsertarEnLogin(PersonaGlobal.Cedula, PersonaGlobal.Nombre, PersonaGlobal.PrimerApellido);
                            if (EmpleadoGlobal.IdRol == 1)
                            {

                                Response.Redirect("EmpleadoView.aspx");
                            }
                            else if (EmpleadoGlobal.IdRol == 2)
                            {

                                Response.Redirect("JefeView.aspx");

                            }
                            else if (EmpleadoGlobal.IdRol == 3)
                            {
                                Response.Redirect("AdminView.aspx");
                            }
                           

                        }
                        if (Singleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text).Password !=
                            Encriptacion.Encriptar(txtcontra.Text,Encriptacion.Llave))//Sigleton.Encriptar(txtPassword.Text, Utilitarios.Llave))
                        {
                            EmpleadoGlobal = Singleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text);

                              mensaje.Visible = false;
                              mensajeinfo.Visible = false;
                              mensajeError.Visible = true;
                              textoMensajeError.InnerHtml = "Contraseña Incorrecta";
                              txtcontra.Text = string.Empty;
                              txtcorreo.Text = string.Empty;                           

                            //Utilitarios.OpAuditoria.InsertarEnLoginFallido(PersonaGlobal.Cedula, PersonaGlobal.Nombre, PersonaGlobal.PrimerApellido);
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


            catch (Exception ex)
            {
              
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml ="error";
                //ImprimirMensajeError(ex.Message);
                //Utilitarios.OpErrores.InsertarEnErrores(PersonaGlobal.Nombre, PersonaGlobal.Cedula, ex.ToString());
                //Limpiar(this.Controls);
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
                        IdDepartamento=EmpleadoGlobal.IdDepartamento,
                        IdRol=EmpleadoGlobal.IdRol,
                        Estado=true

                        
                    };
                    Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                    using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
                    {
                        cliente.EnableSsl = true;
                        cliente.Credentials = new NetworkCredential("dollars.chat.room@hotmail.com", "fidelitasw2");
                        MailMessage msj = new MailMessage("dollars.chat.room@hotmail.com", txtemail.Text, "Restauración de contraseña", "Has recibido una nueva contraseña:  " + contrasena+":"+"Para tu usuario: "+txtemail.Text);
                        cliente.Send(msj);

                        mensajeinfo.Visible = true;
                        mensajeError.Visible = false;
                        mensaje.Visible = false;
                        textomensajeinfo.InnerHtml = "Correo enviado";


                    }
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

        private void CodigoPin()
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            contrasena = rd.Next(100000, 999999).ToString();
        }
    }
}