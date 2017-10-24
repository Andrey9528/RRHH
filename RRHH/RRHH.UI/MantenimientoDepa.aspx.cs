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
                    lblActivo.Visible = true;
                    Chk_estado.Visible = true;
                    Chk_estado.Enabled = true;
                    DDLdepa.Enabled = false;
                    btnactualizar.Enabled = true;
                    mantenimientoDepa.Visible = true;
                    txtcorreojefe.Text = depa.EmailJefeDpto.ToString();
                    txtnombre.Text = depa.NombreJefe.ToString();
                    Chk_estado.Checked = (bool)depa.Estado;
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
                string confirmValueNo = Request.Form["confirm_value"];

                if (Chk_estado.Checked)
                {

                    departamentoGlobal = Singleton.opdepartamento.BuscarDepartamentosPorNombre(DDLdepa.Text);
                    var id_depa = departamentoGlobal.IdDepartamento.ToString();
                    departamento depa = new departamento()
                    {
                        IdDepartamento = Convert.ToInt32(id_depa),
                        Nombre = DDLdepa.SelectedItem.ToString(),
                        NombreJefe = txtnombre.Text,
                        EmailJefeDpto = txtcorreojefe.Text,
                        Estado = true



                    };
                    Singleton.opdepartamento.ActualizarDepartamentos(depa);
                    Gv_datos.DataSource = Singleton.opdepartamento.ListarDepartamentos();
                    Gv_datos.DataBind();
                    mensaje.Visible = false;
                    Chk_estado.Enabled = false;
                    txtcorreojefe.Text = string.Empty;
                    txtnombre.Text = string.Empty;
                    btnactualizar.Enabled = false;
                  
                    mensajeinfo.Visible = false;
                    mensajeError.Visible = false;
                    mensajawarning.Visible = true;
                    textomensajewarning.InnerHtml = "Actualizado";
                    Chk_estado.Checked = false;
                  
                    DDLdepa.Enabled = true;

                }
                else if (Chk_estado.Checked && confirmValueNo=="No" )
                {
                    mensajawarning.Visible = false;
                    mensajeError.Visible = false;
                    mensajeinfo.Visible = false;
                    mensaje.Visible = false;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Operacion cancelada')", true);

                }
                else
                {

                    string confirmValue = Request.Form["confirm_value"];

                    int id_depa = Singleton.opdepartamento.BuscarDepartamentosPorNombre(DDLdepa.Text).IdDepartamento;
                    departamento depa2 = new departamento();
                    depa2 = Singleton.opdepartamento.BuscarDepartamentos(id_depa);
                    if (Chk_estado.Checked == false && confirmValue == "Yes")
                    {
                        departamento depa = new departamento()
                        {
                            IdDepartamento = depa2.IdDepartamento,
                            Nombre = depa2.Nombre,
                            EmailJefeDpto = depa2.EmailJefeDpto,
                            NombreJefe = depa2.NombreJefe,
                            Estado = false

                        };
                        Singleton.opdepartamento.ActualizarDepartamentos(depa);
                        mensaje.Visible = false;
                        mensajawarning.Visible = false;
                        mensajeinfo.Visible = true;
                        mensajeError.Visible = false;
                        textomensajeinfo.InnerHtml = "Departamento borrado";
                       
                        txtcorreojefe.Text = string.Empty;
                        txtnombre.Text = string.Empty;
                        btnactualizar.Enabled = false;
                        Chk_estado.Checked = false;
                        DDLdepa.Enabled = true;
                        Chk_estado.Enabled = false;

                    }


                }


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
                int id_depa = Singleton.opdepartamento.BuscarDepartamentosPorNombre(DDLdepa.Text).IdDepartamento;
                departamento depa2 = new departamento();
                depa2 = Singleton.opdepartamento.BuscarDepartamentos(id_depa);
                if (Chk_estado.Checked == false && confirmValue == "Yes")
                {
                    departamento depa=new  departamento()
                    {
                        IdDepartamento=depa2.IdDepartamento,
                        Nombre=depa2.Nombre,
                        EmailJefeDpto=depa2.EmailJefeDpto,
                        Estado=Chk_estado.Checked
                        
                    };
                    Singleton.opdepartamento.ActualizarDepartamentos(depa);
                    mensaje.Visible = false;
                    mensajawarning.Visible = false;
                    mensajeinfo.Visible = true;
                    mensajeError.Visible = false;
                    textomensajeinfo.InnerHtml = "Departamento borrado";
                       
                }
                  

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["ROL"] = Login.EmpleadoGlobal.IdRol;

            Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);

        }
    }
}