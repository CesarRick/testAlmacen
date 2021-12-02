using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaAlmacenes.Controllers
{
    public class SalirController : Controller
    {
        // GET: Salir
        public ActionResult Index()
        {
            return View();
        }

        //Cerrar session
        public ActionResult LogOff()
        {
            Session["User"] = null;
            return RedirectToAction("Index","Access");
        }
    }
}