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
    
    public partial class sp_SGPRY_listar_actividades_Result
    {
        public int IteracionId { get; set; }
        public string IteracionDescripcion { get; set; }
        public int RequisitoId { get; set; }
        public string RequisitoDescripcion { get; set; }
        public int Actividad_Id { get; set; }
        public string ActividadDescripcion { get; set; }
        public Nullable<int> HorasRequeridas { get; set; }
        public Nullable<System.DateTime> FechaInicio_SinHolgura { get; set; }
        public Nullable<System.DateTime> FechaFin_SinHolgura { get; set; }
        public Nullable<System.DateTime> FechaInicio_ConHolgura { get; set; }
        public Nullable<System.DateTime> FechaFin_ConHolgura { get; set; }
        public Nullable<bool> Analisis { get; set; }
        public Nullable<System.DateTime> FechaCierreAnalisis { get; set; }
        public Nullable<bool> Desarrollo { get; set; }
        public Nullable<System.DateTime> FechaCierreDesarrollo { get; set; }
        public Nullable<bool> ControlCalidad { get; set; }
        public Nullable<System.DateTime> FechaCierreControlCalidad { get; set; }
        public string EstadoScrumDescripcion { get; set; }
        public int ProyectoId { get; set; }
        public Nullable<int> EstadoScrumId { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> RequisitoProyecto { get; set; }
        public Nullable<bool> AseguramientoCalidad { get; set; }
        public Nullable<bool> PlanificacionFuncional { get; set; }
    }
}
