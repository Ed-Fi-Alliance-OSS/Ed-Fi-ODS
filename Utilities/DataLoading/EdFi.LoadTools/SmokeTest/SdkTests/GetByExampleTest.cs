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
    public class GetByExampleTest : BaseTest
    {
        public GetByExampleTest(IResourceApi resourceApi, Dictionary<string, List<object>> resultsDictionary,
                                ISdkConfigurationFactory sdkConfigurationFactory)
            : base(resourceApi, resultsDictionary, sdkConfigurationFactory) { }

        protected override MethodInfo GetMethodInfo()
        {
            return ResourceApi.GetAllMethod;
        }

        protected override object[] GetParams(MethodInfo methodInfo)
        {
            var typeName = ResourceApi.ModelType.Name;

            dynamic typeValue = ResultsDictionary.ContainsKey(typeName)
                ? ResultsDictionary[typeName].FirstOrDefault()
                : null;

            var parameters = methodInfo.GetParameters();
            object sourceObject = typeValue;
            var sourceObjectType = sourceObject?.GetType();

            if (sourceObjectType == null || !parameters.Any())
            {
                return null;
            }

            var methodParams = parameters
                              .Select(
                                   i => new
                                        {
                                            ParameterInfo = i, Name = sourceObjectType
                                                                     .GetProperties()
                                                                     .Select(p => p.Name)
                                                                     .FirstOrDefault(
                                                                          p =>
                                                                              p.Equals(i.Name, StringComparison.InvariantCultureIgnoreCase)) ?? i.Name
                                        })
                              .Select(
                                   t => t.ParameterInfo.Name.Equals("id", StringComparison.InvariantCultureIgnoreCase)
                                       ? null
                                       : sourceObjectType.GetProperty(t.Name)?.GetValue(sourceObject, null))
                              .ToArray();

            return methodParams;
        }
    }
}
