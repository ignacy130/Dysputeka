using Dysputeka.Core.Infrastructure.Data;
using NHibernate.Cfg;

namespace Dysputeka.Web.Infrastructure
{
    public class WebSessionFactoryConfigurator : ISessionFactoryConfigurator
    {
        public void Configure(Configuration configuration)
        {
            configuration
                .SetProperty(Environment.Dialect, "NHibernate.Dialect.MsSql2008Dialect")
                .SetProperty(Environment.Hbm2ddlKeyWords, "auto-quote")
                .SetProperty(Environment.CurrentSessionContextClass, "web")
                .SetProperty(Environment.FormatSql, "true")
                .SetProperty(Environment.GenerateStatistics, "true")
                .SetProperty(Environment.ConnectionStringName, "portalKol");
        }
    }
}