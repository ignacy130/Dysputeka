using PortalKol.Core.Infrastructure.Checks;
using PortalKol.Core.Infrastructure.Commands;
using PortalKol.Core.Infrastructure.Events;
using PortalKol.Core.Infrastructure.Queries;

namespace PortalKol.Core.Infrastructure
{
    public interface IAssistant
    {
        T Do<T>(T command);
        void Tell<T>(T @event);
        bool Check<T>(T check);
        T Give<T>(T query);
    }

    public class Assistant : IAssistant
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly ICheckBus _checkBus;
        private readonly IQueryBus _queryBus;

        public Assistant(IEventBus eventBus, ICommandBus commandBus, ICheckBus checkBus, IQueryBus queryBus)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _checkBus = checkBus;
            _queryBus = queryBus;
        }

        public T Give<T>(T query)
        {
            return _queryBus.Perform(query);
        }

        public bool Check<T>(T check)
        {
            return _checkBus.Check(check);
        }

        public T Do<T>(T command)
        {
            return _commandBus.Execute(command);
        }

        public void Tell<T>(T @event)
        {
            _eventBus.Send(@event);
        }
    }
}