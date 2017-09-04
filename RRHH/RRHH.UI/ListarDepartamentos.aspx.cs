using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;


namespace RRHH.UI
{
    public partial class ListarDepartamentos : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //DGV_datos.DataSource = Singleton.opdepartamento.ListarDepartamentos();
            //DGV_datos.DataBind();

        }

        protected void DGV_datos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                
            }
            catch { }
        }
    }
}