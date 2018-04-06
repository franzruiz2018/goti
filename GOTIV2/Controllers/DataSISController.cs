using GOTIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTIV2.Controllers
{
    public class DataSISController : Controller
    {
        //
        // GET: /ServicioTercero/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Listar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;         
            var ordenes = db.sp_SPE_ServicioTercero_Listar().ToList();
            return View(ordenes);
        }
       
        public ActionResult Registrar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.PersonaOTITercero = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8 && x.TipoContrato == 2), "Persona_Id", "NombreCompleto");
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(SPE_ServicioTercero s)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            try
            {
                s.FechaRegistro = DateTime.Now;
                db.SPE_ServicioTercero.Add(s);
                db.SaveChanges();
                TempData["Mensaje"] = "Se registró corréctamente...";
            }
            catch (Exception ex)
            {

                TempData["Mensaje"] = ex.Message;
            }

            return RedirectToAction("Listar", "CierreDigitacion");
        }

        public ActionResult ListaExpedientes()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            var expedientes = db.STG_Expediente.Where(x => x.OrigenOTI == true).OrderByDescending(x => x.FechaCreacion).ToList();
            return PartialView("_ListaExpedientes", expedientes);
        }
	}
}