using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class MetaActividadController : Controller
    {
        gotiEntities db = new gotiEntities();
        // GET: /MetaActividad/
        public ActionResult Index(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            var result = db.MetaActividad.ToList();
            if (Id != null)
            {
                result = result.Where(x => x.Meta_id == Id).ToList();   

                Meta meta = db.Meta.FirstOrDefault(x => x.Meta_id == Id);
                ViewBag.MetaDescripcion = meta.Meta_descripcion;
                ViewBag.MetaId = Id;
            }
            return View(result.OrderBy(x=>x.Fecha_ejecucion).ToList());
        }

        public ActionResult FinalizarActividad(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;           
            ViewBag.Actividad = db.MetaActividad.FirstOrDefault(x => x.MetaActividad_id == Id);
            return View();
        }


          [HttpPost]
        public ActionResult FinalizarActividad(MetaActividad a)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                MetaActividad obeActividad = db.MetaActividad.FirstOrDefault(x => x.MetaActividad_id == a.MetaActividad_id);
                obeActividad.DocumentoDeEntrega = a.DocumentoDeEntrega;
                obeActividad.Finalizado = true;
                obeActividad.Fecha_finalizacion = DateTime.Now;
                a.Meta_id = obeActividad.Meta_id;
                db.SaveChanges();
                
                 TempData["Mensaje"] =  "La actividad se finalizó correctamente";
               
            }
            catch (Exception ex)
            {
                
                TempData["Mensaje"] = ex.Message;
            }
            return RedirectToAction("Index", "MetaActividad", new { id = a.Meta_id });

        }

          public ActionResult CerrarActividad(int? Id)
          {
              ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
              ViewBag.Actividad = db.MetaActividad.FirstOrDefault(x => x.MetaActividad_id == Id);
              return View();
          }
         [HttpPost]
          public ActionResult CerrarActividad(MetaActividad a)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                MetaActividad obeActividad = db.MetaActividad.FirstOrDefault(x => x.MetaActividad_id == a.MetaActividad_id);

                obeActividad.Finalizado = false;
                obeActividad.Fecha_finalizacion = DateTime.Now;
                obeActividad.Observacion = a.Observacion;
                a.Meta_id = obeActividad.Meta_id;
                db.SaveChanges();
                
                TempData["Mensaje"] = "La actividad se cerró correctamente";
               
            }
            catch (Exception ex)
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                TempData["Mensaje"] = ex.Message;
            }
            return RedirectToAction("Index", "MetaActividad", new { id = a.Meta_id });

        }

        public ActionResult Save(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Especialistas = new SelectList(db.SPE_Persona.Where(x => x.AreaInstitucion_Id == 8 && x.TipoContrato==1), "Persona_Id", "NombreCompleto");
            ViewBag.Id = Id;
            ViewBag.Meta = db.Meta.FirstOrDefault(x => x.Meta_id == Id);
            return View();
        }

         [HttpPost]
        public ActionResult Save(MetaActividad Actividad)
        {
            try
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                ViewBag.Especialistas = new SelectList(db.SPE_Persona.Where(x => x.AreaInstitucion_Id == 8 && x.TipoContrato == 1), "Persona_Id", "NombreCompleto");
                Actividad.Fecha_creacion = DateTime.Now;
                Actividad.Desestimado = false;
                Actividad.Finalizado = false;
                db.MetaActividad.Add(Actividad);
                db.SaveChanges();
                ViewBag.MetaId = Actividad.Meta_id;
                ViewBag.Exito = true;
                ViewBag.Mensaje = "La actividad se registró correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                ViewBag.Especialistas = new SelectList(db.SPE_Persona.Where(x => x.AreaInstitucion_Id == 8), "Persona_Id", "NombreCompleto");
                ViewBag.Exito = false;
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

         public ActionResult Resumen()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             return View(db.vw_Actividades_lista.OrderBy(x => x.Fecha_ejecucion).ThenBy(x => x.NombreCompleto).ThenBy(x => x.Finalizado).ToList());
         }

         [HttpPost]
         public ActionResult Resumen(DateTime? FecInicio)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             var result = db.vw_Actividades_lista.ToList();
             if (FecInicio != null)
             {
                 result = result.Where(x => x.Fecha_ejecucion == FecInicio).ToList();
             }
             result = result.OrderBy(x => x.Fecha_ejecucion).ThenBy(x => x.NombreCompleto).ThenBy(x => x.Finalizado).ToList();

             return View(result);
         }



    }
        
}