using System.Web.Mvc;
using NHibernate;
using PortalKol.Core.Infrastructure;
using PortalKol.Core.Infrastructure.Commands;
using PortalKol.Core.Infrastructure.Data;

namespace PortalKol.Web.Infrastructure
{
    public class BaseController : Controller
    {
        public ISessionProvider SessionProvider { get; set; }

        public ISession Data { get { return SessionProvider.Session; } }

        public IAssistant Please { get; set; }

        public IDateTimeGetter DateTimeGetter { get; set; }

        public ActionResult JsonResultOf<T>(T command) where T : CommandData
        {
            if (command.HasErrors)
            {
                //TODO: Przepisywanie błędów do JSONa w celu wyświetlenia
                return Json(new { success = false });
            }
            return Json(new { success = true });
        }
    } 
}