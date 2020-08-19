// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Xml.Serialization;
using EdFi.Ods.Profiles.Test;
using EdFi.Ods.WebService.Tests.Owin;
using Microsoft.Owin.Testing;
using TechTalk.SpecFlow;
using MetadataProfiles = EdFi.Ods.Common.Metadata.Schemas.Profiles;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    [Binding]
    public static class FeatureHooks
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            var serializer = new XmlSerializer(typeof(MetadataProfiles));

            var stream = typeof(Marker_EdFi_Ods_Profiles_Test).Assembly
                                                              .GetManifestResourceStream("EdFi.Ods.Profiles.Test.Profiles.xml");

            var sr = new StreamReader(stream);
            string xml = sr.ReadToEnd();

            FeatureContext.Current.Set(XDocument.Parse(xml), "ProfilesXDocument");

            var profiles = (MetadataProfiles) serializer.Deserialize(new StringReader(xml));
            FeatureContext.Current.Set(profiles);
        }

        [BeforeFeature("API")]
        public static void BeforeApiFeature()
        {
            var startup = new ProfilesTestStartup();
            var server = TestServer.Create(startup.Configuration);
            FeatureContext.Current.Set(server);
            FeatureContext.Current.Set(startup.InternalContainer);
            FeatureContext.Current.Set(startup, "OWINstartup");

            var client = new HttpClient(server.Handler);
            FeatureContext.Current.Set(client);

            client.Timeout = new TimeSpan(0, 0, 15, 0);

            // Set client's authorization header to an arbitrary value
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());
        }

        [AfterFeature("API")]
        public static void AfterFeature()
        {
            FeatureContext.Current.Get<WebServiceTestsStartupBase>("OWINstartup")
                          .Dispose();

            FeatureContext.Current.Get<TestServer>()
                          .Dispose();

            FeatureContext.Current.Get<HttpClient>()
                          .Dispose();
        }
    }
}
