using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class ControlController : Controller
    {
        //
        // GET: /Control/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActividadesEspecialistas()
        {
            ViewBag.Especialistas = new SelectList(db.SPE_Persona.Where(x => x.AreaInstitucion_Id == 8 && x.TipoContrato == 1), "Persona_Id", "NombreCompleto");
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View();
        }

        [HttpPost]
        public ActionResult ActividadesEspecialistas(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Especialistas = new SelectList(db.SPE_Persona.Where(x => x.AreaInstitucion_Id == 8 && x.TipoContrato == 1), "Persona_Id", "NombreCompleto");

            if (Id != null)
            {
                //Actividades
               //Pendientes
                var ActividadePendientes = db.vw_Actividades_lista.ToList();
                ActividadePendientes = ActividadePendientes.Where(x => x.Fecha_ejecucion.Value.Date.Year == DateTime.Now.Year && 
                                                                        x.Fecha_ejecucion.Value.Date.Month <= DateTime.Now.Month && 
                                                                        x.Persona_Id == Id && x.Finalizado == false &&
                                                                        x.Fecha_finalizacion == null && x.Desestimado == false && x.ActividadDeInforme == false
                                                                        ).ToList();
                ViewBag.ActividadePendientes = ActividadePendientes.OrderBy(x => x.Fecha_ejecucion).ThenBy(x => x.NombreCompleto);


                //Actividades Informe
                //Pendientes
                var InformesPendientes = db.vw_Actividades_lista.ToList();
                InformesPendientes = InformesPendientes.Where(x => x.Fecha_ejecucion.Value.Date.Year == DateTime.Now.Year &&
                                                                        x.Fecha_ejecucion.Value.Date.Month <= DateTime.Now.Month &&
                                                                        x.Persona_Id == Id && x.Finalizado == false &&
                                                                        x.Fecha_finalizacion == null && x.Desestimado == false && x.ActividadDeInforme == true
                                                                        ).ToList();
                ViewBag.InformesPendientes = InformesPendientes.OrderBy(x => x.Fecha_ejecucion).ThenBy(x => x.NombreCompleto); 


                //Expedientes
                //Pendientes
                var ExpedientePendientes = db.sp_STG_Expedientes_Listar().ToList();
                ExpedientePendientes = ExpedientePendientes.Where(x => x.UsuarioIdTecnicoDesignado == Id && x.Atendido == false && x.OrigenOTI==false).ToList();
                ViewBag.ExpedientePendientes = ExpedientePendientes;                
                //CSU
                ViewBag.CSU = db.sp_CSU_Listar_Movimientos().Where(x => x.Persona_Id_EspecialistaDesignado == Id && x.Cerrado == false).ToList();
                ViewBag.CSUMantenimiento = 1;

            }
            else 
            {
                //Actividades
                //Pendientes
                var ActividadePendientes = db.vw_Actividades_lista.ToList();
                ActividadePendientes = ActividadePendientes.Where(x => x.Fecha_ejecucion.Value.Date.Year == DateTime.Now.Year && x.Fecha_ejecucion.Value.Date.Month <= DateTime.Now.Month && x.Finalizado == false && x.Fecha_finalizacion == null && x.Desestimado == false && x.ActividadDeInforme == false).ToList();
                ViewBag.ActividadePendientes = ActividadePendientes.OrderBy(x => x.Fecha_ejecucion).ThenBy(x => x.NombreCompleto);
                //Informe
                //Pendientes
                var InformesPendientes = db.vw_Actividades_lista.ToList();
                InformesPendientes = InformesPendientes.Where(x => x.Fecha_ejecucion.Value.Date.Year == DateTime.Now.Year && x.Fecha_ejecucion.Value.Date.Month <= DateTime.Now.Month && x.Finalizado == false && x.Fecha_finalizacion == null && x.Desestimado == false && x.ActividadDeInforme == true).ToList();
                ViewBag.InformesPendientes = InformesPendientes.OrderBy(x => x.Fecha_ejecucion).ThenBy(x => x.NombreCompleto);  
                //Expedientes
                //Pendientes
                var ExpedientePendientes = db.sp_STG_Expedientes_Listar().ToList();
                ExpedientePendientes = ExpedientePendientes.Where(x => x.Atendido == false && x.OrigenOTI == false).ToList();
                ViewBag.ExpedientePendientes = ExpedientePendientes;
                ViewBag.CSU = db.sp_CSU_Listar_Movimientos().Where(x => x.Cerrado == false).ToList();
            }
            return View();

        }

        public ActionResult VerEvento(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.ID = Id;
            ViewBag.Actividad = db.MetaActividad.FirstOrDefault(y => y.MetaActividad_id == Id);

            ViewBag.Meta = db.vw_Actividades_lista.FirstOrDefault(y => y.MetaActividad_id == Id);
            var x = db.sp_SGMetas_Listar_Avances(Id).ToList();
            return View(x);
        }

        public ActionResult RegistrarEvento(int? Id)
        {
           
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;            
            ViewBag.Actividad = db.MetaActividad.FirstOrDefault(x => x.MetaActividad_id == Id);
            return View();           
        }
        [HttpPost]
        public ActionResult RegistrarEvento(MetaActividadSeguimiento ActividadSeguimiento)
        {
            try
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                ActividadSeguimiento.FechaCreacion = DateTime.Now;
                db.MetaActividadSeguimiento.Add(ActividadSeguimiento);
                db.SaveChanges();
                ViewBag.Actividad_Id = ActividadSeguimiento.ActividadId;                
                TempData["Mensaje"] = "Se registro un nuevo evento...";
            }
            catch (Exception ex)
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                TempData["Mensaje"] = ex.Message;
               
            }
            return RedirectToAction("VerEvento", "Control", new { id = ActividadSeguimiento.ActividadId });
        }
    
    
    }
}