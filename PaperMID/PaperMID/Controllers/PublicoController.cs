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
        MensajeDAL oMensajeDAL;
        UsuarioDAL oUsuarioDAL;
        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerificarUsuario(string usuario, string contraseña)
        {
            oLoginDAL = new LoginDAL();
            if (ModelState.IsValid)
            {
                if (oLoginDAL.verificarCliente(usuario, contraseña) == 1)
                {
                    Session["Usuario"] = usuario;
                    return RedirectToAction("Inicio", "Cliente");
                }
                else if (oLoginDAL.verificarAdmin(usuario, contraseña) == 1)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnviarMensaje(string mensaje, string nombre, string asunto, string telefono, string correo)
        {
            oMensajeDAL = new MensajeDAL();
            if (ModelState.IsValid)
            {
                if (oMensajeDAL.Agregar(mensaje, nombre, asunto, telefono, correo) == 1)
                {
                    return RedirectToAction("Contacto", "Publico");
                }
                else
                {
                    return RedirectToAction("Contacto", "Publico");
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult IniciarSesión()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarUsuario(string usuario, string correo, string contra, string recontra)
        {
            oUsuarioDAL = new UsuarioDAL();
            if (ModelState.IsValid)
            {
                if (contra == recontra)
                {
                    if (oUsuarioDAL.AgregarCliente(usuario, correo, contra) == 1)
                    {
                        return RedirectToAction("Registro", "Publico");
                    }
                    else
                    {
                        return RedirectToAction("Registro", "Publico");
                    }
                }
                else
                {
                    return RedirectToAction("Registro", "Publico");
                }
            }
            else
            {
                return View();
            }

        }
    }
}