using GOTIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTIV2.Controllers
{
    [Autorizado]
    public class HomeController : Controller
    {
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            var ResumenActividades = from a in db.vw_resumen_avance_actividad
                                     where DateTime.Now.Month >= a.Mes && DateTime.Now.Year == a.Año 
                                     select a;
            ViewBag.AvanceActividades = ResumenActividades.ToList();
            ViewBag.ActividadesPorArea = db.vw_Actividades_por_area.ToList();
            ViewBag.MetasSegunPOI = db.vw_Actividades_Segun_POI.ToList();
            ViewBag.Expedientes = db.STG_Expediente.ToList();
            ViewBag.ExpedientesPorEspecialista = db.sp_STG_Expedientes_Por_Especialista().ToList();
            ViewBag.Trama = db.sp_SGP_ResumenTramas().ToList();
            ViewBag.Proyecto = db.sp_SGPRY_listar_proyectos().ToList();
            ViewBag.vw_resumen_metas_1 = db.vw_resumen_metas.ToList();

            ViewBag.CSU_AtencionesPorTipo = db.sp_CSU_Atenciones_por_Tipo(2017).ToList();
            ViewBag.CSU_RendimientoEspecialista = db.sp_CSU_Rendimiento_Especialista(2017).ToList();
           

      
            ViewBag.CSU_AtencionesPorCatalogo = db.sp_CSU_Atenciones_por_Catalogo(2017).ToList();


            return View();
        }

       
    }
}