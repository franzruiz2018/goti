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
    
    public partial class STG_TipoDocumento
    {
        public STG_TipoDocumento()
        {
            this.STG_Documento = new HashSet<STG_Documento>();
        }
    
        public int TipoDocumento_Id { get; set; }
        public string TipoDocumentoDescripcion { get; set; }
    
        public virtual ICollection<STG_Documento> STG_Documento { get; set; }
    }
}