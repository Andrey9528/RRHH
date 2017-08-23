using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using RRHH.DS.Metodos;
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
                    //MessageBox.Show("Debes ingresar tu usuario y contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mensaje.Visible = false;
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    textoMensajeError.InnerHtml = "Debes ingresar tu usuario y contraseña";
                    txtcontra.Text = string.Empty;
                    txtcorreo.Text = string.Empty;
                }
                if (txtcorreo.Text != null && txtcontra.Text != null)
                {
                    if (Sigleton.OpEmpleados.ExisteEmpleado(txtcorreo.Text))
                    {
                        if (Sigleton.OpEmpleados.BuscarEmpleadoCorreo(txtcontra.Text).Password ==
                            txtcontra.Text)//Encriptacion.Encriptar(txtcontra.Text, Encriptacion.Llave))
                        {
                            EmpleadoGlobal = Sigleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text);
                            //Aqui se pone auditorialogin Sigleton.OpEmpleados.InsertarEnLogin(PersonaGlobal.Cedula, PersonaGlobal.Nombre, PersonaGlobal.PrimerApellido);
                            //Limpiar(this.Controls);

                            Response.Redirect("Index.aspx");
                        }
                        if (Sigleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text).Password !=
                            txtcontra.Text)//Encriptacion.Encriptar(txtcontra.Text, Encriptacion.Llave))
                        {
                            EmpleadoGlobal = Sigleton.OpEmpleados.BuscarEmpleadoCorreo(txtcorreo.Text);

                            mensaje.Visible = false;
                            mensajeinfo.Visible = false;
                            mensajeError.Visible = true;
                            textoMensajeError.InnerHtml = "Contraseña Incorrecta";
                            //txtcontra.Text = string.Empty;
                            //txtcorreo.Text = string.Empty;
                            // Utilitarios.OpAuditoria.InsertarEnLoginFallido(PersonaGlobal.Cedula, PersonaGlobal.Nombre, PersonaGlobal.PrimerApellido);

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



                //List<Empleado> listarEmple = Sigleton.OpEmpleados.ListarEmpleados();
                //var usr = listarEmple.Where(x => x.Correo == txtcorreo.Text && x.Password == txtcontra.Text).FirstOrDefault();
                //if (usr != null)
                //{
                //    Session["Cedula"] = usr.Cedula.ToString();
                //    Session["Correo"] = usr.Correo.ToString();
                //    Response.Redirect("Index.aspx");
                //}
                //else
                //{

                //}
            }


            catch (Exception ex)
            {
                mensaje.Visible = false;
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = ex.StackTrace;
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