// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.WebService.Tests.AuthorizationTests;
using EdFi.Ods.WebService.Tests.Owin;
using EdFi.Ods.WebService.Tests._Helpers;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.WebService.Tests.Infrastructure
{
    // These tests exist to attempt to prevent the creation of windsor container memory leaks in the future.
    // The Windsor container provides diagnostics that tell you how many instances are currently being
    // tracked by the container.   On completion of a request, this number should be zero, as we should
    // have properly released anything that would require tracking.  If these tests find issues,
    // review the ioc configuration to determine what's causing an instance to be tracked.
    [TestFixture]
    public class WindsorTrackedComponentsTests : OwinTestBase
    {
        private const int StateEducationAgencyId = 31;
        private const int Lea1Id = 2001;
        private const int Lea2Id = 2002;
        private const int Lea3Id = 2003;
        private const int School1Id = 200101;
        private const int School2Id = 200102;
        private const int School3Id = 200103;

        private readonly List<int> _localEducationAgencyIds = new List<int>
                                                              {
                                                                  Lea1Id
                                                              };

        // These tests fail with timeout when trying to use the shared transacted database
        protected override bool CreateDatabase
        {
            get { return true; }
        }

        public override void SetUp()
        {
            base.SetUp();

            var helper = new DataSeedHelper(DatabaseName);
            helper.CreateStateEducationAgency(StateEducationAgencyId);

            helper.CreateLocalEducationAgency(Lea1Id, StateEducationAgencyId);
            helper.CreateLocalEducationAgency(Lea2Id, StateEducationAgencyId);
            helper.CreateLocalEducationAgency(Lea3Id, StateEducationAgencyId);

            helper.CreateSchool(School1Id, Lea1Id);
            helper.CreateSchool(School2Id, Lea2Id);
            helper.CreateSchool(School3Id, Lea3Id);
        }

        [Test]
        public void When_creating_a_student_should_not_leave_any_tracked_components()
        {
            using (var startup = new OwinStartup(DatabaseName, _localEducationAgencyIds))
            {
                var trackedComponents = startup.GetTrackedComponents();
                int trackedComponentCount = trackedComponents.Count();
                trackedComponentCount.ShouldBe(0);

                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        var createResponse = StudentHelper.CreateStudent(client, DataSeedHelper.RandomName, DataSeedHelper.RandomName);
                        createResponse.ResponseMessage.EnsureSuccessStatusCode();
                        createResponse.ResponseMessage.StatusCode.ShouldBe(HttpStatusCode.Created);
                    }

                    trackedComponents = startup.GetTrackedComponents();
                    trackedComponentCount = trackedComponents.Count();

                    trackedComponentCount.ShouldBe(
                        0,
                        "Tracked Components: " + string.Join(", ", trackedComponents.Select(tc => tc.Key.ToString())));
                }
            }
        }

        [Test]
        public void When_deleting_an_unused_student_should_not_leave_any_tracked_components()
        {
            using (var startup = new OwinStartup(DatabaseName, _localEducationAgencyIds))
            {
                var trackedComponents = startup.GetTrackedComponents();
                int trackedComponentCount = trackedComponents.Count();
                trackedComponentCount.ShouldBe(0);

                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        var createResponse = StudentHelper.CreateStudent(client, DataSeedHelper.RandomName, DataSeedHelper.RandomName);
                        createResponse.ResponseMessage.EnsureSuccessStatusCode();

                        var deleteResponse = client.DeleteAsync(createResponse.ResponseMessage.Headers.Location.AbsoluteUri)
                                                   .Result;

                        deleteResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);
                    }

                    trackedComponents = startup.GetTrackedComponents();
                    trackedComponentCount = trackedComponents.Count();

                    trackedComponentCount.ShouldBe(
                        0,
                        "Tracked Components: " + string.Join(", ", trackedComponents.Select(tc => tc.Key.ToString())));
                }
            }
        }

        [Test]
        public void When_getting_student_by_example_should_not_leave_any_tracked_components()
        {
            var authorizedFirstName = "John";
            var authorizedLastName = string.Format("A{0}", DataSeedHelper.RandomName);

            var unauthorizedFirstName = "Other";
            var unauthorizedLastName = string.Format("U{0}", DataSeedHelper.RandomName);

            var localEducationAgencyIds = new List<int>
                                          {
                                              Lea1Id, Lea2Id
                                          };

            using (var startup = new OwinStartup(DatabaseName, localEducationAgencyIds))
            {
                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        //1st Student
                        var studentCreateResponse = StudentHelper.CreateStudentAndAssociateToSchool(
                            client,
                            authorizedLastName,
                            authorizedFirstName,
                            School1Id);

                        studentCreateResponse.ResponseMessage.EnsureSuccessStatusCode();

                        //2nd Student
                        studentCreateResponse = StudentHelper.CreateStudentAndAssociateToSchool(
                            client,
                            unauthorizedLastName,
                            unauthorizedFirstName,
                            School2Id);

                        studentCreateResponse.ResponseMessage.EnsureSuccessStatusCode();
                    }
                }
            }

            localEducationAgencyIds = new List<int>
                                      {
                                          Lea1Id
                                      };

            using (var startup = new OwinStartup(DatabaseName, localEducationAgencyIds))
            {
                var trackedComponents = startup.GetTrackedComponents();
                int trackedComponentCount = trackedComponents.Count();
                trackedComponentCount.ShouldBe(0);

                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        var authorizedResult = client
                                              .GetAsync(OwinUriHelper.BuildOdsUri("students", queryString: $"LastSurname={authorizedLastName}"))
                                              .Result;

                        authorizedResult.EnsureSuccessStatusCode();
                        authorizedResult.StatusCode.ShouldBe(HttpStatusCode.OK);

                        var students = DefaultTestJsonSerializer.DeserializeObject<Student[]>(
                            authorizedResult.Content.ReadAsStringAsync()
                                            .Result);

                        students.Length.ShouldBe(1);

                        students[0]
                           .FirstName.ShouldBe(authorizedFirstName);

                        var unauthorizedResult = client
                                                .GetAsync(OwinUriHelper.BuildOdsUri("students", queryString: $"LastSurname={unauthorizedLastName}"))
                                                .Result;

                        unauthorizedResult.StatusCode.ShouldBe(HttpStatusCode.OK);

                        students = DefaultTestJsonSerializer.DeserializeObject<Student[]>(
                            unauthorizedResult.Content.ReadAsStringAsync()
                                              .Result);

                        students.Length.ShouldBe(0);
                    }

                    trackedComponents = startup.GetTrackedComponents();
                    trackedComponentCount = trackedComponents.Count();

                    trackedComponentCount.ShouldBe(
                        0,
                        "Tracked Components: " + string.Join(", ", trackedComponents.Select(tc => tc.Key.ToString())));
                }
            }
        }

        [Test]
        public void When_getting_student_by_id_should_not_leave_any_tracked_components()
        {
            string authorizedStudentUri;

            var localEducationAgencyIds = new List<int>
                                          {
                                              Lea1Id, Lea2Id
                                          };

            using (var startup = new OwinStartup(DatabaseName, localEducationAgencyIds))
            {
                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        //1st Student
                        var studentCreateResponse = StudentHelper.CreateStudentAndAssociateToSchool(
                            client,
                            DataSeedHelper.RandomName,
                            DataSeedHelper.RandomName,
                            School1Id);

                        studentCreateResponse.ResponseMessage.EnsureSuccessStatusCode();
                        authorizedStudentUri = studentCreateResponse.ResponseMessage.Headers.Location.AbsoluteUri;
                    }
                }
            }

            using (var startup = new OwinStartup(DatabaseName, localEducationAgencyIds))
            {
                var trackedComponents = startup.GetTrackedComponents();
                int trackedComponentCount = trackedComponents.Count();
                trackedComponentCount.ShouldBe(0);

                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        var authorizedResult = client.GetAsync(authorizedStudentUri)
                                                     .Result;

                        authorizedResult.EnsureSuccessStatusCode();
                        authorizedResult.StatusCode.ShouldBe(HttpStatusCode.OK);
                    }

                    trackedComponents = startup.GetTrackedComponents();
                    trackedComponentCount = trackedComponents.Count();

                    trackedComponentCount.ShouldBe(
                        0,
                        "Tracked Components: " + string.Join(", ", trackedComponents.Select(tc => tc.Key.ToString())));
                }
            }
        }
    }
}
