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
    
    public partial class sp_STG_Documentos_Listar_Result
    {
        public int Documento_Id { get; set; }
        public Nullable<int> TipoDocumento_Id { get; set; }
        public string NroDocumento { get; set; }
        public Nullable<int> UsuarioIdRemitente { get; set; }
        public string UsuarioRemitente { get; set; }
        public Nullable<int> UsuarioIdDestinatario { get; set; }
        public string UsuarioDestinatario { get; set; }
        public Nullable<System.DateTime> FechaDocumento { get; set; }
        public string Asunto { get; set; }
        public Nullable<System.DateTime> FechaRecepcion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string AreaInstitucionRemitente { get; set; }
        public string AreaInstitucionDestinatario { get; set; }
        public string TipoDocumentoDescripcion { get; set; }
    }
}
