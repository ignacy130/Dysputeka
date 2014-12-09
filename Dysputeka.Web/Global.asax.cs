using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PortalKol.Web.Infrastructure;

namespace PortalKol.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = ContainerConfig.CreateContainer();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory(container));
        }
    }
}
