//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GOTIV2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MetaActividad
    {
        public int MetaActividad_id { get; set; }
        public string MetaActividad_descripcion { get; set; }
        public Nullable<System.DateTime> Fecha_ejecucion { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public Nullable<int> Meta_id { get; set; }
        public Nullable<bool> Finalizado { get; set; }
        public Nullable<System.DateTime> Fecha_finalizacion { get; set; }
        public string DocumentoDeEntrega { get; set; }
        public Nullable<int> EspecialistaDesignado { get; set; }
        public string Observacion { get; set; }
        public Nullable<bool> Desestimado { get; set; }
        public Nullable<bool> ActividadDeInforme { get; set; }
        public Nullable<bool> Reprogramado { get; set; }
        public Nullable<int> ActividadReprogramada { get; set; }
    
        public virtual Meta Meta { get; set; }
        public virtual SPE_Persona SPE_Persona { get; set; }
    }
}
