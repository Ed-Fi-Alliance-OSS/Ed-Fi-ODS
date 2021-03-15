// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class GetByIdTest : BaseTest
    {
        public GetByIdTest(IResourceApi resourceApi, Dictionary<string, List<object>> resultsDictionary,
                           ISdkConfigurationFactory sdkConfigurationFactory)
            : base(resourceApi, resultsDictionary, sdkConfigurationFactory) { }

        protected override MethodInfo GetMethodInfo()
        {
            return ResourceApi.GetByIdMethod;
        }

        protected override object[] GetParams(MethodInfo methodInfo)
        {
            dynamic typeValue = GetResult();

            var id = typeValue != null
                ? typeValue.Id.ToString()
                : Guid.Empty.ToString("n");

            object[] paramArray = Enumerable.Repeat<object>(string.Empty, methodInfo.GetParameters().Length).ToArray();
            paramArray[0] = id;
            return paramArray;
        }

        protected override bool ShouldPerformTest()
        {
            return GetMethodInfo().GetParameters().Any(p => p.Name.Equals("id") && !p.IsOptional);
        }
    }
}
