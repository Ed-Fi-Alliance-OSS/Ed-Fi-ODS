// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public static void ShouldContainTuples<T1, T2>(IDbConnection connection,
            PersonType personType, params (T1, T2)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView<T1, T2>(connection, personType);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples<T1, T2>(IDbConnection connection,
            PersonType personType, params (T1, T2)[] expectedTuples)
        {
            var actualTuples = GetExistingRecordsInAuthorizationView<T1, T2>(connection, personType);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }

        public static int GetStudentUsi(IDbConnection connection, string studentUniqueId)
        {
            return GetPersonUsi(connection, PersonType.Student, studentUniqueId);
        }

        public static int GetContactUsi(IDbConnection connection, string contactUniqueId)
        {
            return GetPersonUsi(connection, PersonType.Contact, contactUniqueId);
        }

        public static int GetStaffUsi(IDbConnection connection, string staffUniqueId)
        {
            return GetPersonUsi(connection, PersonType.Staff, staffUniqueId);
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


        private static IEnumerable<(T1, T2)> GetExistingRecordsInAuthorizationView<T1, T2>(IDbConnection connection, PersonType personType)
        {
            var viewName = $"EducationOrganizationIdTo{personType}USI";

            return GetRecordsForAuthorizationView<T1, T2>(connection, viewName);
        }

        private static bool IsDuplicateRecordExistForAuthorizationView(IDbConnection connection, PersonType personType)
        {
            var sql = @$"
                SELECT COUNT(*)
                FROM auth.EducationOrganizationIdTo{personType}USI
                GROUP BY SourceEducationOrganizationId, {personType}USI
                HAVING COUNT(*) > 1;";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }

        private static IEnumerable<(T1, T2)> GetRecordsForAuthorizationView<T1, T2>(IDbConnection connection, string viewName)
        {
            var sql = @$"SELECT * FROM auth.{viewName}";

            using var command = connection.CreateCommand();
            command.CommandText = sql;

            using var reader = command.ExecuteReader();
            var result = new List<(T1, T2)>();

            while (reader.Read())
            {
                var value1 = (T1)reader.GetValue(0);
                var value2 = (T2)reader.GetValue(1);
                result.Add((value1, value2));
            }

            return result;
        }

        public static bool HasDuplicateRecordsForAuthorizationView<T1, T2>(IDbConnection connection, string viewName)
        {
            return GetRecordsForAuthorizationView<T1, T2>(connection, viewName).GroupBy(
                x => new
                {
                    x.Item1,
                    x.Item2
                }).Any(x => x.Count() > 1);
        }

        public static void ShouldContainTuples<T1, T2>(
            IDbConnection connection,
            string viewName,
            params (T1, T2)[] expectedTuples)
        {
            var actualTuples = GetRecordsForAuthorizationView<T1, T2>(connection, viewName);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples<T1, T2>(
            IDbConnection connection,
            string viewName,
            params (T1, T2)[] expectedTuples)
        {
            var actualTuples = GetRecordsForAuthorizationView<T1, T2>(connection, viewName);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }
    }
}
