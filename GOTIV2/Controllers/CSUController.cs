using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
 {[Autorizado]
    public class CSUController : Controller
    {
        //
        // GET: /CSU/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Especialistas = new SelectList(db.SPE_Persona.Where(x => x.AreaInstitucion_Id == 8 ), "Persona_Id", "NombreCompleto");
            return View(db.sp_CSU_Listar_Movimientos().ToList());
        }
        [HttpPost]
        public ActionResult Index(int? cerrado,int? especialista,bool? iniciado)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Especialistas = new SelectList(db.SPE_Persona.Where(x => x.AreaInstitucion_Id == 8 ), "Persona_Id", "NombreCompleto");
                       
            var movimiento = db.sp_CSU_Listar_Movimientos().ToList();
            bool? c = false;
            if (cerrado != null)
            {
                if (cerrado == 1)
                {
                    c = true;
                }

                movimiento = movimiento.Where(x => x.Cerrado == c).ToList();
            }
            if (especialista != null)
            {
                movimiento = movimiento.Where(x => x.Persona_Id_EspecialistaDesignado == especialista).ToList();
            }
            if (iniciado == true)
            {
                movimiento = movimiento.Where(x => x.FechaInicioDeAtencion != null && x.FechaCierreDeAtencion == null).ToList();
            }

            return View(movimiento);
        }

      


         public ActionResult IniciarAtencion(int id)
         {
                 try
                 {
                     ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                     var objAtencion = db.CSU_MovimientoCSU.FirstOrDefault(x => x.MovimientoCSU_Id == id);
                     objAtencion.FechaInicioDeAtencion = DateTime.Now;
                     db.SaveChanges();
                     ViewBag.Atencion = db.sp_CSU_Listar_Movimientos().FirstOrDefault(x => x.MovimientoCSU_Id == id);
                     TempData["Mensaje"] = "Se Inicio la atención...";
                 }
                 catch (Exception ex)
                 {
                     ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                     TempData["Mensaje"] = ex.Message;
                 }

                 return RedirectToAction("Index", "CSU");

         }

         public ActionResult CierreAtencion(int id)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.Atencion = db.sp_CSU_Listar_Movimientos().FirstOrDefault(x => x.MovimientoCSU_Id == id);
             return View();
         }
         [HttpPost]
         public ActionResult CierreAtencion(CSU_MovimientoCSU movimiento)
         {
             try
             {
                 ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                 var objMovimiento = db.CSU_MovimientoCSU.FirstOrDefault(x => x.MovimientoCSU_Id == movimiento.MovimientoCSU_Id);
                 objMovimiento.AsuntoDeLaAtencion_Especilista = movimiento.AsuntoDeLaAtencion_Especilista;
                 objMovimiento.DescripcionDeLaAtencion_Especialista = movimiento.DescripcionDeLaAtencion_Especialista;
                 objMovimiento.DecripcionEnCierre = movimiento.DecripcionEnCierre;
                 objMovimiento.FechaCierreDeAtencion = DateTime.Now;
                 objMovimiento.Cerrado = true;
                 objMovimiento.TiempoUtilizado = movimiento.TiempoUtilizado;

                 db.SaveChanges();
                 TempData["Mensaje"] = "Se cerro una atención...";
             }
             catch (Exception ex)
             {
                 ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                 TempData["Mensaje"] = ex.Message;

             }

             return RedirectToAction("Index", "CSU");

         }





         public ActionResult RegistrarAtencion()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.TipoAtencion = new SelectList(db.CSU_TipoDeAtencion.Where(x=>x.TipoDeAtencion_Padre_Id!=null).ToList(), "TipoDeAtencion_Id", "TipoDeAtencion_Descripcion");
             ViewBag.PersonaFissal = new SelectList(db.SPE_Persona.ToList().Where(x=>x.TipoContrato==1).OrderBy(x=>x.NombreCompleto), "Persona_Id", "NombreCompleto");
             ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8), "Persona_Id", "NombreCompleto");
             return View();
         }
         [HttpPost]
         public ActionResult RegistrarAtencion(CSU_MovimientoCSU movimiento, string __DescripcionDeLaAtencion_Usuario)
         {             
             ViewBag.TipoAtencion = new SelectList(db.CSU_TipoDeAtencion.ToList(), "TipoDeAtencion_Id", "TipoDeAtencion_Descripcion");
             ViewBag.PersonaFissal = new SelectList(db.SPE_Persona.ToList(), "Persona_Id", "NombreCompleto");
             ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8), "Persona_Id", "NombreCompleto");

             try
             {
                 ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;

                 movimiento.FechaRegistro = DateTime.Now;
                 movimiento.Cerrado = false;
                 movimiento.DescripcionDeLaAtencion_Usuario = __DescripcionDeLaAtencion_Usuario;

                 db.CSU_MovimientoCSU.Add(movimiento);
                 db.SaveChanges();

                 TempData["Mensaje"] = "Se registró la Atención...";
             }
             catch (Exception ex)
             {
                 ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                 TempData["Mensaje"] = ex.Message;

             }

             return RedirectToAction("Index", "CSU");

         }


         public ActionResult CatalogoServicio(int id)
         {

             var catalogo = db.CSU_CatalogoDeServicio.Where(x => x.TipoDeAtencion_Id == id).Select(x => new { x.CatalogoServicio_Id, x.CatalogoServicio_Descripcion }).ToList();
             return Json(catalogo, JsonRequestBehavior.AllowGet);            
           
           
         }

         public ActionResult TipoDeAtencion_Colaborador(int id)
         {

             var Colaboradores = db.sp_CSU_TipoAtencion_Colaborador().Where(x => x.TipoDeAtencion_Id == id).Select(x => new { x.PersonaColaborador_Id, x.NombreCompleto }).ToList();
             return Json(Colaboradores, JsonRequestBehavior.AllowGet);


         }

        public ActionResult ReporteCSU ()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Resumen = db.sp_CSU_Resumen().FirstOrDefault();
            ViewBag.CSU_Atenciones_por_Especialista_MesActual = db.sp_CSU_Atenciones_por_Especialista_MesActual().ToList();
            ViewBag.CSU_TotalAtenciones_por_Especialista = db.sp_CSU_Total_Atenciones_por_Especialista_MesActual().ToList();
            ViewBag.CSU_TotalAtenciones_por_TipoAtención = db.sp_CSU_Total_Atenciones_por_TipoDeAtencion().ToList();
            return View();

        }
 
 
 
 }
}






