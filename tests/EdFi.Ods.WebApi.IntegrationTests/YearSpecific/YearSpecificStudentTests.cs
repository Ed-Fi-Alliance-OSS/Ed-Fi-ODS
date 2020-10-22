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

namespace EdFi.Ods.WebApi.IntegrationTests.YearSpecific
{
    [TestFixture]
    public class YearSpecificStudentTests
    {
        private string _connectionStringTemplate;
        private CancellationToken _cancellationToken;
        private EdFiTestUriHelper _uriHelper;
        private HttpClient _httpClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _connectionStringTemplate = YearSpecificHostGlobalFixture.Configuration.GetConnectionString("EdFi_Ods");
            _cancellationToken = GlobalWebApiIntegrationTestFixture.CancellationToken;
            _uriHelper = new EdFiTestUriHelper(TestConstants.YearSpecificBaseUrl);
            _httpClient = YearSpecificHostGlobalFixture.HttpClient;
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            _httpClient.Dispose();
        }

        [Test]
        public async Task Should_update_specified_instance_db()
        {
            string uniqueId2014 = Guid.NewGuid().ToString("N");
            string uniqueId2015 = Guid.NewGuid().ToString("N");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString("n"));

            var create2014Response = await _httpClient.PostAsync(
                _uriHelper.BuildOdsUri("students", 2014),
                new StringContent(
                    ResourceHelper.CreateStudent(
                        uniqueId2014,
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture),
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture)),
                    Encoding.UTF8,
                    "application/json"), _cancellationToken);

            create2014Response.EnsureSuccessStatusCode();

            var create2015Response = await _httpClient.PostAsync(
                _uriHelper.BuildOdsUri("students", 2015),
                new StringContent(
                    ResourceHelper.CreateStudent(
                        uniqueId2015,
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture),
                        DateTime.Now.Ticks.ToString(
                            CultureInfo.InvariantCulture)),
                    Encoding.UTF8,
                    "application/json"), _cancellationToken);

            create2015Response.EnsureSuccessStatusCode();

            int? exists2014 = await StudentExistsAsync(2014, uniqueId2014);
            int? notExists2014 = await StudentExistsAsync(2015, uniqueId2014);
            int? exists2015 = await StudentExistsAsync(2015, uniqueId2015);
            int? notExists2015 = await StudentExistsAsync(2014, uniqueId2015);

            exists2014.ShouldNotBeNull();
            notExists2014.ShouldBeNull();
            exists2015.ShouldNotBeNull();
            notExists2015.ShouldBeNull();
        }

        private async Task<int?> StudentExistsAsync(int schoolYear, string uniqueId)
        {
            string connectionString = string.Format(
                _connectionStringTemplate, $"{GlobalWebApiIntegrationTestFixture.DatabaseName}_{schoolYear}");

            await using var conn = new SqlConnection(connectionString);

            await conn.OpenAsync(_cancellationToken);

            return await conn.QuerySingleOrDefaultAsync<int?>(
                $"SELECT 1 FROM edfi.Student WHERE StudentUniqueId = '{uniqueId}'", _cancellationToken);
        }
    }
}
