namespace PortalKol.Core.Infrastructure.Queries
{
    public interface IQueryBus
    {
        T Perform<T>(T query);
    }

    public class QueryBus : IQueryBus
    {
        public T Perform<T>(T query)
        {
            var performer = IoC.Resolve<IQuery<T>>();
            if (performer != null)
                performer.Perform(query);

            return query;
        }
    }
}