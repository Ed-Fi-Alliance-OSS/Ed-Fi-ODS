// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.CommonTests;
using EdFi.LoadTools.SmokeTest.SdkTests;
using EdFi.SmokeTest.Console.Application;

namespace EdFi.SmokeTest.Console
{
    public class SmokeTestsNonDestructiveSdkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var testGenerators =
                new[]
                {
                    typeof(GetStaticVersionTest),
                    typeof(GetStaticDependenciesTest),
                    typeof(GetMethodsGenerator)
                };

            foreach (var generator in testGenerators)
            {
                builder.RegisterType(generator).As<ITestGenerator>();
            }

            builder.Register(
                    c =>
                    {
                        var ctx = c.Resolve<IComponentContext>();
                        var factory = ctx.Resolve<ISdkConfigurationFactory>();
                        var results = ctx.Resolve<Dictionary<string, List<object>>>();

                        return new TestFactory<IResourceApi, ITest>
                        {
                            t => new GetAllTest(t, results, factory),
                            t => new GetByExampleTest(t, results, factory),
                            t => new GetAllSkipLimitTest(t, results, factory),
                            t => new GetByIdTest(t, results, factory)
                        };
                    })
                .As<ITestFactory<IResourceApi, ITest>>();

            // holds all results
            builder.RegisterInstance(new Dictionary<string, List<object>>()).SingleInstance();
        }
    }
}
