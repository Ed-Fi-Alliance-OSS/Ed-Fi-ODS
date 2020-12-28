// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Security.Authorization
{
    /// <summary>
    /// Executes authorization rules against an Ed-Fi ODS database as the final step of authorization.
    /// </summary>
    public class AuthorizationSegmentsVerifier : IAuthorizationSegmentsVerifier
    {
        private readonly IAuthorizationSegmentsSqlProvider _authorizationSegmentsSqlProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationSegmentsVerifier"/> class using
        /// the supplied connection string provider.
        /// </summary>
        /// <param name="authorizationSegmentsSqlProvider">Authorization sql provider</param>
        public AuthorizationSegmentsVerifier(IAuthorizationSegmentsSqlProvider authorizationSegmentsSqlProvider)
        {
            _authorizationSegmentsSqlProvider = Preconditions.ThrowIfNull(
                authorizationSegmentsSqlProvider,
                nameof(authorizationSegmentsSqlProvider));
        }

        /// <summary>
        /// Verifies that the specified segments exist in the data, as the final step of authorization.
        /// </summary>
        /// <param name="authorizationSegments">The segments to be verified.</param>
        /// <param name="cancellationToken"></param>
        public Task VerifyAsync(
            IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments,
            CancellationToken cancellationToken)
        {
            if (authorizationSegments == null)
            {
                throw new ArgumentNullException(nameof(authorizationSegments));
            }

            if (!authorizationSegments.Any())
            {
                throw new ArgumentException("No authorization segments have been defined.");
            }

            throw new NotImplementedException("Not yet re-implemented for API Simplification.");
            
            // TODO: API Simplification - Convert to use ADO.NET connection, if not obsolete
            // using (var session = _sessionFactory.OpenStatelessSession())
            // {
            //     var cmd = session.Connection.CreateCommand();
            //
            //     int parameterIndex = 0;
            //
            //     var queryMetadata =
            //         _authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);
            //
            //     cmd.CommandText = queryMetadata.Sql;
            //
            //     cmd.Parameters.AddRange(queryMetadata.Parameters);
            //
            //     var result = (int?)await cmd.ExecuteScalarAsync(cancellationToken);
            //
            //     cmd.Parameters.Clear();
            //
            //     if (result == null)
            //     {
            //         throw new EdFiSecurityException(
            //             "Authorization denied.  The claim does not have any established relationships with the requested resource.");
            //     }
            // }
        }
    }
}
