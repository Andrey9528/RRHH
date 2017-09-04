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
        //[Alias("Departamento")]
        public string Nombre { get; set; }
        //[Alias("Correo")]
        public string EmailJefeDpto { get; set; }
        //[Alias("Jefe")]
        public string NombreJefe { get; set; }
        public bool? Estado { get; set; }
    }
}
