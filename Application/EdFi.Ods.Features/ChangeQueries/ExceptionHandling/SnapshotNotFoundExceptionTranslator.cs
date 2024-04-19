// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Features.ChangeQueries.SnapshotContext;
using NHibernate.Exceptions;

namespace EdFi.Ods.Features.ChangeQueries.ExceptionHandling
{
    /// <summary>
    /// Implements an exception translator that looks for the custom <see cref="DatabaseConnectionException" />
    /// embedded in an <see cref="GenericADOException" />, and if snapshot context has been provided on
    /// the request, sets the response status code to HTTP 404 (Not Found).
    /// </summary>
    public class SnapshotNotFoundExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly IContextProvider<SnapshotUsage> _snapshotContextProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SnapshotNotFoundExceptionTranslator" /> class using the
        /// supplied snapshot context provider.
        /// </summary>
        /// <param name="snapshotContextProvider">Provides access to the snapshot context for the current request.</param>
        public SnapshotNotFoundExceptionTranslator(IContextProvider<SnapshotUsage> snapshotContextProvider)
        {
            _snapshotContextProvider = snapshotContextProvider;
        }

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            // If Use-Snapshot was not provided, there is no need to try to translate this exception
            if (_snapshotContextProvider.Get() != SnapshotUsage.On)
            {
                problemDetails = null;
                return false;
            }

            // Unwrap the NHibernate generic exception if it is present
            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is DatabaseConnectionException or DbException)
            {
                problemDetails = new NotFoundException("scenario67.");
                return true;
            }
            
            problemDetails = null;
            return false;
        }
    }
}
