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

namespace RRHH.UI
{
    public partial class Login : System.Web.UI.Page
    {
        public static Empleado EmpleadoGlobal = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                             txtcontra.Text)//Sigleton.Encriptar(txtPassword.Text, Utilitarios.Llave))
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
                            txtcontra.Text)//Sigleton.Encriptar(txtPassword.Text, Utilitarios.Llave))
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
    }
}