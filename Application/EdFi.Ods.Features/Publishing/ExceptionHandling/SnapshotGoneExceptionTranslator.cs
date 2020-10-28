using System;
using System.Net;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Exceptions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Extensions.Publishing.Feature.SnapshotContext;
using NHibernate.Exceptions;

namespace EdFi.Ods.Extensions.Publishing.Feature.ExceptionHandling
{
    /// <summary>
    /// Implements an exception translator that looks for the custom <see cref="DatabaseConnectionException" />
    /// embedded in an <see cref="GenericADOException" />, and if snapshot context has been provided on
    /// the request, sets the response status code to HTTP 410 (Gone).
    /// </summary>
    public class SnapshotGoneExceptionTranslator : IExceptionTranslator
    {
        private readonly ISnapshotContextProvider _snapshotContextProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SnapshotGoneExceptionTranslator" /> class using the
        /// supplied snapshot context provider.
        /// </summary>
        /// <param name="snapshotContextProvider">Provides access to the snapshot context for the current request.</param>
        public SnapshotGoneExceptionTranslator(ISnapshotContextProvider snapshotContextProvider)
        {
            _snapshotContextProvider = snapshotContextProvider;
        }

        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            Preconditions.ThrowIfNull(ex, nameof(ex));
            
            webServiceError = null;

            // Unwrap the NHibernate generic exception if it is present
            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is DatabaseConnectionException
                && _snapshotContextProvider.GetSnapshotContext() != null)
            {
                webServiceError = new RESTError
                {
                    Code = (int) HttpStatusCode.Gone,
                    Type = HttpStatusCode.Gone.ToString().NormalizeCompositeTermForDisplay(), 
                    Message = "Snapshot not available."
                };
                
                return true;
            }

            return false;
        }
    }
}
