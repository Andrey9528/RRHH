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
    public class MControlAuditorias : IControlAuditorias
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MControlAuditorias()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();

        }
        public void InsertarAuditorias(ControlAuditorias controlAudi)
        {
            _db.SqlScalar<ControlAuditorias>("exec nombredelProcedure parametros",new { });

        }

        public List<ControlAuditorias> ListarAudi()
        {
            return _db.Select<ControlAuditorias>();
        }
    }
}
