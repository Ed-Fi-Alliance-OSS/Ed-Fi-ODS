// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class SwaggerRetrieverTests
    {
        private IConfigurationRoot _configuration;

        [SetUp]
        public void SetUp()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        [Test]
        [Category("RunManually")]
        public async Task Should_retrieve_swagger_information()
        {
            var retriever = new SwaggerRetriever(new TestApiMetadataConfiguration(_configuration));
            var result = await retriever.LoadMetadata();
            Assert.AreNotEqual(0, result.Count);
        }

        private class TestApiMetadataConfiguration : IApiMetadataConfiguration
        {
            private readonly IConfiguration _configuration;

            public TestApiMetadataConfiguration(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public bool Force
            {
                get => true;
            }

            public string Folder
            {
                get => _configuration["Folder:Xsd"];
            }

            public string Url
            {
                get => _configuration["OdsApi:MetadataUrl"];
            }

            public string DependenciesUrl
            {
                get => null;
            }
        }
    }
}
