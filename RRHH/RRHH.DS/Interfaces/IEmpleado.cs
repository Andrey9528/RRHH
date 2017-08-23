using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
    public interface IEmpleado
    {
        List<Empleado> ListarEmpleados();
        Empleado BuscarEmpleados(string Cedula);
        void InsertarEmpleados(Empleado empleado);
        void ActualizarEmpleados(Empleado empleado);
        void EliminarEmpleados(string Cedula);
        bool ExisteEmpleado(string Correo);
        Empleado BuscarEmpleadoCorreo(string Correo);
    }
}
