namespace Dysputeka.Core.Infrastructure.Checks
{
    public interface ICheckBus
    {
        bool Check<T>(T check);
    }

    public class CheckBus : ICheckBus
    {
        public bool Check<T>(T check)
        {
            return IoC.Resolve<ICheck<T>>().Check(check);
        }
    }
}