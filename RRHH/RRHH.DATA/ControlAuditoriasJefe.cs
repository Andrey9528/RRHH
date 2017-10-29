using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace RRHH.DATA
{
  public  class ControlAuditoriasJefe
    {
        public string NombreJefe { get; set; }

        public string Cedula { get; set; }

        public DateTime Fecha { get; set; }

        public bool VerPerfil { get; set; }

        public bool ActualizarPerfil { get; set; }

        public bool ListarEmpleados { get; set; }

        public bool ListarIncapacidades { get; set; }

        public bool VerVacaciones { get; set; }

        public bool Ayuda { get; set; }

        public bool CambioContraseña { get; set; }

        public bool CerrarSeccion { get; set; }

        public bool? LoginExitoso { get; set; }

        public bool LoginFallido { get; set; }


    }
}
