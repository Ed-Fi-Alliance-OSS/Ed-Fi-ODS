// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class PutTest : BaseTest
    {
        private readonly Dictionary<string, Uri> _createdDictionary;

        public PutTest(IResourceApi resourceApi, Dictionary<string, List<object>> resultsDictionary,
                       Dictionary<string, Uri> createdDictionary, ISdkConfigurationFactory sdkConfigurationFactory)
            : base(resourceApi, resultsDictionary, sdkConfigurationFactory)
        {
            _createdDictionary = createdDictionary;
        }

        protected override object[] GetParams(MethodInfo methodInfo)
        {
            if (!_createdDictionary.ContainsKey(ResourceApi.ModelType.Name))
            {
                Log.Info("Skipped - not created during POST");
                return null;
            }

            var uri = _createdDictionary[ResourceApi.ModelType.Name];
            var id = Path.GetFileName(uri.ToString());
            dynamic model = GetResourceFromUri(uri);

            return new object[]
                   {
                       id, model, null
                   };
        }

        protected override MethodInfo GetMethodInfo()
        {
            return ResourceApi.PutMethod;
        }

        protected override bool CheckResult(dynamic result, object[] requestParameters)
            => result.StatusCode == HttpStatusCode.NoContent;
    }
}
