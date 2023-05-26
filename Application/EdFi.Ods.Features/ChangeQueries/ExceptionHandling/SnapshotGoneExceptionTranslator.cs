// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Features.ChangeQueries.SnapshotContext;
using NHibernate.Exceptions;

namespace EdFi.Ods.Features.ChangeQueries.ExceptionHandling
{
    /// <summary>
    /// Implements an exception translator that looks for the custom <see cref="DatabaseConnectionException" />
    /// embedded in an <see cref="GenericADOException" />, and if snapshot context has been provided on
    /// the request, sets the response status code to HTTP 410 (Gone).
    /// </summary>
    public class SnapshotGoneExceptionTranslator : IExceptionTranslator
    {
        private readonly IContextProvider<SnapshotUsage> _snapshotContextProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SnapshotGoneExceptionTranslator" /> class using the
        /// supplied snapshot context provider.
        /// </summary>
        /// <param name="snapshotContextProvider">Provides access to the snapshot context for the current request.</param>
        public SnapshotGoneExceptionTranslator(IContextProvider<SnapshotUsage> snapshotContextProvider)
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
                && _snapshotContextProvider.Get() != SnapshotUsage.Off)
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
