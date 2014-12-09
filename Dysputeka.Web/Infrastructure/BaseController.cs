using System.Web.Mvc;
using Dysputeka.Core.Infrastructure;
using Dysputeka.Core.Infrastructure.Commands;
using Dysputeka.Core.Infrastructure.Data;
using NHibernate;

namespace Dysputeka.Web.Infrastructure
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