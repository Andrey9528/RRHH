using ServiceStack.DataAnnotations;
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
        [Alias("Inicia")]
        public DateTime Fecha_Inicio { get; set; }
        [Alias("Finaliza")]
        public DateTime Fecha_finalizacion { get; set; }
        [Alias("Cantidad días")]
        public int CantidadDias { get; set; }
        [Alias("Tipo")]
        public string TipoIncapacidad { get; set; }
        [Alias("Descripción")]
        public string Descripcion { get; set; }
        [Alias("Fecha de emisión")]
        public DateTime FechaEmision { get; set; }
        [Alias("Emisor")]
        public string CentroEmisor { get; set; }
        [Alias("Doctor")]
        public string NombreDoctor { get; set; }
    }
}
