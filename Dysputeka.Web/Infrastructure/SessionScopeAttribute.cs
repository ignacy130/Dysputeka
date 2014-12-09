using System.Web.Mvc;
using PortalKol.Core;
using PortalKol.Core.Infrastructure.Data;

namespace PortalKol.Web.Infrastructure
{
    public class SessionScopeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            IoC.Resolve<ISessionProvider>().CloseSession(filterContext.Exception == null);
        }
    }
}