// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Test.Properties;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class SwaggerRetrieverTests
    {
        [Test]
        [Category("Run Manually")]
        public async Task Should_retrieve_swagger_information()
        {
            var retriever = new SwaggerRetriever(new TestApiMetadataConfiguration());
            var result = await retriever.LoadMetadata();
            Assert.AreNotEqual(0, result.Count);
        }

        private class TestApiMetadataConfiguration : IApiMetadataConfiguration
        {
            public bool Force => true;

            public string Folder => Settings.Default.XsdFolder;

            public string Url => Settings.Default.SwaggerUrl;
            
            public string DependenciesUrl
            {
                get => null;
            }
        }
    }
}
