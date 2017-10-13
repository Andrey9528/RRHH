using System;
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
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
            Response.TransmitFile(Server.MapPath("~/TutorialesPDF/Seashore piano technic.pdf"));
            Response.End();
        }
    }
}