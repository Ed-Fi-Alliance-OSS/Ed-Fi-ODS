// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Castle.Windsor;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public static class FeatureContextExtensions
    {
        public static IWindsorContainer Container(this FeatureContext context) => FeatureContext.Current.Get<IWindsorContainer>();

        public static HttpClient HttpClient(this FeatureContext context, string contentType)
        {
            var httpClient = context.Get<HttpClient>();

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Accept.ToString(), contentType);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                Guid.NewGuid()
                    .ToString());

            return httpClient;
        }
    }
}
#endif