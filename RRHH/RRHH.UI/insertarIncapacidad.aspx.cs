using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class insertarIncapacidad : System.Web.UI.Page
    {
        public static int dias;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btninsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacionDias(txtfechafinal.Text, txtfechainicio.Text))
                {
                    Incapacidad inca = new Incapacidad()
                    {
                        Cedula = Login.EmpleadoGlobal.Cedula,
                        Fecha_finalizacion = Convert.ToDateTime(txtfechafinal.Text),
                        Fecha_Inicio = Convert.ToDateTime(txtfechainicio.Text),
                        CantidadDias = dias,
                        TipoIncapacidad = DDLTipo.SelectedItem.ToString(),
                        Descripcion = txtdescripcion.Text,
                        FechaEmision = Convert.ToDateTime(txtfechaemision.Text),
                        CentroEmisor = txtcentroemisor.Text,
                        NombreDoctor = txtnombredoc.Text,
                        Estado = true,

                    };
                    Singleton.opIncapacidad.InsertarIncapacidad(inca);
                    Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, true, false, false, false, false, false, false, false, false);

                    mensaje.Visible = true;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    textoMensaje.InnerHtml = "Incapacidad generada";
                }

                //else if(string.IsNullOrEmpty(txtfechainicio.Text)&& string.IsNullOrEmpty(txtfechafinal.Text) && string.IsNullOrEmpty(txtdescripcion.Text)&& string.IsNullOrEmpty(txtfechaemision.Text)&& string.IsNullOrEmpty(txtcentroemisor.Text)&& string.IsNullOrEmpty(txtnombredoc.Text))

                //{

                //    mensaje.Visible = false;
                //    mensajeError.Visible = true;
                //    mensajeinfo.Visible = false;
                //    mensajawarning.Visible = false;
                //    textoMensajeError.InnerHtml = "Los campos son requeridos";
                //}
                
                else
                {
                    mensajeError.Visible = true;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    mensaje.Visible = false;
                    textoMensajeError.InnerHtml = "Cantidad de dias incorrecta";
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