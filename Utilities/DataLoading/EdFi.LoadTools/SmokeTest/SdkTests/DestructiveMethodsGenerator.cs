// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class DestructiveMethodsGenerator : ITestGenerator
    {
        private readonly IModelDependencySort _modelDependencySort;
        private readonly ITestFactory<IResourceApi, ITest> _testFactory;

        public DestructiveMethodsGenerator(IModelDependencySort modelDependencySort,
                                           ITestFactory<IResourceApi, ITest> testFactory)
        {
            _modelDependencySort = modelDependencySort;
            _testFactory = testFactory;
        }

        public IEnumerable<ITest> GenerateTests()
        {
            return from resourceApi in _modelDependencySort.OrderedApis()
                   from testFactoryFunc in _testFactory
                   select testFactoryFunc(resourceApi);
        }
    }
}
