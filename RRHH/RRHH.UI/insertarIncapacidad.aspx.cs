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
        List<DateTime> fechas = new List<DateTime>(); //desmadre
        List<DateTime> fechasVacaciones = new List<DateTime>(); //desmadre

        public static int count; // desmadre

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {
                Response.Redirect("Login.aspx?men=1");
                
            }
        }

        public bool ValidarRangoFechasIncapacidades(string fechainicio, string fechafinal)
        {
            try
            {
                var listaId = Singleton.opIncapacidad.ListarIncapacidades().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).ToList();
                foreach (var IdSolicitud in listaId)
                {

                    if (Convert.ToDateTime(fechainicio) >= Convert.ToDateTime(IdSolicitud.Fecha_Inicio) && Convert.ToDateTime(fechainicio) <= Convert.ToDateTime(IdSolicitud.Fecha_finalizacion)
                        || Convert.ToDateTime(fechafinal) >= Convert.ToDateTime(IdSolicitud.Fecha_Inicio) && Convert.ToDateTime(fechafinal) <= Convert.ToDateTime(IdSolicitud.Fecha_finalizacion))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
                //textomensajeError.InnerHtml = "Ha ocurrido un error";
            }
            return false;
        }
        public bool ValidarRangoFechasVacaciones(string  fechainicio, string  fechafinal)
        {
            try
            {
                var listaId = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).ToList();
                foreach (var IdSolicitud in listaId)
                {

                    if (Convert.ToDateTime(fechainicio) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechainicio) <= Convert.ToDateTime(IdSolicitud.FechaFinal)
                        || Convert.ToDateTime(fechafinal) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechafinal) <= Convert.ToDateTime(IdSolicitud.FechaFinal))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
                //textomensajeError.InnerHtml = "Ha ocurrido un error";
            }
            return false;
        }

        //// en teria en este se suman los dias de vacaciones cuando alguien se incapacita
        // public bool ValidarRangoFechas(string fechainicio,string fechafinal)
        //{
        //    try
        //    {
        //        var listaId = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).ToList();
        //        foreach (var IdSolicitud in listaId)
        //        {

        //            if (Convert.ToDateTime(fechainicio) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechainicio) <= Convert.ToDateTime(IdSolicitud.FechaFinal)
        //                || Convert.ToDateTime(fechafinal) >= Convert.ToDateTime(IdSolicitud.FechaInicio) && Convert.ToDateTime(fechafinal) <= Convert.ToDateTime(IdSolicitud.FechaFinal))
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        mensajeError.Visible = true;
        //        mensajeinfo.Visible = false;
        //        mensajawarning.Visible = false;
        //        mensaje.Visible = false;
        //        textomensajeError.InnerHtml = "Ha ocurrido un error";
        //    }
        //    return false;
        //}

       //

        public static int DiasRestantes(DateTime startDate, DateTime endDate, Boolean excludeWeekends, List<DateTime> excludeDates)
        {
            count = 0;
            for (DateTime index = startDate; index < endDate; index = index.AddDays(1))
            {
                if (excludeWeekends && index.DayOfWeek != DayOfWeek.Sunday)
                {
                    bool excluded = false; ;
                    for (int i = 0; i < excludeDates.Count; i++)
                    {
                        if (index.Date.CompareTo(excludeDates[i].Date) == 0)
                        {
                            excluded = true;
                            break;
                        }
                    }

                    if (!excluded)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        protected void btninsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacionDias(txtfechafinal.Text, txtfechainicio.Text))
                {
                    if (ValidarRangoFechasVacaciones(txtfechainicio.Text, txtfechafinal.Text))
                    {
                        mensajeinfo.Visible = false;
                        mensajeError.Visible = true;
                        mensaje.Visible = false;
                        textoMensajeError.InnerHtml = "Existe una solicitud de vacaciones en el rango de fechas seleccionado";
                    }
                   else if  (ValidarRangoFechasIncapacidades(txtfechainicio.Text,  txtfechafinal.Text))
                    {
                        mensajeinfo.Visible = false;
                        mensajeError.Visible = true;
                        mensaje.Visible = false;
                        textoMensajeError.InnerHtml = "Existe una incapacidad registrada en el rango de fechas seleccionado";
                    }
                    else
                    {
                        //fechasVacaciones = Singleton.opsolicitud.BuscarsolicitudPorId(Login.EmpleadoGlobal.Cedula).Where(x => x.Condicion == true).ToList().Select(x => x.FechaInicio && x.FechaFinal);
                        fechas = Singleton.OpFeriados.ListarFeriados().Select(x => x.Fecha).ToList();
                        DiasRestantes(Convert.ToDateTime(txtfechainicio.Text), Convert.ToDateTime(txtfechafinal.Text), true, fechas);
                        Incapacidad inca = new Incapacidad()
                        {
                            Cedula = Login.EmpleadoGlobal.Cedula,
                            Fecha_finalizacion = Convert.ToDateTime(txtfechafinal.Text),
                            Fecha_Inicio = Convert.ToDateTime(txtfechainicio.Text),
                            CantidadDias = count,
                            TipoIncapacidad = DDLTipo.SelectedItem.ToString(),
                            Descripcion = txtdescripcion.Text,
                            FechaEmision = Convert.ToDateTime(txtfechaemision.Text),
                            CentroEmisor = txtcentroemisor.Text,
                            NombreDoctor = txtnombredoc.Text,
                            Estado = true,

                        };
                        if (Login.EmpleadoGlobal.IdRol == 1)
                        {
                            Singleton.opIncapacidad.InsertarIncapacidad(inca);
                            Singleton.opAudiEmple.InsertarAuditoriasEmpleado(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, true, false, false, false, false, false, false, false, false);
                            LimpiarCampos();
                            mensaje.Visible = true;
                            mensajeError.Visible = false;
                            mensajeinfo.Visible = false;
                            mensajawarning.Visible = false;
                            textoMensaje.InnerHtml = "Incapacidad generada";

                        }
                        else if (Login.EmpleadoGlobal.IdRol == 2)
                        {
                            Singleton.opIncapacidad.InsertarIncapacidad(inca);
                            LimpiarCampos();
                            mensaje.Visible = true;
                            mensajeError.Visible = false;
                            mensajeinfo.Visible = false;
                            mensajawarning.Visible = false;
                            textoMensaje.InnerHtml = "Incapacidad generada ";

                        }
                        else
                        {
                            Singleton.opIncapacidad.InsertarIncapacidad(inca);
                            LimpiarCampos();
                            mensaje.Visible = true;
                            mensajeError.Visible = false;
                            mensajeinfo.Visible = false;
                            mensajawarning.Visible = false;
                            textoMensaje.InnerHtml = "Incapacidad generada ";


                        }

                    }
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

                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

            if (Login.EmpleadoGlobal.IdRol == 1)
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("WebForm1.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);
            }
            else if (Login.EmpleadoGlobal.IdRol == 2)
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("VistaJefe.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

            }
            else
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

            }
        }
        public void LimpiarCampos()
        {
            txtfechainicio.Text = string.Empty;
            txtfechafinal.Text = string.Empty;
            txtfechaemision.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            txtcentroemisor.Text = string.Empty;
            txtnombredoc.Text = string.Empty;
        }
    }
}