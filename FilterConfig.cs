using RickyRose.Infastructure;
using System.Web;
using System.Web.Mvc;

namespace RickyRose
{
    public class FilterConfig
    {
        public static RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
    }
}