using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class MetaController : Controller
    {
        //
        // GET: /Meta/
        gotiEntities db = new gotiEntities();

        public ActionResult Index()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.SubArea = new SelectList(db.SubArea.ToList(), "SubArea_id", "SubArea_Descripción");
            return View(db.Meta.ToList());
        }

        [HttpPost]
        public ActionResult Index(int? SubArea_id,int? FgPOI)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;        
            var result = db.Meta.ToList();
            if (SubArea_id != null)
            {
                result = result.Where(x => x.SubArea_id == SubArea_id).ToList();
            }
            if (FgPOI != null)
            {
                bool poi = false;
                if (FgPOI == 1) poi = true;
                result = result.Where(x => x.POI == poi).ToList();
            }

            ViewBag.SubArea = new SelectList(db.SubArea.ToList(), "SubArea_id", "SubArea_Descripción", SubArea_id);
            return View(result);

        }

        public ActionResult Save()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.SubArea = new SelectList(db.SubArea.ToList(), "SubArea_id", "SubArea_Descripción");
            ViewBag.Version = new SelectList(db.Version.ToList(), "Version_id", "Version1");         
            ViewBag.Exito = false;
            return View();
        }

        [HttpPost]
        public ActionResult Save(Meta meta,int poi)
        {
           
            try
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                bool FgPOI = false;
                if (poi == 1) FgPOI = true;
                meta.POI = FgPOI;
                meta.Fecha_creacion = DateTime.Now;
                db.Meta.Add(meta);
                db.SaveChanges();

                db.MetaEstado.Add(new MetaEstado { Meta_id = meta.Meta_id, Estado_id = 1, Fecha_creacion = DateTime.Now });
                db.SaveChanges();
                
                ViewBag.Exito = true;
                ViewBag.Mensaje = "La actividad se registró correctamente";
                ViewBag.SubArea = new SelectList(db.SubArea.ToList(), "SubArea_id", "SubArea_Descripción");
                ViewBag.Version = new SelectList(db.Version.ToList(), "Version_id", "Version1");  
               
}

                                
                catch (Exception ex)
                {
                    ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                    ViewBag.SubArea = new SelectList(db.SubArea.ToList(), "SubArea_id", "SubArea_Descripción");
                    ViewBag.Version = new SelectList(db.Version.ToList(), "Version_id", "Version1");  
                    ViewBag.Exito = false;
                    ViewBag.Mensaje = ex.Message;
                }
                return View(meta);

         
        }



     

	}
}