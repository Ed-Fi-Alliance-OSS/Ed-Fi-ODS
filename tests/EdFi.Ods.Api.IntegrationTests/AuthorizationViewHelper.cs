// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using Shouldly;
using System.Linq;
namespace EdFi.Ods.Api.IntegrationTests
{
    public static class AuthorizationViewHelper
    {
        public static List<EdFiTuple> GetAllRecordsInAuthorizationViewByTarget(IDbConnection connection, string viewName, string target, PersonType personType)
        {
            var sql = @$"
                SELECT SourceEducationOrganizationId, b.{personType}USI
                FROM auth.{viewName} a INNER JOIN edfi.{personType} b ON a.{personType}USI = b.{personType}USI
                WHERE b.{personType}UniqueId = '{target}'";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            using var reader = command.ExecuteReader();

            var sourceList = new List<EdFiTuple>();

            while (reader.Read())
            {
                sourceList.Add(EdFiTuple.Create(reader.GetInt32(0), reader.GetInt32(1)));
            }

            return sourceList;
        }

        public static void ShouldContainStaffInSchoolOrDistrict(IDbConnection connection, string viewName, string target, List<int> expectedSources)
        {
            var tuples = GetAllRecordsInAuthorizationViewByTarget(connection, viewName, target, PersonType.Staff);

            var actualSources = tuples.Where(s => expectedSources.Contains(s.Source)).ToList();

            actualSources.Count.ShouldBe(expectedSources.Count);
        }
        public static void ShouldNotContainStaffInOtherSchoolOrDistrict(IDbConnection connection, string viewName, string target, List<int> expectedSources)
        {
            var tuples = GetAllRecordsInAuthorizationViewByTarget(connection, viewName, target, PersonType.Staff);

            var unexpectedSources = tuples.Where(s => !expectedSources.Contains(s.Source)).ToList();

            unexpectedSources.ShouldBeEmpty();
        }

        public static void ShouldNotHaveDuplicateStaffSegments(IDbConnection connection, string viewName, string target, List<int> expectedSources)
        {
            var tuples = GetAllRecordsInAuthorizationViewByTarget(connection, viewName, target, PersonType.Staff);

            tuples.Count().ShouldBe(2);
            tuples.ShouldContain(s => expectedSources.Contains(s.Source));
        }
    }
}
