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
    
    public partial class SubArea
    {
        public SubArea()
        {
            this.Meta = new HashSet<Meta>();
        }
    
        public int SubArea_id { get; set; }
        public string SubArea_Descripción { get; set; }
        public Nullable<int> Area_id { get; set; }
        public string SubArea_Abreviatura { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual ICollection<Meta> Meta { get; set; }
    }
}