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
    
    public partial class SGP_CierreDigitacion
    {
        public int CierreID { get; set; }
        public Nullable<int> EstablecimientoId { get; set; }
        public Nullable<int> PersonalAsignado { get; set; }
        public Nullable<int> CantidadAtenciones { get; set; }
        public Nullable<int> CantidadAtencionesMigradas { get; set; }
        public Nullable<System.DateTime> FechaCierre { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaMigracion { get; set; }
    }
}
