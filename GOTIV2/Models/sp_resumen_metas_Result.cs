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
    
    public partial class sp_resumen_metas_Result
    {
        public Nullable<long> Id { get; set; }
        public int Meta_id { get; set; }
        public string Area_Descripción { get; set; }
        public string SubArea_Descripción { get; set; }
        public string Meta_descripcion { get; set; }
        public string Estado_descripcion { get; set; }
        public int TotalActividadesProyectados { get; set; }
        public int TotalActividadesFinalizados { get; set; }
        public Nullable<int> PorcentajeAvance { get; set; }
        public Nullable<System.DateTime> FechaInicioActividades { get; set; }
        public Nullable<System.DateTime> FechaFinActividades { get; set; }
        public Nullable<bool> POI { get; set; }
        public Nullable<System.DateTime> Fecha_ejecucion { get; set; }
        public Nullable<int> SubArea_id { get; set; }
        public Nullable<int> area_id { get; set; }
    }
}
