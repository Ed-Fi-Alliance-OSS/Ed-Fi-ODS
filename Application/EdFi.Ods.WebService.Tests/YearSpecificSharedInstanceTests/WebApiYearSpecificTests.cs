// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Common.Extensions;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Standard.Container.Installers;
using EdFi.Ods.WebService.Tests.Owin;
using EdFi.Ods.WebService.Tests._Helpers;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.WebService.Tests.YearSpecificSharedInstanceTests
{
    [TestFixture]
    public class When_putting_a_resource_to_a_shared_year_specific_instance
    {
        private delegate string ResolveDatabaseDelegate();

        private delegate string ResolveConnectionStringDelegate();

        private static ISchoolYearContextProvider _schoolYearContextProvider;

        private static string ResolveConnectionString()
        {
            var nameDatabaseConnectionStringProvider = new NamedDatabaseConnectionStringProvider("EdFi_Ods");
            var connectionString = nameDatabaseConnectionStringProvider.GetConnectionString();
            var builder = new SqlConnectionStringBuilder(connectionString) { InitialCatalog = ResolveDatabase() };

            return builder.ConnectionString;
        }

        private static string ResolveDatabase()
        {
            int schoolYear = _schoolYearContextProvider.GetSchoolYear();

            if (schoolYear == 2014)
            {
                return DatabaseName_2014;
            }

            if (schoolYear == 2015)
            {
                return DatabaseName_2015;
            }

            return string.Empty;
        }

        private const string DatabaseName_2014 =
            "EdFi_Tests_When_putting_a_resource_to_a_shared_year_specific_instance_2014";

        private const string DatabaseName_2015 =
            "EdFi_Tests_When_putting_a_resource_to_a_shared_year_specific_instance_2015";

        private class OwinStartup : OwinTestStartupBase
        {
            protected override void ConfigureRoutes(HttpConfiguration config)
            {
                base.ConfigureRoutes(config, useSchoolYear: true);
            }

            protected override void RegisterOdsDatabase(IWindsorContainer container)
            {
                container.Register(
                    Component.For<IDatabaseConnectionStringProvider>()
                        .Named("IDatabaseConnectionStringProvider.Ods")
                        .Instance(CreateDatabaseConnectionStringProvider()));
            }

            private static IDatabaseConnectionStringProvider CreateDatabaseConnectionStringProvider()
            {
                var databaseConnectionStringProvider = MockRepository.GenerateStub<IDatabaseConnectionStringProvider>();

                databaseConnectionStringProvider.Stub(d => d.GetConnectionString())
                    .Do(new ResolveConnectionStringDelegate(ResolveConnectionString));

                return databaseConnectionStringProvider;
            }

            protected override void InstallTestSpecificInstaller(IWindsorContainer container)
            {
                _schoolYearContextProvider = container.Resolve<ISchoolYearContextProvider>();

                container.Register(
                    Component.For<ISecurityRepository>()
                             .Instance(new OwinSecurityRepository())
                             .IsDefault());

                var oAuthTokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                oAuthTokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                                   .Return(
                                        Task.FromResult(
                                            new ApiClientDetails
                                            {
                                                ApiKey = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture),
                                                ApplicationId = DateTime.Now.Millisecond, ClaimSetName = "SIS Vendor", NamespacePrefixes =
                                                    new List<string>
                                                    {
                                                        "uri://ed-fi.org"
                                                    },
                                                EducationOrganizationIds = new List<int>
                                                                           {
                                                                               255901
                                                                           }
                                            }));

                container.Register(
                    Component.For<IOAuthTokenValidator>()
                             .Instance(oAuthTokenValidator)
                             .IsDefault());

                container.Install(new EdFiOdsStandardInstaller());
            }
        }

        private DatabaseHelper _databaseHelper;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _databaseHelper = new DatabaseHelper();
            _databaseHelper.CopyDatabase(GlobalDatabaseSetupFixture.PopulatedTemplateDatabaseName, DatabaseName_2014);
            _databaseHelper.CopyDatabase(GlobalDatabaseSetupFixture.PopulatedTemplateDatabaseName, DatabaseName_2015);
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
                ConfigurationManager.ConnectionStrings["EdFi_Ods"]
                                    .ConnectionString);

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

        [Test]
        public void Should_update_specified_instance_db()
        {
            Trace.Listeners.Clear();

            // with the change in school year we need to send each year as a separate request so the context will change correctly.
            // should the context provider be set when the request comes into the controller? Currently it appears it is not being set.
            using (var server = TestServer.Create<OwinStartup>())
            {
                string uniqueId2014;
                string uniqueId2015;

                using (var client = new HttpClient(server.Handler))
                {
                    client.Timeout = new TimeSpan(0, 0, 15, 0);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        Guid.NewGuid()
                            .ToString());

                    // create 2014
                    var uniqueId2014Response = client.PostAsync(
                                                          OwinUriHelper.BuildIdentityUri("identities", 2014),
                                                          new StringContent(
                                                              JsonConvert.SerializeObject(
                                                                  UniqueIdCreator
                                                                     .InitializeAPersonWithUniqueData()),
                                                              Encoding.UTF8,
                                                              "application/json"))
                                                     .GetResultSafely();

                    uniqueId2014 = UniqueIdCreator.ExtractIdFromHttpResponse(uniqueId2014Response);

                    var create2014Response = client.PostAsync(
                                                        OwinUriHelper.BuildOdsUri("students", 2014),
                                                        new StringContent(
                                                            ResourceHelper.CreateStudent(
                                                                uniqueId2014,
                                                                DateTime.Now.Ticks.ToString(
                                                                    CultureInfo.InvariantCulture),
                                                                DateTime.Now.Ticks.ToString(
                                                                    CultureInfo.InvariantCulture)),
                                                            Encoding.UTF8,
                                                            "application/json"))
                                                   .GetResultSafely();

                    create2014Response.EnsureSuccessStatusCode();

                    // create 2015
                    var uniqueId2015Response = client.PostAsync(
                                                          OwinUriHelper.BuildIdentityUri("identities", 2015),
                                                          new StringContent(
                                                              JsonConvert.SerializeObject(
                                                                  UniqueIdCreator
                                                                     .InitializeAPersonWithUniqueData()),
                                                              Encoding.UTF8,
                                                              "application/json"))
                                                     .GetResultSafely();

                    uniqueId2015 = UniqueIdCreator.ExtractIdFromHttpResponse(uniqueId2015Response);

                    var create2015Response = client.PostAsync(
                                                        OwinUriHelper.BuildOdsUri("students", 2015),
                                                        new StringContent(
                                                            ResourceHelper.CreateStudent(
                                                                uniqueId2015,
                                                                DateTime.Now.Ticks.ToString(
                                                                    CultureInfo.InvariantCulture),
                                                                DateTime.Now.Ticks.ToString(
                                                                    CultureInfo.InvariantCulture)),
                                                            Encoding.UTF8,
                                                            "application/json"))
                                                   .GetResultSafely();

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
            }
        }
    }
}
