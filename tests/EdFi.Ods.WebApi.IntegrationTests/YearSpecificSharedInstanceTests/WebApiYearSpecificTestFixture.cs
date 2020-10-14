// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac.Extensions.DependencyInjection;
using EdFi.Ods.Api.Models.Identity;
using EdFi.Ods.Common.Context;
using EdFi.Ods.WebApi.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests.YearSpecificSharedInstanceTests
{
    [TestFixture]
    public class WebApiYearSpecificTestFixture
    {
        public IConfigurationRoot Configuration { get; set; }

        public const string DatabaseName_2014 =
            "EdFi_Tests_When_putting_a_resource_to_a_shared_year_specific_instance_2014";

        public const string DatabaseName_2015 =
            "EdFi_Tests_When_putting_a_resource_to_a_shared_year_specific_instance_2015";

        private DatabaseHelper _databaseHelper;

        public static string PopulatedDatabaseName { get; set; }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.yearspecific.json", optional: true)
                .Build();

            PopulatedDatabaseName = Configuration.GetSection("TestDatabaseTemplateName").Value ??
                                    "EdFi_Ods_Populated_Template_Test";

            _databaseHelper = new DatabaseHelper(Configuration);
            _databaseHelper.CopyDatabase(PopulatedDatabaseName, DatabaseName_2014);
            _databaseHelper.CopyDatabase(PopulatedDatabaseName, DatabaseName_2015);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _databaseHelper.DropDatabase(DatabaseName_2014);
            _databaseHelper.DropDatabase(DatabaseName_2015);
        }

        public bool StudentExists(int year, string uniqueId)
        {
            using (var conn = new SqlConnection(GetConnectionString(year)))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT 1 FROM [edfi].[Student] WHERE StudentUniqueId = @uniqueId";
                    cmd.Parameters.AddWithValue("@uniqueId", uniqueId);
                    var retval = cmd.ExecuteScalar();
                    return retval != null;
                }
            }
        }

        public string GetConnectionString(int schoolYear)
        {
            var builder = new SqlConnectionStringBuilder(
                Configuration.GetConnectionString("EdFi_Ods"));

            if (schoolYear == 2014)
            {
                builder.InitialCatalog = DatabaseName_2014;
            }

            if (schoolYear == 2015)
            {
                builder.InitialCatalog = DatabaseName_2015;
            }

            return builder.ConnectionString;
        }

        public async Task<string> ExtractIdFromHttpResponse(HttpResponseMessage responseMessage)
        {
            var uniqueId = Guid.NewGuid()
                               .ToString("N");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return uniqueId;
            }

            var json = await responseMessage.Content.ReadAsStringAsync();
            var identitySearchResponses = JsonConvert.DeserializeObject<IdentitySearchResponse>(json).SearchResponses.ToList();

            if (!identitySearchResponses.Any())
            {
                return uniqueId;
            }

            var identityResponse = identitySearchResponses.Where(x => x.Responses.Any())
                                                          .SelectMany(x => x.Responses)
                                                          .FirstOrDefault();

            return identityResponse.UniqueId ?? uniqueId;
        }

        [Test]
        public async Task Should_update_specified_instance_db()
        {
            var executableAbsoluteDirectory = Path.GetDirectoryName(typeof(WebApiYearSpecificTestFixture).Assembly.Location);

            // Create and start up the host
            var Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(
                    (hostBuilderContext, configBuilder) =>
                    {
                        string appSettingsPath = Path.Combine(executableAbsoluteDirectory, "appsettings.yearspecific.json");

                        configBuilder.SetBasePath(executableAbsoluteDirectory)
                            .AddJsonFile(appSettingsPath, optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables();
                    })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(TestConstants.YearSpecificBaseUrl);
                    })
                .Build();

            await Host.StartAsync();

            string uniqueId2014;
            string uniqueId2015;

            using (var client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 15, 0);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());

                // create 2014
                var uniqueId2014Response = await client.PostAsync(
                                                      UriHelper.BuildIdentityUri("identities", 2014),
                                                      new StringContent(
                                                          JsonConvert.SerializeObject(
                                                              new IdentityCreateRequest
                                                              {
                                                                  BirthDate = new DateTime(1995, 2, 3),
                                                                  SexType = "Male"
                                                              }),
                                                          Encoding.UTF8,
                                                          "application/json"));

                uniqueId2014 = await ExtractIdFromHttpResponse(uniqueId2014Response);

                var create2014Response = await client.PostAsync(
                                                    UriHelper.BuildOdsUri("students", 2014),
                                                    new StringContent(
                                                        ResourceHelper.CreateStudent(
                                                            uniqueId2014,
                                                            DateTime.Now.Ticks.ToString(
                                                                CultureInfo.InvariantCulture),
                                                            DateTime.Now.Ticks.ToString(
                                                                CultureInfo.InvariantCulture)),
                                                        Encoding.UTF8,
                                                        "application/json"));

                create2014Response.EnsureSuccessStatusCode();

                // create 2015
                var uniqueId2015Response = await client.PostAsync(
                                                      UriHelper.BuildIdentityUri("identities", 2015),
                                                      new StringContent(
                                                          JsonConvert.SerializeObject(
                                                              new IdentityCreateRequest
                                                              {
                                                                  BirthDate = new DateTime(1995, 2, 3),
                                                                  SexType = "Male"
                                                              }),
                                                          Encoding.UTF8,
                                                          "application/json"));

                uniqueId2015 = await ExtractIdFromHttpResponse(uniqueId2015Response);

                var create2015Response = await client.PostAsync(
                                                    UriHelper.BuildOdsUri("students", 2015),
                                                    new StringContent(
                                                        ResourceHelper.CreateStudent(
                                                            uniqueId2015,
                                                            DateTime.Now.Ticks.ToString(
                                                                CultureInfo.InvariantCulture),
                                                            DateTime.Now.Ticks.ToString(
                                                                CultureInfo.InvariantCulture)),
                                                        Encoding.UTF8,
                                                        "application/json"));

                create2015Response.EnsureSuccessStatusCode();
            }

            StudentExists(2014, uniqueId2014)
               .ShouldBeTrue();

            StudentExists(2015, uniqueId2014)
               .ShouldBeFalse();

            StudentExists(2014, uniqueId2015)
               .ShouldBeFalse();

            StudentExists(2015, uniqueId2015)
               .ShouldBeTrue();

            await Host.StopAsync();
            Host.Dispose();
        }
    }
}