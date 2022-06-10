// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using EdFi.Common.Configuration;
using EdFi.Common.Inflection;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.WebApi.CompositeSpecFlowTests.Dtos;
using log4net;
using log4net.Appender;
using Shouldly;
using TechTalk.SpecFlow;
using Test.Common;

// ReSharper disable InconsistentNaming
namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    [Binding]
    [UseReporter(typeof(DiffReporter))]
    [IgnoreLineEndings(true)]
    public class Steps
    {
        private readonly Lazy<IOdsDatabaseConnectionStringProvider> _connectionStringProvider;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly Lazy<CancellationToken> _cancellationToken;
        private EdFiTestUriHelper _edFiTestUriHelper;
        private DatabaseEngine _databaseEngine;
        public Steps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

            _cancellationToken = new Lazy<CancellationToken>(() => _featureContext.Get<CancellationToken>());

            _connectionStringProvider = new Lazy<IOdsDatabaseConnectionStringProvider>(
                () =>
                {
                    var provider = (IOdsDatabaseConnectionStringProvider) _featureContext.Get<IServiceProvider>()
                        .GetService(typeof(IOdsDatabaseConnectionStringProvider));

                    provider.ShouldNotBeNull();

                    return provider;
                });

            _edFiTestUriHelper = new EdFiTestUriHelper(CompositesTestConstants.BaseUrl);
            _databaseEngine = DbHelper.GetDatabaseEngine();
        }

        [Given(@"the subject of the request is a StudentEducationOrganizationAssociation")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentEducationOrganizationAssociation()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"SELECT TOP 1 Id FROM edfi.StudentEducationOrganizationAssociation;";
            }
            else
            {
                query = @"SELECT Id FROM edfi.StudentEducationOrganizationAssociation LIMIT 1;";
            }

            await SetIdAsync(query);
            SetResource("StudentEducationOrganizationAssociation");
        }

        [Given(@"the subject of the request is a school with student and staff associations")]
        public async Task GivenTheSubjectOfTheRequestIsASchoolWithStudentAndStaffAssociations()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 eo.Id
                    FROM edfi.School s
                    INNER JOIN edfi.EducationOrganization eo ON s.SchoolId = eo.EducationOrganizationId
                    INNER JOIN edfi.SchoolCategory sc ON s.SchoolId = sc.SchoolId
                    INNER JOIN edfi.StudentSchoolAssociation ssa ON s.SchoolId = ssa.SchoolId
                    INNER JOIN edfi.StaffSchoolAssociation stsa ON s.SchoolId = stsa.SchoolId";
            }
            else
            {
                query = @"
                    SELECT  eo.Id
                    FROM edfi.School s
                    INNER JOIN edfi.EducationOrganization eo ON s.SchoolId = eo.EducationOrganizationId
                    INNER JOIN edfi.SchoolCategory sc ON s.SchoolId = sc.SchoolId
                    INNER JOIN edfi.StudentSchoolAssociation ssa ON s.SchoolId = ssa.SchoolId
                    INNER JOIN edfi.StaffSchoolAssociation stsa ON s.SchoolId = stsa.SchoolId
                    LIMIT 1";
            }

            await SetIdAsync(query);
            SetResource("School");
        }

        [Given(@"the subject of the request is a student with a StudentAcademicRecord")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentWithAStudentAcademicRecord()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                SELECT  TOP 1 s.Id
                FROM    edfi.Student s
                INNER JOIN edfi.StudentAcademicRecord sar ON s.StudentUSI = sar.StudentUSI";
            }
            else
            {
                query = @"
                SELECT  s.Id
                FROM    edfi.Student s
                INNER JOIN edfi.StudentAcademicRecord sar ON s.StudentUSI = sar.StudentUSI
                LIMIT 1";
            }

            await SetIdAsync(query);
            SetResource("Student");
        }

        [Given(@"the subject of the request is a student with values in all name properties")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentWithValuesInAllNameProperties()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 Id
                    FROM    edfi.Student
                    WHERE   PersonalTitlePrefix IS NOT NULL
                            AND FirstName IS NOT NULL
                            AND MiddleName IS NOT NULL
                            AND LastSurname IS NOT NULL
                            AND GenerationCodeSuffix IS NOT NULL";
            }
            else
            {
                query = @"
                    SELECT  Id
                    FROM    edfi.Student
                    WHERE   PersonalTitlePrefix IS NOT NULL
                            AND FirstName IS NOT NULL
                            AND MiddleName IS NOT NULL
                            AND LastSurname IS NOT NULL
                            AND GenerationCodeSuffix IS NOT NULL
                    LIMIT 1";

            }

            await SetIdAsync(query);
            SetResource("Student");
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentSchoolAssociation()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 sa.Id
                    FROM    edfi.StudentSchoolAssociation sa
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId edOrgs
                            ON sa.SchoolId = edOrgs.TargetEducationOrganizationId
                    WHERE edOrgs.SourceEducationOrganizationId = 255901";
            }
            else
            {
                query = @"
                    SELECT  sa.Id
                    FROM    edfi.StudentSchoolAssociation sa
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId edOrgs
                            ON sa.SchoolId = edOrgs.TargetEducationOrganizationId
                    WHERE edOrgs.SourceEducationOrganizationId = 255901
                    LIMIT 1";
            }

            await SetIdAsync(query);
            SetResource("StudentSchoolAssociation");
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation with StudentAssessment")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentSchoolAssociationWithStudentAssessment()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM edfi.StudentSchoolAssociation ssa
                    INNER JOIN edfi.Student stu 
                        ON ssa.StudentUSI = stu.StudentUSI
                    INNER JOIN edfi.StudentAssessment sa
                        ON ssa.StudentUSI = sa.StudentUSI";
            }
            else
            {
                query = @"
                    SELECT  ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM edfi.StudentSchoolAssociation ssa
                    INNER JOIN edfi.Student stu 
                        ON ssa.StudentUSI = stu.StudentUSI
                    INNER JOIN edfi.StudentAssessment sa
                        ON ssa.StudentUSI = sa.StudentUSI
                    LIMIT 1";
            }

            await SetStudentSchoolAssociationKeyInformationAsync(query);
            SetResource("StudentSchoolAssociation");
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation with School")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentSchoolAssociationWithSchool()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM    edfi.StudentSchoolAssociation ssa
                        INNER JOIN edfi.School sc 
                            ON ssa.SchoolId = sc.SchoolId
                        INNER JOIN edfi.Student stu
                            ON ssa.StudentUSI = stu.StudentUSI
                    WHERE LocalEducationAgencyId IS NOT NULL";
            }
            else
            {
                query = @"
                    SELECT  ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM    edfi.StudentSchoolAssociation ssa
                        INNER JOIN edfi.School sc 
                            ON ssa.SchoolId = sc.SchoolId
                        INNER JOIN edfi.Student stu
                            ON ssa.StudentUSI = stu.StudentUSI
                    WHERE LocalEducationAgencyId IS NOT NULL
                    LIMIT 1";
            }
            await SetStudentSchoolAssociationKeyInformationAsync(query);
            SetResource("StudentSchoolAssociation");
        }

        [Given(@"the subject of the request is a StudentAssessment with ObjectAssessmentScoreResults")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentAssessmentWithObjectAssessmentScoreResults()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 sa.Id
                    FROM    edfi.StudentAssessment sa 
                    INNER JOIN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult sr
                    ON sa.AssessmentIdentifier = sr.AssessmentIdentifier
                    AND sa.Namespace = sr.Namespace
                    AND sa.StudentAssessmentIdentifier = sr.StudentAssessmentIdentifier
                    AND sa.StudentUSI = sr.StudentUSI";
            }
            else
            {
                query = @"
                    SELECT  sa.Id
                    FROM    edfi.StudentAssessment sa 
                    INNER JOIN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult sr
                    ON sa.AssessmentIdentifier = sr.AssessmentIdentifier
                    AND sa.Namespace = sr.Namespace
                    AND sa.StudentAssessmentIdentifier = sr.StudentAssessmentIdentifier
                    AND sa.StudentUSI = sr.StudentUSI
                    LIMIT 1";
            }
            await SetIdAsync(query);
            SetResource("StudentAssessment");
        }

        [Given(@"the subject of the request is a StudentAssessment with StudentAssessmentStudentObjectiveAssessment")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentAssessmentWithStudentAssessmentStudentObjectiveAssessment()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
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
            }
            else
            {
                query = @"
                    SELECT  sa.Id, 
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
                                AND sa.StudentUSI = oa.StudentUSI
                    LIMIT 1";
            }
            await SetAssessmentKeyInformationAsync(query);
            SetResource("StudentAssessment");
        }

        [Given(@"the subject of the request is a student with a StudentSchoolAssociation")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentWithAStudentSchoolAssociation()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 s.Id
                    FROM    edfi.Student s
                    INNER JOIN edfi.StudentSchoolAssociation sa ON s.StudentUSI = sa.StudentUSI
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId edOrgs
                            ON sa.SchoolId = edOrgs.TargetEducationOrganizationId
                    WHERE edOrgs.SourceEducationOrganizationId = 255901";
            }
            else
            {
                query = @"
                    SELECT  s.Id
                    FROM    edfi.Student s
                    INNER JOIN edfi.StudentSchoolAssociation sa ON s.StudentUSI = sa.StudentUSI
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId edOrgs
                            ON sa.SchoolId = edOrgs.TargetEducationOrganizationId
                    WHERE edOrgs.SourceEducationOrganizationId = 255901
                    LIMIT 1";
            }

            await SetIdAsync(query);
            SetResource("Student");
        }

        [Given(@"the subject of the request is a student with a StudentEducationOrganizationAssociation")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentWithAStudentEducationOrganizationAssociation()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
                    SELECT  TOP 1 s.Id
                    FROM    edfi.Student s
                    INNER JOIN edfi.StudentEducationOrganizationAssociation ssa ON s.StudentUSI = ssa.StudentUSI";
            }
            else
            {
                query = @"
                    SELECT  s.Id
                    FROM    edfi.Student s
                    INNER JOIN edfi.StudentEducationOrganizationAssociation ssa ON s.StudentUSI = ssa.StudentUSI
                    LIMIT 1";
            }
            

            await SetIdAsync(query);
            SetResource("Student");
        }

        [Given(@"the subject of the request is a StudentSchoolAssociation with School and StudentAssessment")]
        public async Task GivenTheSubjectOfTheRequestIsAStudentSchoolAssociationWithSchoolAndStudentAssessment()
        {
            string query;

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                query = @"
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

            }
            else
            {
                query = @"
                SELECT  ssa.Id, stu.StudentUniqueId, ssa.SchoolId, ssa.EntryDate
                    FROM    edfi.StudentSchoolAssociation ssa
                        INNER JOIN edfi.School sc 
                            ON ssa.SchoolId = sc.SchoolId
                        INNER JOIN edfi.Student stu
                            ON ssa.StudentUSI = stu.StudentUSI
                        INNER JOIN edfi.StudentAssessment sa
                            ON ssa.StudentUSI = sa.StudentUSI
                    WHERE sc.LocalEducationAgencyId IS NOT NULL
                        AND sa.AssessmentIdentifier IS NOT NULL
                    LIMIT 1";
            }

            await SetStudentSchoolAssociationKeyInformationAsync(query);
            SetResource("StudentSchoolAssociation");
        }

        [When(@"a GET \(by id\) request is submitted to the ""(.*)"" composite")]
        public async Task WhenAGETByIdRequestIsSubmittedToTheComposite(string compositeName)
        {
            // Default the category to test, if not specified
            var compositeCategoryName = "test";

            var httpClient = StepsHelper.GetHttpClient();

            var subjectId = _scenarioContext.Get<Guid>(ScenarioContextKeys.CompositeSubjectId);

            var pluralizedCompositeName = CompositeTermInflector.MakePlural(compositeName);

            string correlationId = Guid.NewGuid().ToString("n");

            SetCorrelationId(correlationId);

            string requestUrl = _edFiTestUriHelper.BuildCompositeUri(
                $"{compositeCategoryName}/{pluralizedCompositeName}/{subjectId:n}{StepsHelper.GetQueryString(correlationId)}");

            var response = await httpClient.GetAsync(requestUrl, _cancellationToken.Value);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [When(@"the ""(.*)"" request is submitted")]
        public async Task WhenTheRequestIsSubmitted(string requestName)
        {
            string requestUrl = null;
            Guid resourceId;

            switch (requestName)
            {
                case "School by Id":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901001},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/schools/{resourceId}";
                    break;

                case "Schools by Local Education Agency (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/schools";
                    break;

                case "Schools by Section (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Section",
                        new {SectionIdentifier = "25590100101Trad120ENG112011"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/sections/{resourceId}/schools";
                    break;

                case "Schools by Staff (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Staff",
                        new {StaffUniqueId = "207268"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/staffs/{resourceId}/schools";
                    break;

                case "Section by Id":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Section",
                        new {SectionIdentifier = "25590100101Trad120ENG112011"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/sections/{resourceId}";
                    break;

                case "Sections by Local Education Agency (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/sections";
                    break;

                case "Sections by School (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901001},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/schools/{resourceId}/sections";
                    break;

                case "Sections by Staff (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Staff",
                        new {StaffUniqueId = "207268"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/staffs/{resourceId}/sections";
                    break;

                case "Staff by Id":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Staff",
                        new {StaffUniqueId = "207268"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/staffs/{resourceId}";
                    break;

                case "Staffs by Local Education Agency (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/staffs";
                    break;

                case "Staffs by School (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901001},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/schools/{resourceId}/staffs";
                    break;

                case "Staffs by Section (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Section",
                        new {SectionIdentifier = "25590100101Trad120ENG112011"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/sections/{resourceId}/staffs";
                    break;

                case "Student by Id":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Student",
                        new {StudentUniqueId = "605042"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/students/{resourceId}";
                    break;

                case "Students by Local Education Agency (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/localEducationAgencies/{resourceId}/students";
                    break;

                case "Students by School (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "EducationOrganization",
                        new {EducationOrganizationId = 255901001},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/schools/{resourceId}/students";
                    break;

                case "Students by Section (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Section",
                        new {SectionIdentifier = "25590100101Trad120ENG112011"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/sections/{resourceId}/students";
                    break;

                case "Students by Staff (Id)":

                    resourceId = await StepsHelper.GetResourceIdAsync(
                        _connectionStringProvider.Value.GetConnectionString(),
                        "Staff",
                        new {StaffUniqueId = "207268"},
                        _cancellationToken.Value);

                    requestUrl = $"enrollment/staffs/{resourceId}/students";
                    break;

                default:

                    throw new NotSupportedException(
                        string.Format("No request definition matched '{0}'.", requestName));
            }

            string correlationId = Guid.NewGuid().ToString("n");

            SetCorrelationId(correlationId);

            requestUrl += StepsHelper.GetQueryString(correlationId);

            string uri = _edFiTestUriHelper.BuildCompositeUri(requestUrl);

            string json = null;

            var httpClient = StepsHelper.GetHttpClient();
            var response = await httpClient.GetAsync(uri, _cancellationToken.Value);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            json = await response.Content.ReadAsStringAsync();

            var logger = LogManager.GetLogger(GetType());
            logger.Debug($"JSON response:{Environment.NewLine}{json}");
        }

        [Then(@"the queries generated should all match previously approved values")]
        [IgnoreLineEndings((true))]
        public void ThenTheQueriesGeneratedShouldAllMatchPreviouslyApprovedValues()
        {
            _scenarioContext.TryGetValue(ScenarioContextKeys.RequestCorrelationId, out string correlationId);

            // These ApprovalTests based on the MemoryAppender seem to be unstable when run in batches
            // They are restricted to DEBUG only builds for development-level testing when changes are made.
            var appender = _featureContext.Get<MemoryAppender>();

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

            Approvals.Verify(string.Join($"{Environment.NewLine}", queries));
        }

        private void SetCorrelationId(string correlationId)
            => _scenarioContext.Set(correlationId, ScenarioContextKeys.RequestCorrelationId);

        private void SetResource(string resourceName)
            => _scenarioContext.Set(resourceName, ScenarioContextKeys.CompositeSubjectResourceName);

        private async Task SetStudentSchoolAssociationKeyInformationAsync(string query)
        {
            var dto = await StepsHelper.GetAsync<StudentSchoolKeyInformation>(
                _connectionStringProvider.Value.GetConnectionString(), query, _cancellationToken.Value);

            dto.ShouldNotBeNull();

            _scenarioContext.Set(dto.Id, ScenarioContextKeys.CompositeSubjectId);

            var keyValueByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"StudentUniqueId", dto.StudentUniqueId},
                {"SchoolId", dto.SchoolId},
                {"EntryDate", dto.EntryDate}
            };

            _scenarioContext.Set(keyValueByName, ScenarioContextKeys.CompositeSubjectKey);
        }

        private async Task SetAssessmentKeyInformationAsync(string query)
        {
            var dto = await StepsHelper.GetAsync<StudentAssessmentKeyInformation>(
                _connectionStringProvider.Value.GetConnectionString(), query, _cancellationToken.Value);

            dto.ShouldNotBeNull();

            _scenarioContext.Set(dto.Id, ScenarioContextKeys.CompositeSubjectId);

            var keyValueByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"StudentAssessmentIdentifier", dto.StudentAssessmentIdentifier},
                {"AssessmentIdentifier", dto.AssessmentIdentifier},
                {"Namespace", dto.Namespace},
                {"StudentUniqueId", dto.StudentUniqueId}
            };

            _scenarioContext.Set(keyValueByName, ScenarioContextKeys.CompositeSubjectKey);
        }

        private async Task SetIdAsync(string query)
        {
            var id = await StepsHelper.GetAsync<Guid>(
                _connectionStringProvider.Value.GetConnectionString(), query, _cancellationToken.Value);

            id.ShouldNotBe(default(Guid));

            _scenarioContext.Set(id, ScenarioContextKeys.CompositeSubjectId);
        }
    }
}
