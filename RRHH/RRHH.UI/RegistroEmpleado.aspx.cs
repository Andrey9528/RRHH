﻿using System;
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


namespace RRHH.UI
{
    public partial class RegistroEmpleado : System.Web.UI.Page
    {
        public static string contrasena;

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
            using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
            {
                
                try
                {

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
                        Password = Encriptacion.Encriptar(contrasena, Encriptacion.Llave),
                    };
                    Singleton.OpEmpleados.InsertarEmpleados(emple);
                    mensaje.Visible = true;
                    textoMensaje.InnerHtml = "Usuario agregado y correo enviado";
                    cliente.EnableSsl = true;
                    cliente.Credentials = new NetworkCredential("dollars.chat.room@hotmail.com", "fidelitasw2");
                    MailMessage mensajeC = new MailMessage("dollars.chat.room@hotmail.com", txtCorreo.Text, "Creación de cuenta", "Se ha creado una nueva cuenta para tu usuario" + txtCorreo.Text + "con la contraseña: " + contrasena + "por motivos de seguridad, te recomendamos cambiar la contraseña una vez que ingreses");

                    cliente.Send(mensajeC);
                    txtCedula.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtCorreo.Text = string.Empty;


                }
                catch (Exception)
                {
                    throw;
                }
            }
        
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
        

        private void CodigoPin()
        {
            Random rd = new Random(DateTime.Now.Millisecond);
             contrasena = rd.Next(100000, 999999).ToString();
        }
    }
}