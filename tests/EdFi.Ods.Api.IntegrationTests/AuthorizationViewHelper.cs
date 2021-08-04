// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using Shouldly;
namespace EdFi.Ods.Api.IntegrationTests
{
    public static class AuthorizationViewHelper
    {
        public static void ShouldNotContainDuplicate(IDbConnection connection, PersonType personType)
        {
            var actualTuples = IsDuplicateRecordExistForAuthorizationView(connection, personType);
            actualTuples.ShouldBeFalse();
        }

        public static void ShouldContainTuples(IDbConnection connection,
            PersonType personType, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView(connection, personType);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples(IDbConnection connection,
            PersonType personType, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView(connection, personType);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }

        public static int GetStudentUsi(IDbConnection connection, string studentUniqueId)
        {
            return GetPersonUsi(connection, PersonType.Student, studentUniqueId);
        }

        public static int GetParentUsi(IDbConnection connection, string parentUniqueId)
        {
            return GetPersonUsi(connection, PersonType.Parent, parentUniqueId);
        }

        private static int GetPersonUsi(IDbConnection connection, PersonType personType, string target)
        {
            var sql = $@"SELECT {personType}USI FROM edfi.{personType}
                WHERE {personType}UniqueId = '{target}';";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            var result = Convert.ToInt32(command.ExecuteScalar());

            return result;
        }

        private static List<(int, int)> GetExistingRecordsInAuthorizationView(IDbConnection connection, PersonType personType)
        {
            var sql = @$"
                SELECT SourceEducationOrganizationId, {personType}USI 
                FROM auth.{personType}USIToEducationOrganizationId";

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

        private static bool IsDuplicateRecordExistForAuthorizationView(IDbConnection connection, PersonType personType)
        {
            var sql = @$"
                SELECT COUNT(*)
                FROM auth.{personType}USIToEducationOrganizationId 
                GROUP BY SourceEducationOrganizationId,{personType}USI 
                HAVING COUNT(*) > 1;";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
