// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class JsonMetadataTests
    {
        private static readonly IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        public static IApiMetadataConfiguration ApiMetadataConfiguration
        {
            get => new TestApiMetadataConfiguration(_configuration);
        }

        public static IXsdConfiguration XmlMetadataConfiguration
        {
            get => new TestApiMetadataConfiguration(_configuration);
        }

        public static IInterchangeOrderConfiguration InterchangeOrderConfiguration
        {
            get => new TestInterchangeOrderConfiguration(_configuration);
        }

        [Test]
        [Category("RunManually")]
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
            private readonly IConfiguration _configuration;

            public TestApiMetadataConfiguration(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public bool Force
            {
                get => false;
            }

            string IApiMetadataConfiguration.Folder
            {
                get => TestContext.CurrentContext.TestDirectory;
            }

            public string Url
            {
                get => _configuration["OdsApi:MetadataUrl"];
            }

            bool IXsdConfiguration.DoNotValidateXml
            {
                get { return false; }
            }

            public string Extension
            {
                get => _configuration["OdsApi:Extension"];
            }

            public string XsdMetadataUrl
            {
                get => _configuration["OdsApi:XsdMetadataUrl"];
            }

            string IXsdConfiguration.Folder
            {
                get => _configuration["Folders:Xsd"];
            }

            string IApiMetadataConfiguration.DependenciesUrl
            {
                get => null;
            }
        }

        private class TestInterchangeOrderConfiguration : IInterchangeOrderConfiguration
        {
            private readonly IConfiguration _configuration;

            public TestInterchangeOrderConfiguration(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string Folder
            {
                get => _configuration["Folders:Interchange"];
            }
        }
    }
}
