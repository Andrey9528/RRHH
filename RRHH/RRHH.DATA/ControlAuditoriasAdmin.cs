using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
namespace RRHH.DATA
{
  public  class ControlAuditoriasAdmin
    {
        public string NombreAdmin { get; set; }

        public string Cedula { get; set; }

       

        public bool LoginExitoso { get; set; }

        public bool LoginFallido { get; set; }

        public bool VerPerfil { get; set; }

        public bool ActualizarPerfil { get; set; }

        public bool AgregarEmpleados { get; set; }

        public bool MantenimientoEmpleados { get; set; }

        public bool MantenimientoIncapacidades { get; set; }

        public bool MantenimientoVacaciones { get; set; }

        public bool RegistrarDepartamento { get; set; }

        public bool MantenimientoDepartamento { get; set; }

        public bool Ayuda { get; set; }

        public bool Auditoria { get; set; }

        public bool CambioContraseña { get; set; }

        public bool CerrarSeccion { get; set; }
    }
}
