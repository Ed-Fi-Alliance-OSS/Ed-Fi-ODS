// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api;
using EdFi.Ods.Api.Common;
using EdFi.Ods.Api.Services.Controllers;
using EdFi.Ods.Api.Services.Controllers.AcademicSubjectDescriptors.EdFi;
using EdFi.Ods.Api.Services.Controllers.GraduationPlans.EdFi;
using EdFi.Ods.Api.Services.Controllers.IdentityManagement;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Ods.Composites.Test;
using EdFi.Ods.Features.OpenApiMetadata.Controllers;
using EdFi.Ods.WebService.Tests.Owin;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebService.Tests
{
    [TestFixture]
    public class UrlRoutingTests
    {
        private static Tuple<string, string, Type, string>[] GetYearSpecificRouteMappingTestData(
            bool useSchoolYear)
        {
            var schoolYear = useSchoolYear
                ? "/2008/"
                : "/";

            return new[]
                   {
                       // Define Urls to be tested here, along with the expected controller and action they should invoke
                       // Profiles are excluded as the validator is not using the correct selector
                       // Swagger resources list
                       Tuple.Create("GET", $"http://localhost/metadata/identity/v2{schoolYear}swagger.json", typeof(OpenApiMetadataController), "Get")

                       // Swagger resource
                      ,
                       Tuple.Create("GET", $"http://localhost/metadata{schoolYear}", typeof(OpenApiMetadataController), "GetSections")

                       // Descriptors
                      ,
                       Tuple.Create(
                           "GET",
                           $"http://localhost/data/v3{schoolYear}ed-fi/academicSubjectDescriptors",
                           typeof(AcademicSubjectDescriptorsController),
                           "GetAll"),
                       Tuple.Create(
                           "GET",
                           $"http://localhost/data/v3{schoolYear}ed-fi/academicSubjectDescriptors/4FE78881-D3FB-4639-80E4-AC7BFC3C6317",
                           typeof(AcademicSubjectDescriptorsController),
                           "Get")

                       // Resources
                      ,
                       Tuple.Create("GET", $"http://localhost/data/v3{schoolYear}ed-fi/graduationPlans", typeof(GraduationPlansController), "GetAll"),
                       Tuple.Create(
                           "GET",
                           $"http://localhost/data/v3{schoolYear}ed-fi/graduationPlans/4FE78881-D3FB-4639-80E4-AC7BFC3C6317",
                           typeof(GraduationPlansController),
                           "Get")

                       // Composites
                      ,
                       Tuple.Create(
                           "GET",
                           $"http://localhost/composites/v1{schoolYear}ed-fi/test/StaffFilters",
                           typeof(CompositeResourceController),
                           "Get"),
                       Tuple.Create(
                           "GET",
                           $"http://localhost/composites/v1{schoolYear}ed-fi/test/StaffFilters/67b2bfa3-0dca-48a6-99fb-7531d45a3d88",
                           typeof(CompositeResourceController),
                           "Get")
                   };
        }

        private static Tuple<string, string, Type, string>[] GetYearAgnosticRouteMappingTestData(bool useSchoolYear)
        {
            var schoolYear = useSchoolYear
                ? "/2008/"
                : "/";

            return new[]
                   {
                       // Define Urls to be tested here, along with the expected controller and action they should invoke
                       // Other Section
                       Tuple.Create("GET", $"http://localhost/{schoolYear}", typeof(VersionController), "Get"),
                       Tuple.Create("GET", $"http://localhost/identity/v2/identities{schoolYear}xyz", typeof(IdentitiesController), "GetById")
                   };
        }

#pragma warning disable 618
        // TODO: Remove with ODS-2973, deprecated by ODS-2974
        private class TestStartup : WebServiceTestsStartupBase
#pragma warning restore 618
        {
            public void ExternalizeInitializeContainer()
            {
                Container.Register(
                    Component.For<ICompositesMetadataProvider>()
                             .ImplementedBy<CompositesMetadataProvider>());

                Container.Register(
                    Component.For<IDomainModelProvider>()
                             .Instance(DomainModelDefinitionsProviderHelper.DomainModelProvider));
            }

            protected override void InstallConfigurationSpecificInstaller(IWindsorContainer container)
            {
                throw new NotImplementedException();
            }

            public void ExternalizeConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
            {
                EnsureAssembliesLoaded();
                ConfigureRoutes(config, useSchoolYear);
            }

            protected override void EnsureAssembliesLoaded()
            {
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Api>();
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Api_Common>();
            }

            protected override void InstallOpenApiMetadata(IWindsorContainer container)
            {
                // No OpenApiMetadata installation required.
            }
        }

        public class When_the_API_is_configured_with_school_year_in_the_routes_and_school_years_are_provided_in_the_requests : LegacyTestFixtureBase
        {
            private HttpConfiguration _config;
            private RouteTester _routeTester;
            private Action<string> _resultValidator;

            protected override void Arrange()
            {
                var startup = new TestStartup();

                _config = new HttpConfiguration
                          {
                              IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
                          };

                startup.ExternalizeInitializeContainer();
                startup.ExternalizeConfigureRoutes(_config, useSchoolYear: true);
                _config.EnsureInitialized();
                _routeTester = new RouteTester(_config);

                _resultValidator = x =>
                                   {
                                       if (!string.IsNullOrEmpty(x))
                                       {
                                           Assert.Fail(x);
                                       }
                                   };
            }

            [Assert]
            public void Should_Resolve_To_Appropriate_Controller_Action_For_Urls_containing_school_year()
            {
                GetYearSpecificRouteMappingTestData(useSchoolYear: true)
                   .Select(
                        x => _routeTester.ValidateRoutingForUrl(x.Item1, x.Item2, x.Item3, x.Item4))
                   .ForEach(_resultValidator);
            }
        }

        public class When_the_API_is_configured_with_school_year_in_the_routes_and_school_years_are_not_provided_in_the_requests : LegacyTestFixtureBase
        {
            private HttpConfiguration _config;
            private RouteTester _routeTester;
            private Action<string> _resultValidator;

            protected override void Arrange()
            {
                var startup = new TestStartup();

                _config = new HttpConfiguration
                          {
                              IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
                          };

                startup.ExternalizeInitializeContainer();
                startup.ExternalizeConfigureRoutes(_config, useSchoolYear: true);
                _config.EnsureInitialized();
                _routeTester = new RouteTester(_config);

                _resultValidator = x =>
                                   {
                                       if (string.IsNullOrEmpty(x))
                                       {
                                           Assert.Fail("Invalid Url matched a controller: " + x);
                                       }
                                   };
            }

            [Assert]
            public void Should_Not_Resolve_To_Appropriate_Controller_Action_For_Urls_not_containing_school_year()
            {
                GetYearSpecificRouteMappingTestData(useSchoolYear: false)
                   .Select(
                        x => _routeTester.ValidateRoutingForUrl(x.Item1, x.Item2, x.Item3, x.Item4))
                   .ForEach(_resultValidator);
            }
        }

        public class When_the_API_is_configured_without_school_year_in_the_routes_and_school_years_are_provided_in_the_requests : LegacyTestFixtureBase
        {
            private HttpConfiguration _config;
            private RouteTester _routeTester;
            private Action<string> _resultValidator;

            protected override void Arrange()
            {
                var startup = new TestStartup();

                _config = new HttpConfiguration
                          {
                              IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
                          };

                startup.ExternalizeInitializeContainer();
                startup.ExternalizeConfigureRoutes(_config, useSchoolYear: false);
                _config.EnsureInitialized();
                _routeTester = new RouteTester(_config);

                _resultValidator = x =>
                                   {
                                       if (string.IsNullOrEmpty(x))
                                       {
                                           Assert.Fail("Invalid Url matched a controller: " + x);
                                       }
                                   };
            }

            [Assert]
            public void Should_Not_Resolve_To_Appropriate_Controller_Action_For_Urls_containing_school_year()
            {
                GetYearSpecificRouteMappingTestData(useSchoolYear: true)
                   .Select(
                        x => _routeTester.ValidateRoutingForUrl(x.Item1, x.Item2, x.Item3, x.Item4))
                   .ForEach(_resultValidator);
            }
        }

        public class When_the_API_is_configured_without_school_year_in_the_routes_and_school_years_are_not_provided_in_the_requests : LegacyTestFixtureBase
        {
            private HttpConfiguration _config;
            private RouteTester _routeTester;
            private Action<string> _resultValidator;

            protected override void Arrange()
            {
                var startup = new TestStartup();

                _config = new HttpConfiguration
                          {
                              IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
                          };

                startup.ExternalizeInitializeContainer();
                startup.ExternalizeConfigureRoutes(_config, useSchoolYear: false);
                _config.EnsureInitialized();
                _routeTester = new RouteTester(_config);

                _resultValidator = x =>
                                   {
                                       if (!string.IsNullOrEmpty(x))
                                       {
                                           Assert.Fail(x);
                                       }
                                   };
            }

            [Assert]
            public void Should_Resolve_To_Appropriate_Controller_Action_For_Urls_not_containing_school_year()
            {
                GetYearSpecificRouteMappingTestData(useSchoolYear: false)
                   .Select(
                        x => _routeTester.ValidateRoutingForUrl(x.Item1, x.Item2, x.Item3, x.Item4))
                   .ForEach(_resultValidator);
            }
        }

        public class When_the_API_is_configured_without_school_year_in_the_routes_and_valid_school_year_agnostic_routes_are_requested
            : LegacyTestFixtureBase
        {
            private HttpConfiguration _config;
            private RouteTester _routeTester;
            private Action<string> _resultValidator;

            protected override void Arrange()
            {
                var startup = new TestStartup();

                _config = new HttpConfiguration
                          {
                              IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
                          };

                startup.ExternalizeInitializeContainer();
                startup.ExternalizeConfigureRoutes(_config, useSchoolYear: false);
                _config.EnsureInitialized();
                _routeTester = new RouteTester(_config);

                _resultValidator = x =>
                                   {
                                       if (!string.IsNullOrEmpty(x))
                                       {
                                           Assert.Fail(x);
                                       }
                                   };
            }

            [Assert]
            public void Should_Resolve_To_Appropriate_Controller_Action_For_Urls()
            {
                GetYearAgnosticRouteMappingTestData(false)
                   .Select(
                        x => _routeTester.ValidateRoutingForUrl(x.Item1, x.Item2, x.Item3, x.Item4))
                   .ForEach(_resultValidator);
            }
        }

        public class When_the_API_is_configured_with_school_year_in_the_routes_and_school_year_agnostic_routes_are_requested_with_school_year
            : LegacyTestFixtureBase
        {
            private HttpConfiguration _config;
            private RouteTester _routeTester;
            private Action<string> _resultValidator;

            protected override void Arrange()
            {
                var startup = new TestStartup();

                _config = new HttpConfiguration
                          {
                              IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
                          };

                startup.ExternalizeInitializeContainer();
                startup.ExternalizeConfigureRoutes(_config, useSchoolYear: true);
                _config.EnsureInitialized();
                _routeTester = new RouteTester(_config);

                _resultValidator = x =>
                                   {
                                       if (string.IsNullOrEmpty(x))
                                       {
                                           Assert.Fail("Invalid Url matched a controller: " + x);
                                       }
                                   };
            }

            [Assert]
            public void Should_Resolve_To_Appropriate_Controller_Action_For_Urls()
            {
                GetYearAgnosticRouteMappingTestData(true)
                   .Select(
                        x => _routeTester.ValidateRoutingForUrl(x.Item1, x.Item2, x.Item3, x.Item4))
                   .ForEach(_resultValidator);
            }
        }
    }
}
