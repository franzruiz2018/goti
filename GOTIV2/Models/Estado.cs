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
    
    public partial class Estado
    {
        public Estado()
        {
            this.MetaEstado = new HashSet<MetaEstado>();
        }
    
        public int Estado_id { get; set; }
        public string Estado_descripcion { get; set; }
    
        public virtual ICollection<MetaEstado> MetaEstado { get; set; }
    }
}
