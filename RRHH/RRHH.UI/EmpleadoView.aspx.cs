using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class EmpleadoView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if ( AdminView.ValidarPassword(txtContraseñaActualEmpleado.Text.ToString()))
                {
                    txtNuevaContraseña.Enabled = true;
                    txtNuevaContraseñaConfirmar.Enabled = true;
                    btnCambiarEmpleado.Enabled = true;
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

        protected void btnSalirEmpleado_Click(object sender, EventArgs e)
        {

        }
    }
}