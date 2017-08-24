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
    public class MRoles : IRoles
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MRoles()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }
        public void ActualizarRoles(Roles roles)
        {
            _db.Update(roles);
        }

        public Roles BuscarRoles(int id_rol)
        {
            return _db.Select<Roles>(x => x.IdRol==id_rol).FirstOrDefault();
        }

        public void EliminarRoles(int id_rol)
        {
            _db.Delete<Roles>(x => x.IdRol == id_rol);
        }

        public void InsertarRoles(Roles roles)
        {
            _db.Insert(roles);
        }

        public List<Roles> ListarRoles()
        {
            return _db.Select<Roles>();
        }
    }
}
