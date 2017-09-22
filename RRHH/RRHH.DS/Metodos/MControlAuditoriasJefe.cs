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
    public class MControlAuditoriasJefe : IControlAuditoriasJefe
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MControlAuditoriasJefe()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }
        public void InsertarAuditoriasJefe(string NombreJefe, string Cedula, bool VerPerfil, bool ActualizarPerfil, bool ListarEmpleados, bool ListarIncapacidades, bool VerVacaciones, bool Ayuda, bool CambioContraseña, bool CerrarSeccion, bool LoginExitoso, bool LoginFallido)
        {
            _db.SqlScalar<ControlAuditoriasJefe>("exec insertarAuditoriasJefe '" + NombreJefe + "' , '" + Cedula + "' , '" + VerPerfil + "' , '" + ActualizarPerfil + "' , '" + ListarIncapacidades + "' , '" + VerVacaciones + "' , '" + Ayuda + "' , '" + CambioContraseña + "' , '" + CerrarSeccion + "' , '" + LoginExitoso + "' , " + LoginFallido );

        }

        public List<ControlAuditoriasJefe> ListarAuditoriasJefe()
        {
            throw new NotImplementedException();
        }
    }
}
