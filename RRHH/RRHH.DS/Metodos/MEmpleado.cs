using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.DATA;
using RRHH.DS.Interfaces;
using ServiceStack.OrmLite;
using System.Data;

namespace RRHH.DS.Metodos
{
    public class MEmpleado : IEmpleado
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MEmpleado()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }


        public void ActualizarEmpleados(Empleado empleado)
        {
            _db.Update(empleado);
        }

        public Empleado BuscarEmpleadoCorreo(string correo)
        {
            return _db.Select<Empleado>(x => x.Correo == correo).FirstOrDefault();
        }

        public Empleado BuscarEmpleados(string Cedula)
        {
            return _db.Select<Empleado>(x => x.Cedula == Cedula).FirstOrDefault();
        }

        public void EliminarEmpleados(string Cedula)
        {
            _db.Delete<Empleado>(x => x.Cedula == Cedula);
        }

        public bool ExisteEmpleado(string Correo)
        {
            try
            {
                DATA.Empleado Us = _db.Select<DATA.Empleado>(x => x.Correo == Correo).Where(x => x.Estado == true).FirstOrDefault();

                if (Us.Correo == Correo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public void InsertarEmpleados(Empleado empleado)
        {
            _db.Insert(empleado);
        }

        public List<Empleado> ListarEmpleados()
        {
            return _db.Select<Empleado>();
        }
    }
}
