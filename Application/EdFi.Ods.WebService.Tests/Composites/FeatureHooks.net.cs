// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http;
using Castle.MicroKernel.Lifestyle;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Composites.Test;
using EdFi.Ods.Features;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.WebService.Tests.Owin;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using Microsoft.Owin.Testing;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Composites
{
    public static class FeatureContextKeys
    {
        public const string CompositesMetadataProvider = "CompositesMetadataProvider";
        public const string CompositeDefinitionProcessor = "CompositeDefinitionProcessor";
        public const string ResourceModel = "ResourceModel";
    }

    [Binding]
    public static class FeatureHooks
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(FeatureHooks));
        private static CompositesTestStartup _startup;

        [BeforeFeature("Composites", "CompositesResourceModelComponents")]
        public static void BeforeApiFeature()
        {
            _startup = new CompositesTestStartup();
            var server = TestServer.Create(_startup.Configuration);
            FeatureContext.Current.Set(server);
            FeatureContext.Current.Set(_startup.InternalContainer);
            FeatureContext.Current.Set(_startup, "OWINstartup");

            var scope = _startup.InternalContainer.BeginScope();
            var controllers  = _startup.InternalContainer.ResolveAll(typeof(ApiController));
            scope.Dispose();

            var client = new HttpClient(server.Handler);

            client.DefaultRequestHeaders.Add(
                "IncludeNulls",
                new[]
                {
                    "true"
                });

            FeatureContext.Current.Set(client);

            client.Timeout = new TimeSpan(0, 0, 15, 0);

            // Set client's authorization header to an arbitrary value
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());

            Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;

            MemoryAppender memoryAppender = hierarchy.GetAppenders()
                                                     .SingleOrDefault(a => a.Name == "MemoryAppender") as MemoryAppender;

            FeatureContext.Current.Set(memoryAppender);

            InitializeClaimsPrincipalSelectorFromScenarioContext();
        }

        private static void InitializeClaimsPrincipalSelectorFromScenarioContext()
        {
            ClaimsPrincipal.ClaimsPrincipalSelector = () =>
                                                      {
                                                          ClaimsIdentity identity;

                                                          if (ScenarioContext.Current.TryGetValue(out identity))
                                                          {
                                                              return new ClaimsPrincipal(identity);
                                                          }

                                                          List<string> assignedProfiles;

                                                          if (ScenarioContext.Current.TryGetValue(
                                                              Profiles.ScenarioContextKeys.AssignedProfiles,
                                                              out assignedProfiles))
                                                          {
                                                              var claims = assignedProfiles.Select(p => new Claim(EdFiOdsApiClaimTypes.Profile, p));
                                                              identity = new ClaimsIdentity(claims);
                                                              ScenarioContext.Current.Set(identity);
                                                              return new ClaimsPrincipal(identity);
                                                          }

                                                          return new ClaimsPrincipal(new ClaimsIdentity());
                                                      };
        }

        [AfterFeature("Composites", "CompositesResourceModelComponents")]
        public static void AfterFeature()
        {
#pragma warning disable 618
            // TODO: Remove with ODS-2973, deprecated by ODS-2974
            FeatureContext.Current.Get<WebServiceTestsStartupBase>("OWINstartup")
#pragma warning restore 618
                          .Dispose();

            FeatureContext.Current.Get<TestServer>()
                          .Dispose();

            FeatureContext.Current.Get<HttpClient>()
                          .Dispose();
        }

        [BeforeFeature("CompositesResourceModelComponents")]
        public static void BeforeCompositeResourceModelFeature()
        {
            // Ensure that the assembly containing the composites metadata has been loaded
            AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();
            AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Features>();

            var compositeMetadataProvider = new CompositesMetadataProvider();
            FeatureContext.Current.Set(compositeMetadataProvider, FeatureContextKeys.CompositesMetadataProvider);

            var domainModel =
                _startup.InternalContainer.Resolve<IDomainModelProvider>()
                        .GetDomainModel();

            var resourceModel = new ResourceModel(domainModel);

            var resourceModelBuilderCompositeProcessor =
                new CompositeDefinitionProcessor<CompositeResourceModelBuilderContext, Resource>(new CompositeResourceModelBuilder());

            FeatureContext.Current.Set(resourceModel, FeatureContextKeys.ResourceModel);
            FeatureContext.Current.Set(resourceModelBuilderCompositeProcessor, FeatureContextKeys.CompositeDefinitionProcessor);
        }
    }
}
