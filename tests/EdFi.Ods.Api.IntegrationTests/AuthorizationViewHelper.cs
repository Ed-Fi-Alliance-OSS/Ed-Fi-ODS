// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using Shouldly;
namespace EdFi.Ods.Api.IntegrationTests
{
    public static class AuthorizationViewHelper
    {

        public static bool QueryAuthorizationByViewName(IDbConnection connection, string  viewName)
        {          
            var sql = @$"
                SELECT COUNT(*)
                FROM auth."+ viewName +
                " GROUP BY SourceEducationOrganizationId,TargetEducationOrganizationId HAVING COUNT(*)> 1;";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }

        public static void ShouldNotContainDuplicate(IDbConnection connection, string viewName)
        {
            var actualTuples = QueryAuthorizationByViewName(connection,viewName);
            actualTuples.ShouldBeFalse();
        }
    }
}
