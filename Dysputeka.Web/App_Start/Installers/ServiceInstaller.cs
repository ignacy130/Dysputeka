using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PortalKol.Core.Infrastructure;
using PortalKol.Core.Infrastructure.Checks;
using PortalKol.Core.Infrastructure.Commands;
using PortalKol.Core.Infrastructure.Events;
using PortalKol.Core.Infrastructure.Queries;

namespace PortalKol.Web.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(ICommand<>))
                    .WithServiceBase(),

                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(IEvent<>))
                    .WithServiceBase(),

                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(ICheck<>))
                    .WithServiceBase(),

                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(IQuery<>))
                    .WithServiceBase(),

                Component.For<ICommandBus>().ImplementedBy<CommandBus>(),
                Component.For<IEventBus>().ImplementedBy<EventBus>(),
                Component.For<ICheckBus>().ImplementedBy<CheckBus>(),
                Component.For<IQueryBus>().ImplementedBy<QueryBus>(),
                Component.For<IAssistant>().ImplementedBy<Assistant>(),
                Component.For<IDateTimeGetter>().ImplementedBy<DateTimeGetter>()
                );
        }
    }
}