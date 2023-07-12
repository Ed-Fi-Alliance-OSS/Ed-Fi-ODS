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
        public static List<(T1, T2)> GetExistingTuples<T1, T2>(IDbConnection connection)
        {
            var sql = @"
        SELECT SourceEducationOrganizationId, TargetEducationOrganizationId
        FROM auth.EducationOrganizationIdToEducationOrganizationId;";

            using var command = connection.CreateCommand();
            command.CommandText = sql;

            using var reader = command.ExecuteReader();

            var actualTuples = new List<(T1, T2)>();
            while (reader.Read())
            {
                var value1 = (T1)reader.GetValue(0);
                var value2 = (T2)reader.GetValue(1);
                actualTuples.Add((value1, value2));
            }

            return actualTuples;
        }

        public static void ShouldContainTuples<T1, T2>(IDbConnection connection, params (T1, T2)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples<T1, T2>(connection);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples<T1, T2>(IDbConnection connection, params (T1, T2)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples<T1, T2>(connection);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }
    }
}
