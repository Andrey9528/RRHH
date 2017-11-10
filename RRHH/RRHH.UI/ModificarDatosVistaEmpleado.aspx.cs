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

            try
            {
                
                string correo = Session["emple"].ToString();
                correo = Login.EmpleadoGlobal.Correo;
                if (correo != null)
                {


                    CargarPerfil();
                }
                else
                {
                Response.Redirect("Login.aspx?men=1");
                }
            }
            catch
            {
                Response.Redirect("Login.aspx?men=1");
            }
           
           

          
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
                    //ddlDepartamento.Text = Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).Nombre;
                    txtrol.Text = Singleton.oproles.BuscarRoles(Login.EmpleadoGlobal.IdRol).Nombre;
                    //ddlRol.Text = Singleton.oproles.BuscarRoles(Login.EmpleadoGlobal.IdRol).Nombre;
                    imgEmple.ImageUrl = Login.EmpleadoGlobal.Imagen;
                    txtdepa.Text = Singleton.opdepartamento.BuscarDepartamentos(Login.EmpleadoGlobal.IdDepartamento).Nombre;
                }
            }

            catch (Exception)
            {

                mensajawarning.Visible = true;
                textoMensajeError.InnerHtml = "ha ocurrido un error";
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
               
               var DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(txtdepa.Text);
               var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
               var RolGlobal = Singleton.oproles.BuscarRolesPorNombre(txtrol.Text);
               var IdRol = RolGlobal.IdRol.ToString();
                //string nombreArchivo = Path.GetFileName(fileUpload1.FileName);
                //fileUpload1.SaveAs(Server.MapPath("~/Empleados/" + nombreArchivo));
                var img = fileUpload1.FileName;

                if (fileUpload1.HasFile)
                {
                    string nombrearchivo = Path.GetFileName(fileUpload1.FileName);
                    fileUpload1.SaveAs(Server.MapPath("~/Empleados/" + nombrearchivo));
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
                        DiasVacaciones = Login.EmpleadoGlobal.DiasVacaciones,

                        DiasAntesCaducidad = Login.EmpleadoGlobal.DiasAntesCaducidad,
                        ContraseñaCaducada = Login.EmpleadoGlobal.ContraseñaCaducada,
                    };
                    if (Login.EmpleadoGlobal.IdRol == 1)
                    {
                        Singleton.OpEmpleados.ActualizarEmpleados(emple);
                        ActualizarEmpeladoGlobal();
                        Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, true, false, false, false, false, false, false, false, false, false);

                        Empleadosmantenimiento.Visible = false;
                        formularioImg.Visible = false;
                        Botones.Visible = true;
                        mensajeinfo.Visible = false;
                        mensaje.Visible = true;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = false;
                        textoMensaje.InnerHtml = "Los datos han sido actualizados correctamente";

                    }
                    else if (Login.EmpleadoGlobal.IdRol == 2)
                    {
                        Singleton.OpEmpleados.ActualizarEmpleados(emple);
                        ActualizarEmpeladoGlobal();
                        Singleton.opAudiJefe.InsertarAuditoriasJefe(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, true, false, false, false, false, false, false, false, false, false);


                        Empleadosmantenimiento.Visible = false;
                        formularioImg.Visible = false;
                        Botones.Visible = true;
                        mensajeinfo.Visible = false;
                        mensaje.Visible = true;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = false;
                        textoMensaje.InnerHtml = "Los datos han sido actualizados correctamente";

                    }
                    else
                    {
                        Singleton.OpEmpleados.ActualizarEmpleados(emple);
                        ActualizarEmpeladoGlobal();
                        Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, true, false, false, false, false, false, false, false, false, false, false);


                        Empleadosmantenimiento.Visible = false;
                        formularioImg.Visible = false;
                        Botones.Visible = true;
                        mensajeinfo.Visible = false;
                        mensaje.Visible = true;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = false;
                        textoMensaje.InnerHtml = "Los datos han sido actualizados correctamente";

                    }
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
                        DiasVacaciones = Login.EmpleadoGlobal.DiasVacaciones,

                        DiasAntesCaducidad = Login.EmpleadoGlobal.DiasAntesCaducidad,
                        ContraseñaCaducada = Login.EmpleadoGlobal.ContraseñaCaducada,
                    };
                    if (Login.EmpleadoGlobal.IdRol == 1)
                    {
                        Singleton.OpEmpleados.ActualizarEmpleados(emple2);
                        ActualizarEmpeladoGlobal();
                        Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, true, false, false, false, false, false, false, false, false, false);

                        Empleadosmantenimiento.Visible = false;
                        formularioImg.Visible = false;
                        Botones.Visible = true;
                        mensajeinfo.Visible = false;
                        mensaje.Visible = true;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = false;
                        textoMensaje.InnerHtml = "Los datos han sido actualizados correctamente";

                    }
                    else if (Login.EmpleadoGlobal.IdRol == 2)
                    {
                        Singleton.OpEmpleados.ActualizarEmpleados(emple2);
                        ActualizarEmpeladoGlobal();
                        Singleton.opAudiJefe.InsertarAuditoriasJefe(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, true, false, false, false, false, false, false, false, false, false);


                        Empleadosmantenimiento.Visible = false;
                        formularioImg.Visible = false;
                        Botones.Visible = true;
                        mensajeinfo.Visible = false;
                        mensaje.Visible = true;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = false;
                        textoMensaje.InnerHtml = "Los datos han sido actualizados correctamente";

                    }
                    else
                    {
                        Singleton.OpEmpleados.ActualizarEmpleados(emple2);
                        ActualizarEmpeladoGlobal();
                        Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, true, false, false, false, false, false, false, false, false, false, false);


                        Empleadosmantenimiento.Visible = false;
                        formularioImg.Visible = false;
                        Botones.Visible = true;
                        mensajeinfo.Visible = false;
                        mensaje.Visible = true;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = false;
                        textoMensaje.InnerHtml = "Los datos han sido actualizados correctamente";

                    }
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
                    Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                    Response.Redirect("WebForm1.aspx?ROL="+Login.EmpleadoGlobal.IdRol);

                }
                else if (Login.EmpleadoGlobal.IdRol == 2)
                {
                    Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                    Response.Redirect("VistaJefe.aspx?ROL="+Login.EmpleadoGlobal.IdRol);
                }
                else 
                {
                    Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                    Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

                }

            }
            catch (Exception)
            {

                
            }
        }
    }
}