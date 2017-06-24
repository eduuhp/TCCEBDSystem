using System.Web;
using System.Web.Mvc;
using prjEBDSystem.Filters;

namespace prjEBDSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Authentication());
            filters.Add(new FiltroException());
        }
    }
}
