// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data.Common;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization
{
    public interface IAuthorizationSegmentsSqlProvider
    {
        QueryMetadata GetAuthorizationQueryMetadata(
            IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments,
            ref int parameterIndex);
    }

    public class QueryMetadata
    {
        public QueryMetadata(string sql, DbParameter[] parameters)
        {
            Sql = sql;
            Parameters = parameters;
        }

        public string Sql { get; }
        public DbParameter[] Parameters { get; }
    }
}
