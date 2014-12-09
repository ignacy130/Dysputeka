using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using PortalKol.Core.Infrastructure.Data;
using PortalKol.Web.Infrastructure;

namespace PortalKol.Web.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
               Component.For<ISessionFactoryConfigurator>().ImplementedBy<WebSessionFactoryConfigurator>(),
               Component.For<ISessionFactoryProvider>().ImplementedBy<SessionFactoryProvider>(),
               Component.For<ISessionFactory>().UsingFactoryMethod((kernel, context) => kernel.Resolve<ISessionFactoryProvider>().GetSessionFactory()),
                //.OnCreate(NHibernate.Glimpse.Plugin.RegisterSessionFactory),
               Component.For<ISessionProvider>().ImplementedBy<ContextSessionProvider>()
           );
        }
    }
}