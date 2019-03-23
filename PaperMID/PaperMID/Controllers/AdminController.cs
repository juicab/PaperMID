using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.DAL;

namespace PaperMID.Controllers
{
    public class AdminController : Controller
    {
        ConfiguracionDAL oConfiguracion;
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

        public ActionResult Configuracion()
        {
            oConfiguracion = new ConfiguracionDAL();
            return View(oConfiguracion.Obtener_Empresa());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarDatos(string nombre,string correo,string telefono,string mision,string vision,string valores)
        {
            oConfiguracion= new ConfiguracionDAL();
            if (ModelState.IsValid)
            {
                int Resp = 0;
                Resp = oConfiguracion.Modificar(nombre, correo, telefono, mision, vision, valores);
                if (Resp == 1)
                {

                    return RedirectToAction("Configuracion", "Admin");
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
    }
}