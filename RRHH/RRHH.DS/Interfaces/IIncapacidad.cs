using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
  public  interface IIncapacidad
    {
        List<Incapacidad> ListarIncapacidades();
        Incapacidad BuscarIncapacidad(int IdIncapacidad);
        void InsertarIncapacidad(Incapacidad incapacidad);
        void ActualizarIncapacidad(Incapacidad incapacidad);
        void EliminarIncapacidad(int  idIncapacidad);
    }
}
