using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace RRHH.DATA
{
   public class ControlAuditoriasEmpleado
    {
        public string NombreEmpleado { get; set; }

        public string Cedula { get; set; }

       

        public bool VerPerfil { get; set; }

        public bool ActualizarDatos { get; set; }

        public bool RegistroIncapacidades { get; set; }

        public bool ConsultaIncapacidades { get; set; }

        public bool SolicitudVacaciones { get; set; }

        public bool ConsultaVacaciones { get; set; }

        public bool Ayuda { get; set; }

        public bool CambioContraseña { get; set; }

        public bool CerrarSeccion { get; set; }

        public bool? LoginExitoso { get; set; }

        public bool? LoginFallido { get; set; }
    }
}
