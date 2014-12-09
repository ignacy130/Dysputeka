namespace Dysputeka.Core.Infrastructure.Queries
{
    public interface IQueryData<out T>
    {
        T QueryResult { get; }
    }

    public abstract class QueryData<T> : IQueryData<T>
    {
        public T QueryResult { get; internal set; }
    }
}