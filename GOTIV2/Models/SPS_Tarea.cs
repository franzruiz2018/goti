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
    
    public partial class SPS_Tarea
    {
        public int Tarea_Id { get; set; }
        public string Tarea_Descripcion { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<bool> Finalizado { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public Nullable<int> ObjetivoOTI_Id { get; set; }
        public bool Aprobado { get; set; }
        public Nullable<System.DateTime> FechaAprobacion { get; set; }
        public Nullable<bool> RelevanciaJefatural { get; set; }
        public string Observacion { get; set; }
    }
}