// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using NHibernate;

namespace EdFi.Ods.Security.Authorization
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
        public async Task VerifyAsync(AuthorizationSegmentCollection authorizationSegments, CancellationToken cancellationToken)
        {
            if (authorizationSegments == null)
            {
                throw new ArgumentNullException(nameof(authorizationSegments));
            }

            if (!authorizationSegments.ClaimsAuthorizationSegments.Any()
                && !authorizationSegments.ExistingValuesAuthorizationSegments.Any())
            {
                throw new ArgumentException("No authorization segments have been defined.");
            }

            using (var session = _sessionFactory.OpenStatelessSession())
            {
                var cmd = session.Connection.CreateCommand();

                int parameterIndex = 0;

                var parametersByAuthorizationSql =
                    _authorizationSegmentsSqlProvider.BuildAuthorization(authorizationSegments, ref parameterIndex);

                cmd.CommandText = parametersByAuthorizationSql.Key;

                cmd.Parameters.AddRange(parametersByAuthorizationSql.Value);

                var result = (int?) await cmd.ExecuteScalarAsync(cancellationToken);

                cmd.Parameters.Clear();

                if (result == null)
                {
                    throw new EdFiSecurityException(
                        "Authorization denied.  The claim does not have any established relationships with the requested resource.");
                }
            }
        }
    }
}
