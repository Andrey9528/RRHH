using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
   public interface ISolicitudVacaciones
    {
        List<SolicitudVacaciones> Listarsolicitudes();
        SolicitudVacaciones BuscarSolicitud(int idsolicitud);
        void InsertarSolicitud(SolicitudVacaciones solicitud);
        void ActualizarSolicitud(SolicitudVacaciones solicitud);
        void EliminarSolicitud(int idsolicitud);
        List<SolicitudVacaciones> BuscarsolicitudPorId (string cedula);

    }
}
