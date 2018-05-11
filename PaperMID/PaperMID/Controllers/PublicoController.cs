using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class PublicoController : Controller
    {
        // GET: Publico
        public ActionResult Inicio()
        {
            return View();
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