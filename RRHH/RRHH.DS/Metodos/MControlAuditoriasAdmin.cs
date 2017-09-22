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
    public class MControlAuditoriasAdmin : IControlAuditoriasAdmin
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MControlAuditoriasAdmin()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();

        }
        public void InsertarAuditoriasAdmin(string NombreAdmin,string Cedula,bool LoginExitoso,bool LoginFallido,bool VerPerfil,bool ActualizarPerfil,bool AgregarEmpleados,bool MantenimientoEmpleados,bool MantenimientoIncapacidades, bool MantenimientoVacaciones,bool RegistrarDepartamento,bool MantenimientoDepartamento,bool Ayuda,bool Auditoria,bool CambioContraseña,bool CerrarSeccion)
        {
           _db.SqlScalar<ControlAuditoriasAdmin>("exec insertarAuditoriasAdmin '" + NombreAdmin + "' , '" +Cedula + "' , '" + LoginExitoso + "' , '" + LoginFallido+"' , '"+VerPerfil+"' , '"+ActualizarPerfil+"' , '"+AgregarEmpleados+ "' , '"+MantenimientoEmpleados+"' , '"+MantenimientoIncapacidades+"' , '"+MantenimientoVacaciones+"' , '"+RegistrarDepartamento+"' , '"+MantenimientoDepartamento+ "','"+Ayuda+"' , '"+Auditoria+"' , '"+CambioContraseña+"' , "+CerrarSeccion);

        }

        public List<ControlAuditoriasAdmin> ListarAuditoriasAdmin()
        {
           return  _db.Select<ControlAuditoriasAdmin>();
        }
    }
}
