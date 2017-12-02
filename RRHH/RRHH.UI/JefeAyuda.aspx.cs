using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RRHH.UI
{
    public partial class JefeAyuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string correoLogin = Session["jefeCorreo"].ToString();
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
            } catch
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("VistaJefe.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);
            }
            catch
            {
                mensajeError.Visible = true;
                textomensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void btnReportar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Jefe/VerPerfilModificar.pdf"));
                Response.End();
            }
            catch
            {

                mensajeError.Visible = true;
                textomensajeError.InnerHtml = "Hubo un error";
            }

        }

        protected void LKB_ReporteCambioContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Jefe/CambioContraseña.pdf"));
                Response.End();
            }
            catch
            {

                mensajeError.Visible = true;
                textomensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void GestionVaca_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Jefe/AceptarDenegarVaca.pdf"));
                Response.End();
            }
            catch
            {

                mensajeError.Visible = true;
                textomensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void ReportelistaEmple_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Jefe/ListaEmpleados.pdf"));
                Response.End();

            } catch
            {

                mensajeError.Visible = true;
                textomensajeError.InnerHtml = "Hubo un error";
            }
        }

        protected void ReporteInca_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Jefe/ListaEmpleados.pdf"));
                Response.End();

            }
            catch
            {

                mensajeError.Visible = true;
                textomensajeError.InnerHtml = "Hubo un error";

            }
        }
    }
}