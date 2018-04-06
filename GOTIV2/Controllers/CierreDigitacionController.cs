using GOTIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class CierreDigitacionController : Controller
    {
        gotiEntities db = new gotiEntities();
        // GET: /CierreDigitacion/
        public ActionResult Index()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.ResumenCierre = db.sp_SGP_AtencionesCerradas_por_Ipress_Establecimiento().ToList();
            ViewBag.ResumenCierreTotal = db.sp_SGP_Total_AtencionesCerradas_por_Ipress_Establecimiento().ToList();
            return View();
        }

        public ActionResult Listar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Establecimiento = new SelectList(db.sp_Maestro_Establecimiento_Convenio().ToList(), "EstablecimientoId", "abreviatura");        
            return View(db.sp_SGP_Cierre_Digitacion_Lista().ToList());
        }
        [HttpPost]
        public ActionResult Listar(int? Establecimiento)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Establecimiento = new SelectList(db.sp_Maestro_Establecimiento_Convenio().ToList(), "EstablecimientoId", "abreviatura");
            var cierre = db.sp_SGP_Cierre_Digitacion_Lista().ToList();
            if (Establecimiento != null)
            {
                cierre = cierre.Where(x => x.EstablecimientoId == Establecimiento).ToList();
            }
            return View(cierre);
        }

        public ActionResult Registrar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Establecimiento = new SelectList(db.sp_Maestro_Establecimiento_Convenio().ToList(), "EstablecimientoId", "abreviatura");
            ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8), "Persona_Id", "NombreCompleto");
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(SGP_CierreDigitacion r)
        {
         
            try
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                r.FechaRegistro = DateTime.Now;
                db.SGP_CierreDigitacion.Add(r);
                db.SaveChanges();
                TempData["Mensaje"] = "Se registró corréctamente...";
            }
            catch (Exception ex)
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                TempData["Mensaje"] = ex.Message;
            }

            return RedirectToAction("Listar", "CierreDigitacion");
        }

	}
}