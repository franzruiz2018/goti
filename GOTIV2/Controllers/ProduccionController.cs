using GOTIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class ProduccionController : Controller
    {
        
        // GET: /Produccion/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarTrama()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View(db.SGP_Trama.ToList());
        }

        public ActionResult RegistrarTrama()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarTrama(SGP_Trama trama)
        {         
            try
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                trama.FechaRegistro = DateTime.Now;
                db.SGP_Trama.Add(trama);
                db.SaveChanges();
                ViewBag.Exito = true;
                ViewBag.Mensaje = "La actividad se registró correctamente";  
            }
            catch (Exception ex)
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;

                ViewBag.Exito = false;
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }


       








	}
}