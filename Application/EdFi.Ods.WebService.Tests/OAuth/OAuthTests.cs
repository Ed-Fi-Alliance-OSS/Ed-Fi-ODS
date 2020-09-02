// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebService.Tests.OAuth
{
    [TestFixture]
    public class OAuthTests : HttpClientTestsBase
    {
        [Test]
        public async Task OAuthEndpointGetShouldNotAllow()
        {
            var response = await _httpClient.GetAsync(TestConstants.BaseUrl + "oauth/token");

            response.StatusCode.ShouldBe(HttpStatusCode.MethodNotAllowed);

            var json = await response.Content.ReadAsStringAsync();

            json.ShouldBeNullOrWhiteSpace();
        }
    }
}
#endif