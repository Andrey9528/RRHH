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
    public class MDepartamento : Idepartamento
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MDepartamento()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();

        }
        public void ActualizarDepartamentos(departamento departamento)
        {
            _db.Update(departamento);
        }

        public departamento BuscarDepartamentos(int IdDepartemento)
        {
            return _db.Select<departamento>(x => x.IdDepartamento==IdDepartemento).FirstOrDefault();
        }

        public departamento BuscarDepartamentosPorNombre(string Departemento)
        {
            return _db.Select<departamento>(x => x.Nombre == Departemento).FirstOrDefault();
        }

        public void EliminarDepartamentos(int IdDepartamento)
        {
             _db.Delete<departamento>(x => x.IdDepartamento == IdDepartamento);
        }

        public void InsertarDepartamentos(departamento departamento)
        {
            _db.Insert(departamento);
        }

        public List<departamento> ListarDepartamentos()
        {
            return _db.Select<departamento>();
        }
    }
}
