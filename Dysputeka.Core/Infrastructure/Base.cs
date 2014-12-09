using Castle.Core.Logging;
using NHibernate;
using PortalKol.Core.Infrastructure.Data;

namespace PortalKol.Core.Infrastructure
{
    public class Base
    {
        public ISessionProvider SessionProvider { get; set; }
        public ISession Session { get { return SessionProvider.Session; } }
        public IAssistant Please { get; set; }
        public ILogger Logger { get; set; }
        public IDateTimeGetter DateTime { get; set; }
    }
}