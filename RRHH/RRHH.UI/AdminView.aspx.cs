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
            try
            {
                Session["ROL"] =Login.EmpleadoGlobal.IdRol;
                if (Request.QueryString["ROL"] != null)
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
                    ClientScript.RegisterStartupScript(GetType(), "Modal", "popup();", true);

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
                        };
                        Singleton.OpEmpleados.ActualizarEmpleados(empleado);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña ha sido modificada, por favor vuelve a iniciar sesión')", true);

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

       

        //protected void LB_Agregar_Click(object sender, EventArgs e)
        //{
        //    Server.Transfer("RegistroEmpleado.aspx");
        //}

        protected void LnkHome_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

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