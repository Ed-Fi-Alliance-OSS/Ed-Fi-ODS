using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Context
{
    /// <summary>
    /// Transfers required context from <see cref="HttpContext"/> to <see cref="CallContext"/>.
    /// </summary>
    public class HttpContextStorageTransfer : IHttpContextStorageTransfer
    {
        private readonly CallContextStorage _callContextStorage;
        private readonly IContextStorage _httpContextStorage;
        private readonly IHttpContextStorageTransferKeys[] _httpContextStorageTransferKeys;

        public HttpContextStorageTransfer(
            IContextStorage httpContextStorage,
            CallContextStorage callContextStorage,
            IHttpContextStorageTransferKeys[] httpContextStorageTransferKeys)
        {
            _httpContextStorage = httpContextStorage;
            _callContextStorage = callContextStorage;
            _httpContextStorageTransferKeys = httpContextStorageTransferKeys;
        }

        /// <summary>
        /// Transfers necessary context from <see cref="HttpContext"/> to the injected underlying context provider (e.g. <see cref="CallContext"/>, for running background worker threads in ASP.NET applications).
        /// </summary>
        public void TransferContext()
        {
            // Iterate through all context storage keys providers
            foreach (var keys in _httpContextStorageTransferKeys)
            {
                // Add each key/value pair to the call context
                foreach (string key in keys.GetKeys())
                {
                    _callContextStorage.SetValue(key, _httpContextStorage.GetValue<object>(key));
                }
            }
        }
    }
}
