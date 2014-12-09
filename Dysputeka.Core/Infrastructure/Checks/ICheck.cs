namespace PortalKol.Core.Infrastructure.Checks
{
    public interface ICheck<in TCheck>
    {
        bool Check(TCheck check);
    }

    public abstract class CheckPerformer<TCheck> : Base, ICheck<TCheck>
    {
        public abstract bool Check(TCheck check);
    }
}