namespace PortalKol.Core.Infrastructure.Commands
{
    public interface ICommandBus
    {
        T Execute<T>(T command);
    }

    public class CommandBus : ICommandBus
    {
        public T Execute<T>(T command)
        {
            IoC.Resolve<ICommand<T>>().Execute(command);
            return command;
        }
    }
}