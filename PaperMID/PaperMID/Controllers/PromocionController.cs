using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class PromocionController : Controller
    {
        // GET: Promocion
        public ActionResult Promociones()
        {
            return View();
        }
    }
}