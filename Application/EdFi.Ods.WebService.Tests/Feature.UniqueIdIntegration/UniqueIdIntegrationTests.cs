// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.WebService.Tests.Owin;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace EdFi.Ods.WebService.Tests.Feature.UniqueIdIntegration
{
    [TestFixture]
    public class UniqueIdIntegrationTests : OwinTestBase
    {
        // Actual responses WITHOUT UniqueId integration
        private static HttpResponseMessage _actualResponseForCreateUsingPutWithoutUniqueIdIntegration;

        // Actual responses WITH UniqueId integration
        private static HttpResponseMessage _actualResponseForCreateUsingPostWithUniqueIdIntegration;
        private static HttpResponseMessage _actualResponseForCreateUsingPutWithUniqueIdIntegration;

        private static readonly string _suppliedUniqueId = new string('1', 32);

        public override void SetUp()
        {
            base.SetUp();

            // Client-supplied resource id using PUT (legacy 2.x behavior that should now fail)
            using (var startup = new UniqueIdIntegrationOwinTestStartup(
                DatabaseName, DefaultLocalEducationAgencyIds,
                // Configure WITHOUT UniqueId integration
                useUniqueIdIntegration: false))
            {
                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = new TimeSpan(0, 0, 15, 0);

                        client.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString());

                        // Attempt to PUT (create) the Student resource using client-supplied resourceId in URL
                        // (legacy 2.x behavior that should now fail)
                        var student = CreateStudentJson();

                        string url = OwinUriHelper.BuildOdsUri("students");
                        string clientAssignedId = Guid.NewGuid().ToString("n");

                        _actualResponseForCreateUsingPutWithoutUniqueIdIntegration = Put(client, student, url, clientAssignedId);
                    }
                }
            }

            // Server-supplied resource id using UniqueId integration
            using (var startup = new UniqueIdIntegrationOwinTestStartup(
                DatabaseName, DefaultLocalEducationAgencyIds,
                // Configure WITH UniqueId integration
                useUniqueIdIntegration: true))
            {
                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = new TimeSpan(0, 0, 15, 0);

                        client.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString());

                        var student = CreateStudentJson();
                        string url = OwinUriHelper.BuildOdsUri("students");

                        // Attempt to PUT (create) the Student resource using client-supplied resourceId in URL
                        // (legacy 2.x behavior that should now fail)
                        string clientAssignedId = Guid.NewGuid().ToString("n");
                        _actualResponseForCreateUsingPutWithUniqueIdIntegration = Put(client, student, url, clientAssignedId);

                        // Attempt to POST the student (with server-supplied resourceId from UniqueId integration)
                        _actualResponseForCreateUsingPostWithUniqueIdIntegration = Post(client, student, url);
                    }
                }
            }
        }

        [Test]
        public void Should_allow_the_assignment_of_the_resource_id_for_new_resources_by_the_UniqueId_integration()
        {
            // This test uses the integration with the ParsedGuidUniqueIdToIdValueMapper, which simply
            // parses the supplied UniqueId to a Guid (the resource identifier)
            var response = _actualResponseForCreateUsingPostWithUniqueIdIntegration;
            var actualStatusCode = response.StatusCode;
            string message = response.Content.ReadAsStringAsync().Result;

            Assert.That(actualStatusCode, Is.EqualTo(HttpStatusCode.Created), message);

            string actualAssignedResourceId = GetIdFromLocationHeader(response);
            Assert.That(actualAssignedResourceId, Is.EqualTo(_suppliedUniqueId));
        }

        [Test]
        public void Should_fail_attempt_by_API_client_to_supply_resourceId_using_PUT_WITHOUT_uniqueId_integration_with_a_message_indicating_an_existing_resource_could_not_be_found_to_update()
        {
            var response = _actualResponseForCreateUsingPutWithoutUniqueIdIntegration;
            var actualStatusCode = response.StatusCode;
            string actualMessage = response.Content.ReadAsStringAsync().Result;

            Assert.That(actualStatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(actualMessage, Does.Contain("Resource to update was not found."));
        }

        [Test]
        public void Should_fail_attempt_by_API_client_to_supply_resourceId_using_PUT_WITH_uniqueId_integration_with_a_message_indicating_an_existing_resource_could_not_be_found_to_update()
        {
            var response = _actualResponseForCreateUsingPutWithUniqueIdIntegration;
            var actualStatusCode = response.StatusCode;
            string actualMessage = response.Content.ReadAsStringAsync().Result;

            Assert.That(actualStatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(actualMessage, Does.Contain("Resource to update was not found."));
        }

        private static HttpResponseMessage Post(HttpClient client, JObject data, string url)
        {
            string rawJson = data.ToString();
            var content = new StringContent(rawJson, Encoding.UTF8, "application/json");
            var postResponse = client.PostAsync(url, content).Result;
            return postResponse;
        }

        private static HttpResponseMessage Put(HttpClient client, JObject data, string url, string id)
        {
            string rawJson = data.ToString();
            var content = new StringContent(rawJson, Encoding.UTF8, "application/json");
            var putResponse = client.PutAsync($"{url}/{id}", content).Result;
            return putResponse;
        }

        private static string GetIdFromLocationHeader(HttpResponseMessage postResult)
        {
            if (postResult.StatusCode == HttpStatusCode.Created)
            {
                return postResult.Headers.Location.AbsoluteUri.Split('/').Last();
            }

            Console.WriteLine($"Unable to extract the 'id' from the location header of the response with status '{postResult.StatusCode}'. Response body: {postResult.Content.ReadAsStringAsync().Result}");
            return Guid.NewGuid().ToString("n");
        }

        private static readonly JsonSerializerSettings _serializerSettings 
            = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        public JObject CreateStudentJson()
        {
            var student = new Student
            {
                StudentUniqueId = _suppliedUniqueId,
                FirstName = "Initialized",
                LastSurname = "TestLast",
                BirthDate = DateTime.Today,
            };

            string jsonText = JsonConvert.SerializeObject(student, _serializerSettings);

            var json = JObject.Parse(jsonText);
            return json;
        }
    }
}