﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class gotiEntities : DbContext
    {
        public gotiEntities()
            : base("name=gotiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Area> Area { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Meta> Meta { get; set; }
        public DbSet<MetaActividad> MetaActividad { get; set; }
        public DbSet<MetaEstado> MetaEstado { get; set; }
        public DbSet<SubArea> SubArea { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Version> Version { get; set; }
        public DbSet<vw_resumen_metas> vw_resumen_metas { get; set; }
        public DbSet<vw_resumen_avance_actividad> vw_resumen_avance_actividad { get; set; }
        public DbSet<vw_Actividades_por_area> vw_Actividades_por_area { get; set; }
        public DbSet<vw_Actividades_Segun_POI> vw_Actividades_Segun_POI { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<vw_Actividades_lista> vw_Actividades_lista { get; set; }
        public DbSet<SPE_AreaInstitucion> SPE_AreaInstitucion { get; set; }
        public DbSet<STG_Documento> STG_Documento { get; set; }
        public DbSet<STG_Expediente> STG_Expediente { get; set; }
        public DbSet<STG_TipoDocumento> STG_TipoDocumento { get; set; }
        public DbSet<SGP_Trama> SGP_Trama { get; set; }
        public DbSet<SGPRY_Actividad> SGPRY_Actividad { get; set; }
        public DbSet<SGPRY_Actividad_EstadoScrum> SGPRY_Actividad_EstadoScrum { get; set; }
        public DbSet<SGPRY_EstadoScrum> SGPRY_EstadoScrum { get; set; }
        public DbSet<SGPRY_Iteracion> SGPRY_Iteracion { get; set; }
        public DbSet<SGPRY_Proyecto> SGPRY_Proyecto { get; set; }
        public DbSet<SGPRY_Requisito> SGPRY_Requisito { get; set; }
        public DbSet<SGPRY_Prioridad> SGPRY_Prioridad { get; set; }
        public DbSet<MetaActividadSeguimiento> MetaActividadSeguimiento { get; set; }
        public DbSet<CSU_MedioDeSolicitud> CSU_MedioDeSolicitud { get; set; }
        public DbSet<CSU_TipoDeAtencion> CSU_TipoDeAtencion { get; set; }
        public DbSet<CSU_MovimientoCSU> CSU_MovimientoCSU { get; set; }
        public DbSet<CSU_CatalogoDeServicio> CSU_CatalogoDeServicio { get; set; }
        public DbSet<CSU_TipoDeAtencion_Colaborador> CSU_TipoDeAtencion_Colaborador { get; set; }
        public DbSet<SGP_CierreDigitacion> SGP_CierreDigitacion { get; set; }
        public DbSet<SPE_ServicioTercero> SPE_ServicioTercero { get; set; }
        public DbSet<SGRQ_Sistema> SGRQ_Sistema { get; set; }
        public DbSet<SGRQ_TipoRequerimiento> SGRQ_TipoRequerimiento { get; set; }
        public DbSet<SGRQ_TipoSistema> SGRQ_TipoSistema { get; set; }
        public DbSet<SGRQ_Requerimiento> SGRQ_Requerimiento { get; set; }
        public DbSet<SPS_ObjetivosOTI> SPS_ObjetivosOTI { get; set; }
        public DbSet<SPS_Tarea> SPS_Tarea { get; set; }
        public DbSet<SPS_TareaAvance> SPS_TareaAvance { get; set; }
        public DbSet<SPS_Automatizacion> SPS_Automatizacion { get; set; }
        public DbSet<SPS_DocumentosNormativos> SPS_DocumentosNormativos { get; set; }
        public DbSet<SPS_AvanceProyecto> SPS_AvanceProyecto { get; set; }
        public DbSet<SPS_Reunion> SPS_Reunion { get; set; }
        public DbSet<SPE_Persona> SPE_Persona { get; set; }
    
        public virtual ObjectResult<sp_resumen_metas_Result> sp_resumen_metas(Nullable<System.DateTime> fechaEjecucion)
        {
            var fechaEjecucionParameter = fechaEjecucion.HasValue ?
                new ObjectParameter("FechaEjecucion", fechaEjecucion) :
                new ObjectParameter("FechaEjecucion", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_resumen_metas_Result>("sp_resumen_metas", fechaEjecucionParameter);
        }
    
        public virtual ObjectResult<sp_STG_Documentos_Listar_Result> sp_STG_Documentos_Listar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_STG_Documentos_Listar_Result>("sp_STG_Documentos_Listar");
        }
    
        public virtual ObjectResult<sp_STG_Expedientes_Listar_Result> sp_STG_Expedientes_Listar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_STG_Expedientes_Listar_Result>("sp_STG_Expedientes_Listar");
        }
    
        public virtual ObjectResult<sp_STG_Expedientes_Por_Especialista_Result> sp_STG_Expedientes_Por_Especialista()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_STG_Expedientes_Por_Especialista_Result>("sp_STG_Expedientes_Por_Especialista");
        }
    
        public virtual ObjectResult<sp_SGP_ResumenTramas_Result> sp_SGP_ResumenTramas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGP_ResumenTramas_Result>("sp_SGP_ResumenTramas");
        }
    
        public virtual ObjectResult<sp_SGPRY_listar_actividades_Result> sp_SGPRY_listar_actividades(Nullable<int> proyecto)
        {
            var proyectoParameter = proyecto.HasValue ?
                new ObjectParameter("proyecto", proyecto) :
                new ObjectParameter("proyecto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGPRY_listar_actividades_Result>("sp_SGPRY_listar_actividades", proyectoParameter);
        }
    
        public virtual ObjectResult<sp_SGPRY_listar_iteracion_Result> sp_SGPRY_listar_iteracion(Nullable<int> proyecto)
        {
            var proyectoParameter = proyecto.HasValue ?
                new ObjectParameter("proyecto", proyecto) :
                new ObjectParameter("proyecto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGPRY_listar_iteracion_Result>("sp_SGPRY_listar_iteracion", proyectoParameter);
        }
    
        public virtual ObjectResult<sp_SGPRY_listar_requisitos_Result> sp_SGPRY_listar_requisitos(Nullable<int> proyecto)
        {
            var proyectoParameter = proyecto.HasValue ?
                new ObjectParameter("proyecto", proyecto) :
                new ObjectParameter("proyecto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGPRY_listar_requisitos_Result>("sp_SGPRY_listar_requisitos", proyectoParameter);
        }
    
        public virtual ObjectResult<sp_SGPRY_listar_proyectos_Result> sp_SGPRY_listar_proyectos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGPRY_listar_proyectos_Result>("sp_SGPRY_listar_proyectos");
        }
    
        public virtual ObjectResult<sp_SGMetas_Listar_Avances_Result> sp_SGMetas_Listar_Avances(Nullable<int> actividad)
        {
            var actividadParameter = actividad.HasValue ?
                new ObjectParameter("actividad", actividad) :
                new ObjectParameter("actividad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGMetas_Listar_Avances_Result>("sp_SGMetas_Listar_Avances", actividadParameter);
        }
    
        public virtual ObjectResult<sp_CSU_Listar_Movimientos_Result> sp_CSU_Listar_Movimientos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Listar_Movimientos_Result>("sp_CSU_Listar_Movimientos");
        }
    
        public virtual ObjectResult<sp_CSU_Atenciones_por_Catalogo_Result> sp_CSU_Atenciones_por_Catalogo(Nullable<int> anio)
        {
            var anioParameter = anio.HasValue ?
                new ObjectParameter("anio", anio) :
                new ObjectParameter("anio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Atenciones_por_Catalogo_Result>("sp_CSU_Atenciones_por_Catalogo", anioParameter);
        }
    
        public virtual ObjectResult<sp_CSU_Atenciones_por_Tipo_Result> sp_CSU_Atenciones_por_Tipo(Nullable<int> anio)
        {
            var anioParameter = anio.HasValue ?
                new ObjectParameter("anio", anio) :
                new ObjectParameter("anio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Atenciones_por_Tipo_Result>("sp_CSU_Atenciones_por_Tipo", anioParameter);
        }
    
        public virtual ObjectResult<sp_CSU_Rendimiento_Especialista_Result> sp_CSU_Rendimiento_Especialista(Nullable<int> anio)
        {
            var anioParameter = anio.HasValue ?
                new ObjectParameter("anio", anio) :
                new ObjectParameter("anio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Rendimiento_Especialista_Result>("sp_CSU_Rendimiento_Especialista", anioParameter);
        }
    
        public virtual ObjectResult<sp_CSU_TipoAtencion_Colaborador_Result> sp_CSU_TipoAtencion_Colaborador()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_TipoAtencion_Colaborador_Result>("sp_CSU_TipoAtencion_Colaborador");
        }
    
        public virtual ObjectResult<sp_CSU_Atenciones_por_Especialista_MesActual_Result> sp_CSU_Atenciones_por_Especialista_MesActual()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Atenciones_por_Especialista_MesActual_Result>("sp_CSU_Atenciones_por_Especialista_MesActual");
        }
    
        public virtual ObjectResult<sp_Maestro_Establecimiento_Convenio_Result> sp_Maestro_Establecimiento_Convenio()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Maestro_Establecimiento_Convenio_Result>("sp_Maestro_Establecimiento_Convenio");
        }
    
        public virtual ObjectResult<sp_SGP_Cierre_Digitacion_Lista_Result> sp_SGP_Cierre_Digitacion_Lista()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGP_Cierre_Digitacion_Lista_Result>("sp_SGP_Cierre_Digitacion_Lista");
        }
    
        public virtual ObjectResult<sp_SGP_AtencionesCerradas_por_Ipress_Establecimiento_Result> sp_SGP_AtencionesCerradas_por_Ipress_Establecimiento()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGP_AtencionesCerradas_por_Ipress_Establecimiento_Result>("sp_SGP_AtencionesCerradas_por_Ipress_Establecimiento");
        }
    
        public virtual int sp_SGR_Actividades_por_Especialista(string año)
        {
            var añoParameter = año != null ?
                new ObjectParameter("año", año) :
                new ObjectParameter("año", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_SGR_Actividades_por_Especialista", añoParameter);
        }
    
        public virtual ObjectResult<sp_SGP_Total_AtencionesCerradas_por_Ipress_Establecimiento_Result> sp_SGP_Total_AtencionesCerradas_por_Ipress_Establecimiento()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGP_Total_AtencionesCerradas_por_Ipress_Establecimiento_Result>("sp_SGP_Total_AtencionesCerradas_por_Ipress_Establecimiento");
        }
    
        public virtual ObjectResult<sp_CSU_Total_Atenciones_por_Especialista_MesActual_Result> sp_CSU_Total_Atenciones_por_Especialista_MesActual()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Total_Atenciones_por_Especialista_MesActual_Result>("sp_CSU_Total_Atenciones_por_Especialista_MesActual");
        }
    
        public virtual ObjectResult<sp_CSU_Total_Atenciones_por_TipoDeAtencion_Result> sp_CSU_Total_Atenciones_por_TipoDeAtencion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Total_Atenciones_por_TipoDeAtencion_Result>("sp_CSU_Total_Atenciones_por_TipoDeAtencion");
        }
    
        public virtual ObjectResult<sp_CSU_Resumen_Result> sp_CSU_Resumen()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CSU_Resumen_Result>("sp_CSU_Resumen");
        }
    
        public virtual ObjectResult<sp_SPE_ServicioTercero_Listar_Result> sp_SPE_ServicioTercero_Listar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SPE_ServicioTercero_Listar_Result>("sp_SPE_ServicioTercero_Listar");
        }
    
        public virtual ObjectResult<sp_SGRQ_Requerimiento_Lista_Result> sp_SGRQ_Requerimiento_Lista()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SGRQ_Requerimiento_Lista_Result>("sp_SGRQ_Requerimiento_Lista");
        }
    
        public virtual ObjectResult<sp_SPS_Listar_Tareas_Result> sp_SPS_Listar_Tareas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SPS_Listar_Tareas_Result>("sp_SPS_Listar_Tareas");
        }
    
        public virtual ObjectResult<sp_SPS_Listar_Tareas_Eventos_Result2> sp_SPS_Listar_Tareas_Eventos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SPS_Listar_Tareas_Eventos_Result2>("sp_SPS_Listar_Tareas_Eventos");
        }
    
        public virtual ObjectResult<sp_SPS_Listar_Automatizacion_Result> sp_SPS_Listar_Automatizacion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SPS_Listar_Automatizacion_Result>("sp_SPS_Listar_Automatizacion");
        }
    
        public virtual ObjectResult<sp_SPS_Listar_Avance_Proyectos_Result> sp_SPS_Listar_Avance_Proyectos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SPS_Listar_Avance_Proyectos_Result>("sp_SPS_Listar_Avance_Proyectos");
        }
    
        public virtual ObjectResult<sp_SPS_Listar_DocumentosNormativos_Result> sp_SPS_Listar_DocumentosNormativos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SPS_Listar_DocumentosNormativos_Result>("sp_SPS_Listar_DocumentosNormativos");
        }
    
        public virtual ObjectResult<sp_SPS_Listar_Reuniones_Result> sp_SPS_Listar_Reuniones()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SPS_Listar_Reuniones_Result>("sp_SPS_Listar_Reuniones");
        }
    }
}
