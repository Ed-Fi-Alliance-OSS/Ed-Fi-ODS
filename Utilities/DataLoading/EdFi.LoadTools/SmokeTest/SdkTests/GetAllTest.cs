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
    public class GetAllTest(IResourceApi resourceApi, Dictionary<string, List<object>> resultsDictionary,
        ISdkConfigurationFactory sdkConfigurationFactory, bool failIfNoData = false) 
        : BaseTest(resourceApi, resultsDictionary, sdkConfigurationFactory)
    {
        protected override bool NoDataAvailableForTheResource => false;

        protected override MethodInfo GetMethodInfo()
        {
            return ResourceApi.GetAllMethod;
        }

        protected override object[] GetParams(MethodInfo methodInfo)
        {
            return methodInfo.GetParameters()
                .Select(p => p.HasDefaultValue ? Type.Missing : (object)null)
                .ToArray();
        }

        private protected override bool CheckResult(SdkOperationResponse response, object[] requestParameters)
        {
            if (response.Payload is System.Collections.IEnumerable data)
            {
                var items = data.Cast<object>().ToList();
                ResultsDictionary[ResourceApi.ModelType.Name] = items;

                if (failIfNoData && items.Count == 0)
                {
                    // Destructive SDK tests create a record for all the entities, so at least one record is expected.
                    Log.Error("The request did not return any records, but at least one was expected.");
                    return false;
                }
            }
            else
            {
                ResultsDictionary[ResourceApi.ModelType.Name] = new List<object>();
            }

            return true;
        }
    }
}
