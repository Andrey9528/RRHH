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
            GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X=>X.Estado==true);
            GV_inca.DataBind();

        }

        protected void DDLEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLEstado.Text == "Activos")
            {
                GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X => X.Estado == true);
                GV_inca.DataBind();
            }
            else if(DDLEstado.Text=="Inactivos")
            {
                GV_inca.DataSource = Singleton.opIncapacidad.ListarIncapacidades().Where(X => X.Estado ==false);
                GV_inca.DataBind();
            }
        }
    }
}