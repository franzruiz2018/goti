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
    
    public partial class sp_CSU_Listar_Movimientos_Result
    {
        public int MovimientoCSU_Id { get; set; }
        public Nullable<int> CatalogoServicio_Id { get; set; }
        public string CatalogoServicio_Descripcion { get; set; }
        public int Persona_Id { get; set; }
        public string AreaInstitucionAbreviaturaUsuario { get; set; }
        public string AsuntoDeLaAtencion_Usuario { get; set; }
        public string AsuntoDeLaAtencion_Especilista { get; set; }
        public string DescripcionDeLaAtencion_Usuario { get; set; }
        public string DescripcionDeLaAtencion_Especialista { get; set; }
        public Nullable<int> Persona_Id_EspecialistaDesignado { get; set; }
        public string AreaInstitucionAbreviaturaEspecialista { get; set; }
        public Nullable<System.DateTime> FechaInicioDeAtencion { get; set; }
        public Nullable<System.DateTime> FechaCierreDeAtencion { get; set; }
        public Nullable<bool> Cerrado { get; set; }
        public string DecripcionEnCierre { get; set; }
        public Nullable<int> TiempoUtilizado { get; set; }
        public string Entregable { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> TipoDeAtencion_Id_Padre { get; set; }
        public string TipoDeAtencion_Descripcion_Padre { get; set; }
        public int TipoDeAtencion_Id { get; set; }
        public string TipoDeAtencion_Descripcion { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string Especialista { get; set; }
        public int AreaInstitucion_Id_Usuario { get; set; }
        public Nullable<int> AreaInstitucion_Id_Especialista { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<bool> Coyuntural { get; set; }
        public string CoyunturalObservacion { get; set; }
    }
}