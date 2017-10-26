using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ServiceStack.OrmLite;
using RRHH.DS.Interfaces;
using RRHH.DATA;

namespace RRHH.DS.Metodos
{
    public class MSolicitudVacaciones : ISolicitudVacaciones
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MSolicitudVacaciones()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }
        public void ActualizarSolicitud(SolicitudVacaciones solicitud)
        {
            _db.Update(solicitud);
        }

        public List<SolicitudVacaciones> BuscarFechaMayor(string cedula, bool condicion)
        {
            return _db.SqlList<SolicitudVacaciones>("select  max(FechaInicio) from SolicitudVacaciones where Cedula = " + cedula + "and Condicion = " + condicion + ";");
        }

        public List<SolicitudVacaciones> BuscarFechaMenor(string cedula, bool condicion)
        {
            return _db.SqlList<SolicitudVacaciones>("select  min(FechaInicio) from SolicitudVacaciones where Cedula = " + cedula + "and Condicion = " + condicion + ";");
        }


        public SolicitudVacaciones BuscarSolicitud(int idsolicitud)
        {
            return _db.Select<SolicitudVacaciones>(x => x.IdSolicitud == idsolicitud).FirstOrDefault();
        }

        public List<SolicitudVacaciones> BuscarsolicitudPorId(string cedula)
        {
            return (_db.Select<SolicitudVacaciones>().Where(x => x.Cedula == cedula)).ToList();
        }

        public List<SolicitudVacaciones> BuscarsolicitudRangos(int IdSolicitud)
        {
            return (_db.Select<SolicitudVacaciones>().Where(x => x.IdSolicitud == IdSolicitud)).ToList();
        }

        public void EliminarSolicitud(int idsolicitud)
        {
            _db.Delete<SolicitudVacaciones>(x => x.IdSolicitud == idsolicitud);
        }

        public void InsertarSolicitud(SolicitudVacaciones solicitud)
        {
            _db.Insert(solicitud);
        }

        public List<SolicitudVacaciones> Listarsolicitudes()
        {
           return  _db.Select<SolicitudVacaciones>();
        }

        public List<ListarVacaciones> ListarVacaciones(DateTime FechaInicio, DateTime FechaFinal, string cedula, bool Condicion)
             {
            return _db.SqlList<ListarVacaciones>("exec ListarVacaciones '" +FechaInicio+"' , '"+FechaFinal+"' , '"+cedula+"' , "+Condicion);


        }
    }
}
