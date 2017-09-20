using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using System.IO;

namespace RRHH.UI
{
    public partial class ModificarDatosVistaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPerfil();
        }

        public void CargarPerfil()
        {
            try
            {
                if (!IsPostBack)
                {
                    txtNombre.Text = Login.EmpleadoGlobal.Nombre;
                    DDLgenero.Text = Login.EmpleadoGlobal.Genero;
                    txtDireccion.Text = Login.EmpleadoGlobal.Direccion;
                    txtTelefono.Text = Login.EmpleadoGlobal.Telefono;
                    txtCorreo.Text = Login.EmpleadoGlobal.Correo;
                    DddlEstadoCivil.Text = Login.EmpleadoGlobal.EstadoCivil;
                    txtFechaNacimiento.Text = Login.EmpleadoGlobal.FechaNacimiento.ToString();
                    ddlDepartamento.Text = Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).Nombre;
                    ddlRol.Text = Singleton.oproles.BuscarRoles(Login.EmpleadoGlobal.IdRol).Nombre;
                    imgEmple.ImageUrl = Login.EmpleadoGlobal.Imagen;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        public static void ActualizarEmpeladoGlobal()
        {
            Login.EmpleadoGlobal = Singleton.OpEmpleados.BuscarEmpleados(Login.EmpleadoGlobal.Cedula);

        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
               
               var DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(ddlDepartamento.Text);
               var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
               var RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
               var IdRol = RolGlobal.IdRol.ToString();
                
                if (Login.EmpleadoGlobal.Imagen!=imgEmple.ImageUrl)
                {
                    string nombrearchivo = Path.GetFileName(fileUpload1.FileName);
                    fileUpload1.SaveAs(Server.MapPath("~/Empleados/" +  nombrearchivo));
                    Empleado emple = new Empleado()
                    {


                        Cedula = Login.EmpleadoGlobal.Cedula,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        IdDepartamento = Convert.ToInt32(IdDepartamento),
                        IdRol = Convert.ToInt32(IdRol),
                        Estado = true,
                        Imagen = "~/Empleados/" + nombrearchivo,
                        Bloqueado = false,
                        Genero = DDLgenero.Text.ToString(),
                        Password = Login.EmpleadoGlobal.Password,
                        IntentosFallidos = 0,
                    };
                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                    Empleadosmantenimiento.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = true;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = false;
                    textoMensaje.InnerHtml = "Los datos han sido actualizados";
                }
                else 
                {
                    Empleado emple2 = new Empleado()
                    {
                        Cedula = Login.EmpleadoGlobal.Cedula,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        IdDepartamento = Convert.ToInt32(IdDepartamento),
                        IdRol = Convert.ToInt32(IdRol),
                        Estado = true,
                        Imagen = Login.EmpleadoGlobal.Imagen,
                        Bloqueado = false,
                        Genero = DDLgenero.Text.ToString(),
                        Password = Login.EmpleadoGlobal.Password,
                        IntentosFallidos = 0,
                    };
                    Singleton.OpEmpleados.ActualizarEmpleados(emple2);
                    ActualizarEmpeladoGlobal();
                    Empleadosmantenimiento.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = true;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = false;
                    textoMensaje.InnerHtml = "Los datos han sido actualizados correctamente";
                }

               
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.EmpleadoGlobal.IdRol == 1)
                {
                    Response.Redirect("EmpleadoView.aspx");
                }
                else if (Login.EmpleadoGlobal.IdRol == 2)
                {

                    Response.Redirect("JefeView.aspx");
                }
                else 
                {
                    Response.Redirect("AdminView.aspx");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}