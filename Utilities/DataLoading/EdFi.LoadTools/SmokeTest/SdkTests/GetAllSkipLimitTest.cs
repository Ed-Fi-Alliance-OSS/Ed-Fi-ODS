// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class GetAllSkipLimitTest : BaseTest
    {
        public GetAllSkipLimitTest(IResourceApi resourceApi, Dictionary<string, List<object>> resultsDictionary,
                                   ISdkConfigurationFactory sdkConfigurationFactory)
            : base(resourceApi, resultsDictionary, sdkConfigurationFactory) { }

        protected override MethodInfo GetMethodInfo()
        {
            return ResourceApi.GetAllMethod;
        }

        protected override object[] GetParams(MethodInfo methodInfo)
        {
            return FillInputParameters(methodInfo);
        }

        private static object[] FillInputParameters(MethodInfo methodInfo)
        {
            var inputParams = new List<object>
                              {
                                  1, 1
                              };

            inputParams.AddRange(Enumerable.Repeat<object>(null, methodInfo.GetParameters().Length - 2).ToList());

            return inputParams.ToArray();
        }
    }
}
