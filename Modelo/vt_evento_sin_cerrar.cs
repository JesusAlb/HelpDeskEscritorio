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
    
    public partial class vt_evento_sin_cerrar
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha_solicitud { get; set; }
        public Nullable<System.DateTime> fecha_cierre { get; set; }
        public Nullable<System.DateTime> hora_inicial { get; set; }
        public Nullable<System.DateTime> hora_final { get; set; }
        public int estatus_evento { get; set; }
        public string solicitante { get; set; }
        public int idsolicitante { get; set; }
        public string soporte { get; set; }
        public string apoyo { get; set; }
        public string tipo { get; set; }
        public string lugar { get; set; }
        public int asistencia { get; set; }
        public string acomodo { get; set; }
        public System.DateTime fecha_realizacion { get; set; }
    }
}
