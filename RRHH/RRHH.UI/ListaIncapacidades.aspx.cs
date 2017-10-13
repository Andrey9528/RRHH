using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class ListaIncapacidades : System.Web.UI.Page
    {
        Incapacidad IncapacidadGlobal = new Incapacidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
            GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X=>X.Estado==true);
            GV_inca.DataBind();

            }
            catch
            {
                mensajeError.Visible = true;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
           
        }

        protected void DDLEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (DDLEstado.Text == "Registradas")
                {
                    mensajeError.Visible = false;
                   
                    GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X => X.Estado == true);
                    GV_inca.DataBind();
                }
                else if (DDLEstado.Text == "No registradas")
                {
                    mensajeError.Visible = false;

                    GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X => X.Estado == false);
                    GV_inca.DataBind();
                }
            }
            catch
            {
                mensajeError.Visible = true;
                textoMensajeError.InnerHtml = "Hubo un error";

            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("VistaJefe.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

        }
    }
}