using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
{

    //[Autorizado]
    public class PruebaController : Controller
    {
        //
        // GET: /Prueba/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            //ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Proyecto = db.SGPRY_Proyecto.FirstOrDefault(x => x.ProyectoId == 1);
            ViewBag.Requisitos = db.sp_SGPRY_listar_requisitos(1).ToList();
            ViewBag.Iteracion = db.sp_SGPRY_listar_iteracion(1);
            ViewBag.Actividad = db.sp_SGPRY_listar_actividades(1);  
            return View();
        }
	}
}