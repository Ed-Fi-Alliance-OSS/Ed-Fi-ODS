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
            var parameters = methodInfo.GetParameters();
            var inputParams = new List<object>();

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];

                // First two parameters are typically offset and limit
                if (i < 2)
                {
                    // Check if parameter is Option<int> type
                    if (param.ParameterType.IsGenericType && 
                        param.ParameterType.GetGenericTypeDefinition().Name == "Option`1")
                    {
                        // Create Option<int>(1) using reflection
                        var optionType = param.ParameterType;
                        var optionInstance = Activator.CreateInstance(optionType, 1);
                        inputParams.Add(optionInstance);
                    }
                    else
                    {
                        inputParams.Add(1);
                    }
                }
                else if (param.HasDefaultValue)
                {
                    inputParams.Add(Type.Missing);
                }
                else
                {
                    inputParams.Add(null);
                }
            }

            return inputParams.ToArray();
        }
    }
}
