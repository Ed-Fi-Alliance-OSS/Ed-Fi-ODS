using System.Collections.Generic;
using System.Web;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Extensions.Publishing.Feature.SnapshotContext
{
    public class SnapshotContextProvider : ISnapshotContextProvider, IHttpContextStorageTransferKeys
    {
        private const string SnapshotContextKeyName = "SnapshotContextProvider.SnapshotContext";
        private readonly IContextStorage _contextStorage;

        public SnapshotContextProvider(IContextStorage contextStorage)
        {
            _contextStorage = contextStorage;
        }

        /// <summary>
        /// Gets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <returns>The current context.</returns>
        public SnapshotContext GetSnapshotContext()
        {
            return _contextStorage.GetValue<SnapshotContext>(SnapshotContextKeyName);
        }

        /// <summary>
        /// Sets the <see cref="SnapshotContext" /> for the current API request.
        /// </summary>
        /// <param name="snapshotContext">The snapshot context to be set.</param>
        public void SetSnapshotContext(SnapshotContext snapshotContext)
        {
            _contextStorage.SetValue(SnapshotContextKeyName, snapshotContext);
        }

        /// <summary>
        /// Declare the <see cref="IContextStorage"/> keys that are read and written by the component
        /// and should be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/> for background Tasks.
        /// </summary>
        /// <returns>A list of keys to be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/>.</returns>
        IReadOnlyList<string> IHttpContextStorageTransferKeys.GetKeys()
        {
            return new[]
            {
                SnapshotContextKeyName
            };
        }
    }
}
