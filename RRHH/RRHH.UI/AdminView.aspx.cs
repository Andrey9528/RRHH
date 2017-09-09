using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class AdminView : System.Web.UI.Page
    {
        public static Empleado EmpleadoGlobal = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //
        public static bool ValidarPassword(string contraseña)
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
                if (ValidarPassword(txtContraseñaActual.Text.ToString()))
                {
                    txtNuevaContraseña.Enabled = true;
                    txtNuevaContraseñaConfirmar.Enabled = true;
                    btnCambiar.Enabled = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevaContraseña.Text == txtNuevaContraseñaConfirmar.Text)
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
                        Estado = true
                    };
                    Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña ha sido modificada, por favor vuelve a iniciar sesión')", true);

                    Response.Redirect("Login.aspx");
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
                mensaje.Visible = true;
                mensajawarning.Visible = false;
                mensajeError.Visible = false;
                mensajeinfo.Visible = false;
                textoMensaje.InnerHtml = "Departamento agregado";
                txtnombre.Text = string.Empty;
                txtemailjefedepa.Text = string.Empty;
                txtnombrejefe.Text = string.Empty;


            }
            catch (Exception)
            {
                throw;
            }
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
    }
}