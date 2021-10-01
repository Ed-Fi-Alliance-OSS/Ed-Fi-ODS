// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Api.Security.Utilities;
using Npgsql;

namespace EdFi.Ods.Api.Security.Authorization
{
    public class PostgresAuthorizationSegmentSqlProvider : AuthorizationSegmentSqlProviderBase
    {
        public PostgresAuthorizationSegmentSqlProvider(IAuthorizationTableViewsProvider authorizationViewsProvider)
            : base(authorizationViewsProvider)
        {
        }

        protected override DbParameter CreateParameter(
            string parameterName,
            AuthorizationSegmentEndpointWithValue segmentEndpoint)
        {
            return new NpgsqlParameter
            {
                ParameterName = parameterName,
                Value = segmentEndpoint.Value
            };
        }
    }
}
