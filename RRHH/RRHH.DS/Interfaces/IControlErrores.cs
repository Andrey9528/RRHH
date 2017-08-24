using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
   public interface IControlErrores
    {
        List<ControlErrores> ListarErrores();
        void InsertarAuditorias(ControlErrores controlErrores);
        
            
    }
}
