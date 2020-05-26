// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.SmokeTest.ApiTests
{
    public class GetMethodsGenerator : ITestGenerator
    {
        private readonly Dictionary<string, Resource> _resources;
        private readonly ITestFactory<Resource, ITest> _testFactory;

        public GetMethodsGenerator(Dictionary<string, Resource> resources, ITestFactory<Resource, ITest> testFactory)
        {
            _resources = resources;
            _testFactory = testFactory;
        }

        public IEnumerable<ITest> GenerateTests()
        {
            return from resource in _resources.Values
                   from testFactoryFunc in _testFactory
                   select testFactoryFunc(resource);
        }
    }
}
