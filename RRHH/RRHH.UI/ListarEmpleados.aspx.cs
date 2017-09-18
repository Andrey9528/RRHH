using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;

namespace RRHH.UI
{
    public partial class Lista_de_Empleados : System.Web.UI.Page
    {
        public static Empleado EmpleaoGlobal = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                    List<Empleado> listar = Singleton.OpEmpleados.ListarEmpleados();
                    var listaEmple = listar.Select(x => new {x.Cedula, x.Nombre, x.Direccion, x.Telefono, x.Correo, x.EstadoCivil, x.Genero, x.FechaNacimiento, x.Estado ,x.Imagen});
                   
                    //gv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    //gv_datos.DataBind();
                    //listview
                    //lv_empleados.DataSource = listaEmple.Where(x=>x.Estado==true);
                    //lv_empleados.DataBind();
                    lv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    lv_datos.DataBind();
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DDLActivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Empleado> listar = Singleton.OpEmpleados.ListarEmpleados();
            var listaEmple = listar.Select(x => new {x.Cedula, x.Nombre, x.Direccion, x.Telefono, x.Correo, x.EstadoCivil, x.Genero, x.FechaNacimiento, x.Estado,x.Imagen });

            if (DDLActivos.Text == "Activo" && EmpleaoGlobal.Estado==true )
            {
                
                lv_datos.DataSource = listaEmple.Where(x => x.Estado == true);
                    lv_datos.DataBind();
            }
            else if (DDLActivos.Text == "Inactivo" && EmpleaoGlobal.Estado==false)    
            {

                lv_datos.DataSource = listaEmple.Where(x => x.Estado == false);
                lv_datos.DataBind();
            }
        }
    }
}