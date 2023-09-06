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

            public static void ShouldContainTuples(IDbConnection connection,
                PersonType contactPersonType, params (long, long)[] expectedTuples)
            {
                var actualTuples = GetExistingRecordsInAuthorizationView(connection, contactPersonType);
                expectedTuples.ShouldBeSubsetOf(actualTuples);
            }

            public static void ShouldNotContainTuples(IDbConnection connection,
                PersonType contactPersonType, params (long, long)[] expectedTuples)
            {
                var actualTuples = GetExistingRecordsInAuthorizationView(connection, contactPersonType);
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

            private static IEnumerable<(long, long)> GetExistingRecordsInAuthorizationView(IDbConnection connection, PersonType contactPersonType)
            {
                var viewName = $"EducationOrganizationIdTo{contactPersonType}USI";

                return GetRecordsForAuthorizationView(connection, viewName);
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

            private static IEnumerable<(long, long)> GetRecordsForAuthorizationView(IDbConnection connection, string viewName)
            {
                var sql = @$"SELECT * FROM auth.{viewName}";

                using var command = connection.CreateCommand();
                command.CommandText = sql;

                using var reader = command.ExecuteReader();
                var result = new List<(long, long)>();

                while (reader.Read())
                {
                    long value1;
                    long value2;
                    
                    if (reader.GetFieldType(0).Name == "Int64")
                    {
                        value1 = reader.GetInt64(0);
                    }
                    else if (reader.GetFieldType(0).Name == "Int32")
                    {
                        value1 = reader.GetInt32(0);
                    }
                    else
                    {
                        throw new Exception("Unexpected data type in authorization view column 1");
                    }
                    
                    if (reader.GetFieldType(1).Name == "Int64")
                    {
                        value2 = reader.GetInt64(1);
                    }
                    else if (reader.GetFieldType(1).Name == "Int32")
                    {
                        value2 = reader.GetInt32(1);
                    }
                    else
                    {
                        throw new Exception("Unexpected data type in authorization view column 1");
                    }
                   
                    result.Add((value1, value2));
                }

                return result;
            }

            public static bool HasDuplicateRecordsForAuthorizationView<T1, T2>(IDbConnection connection, string viewName)
            {
                return GetRecordsForAuthorizationView(connection, viewName).GroupBy(
                    x => new
                    {
                        x.Item1,
                        x.Item2
                    }).Any(x => x.Count() > 1);
            }

            public static void ShouldContainTuples(
                IDbConnection connection,
                string viewName,
                params (long, long)[] expectedTuples)
            {
                var actualTuples = GetRecordsForAuthorizationView(connection, viewName);
                expectedTuples.ShouldBeSubsetOf(actualTuples);
            }

            public static void ShouldNotContainTuples(
                IDbConnection connection,
                string viewName,
                params (long, long)[] expectedTuples)
            {
                var actualTuples = GetRecordsForAuthorizationView(connection, viewName);
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
