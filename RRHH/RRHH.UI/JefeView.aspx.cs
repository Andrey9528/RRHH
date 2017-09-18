using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class JefeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblnombre.Text = "Nombre: " + Login.EmpleadoGlobal.Nombre;
                lblCedula.Text = "Cédula:" + Login.EmpleadoGlobal.Cedula;
                lblDirreccion.Text = "Dirreccion:" + Login.EmpleadoGlobal.Direccion;
                lblTelefono.Text = "Telefono: " + Login.EmpleadoGlobal.Telefono;
                lblCorreo.Text = "Correo: " + Login.EmpleadoGlobal.Correo;
                lblestadocivil.Text = "Estado Civil: " + Login.EmpleadoGlobal.EstadoCivil;
                lblfechaNaci.Text = "Fecha nacimiento: " + Login.EmpleadoGlobal.FechaNacimiento;
                lbldepa.Text = "Departamento: " + Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).Nombre;
                lblRol.Text = "Rol: " + Singleton.oproles.BuscarRoles(Login.EmpleadoGlobal.IdRol).Nombre;
                imgPerfil.ImageUrl = Login.EmpleadoGlobal.Imagen;

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnConfirmarJefe_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdminView.ValidarPassword(txtContraseñaActualJefe.Text.ToString()))
                {
                    txtNuevaContraseña.Enabled = true;
                    txtNuevaContraseñaConfirmar.Enabled = true;
                    btnCambiarJefe.Enabled = true;
                    ClientScript.RegisterStartupScript(GetType(), "Modal", "popup();", true);
                   

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCambiarJefe_Click(object sender, EventArgs e)
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
                        Genero=Login.EmpleadoGlobal.Genero,
                        Imagen=Login.EmpleadoGlobal.Imagen,
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

        protected void btnSalirJefe_Click(object sender, EventArgs e)
        {

        }
    }
}