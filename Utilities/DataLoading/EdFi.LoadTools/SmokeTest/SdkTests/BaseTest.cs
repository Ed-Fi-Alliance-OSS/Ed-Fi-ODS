// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using EdFi.LoadTools.Engine;
using log4net;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public abstract class BaseTest : ITest
    {
        protected readonly IResourceApi ResourceApi;
        protected readonly Dictionary<string, List<object>> ResultsDictionary;
        private readonly ISdkConfigurationFactory SdkConfigurationFactory;

        protected BaseTest(
            IResourceApi resourceApi,
            Dictionary<string, List<object>> resultsDictionary,
            ISdkConfigurationFactory sdkConfigurationFactory)
        {
            ResourceApi = resourceApi;
            ResultsDictionary = resultsDictionary;
            SdkConfigurationFactory = sdkConfigurationFactory;
        }

        protected ILog Log => LogManager.GetLogger(GetType().Name);

        protected virtual bool NoDataAvailableForTheResource => GetResult() == null;

        public virtual Task<bool> PerformTest()
        {
            using (LogicalThreadContext.Stacks["NDC"]
                .Push(ResourceApi.Name))
            {
                dynamic result = null;

                var methodInfo = GetMethodInfo();

                if (methodInfo == null)
                {
                    Log.Error($"Unable to find method info for {ResourceApi.Name}.");
                    return Task.FromResult(false);
                }

                if (!ShouldPerformTest())
                {
                    Log.Info("Skipped - Should not perform test.");
                    return Task.FromResult(true);
                }

                if (NoDataAvailableForTheResource)
                {
                    Log.Info("Skipped - No data available for the resource.");
                    return Task.FromResult(true);
                }

                var @params = GetParams(methodInfo);

                if (@params == null)
                {
                    Log.Error($"Unable to find the test data for {ResourceApi.Name}.");
                    return Task.FromResult(false);
                }

                try
                {
                    var api = GetApiInstance();
                    result = methodInfo.Invoke(api, @params);
                }
                catch (Exception e)
                {
                    Log.Debug("----- BEGIN EXCEPTION INFORMATION -----");
                    Log.Debug(methodInfo);
                    Log.Debug(@params);

                    // we want to continue testing thus we are swallowing the exception.
                    Log.Error($"Exception: {e}");

                    Log.Debug("----- END EXCEPTION INFORMATION -----");

                    return Task.FromResult(false);
                }

                var responseStatusCode = (HttpStatusCode) result.StatusCode;

                if (IsExpectedResponse(responseStatusCode))
                {
                    CheckResult(result);
                    Log.Info($"{(int) responseStatusCode} {responseStatusCode}");
                    return Task.FromResult(true);
                }

                Log.Error($"{(int) responseStatusCode} {responseStatusCode}");
                return Task.FromResult(false);
            }
        }

        protected abstract MethodInfo GetMethodInfo();

        protected virtual object[] GetParams(MethodInfo methodInfo)
        {
            var obj = GetResult();

            if (obj == null)
            {
                return null;
            }

            var type = obj.GetType();

            return methodInfo.GetParameters()
                .Select(
                    p => type.GetProperty(p.Name)
                        ?.GetValue(obj, null))
                .ToArray();
        }

        protected virtual bool CheckResult(dynamic result)
        {
            return true;
        }

        private object GetApiInstance()
        {
            return Activator.CreateInstance(ResourceApi.ApiType, SdkConfigurationFactory.SdkConfiguration);
        }

        protected object GetResourceFromUri(Uri resourceUri)
        {
            var api = GetApiInstance();
            var getByIdMethod = ResourceApi.GetByIdMethod;
            var id = Path.GetFileName(resourceUri.ToString());

            var @params = new object[]
            {
                id,
                Type.Missing,
                Type.Missing
            };

            try
            {
                dynamic result = getByIdMethod.Invoke(api, @params);
                return result.Data;
            }
            catch (Exception e)
            {
                Log.Error($"Exception: {e}");
                throw;
            }
        }

        protected virtual bool ShouldPerformTest()
        {
            return true;
        }

        protected object GetResult()
        {
            var obj = ResultsDictionary.FirstOrDefault(r => ResourceApi.ModelType.Name == r.Key);

            return string.IsNullOrEmpty(obj.Key)
                ? null
                : obj.Value.FirstOrDefault();
        }

        protected bool IsExpectedResponse(HttpStatusCode statusCode)
        {
            return statusCode >= HttpStatusCode.OK && statusCode <= (HttpStatusCode) 299;
        }
    }
}
