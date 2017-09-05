using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class MantenimientoIncapacidades : System.Web.UI.Page
    {
        public static Incapacidad Inca = new Incapacidad();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Incapacidad inca = new Incapacidad();
                //inca = Singleton.opIncapacidad.BuscarIncapacidad(Convert.ToInt32(txtcedula.Text));
                Inca = Singleton.opIncapacidad.BuscarIncapacidadPorCedula(txtcedula.Text);

                //List<Empleado> listaEmpleados = Singleton.OpEmpleados.BuscarEmpleados(txtcedula.Text);

                if (Inca != null)
                {
                    //
                    grVacaciones.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(x=> x.Cedula == txtcedula.Text);
                    grVacaciones.DataBind();
                    mantenimientoInca.Visible = true;
                    //txtfechainicio.Text = inca.Fecha_Inicio.ToString();
                    //txtfechafinal.Text = inca.Fecha_finalizacion.ToString();
                    //DDLTipo.Text = inca.TipoIncapacidad.ToString();
                    //txtdescripcion.Text = inca.Descripcion.ToString();
                    //txtfechaemision.Text = inca.FechaEmision.ToString();
                    //txtcentroemisor.Text = inca.CentroEmisor.ToString();
                    //chkEstado.Checked = inca.Estado;
                    //txtnombredoc.Text = inca.NombreDoctor.ToString();
                    mensaje.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = false;
                }
                else
                {
                    mensajeError.Visible = true;
                    mensaje.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajawarning.Visible = false;
                    textoMensajeError.InnerHtml = "Cedula incorrecta";
                }

            }
            catch
            {
                throw;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btndesahabilitar_Click(object sender, EventArgs e)
        {

        }
    }
}