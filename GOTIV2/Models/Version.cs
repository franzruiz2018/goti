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
    
    public partial class Version
    {
        public Version()
        {
            this.Meta = new HashSet<Meta>();
        }
    
        public int Version_id { get; set; }
        public string Version1 { get; set; }
        public Nullable<System.DateTime> Fecha_actualizacion { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
    
        public virtual ICollection<Meta> Meta { get; set; }
    }
}