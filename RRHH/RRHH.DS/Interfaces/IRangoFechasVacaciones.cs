using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;


namespace RRHH.DS.Interfaces
{
   public interface IRangoFechasVacaciones
    {
        //List<RangoFechasVacaciones> RangoFechasVacaciones(string Cedula);
        List<RangoFechasVacaciones> ValidarRango (string Cedula, DateTime FechaInicio, int IdSolicitud);

    }
}
