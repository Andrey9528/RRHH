using RRHH.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH.DS.Interfaces
{
    public interface INotificacionCorreoJefe
    {
        NotificacionCorreoJefe BuscarEmpleados(string Cedula);
        List<NotificacionCorreoJefe> CorreoJefe (string Cedula);
    }
}
