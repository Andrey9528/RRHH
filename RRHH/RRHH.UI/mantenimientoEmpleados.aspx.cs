using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class mantenimientoEmpleados : System.Web.UI.Page
    {
       public static Empleado EmpleadoGlobal = new Empleado();
        public static Roles RolGlobal = new Roles();
        public static departamento DepartamentoGlobal = new departamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }

        protected void btnsBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //ddlRol.DataSource = Singleton.oproles.ListarRoles().Select(x => x.Nombre).ToList();
                //ddlRol.DataBind();

                List<Empleado> listaEmpleados = Singleton.OpEmpleados.ListarEmpleados();
                var emple = listaEmpleados.FirstOrDefault(x => x.Cedula == txtcedula.Text);
                 var rol = Singleton.oproles.BuscarRoles(Convert.ToInt32(emple.IdRol)).Nombre.ToString();
                var depar = Singleton.opdepartamento.BuscarDepartamentos(Convert.ToInt32(emple.IdDepartamento)).Nombre.ToString();
                //var identificacionRol = RolGlobal.IdRol.ToString();
                //var identificacionDepa = DepartamentoGlobal.IdDepartamento.ToString();

                var fecha = emple.FechaNacimiento.ToString();
                if (emple != null)
                {
                    txtNombre.Text = emple.Nombre;
                    txtDireccion.Text = emple.Direccion;
                    txtTelefono.Text = emple.Telefono;
                    txtCorreo.Text = emple.Correo;
                    DddlEstadoCivil.SelectedValue = emple.EstadoCivil;
                    
                    txtFechaNacimiento.Text = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy"); 
                    ddlDepartamento.DataSource= rol.ToList();
                    DataBind();

                    ddlRol.DataSource = depar.ToList() ;
                    DataBind();
                   
                    Chk_estado.Checked = (bool)emple.Estado;
                    Empleadosmantenimiento.Visible = true;
                    txtcedula.ReadOnly = true;
                    mensaje.Visible = false;
                    mensajeError.Visible = false;


                }
                else
                {
                    txtcedula.Text = string.Empty;
                    txtcedula.Focus();
                    mensajeError.Visible = true;
                    mensaje.Visible = false;
                    textoMensajeError.InnerHtml = "Empleado no existe";

                }

            }
            catch
            {
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try

            {
                DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(ddlDepartamento.Text);
                var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
                RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
                var IdRol = RolGlobal.IdRol.ToString();
                Empleado emple = new Empleado()

                {
                    
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                    IdDepartamento = Convert.ToInt32(IdDepartamento),
                    IdRol = Convert.ToInt32(IdRol),
                    Estado = Chk_estado.Checked,
                    Password = "admin",
                };
                Singleton.OpEmpleados.ActualizarEmpleados(emple);
                mensaje.Visible = true;
                textoMensaje.InnerHtml = "Usuario actualizado";

            }
            catch
            {
                throw;

            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}