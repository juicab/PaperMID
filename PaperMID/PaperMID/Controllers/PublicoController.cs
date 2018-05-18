using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.DAL;

namespace PaperMID.Controllers
{
    public class PublicoController : Controller
    {
        // GET: Publico
        LoginDAL oLoginDAL;
        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerificarUsuario(string usuario,string contraseña)
        {
            oLoginDAL = new LoginDAL();
            if(ModelState.IsValid)
            {
                if(oLoginDAL.verificarCliente(usuario,contraseña)==1)
                {
                    Session["Usuario"] = usuario;
                    return RedirectToAction("Inicio", "Cliente");
                }
                else if(oLoginDAL.verificarAdmin(usuario,contraseña)==1)
                {
                    Session["Usuario"] = usuario;
                    return RedirectToAction("Inicio", "Admin");
                }
                else
                {
                    IniciarSesión();
                    return View("IniciarSesión");
                }
            }
            else
            {
                IniciarSesión();
                return View("IniciarSesón");
            }
        }

        public ActionResult QuiénesSomos()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult IniciarSesión()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }
    }
}