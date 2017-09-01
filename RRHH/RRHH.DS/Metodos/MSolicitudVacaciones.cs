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

        public SolicitudVacaciones BuscarSolicitud(int idsolicitud)
        {
            return _db.Select<SolicitudVacaciones>(x => x.IdSolicitud == idsolicitud).FirstOrDefault();
        }

        public SolicitudVacaciones BuscarsolicitudPorId(string cedula)
        {
            return _db.Select<SolicitudVacaciones>(x => x.Cedula == cedula).FirstOrDefault();
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
    }
}
