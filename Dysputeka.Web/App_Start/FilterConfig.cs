using System.Web;
using System.Web.Mvc;
using Dysputeka.Web.Infrastructure;

namespace Dysputeka.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SessionScopeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
