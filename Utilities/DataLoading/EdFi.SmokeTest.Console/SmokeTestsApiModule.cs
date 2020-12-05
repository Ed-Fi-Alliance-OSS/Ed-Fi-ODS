// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.ApiTests;
using EdFi.LoadTools.SmokeTest.CommonTests;
using EdFi.SmokeTest.Console.Application;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger;

namespace EdFi.SmokeTest.Console
{
    public class SmokeTestsApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var generators = new[]
            {
                typeof(GetStaticVersionTest),
                typeof(GetStaticDependenciesTest),
                typeof(GetSwaggerMetadataGenerator),
                typeof(GetSessionTokenGenerator),
                typeof(GetMethodsGenerator)
            };

            foreach (var generator in generators)
            {
                builder.RegisterType(generator)
                    .As<ITestGenerator>();
            }

            builder.Register(
                    c =>
                    {
                        var ctx = c.Resolve<IComponentContext>();
                        var apiConfiguration = ctx.Resolve<IApiConfiguration>();
                        var tokenHandler = ctx.Resolve<IOAuthTokenHandler>();
                        var results = ctx.Resolve<Dictionary<string, JArray>>();

                        return new TestFactory<Resource, ITest>
                        {
                            r => new GetAllTest(r, results, apiConfiguration, tokenHandler),
                            r => new GetAllSkipLimitTest(r, results, apiConfiguration, tokenHandler),
                            r => new GetByIdTest(r, results, apiConfiguration, tokenHandler),
                            r => new GetByExampleTest(r, results, apiConfiguration, tokenHandler)
                        };
                    })
                .As<ITestFactory<Resource, ITest>>();

            builder.RegisterInstance(new Dictionary<string, Resource>())
                .SingleInstance();

            builder.RegisterInstance(new Dictionary<string, SwaggerDocument>())
                .SingleInstance();

            builder.RegisterInstance(new Dictionary<string, Entity>())
                .SingleInstance();

            builder.RegisterInstance(new Dictionary<string, JArray>())
                .SingleInstance();

            builder.RegisterInstance(new List<string>())
                .SingleInstance();
        }
    }
}
