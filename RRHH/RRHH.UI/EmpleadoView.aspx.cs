﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class EmpleadoView : System.Web.UI.Page
    {
        public static int dias;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdminView.ValidarPassword(txtContraseñaActualEmpleado.Text.ToString()))
                {
                    txtNuevaContraseña.Enabled = true;
                    txtNuevaContraseñaConfirmar.Enabled = true;
                    btnCambiarEmpleado.Enabled = true;
                }
                else
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCambiarEmpleado_Click(object sender, EventArgs e)
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

        protected void btnSalirEmpleado_Click(object sender, EventArgs e)
        {

        }

        protected void btnvaca_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime FechaSalida = Convert.ToDateTime(txtidsolicitud.Text);
                //DateTime FechaRetorno = Convert.ToDateTime(txtfechafinal.Text);
                //int TotalDias = Convert.ToInt32(FechaRetorno - FechaSalida);
                if (ValidacionDias(txtfechafinal.Text, txtfechadeincio.Text))
                {
                    var vacaciones = new SolicitudVacaciones()
                    {

                        FechaFinal = Convert.ToDateTime(txtfechafinal.Text),
                        FechaInicio = Convert.ToDateTime(txtfechadeincio.Text),
                        Cedula = Login.EmpleadoGlobal.Cedula,
                        TotalDias = dias,
                        Condicion = null,
                    };
                    Singleton.opsolicitud.InsertarSolicitud(vacaciones);
                    mensaje.Visible = true;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    //TimeSpan diferencia = Convert.ToDateTime(txtfechafinal.Text) - Convert.ToDateTime(txtfechadeincio.Text);
                    //var dias = diferencia.TotalDays;
                    //txttotaldias.Text = dias.ToString();
                    textoMensaje.InnerHtml = "Solicitud generada";
                }
                else
                {
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    mensaje.Visible = false;
                    textomensajeError.InnerHtml = "Cantidad de dias incorrecta";
                    txtfechafinal.Focus();
                }


            }
            catch (Exception)
            {
                throw;
            }


        }

        public bool ValidacionDias(string fechaFinal, string fechadeInicio)
        {
            try
            {
                TimeSpan diferencia = Convert.ToDateTime(fechaFinal) - Convert.ToDateTime(fechadeInicio);
                dias = Convert.ToInt32(diferencia.TotalDays);
                if (dias > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}