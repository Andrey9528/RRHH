using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
   public interface IRoles
    {
        List<Roles> ListarRoles();
        Roles BuscarRoles(int id_rol);
        void InsertarRoles(Roles roles);
        void ActualizarRoles(Roles roles);
        void EliminarRoles(int id_rol);
    }
}
