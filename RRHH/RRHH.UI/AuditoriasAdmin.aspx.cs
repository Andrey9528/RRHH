using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
namespace RRHH.UI
{
    public partial class AuditoriasAdmin : System.Web.UI.Page
    {
        public static ControlAuditoriasEmpleado emple = new ControlAuditoriasEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                string AdminCorreo = Session["AdminCorreo"].ToString();
                lblMensaje.Text = "Historial de Empleados";
                Gv_datos.DataSource = Singleton.opAudiEmple.ListarAuditoriasEmpleado();
                Gv_datos.DataBind();
            }
            catch 
            {
                Response.Redirect("Error.aspx"); 
                
            }
        }

        protected void DDLAudi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLAudi.Text == "Empleados")
                {
                    lblMensaje.Text = "Historial de Empleados";
                    Gv_datos.DataSource = Singleton.opAudiEmple.ListarAuditoriasEmpleado();
                    Gv_datos.DataBind();
                    Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, false, false, true, false, false);

                }
                else if (DDLAudi.Text == "Jefes")
                {
                    lblMensaje.Text = "Historial de jefes de departamento";
                    Gv_datos.DataSource = Singleton.opAudiJefe.ListarAuditoriasJefe();
                    Gv_datos.DataBind();
                    Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, false, false, true, false, false);

                }
                else
                {
                    lblMensaje.Text = "Historial de Administradores";
                    Gv_datos.DataSource = Singleton.opaudi.ListarAuditoriasAdmin();
                    Gv_datos.DataBind();
                   
                }
            }
            catch 
            {
                

               
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

        }
    }
}