
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Modelos
using PruebaAlmacenes.Models;
using PruebaAlmacenes.Utilities;

namespace PruebaAlmacenes.Controllers
{
    public class AccessController : Controller
    {
        // Variable global para capturar dominio
        string urlDomain = "http://localhost:64759/";

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

        /*
         Inicio de recuperación de contraseña.
         Se crea ViewModel Recovery con correo y fecha nacimiento.
             */
        [HttpGet]
        public ActionResult StartRecovery()
        {
            Models.ViewModel.RecoveryViewModel model = new Models.ViewModel.RecoveryViewModel();
            return View(model);
        }

        /*Metodo para recuperar (POST)*/
        [HttpPost]
        public ActionResult StartRecovery(Models.ViewModel.RecoveryViewModel model)
        {
            try
            {
                //Validar el modelo
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                // Instanciar Clase para Generar Token
                TokenGenerator getToken = new TokenGenerator();
                
                // Obtener Token
                string token = getToken.GetSha256(Guid.NewGuid().ToString());

                // Guardar token en BD
                using (Models.IncomelDBEntities db = new Models.IncomelDBEntities())
                {
                    var usuario = db.Usuario.Where(d => d.Email == model.Email).FirstOrDefault();

                    if (usuario != null)
                    {
                        usuario.Token = token;
                        db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        db.Dispose();
                        // Enivar correo

                        //SendEmail(usuario.Email, token);
                    }
                }
                return View();                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Funcion Recovery 
        [HttpGet]
        public ActionResult Recovery(string token)
        {
            Models.ViewModel.RecoveryPasswordViewModel model = new Models.ViewModel.RecoveryPasswordViewModel();

            model.Token = token;

            using (Models.IncomelDBEntities db = new Models.IncomelDBEntities())
            {
                if (model.Token == null || model.Token.Trim().Equals(""))
                {
                    ViewBag.Error = "Url Expirado o no valido.";
                    return View("Index");
                }

                var usuario = db.Usuario.Where(d => d.Token == model.Token);

                if (usuario == null)
                {
                    ViewBag.Error = "Url Expirado o no valido.";
                    return View("Index");
                }
            }

            // Retorna respuesta.
            return View(model);
        }

        // Funcion Recover POST
        public ActionResult Recovery(Models.ViewModel.RecoveryPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (Models.IncomelDBEntities db = new Models.IncomelDBEntities())
                {
                    var usuario = db.Usuario.Where(d => d.Token == model.Token).FirstOrDefault();

                    if (usuario != null)
                    {
                        usuario.Contrasena = model.Password;
                        usuario.Token = null;
                        db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message) ;
            }
            ViewBag.Message = "Contraseña modificada. Vuelva a iniciar Sesión.";
            return View("Index");
        }
    }
}