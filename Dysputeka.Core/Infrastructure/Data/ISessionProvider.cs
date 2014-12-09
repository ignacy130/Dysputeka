using System.Data;
using NHibernate;
using NHibernate.Context;

namespace PortalKol.Core.Infrastructure.Data
{
    public interface ISessionProvider
    {
        ISession Session { get; }
        bool HasOpenSession { get; }
        void CloseSession(bool commit);
    }

    public class ContextSessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;

        public ContextSessionProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public ISession Session
        {
            get
            {
                return CurrentSessionContext.HasBind(_sessionFactory)
                    ? _sessionFactory.GetCurrentSession()
                    : CreateAndBindSession();
            }
        }

        public bool HasOpenSession
        {
            get { return CurrentSessionContext.HasBind(_sessionFactory); }
        }

        private ISession CreateAndBindSession()
        {
            var session = _sessionFactory.OpenSession();

            session.BeginTransaction(IsolationLevel.ReadCommitted);
            CurrentSessionContext.Bind(session);
            return session;
        }

        public void CloseSession(bool commit)
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory))
                return;

            var session = CurrentSessionContext.Unbind(_sessionFactory);

            if (!session.IsOpen)
                return;

            var tx = session.Transaction;
            try
            {
                if (tx != null && tx.IsActive)
                {
                    if (commit)
                    {
                        try
                        {
                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                    else
                        tx.Rollback();
                }
            }
            finally
            {
                session.Dispose();
            }
        }
    }
}