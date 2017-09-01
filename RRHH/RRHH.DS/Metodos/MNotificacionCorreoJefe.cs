using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using RRHH.DS.Metodos;
using ServiceStack.OrmLite;
using System.Data;

namespace RRHH.DS.Metodos
{
    public class MNotificacionCorreoJefe : INotificacionCorreoJefe
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MNotificacionCorreoJefe()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }

        public NotificacionCorreoJefe BuscarEmpleados(string Cedula)
        {
            return _db.SqlScalar<NotificacionCorreoJefe>("Exec NotificacionCorreoJefe @Cedula", new { Cedula = Cedula });
        }

        public List<NotificacionCorreoJefe> CorreoJefe(string Cedula)
        {
            return _db.SqlList<NotificacionCorreoJefe>("exec NotificacionCorreoJefe " + Cedula);

             
        }
    }
}
