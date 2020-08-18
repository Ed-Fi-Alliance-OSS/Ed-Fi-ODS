// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using ApprovalTests;
using ApprovalTests.Reporters;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.WebService.Tests.Extensions;
using EdFi.Ods.WebService.Tests.Owin;
using log4net;
using log4net.Appender;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Composites
{
    [UseReporter(typeof(DiffReporter))]
    public partial class RefactoredCompositesGeneratesSameQueriesFeature { }

    [Binding]
    public sealed class RefactoredCompositesSteps
    {
        private Guid GetResourceId(string tableName, object keyValues)
        {
            var valueByName = keyValues.ToDictionary();

            string whereClause = string.Join(
                " AND ",
                valueByName.Select(
                    kvp =>
                        kvp.Key + " = "
                                + (kvp.Value is string
                                    ? kvp.Value.ToString()
                                         .SingleQuoted()
                                    : kvp.Value)));

            using (var conn = new SqlConnection(GlobalDatabaseSetupFixture.SpecFlowDatabaseConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = $@"
                  SELECT Id
                  FROM  [edfi].[{tableName}]
                  WHERE {whereClause}";

                return (Guid) cmd.ExecuteScalar();
            }
        }

        [When(@"the ""(.*)"" request is submitted")]
        public void When_the_request_is_submitted(string requestName)
        {
            var httpClient = FeatureContext.Current.Get<HttpClient>();

            string requestUrl = null;
            Guid resourceId;

            switch (requestName)
            {
                case "School by Id":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901001
                        });

                    requestUrl = $"enrollment/schools/{resourceId}";
                    break;

                case "Schools by Local Education Agency (Id)":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901
                        });

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/schools";
                    break;

                case "Schools by Section (Id)":

                    resourceId = GetResourceId(
                        "Section",
                        new
                        {
                            SectionIdentifier = "25590100101Trad120ENG112011"
                        });

                    requestUrl = $"enrollment/sections/{resourceId}/schools";
                    break;

                case "Schools by Staff (Id)":

                    resourceId = GetResourceId(
                        "Staff",
                        new
                        {
                            StaffUniqueId = "207268"
                        });

                    requestUrl = $"enrollment/staffs/{resourceId}/schools";
                    break;

                case "Section by Id":

                    resourceId = GetResourceId(
                        "Section",
                        new
                        {
                            SectionIdentifier = "25590100101Trad120ENG112011"
                        });

                    requestUrl = $"enrollment/sections/{resourceId}";
                    break;

                case "Sections by Local Education Agency (Id)":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901
                        });

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/sections";
                    break;

                case "Sections by School (Id)":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901001
                        });

                    requestUrl = $"enrollment/schools/{resourceId}/sections";
                    break;

                case "Sections by Staff (Id)":

                    resourceId = GetResourceId(
                        "Staff",
                        new
                        {
                            StaffUniqueId = 207268
                        });

                    requestUrl = $"enrollment/staffs/{resourceId}/sections";
                    break;

                case "Staff by Id":

                    resourceId = GetResourceId(
                        "Staff",
                        new
                        {
                            StaffUniqueId = "207268"
                        });

                    requestUrl = $"enrollment/staffs/{resourceId}";
                    break;

                case "Staffs by Local Education Agency (Id)":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901
                        });

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/staffs";
                    break;

                case "Staffs by School (Id)":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901001
                        });

                    requestUrl = $"enrollment/schools/{resourceId}/staffs";
                    break;

                case "Staffs by Section (Id)":

                    resourceId = GetResourceId(
                        "Section",
                        new
                        {
                            SectionIdentifier = "25590100101Trad120ENG112011"
                        });

                    requestUrl = $"enrollment/sections/{resourceId}/staffs";
                    break;

                case "Student by Id":

                    resourceId = GetResourceId(
                        "Student",
                        new
                        {
                            StudentUniqueId = 605042
                        });

                    requestUrl = $"enrollment/students/{resourceId}";
                    break;

                case "Students by Local Education Agency (Id)":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901
                        });

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/students";
                    break;

                case "Students by School (Id)":

                    resourceId = GetResourceId(
                        "EducationOrganization",
                        new
                        {
                            EducationOrganizationId = 255901001
                        });

                    requestUrl = $"enrollment/schools/{resourceId}/students";
                    break;

                case "Students by Section (Id)":

                    resourceId = GetResourceId(
                        "Section",
                        new
                        {
                            SectionIdentifier = "25590100101Trad120ENG112011"
                        });

                    requestUrl = $"enrollment/sections/{resourceId}/students";
                    break;

                case "Students by Staff (Id)":

                    resourceId = GetResourceId(
                        "Staff",
                        new
                        {
                            StaffUniqueId = 207268
                        });

                    requestUrl = $"enrollment/staffs/{resourceId}/students";
                    break;

                default:

                    throw new NotSupportedException(
                        string.Format("No request definition matched '{0}'.", requestName));
            }

            requestUrl += string.Format(
                "?{0}={1}",
                SpecialQueryStringParameters.CorrelationId,
                CompositeSteps.EstablishRequestCorrelationIdForScenario());

            var uri = OwinUriHelper.BuildCompositeUri(requestUrl);

            try
            {
                var getResponseMessage = httpClient.GetAsync(uri)
                    .Sync();
                // Save the response, and the resource collection name for the scenario
                ScenarioContext.Current.Set(getResponseMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            string json = GetContentFromResponse();
            var logger = LogManager.GetLogger(GetType());
            logger.DebugFormat("JSON response:\r\n{0}", json);
        }

        [Then(@"the queries generated should all match previously approved values")]
        public void Then_the_generated_queries_should_match_previously_approved_values()
        {
            string correlationId;

            ScenarioContext.Current.TryGetValue(ScenarioContextKeys.RequestCorrelationId, out correlationId);

            // These ApprovalTests based on the MemoryAppender seem to be unstable when run in batches
            // They are restricted to DEBUG only builds for development-level testing when changes are made.
            var appender = FeatureContext.Current.Get<MemoryAppender>();

            List<string> queries;

            if (string.IsNullOrEmpty(correlationId))
            {
                queries = appender.GetEvents()
                                  .Where(evt => evt.RenderedMessage.StartsWith("HQL:"))
                                  .Select(evt => evt.RenderedMessage)
                                  .ToList();

                appender.Clear();
            }
            else
            {
                queries = appender.GetEvents()
                                  .Where(evt => evt.RenderedMessage.StartsWith(string.Format("HQL[{0}]:", correlationId)))

                                   // Normalize the output, removing the correlation Id
                                  .Select(evt => Regex.Replace(evt.RenderedMessage, @"HQL\[[0-9a-f]{32}\]:", "HQL:"))
                                  .ToList();
            }

            Approvals.Verify(string.Join("\r\n", queries));
        }

        private static string GetContentFromResponse()
        {
            // Deserialize the dynamic data object from the JSON response content
            var responseMessage = ScenarioContext.Current.Get<HttpResponseMessage>();

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(string.Format("Request failed with status '{0}'.", responseMessage.StatusCode));
            }

            var httpContent = responseMessage.Content;

            string content = httpContent.ReadAsStringAsync()
                                        .Sync();

            return content;
        }
    }
}
