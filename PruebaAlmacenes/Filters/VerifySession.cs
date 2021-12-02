using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Using filters
using System.Web.Mvc;
using PruebaAlmacenes.Controllers;
using PruebaAlmacenes.Models;

namespace PruebaAlmacenes.Filters
{
    public class VerifySession: ActionFilterAttribute
    {
        //Method Override
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Verificar si existe session.
            var usuario = (Usuario)HttpContext.Current.Session["User"];
            if (usuario == null)
            {
                // Validar si accede desde AccessController y no tiene Session
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                // Si ya tiene Session redireccion a Home / Index
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }                
            }

            //Return
            base.OnActionExecuting(filterContext);

        }
    }
}