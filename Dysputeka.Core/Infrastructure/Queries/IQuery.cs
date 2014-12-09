namespace PortalKol.Core.Infrastructure.Queries
{
    public interface IQuery<T>
    {
        T Perform(T query);
    }

    public abstract class QueryPerformer<T> : Base, IQuery<T>
    {
        public abstract T Perform(T query);
    }
}