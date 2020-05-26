// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using EdFi.Ods.Common.Security.Authorization;
using Npgsql;

namespace EdFi.Ods.Security.Authorization
{
    public class PostgresAuthorizationSegmentSqlProvider : AuthorizationSegmentSqlProviderBase
    {
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
