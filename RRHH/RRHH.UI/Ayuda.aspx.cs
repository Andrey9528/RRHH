﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RRHH.UI
{
    public partial class Ayuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReportar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Empleado/VerPerfilyModificar.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("WebForm1.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);
        }

        protected void LKB_ReporteInca_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Empleado/GestionDeIncapacidades.pdf"));
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
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Empleado/GestionDeVacaciones.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void LKB_ReporteContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Empleado/CambioContraseña.pdf"));
                Response.End();
            }
            catch { }
        }

        protected void LKB_ReporteOlvideContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
                Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Empleado/OlvideContraseña.pdf"));
                Response.End();
            }
            catch { }

        }
    }
}