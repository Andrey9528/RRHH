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
        public static int dias;
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
                    DDLid_incapacidad.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Select(x => x.IdIncapacidad);
                    DDLid_incapacidad.DataBind();
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
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Chk_estado.Checked)
            //    {

            //        var lista = Singleton.opIncapacidad.BuscarIncapacidad(Convert.ToInt32(DDLid_incapacidad.Text));
            //        string confirmValue = Request.Form["confirm_value"];
            //        if (lista != null  )
            //        {
            //            if (ValidacionDias(txtfechafinalizacion.Text, txtfechainicio.Text))
            //                {

            //                if (Chk_estado.Checked && confirmValue == "Yes")
            //                {
            //                    Incapacidad inca = new Incapacidad()
            //                    {
            //                        IdIncapacidad = lista.IdIncapacidad,
            //                        Cedula = lista.Cedula,
            //                        Fecha_Inicio = Convert.ToDateTime(txtfechainicio.Text),
            //                        Fecha_finalizacion = Convert.ToDateTime(txtfechafinalizacion.Text),
            //                        TipoIncapacidad = DDLid_incapacidad.Text,
            //                        Descripcion = txtdescripcion.Text,
            //                        FechaEmision = Convert.ToDateTime(txtfechaemision.Text),
            //                        CentroEmisor = txtcentroemisor.Text,
            //                        Estado = true,
            //                        NombreDoctor = txtdoctor.Text,
            //                        CantidadDias = dias,
            //                    };
            //                    Singleton.opIncapacidad.ActualizarIncapacidad(inca);
            //                }
            //                else
            //                {
            //                    Incapacidad inca = new Incapacidad()
            //                    {
            //                        IdIncapacidad = lista.IdIncapacidad,
            //                        Cedula = lista.Cedula,
            //                        Fecha_Inicio = Convert.ToDateTime(txtfechainicio.Text),
            //                        Fecha_finalizacion = Convert.ToDateTime(txtfechafinalizacion.Text),
            //                        TipoIncapacidad = DDLid_incapacidad.Text,
            //                        Descripcion = txtdescripcion.Text,
            //                        FechaEmision = Convert.ToDateTime(txtfechaemision.Text),
            //                        CentroEmisor = txtcentroemisor.Text,
            //                        Estado = false,
            //                        NombreDoctor = txtdoctor.Text,
            //                        CantidadDias = dias,
            //                    };
            //                    Singleton.opIncapacidad.ActualizarIncapacidad(inca);
            //                }                          
            //            }
            //        }
            //        else if (Chk_estado.Checked = true && confirmValue == "Yes")
            //        {
            //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Debes desahabilitar el estado!')", true);

            //        }
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            try
            {
                string confirmValue = Request.Form["confirm_value"];

                if (Chk_estado.Checked && confirmValue=="Yes")
                {
                    var lista = Singleton.opIncapacidad.BuscarIncapacidad(Convert.ToInt32(DDLid_incapacidad.Text));
                    if (ValidacionDias(txtfechafinalizacion.Text, txtfechainicio.Text))
                    {
                        Incapacidad inca = new Incapacidad()
                        {
                            IdIncapacidad = lista.IdIncapacidad,
                            Cedula = lista.Cedula,
                            Fecha_Inicio = Convert.ToDateTime(txtfechainicio.Text),
                            Fecha_finalizacion = Convert.ToDateTime(txtfechafinalizacion.Text),
                            TipoIncapacidad = DDLid_incapacidad.Text,
                            Descripcion = txtdescripcion.Text,
                            FechaEmision = Convert.ToDateTime(txtfechaemision.Text),
                            CentroEmisor = txtcentroemisor.Text,
                            Estado = true,
                            NombreDoctor = txtdoctor.Text,
                            CantidadDias = dias,
                        };
                        Singleton.opIncapacidad.ActualizarIncapacidad(inca);
                        mensaje.Visible = false;
                        mensajeinfo.Visible = false;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = true;
                        textomensajewarning.InnerHtml = "Actualizado";
                    }
                }
                else
                {
                    if (ValidacionDias(txtfechafinalizacion.Text, txtfechainicio.Text))
                    {
                        var lista = Singleton.opIncapacidad.BuscarIncapacidad(Convert.ToInt32(DDLid_incapacidad.Text));
                        Incapacidad inca = new Incapacidad()
                        {
                            IdIncapacidad = lista.IdIncapacidad,
                            Cedula = lista.Cedula,
                            Fecha_Inicio = Convert.ToDateTime(txtfechainicio.Text),
                            Fecha_finalizacion = Convert.ToDateTime(txtfechafinalizacion.Text),
                            TipoIncapacidad = DDLid_incapacidad.Text,
                            Descripcion = txtdescripcion.Text,
                            FechaEmision = Convert.ToDateTime(txtfechaemision.Text),
                            CentroEmisor = txtcentroemisor.Text,
                            Estado = false,
                            NombreDoctor = txtdoctor.Text,
                            CantidadDias = dias,
                        };
                        Singleton.opIncapacidad.ActualizarIncapacidad(inca);
                        mensaje.Visible = false;
                        mensajeinfo.Visible = true;
                        mensajeError.Visible = false;
                        mensajawarning.Visible = false;
                        textomensajeinfo.InnerHtml = "Incapacidad deshabilitada";
                    }
                  
                    }      
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btndesahabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarIncapacidad_Click(object sender, EventArgs e)
        {
            try
            {
                List<Incapacidad> listaIncapacidades = Singleton.opIncapacidad.ListarIncapacidades();
                var lista = listaIncapacidades.FirstOrDefault(x => x.IdIncapacidad == Convert.ToInt32(DDLid_incapacidad.Text));
                //var lista = Singleton.opIncapacidad.BuscarIncapacidad(Convert.ToInt32(DDLid_incapacidad.Text));
                if (lista != null)
                {
                    txtfechainicio.Text = lista.Fecha_Inicio.ToString();
                    txtfechafinalizacion.Text = lista.Fecha_finalizacion.ToString();
                    DDLtipoenfermedad.SelectedValue = lista.TipoIncapacidad;
                    //DDLtipoenfermedad.DataBind();
                    txtdescripcion.Text = lista.Descripcion.ToString();
                    txtfechaemision.Text = lista.FechaEmision.ToString();
                    txtcentroemisor.Text = lista.CentroEmisor.ToString();
                    Chk_estado.Checked = lista.Estado;
                    txtdoctor.Text = lista.NombreDoctor.ToString();


                }
                else{

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}