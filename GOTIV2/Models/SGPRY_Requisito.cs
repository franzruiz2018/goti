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
    
    public partial class SGPRY_Requisito
    {
        public int RequisitoId { get; set; }
        public string RequisitoDescripcion { get; set; }
        public Nullable<int> PrioridadId { get; set; }
        public Nullable<int> IteracionId { get; set; }
        public Nullable<int> ProyectoId { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> AreaInstitucion_Id { get; set; }
        public Nullable<bool> RequisitoProyecto { get; set; }
        public Nullable<bool> AseguramientoCalidad { get; set; }
        public Nullable<bool> PlanificacionFuncional { get; set; }
    }
}