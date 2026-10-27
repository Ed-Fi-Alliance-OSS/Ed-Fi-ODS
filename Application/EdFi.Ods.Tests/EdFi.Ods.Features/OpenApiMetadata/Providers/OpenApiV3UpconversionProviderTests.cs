// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Tests.EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Npgsql;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Providers
{
    [TestFixture]
    public class OpenApiV3UpconversionProviderTests
    {
        private const string BaseDescription = "The Ed-Fi ODS / API enables applications to read and write education data.";

        private const string OpenApiV2Json =
            "{\"swagger\":\"2.0\",\"info\":{\"title\":\"Ed-Fi Operational Data Store API\",\"version\":\"3\",\"description\":\"" +
            BaseDescription + "\"},\"paths\":{},\"securityDefinitions\":{\"oauth2_client_credentials\":" +
            "{\"type\":\"oauth2\",\"flow\":\"application\",\"tokenUrl\":\"%TOKEN_URL%\",\"scopes\":{}}}}";

        private static readonly string[] TenantIdentifiers = { "Tenant1", "Tenant2", "Tenant3" };

        private static OpenApiV3UpconversionProvider CreateProvider(
            IEdFiAdminRawOdsInstanceConfigurationDataProvider odsInstanceConfigurationDataProvider,
            bool isMultiTenant = true,
            string odsContextRouteTemplate = null)
        {
            var tenantConfigurationMapProvider = A.Fake<ITenantConfigurationMapProvider>();

            A.CallTo(() => tenantConfigurationMapProvider.GetMap())
                .Returns(
                    TenantIdentifiers.ToDictionary(
                        tenantIdentifier => tenantIdentifier,
                        tenantIdentifier => new TenantConfiguration
                        {
                            TenantIdentifier = tenantIdentifier,
                            AdminConnectionString = GetAdminConnectionString(tenantIdentifier)
                        }));

            var httpContextAccessor = A.Fake<IHttpContextAccessor>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost", 54746);
            A.CallTo(() => httpContextAccessor.HttpContext).Returns(httpContext);

            var featureManager = isMultiTenant
                ? new FakeFeatureManager(false, ApiFeature.MultiTenancy)
                : new FakeFeatureManager(false);

            return new OpenApiV3UpconversionProvider(
                featureManager,
                new ApiSettings { OdsContextRouteTemplate = odsContextRouteTemplate },
                odsInstanceConfigurationDataProvider,
                A.Fake<IAdminDatabaseConnectionStringProvider>(),
                httpContextAccessor,
                tenantConfigurationMapProvider);
        }

        private static IEdFiAdminRawOdsInstanceConfigurationDataProvider CreateOdsInstanceConfigurationDataProvider(
            Exception failure = null,
            params string[] failingTenantIdentifiers)
        {
            var odsInstanceConfigurationDataProvider = A.Fake<IEdFiAdminRawOdsInstanceConfigurationDataProvider>();

            A.CallTo(() => odsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(A<string>._, A<string>._))
                .Returns(Task.FromResult(Array.Empty<string>()));

            foreach (var failingTenantIdentifier in failingTenantIdentifiers)
            {
                A.CallTo(
                        () => odsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(
                            A<string>._, GetAdminConnectionString(failingTenantIdentifier)))
                    .ThrowsAsync(failure);
            }

            return odsInstanceConfigurationDataProvider;
        }

        private static string GetAdminConnectionString(string tenantIdentifier)
            => $"server=(local);database=EdFi_Admin_{tenantIdentifier}";

        private static OpenApiDocument ReadDocument(string openApiJson) => new OpenApiStringReader().Read(openApiJson, out _);

        private static IEnumerable<string> GetServerTenants(OpenApiDocument document)
            => document.Servers.Single().Variables.Values.Single().Enum;

        public class When_one_tenant_admin_database_does_not_exist_on_SQL_Server : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private string _actualJson;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(
                        SqlExceptionCreator.Create(4060, "Cannot open database \"EdFi_Admin_Tenant2\" requested by the login."),
                        "Tenant2"));
            }

            protected override void Act()
            {
                _actualJson = _provider.GetUpconvertedOpenApiJson(OpenApiV2Json);
                _actualDocument = ReadDocument(_actualJson);
            }

            [Test]
            public void Should_not_throw()
            {
                ActualException.ShouldBeNull();
            }

            [Test]
            public void Should_omit_the_tenant_from_the_server_list()
            {
                GetServerTenants(_actualDocument).ShouldBe(new[] { "Tenant1", "Tenant3" });
            }

            [Test]
            public void Should_omit_the_tenant_from_the_security_schemes()
            {
                _actualDocument.Components.SecuritySchemes.Keys.ShouldBe(
                    new[] { "Tenant1_oauth2_client_credentials", "Tenant3_oauth2_client_credentials" });
            }

            [Test]
            public void Should_name_the_omitted_tenant_in_the_document_description()
            {
                _actualDocument.Info.Description.ShouldStartWith(BaseDescription);
                _actualDocument.Info.Description.ShouldContain("**Unavailable tenants:** Tenant2.");
                _actualDocument.Info.Description.ShouldContain("not listed under Tenant Selection or in the Authorize dialog");
            }

            [Test]
            public void Should_not_say_that_no_tenants_are_available()
            {
                _actualDocument.Info.Description.ShouldNotContain("No tenants are available");
            }

            [Test]
            public void Should_not_expose_the_admin_database_name_in_the_document()
            {
                _actualJson.ShouldNotContain("EdFi_Admin_Tenant2");
            }
        }

        public class When_one_tenant_admin_database_is_offline_on_SQL_Server : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(
                        SqlExceptionCreator.Create(942, "Database 'EdFi_Admin_Tenant2' cannot be opened because it is offline."),
                        "Tenant2"));
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_not_throw()
            {
                ActualException.ShouldBeNull();
            }

            [Test]
            public void Should_omit_the_tenant_from_the_server_list()
            {
                GetServerTenants(_actualDocument).ShouldBe(new[] { "Tenant1", "Tenant3" });
            }

            [Test]
            public void Should_name_the_omitted_tenant_in_the_document_description()
            {
                _actualDocument.Info.Description.ShouldContain("**Unavailable tenants:** Tenant2.");
            }
        }

        public class When_one_tenant_admin_database_does_not_exist_on_PostgreSQL : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(
                        new PostgresException(
                            "database \"edfi_admin_tenant2\" does not exist", "FATAL", "FATAL",
                            PostgresErrorCodes.InvalidCatalogName),
                        "Tenant2"));
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_not_throw()
            {
                ActualException.ShouldBeNull();
            }

            [Test]
            public void Should_omit_the_tenant_from_the_server_list()
            {
                GetServerTenants(_actualDocument).ShouldBe(new[] { "Tenant1", "Tenant3" });
            }

            [Test]
            public void Should_name_the_omitted_tenant_in_the_document_description()
            {
                _actualDocument.Info.Description.ShouldContain("**Unavailable tenants:** Tenant2.");
            }
        }

        public class When_one_tenant_admin_database_does_not_accept_connections_on_PostgreSQL : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(
                        new PostgresException(
                            "database \"edfi_admin_tenant2\" is not currently accepting connections", "FATAL", "FATAL",
                            PostgresErrorCodes.ObjectNotInPrerequisiteState),
                        "Tenant2"));
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_omit_the_tenant_from_the_server_list()
            {
                GetServerTenants(_actualDocument).ShouldBe(new[] { "Tenant1", "Tenant3" });
            }

            [Test]
            public void Should_name_the_omitted_tenant_in_the_document_description()
            {
                _actualDocument.Info.Description.ShouldContain("**Unavailable tenants:** Tenant2.");
            }
        }

        public class When_one_tenant_PostgreSQL_server_cannot_be_reached : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(
                        new NpgsqlException("Failed to connect to 127.0.0.1:5432"),
                        "Tenant2"));
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_omit_the_tenant_from_the_server_list()
            {
                GetServerTenants(_actualDocument).ShouldBe(new[] { "Tenant1", "Tenant3" });
            }

            [Test]
            public void Should_name_the_omitted_tenant_in_the_document_description()
            {
                _actualDocument.Info.Description.ShouldContain("**Unavailable tenants:** Tenant2.");
            }
        }

        public class When_every_tenant_admin_database_is_unavailable : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(
                        SqlExceptionCreator.Create(942, "Database cannot be opened because it is offline."),
                        TenantIdentifiers));
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_not_throw()
            {
                ActualException.ShouldBeNull();
            }

            [Test]
            public void Should_list_no_tenants_and_no_security_schemes()
            {
                // An empty enum is left out when the document is written
                (GetServerTenants(_actualDocument) ?? Enumerable.Empty<string>()).ShouldBeEmpty();
                _actualDocument.Components.SecuritySchemes.ShouldBeEmpty();
            }

            [Test]
            public void Should_say_that_no_tenants_are_available()
            {
                _actualDocument.Info.Description.ShouldContain("**No tenants are available:** Tenant1, Tenant2, Tenant3.");
                _actualDocument.Info.Description.ShouldContain("Requests sent from this page will fail until they are restored.");
            }

            [Test]
            public void Should_not_mention_the_Authorize_dialog_that_is_not_shown()
            {
                _actualDocument.Info.Description.ShouldNotContain("Authorize dialog");
            }
        }

        public class When_two_of_three_tenant_admin_databases_are_unavailable : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(
                        SqlExceptionCreator.Create(942, "Database cannot be opened because it is offline."),
                        "Tenant1", "Tenant3"));
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_list_only_the_available_tenant()
            {
                GetServerTenants(_actualDocument).ShouldBe(new[] { "Tenant2" });
            }

            [Test]
            public void Should_name_the_unavailable_tenants_without_saying_that_none_are_available()
            {
                _actualDocument.Info.Description.ShouldContain("**Unavailable tenants:** Tenant1, Tenant3.");
                _actualDocument.Info.Description.ShouldNotContain("No tenants are available");
            }
        }

        public class When_every_tenant_admin_database_is_available : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(CreateOdsInstanceConfigurationDataProvider());
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_list_every_tenant()
            {
                GetServerTenants(_actualDocument).ShouldBe(TenantIdentifiers);
                _actualDocument.Components.SecuritySchemes.Count.ShouldBe(TenantIdentifiers.Length);
            }

            [Test]
            public void Should_keep_the_document_description_unchanged()
            {
                _actualDocument.Info.Description.ShouldBe(BaseDescription);
            }
        }

        public class When_routing_by_ods_context_and_a_tenant_admin_database_fails_after_its_first_lookup : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                var odsInstanceConfigurationDataProvider = A.Fake<IEdFiAdminRawOdsInstanceConfigurationDataProvider>();

                A.CallTo(() => odsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(A<string>._, A<string>._))
                    .Returns(Task.FromResult(new[] { "2026" }));

                // The first lookup builds the server paths; the second one, for the security scheme, fails
                A.CallTo(
                        () => odsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(
                            A<string>._, GetAdminConnectionString("Tenant2")))
                    .Returns(Task.FromResult(new[] { "2026" })).Once()
                    .Then.ThrowsAsync(SqlExceptionCreator.Create(942, "Database cannot be opened because it is offline."));

                _provider = CreateProvider(
                    odsInstanceConfigurationDataProvider, odsContextRouteTemplate: "{schoolYearFromRoute:range(2026,2027)}");
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_not_throw()
            {
                ActualException.ShouldBeNull();
            }

            [Test]
            public void Should_leave_nothing_of_the_tenant_in_the_server_list()
            {
                GetServerTenants(_actualDocument).ShouldBe(new[] { "Tenant1/2026", "Tenant3/2026" });
            }

            [Test]
            public void Should_leave_nothing_of_the_tenant_in_the_security_schemes()
            {
                _actualDocument.Components.SecuritySchemes.Keys.ShouldBe(
                    new[] { "Tenant1_oauth2_client_credentials", "Tenant3_oauth2_client_credentials" });

                _actualDocument.Components.SecuritySchemes["Tenant1_oauth2_client_credentials"]
                    .Flows.ClientCredentials.TokenUrl.ToString()
                    .ShouldEndWith("/Tenant1/2026/oauth/token");
            }

            [Test]
            public void Should_use_the_tenant_and_context_selection_title_in_the_notice()
            {
                _actualDocument.Info.Description.ShouldContain("not listed under Tenant/Context Selection");
            }
        }

        public class When_multitenancy_is_disabled : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;
            private OpenApiDocument _actualDocument;

            protected override void Arrange()
            {
                _provider = CreateProvider(CreateOdsInstanceConfigurationDataProvider(), isMultiTenant: false);
            }

            protected override void Act()
            {
                _actualDocument = ReadDocument(_provider.GetUpconvertedOpenApiJson(OpenApiV2Json));
            }

            [Test]
            public void Should_add_a_single_security_scheme_without_a_tenant()
            {
                _actualDocument.Components.SecuritySchemes.Keys.ShouldBe(new[] { "oauth2_client_credentials" });
            }

            [Test]
            public void Should_keep_the_document_description_unchanged()
            {
                _actualDocument.Info.Description.ShouldBe(BaseDescription);
            }
        }

        public class When_a_tenant_lookup_fails_with_an_error_that_does_not_come_from_the_database : TestFixtureBase
        {
            private OpenApiV3UpconversionProvider _provider;

            protected override void Arrange()
            {
                _provider = CreateProvider(
                    CreateOdsInstanceConfigurationDataProvider(new InvalidOperationException("Unexpected failure."), "Tenant2"));
            }

            protected override void Act()
            {
                _provider.GetUpconvertedOpenApiJson(OpenApiV2Json);
            }

            [Test]
            public void Should_not_hide_the_failure()
            {
                var failure = ActualException is AggregateException aggregateException
                    ? aggregateException.Flatten().InnerExceptions.Single()
                    : ActualException;

                failure.ShouldBeOfType<InvalidOperationException>().Message.ShouldBe("Unexpected failure.");
            }
        }
    }
}
