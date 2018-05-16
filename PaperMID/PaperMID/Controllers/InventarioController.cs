using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Ingreso()
        {
            return View();
        }
        public ActionResult Egreso()
        {
            return View();
        }
    }
}