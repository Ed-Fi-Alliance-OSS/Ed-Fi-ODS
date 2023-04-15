// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.WebApi.IntegrationTests.Helpers;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    [TestFixture]
    public class StudentTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _cancellationToken = GlobalWebApiIntegrationTestFixture.Instance.CancellationToken;
            _uriHelper = new EdFiTestUriHelper(TestConstants.BaseUrl);
            _httpClient = HostGlobalFixture.Instance.HttpClient;
        }

        private CancellationToken _cancellationToken;
        private EdFiTestUriHelper _uriHelper;
        private HttpClient _httpClient;

        [Test]
        public async Task Should_update_the_db()
        {
            string uniqueId1 = Guid.NewGuid().ToString("N");
            string uniqueId2 = Guid.NewGuid().ToString("N");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString("n"));

            var createResponse1 = await _httpClient.PostAsync(
                _uriHelper.BuildOdsUri("students", null),
                new StringContent(
                    ResourceHelper.CreateStudent(
                        uniqueId1,
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture),
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture)),
                    Encoding.UTF8,
                    "application/json"), _cancellationToken);

            try
            {
                createResponse1.EnsureSuccessStatusCode();
            }
            catch
            {
                Console.WriteLine(createResponse1.ToString());
                throw;
            }

            var createResponse2 = await _httpClient.PostAsync(
                _uriHelper.BuildOdsUri("students", null),
                new StringContent(
                    ResourceHelper.CreateStudent(
                        uniqueId2,
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture),
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture)),
                    Encoding.UTF8,
                    "application/json"), _cancellationToken);

            try
            {
                createResponse2.EnsureSuccessStatusCode();
            }
            catch
            {
                Console.WriteLine(createResponse2.ToString());
                throw;
            }

            int? exists1 = await StudentExistsAsync(uniqueId1);
            int? exists2 = await StudentExistsAsync(uniqueId2);

            exists1.ShouldNotBeNull();
            exists2.ShouldNotBeNull();
        }

        private async Task<int?> StudentExistsAsync(string uniqueId)
        {
            using var conn = HostGlobalFixture.Instance.BuildOdsConnection();
            
            return await conn.QuerySingleOrDefaultAsync<int?>(
                $"SELECT 1 FROM edfi.Student WHERE StudentUniqueId = '{uniqueId}'", _cancellationToken);
        }
    }
}
