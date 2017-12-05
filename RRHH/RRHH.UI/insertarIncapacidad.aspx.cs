using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class insertarIncapacidad :  System.Web.UI.Page
    {
        public static int dias;
        List<DateTime> fechas = new List<DateTime>(); //desmadre
        List<DateTime> fechasVacaciones = new List<DateTime>(); //desmadre
        public static int DiasIncapacidadEnVacaciones;
        public static bool estado;


        public static int count; // desmadre

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.EmpleadoGlobal.IdRol == 1)
                {
                    string correo = Session["emple"].ToString();
                    Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                }
                else if (Login.EmpleadoGlobal.IdRol == 2)
                {

                    string correoLogin = Session["jefeCorreo"].ToString();
                    Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                }
                else
                {
                    Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                    string AdminCorreo = Session["AdminCorreo"].ToString();

                }

            }
            catch
            {
                Response.Redirect("Error.aspx");
                
            }
        }

        public void IncapacidadEnVacaciones(DateTime FechaInicio, DateTime FechaFinal) // desmadre
        {
            try
            {
                TimeSpan diferencia;
                int contador = 0;
                var listaId = Singleton.opsolicitud.Listarsolicitudes().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula && x.Condicion == true).ToList();
                var Feriados = Singleton.OpFeriados.ListarFeriados().Select(x => x.Fecha).ToList();
                if (listaId.Count == 0)
                {
                    contador = 0;
                    DiasIncapacidadEnVacaciones = DiasIncapacidadEnVacaciones - contador;
                }
                else
                {
                    foreach (var item in listaId)
                    {
                        contador = 0;
                        diferencia = item.FechaFinal - item.FechaInicio;
                        {
                            if ((FechaInicio >= item.FechaInicio) && (FechaInicio <= item.FechaFinal)
                                || (item.FechaFinal) >= item.FechaInicio && FechaFinal <= item.FechaFinal)
                            {

                                do
                                {
                                    foreach (var Fecha in Feriados)
                                    {

                                        if (Fecha.Date == FechaInicio)
                                        {
                                            contador = contador + 1;
                                        }
                                    }

                                    if (FechaInicio.DayOfWeek == DayOfWeek.Sunday)
                                    {
                                        contador = contador + 1;
                                    }

                                    else
                                    {
                                        DiasIncapacidadEnVacaciones = (DiasIncapacidadEnVacaciones + 1);
                                        DiasIncapacidadEnVacaciones = DiasIncapacidadEnVacaciones - contador;
                                        contador = 0;
                                    }
                                    FechaInicio = FechaInicio.AddDays(1);


                                } while (FechaInicio < FechaFinal);

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }
        }
        public bool ValidarRangoFechasIncapacidades(string fechainicio, string fechafinal)
        {
            try
            {
                var listaId = Singleton.opIncapacidad.ListarIncapacidades().Where(x => x.Cedula == Login.EmpleadoGlobal.Cedula).ToList();
                if (listaId.Count == 0)
                {
                    estado = false;
                }
                else
                {
                    foreach (var IdSolicitud in listaId)
                    {

                        if (Convert.ToDateTime(fechainicio) >= Convert.ToDateTime(IdSolicitud.Fecha_Inicio) && Convert.ToDateTime(fechainicio) <= Convert.ToDateTime(IdSolicitud.Fecha_finalizacion)
                            || Convert.ToDateTime(fechafinal) >= Convert.ToDateTime(IdSolicitud.Fecha_Inicio) && Convert.ToDateTime(fechafinal) <= Convert.ToDateTime(IdSolicitud.Fecha_finalizacion))
                        {
                            estado = true;

                        }
                        else
                        {
                            estado = false;

                        }
                    }
                    return estado;

                }
            }
            catch (Exception)
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensajawarning.Visible = false;
                mensaje.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }
            return estado;
        }
        //public bool ValidarRangoFechasVacaciones(string  fechainicio, string  fechafinal)
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
        //        textoMensajeError.InnerHtml = "Ha ocurrido un error";
        //        //textomensajeError.InnerHtml = "Ha ocurrido un error";
        //    }
        //    return false;
        //}

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
            try
            {
                count = 0;
                for (DateTime index = startDate; index < endDate; index = index.AddDays(1))
                {
                    if (excludeWeekends && index.DayOfWeek != DayOfWeek.Sunday)
                    {
                        bool excluded = false;
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

              
            }
            catch (Exception)
            {
                throw;
                
            }
              return count;
        }
        public  void mensajes()
        {
              
            mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
        }
        protected void btninsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacionDias(txtfechafinal.Text, txtfechainicio.Text))
                {
                    if  (ValidarRangoFechasIncapacidades(txtfechainicio.Text,  txtfechafinal.Text))
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
                        IncapacidadEnVacaciones(Convert.ToDateTime(txtfechainicio.Text), Convert.ToDateTime(txtfechafinal.Text)); // desmadre
                        Incapacidad inca = new Incapacidad()
                        {
                            Cedula = Login.EmpleadoGlobal.Cedula,
                            Fecha_finalizacion = Convert.ToDateTime(txtfechafinal.Text),
                            Fecha_Inicio = Convert.ToDateTime(txtfechainicio.Text),
                            CantidadDias = count + 1,
                            TipoIncapacidad = DDLTipo.SelectedItem.ToString(),
                            Descripcion = txtdescripcion.Text,
                            FechaEmision = Convert.ToDateTime(txtfechaemision.Text),
                            CentroEmisor = txtcentroemisor.Text,
                            NombreDoctor = txtnombredoc.Text,
                            Estado = true,
                            NombreEmpleado = Login.EmpleadoGlobal.Nombre
                        };

                        Empleado emple = new Empleado() // desmadre
                        {
                            Cedula = Login.EmpleadoGlobal.Cedula,
                            Nombre = Login.EmpleadoGlobal.Nombre,
                            Direccion = Login.EmpleadoGlobal.Direccion,
                            Telefono = Login.EmpleadoGlobal.Telefono,
                            Correo = Login.EmpleadoGlobal.Correo,
                            EstadoCivil = Login.EmpleadoGlobal.EstadoCivil,
                            FechaNacimiento = Login.EmpleadoGlobal.FechaNacimiento,
                            IdDepartamento = Login.EmpleadoGlobal.IdDepartamento,
                            IdRol = Login.EmpleadoGlobal.IdRol,
                            Estado = Login.EmpleadoGlobal.Estado,
                            Imagen = Login.EmpleadoGlobal.Imagen,
                            Bloqueado = Login.EmpleadoGlobal.Bloqueado,
                            Genero = Login.EmpleadoGlobal.Genero,
                            Password = Login.EmpleadoGlobal.Password,
                            IntentosFallidos = Login.EmpleadoGlobal.IntentosFallidos,
                            DiasVacaciones = Login.EmpleadoGlobal.DiasVacaciones + DiasIncapacidadEnVacaciones+1,
                            DiasAntesCaducidad = Login.EmpleadoGlobal.DiasAntesCaducidad,
                            ContraseñaCaducada = false,
                            FechaCaducidadContraseña=Login.EmpleadoGlobal.FechaCaducidadContraseña,
                            FechaIngreso=Login.EmpleadoGlobal.FechaIngreso,
                            SesionIniciada=Login.EmpleadoGlobal.SesionIniciada
                            
                        };
                        DiasIncapacidadEnVacaciones = 0;
                        count = 0;
                        dias = 0;

                        if (Login.EmpleadoGlobal.IdRol == 1)
                        {
                            Singleton.opIncapacidad.InsertarIncapacidad(inca);
                            Singleton.OpEmpleados.ActualizarEmpleados(emple);
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
                            Singleton.OpEmpleados.ActualizarEmpleados(emple);
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
                            Singleton.OpEmpleados.ActualizarEmpleados(emple);
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
                    estado = true;
                }
               

                else
                {
                    estado = false;
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
            return estado;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }

           
        }
        public void LimpiarCampos()
        {
            try
            {
                txtfechainicio.Text = string.Empty;
                txtfechafinal.Text = string.Empty;
                txtfechaemision.Text = string.Empty;
                txtdescripcion.Text = string.Empty;
                txtcentroemisor.Text = string.Empty;
                txtnombredoc.Text = string.Empty;
            }
            catch
            {
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }
    }
}