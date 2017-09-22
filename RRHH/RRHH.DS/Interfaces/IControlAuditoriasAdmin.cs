using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
   public interface IControlAuditoriasAdmin
    {
        List<ControlAuditoriasAdmin> ListarAuditoriasAdmin();
        void InsertarAuditoriasAdmin(string NombreAdmin, string Cedula,  bool LoginExitoso, bool LoginFallido, bool VerPerfil, bool ActualizarPerfil, bool AgregarEmpleados, bool MantenimientoEmpleados, bool MantenimientoIncapacidades, bool MantenimientoVacaciones, bool RegistrarDepartamento, bool MantenimientoDepartamento, bool Ayuda, bool Auditoria, bool CambioContraseña, bool CerrarSeccion);
       
    }
}
