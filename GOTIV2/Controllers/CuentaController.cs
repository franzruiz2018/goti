using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTIV2.Models;
using System.Web.Security;

namespace GOTIV2.Controllers
{
  
    public class CuentaController : Controller
    {
        
        // GET: /Cuenta/
        gotiEntities db = new gotiEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                var usuarioLogueado = db.Usuario.FirstOrDefault(x => x.LoginName.Equals(usuario.LoginName) && x.Password.Equals(usuario.Password));
                if (usuarioLogueado != null)
                {
                    Session["UsuarioLogueado"] = usuarioLogueado;
                    FormsAuthentication.SetAuthCookie(usuario.LoginName, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {


            }
            return View(usuario);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

 
	}
}