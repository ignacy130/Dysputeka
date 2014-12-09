using NHibernate.Cfg;

namespace PortalKol.Core.Infrastructure.Data
{
    public interface ISessionFactoryConfigurator
    {
        void Configure(Configuration configuration);
    }
}