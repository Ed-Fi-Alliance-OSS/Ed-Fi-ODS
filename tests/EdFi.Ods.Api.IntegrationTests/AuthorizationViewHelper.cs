// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Api.Common.Models.Resources.Person.EdFi;
using Shouldly;

namespace EdFi.Ods.Api.IntegrationTests
{
    public static class AuthorizationViewHelper
        {
            public static void ShouldNotContainDuplicate(IDbConnection connection, PersonType contactPersonType)
            {
                var actualTuples = IsDuplicateRecordExistForAuthorizationView(connection, contactPersonType);
                actualTuples.ShouldBeFalse();
            }

            public static void ShouldContainTuples<T1, T2>(IDbConnection connection,
                PersonType contactPersonType, params (T1, T2)[] expectedTuples)
            {
                var actualTuples = GetExistingRecordsInAuthorizationView<T1, T2>(connection, contactPersonType);
                expectedTuples.ShouldBeSubsetOf(actualTuples);
            }

            public static void ShouldNotContainTuples<T1, T2>(IDbConnection connection,
                PersonType contactPersonType, params (T1, T2)[] expectedTuples)
            {
                var actualTuples = GetExistingRecordsInAuthorizationView<T1, T2>(connection, contactPersonType);
                expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
            }

            public static int GetPersonUsi(IDbConnection connection, PersonType contactPersonType, string target)
            {
                var sql = $@"SELECT {contactPersonType}USI FROM edfi.{contactPersonType}
                    WHERE {contactPersonType}UniqueId = '{target}';";

                using var command = connection.CreateCommand();
                command.CommandText = sql;
                var result = Convert.ToInt32(command.ExecuteScalar());

                return result;
            }

            private static IEnumerable<(T1, T2)> GetExistingRecordsInAuthorizationView<T1, T2>(IDbConnection connection, PersonType contactPersonType)
            {
                var viewName = $"EducationOrganizationIdTo{contactPersonType}USI";

                return GetRecordsForAuthorizationView<T1, T2>(connection, viewName);
            }

            private static bool IsDuplicateRecordExistForAuthorizationView(IDbConnection connection, PersonType contactPersonType)
            {
                var sql = @$"
                    SELECT COUNT(*)
                    FROM auth.EducationOrganizationIdTo{contactPersonType}USI
                    GROUP BY SourceEducationOrganizationId, {contactPersonType}USI
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
            
            // This is used to provide compatability with data standards <v5.0 where the Contact is named Parent 
            public static PersonType GetContactPersonType(IDbConnection connection)
            {
                var sql = $@"   SELECT COUNT(*)
                    FROM information_schema.tables 
                    WHERE  table_schema = 'edfi'
                    AND    table_name   = 'Parent';";

                using var command = connection.CreateCommand();
                command.CommandText = sql;
                var result = Convert.ToInt32(command.ExecuteScalar());

                return result > 0 ? PersonType.Parent : PersonType.Contact;
            }
        }
}
