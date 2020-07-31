// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Test.Properties;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class JsonMetadataTests
    {
        public static IApiMetadataConfiguration ApiMetadataConfiguration
        {
            get { return new TestApiMetadataConfiguration(); }
        }

        public static IXsdConfiguration XmlMetadataConfiguration
        {
            get { return new TestApiMetadataConfiguration(); }
        }

        public static IInterchangeOrderConfiguration InterchangeOrderConfiguration
        {
            get { return new TestInterchangeOrderConfiguration(); }
        }

        [Test]
        [Category("Run Manually")]
        public void Should_display_all_Json_metadata()
        {
            var loader = new SwaggerMetadataRetriever(
                ApiMetadataConfiguration, new SwaggerRetriever(ApiMetadataConfiguration), new List<string>
                                                                                          {
                                                                                              "ed-fi"
                                                                                          });

            IEnumerable<JsonModelMetadata> jsonMetadata = loader.GetMetadata().Result;

            foreach (JsonModelMetadata metadata in jsonMetadata)
            {
                Console.WriteLine(
                    $"{metadata.Model},{metadata.Property},{metadata.Type},{metadata.IsArray},{metadata.IsRequired},{metadata.IsSimpleType}");
            }
        }

        private class TestApiMetadataConfiguration : IApiMetadataConfiguration, IXsdConfiguration
        {
            public bool Force
            {
                get { return false; }
            }

            string IApiMetadataConfiguration.Folder
            {
                get { return Settings.Default.WorkingFolder; }
            }

            public string Url
            {
                get { return Settings.Default.SwaggerUrl; }
            }

            bool IXsdConfiguration.DoNotValidateXml
            {
                get { return false; }
            }

            string IXsdConfiguration.Folder
            {
                get { return Settings.Default.XsdFolder; }
            }
            
            string IApiMetadataConfiguration.DependenciesUrl
            {
                get => null;
            }
        }

        private class TestInterchangeOrderConfiguration : IInterchangeOrderConfiguration
        {
            public string Folder
            {
                get { return Settings.Default.InterchangeOrderFolder; }
            }
        }
    }
}
