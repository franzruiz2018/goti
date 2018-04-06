using GOTIV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class ResumenController : Controller
    {
       
       // GET: /Resumen/
        gotiEntities db = new gotiEntities();
        
      //Metas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaMetas()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.SubArea = new SelectList(db.Area.ToList(), "Area_id", "Area_Descripción");
            var resumen = from p in db.sp_resumen_metas(Convert.ToDateTime("1990-01-01"))
                         select p;
            resumen = resumen.OrderBy(y => y.Area_Descripción).ThenBy(z => z.SubArea_Descripción).ThenBy(z => z.FechaInicioActividades).ThenBy(z => z.Estado_descripcion);
            return View(resumen.ToList());
           
        }
        [HttpPost]
        public ActionResult ListaMetas(DateTime? FecInicio, string Estado, int? SubArea_id, int? FgPOI)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.SubArea = new SelectList(db.Area.ToList(), "Area_id", "Area_Descripción");
            if (FecInicio == null)
            {
                FecInicio = Convert.ToDateTime("1990-01-01");
            }
            var resumen = from p in db.sp_resumen_metas(FecInicio)
                          select p;
             if (SubArea_id != null)
            {
                resumen = resumen.Where(x => x.area_id == SubArea_id).ToList();
            }
            if (FgPOI != null)
            {
                bool poi = false;
                if (FgPOI == 1) poi = true;
                resumen = resumen.Where(x => x.POI == poi).ToList();
            }           
            resumen = resumen.OrderBy(y => y.Area_Descripción).ThenBy(z => z.SubArea_Descripción).ThenBy(z => z.FechaInicioActividades).ThenBy(z => z.Estado_descripcion);

            return View(resumen.ToList());
        }



	}
}