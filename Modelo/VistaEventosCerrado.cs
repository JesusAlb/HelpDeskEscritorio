//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpDeskEscritorio.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class VistaEventosCerrado
    {
        public int idEvento { get; set; }
        public string descripcion { get; set; }
        public string solicitante { get; set; }
        public string responsable { get; set; }
        public string apoyo { get; set; }
        public Nullable<System.DateTime> fecha_Sol { get; set; }
        public Nullable<int> asistencia_aprox { get; set; }
        public string tipo_evento { get; set; }
        public string acomodo { get; set; }
        public Nullable<System.DateTime> horaIn { get; set; }
        public Nullable<System.DateTime> horaFn { get; set; }
        public Nullable<System.DateTime> fecha_cierre { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public int idSolicitante { get; set; }
        public int idResponsable { get; set; }
        public int idApoyo { get; set; }
        public string lugar { get; set; }
        public string observaciones { get; set; }
        public string titulo { get; set; }
        public bool statusCal_Servicio { get; set; }
        public int idCalidad_Servicio { get; set; }
        public string observacionesServicio { get; set; }
        public Nullable<double> promedioCalidad { get; set; }
    }
}
