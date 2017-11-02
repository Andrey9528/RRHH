using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using RRHH.DS.Metodos;

namespace RRHH.UI
{
    public partial class InsertarDepartamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                var depart = new departamento()
                {

                    Nombre = txtnombre.Text,
                };
                Singleton.opdepartamento.InsertarDepartamentos(depart);
                mensaje.Visible = true;
                textoMensaje.InnerHtml = "Departamento agregado";

            }
            catch (Exception)
            {
                throw;
            }


        }
        public void limpiarCampos()
        {

        }
    }
}