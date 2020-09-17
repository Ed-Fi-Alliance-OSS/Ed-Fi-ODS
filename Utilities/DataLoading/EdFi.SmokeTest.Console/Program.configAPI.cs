// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Net.Http;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.ApiTests;
using EdFi.LoadTools.SmokeTest.CommonTests;
using EdFi.SmokeTest.Console.Application;
using Newtonsoft.Json.Linq;
using SimpleInjector;
using Swashbuckle.Swagger;

namespace EdFi.SmokeTest.Console
{
    public partial class Program
    {
        private static void ConfigureNonDestructiveApi(Container c)
        {
            c.RegisterSingleton<IOAuthTokenHandler, OAuthTokenHandler>();
            c.RegisterSingleton<ITokenRetriever, TokenRetriever>();

            c.RegisterCollection<ITestGenerator>(
                new[]
                {
                    typeof(GetStaticVersionTest), typeof(GetStaticDependenciesTest), typeof(GetSwaggerMetadataGenerator), typeof(GetSessionTokenGenerator), typeof(GetMethodsGenerator)
                });

            c.RegisterInstance<ITestFactory<Resource, ITest>>(
                new TestFactory<Resource, ITest>
                {
                    r => new GetAllTest(
                        r, c.GetInstance<Dictionary<string, JArray>>(),
                        c.GetInstance<IApiConfiguration>(), c.GetInstance<IOAuthTokenHandler>(),null),
                    r => new GetAllSkipLimitTest(
                        r, c.GetInstance<Dictionary<string, JArray>>(),
                        c.GetInstance<IApiConfiguration>(), c.GetInstance<IOAuthTokenHandler>(),null),
                    r => new GetByIdTest(
                        r, c.GetInstance<Dictionary<string, JArray>>(),
                        c.GetInstance<IApiConfiguration>(), c.GetInstance<IOAuthTokenHandler>(),null),
                    r => new GetByExampleTest(
                        r, c.GetInstance<Dictionary<string, JArray>>(),
                        c.GetInstance<IApiConfiguration>(), c.GetInstance<IOAuthTokenHandler>(),null)
                });

            c.Register<SwaggerRetriever>();

            // Holds OpenAPI metadata
            c.RegisterSingleton(() => new Dictionary<string, Resource>());

            // Holds OpenAPI metadata
            c.RegisterSingleton(() => new Dictionary<string, SwaggerDocument>());

            // Holds the OpenApi Model Definitions
            c.RegisterSingleton(() => new Dictionary<string, Entity>());

            // holds GetAll results for later use
            c.RegisterSingleton(() => new Dictionary<string, JArray>());

            // Holds unique schema names
            c.RegisterSingleton(() => new List<string>());
        }
    }
}
