namespace Dysputeka.Core.Infrastructure.Commands
{
    public interface ICommand<in TCommand>
    {
        void Execute(TCommand command);
    }

    public abstract class CommandPerformer<T> : Base, ICommand<T>
    {
        public abstract void Execute(T command);
    }
}