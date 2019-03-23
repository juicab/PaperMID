using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.DAL;

namespace PaperMID.Controllers
{
    public class PromocionController : Controller
    {
        // GET: Promocion
        PromocionesDAL oPromocionDAL;
        public ActionResult Promociones()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(string nombre, double desc, string fchini, string fchfin, string comentario, string prov)
        {
            oPromocionDAL = new PromocionesDAL();
            if (ModelState.IsValid)
            {
                int Resp = 0;
                Resp = oPromocionDAL.Agregar(nombre,desc,fchfin,fchini,comentario,prov);
                if (Resp == 1)
                {

                    return RedirectToAction("Promociones", "Promocion");
                }
                else
                {
                    return RedirectToAction("Inicio", "Admin");
                }
            }
            else
            {
                return RedirectToAction("Inicio", "Admin");
            }

        }

        [ChildActionOnly]
        public ActionResult ListarPromociones()
        {
            oPromocionDAL = new PromocionesDAL();
            return PartialView(oPromocionDAL.Mostrar());
        }
    }
}