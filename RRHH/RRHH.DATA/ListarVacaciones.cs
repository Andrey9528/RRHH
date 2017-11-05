using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.DATA
{
   public class ListarVacaciones
    {
     
        public int IdSolicitud { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public int TotalDias { get; set; }

        public bool? Condicion { get; set; }

        public string NombreEmpleado { get; set; }



    }
}
