using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace RRHH.UI
{
    public class Singleton
    {
        public static DS.Interfaces.IEmpleado OpEmpleados = new DS.Metodos.MEmpleado();
        public static DS.Interfaces.IControlAuditorias opaudi = new DS.Metodos.MControlAuditorias();
        public static DS.Interfaces.IControlErrores opErrores = new DS.Metodos.MControlErrores();
        public static DS.Interfaces.Idepartamento opdepartamento = new DS.Metodos.MDepartamento();
        public static DS.Interfaces.IIncapacidad opIncapacidad = new DS.Metodos.MIncapacidad();
        public static DS.Interfaces.IRoles oproles = new DS.Metodos.MRoles();
        public static DS.Interfaces.ISolicitudVacaciones opsolicitud = new DS.Metodos.MSolicitudVacaciones();
        public static DS.Interfaces.INotificacionCorreoJefe opNotificacion = new DS.Metodos.MNotificacionCorreoJefe();
    }
}