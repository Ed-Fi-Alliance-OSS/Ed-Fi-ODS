// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Api.Providers;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Text;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Common.Security;
using EdFi.Ods.Api.Security.Authentication;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers
{
    public static class ControllerHelper
    {
        public static TokenController CreateTokenController(
            IApiClientAuthenticator apiClientAuthenticator,
            IAccessTokenFactory accessTokenFactory)
        {
            var tokenRequestProvider = new ClientCredentialsTokenRequestProvider(apiClientAuthenticator, accessTokenFactory);
            var controller = new TokenController(tokenRequestProvider);
            var request = A.Fake<HttpRequest>();
            request.Method = "Post";
            request.Scheme = "http";

            A.CallTo(() => request.Host).Returns(new HostString("localhost", 80));

            request.PathBase = "/";
            request.RouteValues = new RouteValueDictionary {{"controller", "authorize"}};

            var httpContext = A.Fake<HttpContext>();
            A.CallTo(() => httpContext.Request).Returns(request);

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            var routeData = A.Fake<RouteData>();
            RouteValueDictionary dictionary = new RouteValueDictionary {{"controller", "authorize"}};

            controllerContext.RouteData = new RouteData(dictionary);
            controller.ControllerContext = controllerContext;

            return controller;
        }

        public static ControllerContext CreateControllerContext(HeaderDictionary headerDictionary)
        {
            var request = A.Fake<HttpRequest>();

            A.CallTo(() => request.Headers).Returns(headerDictionary);

            var httpContext = A.Fake<HttpContext>();
            A.CallTo(() => httpContext.Request).Returns(request);

            return new ControllerContext {HttpContext = httpContext};
        }

        public static string CreateEncodedAuthentication(string clientKey = "clientId", string clientSecret = "clientSecret")
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientKey}:{clientSecret}"));
        }
    }
}
