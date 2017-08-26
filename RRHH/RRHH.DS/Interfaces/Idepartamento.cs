using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;

namespace RRHH.DS.Interfaces
{
   public interface Idepartamento
    {
        List<departamento> ListarDepartamentos();
        departamento BuscarDepartamentos(int IdDepartemento);
        departamento BuscarDepartamentosPorNombre(string Departemento);

        void InsertarDepartamentos(departamento departamento);
        void ActualizarDepartamentos(departamento departamento);
        void EliminarDepartamentos(int IdDepartamento);
    }
}
