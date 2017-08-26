using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;


namespace RRHH.UI
{
    public partial class RegistroEmpleado : System.Web.UI.Page
    {
        public static departamento DepartamentoGlobal = new departamento();
        public static Roles RolGlobal = new Roles();


        protected void Page_Load(object sender, EventArgs e)
        {
            ddlRol.DataSource = Singleton.oproles.ListarRoles().Select(x => x.Nombre).ToList();
            ddlRol.DataBind();
            ddlDepartamento.DataSource = Singleton.opdepartamento.ListarDepartamentos().Select(x => x.Nombre).ToList();
            ddlDepartamento.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                //frmLogin.AutorGlobal = Utilitarios.OpAutores.BuscarAutorNombre(CboAutor.Text);
                //var identificacionAutor = frmLogin.AutorGlobal.Id_Autor.ToString();
                DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre((ddlDepartamento.Text).ToString());
                var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
                RolGlobal = Singleton.oproles.BuscarRolesPorNombre((ddlRol.Text).ToString());
                var IdRol = RolGlobal.IdRol.ToString();
                Empleado emple = new Empleado()
                {
                    Cedula = txtCedula.Text,
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                    IdDepartamento = Convert.ToInt32(IdDepartamento),
                    IdRol = Convert.ToInt32(IdRol),
                    Estado = true,
                    Password = "admin",
                };
                Singleton.OpEmpleados.InsertarEmpleados(emple);
                mensaje.Visible = true;
                textoMensaje.InnerHtml = "Usuario agregado";
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}