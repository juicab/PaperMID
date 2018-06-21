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
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Barrilito", Value = "47" });
            lst.Add(new SelectListItem() { Text = "Delta", Value = "48" });
            lst.Add(new SelectListItem() { Text = "Granmark", Value = "49" });
            lst.Add(new SelectListItem() { Text = "Bic", Value = "50" });
            lst.Add(new SelectListItem() { Text = "Navitek", Value = "51" });
            lst.Add(new SelectListItem() { Text = "Kole", Value = "52" });
            lst.Add(new SelectListItem() { Text = "Indra", Value = "53" });
            lst.Add(new SelectListItem() { Text = "Dietrix", Value = "54" });
            lst.Add(new SelectListItem() { Text = "First Class", Value = "55" });
            lst.Add(new SelectListItem() { Text = "Mussa", Value = "56" });
            lst.Add(new SelectListItem() { Text = "Ribocel", Value = "57" });
            lst.Add(new SelectListItem() { Text = "Pincelitos", Value = "58" });
            lst.Add(new SelectListItem() { Text = "Mae", Value = "59" });
            lst.Add(new SelectListItem() { Text = "Artline", Value = "60" });
            lst.Add(new SelectListItem() { Text = "A-ink", Value = "61" });
            ViewBag.Opciones = lst;
            return View();
        }
    }
}