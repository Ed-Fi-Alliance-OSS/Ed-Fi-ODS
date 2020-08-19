// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Linq;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class GetMethodsGenerator : ITestGenerator
    {
        private readonly ISdkCategorizer _sdkCategorizer;
        private readonly ITestFactory<IResourceApi, ITest> _testFactory;

        public GetMethodsGenerator(ISdkCategorizer sdkCategorizer, ITestFactory<IResourceApi, ITest> testFactory)
        {
            _sdkCategorizer = sdkCategorizer;
            _testFactory = testFactory;
        }

        public IEnumerable<ITest> GenerateTests()
        {
            return from resourceApi in _sdkCategorizer.ResourceApis
                   from testFactoryFunc in _testFactory
                   select testFactoryFunc(resourceApi);
        }
    }
}
