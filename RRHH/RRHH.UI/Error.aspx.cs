﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRHH.DATA;
namespace RRHH.UI
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.EmpleadoGlobal.IdRol == 1)
            {
                vistaJefe.Visible = false;
                VistaEmpleado.Visible = true;
            }
            else
            {
                vistaJefe.Visible = true;
                VistaEmpleado.Visible = false; 
            }
        }
    }
}