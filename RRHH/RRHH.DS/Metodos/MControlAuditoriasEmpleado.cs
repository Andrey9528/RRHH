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
    public class MControlAuditoriasEmpleado : IControlAuditoriasEmpleado
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MControlAuditoriasEmpleado()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }
        public void InsertarAuditoriasEmpleado(string NombreEmpleado, string Cedula, bool VerPerfil, bool ActualizarDatos, bool RegistroIncapacidades, bool ConsultaIncapacidades, bool SolicitudVacaciones,bool ConsultaVacaciones, bool Ayuda, bool CambioContraseña, bool CerrarSeccion, bool LoginExitoso, bool LoginFallido)
        {
            _db.SqlScalar<ControlAuditoriasEmpleado>("exec insertarAuditoriasEmpleado '" + NombreEmpleado + "' , '" + Cedula + "' , '" + VerPerfil + "' , '" + ActualizarDatos + "' , '" + RegistroIncapacidades + "' , '" + ConsultaIncapacidades + "' , '" + SolicitudVacaciones+"' , '" + ConsultaVacaciones + "' , '" + Ayuda + "' , '" + CambioContraseña + "' , '" + CerrarSeccion + "' , '" + LoginExitoso+ "' , " + LoginFallido );


        }

        public List<ControlAuditoriasEmpleado> ListarAuditoriasEmpleado()
        {
          return  _db.Select<ControlAuditoriasEmpleado>();
        }
    }
}
