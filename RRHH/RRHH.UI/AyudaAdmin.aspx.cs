using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RRHH.UI
{
    public partial class AyudaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

        }

        protected void btnReportar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Admin/VerPerfilModificarAdmin.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void LKB_ReporteCambioContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Admin/CambioContraseña.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void LKB_ReporteVaca_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Admin/MantenimeintoVaca.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void LKB_ReporteInca_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Admin/MantenimientoVaca.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void LKB_ReporteDepa_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Admin/MantenimientoDepa.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void ReportemanteimientoEmple_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Admin/MantenimientoEmple.pdf"));
                Response.End();
            }
            catch { }
            }


        protected void LinkRegistroEmple_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Admin/MantenimientoEmple.pdf"));
                Response.End();
            }
            catch { }
        }
    }
}