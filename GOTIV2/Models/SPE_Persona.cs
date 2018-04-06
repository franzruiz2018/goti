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
    
    public partial class SPE_Persona
    {
        public SPE_Persona()
        {
            this.MetaActividad = new HashSet<MetaActividad>();
        }
    
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
        public Nullable<bool> Activo { get; set; }
    
        public virtual ICollection<MetaActividad> MetaActividad { get; set; }
        public virtual SPE_AreaInstitucion SPE_AreaInstitucion { get; set; }
    }
}
