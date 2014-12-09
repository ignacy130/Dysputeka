using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Dysputeka.Core.Infrastructure.Data;
using Dysputeka.Web.Infrastructure;
using NHibernate;

namespace Dysputeka.Web.Installers
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