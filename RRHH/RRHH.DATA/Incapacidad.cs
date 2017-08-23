using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.DATA
{
    public class Incapacidad
    {
        public int IdIncapacidad { get; set; }

        public string Cedula { get; set; }

        public int CantidadDias { get; set; }

        public string TipoIncapacidad { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaEmision { get; set; }

        public string CentroEmisor { get; set; }

        public char NombreDoctor { get; set; }

        public bool Estado { get; set; }
    }
}
