using System.Web;
using System.Web.Mvc;

namespace PruebaAlmacenes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Filtro personalizado
            filters.Add(new Filters.VerifySession());
        }
    }
}
