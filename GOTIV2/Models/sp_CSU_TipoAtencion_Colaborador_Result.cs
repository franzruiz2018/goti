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
    
    public partial class sp_CSU_TipoAtencion_Colaborador_Result
    {
        public int TipoDeAtencion_Colaborador_Id { get; set; }
        public Nullable<int> TipoDeAtencion_Id { get; set; }
        public Nullable<int> PersonaColaborador_Id { get; set; }
        public int Persona_Id { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Apellidomaterno { get; set; }
        public string Nombres { get; set; }
        public Nullable<int> TipoDocumento { get; set; }
        public Nullable<int> NumeroDocumento { get; set; }
        public string Cargo { get; set; }
        public Nullable<int> AreaInstitucion_Id { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<bool> Jefe { get; set; }
        public string NombreCorto { get; set; }
        public Nullable<int> TipoContrato { get; set; }
    }
}