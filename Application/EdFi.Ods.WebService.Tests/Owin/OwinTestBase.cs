// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Features.AggregateDepenedencies;
using EdFi.Ods.Features.OpenApiMetadata.Controllers;
using EdFi.Ods.Features.UniqueIdIntegration.IdentityValueMappers;
using EdFi.Ods.Features.UniqueIdIntegration.Installers;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Security.Profiles;
using EdFi.Ods.Standard.Container.Installers;
using Microsoft.Owin.Testing;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.WebService.Tests.Owin
{
    public abstract class OwinTestBase
    {
        public const string EdFiNamespacePrefix = "uri://ed-fi.org";
        protected const string OdsBaseAddress = "http://owin/data/v3/ed-fi";
        public static readonly List<string> DefaultTestNamespacePrefixes = new List<string>
                                                                           {
                                                                               EdFiNamespacePrefix
                                                                           };

        protected static readonly TimeSpan DefaultHttpClientTimeout = new TimeSpan(0, 0, 15, 0);

        private readonly Guid _databaseId = Guid.NewGuid();

        private DatabaseHelper _databaseHelper;
        private TransactionScope _transactionScope;
        protected string BaseAddress;

        protected virtual string BaseDatabase
        {
            get { return GlobalDatabaseSetupFixture.PopulatedTemplateDatabaseName; }
        }

        protected virtual string DatabaseName
        {
            get
            {
                return CreateDatabase
                    ? "EdFi_Tests_" + GetType()
                         .Name + _databaseId.ToString("N")
                    : GlobalDatabaseSetupFixture.PopulatedDatabaseName;
            }
        }

        protected virtual List<int> DefaultLocalEducationAgencyIds
        {
            get
            {
                return new List<int>
                       {
                           255901
                       };
            }
        }

        protected virtual string TestNamespace
        {
            get { return "uri://www.TEST.org/"; }
        }

        protected virtual string FailNamespace
        {
            get { return "uri://www.FAIL.org/"; }
        }

        protected virtual bool CreateDatabase
        {
            get { return false; }
        }

        [OneTimeSetUp]
        public virtual void SetUp()
        {
            if (string.IsNullOrWhiteSpace(BaseAddress))
            {
                BaseAddress = OdsBaseAddress;
            }

            if (CreateDatabase)
            {
                _databaseHelper = new DatabaseHelper();
                _databaseHelper.CopyDatabase(BaseDatabase, DatabaseName);
            }
            else
            {
                _transactionScope = new TransactionScope();
            }
        }

        protected virtual void Execute(Action<HttpClient> action)
        {
            Execute(DefaultLocalEducationAgencyIds, action);
        }

        protected virtual void Execute(string customNamespace, Action<HttpClient> action)
        {
            Execute(DefaultLocalEducationAgencyIds, customNamespace, action);
        }

        protected virtual void Execute(List<int> localEducationAgencyIds, Action<HttpClient> action)
        {
            Execute(localEducationAgencyIds, TestNamespace, action);
        }

        protected virtual void Execute(List<int> localEducationAgencyIds, string customNamespace, Action<HttpClient> action)
        {
            using (var startup = new OwinStartup(
                DatabaseName,
                localEducationAgencyIds,
                new List<string>
                {
                    customNamespace
                }))
            {
                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.BaseAddress = new Uri(OdsBaseAddress);
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        action(client);
                    }
                }
            }
        }

        protected virtual void Execute(Func<ISecurityRepository> securityRepository, Action<HttpClient> action)
        {
            if (action == null)
            {
                return;
            }

            using (var startup = new OwinStartup(
                DatabaseName,
                DefaultLocalEducationAgencyIds,
                new List<string>
                {
                    TestNamespace
                },
                null,
                securityRepository))
            {
                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.BaseAddress = new Uri(OdsBaseAddress);
                        client.Timeout = DefaultHttpClientTimeout;

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            Guid.NewGuid()
                                .ToString());

                        action(client);
                    }
                }
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (CreateDatabase)
            {
                _databaseHelper.DropDatabase(DatabaseName);
            }
            else
            {
                _transactionScope.Dispose();
            }
        }

        internal class OwinStartup : OwinTestStartupBase
        {
            private readonly Func<IAdminProfileNamesPublisher> _adminProfileNamesPublisher;
            private readonly Func<IOAuthTokenValidator> _createOAuthTokenValidator;
            private readonly List<int> _educationOrganizationIds;
            private readonly Func<ISecurityRepository> _securityRepository;
            private readonly bool _useSchoolYear;
            private readonly bool _useUniqueIdIntegration;
            private readonly List<string> _vendorNamespacePrefixes;

            internal OwinStartup(
                string databaseName,
                List<int> educationOrganizationIds,
                List<string> vendorNamespacePrefixes = null,
                Func<IOAuthTokenValidator> createOAuthTokenValidator = null,
                Func<ISecurityRepository> securityRepository = null,
                bool useUniqueIdIntegration = false,
                Func<IAdminProfileNamesPublisher> adminProfileNamesPublisher = null,
                bool useSchoolYear = false)
            {
                Trace.Listeners.Clear();
                BaseDatabase = databaseName;
                _educationOrganizationIds = educationOrganizationIds;
                _vendorNamespacePrefixes = vendorNamespacePrefixes ?? DefaultTestNamespacePrefixes;
                _useUniqueIdIntegration = useUniqueIdIntegration;
                _useSchoolYear = useSchoolYear;
                _adminProfileNamesPublisher = adminProfileNamesPublisher ?? CreateAdminProfileNamesPublisher;
                _createOAuthTokenValidator = createOAuthTokenValidator ?? CreateOAuthTokenValidator;
                _securityRepository = securityRepository ?? (() => new OwinSecurityRepository());
            }

            protected override void ConfigureRoutes(HttpConfiguration config)
            {
                base.ConfigureRoutes(config, _useSchoolYear);
            }

            protected override void InstallTestSpecificInstaller(IWindsorContainer container)
            {
                EnsureAssembliesLoaded();

                container.Register(
                    Component.For<IAdminProfileNamesPublisher>()
                             .Instance(_adminProfileNamesPublisher())
                             .IsDefault());

                container.Register(
                    Component.For<IOAuthTokenValidator>()
                             .Instance(_createOAuthTokenValidator())
                             .IsDefault());

                container.Register(
                    Component.For<ISecurityRepository>()
                             .Instance(_securityRepository())
                             .IsDefault());

                container.Register(
                    Component
                        .For<IAuthorizationViewsProvider>()
                        .ImplementedBy<AuthorizationViewsProvider>());

                // Conditionally, add support for UniqueId integration
                if (_useUniqueIdIntegration)
                {
                    container.Install(new UniqueIdIntegrationInstaller());

                    container.Register(
                        Component.For<IUniqueIdToIdValueMapper>().ImplementedBy<ParsedGuidUniqueIdToIdValueMapper>());
                }

                container.Install(new EdFiOdsStandardInstaller());

                container.Register(Component.For<AggregateDependencyController>().LifestyleScoped());
            }

            protected virtual IAdminProfileNamesPublisher CreateAdminProfileNamesPublisher()
            {
                var adminProfileNamesPublisher = MockRepository.GenerateStub<IAdminProfileNamesPublisher>();
                return adminProfileNamesPublisher;
            }

            protected virtual IOAuthTokenValidator CreateOAuthTokenValidator()
            {
                var oAuthTokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                oAuthTokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                                   .Return(
                                        Task.FromResult(
                                            new ApiClientDetails
                                            {
                                                ApiKey = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture),
                                                ApplicationId = DateTime.Now.Millisecond, ClaimSetName = "SIS Vendor",
                                                NamespacePrefixes = _vendorNamespacePrefixes, EducationOrganizationIds = _educationOrganizationIds
                                            }));

                return oAuthTokenValidator;
            }
        }
    }
}
