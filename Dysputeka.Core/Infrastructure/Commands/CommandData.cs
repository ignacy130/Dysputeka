using System;
using System.Collections.Specialized;

namespace PortalKol.Core.Infrastructure.Commands
{
    public class CommandData
    {
        private readonly Lazy<NameValueCollection> _errors = new Lazy<NameValueCollection>();

        public NameValueCollection Errors
        {
            get { return _errors.Value; }
        }

        public bool HasErrors
        {
            get { return _errors.IsValueCreated && _errors.Value.Count > 0; }
        }

        public void AddError(string key, string message)
        {
            _errors.Value.Add(key, message);
        }

        public void AddError(string message)
        {
            _errors.Value.Add(string.Empty, message);
        }
    }
}