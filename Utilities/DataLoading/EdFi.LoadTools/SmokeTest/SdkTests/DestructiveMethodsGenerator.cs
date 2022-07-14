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
        private readonly IModelDependencySort _modelDependencySort;
        private readonly ITestFactory<IResourceApi, ITest> _testFactories;
        private readonly IDependenciesRetriever _dependenciesRetriever;
        private readonly IDependenciesSorter _dependenciesSorter;

        public DestructiveMethodsGenerator(IModelDependencySort modelDependencySort,
                                           ITestFactory<IResourceApi, ITest> testFactories,
                                           IDependenciesRetriever dependenciesRetriever,
                                           IDependenciesSorter dependenciesSorter)
        {
            _modelDependencySort = modelDependencySort;
            _testFactories = testFactories;
            _dependenciesRetriever = dependenciesRetriever;
            _dependenciesSorter = dependenciesSorter;
        }

        protected ILog Log => LogManager.GetLogger(GetType().Name);

        public IEnumerable<ITest> GenerateTests()
        {
            var dependencies = _dependenciesRetriever.GetDependencyOrderAsync().GetResultSafely()
                .ToList();

            var sdkResourcesByName = _modelDependencySort.OrderedApis()
                .ToDictionary(a => a.ModelType.Name, StringComparer.OrdinalIgnoreCase);

            return _testFactories
                .SelectMany(
                    testFactory =>
                        _dependenciesSorter.GetValueOrDefault(testFactory(default).GetType(), d => d)(dependencies)
                            .Select(
                                d => (dependency: d,
                                    sdkResource: sdkResourcesByName.GetValueOrDefault(
                                        DependencyResourceNameToSdkResourceName(d), null)))
                            .Select(
                                dependencyAndSdkResource =>
                                {
                                    if (dependencyAndSdkResource.sdkResource is not null)
                                    {
                                        return testFactory(dependencyAndSdkResource.sdkResource);
                                    }

                                    Log.Info(
                                        $"Couldn't find an SDK with name '{DependencyResourceNameToSdkResourceName(dependencyAndSdkResource.dependency)}'. The endpoint's tests will be skipped.");
                                    return null;
                                }))
                .Where(test => test is not null);
        }

        private static string DependencyResourceNameToSdkResourceName(Dependency dependency) =>
            dependency.Namespace.Replace("-", string.Empty) + dependency.Resource;
    }
}
