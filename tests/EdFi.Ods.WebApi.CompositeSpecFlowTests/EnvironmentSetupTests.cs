// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    [TestFixture]
    public class EnvironmentSetupTests
    {
        [Test]
        public async Task ShouldBuildDbAndSetupWebServer()
        {
            string connectionString =
                $"Server=(local); Database={CompositesSpecFlowTestFixture.SpecFlowDatabaseName}; Trusted_Connection=True; Application Name=EdFi.Ods.WebApi;";

            var cancellationToken = new CancellationToken();
            await using var conn = new SqlConnection(connectionString);

            await conn.OpenAsync(cancellationToken);

            int count = await conn.QuerySingleAsync<int>("select count(*) from dbo.DeployJournal;", cancellationToken);

            count.ShouldNotBe(0);

            var response = await new HttpClient().GetAsync(CompositesTestConstants.BaseUrl, cancellationToken);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            json.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
