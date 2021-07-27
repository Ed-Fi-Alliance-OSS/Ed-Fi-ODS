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

        public static bool QueryAuthorizationByViewName(IDbConnection connection, string  viewName)
        {          
            var sql = @$"
                SELECT COUNT(*)
                FROM auth."+ viewName +
                " GROUP BY SourceEducationOrganizationId,TargetEducationOrganizationId HAVING COUNT(*)> 1;";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return 1 == Convert.ToInt32(command.ExecuteScalar());
        }

        //public static bool RecordExistInAuthorizationByViewName(IDbConnection connection, string viewName, (int, int) sourceTargetTuple)
        //{
        //    (int source, int target) = sourceTargetTuple;

        //    var sql = @$"
        //        SELECT COUNT(*)
        //        FROM auth." + viewName +
        //        " WHERE  SourceEducationOrganizationId ="+ source +" AND TargetEducationOrganizationId ="+ target +";";

        //    using var command = connection.CreateCommand();
        //    command.CommandText = sql;
        //    return 1 == Convert.ToInt32(command.ExecuteScalar());
        //}


        public static List<int> GetRecordsInAuthorizationView(IDbConnection connection, string viewName, (int, int) sourceTargetTuple)
        {
            (int source, int target) = sourceTargetTuple;

            string sqlQuery = "";
            if (source != 0)
            {
                sqlQuery= "SourceEducationOrganizationId =" + source + " AND ";
            }
   
            sqlQuery += "TargetEducationOrganizationId =" + target + ";";

            var sql = @$"
                SELECT SourceEducationOrganizationId
                FROM auth." + viewName + " WHERE " + sqlQuery;

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            using var reader = command.ExecuteReader();

            var sourceList = new List<int>();
            while (reader.Read())
            {
                sourceList.Add(reader.GetInt32(0));
            }
            return sourceList;
        }

        public static int GetStudentUSI(IDbConnection connection, string studentUniqueID)
        {
            var sql = @$"
                SELECT StudentUSI FROM edfi.Student
                WHERE StudentUniqueId = '"+ studentUniqueID +"';";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static void ShouldNotContainDuplicate(IDbConnection connection, string viewName)
        {
            var actualTuples = QueryAuthorizationByViewName(connection,viewName);
            actualTuples.ShouldBeFalse();
        }

        public static void ShouldContainStudentInSchoolOrDistrict(IDbConnection connection, string viewName , params (int, int)[] expectedTuples)
        {
            foreach (var eachTuple in expectedTuples)
            {
                (int source, int target) = eachTuple;
                var actualTuples = GetRecordsInAuthorizationView(connection, viewName, eachTuple);
                actualTuples.All(p => p == source).ShouldBeTrue();
            }
        }

        public static void ShouldContainStudentInBothSchool(IDbConnection connection, string viewName, params (int, int)[]  expectedTuples)
        {
            foreach (var eachTuple in expectedTuples)
            {
                (int source, int target) = eachTuple;
                var actualTuples = GetRecordsInAuthorizationView(connection, viewName, eachTuple);
                actualTuples.All(p => p == source).ShouldBeTrue();
            }
        }

        public static void ShouldNotContainStudentInOtherSchoolOrDistrict(IDbConnection connection, string viewName, params (int, int)[] sourceTargetTuple)
        {
            foreach (var eachTuple in sourceTargetTuple)
            {
                (int source, int target) = eachTuple;
                var actualTuples = GetRecordsInAuthorizationView(connection, viewName, eachTuple);
                actualTuples.All(p => p == source).ShouldBeTrue();
            }
        }

        public static void ShouldNotContainStudentInAnySchool(IDbConnection connection, string viewName, (int, int) sourceTargetTuple)
        {
            var actualTuples = GetRecordsInAuthorizationView(connection, viewName, sourceTargetTuple);
            actualTuples.ShouldBeEmpty();
        }
    }
}
