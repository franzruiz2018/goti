using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;

namespace GOTIV2.Controllers
{
     [Autorizado]
    public class PersonaController : Controller
    {
        //
        // GET: /Persona/
        gotiEntities db = new gotiEntities();
        public ActionResult Index()
        {
            return View();
        }
               


	}
}