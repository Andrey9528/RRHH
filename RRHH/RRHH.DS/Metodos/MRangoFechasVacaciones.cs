using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using ServiceStack.OrmLite;
using System.Data;

namespace RRHH.DS.Metodos
{
    public class MRangoFechasVacaciones : IRangoFechasVacaciones
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MRangoFechasVacaciones()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }

        List<RangoFechasVacaciones> IRangoFechasVacaciones.RangoFechasVacaciones(string Cedula)
        {
            return _db.SqlList<RangoFechasVacaciones>("exec RangoFechasVacaciones "+ Cedula);
        }

     
    }
}
