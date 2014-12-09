using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Dysputeka.Core.Infrastructure;
using Dysputeka.Core.Infrastructure.Checks;
using Dysputeka.Core.Infrastructure.Commands;
using Dysputeka.Core.Infrastructure.Events;
using Dysputeka.Core.Infrastructure.Queries;

namespace Dysputeka.Web.Installers
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