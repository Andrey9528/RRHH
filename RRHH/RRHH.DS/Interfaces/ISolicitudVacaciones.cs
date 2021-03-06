﻿using System;
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
        List<SolicitudVacaciones> BuscarsolicitudRangos(int cedula);

        List<SolicitudVacaciones> BuscarsolicitudPorId (string cedula);
        List<ListarVacaciones> ListarVacaciones(DateTime FechaInicio, DateTime FechaFinal, string cedula, bool Condicion);
        List<SolicitudVacaciones> BuscarFechaMenor(string cedula, bool condicion);
        List<SolicitudVacaciones> BuscarFechaMayor(string cedula, bool condicion);


    }
}
