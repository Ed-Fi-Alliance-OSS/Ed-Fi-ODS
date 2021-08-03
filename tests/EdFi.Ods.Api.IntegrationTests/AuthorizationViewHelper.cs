// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Shouldly;
using System;
using System.Collections.Generic;
using System.Data;
namespace EdFi.Ods.Api.IntegrationTests
{
    public static class AuthorizationViewHelper
    {

        private static bool QueryAuthorizationByViewName(IDbConnection connection, string  viewName)
        {
            string subSql = "";
            if(viewName.Equals("StudentUSIToEducationOrganizationId",StringComparison.OrdinalIgnoreCase))
            {
                subSql= " GROUP BY SourceEducationOrganizationId,studentUSI  HAVING COUNT(*)> 1;";
            }
            else if (viewName.Equals("ParentUSIToEducationOrganizationId", StringComparison.OrdinalIgnoreCase))
            {
                subSql = " GROUP BY SourceEducationOrganizationId,ParentUSI  HAVING COUNT(*)> 1;";
            }

            var sql = @$"
                SELECT COUNT(*)
                FROM auth." + viewName + subSql;
            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }

        private static List<(int, int)> GetExistingRecordsInAuthorizationView(IDbConnection connection, string viewName)
        {
            string sql = "";
            if (viewName.Equals("StudentUSIToEducationOrganizationId", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
                SELECT SourceEducationOrganizationId, StudentUSI
                FROM auth.StudentUSIToEducationOrganizationId;";
            }
            else if (viewName.Equals("ParentUSIToEducationOrganizationId", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
                SELECT SourceEducationOrganizationId, parentUSI
                FROM auth.ParentUSIToEducationOrganizationId;";
            }

            using var command = connection.CreateCommand();
            command.CommandText = sql;

            using var reader = command.ExecuteReader();

            var actualTuples = new List<(int, int)>();
            while (reader.Read())
            {
                actualTuples.Add((reader.GetInt32(0), reader.GetInt32(1)));
            }
            return actualTuples;
        }


        public static void ShouldNotContainDuplicate(IDbConnection connection, string viewName)
        {
            var actualTuples = QueryAuthorizationByViewName(connection,viewName);
            actualTuples.ShouldBeFalse();
        }

        public static void ShouldContainTuples(IDbConnection connection, string viewName, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView(connection, viewName);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples(IDbConnection connection, string viewName, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView(connection, viewName);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }

        public static int GetStudentUSI(IDbConnection connection, string studentUniqueId)
        {
            var sql = $@"SELECT StudentUSI FROM edfi.Student
                WHERE StudentUniqueId = '{studentUniqueId}';";

            return ExecuteScalar(connection, sql);
        }

        public static int GetParentUSI(IDbConnection connection, string parentUniqueId)
        {
            var sql = $@"SELECT ParentUSI FROM edfi.Parent
                WHERE ParentUniqueId = '{parentUniqueId}';";

            return ExecuteScalar(connection, sql);
        }

        private static int ExecuteScalar(IDbConnection connection, string sql)
        {
            using var command = connection.CreateCommand();
            command.CommandText = sql;
            var result = Convert.ToInt32(command.ExecuteScalar());

            return result;
        }

    }
}
