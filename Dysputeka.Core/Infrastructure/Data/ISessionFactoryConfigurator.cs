using NHibernate.Cfg;

namespace Dysputeka.Core.Infrastructure.Data
{
    public interface ISessionFactoryConfigurator
    {
        void Configure(Configuration configuration);
    }
}