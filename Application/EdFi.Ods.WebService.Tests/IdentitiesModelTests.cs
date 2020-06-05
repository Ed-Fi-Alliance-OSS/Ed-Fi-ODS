// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models.Identity;
using EdFi.Ods.Api.HttpRouteConfigurations;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Services.Controllers.IdentityManagement;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Claims;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Standard;
using EdFi.Ods.WebService.Tests._Installers;
using EdFi.TestObjects;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Owin;
using Rhino.Mocks;
using Test.Common._Stubs;

namespace EdFi.Ods.WebService.Tests
{
    public class IdentityServiceTestStartup : WebApiInstaller
    {
        public const string EdFiNamespacePrefix = "uri://ed-fi.org";
        public static readonly List<string> DefaultTestNamespacePrefixes = new List<string>
                                                                           {
                                                                               EdFiNamespacePrefix
                                                                           };
        private readonly IWindsorContainer _container = new WindsorContainer();
        private readonly bool _isAsync;

        public IdentityServiceTestStartup(bool isAsync)
        {
            _isAsync = isAsync;
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            RegisterComponents(_container);

            var httpConfig = new HttpConfiguration
                             {
                                 DependencyResolver = _container.Resolve<IDependencyResolver>()
                             };

            ConfigureRoutes(httpConfig, false);

            appBuilder.UseWebApi(httpConfig);
        }

        private void RegisterComponents(IWindsorContainer container)
        {
            if (_isAsync)
            {
                container.Register(
                    Component.For<IDependencyResolver>()
                             .Instance(new WindsorDependencyResolver(container)),
                    Component.For<IIdentityService, IIdentityServiceAsync>()
                             .ImplementedBy<TestIdentitiesService>(),
                    Classes.From(typeof(IdentitiesController))
                           .BasedOn<ApiController>()
                           .LifestyleScoped()
                );
            }
            else
            {
                container.Register(
                    Component.For<IDependencyResolver>()
                             .Instance(new WindsorDependencyResolver(container)),
                    Component.For<IIdentityService>()
                             .ImplementedBy<TestIdentitiesService>(),
                    Component.For<IIdentityServiceAsync>()
                             .ImplementedBy<UnimplementedIdentityService>(),
                    Classes.From(typeof(IdentitiesController))
                           .BasedOn<ApiController>()
                           .LifestyleScoped()
                );
            }

            container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                         .Named("IDatabaseConnectionStringProvider.Admin")
                         .ImplementedBy<NamedDatabaseConnectionStringProvider>()
                         .DependsOn(Dependency.OnValue("connectionStringName", "EdFi_Admin")));

            container.Register(
                Component
                   .For<SecurityContextFactory>()
                   .ImplementedBy<SecurityContextFactory>());

            container.Register(
                Component.For<IOAuthTokenValidator>()
                         .Instance(CreateOAuthTokenValidator())
                         .IsDefault());

            container.Register(
                Component.For<ISecurityRepository>()
                         .Instance(new StubSecurityRepository()));

            var suppliedApiKeyContextProvider = MockRepository.GenerateStub<IApiKeyContextProvider>();

            container.Register(
                Component.For<IApiKeyContextProvider>()
                         .Instance(suppliedApiKeyContextProvider)
                         .IsDefault());

            container.Register(
                Component.For<IConfigValueProvider>()
                         .ImplementedBy<AppConfigValueProvider>());

            container.Register(
                Component.For<IClaimsIdentityProvider>()
                         .ImplementedBy<ClaimsIdentityProvider>());

            ClaimsPrincipal.ClaimsPrincipalSelector =
                () => EdFiClaimsPrincipalSelector.GetClaimsPrincipal(container.Resolve<IClaimsIdentityProvider>());

            container.Register(
                Component.For<IAuthenticationProvider>()
                         .ImplementedBy<OAuthAuthenticationProvider>());
        }

        protected IOAuthTokenValidator CreateOAuthTokenValidator()
        {
            var oAuthTokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

            oAuthTokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                               .Return(
                                    Task.FromResult(
                                        new ApiClientDetails
                                        {
                                            ApiKey = Guid.NewGuid()
                                                         .ToString("n"),
                                            ApplicationId = 999, ClaimSetName = "SomeClaimSet", NamespacePrefixes = DefaultTestNamespacePrefixes,
                                            EducationOrganizationIds = new List<int>
                                                                       {
                                                                           123, 234
                                                                       }
                                        }));

            return oAuthTokenValidator;
        }

        private static void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            config.MapHttpAttributeRoutes();
            ConfigureIdentityRoutes(config, useSchoolYear);
        }

        private static void ConfigureIdentityRoutes(HttpConfiguration config, bool useSchoolYear = false)
        {
            var routeConfiguration = new IdentityRouteConfiguration();

            routeConfiguration.ConfigureRoutes(config, useSchoolYear);
        }
    }

    [TestFixture]
    public class IdentitiesModelTests
    {
        private const string JsonEncoding = "application/json";
        private const string Name = "Alice";
        private const string City = "Springfield";
        private const string License = "TX1234567";

        private static readonly string _baseRoute = $"identity/v{ApiVersionConstants.Identity}/identities";

        private static IdentityCreateRequest TestIdentity
        {
            get
            {
                dynamic identity = new IdentityCreateRequest
                                   {
                                       FirstName = Name, LastSurname = "Smith", BirthDate = DateTime.Parse("1/1/2000"), SexType = "female",
                                       BirthLocation = new Location
                                                       {
                                                           City = City, StateAbbreviation = "TX"
                                                       }
                                   };

                identity.DriversLicense = new
                                          {
                                              IssuingState = "TX", Number = License
                                          };

                return identity;
            }
        }

        private static IdentitySearchRequest[] TestSearch
        {
            get
            {
                return new[]
                       {
                           new IdentitySearchRequest
                           {
                               FirstName = Name
                           }
                       };
            }
        }

        private static void TestResults(dynamic result3, string uniqueId)
        {
            Assert.AreEqual(uniqueId, result3.UniqueId);
            Assert.AreEqual(100, result3.Score);
            Assert.AreEqual(Name, result3.FirstName);
            Assert.AreEqual(City, result3.BirthLocation.City);
            Assert.AreEqual(License, result3.DriversLicense.Number.Value);
        }

        private static string JsonFormat(string unformattedJson)
        {
            return JsonConvert.SerializeObject(JToken.Parse(unformattedJson), Formatting.Indented);
        }

        [Test]
        public void Should_roundtrip_dynamic_properties_for_all_async_methods()
        {
            var startup = new IdentityServiceTestStartup(isAsync: true);

            using (var server = TestServer.Create(startup.Configuration))
            {
                using (var client = server.HttpClient)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        Guid.NewGuid()
                            .ToString());

                    // Post new identity
                    var json1 = new StringContent(JsonConvert.SerializeObject(TestIdentity), Encoding.UTF8, JsonEncoding);

                    var response1 = client.PostAsync(_baseRoute, json1)
                                          .GetResultSafely();

                    Assert.IsTrue(response1.IsSuccessStatusCode);

                    var uniqueId = response1.Content.ReadAsStringAsync()
                                            .GetResultSafely();

                    var identityUrl = response1.Headers.Location;

                    var response2 = client.GetAsync(identityUrl)
                                          .GetResultSafely();

                    var content2 = response2.Content.ReadAsStringAsync()
                                            .GetResultSafely();

                    dynamic result2 = JsonConvert.DeserializeObject<IdentityResponse>(content2);

                    //Console.WriteLine(JsonFormat(content2));
                    TestResults(result2, uniqueId);

                    var json3 = new StringContent(
                        JsonConvert.SerializeObject(
                            new[]
                            {
                                uniqueId
                            }),
                        Encoding.UTF8,
                        JsonEncoding);

                    var response3 = client.PostAsync($"{_baseRoute}/find", json3)
                                          .GetResultSafely();

                    var findTokenUrl = response3.Headers.Location;

                    var response3A = client.GetAsync(findTokenUrl)
                                           .GetResultSafely();

                    var content3 = response3A.Content.ReadAsStringAsync()
                                             .GetResultSafely();

                    dynamic result3 = JsonConvert.DeserializeObject<IdentitySearchResponse>(content3)
                                                 .SearchResponses[0]
                                                 .Responses[0];

                    //Console.WriteLine(JsonFormat(content3));
                    TestResults(result3, uniqueId);

                    var json4 = new StringContent(JsonConvert.SerializeObject(TestSearch), Encoding.UTF8, JsonEncoding);

                    var response4 = client.PostAsync($"{_baseRoute}/search", json4)
                                          .GetResultSafely();

                    var searchTokenUrl = response4.Headers.Location;

                    var response4A = client.GetAsync(searchTokenUrl)
                                           .GetResultSafely();

                    var content4 = response4A.Content.ReadAsStringAsync()
                                             .GetResultSafely();

                    dynamic result4 = JsonConvert.DeserializeObject<IdentitySearchResponse>(content4)
                                                 .SearchResponses[0]
                                                 .Responses[0];

                    //Console.WriteLine(JsonFormat(content4));
                    TestResults(result4, uniqueId);
                }
            }
        }

        [Test]
        public void Should_roundtrip_dynamic_properties_for_all_methods()
        {
            var startup = new IdentityServiceTestStartup(isAsync: false);

            using (var server = TestServer.Create(startup.Configuration))
            {
                using (var client = server.HttpClient)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        Guid.NewGuid()
                            .ToString());

                    // Post new identity
                    var json1 = new StringContent(JsonConvert.SerializeObject(TestIdentity), Encoding.UTF8, JsonEncoding);

                    var response1 = client.PostAsync(_baseRoute, json1)
                                          .GetResultSafely();

                    Assert.IsTrue(response1.IsSuccessStatusCode);

                    var uniqueId = response1.Content.ReadAsStringAsync()
                                            .GetResultSafely();

                    var identityUrl = response1.Headers.Location;

                    var response2 = client.GetAsync(identityUrl)
                                          .GetResultSafely();

                    var content2 = response2.Content.ReadAsStringAsync()
                                            .GetResultSafely();

                    dynamic result2 = JsonConvert.DeserializeObject<IdentityResponse>(content2);

                    //Console.WriteLine(JsonFormat(content2));
                    TestResults(result2, uniqueId);

                    var json3 = new StringContent(
                        JsonConvert.SerializeObject(
                            new[]
                            {
                                uniqueId
                            }),
                        Encoding.UTF8,
                        JsonEncoding);

                    var response3 = client.PostAsync($"{_baseRoute}/find", json3)
                                          .GetResultSafely();

                    var content3 = response3.Content.ReadAsStringAsync()
                                            .GetResultSafely();

                    dynamic result3 = JsonConvert.DeserializeObject<IdentitySearchResponse>(content3)
                                                 .SearchResponses[0]
                                                 .Responses[0];

                    //Console.WriteLine(JsonFormat(content3));
                    TestResults(result3, uniqueId);

                    var json4 = new StringContent(JsonConvert.SerializeObject(TestSearch), Encoding.UTF8, JsonEncoding);

                    var response4 = client.PostAsync($"{_baseRoute}/search", json4)
                                          .GetResultSafely();

                    var content4 = response4.Content.ReadAsStringAsync()
                                            .GetResultSafely();

                    dynamic result4 = JsonConvert.DeserializeObject<IdentitySearchResponse>(content4)
                                                 .SearchResponses[0]
                                                 .Responses[0];

                    //Console.WriteLine(JsonFormat(content4));
                    TestResults(result4, uniqueId);
                }
            }
        }
    }
}
