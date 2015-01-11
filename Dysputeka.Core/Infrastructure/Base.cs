using Castle.Core.Logging;
using Dysputeka.Core.Infrastructure.Data;
using NHibernate;

namespace Dysputeka.Core.Infrastructure
{
    public class Base
    {
        public ISessionProvider SessionProvider { get; set; }
        public ISession Data { get { return SessionProvider.Session; } }
        public IAssistant Please { get; set; }
        public ILogger Logger { get; set; }
        public IDateTimeGetter DateTimeGetter { get; set; }
    }
}