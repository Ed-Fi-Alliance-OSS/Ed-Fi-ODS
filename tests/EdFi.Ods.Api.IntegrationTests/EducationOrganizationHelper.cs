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
        public static List<(int, int)> GetExistingTuples(IDbConnection connection)
        {
            var sql = @"
                SELECT SourceEducationOrganizationId, TargetEducationOrganizationId
                FROM auth.EducationOrganizationIdToEducationOrganizationId;";

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

        public static void ShouldContainTuples(IDbConnection connection, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples(connection);
            expectedTuples.ShouldBeSubsetOf(actualTuples);
        }

        public static void ShouldNotContainTuples(IDbConnection connection, params (int, int)[] expectedTuples)
        {
            var actualTuples = GetExistingTuples(connection);
            expectedTuples.ShouldAllBe(item => !actualTuples.Contains(item));
        }

        public static bool QueryEducationOrganizationIdToToEducationOrganizationId(IDbConnection connection, (int, int) sourceTargetTuple)
        {
            (int source, int target) = sourceTargetTuple;

            var sql = @$"
                SELECT COUNT(*)
                FROM auth.EducationOrganizationIdToEducationOrganizationId
                WHERE SourceEducationOrganizationId = {source} AND TargetEducationOrganizationId = {target};";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
