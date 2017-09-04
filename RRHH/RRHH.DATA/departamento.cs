using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace RRHH.DATA
{
    public class departamento
    {
        [AutoIncrement]

        public int IdDepartamento { get; set; }
        
        public string Nombre { get; set; }
        public string EmailJefeDpto { get; set; }
        public string NombreJefe { get; set; }
    }
}
