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
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using NHibernate;

namespace EdFi.Ods.Api.Security.Authorization
{
    /// <summary>
    /// Executes authorization rules against an Ed-Fi ODS database as the final step of authorization.
    /// </summary>
    public class AuthorizationSegmentsVerifier : IAuthorizationSegmentsVerifier
    {
        private readonly IAuthorizationSegmentsSqlProvider _authorizationSegmentsSqlProvider;
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationSegmentsVerifier"/> class using
        /// the supplied connection string provider.
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        /// <param name="authorizationSegmentsSqlProvider">Authorization sql provider</param>
        public AuthorizationSegmentsVerifier(
            ISessionFactory sessionFactory,
            IAuthorizationSegmentsSqlProvider authorizationSegmentsSqlProvider)
        {
            _authorizationSegmentsSqlProvider = Preconditions.ThrowIfNull(
                authorizationSegmentsSqlProvider,
                nameof(authorizationSegmentsSqlProvider));

            _sessionFactory = Preconditions.ThrowIfNull(sessionFactory, nameof(sessionFactory));
        }

        /// <summary>
        /// Verifies that the specified segments exist in the data, as the final step of authorization.
        /// </summary>
        /// <param name="authorizationSegments">The segments to be verified.</param>
        /// <param name="cancellationToken"></param>
        public async Task VerifyAsync(
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

            using (var session = _sessionFactory.OpenStatelessSession())
            {
                var cmd = session.Connection.CreateCommand();

                int parameterIndex = 0;

                var queryMetadata =
                    _authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                cmd.CommandText = queryMetadata.Sql;

                cmd.Parameters.AddRange(queryMetadata.Parameters);

                var result = (int?)await cmd.ExecuteScalarAsync(cancellationToken);

                cmd.Parameters.Clear();

                if (result == null)
                {
                    string[] claimEndpointNames =
                        authorizationSegments.FirstOrDefault()?.ClaimsEndpoints.Select(x => x.Name).ToArray()
                        ?? Array.Empty<string>();

                    // NOTE: Embedded convention - UniqueId is suffix used for external representation of USI values
                    string[] subjectEndpointNames = authorizationSegments
                        .Select(x => x.SubjectEndpoint.Name.ReplaceSuffix("USI", "UniqueId"))
                        .ToArray();

                    string claimEndpointNamesText = $"'{string.Join("', '", claimEndpointNames)}'";
                    string subjectEndpointNamesText = $"'{string.Join("', '", subjectEndpointNames)}'";
                    
                    string claimOrClaims = Inflector.Inflect("claim", claimEndpointNames.Length);
                    string doOrDoes = Inflector.Inflect("ignored", claimEndpointNames.Length, "does", "do");
                    string relationshipOrRelationships = Inflector.Inflect("relationship", subjectEndpointNames.Length);

                    throw new EdFiSecurityException(
                        $"Authorization denied. The education organization {claimOrClaims} ({claimEndpointNamesText}) {doOrDoes} not have the necessary {relationshipOrRelationships} (with {subjectEndpointNamesText}) required to access the requested resource.");

                    // throw new EdFiSecurityException(
                    //     "Authorization denied.  The claim does not have any established relationships with the requested resource. ");
                }
            }
        }
    }
}
