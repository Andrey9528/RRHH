using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using RRHH.DS.Interfaces;
using RRHH.DATA;
using System.Data;

namespace RRHH.DS.Metodos
{
    public class MFeriados : IFeriados
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MFeriados()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();

        }

        public void InsertarFeriados(Feriados feriado)
        {
            _db.Insert(feriado);
        }

        public List<Feriados> ListarFeriados()
        {
            return _db.Select<Feriados>();
        }
    }
}
