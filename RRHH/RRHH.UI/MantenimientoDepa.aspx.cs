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
            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;
                string AdminCorreo = Session["AdminCorreo"].ToString();
                Gv_datos.DataSource = Singleton.opdepartamento.ListarDepartamentos();
                Gv_datos.DataBind();
              
                txtnombre.Enabled = false;
                txtcorreojefe.Enabled = false;

                if (!IsPostBack)
                {
                    DDLdepa.DataSource = Singleton.opdepartamento.ListarDepartamentos().Select(x => x.Nombre).ToList();
                    DDLdepa.DataBind();


                }
            }
            catch
            {
                Response.Redirect("Error.aspx");
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
                    txtnombre.Enabled = true;
                    txtcorreojefe.Enabled = true;
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
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
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
                    Singleton.opaudi.InsertarAuditoriasAdmin(Login.EmpleadoGlobal.Nombre, Login.EmpleadoGlobal.Cedula, false, false, false, false, false, false, false, false, false, true, false, false, false, false);

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

                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
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

                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ROL"] = Login.EmpleadoGlobal.IdRol;

                Response.Redirect("AdminView.aspx?ROL=" + Login.EmpleadoGlobal.IdRol);
            }
            catch
            {
                mensajawarning.Visible = false;
                mensajeError.Visible = true;
                mensaje.Visible = false;
                mensajeinfo.Visible = false;
                textoMensajeError.InnerHtml = "Hubo un error";
            }
        }
    }
}