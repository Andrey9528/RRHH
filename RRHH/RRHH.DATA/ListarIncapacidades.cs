using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RRHH.DATA
{
  public  class ListarIncapacidades
    {
        public int idIncapacidad { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_finalizacion { get; set; }
        public int CantidadDias { get; set; }
        public string TipoIncapacidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEmision { get; set; }
        public string CentroEmisor { get; set; }
        public string NombreDoctor { get; set; }
    }
}
