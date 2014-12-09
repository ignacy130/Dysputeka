using System.Web.Mvc;
using Dysputeka.Core;
using Dysputeka.Core.Infrastructure.Data;

namespace Dysputeka.Web.Infrastructure
{
    public class SessionScopeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            IoC.Resolve<ISessionProvider>().CloseSession(filterContext.Exception == null);
        }
    }
}