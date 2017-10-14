using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace RRHH.UI
{
    public class Singleton
    {
        public static DS.Interfaces.IEmpleado OpEmpleados = new DS.Metodos.MEmpleado();
        public static DS.Interfaces.IControlAuditoriasAdmin opaudi = new DS.Metodos.MControlAuditoriasAdmin();
        public static DS.Interfaces.IControlAuditoriasEmpleado opAudiEmple = new DS.Metodos.MControlAuditoriasEmpleado();
        public static DS.Interfaces.IControlAuditoriasJefe opAudiJefe = new DS.Metodos.MControlAuditoriasJefe();
        public static DS.Interfaces.IControlErrores opErrores = new DS.Metodos.MControlErrores();
        public static DS.Interfaces.Idepartamento opdepartamento = new DS.Metodos.MDepartamento();
        public static DS.Interfaces.IIncapacidad opIncapacidad = new DS.Metodos.MIncapacidad();
        public static DS.Interfaces.IRoles oproles = new DS.Metodos.MRoles();
        public static DS.Interfaces.ISolicitudVacaciones opsolicitud = new DS.Metodos.MSolicitudVacaciones();
        public static DS.Interfaces.INotificacionCorreoJefe opNotificacion = new DS.Metodos.MNotificacionCorreoJefe();
        public static DS.Interfaces.IRangoFechasVacaciones OpRangoFechas = new DS.Metodos.MRangoFechasVacaciones();
    }
}