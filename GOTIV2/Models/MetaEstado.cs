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
    
    public partial class MetaEstado
    {
        public int MetaEstado_id { get; set; }
        public Nullable<int> Meta_id { get; set; }
        public Nullable<int> Estado_id { get; set; }
        public System.DateTime Fecha_creacion { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Meta Meta { get; set; }
    }
}
