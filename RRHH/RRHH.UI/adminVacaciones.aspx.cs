using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class adminVacaciones : System.Web.UI.Page
    {
        SolicitudVacaciones soli = new SolicitudVacaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            Gv_datos.DataSource = Singleton.opsolicitud.Listarsolicitudes();
            Gv_datos.DataBind();
            if (!IsPostBack)
            {
                DDLidsoli.DataSource = Singleton.opsolicitud.Listarsolicitudes().Select(x => x.IdSolicitud).ToList();
                DDLidsoli.DataBind();
            }

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            List<SolicitudVacaciones> lista = Singleton.opsolicitud.Listarsolicitudes();
            var vaca = lista.FirstOrDefault(x => x.IdSolicitud==Convert.ToInt32(DDLidsoli.Text));

            if (vaca != null)
            {
                mantenimientovacaciones.Visible = true;
               
                txtfechaincio.Text = vaca.FechaInicio.ToString();
                txtfechafinal.Text = vaca.FechaFinal.ToString();
            }
            else
            {

            }

            

        }
    }
}