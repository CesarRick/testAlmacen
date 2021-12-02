
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Modelos
using PruebaAlmacenes.Models;

namespace PruebaAlmacenes.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        // Login de usuario
        public ActionResult Login(string userName, string password)
        {
            try
            {
                // Conexion
                using (IncomelDBEntities db = new IncomelDBEntities())
                {
                    var lstUsuario = from d in db.Usuario
                                     where d.NombreUsuario == userName && d.Contrasena == password && d.EstadoID == 1
                                     select d;

                    if (lstUsuario.Count() > 0)
                    {
                        Usuario usuario = lstUsuario.First();
                        Session["User"] = usuario;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario no existe o no es correcto.");
                    }
                }
            }
            catch (Exception ex)
            {
                
                return Content("Ocurrió un error: " + ex.Message);
            }
        }

    }
}