// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.WebApi.IntegrationTests.Helpers;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests.Sandbox
{
    [TestFixture]
    public class SandboxStudentTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var configuration = SandboxHostGlobalFixture.Configuration;

            _connectionStringTemplate = configuration.GetConnectionString("EdFi_Ods");
            _cancellationToken = new CancellationToken();
            _uriHelper = new EdFiTestUriHelper(TestConstants.SandboxBaseUrl);
            _httpClient = SandboxHostGlobalFixture.HttpClient;
        }

        private string _connectionStringTemplate;
        private CancellationToken _cancellationToken;
        private EdFiTestUriHelper _uriHelper;
        private HttpClient _httpClient;

        [Test]
        public async Task Should_update_the_sandbox_db()
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

            createResponse1.EnsureSuccessStatusCode();

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

            createResponse2.EnsureSuccessStatusCode();

            int? exists1 = await StudentExistsAsync(uniqueId1);
            int? exists2 = await StudentExistsAsync(uniqueId2);

            exists1.ShouldNotBeNull();
            exists2.ShouldNotBeNull();
        }

        private async Task<int?> StudentExistsAsync(string uniqueId)
        {
            string connectionString = string.Format(
                _connectionStringTemplate, $"{GlobalWebApiIntegrationTestFixture.DatabaseName}");

            using var conn = DbHelper.GetConnection(connectionString);

            conn.Open();

            return await conn.QuerySingleOrDefaultAsync<int?>(
                $"SELECT 1 FROM edfi.Student WHERE StudentUniqueId = '{uniqueId}'", _cancellationToken);
        }
    }
}
