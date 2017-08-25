﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ServiceStack.OrmLite;
using RRHH.DS.Interfaces;
using RRHH.DATA;

namespace RRHH.DS.Metodos
{
    public class MIncapacidad : IIncapacidad
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;
        public MIncapacidad()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.Conexion, SqlServerDialect.Provider);
            _db = _conexion.Open();
        }
        public void ActualizarIncapacidad(Incapacidad incapacidad)
        {
            _db.Update(incapacidad);
        }

        public Incapacidad BuscarIncapacidad(int IdIncapacidad)
        {
            return _db.Select<Incapacidad>(x => x.IdIncapacidad == IdIncapacidad).FirstOrDefault();
        }

        public void EliminarIncapacidad(int idIncapacidad)
        {
            _db.Delete<Incapacidad>(x => x.IdIncapacidad == idIncapacidad);
        }

        public void InsertarIncapacidad(Incapacidad incapacidad)
        {
            _db.Insert(incapacidad);
        }

        public List<Incapacidad> ListarIncapacidades()
        {
            return _db.Select<Incapacidad>();
        }
    }
}