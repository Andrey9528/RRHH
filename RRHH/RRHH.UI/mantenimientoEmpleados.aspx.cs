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
                //ddlRol.Text = Singleton.oproles.ListarRoles().Select(x => x.Nombre).ToString();
                //ddlRol.DataBind();


                List<Empleado> listaEmpleados = Singleton.OpEmpleados.ListarEmpleados();
                var emple = listaEmpleados.FirstOrDefault(x => x.Cedula == txtcedula.Text);
                var rol = Singleton.oproles.BuscarRoles(Convert.ToInt32(emple.IdRol)).Nombre.ToString();
                var depar = Singleton.opdepartamento.BuscarDepartamentos(Convert.ToInt32(emple.IdDepartamento)).Nombre.ToString();
                var identificacionRol = RolGlobal.IdRol.ToString();
                var identificacionDepa = DepartamentoGlobal.IdDepartamento.ToString();
                //var size = (depar.Length);
                //char[] charArrayDepar = depar.ToCharArray();
                //List<string> lista  = new List<string>();

                //for (int i = 0; i < charArrayDepar.Length; i++)
                //{
                //    //lista = (charArray[i].ToString());
                //    //lista.Add(charArrayDepar[i].ToString());
                //    lista.Add(charArrayDepar[i].ToString());


                //}
                var fecha = emple.FechaNacimiento.ToString();
                if (emple != null)
                {
                   
                    txtNombre.Text = emple.Nombre;
                    txtDireccion.Text = emple.Direccion;
                    txtTelefono.Text = emple.Telefono;
                    txtCorreo.Text = emple.Correo;
                    DddlEstadoCivil.SelectedValue = emple.EstadoCivil;
                    
                    txtFechaNacimiento.Text = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy");
                    //ddlDepartamento.DataSource = rol.ToList();
                    //DataBind();
                   
                    ddlRol.SelectedValue = rol;
                    ddlDepartamento.SelectedValue = depar;
                    DDLgenero.SelectedValue = emple.Genero;
                    Chk_bloqueado.Checked = (bool)emple.Bloqueado;
                    //ddlRol.DataSource = depar.ToList() ;
                    //DataBind();
                   
                    Chk_estado.Checked = (bool)emple.Estado;
                    
                    imgEmple.ImageUrl = emple.Imagen;
                    Empleadosmantenimiento.Visible = true;
                    txtcedula.ReadOnly = true;
                    mensaje.Visible = false;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;


                }
                else
                {
                    
                    
                    mensajeError.Visible = true;
                    mensaje.Visible = false;
                    mensajawarning.Visible = false;
                    mensajeinfo.Visible = false;
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
                // DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(ddlDepartamento.Text);
                DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(ddlDepartamento.Text);
                var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
                EmpleadoGlobal = Singleton.OpEmpleados.BuscarEmpleados(txtcedula.Text); // DESMADRE DE MARCOS
                bool bloqueoOrigen = EmpleadoGlobal.Bloqueado;
                //RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
                RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
                var IdRol = RolGlobal.IdRol.ToString();
                //string nombrearchivo = Path.GetFileName(fileUpload1.FileName);
               //fileUpload1.SaveAs(Server.MapPath("~/Empleados/" + nombrearchivo));

                if (Chk_bloqueado.Checked==bloqueoOrigen)
                {
                    Empleado emple = new Empleado()
                    {
                        Cedula = txtcedula.Text,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        IdDepartamento = Convert.ToInt32(IdDepartamento),
                        IdRol = Convert.ToInt32(IdRol),
                        Estado = Chk_estado.Checked,
                        Imagen = EmpleadoGlobal.Imagen,

                        Bloqueado = true,
                        Genero = DDLgenero.SelectedItem.ToString(),
                        Password = EmpleadoGlobal.Password,
                        IntentosFallidos = EmpleadoGlobal.IntentosFallidos,
                    };


                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                    Empleadosmantenimiento.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = false;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = true;
                    textomensajewarning.InnerHtml = "La cuenta ha sido actualizada(imagen)";
                    txtcedula.ReadOnly = false;
                    txtcedula.Focus();
                    txtcedula.Text = string.Empty;

                }



                else if (/*bloqueoOrigen != Chk_bloqueado.Checked &&*/ bloqueoOrigen==true && Chk_bloqueado.Checked==false)
                {
                   
                    Empleado emple = new Empleado()
                    {
                        Cedula = txtcedula.Text,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        IdDepartamento = Convert.ToInt32(IdDepartamento),
                        IdRol = Convert.ToInt32(IdRol),
                        Estado = Chk_estado.Checked,
                        Bloqueado = false,
                        Imagen = EmpleadoGlobal.Imagen,
                        Genero = DDLgenero.SelectedItem.ToString(),
                        Password = EmpleadoGlobal.Password,
                        IntentosFallidos = 0,
                    };


                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                    Empleadosmantenimiento.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = false;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = true;
                    textomensajewarning.InnerHtml = "La cuenta ha sido desbloqueada";
                    txtcedula.ReadOnly = false;
                    txtcedula.Focus();
                    txtcedula.Text = string.Empty;

                }
                else if (bloqueoOrigen == false && Chk_bloqueado.Checked==true)
                {
                    
                    Empleado emple = new Empleado()
                    {
                        Cedula = txtcedula.Text,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        IdDepartamento = Convert.ToInt32(IdDepartamento),
                        IdRol = Convert.ToInt32(IdRol),
                        Estado = Chk_estado.Checked,
                        Bloqueado = true,
                        Imagen = EmpleadoGlobal.Imagen,
                        Genero = DDLgenero.SelectedItem.ToString(),
                        Password = EmpleadoGlobal.Password,
                        IntentosFallidos = 4,
                    };


                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                    Empleadosmantenimiento.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = false;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = true;
                    textomensajewarning.InnerHtml = "La cuenta ha sido bloqueada";
                    txtcedula.ReadOnly = false;
                    txtcedula.Focus();
                    txtcedula.Text = string.Empty;
                }

                else
                {
                   
                    Empleado emple = new Empleado()
                    {
                        Cedula = txtcedula.Text,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        IdDepartamento = Convert.ToInt32(IdDepartamento),
                        IdRol = Convert.ToInt32(IdRol),
                        Estado = Chk_estado.Checked,
                        Imagen = EmpleadoGlobal.Imagen,
                        Bloqueado = EmpleadoGlobal.Bloqueado,
                        Genero = DDLgenero.SelectedItem.ToString(),
                        Password = EmpleadoGlobal.Password,
                        IntentosFallidos = EmpleadoGlobal.IntentosFallidos,
                    };


                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                    Empleadosmantenimiento.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = false;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = true;
                    textomensajewarning.InnerHtml = "La cuenta ha sido actualizada";
                    txtcedula.ReadOnly = false;
                    txtcedula.Focus();
                    txtcedula.Text = string.Empty;


                }


            }
            catch
            {
                throw;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                string confirmValue = Request.Form["confirm_value"];


                if (Chk_estado.Checked == false && confirmValue == "Yes")
                {
                    DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(ddlDepartamento.Text);
                    var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
                    //RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
                    RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
                    var IdRol = RolGlobal.IdRol.ToString();
                    Empleado emple = new Empleado()
                    {
                        Cedula = txtcedula.Text,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        EstadoCivil = DddlEstadoCivil.SelectedItem.ToString(),
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        IdDepartamento = Convert.ToInt32(IdDepartamento),
                        IdRol = Convert.ToInt32(IdRol),
                        Estado = Chk_estado.Checked,
                        Bloqueado=Chk_bloqueado.Checked,
                        Imagen = EmpleadoGlobal.Imagen,
                        Genero = DDLgenero.SelectedItem.ToString(),
                        Password = EmpleadoGlobal.Password,
                        IntentosFallidos=Convert.ToInt32(EmpleadoGlobal.IntentosFallidos)
                    };
                    Singleton.OpEmpleados.ActualizarEmpleados(emple);
                    Empleadosmantenimiento.Visible = false;
                    Empleadosmantenimiento.Visible = false;
                    mensaje.Visible = false;
                    mensajawarning.Visible = false;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = true;
                    textomensajeinfo.InnerHtml = "Usuario eliminado";
                    txtcedula.ReadOnly = false;
                    txtcedula.Text = string.Empty;

                   
                    

                }
                else if (Chk_estado.Checked = true && confirmValue == "Yes")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Debes desahabilitar el estado!')", true);

                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Operacion Cancelada!')", true);
                    

                }

            }
            catch (Exception)
            {

                throw;
            }     

        }

        protected void Chk_estado_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_estado.Checked)
            {
                btnEliminar.Enabled = false;

            }
            else
            {
                btnEliminar.Enabled = true;
            }
        }
    }
}