// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Shouldly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace EdFi.Ods.Api.IntegrationTests
{
    public static class AuthorizationViewHelper
    {

        public static void ShouldNotContainDuplicate(IDbConnection connection,
            string viewName, PersonType personType,
            int target, int countValue, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView(connection, viewName, personType, target);

            actualTuples.Count().ShouldBe(countValue);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldContainTuples(IDbConnection connection, string viewName,
            PersonType personType, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView(connection, viewName, personType);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples(IDbConnection connection, string viewName,
            PersonType personType, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView(connection, viewName, personType);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }

        public static int GetStudentUSI(IDbConnection connection, string studentUniqueId)
        {
            return ExecuteScalar(connection, PersonType.Student, studentUniqueId);
        }

        public static int GetParentUSI(IDbConnection connection, string parentUniqueId)
        {
            return ExecuteScalar(connection,PersonType.Parent, parentUniqueId);
        }

        private static int ExecuteScalar(IDbConnection connection, PersonType personType, string target)
        {
            var sql = $@"SELECT {personType}USI FROM edfi.{personType}
                WHERE {personType}UniqueId = '{target}';";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            var result = Convert.ToInt32(command.ExecuteScalar());

            return result;
        }

        private static List<(int, int)> GetExistingRecordsInAuthorizationView(IDbConnection connection,
            string viewName, PersonType personType, int? target = null)
        {
            string sql = @$"SELECT SourceEducationOrganizationId, {personType}USI FROM auth.{viewName}";

            if (target.HasValue)
            {
                sql += @$" WHERE {personType}USI = '{target}';";
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
    }
}
