using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
  public interface IControlAuditoriasEmpleado
    {
        List<ControlAuditoriasEmpleado> ListarAuditoriasEmpleado();
        void InsertarAuditoriasEmpleado(string NombreEmpleado, string Cedula, bool VerPerfil, bool ActualizarDatos, bool RegistroIncapacidades , bool ConsultaIncapacidades, bool SolicitudVacaciones,bool ConsultaVacaciones, bool Ayuda, bool CambioContraseña, bool CerrarSeccion, bool LoginExitoso, bool LoginFallido);

    }
}
