using GOTIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class SeguimientoTareasController : Controller
    {
        //
        // GET: /SeguimientoTareas/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8 ), "Persona_Id", "NombreCompleto");
            return View(db.sp_SPS_Listar_Tareas().ToList());
        }
         [HttpPost]
        public ActionResult Listar(int? personaid, int? FgEstado,bool FgAprobado )
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8 ), "Persona_Id", "NombreCompleto");
            var Tareas = db.sp_SPS_Listar_Tareas().Where(x => x.Aprobado == FgAprobado).ToList();
            if (personaid != null) { Tareas = Tareas.Where(x => x.PersonaId == personaid ).ToList(); }
            if (FgEstado != null)
            {
                bool Estado = false;
                if (FgEstado == 1) Estado = true;
                Tareas = Tareas.Where(x => x.Finalizado == Estado).ToList();
            }          
            return View(Tareas);
        }

         public ActionResult Registrar()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.Objetivos = new SelectList(db.SPS_ObjetivosOTI.ToList(), "ObejtivosOTI_Id", "ObjetivosOTI_Descripcion");
             ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8 && x.Activo== true ), "Persona_Id", "NombreCompleto");
             return View();
         }
         [HttpPost]
         public ActionResult Registrar(SPS_Tarea t)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             try
             {
                 t.FechaRegistro = DateTime.Now;
                 t.Finalizado = false;
                 t.Anulado = false;
                 if (t.Aprobado == true) { t.FechaAprobacion = DateTime.Now; };
                 db.SPS_Tarea.Add(t);
                 db.SaveChanges();
                 TempData["Mensaje"] = "Se registró corréctamente...";
             }
             catch (Exception ex)
             {

                 TempData["Mensaje"] = ex.Message;
             }

             return RedirectToAction("Listar", "SeguimientoTareas");
         }


         public ActionResult RegistrarAvance(int id)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.Tarea = db.sp_SPS_Listar_Tareas().FirstOrDefault(x=>x.Tarea_Id==id);
             return View();
         }
         [HttpPost]
         public ActionResult RegistrarAvance(SPS_TareaAvance t, bool finalizado)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             try
             {
                 t.FechaRegistro = DateTime.Now;             
                 t.Anulado = false;
                 db.SPS_TareaAvance.Add(t);
                 db.SaveChanges();

                 if (finalizado)
                 {
                     SPS_Tarea tarea = db.SPS_Tarea.FirstOrDefault(x => x.Tarea_Id == t.Tarea_Id);
                     tarea.Finalizado = true;                     
                     db.SaveChanges();
                 }

                 TempData["Mensaje"] = "Se registró corréctamente...";
             }
             catch (Exception ex)
             {
                 TempData["Mensaje"] = ex.Message;
             }

             return RedirectToAction("ListarAvance", "SeguimientoTareas", new { id = t.Tarea_Id });



         }

         public ActionResult RegistrarDificultad(int id)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.Tarea = db.sp_SPS_Listar_Tareas().FirstOrDefault(x => x.Tarea_Id == id);
             return View();
         }
         [HttpPost]
         public ActionResult RegistrarDificultad(SPS_TareaAvance t)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             try
             {
                 t.FechaRegistro = DateTime.Now;
                 t.Anulado = false;
                 t.Dificultad = true;
                 db.SPS_TareaAvance.Add(t);
                 db.SaveChanges();             

                 TempData["Mensaje"] = "Se registró corréctamente...";
             }
             catch (Exception ex)
             {
                 TempData["Mensaje"] = ex.Message;
             }

             return RedirectToAction("ListarAvance", "SeguimientoTareas", new { id = t.Tarea_Id });
         }


         public ActionResult ListarAvance(int id)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil; 
             ViewBag.Tarea = db.sp_SPS_Listar_Tareas().FirstOrDefault(x => x.Tarea_Id == id);
             return View(db.sp_SPS_Listar_Tareas_Eventos().Where(x => x.Tarea_Id == id).ToList());
         }

         public ActionResult AprobarTarea(int Id)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             try
             {
                 SPS_Tarea obeTarea = db.SPS_Tarea.FirstOrDefault(x => x.Tarea_Id == Id);
                 obeTarea.Aprobado = true;
                 obeTarea.FechaAprobacion = DateTime.Now;
                 db.SaveChanges();           
                 TempData["Mensaje"] = "La Tarea fue aprobado";                 
             }
             catch (Exception ex)
             {               
                 TempData["Mensaje"] = ex.Message;
             }             
             return RedirectToAction("Listar", "SeguimientoTareas");
         }

        public ActionResult ListarAutomatizacion()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;             
             return View(db.sp_SPS_Listar_Automatizacion().ToList());
         }

        public ActionResult RegistrarAutomatizacion()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Sistemas = new SelectList(db.SGRQ_Sistema.ToList(), "Sistema_Id", "Sistema_Descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarAutomatizacion(SPS_Automatizacion p)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                p.FechaRegistro = DateTime.Now;
                db.SPS_Automatizacion.Add(p);
                db.SaveChanges();
                TempData["Mensaje"] = "Se registró corréctamente...";
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = ex.Message;
            }

            return RedirectToAction("ListarAutomatizacion", "SeguimientoTareas");
        }


        public ActionResult ListarAvanceProyectos()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View(db.sp_SPS_Listar_Avance_Proyectos().ToList());
        }

        public ActionResult RegistrarAvanceProyectos()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Proyectos = new SelectList(db.SGPRY_Proyecto.ToList(), "ProyectoId", "ProyectoDescripcion");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarAvanceProyectos(SPS_AvanceProyecto p)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                p.FechaRegistro = DateTime.Now;                
                db.SPS_AvanceProyecto.Add(p);
                db.SaveChanges();
                TempData["Mensaje"] = "Se registró corréctamente...";
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = ex.Message;
            }

            return RedirectToAction("ListarAvanceProyectos", "SeguimientoTareas");
        }

        public ActionResult ListarDocumentosNormativos()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View(db.sp_SPS_Listar_DocumentosNormativos().ToList());
        }

        public ActionResult RegistrarDocumentosNormativos()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8 && x.TipoContrato == 1), "Persona_Id", "NombreCompleto");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarDocumentosNormativos(SPS_DocumentosNormativos p)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                p.FechaRegistro = DateTime.Now;
                db.SPS_DocumentosNormativos.Add(p);
                db.SaveChanges();
                TempData["Mensaje"] = "Se registró corréctamente...";
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = ex.Message;
            }

            return RedirectToAction("ListarDocumentosNormativos", "SeguimientoTareas");
        }


        public ActionResult ListarReuniones()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View(db.sp_SPS_Listar_Reuniones().ToList());
        }


        public ActionResult RegistrarReuniones()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8 ), "Persona_Id", "NombreCompleto");
            return View();
        }
        [HttpPost]        public ActionResult RegistrarReuniones(SPS_Reunion p)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                p.FechaRegistro = DateTime.Now;
                db.SPS_Reunion.Add(p);
                db.SaveChanges();
                TempData["Mensaje"] = "Se registró corréctamente...";
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = ex.Message;
            }

            return RedirectToAction("ListarReuniones", "SeguimientoTareas");
        }




	}
}