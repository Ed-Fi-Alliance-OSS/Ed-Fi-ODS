// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Database;
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
            var databaseEngine = DbHelper.GetDatabaseEngine();

            var connectionStringProvider = (IOdsDatabaseConnectionStringProvider)
                CompositesSpecFlowTestFixture.ServiceProvider.GetService(typeof(IOdsDatabaseConnectionStringProvider));

            connectionStringProvider.ShouldNotBeNull();
            connectionStringProvider.GetConnectionString().ShouldContain(CompositesSpecFlowTestFixture.SpecFlowDatabaseName);

            var cancellationToken = new CancellationToken();
            using var conn = DbHelper.GetConnection(databaseEngine, connectionStringProvider.GetConnectionString());
            conn.Open();

            int count = 0;
            if (databaseEngine == DatabaseEngine.SqlServer)
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
