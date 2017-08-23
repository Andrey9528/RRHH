using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RRHH.UI
{
    public class Sigleton
    {
        public static DS.Interfaces.IEmpleado OpEmpleados = new DS.Metodos.MEmpleado();
    }
}