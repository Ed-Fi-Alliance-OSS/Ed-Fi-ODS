// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using Newtonsoft.Json;
using Npgsql;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database.Querying
{
    [TestFixture]
    public class When_building_sql
    {
        [TestCase(DatabaseEngine.MsSql)]
        [TestCase(DatabaseEngine.PgSql)]
        public void Should_select_columns(DatabaseEngine databaseEngine)
        {
            var q = new QueryBuilder(GetDialectFor(databaseEngine))
                .From("edfi.EducationOrganization")
                .Select("NameOfInstitution", "WebSite");

            var template = q.BuildTemplate();

            template.RawSql.NormalizeSql()
                .ShouldBe("SELECT NameOfInstitution, WebSite FROM edfi.EducationOrganization");
            
            ExecuteQueryAndWriteResults(databaseEngine, template);
            
            // Check the cloned query results
            var clonedQueryResult = q.Clone().BuildTemplate();
            template.RawSql.ShouldBe(clonedQueryResult.RawSql);
        }

        public class With_group_by
        {
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_group_by_with_raw_aggregates(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("tracked_changes_edfi.student AS c")
                    .Select("c.Id")
                    .SelectRaw($"MIN(c.ChangeVersion) AS initialChangeVersion")
                    .SelectRaw($"MAX(c.ChangeVersion) AS finalChangeVersion")
                    .GroupBy("c.Id");
                
                var template = q.BuildTemplate();

                template.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql()
                        .ShouldBe(@"
                    SELECT  c.Id, MIN(c.ChangeVersion) AS initialChangeVersion, MAX(c.ChangeVersion) AS finalChangeVersion 
                    FROM    tracked_changes_edfi.student AS c
                    GROUP BY c.Id".NormalizeSql()));
                
                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_group_by_on_multiple_columns(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.student")
                    .Select("FirstName")
                    .Select("LastSurname")
                    .SelectRaw("COUNT(1) AS RecordCount")
                    .GroupBy("LastSurname")
                    .GroupBy("FirstName")
                    .OrderBy("LastSurname DESC");
                
                var template = q.BuildTemplate();

                template.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql()
                        .ShouldBe(@"
                    SELECT  FirstName, LastSurname, COUNT(1) AS RecordCount 
                    FROM    edfi.student
                    GROUP BY LastSurname, FirstName
                    ORDER BY LastSurname DESC".NormalizeSql()));

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
        }

        public class With_where_clauses
        {
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_where_with_null(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname")
                    .Where("BirthCity", "Chicago")
                    .WhereNull("MiddleName");
                
                var template = q.BuildTemplate();

                template.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql()
                        .ShouldBe(@"
                    SELECT  FirstName, LastSurname 
                    FROM    edfi.Student
                    WHERE   BirthCity = @p0
                            AND MiddleName IS NULL".NormalizeSql()));

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_where_with_not_null(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname", "BirthCity")
                    .WhereLike("LastSurname", "Le%")
                    .WhereNotNull("BirthCity");
                
                var template = q.BuildTemplate();

                template.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql()
                        .ShouldBe(@"
                    SELECT  FirstName, LastSurname, BirthCity 
                    FROM    edfi.Student
                    WHERE   LastSurname LIKE @p0 AND BirthCity IS NOT NULL".NormalizeSql()));

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_where_with_exact_match_Date_value(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname")
                    .Where("BirthDate", new DateTime(2016,09,01));

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql()
                        .ShouldBe(@"
                    SELECT  FirstName, LastSurname 
                    FROM    edfi.Student
                    WHERE   BirthDate = @p0".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("p0"),
                    () => actualParameters.Get<DateTime>("@p0").ShouldBe(new DateTime(2016,09,01))
                    );

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }

            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_where_with_exact_match_string_value(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname")
                    .Where("BirthCity", "Chicago");

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    SELECT  FirstName, LastSurname 
                    FROM    edfi.Student
                    WHERE   BirthCity = @p0".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("p0"),
                    () => actualParameters.Get<string>("@p0").ShouldBe("Chicago"));

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_where_with_like_with_implicit_parameter(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname")
                    .WhereLike("BirthCity", "%ago%")
                    .WhereLike("BirthCity", "Chi%");

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    SELECT  FirstName, LastSurname 
                    FROM    edfi.Student
                    WHERE   BirthCity LIKE @p0 AND BirthCity LIKE @p1".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("p0"),
                    () => actualParameters.Get<string>("@p0").ShouldBe("%ago%"),
                    () => actualParameters.ParameterNames.ShouldContain("p1"),
                    () => actualParameters.Get<string>("@p1").ShouldBe("Chi%"));

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_where_with_any_like_with_implicit_parameter(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname")
                    .Select("BirthCity")
                    .WhereLike("BirthCity", "Chi%")
                    .OrWhereLike("BirthCity", "%ago%")
                    .OrWhereLike("BirthCity", "%na");

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    SELECT  FirstName, LastSurname, BirthCity 
                    FROM    edfi.Student
                    WHERE   BirthCity LIKE @p0 AND (BirthCity LIKE @p1 OR BirthCity LIKE @p2)".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("p0"),
                    () => actualParameters.Get<string>("@p0").ShouldBe("Chi%"),
                    () => actualParameters.ParameterNames.ShouldContain("p1"),
                    () => actualParameters.Get<string>("@p1").ShouldBe("%ago%"),
                    () => actualParameters.ParameterNames.ShouldContain("p2"),
                    () => actualParameters.Get<string>("@p2").ShouldBe("%na"));
                
                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql, "@p0")]
            [TestCase(DatabaseEngine.PgSql, "(VALUES (@p0_0), (@p0_1), (@p0_2), (@p0_3))")]
            public void Should_apply_where_with_IN(DatabaseEngine databaseEngine, string expectedInClause)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.StudentSchoolAssociation")
                    .Select("StudentUSI", "SchoolId", "EntryDate")
                    .WhereIn("StudentUSI", new [] { 12, 34, 56, 78 });

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@$"
                    SELECT  StudentUSI, SchoolId, EntryDate 
                    FROM    edfi.StudentSchoolAssociation
                    WHERE   StudentUSI IN {expectedInClause}".NormalizeSql()) //,
                    // () => actualParameters.ShouldNotBeNull(),
                    // () => actualParameters.ParameterNames.Count().ShouldBe(1),
                    // () => actualParameters.ParameterNames.ShouldContain("p0"),
                    // () => actualParameters.Get<int[]>("@p0").ShouldBe(new [] {12, 34, 56, 78})
                    );

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }

            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_where_with_explicit_comparison_operators(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname")
                    .Select("ChangeVersion")
                    .Where("ChangeVersion", ">", 10000)
                    .Where("ChangeVersion", "<", 11000);

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    SELECT  FirstName, LastSurname, ChangeVersion 
                    FROM    edfi.Student
                    WHERE   ChangeVersion > @p0
                            AND ChangeVersion < @p1".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("p0"),
                    () => actualParameters.Get<int>("@p0").ShouldBe(10000),
                    () => actualParameters.ParameterNames.ShouldContain("p1"),
                    () => actualParameters.Get<int>("@p1").ShouldBe(11000)
                    );

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }

            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_nested_conjunction_combined_with_a_disjunction(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname", "ChangeVersion")
                    .Where(
                        q => q.OrWhere(q2 => q2.Where("ChangeVersion", ">=", 10000).Where("ChangeVersion", "<=", 11000))
                            .OrWhereNull("ChangeVersion"));

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    SELECT  FirstName, LastSurname, ChangeVersion
                    FROM    edfi.Student
                    WHERE   (((ChangeVersion >= @p0 AND ChangeVersion <= @p1) 
                            OR ChangeVersion IS NULL))".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("p0"),
                    () => actualParameters.Get<int>("@p0").ShouldBe(10000),
                    () => actualParameters.ParameterNames.ShouldContain("p1"),
                    () => actualParameters.Get<int>("@p1").ShouldBe(11000)
                    );

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_nested_conjunction_combined_with_a_disjunction_with_auto_named_parameters(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname", "ChangeVersion")
                    .Where(
                        q => q.OrWhere(q2 => q2.Where("ChangeVersion", ">=", 10000).Where("ChangeVersion", "<=", 11000))
                            .OrWhereNull("ChangeVersion"));

                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    SELECT  FirstName, LastSurname, ChangeVersion
                    FROM    edfi.Student
                    WHERE   (((ChangeVersion >= @p0 AND ChangeVersion <= @p1) 
                            OR ChangeVersion IS NULL))".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("p0"),
                    () => actualParameters.Get<int>("@p0").ShouldBe(10000),
                    () => actualParameters.ParameterNames.ShouldContain("p1"),
                    () => actualParameters.Get<int>("@p1").ShouldBe(11000)
                    );

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }

            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_nested_conjunction_combined_with_a_disjunction_with_explicitly_named_parameters(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("FirstName", "LastSurname", "ChangeVersion")
                    .Where(
                        q => q.OrWhere(q2 =>
                                q2.Where("ChangeVersion", ">=", new Parameter("@MinChangeVersion", 10000))
                                    .Where("ChangeVersion", "<=", new Parameter( "@MaxChangeVersion", 11000)))
                            .OrWhereNull("ChangeVersion"));
                
                var template = q.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    SELECT  FirstName, LastSurname, ChangeVersion 
                    FROM    edfi.Student
                    WHERE   (((ChangeVersion >= @MinChangeVersion AND ChangeVersion <= @MaxChangeVersion) 
                            OR ChangeVersion IS NULL))".NormalizeSql()),
                    () => actualParameters.ShouldNotBeNull(),
                    () => actualParameters.ParameterNames.ShouldContain("MinChangeVersion"),
                    () => actualParameters.Get<int>("@MinChangeVersion").ShouldBe(10000),
                    () => actualParameters.ParameterNames.ShouldContain("MaxChangeVersion"),
                    () => actualParameters.Get<int>("@MaxChangeVersion").ShouldBe(11000)
                    );
                
                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
        }

        public class With_paging
        {
            [TestCase(DatabaseEngine.MsSql, "OFFSET 50 ROWS FETCH NEXT 5 ROWS ONLY")]
            [TestCase(DatabaseEngine.PgSql, "LIMIT 5 OFFSET 50")]
            public void Should_page_using_limit_and_offset_correctly(DatabaseEngine databaseEngine, string pagingSql)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.Student")
                    .Select("*")
                    .OrderBy("LastSurname DESC", "FirstName")
                    .LimitOffset(5 ,50);

                var template = q.BuildTemplate();
            
                template.RawSql.NormalizeSql()
                    .ShouldBe($"SELECT * FROM edfi.Student ORDER BY LastSurname DESC, FirstName {pagingSql}");

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
        }
        
        public class With_joins
        {
            [TestCase(DatabaseEngine.MsSql, "OFFSET 25 ROWS FETCH NEXT 5 ROWS ONLY")]
            [TestCase(DatabaseEngine.PgSql, "LIMIT 5 OFFSET 25")]
            public void Should_apply_single_column_inner_joins(DatabaseEngine databaseEngine, string pagingSql)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("edfi.StudentSchoolAssociation AS ssa")
                    .Select("s.FirstName", "s.LastSurname", "edOrg.NameOfInstitution", "ssa.EntryDate")
                    .Join("edfi.Student s", "ssa.StudentUSI", "s.StudentUSI")
                    .Join("edfi.EducationOrganization edOrg", "ssa.SchoolId", "edOrg.EducationOrganizationId")
                    .OrderBy("s.LastSurname")
                    .LimitOffset(5, 25);

                var template = q.BuildTemplate();

                template.RawSql.NormalizeSql()
                    .ShouldBe(@$"
                    SELECT  s.FirstName, s.LastSurname, edOrg.NameOfInstitution, ssa.EntryDate 
                    FROM    edfi.StudentSchoolAssociation AS ssa 
                        INNER JOIN edfi.Student s ON ssa.StudentUSI = s.StudentUSI
                        INNER JOIN edfi.EducationOrganization edOrg ON ssa.SchoolId = edOrg.EducationOrganizationId
                    ORDER BY s.LastSurname
                    {pagingSql}".NormalizeSql());

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
            
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_multiple_column_left_join(DatabaseEngine databaseEngine)
            {
                var q = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("tracked_changes_edfi.CalendarDate AS c")
                    .Select("c.Id", "c.ChangeVersion")
                    .LeftJoin("edfi.CalendarDate src", joiner => 
                        joiner.On("c.OldCalendarCode", "src.CalendarCode")
                            .On("c.OldDate", "src.Date")
                            .On("c.OldSchoolId", "src.SchoolId")
                            .On("c.OldSchoolYear", "src.SchoolYear"));

                var template = q.BuildTemplate();
            
                template.RawSql.NormalizeSql()
                    .ShouldBe(@$"
                    SELECT  c.Id, c.ChangeVersion 
                    FROM    tracked_changes_edfi.CalendarDate AS c 
                        LEFT JOIN edfi.CalendarDate src 
                            ON c.OldCalendarCode = src.CalendarCode
                            AND c.OldDate = src.Date
                            AND c.OldSchoolId = src.SchoolId
                            AND c.OldSchoolYear = src.SchoolYear".NormalizeSql());

                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = q.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
        }

        public class With_CTEs
        {
            [TestCase(DatabaseEngine.MsSql)]
            [TestCase(DatabaseEngine.PgSql)]
            public void Should_apply_CTEs(DatabaseEngine databaseEngine)
            {
                string initialChangeVersionColumnName = "initialChangeVersion";
                string finalChangeVersionColumnName = "finalChangeVersion";
                
                var changeWindowVersionsCteQuery = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From("tracked_changes_edfi.Calendar AS c")
                    .Select("c.Id")
                    .SelectRaw($"MIN(c.ChangeVersion) AS {initialChangeVersionColumnName}")
                    .SelectRaw($"MAX(c.ChangeVersion) AS {finalChangeVersionColumnName}")
                    .GroupBy("c.Id");

                string changeWindowCteName = "ChangeWindow";
                string changeWindowAlias = "cw";

                string changeQueriesTableName = "tracked_changes_edfi.Calendar";
                string oldAlias = "old";
                string newAlias = "new";

                string idColumnName = "Id";
                
                var dataQuery = new QueryBuilder(GetDialectFor(databaseEngine))
                    .From($"{changeWindowCteName} AS {changeWindowAlias}")
                    .With(changeWindowCteName, changeWindowVersionsCteQuery)
                    .Join(
                        $"{changeQueriesTableName} AS {oldAlias}",
                        j => j.On($"{changeWindowAlias}.{idColumnName}", $"{oldAlias}.{idColumnName}")
                            .On($"{changeWindowAlias}.{initialChangeVersionColumnName}", $"{oldAlias}.ChangeVersion"))
                    .Join(
                        $"{changeQueriesTableName} AS {newAlias}",
                        j => j.On($"{changeWindowAlias}.{idColumnName}", $"{newAlias}.{idColumnName}")
                            .On($"{changeWindowAlias}.{finalChangeVersionColumnName}", $"{newAlias}.ChangeVersion"))
                    .Select(
                        $"{changeWindowAlias}.{idColumnName}",
                        $"{changeWindowAlias}.{finalChangeVersionColumnName} AS ChangeVersion")
                    .Select($"{oldAlias}.OldCalendarCode", $"{oldAlias}.OldSchoolId", $"{oldAlias}.OldSchoolYear")
                    .Select($"{newAlias}.NewCalendarCode", $"{newAlias}.NewSchoolId", $"{newAlias}.NewSchoolYear")
                    .OrderBy($"{changeWindowAlias}.{finalChangeVersionColumnName}");
                
                var template = dataQuery.BuildTemplate();

                var actualParameters = template.Parameters as DynamicParameters;
                
                actualParameters.ShouldSatisfyAllConditions(
                    () => template.RawSql.NormalizeSql().ShouldBe(@"
                    WITH ChangeWindow AS (
                        SELECT  c.Id, MIN(c.ChangeVersion) AS initialChangeVersion, MAX(c.ChangeVersion) AS finalChangeVersion
                        FROM    tracked_changes_edfi.Calendar AS c
                        GROUP BY c.Id
                    )
                    SELECT  cw.Id, cw.finalChangeVersion AS ChangeVersion,
                            old.OldCalendarCode, old.OldSchoolId, old.OldSchoolYear,
                            new.NewCalendarCode, new.NewSchoolId, new.NewSchoolYear
                    FROM    ChangeWindow AS cw
                            INNER JOIN tracked_changes_edfi.Calendar AS old
                                ON cw.Id = old.Id AND cw.initialChangeVersion = old.ChangeVersion 
                            INNER JOIN tracked_changes_edfi.Calendar AS new
                                ON cw.Id = new.Id AND cw.finalChangeVersion = new.ChangeVersion
                    ORDER BY cw.finalChangeVersion
                    ".NormalizeSql())
                );
                
                ExecuteQueryAndWriteResults(databaseEngine, template);
                
                // Check the cloned query results
                var clonedQueryResult = dataQuery.Clone().BuildTemplate();
                template.RawSql.ShouldBe(clonedQueryResult.RawSql);
            }
        }

        public enum DatabaseEngine
        {
            MsSql,
            PgSql
        }

        private static Dialect GetDialectFor(DatabaseEngine databaseEngine)
        {
            switch (databaseEngine)
            {
                case DatabaseEngine.MsSql:
                    return new SqlServerDialect();
                case DatabaseEngine.PgSql:
                    return new PostgreSqlDialect();
                default:
                    throw new NotSupportedException($"Unsupported database engine '{databaseEngine.ToString()}'.");
            }
        }
        
        private static void ExecuteQueryAndWriteResults(DatabaseEngine databaseEngine, SqlBuilder.Template template)
        {
            IEnumerable<dynamic> results;

            switch (databaseEngine)
            {
                case DatabaseEngine.MsSql:
                {
                    using var conn = new SqlConnection(
                        "Server=(local); Database=EdFi_Ods_Populated_Template; Trusted_Connection=True; Application Name=EdFi.Ods.WebApi;");

                    results = conn.Query(template.RawSql, template.Parameters);
                }

                    break;

                case DatabaseEngine.PgSql:
                {
                    using var conn = new NpgsqlConnection(
                        "host=localhost;port=6432;username=postgres;database=EdFi_Ods_Populated_Template_Test;pooling=true;minimum pool size=10;maximum pool size=50;Application Name=EdFi.Ods.Api.IntegrationTests");

                    results = conn.Query(template.RawSql, template.Parameters);
                }

                    break;
                
                default:
                    return;
            }

            bool hasResults = false;
            int rowNumber = 0;
            
            foreach (dynamic item in results)
            {
                if (++rowNumber > 5)
                {
                    Console.WriteLine("...");

                    break;
                }
                
                hasResults = true;
                Console.WriteLine(JsonConvert.SerializeObject(item));
            }
            
            if (!hasResults)
            {
                Console.WriteLine("Query executed successfully but returned no data.");
            }
        }
    }
}
