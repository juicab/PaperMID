using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("Inicio", "Publico");
        }
    }
}