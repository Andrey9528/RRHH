using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.DATA
{
    public class Feriados
    {
        [AutoIncrement]
        public int IdFeriado { get; set; }
        public DateTime Fecha { get; set; }
        public string Festividad { get; set; }
    }
}
