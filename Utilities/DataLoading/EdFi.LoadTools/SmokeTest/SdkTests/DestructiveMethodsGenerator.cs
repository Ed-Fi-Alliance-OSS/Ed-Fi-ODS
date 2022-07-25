// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.LoadTools.ApiClient;
using log4net;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class DestructiveMethodsGenerator : ITestGenerator
    {
        private readonly ISdkCategorizer _categorizer;
        private readonly ITestFactory<IResourceApi, ITest> _testFactories;
        private readonly IDependenciesRetriever _dependenciesRetriever;
        private readonly IDependenciesSorter _dependenciesSorter;

        public DestructiveMethodsGenerator(ISdkCategorizer categorizer,
                                           ITestFactory<IResourceApi, ITest> testFactories,
                                           IDependenciesRetriever dependenciesRetriever,
                                           IDependenciesSorter dependenciesSorter)
        {
            _categorizer = categorizer;
            _testFactories = testFactories;
            _dependenciesRetriever = dependenciesRetriever;
            _dependenciesSorter = dependenciesSorter;
        }

        protected ILog Log => LogManager.GetLogger(GetType().Name);

        public IEnumerable<ITest> GenerateTests()
        {
            var dependencies = _dependenciesRetriever.GetDependencyOrderAsync().GetResultSafely()
                .ToList();

            var sdkResourcesByName = _categorizer.ResourceApis
                .ToDictionary(a => a.ModelType.Name, StringComparer.OrdinalIgnoreCase);

            return _testFactories
                .SelectMany(
                    testFactory =>
                        _dependenciesSorter.GetValueOrDefault(testFactory(default).GetType(), d => d)(dependencies)
                            .Select(
                                dependency =>
                                {
                                    var sdkResource = sdkResourcesByName.GetValueOrDefault(
                                        DependencyResourceNameToSdkResourceName(dependency));

                                    if (sdkResource is not null)
                                    {
                                        return testFactory(sdkResource);
                                    }

                                    Log.Info(
                                        $"Skipped - Couldn't find a matching SDK for the resource '{dependency.Resource}' with namespace '{dependency.Namespace}'.");

                                    return null;
                                }))
                .Where(test => test is not null);
        }

        private static string DependencyResourceNameToSdkResourceName(Dependency dependency) =>
            dependency.Namespace.Replace("-", string.Empty) + dependency.Resource;
    }
}
