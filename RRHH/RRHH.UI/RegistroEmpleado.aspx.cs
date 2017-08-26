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
    public partial class RegistroEmpleado : System.Web.UI.Page
    {
        public static departamento DepartamentoGlobal = new departamento();
        public static Roles RolGlobal = new Roles();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//post back recargar la pagina con el dato que elegistes en ddl o textbox ,si recarga la pagina perdemos lo que elegimos por eso pone si es diferente a post back
            {
                ddlRol.DataSource = Singleton.oproles.ListarRoles().Select(x => x.Nombre).ToList();
                ddlRol.DataBind();
                ddlDepartamento.DataSource = Singleton.opdepartamento.ListarDepartamentos().Select(x => x.Nombre).ToList();
                ddlDepartamento.DataBind();
            }


        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
      
                //frmLogin.AutorGlobal = Utilitarios.OpAutores.BuscarAutorNombre(CboAutor.Text);
                //var identificacionAutor = frmLogin.AutorGlobal.Id_Autor.ToString();
                DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(ddlDepartamento.Text);
                var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
                RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
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