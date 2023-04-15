// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Http;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests.Sandbox.Controllers
{
    public class HttpClientTestsBase
    {
        protected HttpClient HttpClient { get; private set; }

        protected EdFiTestUriHelper UriHelper { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            HttpClient = new HttpClient();
            UriHelper = new EdFiTestUriHelper(TestConstants.BaseUrl);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            HttpClient.Dispose();
        }
    }
}