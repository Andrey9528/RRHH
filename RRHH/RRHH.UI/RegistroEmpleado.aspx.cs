using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using RRHH.DS.Metodos;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace RRHH.UI
{
    public partial class RegistroEmpleado : System.Web.UI.Page
    {
        public static string contrasena;

        public static departamento DepartamentoGlobal = new departamento();
        public static Roles RolGlobal = new Roles();
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                string AdminCorreo = Session["AdminCorreo"].ToString();
                if (!IsPostBack)//post back recargar la pagina con el dato que elegistes en ddl o textbox ,si recarga la pagina perdemos lo que elegimos por eso pone si es diferente a post back
                {
                    ddlRol.DataSource = Singleton.oproles.ListarRoles().Select(x => x.Nombre).ToList();
                    ddlRol.DataBind();
                    ddlDepartamento.DataSource = Singleton.opdepartamento.ListarDepartamentos().Select(x => x.Nombre).ToList();
                    ddlDepartamento.DataBind();
                }
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }


        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
            {
                
                try
                {
                    if (string.IsNullOrEmpty(txtDireccion.Text) && string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtCorreo.Text) && string.IsNullOrEmpty(txtCedula.Text) && string.IsNullOrEmpty(txtFechaNacimiento.Text) && string.IsNullOrEmpty(txtTelefono.Text))
                    {
                        mensaje.Visible = false;
                        mensajeError.Visible = false;
                        mensajeInfo.Visible = true;
                        textomensajeInfo.InnerHtml = "Los campos son requeridos";
                    }
                    else
                    {
                    string nombrearchivo = Path.GetFileName(fileUpload1.FileName);
                    fileUpload1.SaveAs(Server.MapPath("~/Images/" + nombrearchivo));


                    //frmLogin.AutorGlobal = Utilitarios.OpAutores.BuscarAutorNombre(CboAutor.Text);
                    //var identificacionAutor = frmLogin.AutorGlobal.Id_Autor.ToString();
                    DepartamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(ddlDepartamento.Text);
                    var IdDepartamento = DepartamentoGlobal.IdDepartamento.ToString();
                    RolGlobal = Singleton.oproles.BuscarRolesPorNombre(ddlRol.Text);
                    var IdRol = RolGlobal.IdRol.ToString();
                    CodigoPin();
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
                            Bloqueado = false,
                            Password = Encriptacion.Encriptar(contrasena, Encriptacion.Llave),
                            Genero = DDLgenero.SelectedItem.ToString(),
                            Imagen = "~/Images/" + nombrearchivo,
                            DiasVacaciones = 0,
                            ContraseñaCaducada = false,
                            DiasAntesCaducidad = 90,


                    };
                    Singleton.OpEmpleados.InsertarEmpleados(emple);
                    mensaje.Visible = true;
                    mensajeError.Visible = false;
                    mensajeInfo.Visible = false;
                     textoMensaje.InnerHtml = "Usuario agregado y correo enviado";
                    cliente.EnableSsl = true;
                    cliente.Credentials = new NetworkCredential("soporte.biblioteca@hotmail.com", "soporte123.");
                    MailMessage mensajeC = new MailMessage("soporte.biblioteca@hotmail.com", txtCorreo.Text, "Creación de cuenta", "Se ha creado una nueva cuenta para tu usuario" + txtCorreo.Text + "con la contraseña: " + contrasena + "por motivos de seguridad, te recomendamos cambiar la contraseña una vez que ingreses");

                    cliente.Send(mensajeC);
                    Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, true, false, false, false, false, false, false, false, false, false);
                    txtCedula.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtCorreo.Text = string.Empty;


                    }
                   
                  
                }
                catch (Exception)
                {
                    mensajeInfo.Visible = false;
                    mensaje.Visible = false;
                    mensajeError.Visible = true;
                    textomensajeError.InnerHtml = "Hubo un error";
                }
            }
        
        }
        public void limpiar()
        {
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtDireccion.Text = string.Empty;

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
            }
            catch
            {

               
            }
        }
        

        private void CodigoPin()
        {
            Random rd = new Random(DateTime.Now.Millisecond);
             contrasena = rd.Next(100000, 999999).ToString();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

           Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

        }
    }
}