// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Common.Configuration;
using NUnit.Framework;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    [TestFixture]
    public class EnvironmentSetupTests
    {
        [Test]
        public async Task ShouldBuildDbAndSetupWebServer()
        {
            var cancellationToken = new CancellationToken();
            using var conn = CompositesSpecFlowTestFixture.Instance.BuildOdsConnection();

            int count;

            if (CompositesSpecFlowTestFixture.Instance.DatabaseEngine == DatabaseEngine.SqlServer)
            {
                count = await conn.QuerySingleAsync<int>("select count(*) from dbo.DeployJournal;", cancellationToken);
            }
            else
            {
                count = await conn.QuerySingleAsync<int>("select count(*) from public.\"DeployJournal\";", cancellationToken);
            }

            count.ShouldNotBe(0);

            var response = await new HttpClient().GetAsync(CompositesTestConstants.BaseUrl, cancellationToken);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            json.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
