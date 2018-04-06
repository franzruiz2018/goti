using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class ProyectoController : Controller
    {
        gotiEntities db = new gotiEntities();
        // GET: /Proyecto/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResumenProyecto(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Proyecto = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == Id);
            ViewBag.Requisitos = db.sp_SGPRY_listar_requisitos(Id).OrderBy(x => x.IteracionId).ToList();
            ViewBag.Iteracion = db.sp_SGPRY_listar_iteracion(Id);
            ViewBag.Actividad = db.sp_SGPRY_listar_actividades(Id).OrderBy(x => x.FechaFin_SinHolgura).ToList();

            var iteracion = db.sp_SGPRY_listar_iteracion(Id);
            int? horasProgramadas = 0;
            int? HorasEjecutados = 0;
            int? avance = 0;
            foreach (var i in iteracion)
            {
                horasProgramadas = horasProgramadas + i.HorasRequeridas;
                HorasEjecutados = HorasEjecutados + i.HorasEjecutadas;
            }
            avance = HorasEjecutados * 100 / horasProgramadas;
            ViewBag.Avance = avance;

            return View();
        }

        public ActionResult ResumenProyectoCliente(int? Id)
        {
            
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Proyecto = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == Id);
            ViewBag.Requisitos = db.sp_SGPRY_listar_requisitos(Id).Where(x => x.RequisitoProyecto == false).OrderBy(x => x.IteracionId).ToList();
            ViewBag.RequisitosProyecto = db.sp_SGPRY_listar_requisitos(Id).Where(x => x.RequisitoProyecto == true && x.AseguramientoCalidad == false).OrderBy(x => x.IteracionId).ToList();
            ViewBag.Iteracion = db.sp_SGPRY_listar_iteracion(Id);
            var iteracion = db.sp_SGPRY_listar_iteracion(Id);
            int? horasProgramadas=0;
            int? HorasEjecutados=0;
            int? avance = 0;
            foreach(var i in iteracion)
             {
                 horasProgramadas = horasProgramadas + i.HorasRequeridas;
                 HorasEjecutados = HorasEjecutados + i.HorasEjecutadas;
            }
            avance = HorasEjecutados * 100 / horasProgramadas;
            ViewBag.Avance = avance;
            ViewBag.Actividad = db.sp_SGPRY_listar_actividades(Id).ToList();
            return View();
        }

        //Mantenimiento Actividades del Proyecto
        ////////////////////////////////////////
        public ActionResult ActualizarAvanceEquipo(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Proyecto = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == Id);
            var Actividad = db.sp_SGPRY_listar_actividades(Id).ToList();
            return View(Actividad);
        }

        public ActionResult CerrarAnalisis(int? Id, int? proyecto_id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                SGPRY_Actividad obeActividad = db.SGPRY_Actividad.FirstOrDefault(x => x.Actividad_Id == Id);

                obeActividad.Analisis = true;
                obeActividad.FechaCierreAnalisis = DateTime.Now;
                db.SaveChanges();
                db.SGPRY_Actividad_EstadoScrum.Add(new SGPRY_Actividad_EstadoScrum { Actividad_Id = Id, EstadoScrumId = 2, FechaCreacion = DateTime.Now });
                db.SaveChanges();
                TempData["Mensaje"] = "La actividad de análisis se finalizó correctamente";
                TempData["Proyecto"] = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == proyecto_id).ProyectoDescripcion;
            }
            catch (Exception ex)
            {
                TempData["Proyecto"] = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == proyecto_id).ProyectoDescripcion;
                TempData["Mensaje"] =  ex.Message;
            }


            return RedirectToAction("ActualizarAvanceEquipo", "Proyecto", new { id = proyecto_id });

        }

        public ActionResult CerrarDesarrollo(int? Id, int? proyecto_id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                SGPRY_Actividad obeActividad = db.SGPRY_Actividad.FirstOrDefault(x => x.Actividad_Id == Id);

                obeActividad.Desarrollo = true;
                obeActividad.FechaCierreDesarrollo = DateTime.Now;
                db.SaveChanges();

                db.SGPRY_Actividad_EstadoScrum.Add(new SGPRY_Actividad_EstadoScrum { Actividad_Id = Id, EstadoScrumId = 3, FechaCreacion = DateTime.Now });
                db.SaveChanges();

                db.SGPRY_Actividad_EstadoScrum.Add(new SGPRY_Actividad_EstadoScrum { Actividad_Id = Id, EstadoScrumId = 4, FechaCreacion = DateTime.Now });
                db.SaveChanges();      

                TempData["Mensaje"] = "La actividad de desarrollo se finalizó correctamente";
                TempData["Proyecto"] = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == proyecto_id).ProyectoDescripcion;
            }
            catch (Exception ex)
            {
                TempData["Proyecto"] = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == proyecto_id).ProyectoDescripcion;
                TempData["Mensaje"] = ex.Message;
            }
            return RedirectToAction("ActualizarAvanceEquipo", "Proyecto", new { id = proyecto_id });

        }
        public ActionResult CerrarCalidad(int? Id,int? proyecto_id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                SGPRY_Actividad obeActividad = db.SGPRY_Actividad.FirstOrDefault(x => x.Actividad_Id == Id);

                obeActividad.ControlCalidad = true;
                obeActividad.FechaCierreControlCalidad = DateTime.Now;
                db.SaveChanges();
                db.SGPRY_Actividad_EstadoScrum.Add(new SGPRY_Actividad_EstadoScrum { Actividad_Id = Id, EstadoScrumId = 4, FechaCreacion = DateTime.Now });
                db.SaveChanges();               
                TempData["Mensaje"] = "La actividad se finalizó correctamente";              
                TempData["Proyecto"] = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == proyecto_id).ProyectoDescripcion;
                
            }
            catch (Exception ex)
            {
                TempData["Proyecto"] = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == proyecto_id).ProyectoDescripcion;
                TempData["Mensaje"] = ex.Message;
            }
            return RedirectToAction("ActualizarAvanceEquipo", "Proyecto", new { id = proyecto_id });

        }
        
        //Mantenimiento Proyecto

        public ActionResult ListarProyectos()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View(db.sp_SGPRY_listar_proyectos().ToList());
        }

        [HttpPost]
        public ActionResult ListarProyectos(int? FgEstado)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            var resultado = db.sp_SGPRY_listar_proyectos().ToList();

            if (FgEstado != null) 
            {
                if (FgEstado == 1)
                {
                    resultado = db.sp_SGPRY_listar_proyectos().Where(x => x.Avance == 100).ToList();
                }
                else
                {
                    resultado = db.sp_SGPRY_listar_proyectos().Where(x => x.Avance < 100).ToList();
                }
            }
          
            return View(resultado);
        }
	}
}



