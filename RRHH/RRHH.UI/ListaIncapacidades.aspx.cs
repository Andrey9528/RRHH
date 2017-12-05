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

                string correoLogin = Session["jefeCorreo"].ToString();
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X=>X.Estado==true);
            GV_inca.DataBind();

            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
           
        }

        protected void DDLEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (DDLEstado.Text == "Registradas")
                {
                    mensajeError.Visible = false;
                   
                    GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where (X => X.Estado == true );
                    GV_inca.DataBind();
                    Singleton.opAudiJefe.InsertarAuditoriasJefe(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, true, false, false, false, false, false, false);

                }
                else if (DDLEstado.Text == "No registradas")
                {
                    mensajeError.Visible = false;

                    GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X => X.Estado == false);
                    GV_inca.DataBind();
                    Singleton.opAudiJefe.InsertarAuditoriasJefe(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, true, false, false, false, false, false, false);

                }
            }
            catch
            {
                mensajeError.Visible = true;
                mensajeinfo.Visible = false;
                mensaje.Visible = false;
                mensajawarning.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";

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
                mensajeinfo.Visible = false;
                mensaje.Visible = false;
                mensajawarning.Visible = false;
                textoMensajeError.InnerHtml = "Ha ocurrido un error";
            }
        }
    }
}