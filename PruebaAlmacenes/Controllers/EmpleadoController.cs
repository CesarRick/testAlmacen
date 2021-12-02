using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//

using PruebaAlmacenes.Models;
using PruebaAlmacenes.Models.TableViewModels;
using PruebaAlmacenes.Models.ViewModel;

namespace PruebaAlmacenes.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoTableViewModel> lst = null;
            using (IncomelDBEntities db = new IncomelDBEntities())
            {
                lst = (from d in db.Empleado
                       where d.UsuarioID > 0
                       orderby d.EmpleadoID
                       select new EmpleadoTableViewModel
                       {
                           EmpleadoID = d.EmpleadoID,
                           DPI = d.DPI,
                           NombreCompleto = d.NombreCompleto,
                           CantidadHijos = (int)d.CantidadHijos,
                           SalarioBase = d.SalarioBase,
                           BonoDecreto = d.BonoDecreto,
                           UsuarioID = d.UsuarioID,
                           FechaCreacion = (DateTime)d.FechaCreacion
                       }).ToList();
            }
            return View(lst);
        }

        //Agregar Empleado
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmpleadoViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new IncomelDBEntities())
            {
                Empleado empleado = new Empleado();
                empleado.EmpleadoID = 1;
                empleado.DPI = model.DPI;
                empleado.NombreCompleto = model.NombreCompleto;
                empleado.CantidadHijos = model.CantidadHijos;
                empleado.SalarioBase = model.SalarioBase;
                empleado.BonoDecreto = model.BonoDecreto;
                empleado.UsuarioID = model.UsuarioID;
                empleado.FechaCreacion = model.FechaCreacion;
                db.Empleado.Add(empleado);
                db.SaveChanges();
                db.Dispose();                
            }

            return Redirect(Url.Content("~/Empleado/"));
        }

        //Editar
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditEmpleadoViewModel model = new EditEmpleadoViewModel();
            using (var db = new IncomelDBEntities())
            {
                var empleado = db.Empleado.Find(Id);

                model.DPI = empleado.DPI;
                model.NombreCompleto = empleado.NombreCompleto;
                model.CantidadHijos = (int)empleado.CantidadHijos;
                model.SalarioBase = empleado.SalarioBase;
                model.BonoDecreto = empleado.BonoDecreto;
                model.UsuarioID = empleado.UsuarioID;
                //model.FechaCreacion = empleado.FechaCreacion;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditEmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new IncomelDBEntities())
            {
                var empleado = db.Empleado.Find(model.EmpleadoID);
                empleado.DPI = model.DPI;
                empleado.NombreCompleto = model.NombreCompleto;
                empleado.CantidadHijos = model.CantidadHijos;
                empleado.SalarioBase = model.SalarioBase;
                empleado.BonoDecreto = model.BonoDecreto;
                empleado.UsuarioID = model.UsuarioID;
                //empleado.FechaCreacion = model.FechaCreacion;

               
                db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //db.Dispose();           
            }

            return Redirect(Url.Content("~/Empleado/"));
        }
    }
}

