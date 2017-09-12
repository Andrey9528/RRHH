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
        Incapacidad BuscarIncapacidadPorCedula(string cedula);
        List<Incapacidad> BuscarIncapacidadPorCedula2(string cedula);

        void InsertarIncapacidad(Incapacidad incapacidad);
        void ActualizarIncapacidad(Incapacidad incapacidad);
        void EliminarIncapacidad(int  idIncapacidad);
        List<ListarIncapacidades> ListarIncapacidades(DateTime Fecha_Inicio, DateTime Fecha_finalizacion, string Cedula);

    }
}
