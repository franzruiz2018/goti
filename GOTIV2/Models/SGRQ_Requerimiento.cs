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
    
    public partial class SGRQ_Requerimiento
    {
        public int Requerimiento_Id { get; set; }
        public string Asunto { get; set; }
        public Nullable<int> Persona_Id { get; set; }
        public Nullable<int> Tipo_Requerimiento { get; set; }
        public Nullable<int> Tipo_Sistema { get; set; }
        public Nullable<int> Sistema_Id { get; set; }
        public Nullable<int> Prioridad_Id { get; set; }
        public Nullable<int> Persona_Id_Referente_Funcional { get; set; }
        public string Correo { get; set; }
        public string Objetivo_alcanzar { get; set; }
        public string Definicion_Requerimiento { get; set; }
        public Nullable<System.DateTime> Fecha_Registro { get; set; }
        public Nullable<int> Expediente_Id { get; set; }
        public Nullable<System.DateTime> FechaReunion { get; set; }
        public Nullable<decimal> Puntaje { get; set; }
        public Nullable<bool> Aprobado { get; set; }
        public Nullable<int> Proyecto_Id { get; set; }
        public Nullable<bool> VBTecnico { get; set; }
    }
}
