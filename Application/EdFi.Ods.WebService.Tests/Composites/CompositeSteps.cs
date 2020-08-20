// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using Castle.Windsor;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.WebService.Tests.Extensions;
using EdFi.Ods.WebService.Tests.Owin;
using log4net;
using Newtonsoft.Json.Linq;
using NHibernate;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Composites
{
    public static class ScenarioContextKeys
    {
        public const string CompositeSubjectId = "CompositeSubjectId";
        public const string CompositeSubjectResourceName = "CompositeSubjectResourceName";
        public const string PluralizedCompositeName = "pluralizedCompositeName";
        public const string CompositeMatchingRecordIds = "CompositeMatchingRecordIds";
        public const string CompositeQueryParameterDictionary = "CompositeQueryParameterDictionary";        
        public const string CompositeRangeQueries = "CompositeRangeQueries";
        public const string RequestCorrelationId = "RequestCorrelationId";        
        public const string CompositeQueryStringDescriptorParameter = "CompositeQueryStringDescriptorParameter";
        public const string RequestPattern = "RequestPattern";
        public const string RequestParameters = "RequestParameters";
        public static string CompositeSubjectKey = "CompositeSubjectKey";
    }

    [Binding]
    public sealed class CompositeSteps
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(CompositeSteps));

        [Given(@"the subject of the request is a student with values in all name properties")]
        public void GivenTheSubjectOfTheRequestIsAStudentWithValuesInAllNameProperties()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 Id, *
                    FROM    edfi.Student
                    WHERE   PersonalTitlePrefix IS NOT NULL
                            AND FirstName IS NOT NULL
                            AND MiddleName IS NOT NULL
                            AND LastSurname IS NOT NULL
                            AND GenerationCodeSuffix IS NOT NULL";

                ScenarioContext.Current.Set((Guid) cmd.ExecuteScalar(), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("Student", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

       
        [Given(@"the subject of the request is ""(.*)""( with invalid query)? where")]
        public void GivenTheSubjectOfTheRequestIsBaseResourceWhere(string baseResource, string invalidProperty, Table queryParameters)
        {
            var queryParameterDictionary = CreateQueryStringParameterDictionaryByTypes(queryParameters);

            ScenarioContext.Current.Set(queryParameterDictionary, ScenarioContextKeys.CompositeQueryParameterDictionary);

            if (!string.IsNullOrEmpty(invalidProperty))
            {
                return;
            }

            var container = FeatureContext.Current.Get<IWindsorContainer>();
            var connectionStringProvider = container.Resolve<IConfigConnectionStringsProvider>();

            var whereSelector = new StringBuilder();

            foreach (var pair in queryParameterDictionary)
            {
                whereSelector.Append(
                    string.Format(
                        "{0} {1} = '{2}' ",
                        whereSelector.Length > 0
                            ? "AND"
                            : "WHERE",
                        pair.Value.Name,
                        pair.Value.Value));
            }

            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = string.Format(
                    @"
                    SELECT Id
                    FROM [edfi].[{0}]
                    {1}",
                    baseResource,
                    whereSelector);

                var matchingIds = new List<Guid>();
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    matchingIds.Add(sqlReader.GetGuid(0));
                }

                sqlReader.Close();

                ScenarioContext.Current.Set(matchingIds, ScenarioContextKeys.CompositeMatchingRecordIds);
            }
        }

        private bool IsDescriptorParameter(string parameterName)
        {
            return parameterName.EndsWithIgnoreCase("descriptor");
        }

        [Given(@"the subject of the request is ""(.*)"" with a given (?:descriptor) where")]
        public void GivenTheSubjectOfTheRequestIsBaseResourceWhere(string baseResource, Table queryParameters)
        {
            var queryParameterDictionary = CreateQueryStringParameterDictionaryByTypes(queryParameters);

            ScenarioContext.Current.Set(queryParameterDictionary, ScenarioContextKeys.CompositeQueryParameterDictionary);

            var container = FeatureContext.Current.Get<IWindsorContainer>();
            var typeAndDescriptorCache = container.Resolve<IDescriptorsCache>();

            var whereSelector = new StringBuilder();

            foreach (var pair in queryParameterDictionary)
            {
                string parameterNameToUse = pair.Value.Name;
                string parameterValueToUse = pair.Value.Value.ToString();

                if (IsDescriptorParameter(pair.Value.Name))
                {
                    ScenarioContext.Current.Set(
                        pair.Value.Name.ToCamelCase(),
                        ScenarioContextKeys.CompositeQueryStringDescriptorParameter);

                    parameterNameToUse = pair.Value.Name + "Id";

                    var descriptorParts = pair.Value.Name.SplitCamelCase();

                    for (var n = 0; n < descriptorParts.Length; n++)
                    {
                        var descriptorWithNextPartTrimmed = string.Join(string.Empty, descriptorParts, n, descriptorParts.Length - n);

                        try
                        {
                            parameterValueToUse =
                                typeAndDescriptorCache.GetId(descriptorWithNextPartTrimmed, parameterValueToUse)
                                                      .ToString();

                            break;
                        }
                        catch (KeyNotFoundException) { }
                        catch (MappingException) { }
                    }
                }

                whereSelector.Append(
                    string.Format(
                        "{0} {1} = '{2}' ",
                        whereSelector.Length > 0
                            ? "AND"
                            : "WHERE",
                        parameterNameToUse,
                        parameterValueToUse));
            }

            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = string.Format(
                    @"
                    SELECT Id
                    FROM [edfi].[{0}]
                    {1}",
                    baseResource,
                    whereSelector);

                var matchingIds = new List<Guid>();
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    matchingIds.Add(sqlReader.GetGuid(0));
                }

                sqlReader.Close();

                ScenarioContext.Current.Set(matchingIds, ScenarioContextKeys.CompositeMatchingRecordIds);
            }
        }


        [Given(@"the subject of the request is ""(.*)""( with invalid query)? with range")]
        public void GivenTheSubjectOfTheRequestIsACompositeWithRange(
            string baseResource,
            string invalidProperty,
            Table queryRangeParameters)
        {
            var compositeRangeQueries = queryRangeParameters.Rows.Select(
                                                                 entry => new RangeQueryObject
                                                                          {
                                                                              PropertyName = entry["PropertyName"], BeginRange = entry["BeginValue"],
                                                                              BeginRangeOperator = entry["BeginInclusion"],
                                                                              EndRange = entry["EndValue"], EndRangeOperator = entry["EndInclusion"]
                                                                          })
                                                            .ToList();

            ScenarioContext.Current.Set(compositeRangeQueries, ScenarioContextKeys.CompositeRangeQueries);

            if (!string.IsNullOrEmpty(invalidProperty))
            {
                return;
            }

            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                var whereSelector = new StringBuilder();

                whereSelector.Append(
                    string.Join(
                        " AND ",
                        compositeRangeQueries.Select(
                            (q, i) =>
                                string.Format(
                                    "{1} {2} @beginValue{0} and {1} {3} @endValue{0}",
                                    i,
                                    q.PropertyName,
                                    q.BeginRangeOperator,
                                    q.EndRangeOperator))));

                if (whereSelector.Length > 0)
                {
                    whereSelector.Insert(0, "WHERE ");
                }

                cmd.Parameters.AddRange(
                    compositeRangeQueries.SelectMany(
                                              (q, i) =>
                                              {
                                                  var beginParameter = cmd.CreateParameter();
                                                  beginParameter.ParameterName = "@beginValue" + i;
                                                  beginParameter.Value = q.BeginRange;

                                                  var endParameter = cmd.CreateParameter();
                                                  endParameter.ParameterName = "@endValue" + i;
                                                  endParameter.Value = q.EndRange;

                                                  return new[]
                                                         {
                                                             beginParameter, endParameter
                                                         };
                                              })
                                         .ToArray()
                );

                cmd.CommandText = string.Format(
                    @"
                    SELECT Id
                    FROM [edfi].[{0}]
                    {1}",
                    baseResource,
                    whereSelector);

                var matchingIds = new List<Guid>();

                try
                {
                    var sqlReader = cmd.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        matchingIds.Add(sqlReader.GetGuid(0));
                    }

                    sqlReader.Close();

                    ScenarioContext.Current.Set(matchingIds, ScenarioContextKeys.CompositeMatchingRecordIds);
                }
                catch (Exception ex)
                {
                    _logger.ErrorFormat(
                        "An exception occurred while trying to read the Ids for the subject from the database.\r\nSQL:{0}\r\nException:{1}",
                        cmd.CommandText,
                        ex);
                }
            }
        }

        [Given(@"the subject of the request is ""(.*)""")]
        public void GivenTheSubjectOfTheRequestIsAComposite(string composite)
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = string.Format(
                    @"
                    SELECT Id
                    FROM [edfi].[{0}]",
                    composite);

                var matchingIds = new List<Guid>();
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    matchingIds.Add(sqlReader.GetGuid(0));
                }

                sqlReader.Close();

                ScenarioContext.Current.Set(matchingIds, ScenarioContextKeys.CompositeMatchingRecordIds);
            }
        }

        [Given(@"the subject of the request is a student with a StudentAcademicRecord")]
        public void GivenTheSubjectOfTheRequestIsAStudentWithAStudentAcademicRecord()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 s.Id, *
                    FROM    edfi.Student s
                    INNER JOIN edfi.StudentAcademicRecord sar ON s.StudentUSI = sar.StudentUSI";

                ScenarioContext.Current.Set((Guid) cmd.ExecuteScalar(), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("Student", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

        [Given(@"the subject of the request is a school with student and staff associations")]
        public void GivenTheSubjectOfTheRequestIsASchoolWithStudentAndStaffAssociations()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 eo.Id, *
                    FROM edfi.School s
                    INNER JOIN edfi.EducationOrganization eo ON s.SchoolId = eo.EducationOrganizationId
                    INNER JOIN edfi.SchoolCategory sc ON s.SchoolId = sc.SchoolId
                    INNER JOIN edfi.StudentSchoolAssociation ssa ON s.SchoolId = ssa.SchoolId
                    INNER JOIN edfi.StaffSchoolAssociation stsa ON s.SchoolId = stsa.SchoolId";

                var subjectId = (Guid?) cmd.ExecuteScalar();

                if (!subjectId.HasValue)
                {
                    throw new Exception("Unable to find valid test subject in test database.");
                }

                ScenarioContext.Current.Set(subjectId.Value, ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("School", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

        [Given(@"the subject of the request is a student with a StudentSchoolAssociation")]
        public void GivenTheSubjectOfTheRequestIsAStudentWithAStudentSchoolAssociation()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 s.Id, *
                    FROM    edfi.Student s
                    INNER JOIN edfi.StudentSchoolAssociation ssa ON s.StudentUSI = ssa.StudentUSI";

                ScenarioContext.Current.Set((Guid) cmd.ExecuteScalar(), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("Student", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

        [Given(@"the subject of the request is a student with a StudentEducationOrganizationAssociation")]
        public void GivenTheSubjectOfTheRequestIsAStudentWithAstudentEducationOrganizationAssociation()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 s.Id, *
                    FROM    edfi.Student s
                    INNER JOIN edfi.StudentEducationOrganizationAssociation ssa ON s.StudentUSI = ssa.StudentUSI";

                ScenarioContext.Current.Set((Guid) cmd.ExecuteScalar(), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("Student", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

        [Given(@"the subject of the request is a StudentEducationOrganizationAssociation")]
        public void GivenTheSubjectOfTheRequestIsAStudentEducationOrganizationAssociation()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 seoa.Id, *
                    FROM    edfi.StudentEducationOrganizationAssociation seoa";

                ScenarioContext.Current.Set((Guid) cmd.ExecuteScalar(), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("StudentEducationOrganizationAssociation", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation")]
        public void GivenTheSubjectOfTheRequestIsAStudentSchoolAssociation()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 sa.Id, *
                    FROM    edfi.StudentSchoolAssociation sa ";

                ScenarioContext.Current.Set((Guid) cmd.ExecuteScalar(), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("StudentSchoolAssociation", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation with StudentAssessment")]
        public void GivenTheSubjectOfTheRequestIsAStudentSchoolAssociationWithStudentAssessment()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM    edfi.StudentSchoolAssociation ssa
                        INNER JOIN edfi.Student stu 
                            ON ssa.StudentUSI = stu.StudentUSI
                        INNER JOIN edfi.StudentAssessment sa
                            ON ssa.StudentUSI = sa.StudentUSI";

                var reader = cmd.ExecuteReader();
                reader.Read();

                ScenarioContext.Current.Set(reader.GetGuid(0), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("StudentSchoolAssociation", ScenarioContextKeys.CompositeSubjectResourceName);

                var keyValueByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase)
                                     {
                                         {
                                             "StudentUniqueId", reader.GetString(1)
                                         },
                                         {
                                             "SchoolId", reader.GetInt32(2)
                                         },
                                         {
                                             "EntryDate", reader.GetDateTime(3)
                                         }
                                     };

                ScenarioContext.Current.Set(keyValueByName, ScenarioContextKeys.CompositeSubjectKey);
            }
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation with School")]
        public void GivenTheSubjectOfTheRequestIsAStudentSchoolAssociationWithSchool()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM    edfi.StudentSchoolAssociation ssa
                        INNER JOIN edfi.School sc 
                            ON ssa.SchoolId = sc.SchoolId
                        INNER JOIN edfi.Student stu
                            ON ssa.StudentUSI = stu.StudentUSI
                    WHERE LocalEducationAgencyId IS NOT NULL";

                var reader = cmd.ExecuteReader();
                reader.Read();

                ScenarioContext.Current.Set(reader.GetGuid(0), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("StudentSchoolAssociation", ScenarioContextKeys.CompositeSubjectResourceName);

                var keyValueByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase)
                                     {
                                         {
                                             "StudentUniqueId", reader.GetString(1)
                                         },
                                         {
                                             "SchoolId", reader.GetInt32(2)
                                         },
                                         {
                                             "EntryDate", reader.GetDateTime(3)
                                         }
                                     };

                ScenarioContext.Current.Set(keyValueByName, ScenarioContextKeys.CompositeSubjectKey);
            }
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation with School and StudentAssessment")]
        public void GivenTheSubjectOfTheRequestIsAStudentSchoolAssociationWithSchoolAndStudentAssessment()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM    edfi.StudentSchoolAssociation ssa
                        INNER JOIN edfi.School sc 
                            ON ssa.SchoolId = sc.SchoolId
                        INNER JOIN edfi.Student stu
                            ON ssa.StudentUSI = stu.StudentUSI
                        INNER JOIN edfi.StudentAssessment sa
                            ON ssa.StudentUSI = sa.StudentUSI
                    WHERE sc.LocalEducationAgencyId IS NOT NULL
                        AND sa.AssessmentIdentifier IS NOT NULL";

                var reader = cmd.ExecuteReader();
                reader.Read();

                ScenarioContext.Current.Set(reader.GetGuid(0), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("StudentSchoolAssociation", ScenarioContextKeys.CompositeSubjectResourceName);

                var keyValueByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase)
                                     {
                                         {
                                             "StudentUniqueId", reader.GetString(1)
                                         },
                                         {
                                             "SchoolId", reader.GetInt32(2)
                                         },
                                         {
                                             "EntryDate", reader.GetDateTime(3)
                                         }
                                     };

                ScenarioContext.Current.Set(keyValueByName, ScenarioContextKeys.CompositeSubjectKey);
            }
        }

        [Given(@"the subject of the request is a StudentAssessment with ObjectAssessmentScoreResults")]
        public void GivenTheSubjectOfTheRequestIsAStudentAssessmentWithObjectAssessmentScoreResults()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 sa.Id
                    FROM    edfi.StudentAssessment sa 
                    INNER JOIN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult sr
                    ON sa.AssessmentIdentifier = sr.AssessmentIdentifier
                    AND sa.Namespace = sr.Namespace
                    AND sa.StudentAssessmentIdentifier = sr.StudentAssessmentIdentifier
                    AND sa.StudentUSI = sr.StudentUSI";

                ScenarioContext.Current.Set((Guid) cmd.ExecuteScalar(), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("StudentAssessment", ScenarioContextKeys.CompositeSubjectResourceName);
            }
        }

        [Given(@"the subject of the request is a StudentAssessment with StudentAssessmentStudentObjectiveAssessment")]
        public void GivenTheSubjectOfTheRequestIsAStudentAssessmentWithStudentAssessmentStudentObjectiveAssessment()
        {
            using (var conn = CreateSqlConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT  TOP 1 sa.Id, 
                            sa.StudentAssessmentIdentifier,
                            sa.AssessmentIdentifier,
                            sa.Namespace,
                            s.StudentUniqueId
                    FROM    edfi.StudentAssessment sa 
                        INNER JOIN edfi.Student s
                            ON sa.StudentUSI = s.StudentUSI
                        INNER JOIN edfi.StudentAssessmentStudentObjectiveAssessment oa
                            ON sa.StudentAssessmentIdentifier = oa.StudentAssessmentIdentifier
                                AND sa.AssessmentIdentifier = oa.AssessmentIdentifier
                                AND sa.Namespace = oa.Namespace
                                AND sa.StudentUSI = oa.StudentUSI";

                var reader = cmd.ExecuteReader();
                reader.Read();

                ScenarioContext.Current.Set(reader.GetGuid(0), ScenarioContextKeys.CompositeSubjectId);
                ScenarioContext.Current.Set("StudentAssessment", ScenarioContextKeys.CompositeSubjectResourceName);

                var keyValueByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase)
                                     {
                                         {
                                             "StudentAssessmentIdentifier", reader.GetString(1)
                                         },
                                         {
                                             "AssessmentIdentifier", reader.GetString(2)
                                         },
                                         {
                                             "Namespace", reader.GetString(3)
                                         },
                                         {
                                             "StudentUniqueId", reader.GetString(4)
                                         }
                                     };

                ScenarioContext.Current.Set(keyValueByName, ScenarioContextKeys.CompositeSubjectKey);
            }
        }

    
        [When(@"a GET \(by (example|key|id)\) request is submitted to the (?:([a-z]+) )?""(.*)"" resource using the following parameters:")]
        public void WhenAGETByExampleRequestIsSubmittedToTheCompositeUsingTheFollowingParameters(
            string requestPattern,
            string compositeCategoryName,
            string resourceName,
            Table parameters)
        {
            // Default the category to test, if not specified
            compositeCategoryName = GetCompositeCategoryName(compositeCategoryName);

            ScenarioContext.Current.Set(requestPattern, ScenarioContextKeys.RequestPattern);

            var valueByName = parameters.Rows.ToDictionary(
                r => r["Name"],
                r => (object) r["Value"],
                StringComparer.InvariantCultureIgnoreCase);

            ScenarioContext.Current.Set(valueByName, ScenarioContextKeys.RequestParameters);

            var pluralizedCompositeName = CompositeTermInflector.MakePlural(resourceName);
            ScenarioContext.Current.Set(pluralizedCompositeName, ScenarioContextKeys.PluralizedCompositeName);

            var uri = OwinUriHelper.BuildCompositeUri(
                string.Format(
                    "{0}/{1}?{2}",
                    compositeCategoryName,
                    pluralizedCompositeName,
                    string.Join("&", valueByName.Select(kvp => Uri.EscapeDataString(kvp.Key) + "=" + Uri.EscapeDataString(kvp.Value.ToString())))));

            var httpClient = FeatureContext.Current.Get<HttpClient>();

            var getResponseMessage = httpClient.GetAsync(uri)
                                               .GetResultSafely();

            // Save the response, and the resource collection name for the scenario
            ScenarioContext.Current.Set(getResponseMessage);
        }

        [When(@"a GET \(by id\) request is submitted to the (?:([a-z]+) )?""(.*)"" composite with a resource identifier of ""(.*)""")]
        public void WhenAGETByIdRequestIsSubmittedToTheCompositeWithAnInvalidResourceIdentifier(
            string compositeCategoryName,
            string compositeName,
            string resourceIdentifier)
        {
            // Default the category to test, if not specified
            compositeCategoryName = GetCompositeCategoryName(compositeCategoryName);

            var httpClient = FeatureContext.Current.Get<HttpClient>();

            var pluralizedCompositeName = CompositeTermInflector.MakePlural(compositeName);

            ScenarioContext.Current.Set(pluralizedCompositeName, ScenarioContextKeys.PluralizedCompositeName);

            var uri = OwinUriHelper.BuildCompositeUri(
                string.Format(
                    "{0}/{1}/{2}",
                    compositeCategoryName,
                    pluralizedCompositeName,
                    resourceIdentifier));

            var getResponseMessage = httpClient.GetAsync(uri)
                                               .GetResultSafely();

            // Save the response, and the resource collection name for the scenario
            ScenarioContext.Current.Set(getResponseMessage);
        }

        [When(
            @"a GET \(by (example|key|id)\) request is submitted to the (?:([a-z]+) )?""(.*)"" composite( with no correlation Id)? with the following parameters:")]
        public void WhenAGETRequestIsSubmittedToTheCompositeWithParameters(
            string requestPattern,
            string compositeCategoryName,
            string compositeName,
            string excludeCorrelationText,
            Table parametersTable)
        {
            ScenarioContext.Current.Set(requestPattern, ScenarioContextKeys.RequestPattern);

            // Default the category to test, if not specified
            compositeCategoryName = GetCompositeCategoryName(compositeCategoryName);

            var httpClient = FeatureContext.Current.Get<HttpClient>();

            var subjectId = ScenarioContext.Current.Get<Guid>(ScenarioContextKeys.CompositeSubjectId);

            var pluralizedCompositeName = CompositeTermInflector.MakePlural(compositeName);

            ScenarioContext.Current.Set(pluralizedCompositeName, ScenarioContextKeys.PluralizedCompositeName);

            bool includeCorrelation = string.IsNullOrEmpty(excludeCorrelationText);

            string requestUrl = null;

            if (requestPattern.EqualsIgnoreCase("id"))
            {
                var dictionary = new Dictionary<string, object>();
                ScenarioContext.Current.Set(dictionary, ScenarioContextKeys.RequestParameters);

                requestUrl = OwinUriHelper.BuildCompositeUri(
                    string.Format(
                        "{0}/{1}/{2}{3}",
                        compositeCategoryName,
                        pluralizedCompositeName,
                        subjectId.ToString("n"),
                        GetQueryString(parametersTable, includeCorrelation)));
            }
            else if (requestPattern.EqualsIgnoreCase("key"))
            {
                var valueByName = parametersTable == null
                    ? ScenarioContext.Current.Get<Dictionary<string, object>>(ScenarioContextKeys.CompositeSubjectKey)
                    : parametersTable.Rows.ToDictionary(
                        r => r["Name"],
                        r => (object) r["Value"],
                        StringComparer.InvariantCultureIgnoreCase);

                ScenarioContext.Current.Set(valueByName, ScenarioContextKeys.RequestParameters);

                requestUrl = OwinUriHelper.BuildCompositeUri(
                    string.Format(
                        "{0}/{1}?{2}",
                        compositeCategoryName,
                        pluralizedCompositeName,
                        string.Join("&", valueByName.Select(kvp => kvp.Key + "=" + Uri.EscapeDataString(kvp.Value.ToString())))));
            }
            else
            {
                throw new NotSupportedException(
                    string.Format("Request pattern '{0}' is not yet explicity supported by the test step definition.", requestPattern));
            }

            if (!includeCorrelation)
            {
                ScenarioContext.Current.Remove(ScenarioContextKeys.RequestCorrelationId);
            }

            var getResponseMessage = httpClient.GetAsync(requestUrl)
                                               .GetResultSafely();

            // Save the response, and the resource collection name for the scenario
            ScenarioContext.Current.Set(getResponseMessage);
        }

        [When(@"a GET \(by (id|key|example)\) request is submitted to the (?:([a-z]+) )?""(.*)"" composite( with no correlation Id)?")]
        public void WhenAGETByIdRequestIsSubmittedToTheComposite(
            string requestPattern,
            string compositeCategoryName,
            string compositeName,
            string excludeCorrelationText)
        {
            WhenAGETRequestIsSubmittedToTheCompositeWithParameters(
                requestPattern,
                compositeCategoryName,
                compositeName,
                excludeCorrelationText,
                null);
        }

        private static string GetQueryString(Table table, bool includeCorrelation)
        {
            var sb = new StringBuilder();

            if (includeCorrelation)
            {
                sb.AppendFormat("&{0}={1}", SpecialQueryStringParameters.CorrelationId, EstablishRequestCorrelationIdForScenario());
            }

            if (table != null)
            {
                foreach (var row in table.Rows)
                {
                    sb.AppendFormat("&{0}={1}", row["Name"], Uri.EscapeDataString(row["Value"]));
                }
            }

            if (sb.Length > 0)
            {
                sb.Replace('&', '?', 0, 1);
            }

            return sb.ToString();
        }

        public static string EstablishRequestCorrelationIdForScenario()
        {
            string correlationId = Guid.NewGuid()
                                       .ToString("n");

            ScenarioContext.Current.Set(correlationId, ScenarioContextKeys.RequestCorrelationId);
            return correlationId;
        }

      

        [When(@"a GET \(all\) request is submitted to the (?: ([a-z]+) )?""(.*)"" composite( with the query string filter)?")]
        public void WhenAGetAlldRequestIsSubmittedToTheCompositeWithAFilteredQuery(
            string compositeCategoryName,
            string compositeName,
            string hasParameters)
        {
            var httpClient = FeatureContext.Current.Get<HttpClient>();

            var pluralizedCompositeName = CompositeTermInflector.MakePlural(compositeName);

            compositeCategoryName = GetCompositeCategoryName(compositeCategoryName);

            var queryParameterDictionary = new Dictionary<string, QueryParameterObject>();

            if (!string.IsNullOrEmpty(hasParameters))
            {
                queryParameterDictionary =
                    ScenarioContext.Current.Get<Dictionary<string, QueryParameterObject>>(ScenarioContextKeys.CompositeQueryParameterDictionary);
            }

            ScenarioContext.Current.Set(pluralizedCompositeName, ScenarioContextKeys.PluralizedCompositeName);

            string queryStringParameterText = string.Join(
                "&",

                // Add the criteria 
                queryParameterDictionary.Select(
                                             kvp =>
                                             {
                                                 string parameterName = kvp.Value.Name;

                                                 if (IsDescriptorParameter(kvp.Value.Name))
                                                 {
                                                     parameterName = ScenarioContext.Current.Get<string>(
                                                         ScenarioContextKeys.CompositeQueryStringDescriptorParameter);
                                                 }

                                                 return $"{parameterName}={Uri.EscapeDataString(kvp.Value.Value.ToString())}";
                                             })

                                         // Add the correlation Id
                                        .Concat(
                                             new[]
                                             {
                                                 SpecialQueryStringParameters.CorrelationId + "=" + EstablishRequestCorrelationIdForScenario()
                                             }));

            var uri = OwinUriHelper.BuildCompositeUri(
                string.Format(
                    "{0}/{1}{2}{3}",
                    compositeCategoryName,
                    pluralizedCompositeName,
                    queryStringParameterText.Length > 0
                        ? "?"
                        : string.Empty,
                    queryStringParameterText));

            var getResponseMessage = httpClient.GetAsync(uri)
                                               .GetResultSafely();

            // Save the response, and the resource collection name for the scenario
            ScenarioContext.Current.Set(getResponseMessage);
        }

     
        private string GetCompositeCategoryName(string providedName)
        {
            return string.IsNullOrWhiteSpace(providedName)
                ? "test"
                : providedName;
        }
       
        private Dictionary<string, QueryParameterObject> CreateQueryStringParameterDictionaryByTypes(Table queryParameters)
        {
            var queryParameterDictionary = new Dictionary<string, QueryParameterObject>();

            queryParameterDictionary = queryParameters.Rows.ToDictionary(
                row => row["Type"],
                row => new QueryParameterObject
                       {
                           Name = row["ParameterName"], Value = row["Value"]
                       });

            return queryParameterDictionary;
        }

       
        internal static SqlConnection CreateSqlConnection()
        {
            var conn = new SqlConnection(GlobalDatabaseSetupFixture.SpecFlowDatabaseConnectionString);
            return conn;
        }


        private class RangeQueryObject
        {
            public string PropertyName { get; set; }

            public string BeginRange { get; set; }

            public string BeginRangeOperator { get; set; }

            public string EndRange { get; set; }

            public string EndRangeOperator { get; set; }
        }

        private class QueryParameterObject
        {
            public string Name { get; set; }

            public object Value { get; set; }
        }
    }
}
