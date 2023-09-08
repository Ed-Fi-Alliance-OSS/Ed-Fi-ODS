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
    public static class EducationOrganizationHelper
    {
        public static List<(long, long)> GetExistingTuples(IDbConnection connection)
        {
            var sql = @"
        SELECT SourceEducationOrganizationId, TargetEducationOrganizationId
        FROM auth.EducationOrganizationIdToEducationOrganizationId;";

            using var command = connection.CreateCommand();
            command.CommandText = sql;

            using var reader = command.ExecuteReader();

            var actualTuples = new List<(long, long)>();
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
                
                actualTuples.Add((value1, value2));
            }

            return actualTuples;
        }

        public static void ShouldContainTuples(IDbConnection connection, params (long, long)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples(connection);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples(IDbConnection connection, params (long, long)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples(connection);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }
    }
}
