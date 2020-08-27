// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Net.Http;
using NUnit.Framework;

namespace EdFi.Ods.WebService.Tests
{
    public class HttpClientTestsBase
    {
        [OneTimeSetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
        }

        protected HttpClient _httpClient;
    }
}
#endif