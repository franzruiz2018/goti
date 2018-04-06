using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
{
     [Autorizado]
    public class ExpedienteController : Controller
    {
        //
        // GET: /Expediente/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {           
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
          return View(db.sp_STG_Expedientes_Listar().OrderByDescending(x=>x.FechaRecepcionOTI).ToList());
        }

      
        public ActionResult Registrar()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Persona = new SelectList(db.SPE_Persona.ToList(), "Persona_Id", "NombreCompleto");
            ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x=>x.AreaInstitucion_Id==8 ), "Persona_Id", "NombreCompleto");
            ViewBag.PersonaJefes = new SelectList(db.SPE_Persona.ToList().Where(x => x.Jefe == true), "Persona_Id", "NombreCompleto");
            ViewBag.TipoDocumento = new SelectList(db.STG_TipoDocumento.ToList(), "TipoDocumento_Id", "TipoDocumentoDescripcion");
            ViewBag.Exito = false;
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(STG_Expediente Expediente)
        {

            try
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                Expediente.FechaCreacion = DateTime.Now;
                Expediente.Atendido = false;
                db.STG_Expediente.Add(Expediente);
                db.SaveChanges();
                ViewBag.Exito = true;
                ViewBag.Mensaje = "La actividad se registró correctamente";
                ViewBag.Persona = new SelectList(db.SPE_Persona.ToList(), "Persona_Id", "NombreCompleto");
               
            }


            catch (Exception ex)
            {
                ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                ViewBag.Persona = new SelectList(db.SPE_Persona.ToList(), "Persona_Id", "NombreCompleto");
                ViewBag.PersonaOTI = new SelectList(db.SPE_Persona.ToList().Where(x => x.AreaInstitucion_Id == 8), "Persona_Id", "NombreCompleto");
                ViewBag.PersonaJefes = new SelectList(db.SPE_Persona.ToList().Where(x => x.Jefe == true), "Persona_Id", "NombreCompleto");
                ViewBag.TipoDocumento = new SelectList(db.STG_TipoDocumento.ToList(), "TipoDocumento_Id", "TipoDocumentoDescripcion");
                ViewBag.Exito = false;
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public ActionResult Pendientes()
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            ViewBag.Exito = false;
            return View(db.sp_STG_Expedientes_Listar().Where(x=>x.Atendido==false && x.OrigenOTI==false ).ToList());
        }
        
        public ActionResult Cerrar(int? Id)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
            return View(db.STG_Expediente.FirstOrDefault(x => x.Expediente_Id == Id));
        }
         [HttpPost]
        public ActionResult Cerrar(STG_Expediente Expediente)
        {
            ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             var obExpediente= db.STG_Expediente.FirstOrDefault(x => x.Expediente_Id == Expediente.Expediente_Id);
             obExpediente.DocumentoAtención = Expediente.DocumentoAtención;
             obExpediente.FechaRecepcionSolicitante = Expediente.FechaRecepcionSolicitante;
             obExpediente.FechaCierre = DateTime.Now;
             obExpediente.Atendido = true;
             db.SaveChanges();            
             ViewBag.Exito = true;
             ViewBag.Mensaje = "La actividad se registró correctamente";
            return View();
        }

         public ActionResult Archivar(int? Id)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             return View(db.STG_Expediente.FirstOrDefault(x => x.Expediente_Id == Id));
         }
         [HttpPost]
         public ActionResult Archivar(STG_Expediente Expediente)
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             var obExpediente = db.STG_Expediente.FirstOrDefault(x => x.Expediente_Id == Expediente.Expediente_Id);
             obExpediente.Observacion = Expediente.Observacion;
             obExpediente.FechaCierre = DateTime.Now;
             obExpediente.Atendido = true;
             db.SaveChanges();
             ViewBag.Exito = true;
             ViewBag.Mensaje = "La actividad se registró correctamente";
             return View();
         }

         

         public ActionResult Persona()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             var ipress = db.SPE_Persona.OrderBy(x => x.NombreCompleto).ToList();
             return PartialView("_Persona", ipress);
         }

         public ActionResult PersonaDestinatario()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             var ipress = db.SPE_Persona.OrderBy(x => x.NombreCompleto).ToList();
             return PartialView("_PersonaDestinatario", ipress);
         }

        //-------------------------------------------------------------------
        //Documento
        //-------------------------------------------------------------------

         public ActionResult ListaDocumentos()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
           
             var ipress = db.sp_STG_Documentos_Listar().OrderByDescending(x => x.FechaCreacion).ToList();
             return PartialView("_ListaDocumentos", ipress);
         }

         public ActionResult ListarDocumentos()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             var doc = db.sp_STG_Documentos_Listar().OrderByDescending(x => x.FechaCreacion).ToList();
             return PartialView(doc);
         }

         public ActionResult RegistrarDocumento()
         {
             ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
             ViewBag.TipoDocumento = new SelectList(db.STG_TipoDocumento.ToList(), "TipoDocumento_Id", "TipoDocumentoDescripcion");
             return View();
         }

         [HttpPost]
         public ActionResult RegistrarDocumento(STG_Documento Doc)
         {

             try
             {
                 ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                 Doc.FechaCreacion = DateTime.Now;
                 db.STG_Documento.Add(Doc);
                 db.SaveChanges();
                 ViewBag.Exito = true;
                 ViewBag.Mensaje = "La actividad se registró correctamente";
                 ViewBag.Persona = new SelectList(db.SPE_Persona.ToList(), "Persona_Id", "NombreCompleto");
             }


             catch (Exception ex)
             {
                 ViewBag.Perfil = ((Usuario)Session["UsuarioLogueado"]).Perfil;
                 ViewBag.TipoDocumento = new SelectList(db.STG_TipoDocumento.ToList(), "TipoDocumento_Id", "TipoDocumentoDescripcion");
                 ViewBag.Exito = false;
                 ViewBag.Mensaje = ex.Message;
                
             }
             return View();
         }



	}
}