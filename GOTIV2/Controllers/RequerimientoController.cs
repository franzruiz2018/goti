using GOTIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTIV2.Controllers
{   
    [Autorizado]
    public class RequerimientoController : Controller
    {
        gotiEntities db = new gotiEntities();
        //
        // GET: /Requerimiento/
        public ActionResult Index()
        {           
            return View();
        }
       

         
        public ActionResult Listar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;             
            ViewBag.Areas = new SelectList(db.SPE_AreaInstitucion.ToList(), "AreaInstitucion_Id", "AreaInstitucionAbreviatura");
            return View(db.sp_SGRQ_Requerimiento_Lista().Where(x => x.VBTecnico == true).ToList());
         }
         [HttpPost]
         public ActionResult Listar(int? areaId)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.Areas = new SelectList(db.SPE_AreaInstitucion.ToList(), "AreaInstitucion_Id", "AreaInstitucionAbreviatura");
             var req = db.sp_SGRQ_Requerimiento_Lista().Where(x=>x.VBTecnico==true).ToList();
             if (areaId != null)
             {
                 req = req.Where(x => x.Requerimiento_Id == areaId).ToList();
             }
             return View(req);
         }



         public ActionResult ListarSolicitud()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.Areas = new SelectList(db.SPE_AreaInstitucion.ToList(), "AreaInstitucion_Id", "AreaInstitucionAbreviatura");
             return View(db.sp_SGRQ_Requerimiento_Lista().Where(x => x.VBTecnico == false).ToList());
         }
         [HttpPost]
         public ActionResult ListarSolicitud(int? areaId)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.Areas = new SelectList(db.SPE_AreaInstitucion.ToList(), "AreaInstitucion_Id", "AreaInstitucionAbreviatura");
             var req = db.sp_SGRQ_Requerimiento_Lista().Where(x => x.VBTecnico == false).ToList();
             if (areaId != null)
             {
                 req = req.Where(x => x.Requerimiento_Id == areaId).ToList();
             }
             return View(req);
         }


        public ActionResult Registrar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.PersonaJefes = new SelectList(db.SPE_Persona.Where(x => x.Jefe == true).ToList(), "Persona_Id", "NombreCompleto");
            ViewBag.TipoRequerimiento = new SelectList(db.SGRQ_TipoRequerimiento.ToList(), "TipoRequerimiento_Id", "TipoRequerimiento_Descripcion");
            ViewBag.TipoSistema = new SelectList(db.SGRQ_TipoSistema.ToList(), "TipoSistema_Id", "TipoSistema_Descripcion");
            ViewBag.Sistema = new SelectList(db.SGRQ_Sistema.ToList(), "Sistema_Id", "Sistema_Descripcion");
            ViewBag.Prioridad = new SelectList(db.SGPRY_Prioridad.ToList(), "Prioridad_Id", "PrioridadDescripcion");
            ViewBag.PersonaReferenteFuncional = new SelectList(db.SPE_Persona.ToList(), "Persona_Id", "NombreCompleto");
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(SGRQ_Requerimiento r)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;            
            try
            {             
                r.Fecha_Registro = DateTime.Now;
                db.SGRQ_Requerimiento.Add(r);
                db.SaveChanges();
                TempData["Mensaje"] = "Se registró corréctamente...";
            }
            catch (Exception ex)
            {
               
                TempData["Mensaje"] = ex.Message;
            }

            return RedirectToAction("Listar", "Requerimiento");
        }
	}
}