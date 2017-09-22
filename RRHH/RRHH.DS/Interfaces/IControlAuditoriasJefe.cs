using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
  public  interface IControlAuditoriasJefe
    {
        List<ControlAuditoriasJefe> ListarAuditoriasJefe();
        void InsertarAuditoriasJefe(string NombreJefe, string Cedula,bool VerPerfil, bool ActualizarPerfil,bool ListarEmpleados,bool ListarIncapacidades,bool VerVacaciones,bool Ayuda,bool CambioContraseña,bool CerrarSeccion,bool LoginExitoso, bool LoginFallido);

    }
}
