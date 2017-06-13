using System.Web;
using System.Web.Mvc;

namespace GustavoFonseca.DesafioEstagio.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
