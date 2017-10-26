using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace RRHH.DATA
{
    public class RangoFechasVacaciones
    {
        //public int FechaInicioMenor { get; set; }
        //public string FechaInicioMayor { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdSolicitud { get; set; }

    }
}
