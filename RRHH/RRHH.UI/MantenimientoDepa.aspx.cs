using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class MantenimientoDepa : System.Web.UI.Page
    {
        departamento departamentoGlobal = new departamento();
        protected void Page_Load(object sender, EventArgs e)
        {
            Gv_datos.DataSource = Singleton.opdepartamento.ListarDepartamentos();
            Gv_datos.DataBind();
            if (!IsPostBack)
            {
                DDLdepa.DataSource = Singleton.opdepartamento.ListarDepartamentos().Select(x => x.Nombre).ToList();
                DDLdepa.DataBind();
            }
        }

        protected void btnbuscardepa_Click(object sender, EventArgs e)
        {
            try
            {
                List<departamento>lista=Singleton.opdepartamento.ListarDepartamentos();
                var depa = lista.FirstOrDefault(x => x.Nombre == DDLdepa.Text);
                if (depa != null)
                {
                    DDLdepa.Enabled = false;
                    mantenimientoDepa.Visible = true;
                    txtcorreojefe.Text = depa.EmailJefeDpto.ToString();
                    txtnombre.Text = depa.NombreJefe.ToString();
                    mensaje.Visible = false;
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = false;
                }
                else
                {

                }

            }
            catch
            {

            }
        }

        
        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            try
            {
               
               departamentoGlobal=Singleton.opdepartamento.BuscarDepartamentosPorNombre(DDLdepa.Text);
                var id_depa = departamentoGlobal.IdDepartamento.ToString();
                departamento depa = new departamento()
                {
                    IdDepartamento = Convert.ToInt32(id_depa),
                    Nombre=DDLdepa.SelectedItem.ToString(),
                    NombreJefe=txtnombre.Text,
                    EmailJefeDpto=txtcorreojefe.Text
                    
                    
                };
                Singleton.opdepartamento.ActualizarDepartamentos(depa);
                Gv_datos.DataSource = Singleton.opdepartamento.ListarDepartamentos();
                Gv_datos.DataBind();
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                mensajeError.Visible = false;
                mensajawarning.Visible = true;
                textomensajewarning.InnerHtml = "Actualizado";
                mantenimientoDepa.Visible = false;
                DDLdepa.Enabled = true;
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btndesahabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                string confirmValue = Request.Form["confirm_value"];
                  

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}