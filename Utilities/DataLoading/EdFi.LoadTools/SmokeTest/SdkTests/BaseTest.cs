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

        public virtual async Task<bool> PerformTest()
        {
            using (LogicalThreadContext.Stacks["NDC"]
                .Push(ResourceApi.Name))
            {
                var canonicalMethod = GetMethodInfo();

                if (canonicalMethod == null)
                {
                    Log.Error($"Unable to find method info for {ResourceApi.Name}.");
                    return false;
                }

                if (!ShouldPerformTest())
                {
                    Log.Info("Skipped - Should not perform test.");
                    return true;
                }

                if (NoDataAvailableForTheResource)
                {
                    Log.Info("Skipped - No data available for the resource.");
                    return true;
                }

                // Old-generator mode: invoke the *WithHttpInfoAsync companion so the result carries
                // status/headers/data. New-generator mode: this returns the canonical method unchanged.
                var methodInfo = ResourceApi.GetExecutionMethod(canonicalMethod);

                var @params = GetParams(methodInfo);

                if (@params == null)
                {
                    Log.Error($"Unable to find the test data for {ResourceApi.Name}.");
                    return false;
                }

                SdkOperationResponse response;

                try
                {
                    var api = GetApiInstance();
                    Log.Debug($"API instance type: {api.GetType().FullName}");

                    var taskResult = methodInfo.Invoke(api, @params);

                    object raw;
                    if (taskResult is Task task)
                    {
                        await task;
                        raw = task.GetType().GetProperty("Result")?.GetValue(task);
                    }
                    else
                    {
                        raw = taskResult;
                    }

                    response = new SdkOperationResponse(raw);

                    Log.Debug($"Response status: {response.StatusCode}, Raw content length: {response.RawContent?.Length ?? 0}");
                    if (response.StatusCode == HttpStatusCode.NotFound && !string.IsNullOrEmpty(response.RawContent))
                    {
                        Log.Debug($"404 Response content: {response.RawContent}");
                    }
                }
                catch (Exception e)
                {
                    Log.Debug("----- BEGIN EXCEPTION INFORMATION -----");
                    Log.Debug(methodInfo);
                    Log.Debug(@params);

                    // we want to continue testing thus we are swallowing the exception.
                    Log.Error($"Exception: {e}");

                    Log.Debug("----- END EXCEPTION INFORMATION -----");

                    return false;
                }

                var responseStatusCode = response.StatusCode;

                if (IsExpectedResponse(responseStatusCode) && CheckResult(response, @params))
                {
                    Log.Info($"{(int) responseStatusCode} {responseStatusCode}");
                    return true;
                }

                Log.Error($"{(int) responseStatusCode} {responseStatusCode}");
                return false;
            }
        }

        protected abstract MethodInfo GetMethodInfo();

        protected abstract object[] GetParams(MethodInfo methodInfo);

        private protected virtual bool CheckResult(SdkOperationResponse response, object[] requestParameters)
        {
            return true;
        }

        private object GetApiInstance()
        {
            // Capture once: in old-generator (legacy) mode this getter is side-effecting - it sets the
            // bearer token on the Configuration each call - so it must not be invoked twice.
            var sdkConfiguration = SdkConfigurationFactory.SdkConfiguration;
            var serviceProvider = sdkConfiguration as IServiceProvider;

            if (serviceProvider == null)
            {
                // Old-generator (Client.Configuration) mode: SdkConfiguration is a Configuration
                // object, not an IServiceProvider. Construct the API directly with the old-generator
                // constructor: new XxxApi(configuration). Going through the DI/manual-construction
                // paths below would pick the parameterless constructor and yield a broken instance
                // (no base path, no bearer token).
                return Activator.CreateInstance(ResourceApi.ApiType, sdkConfiguration);
            }

            // DI (new-generator) mode: serviceProvider is non-null from here on.
            // The SDK registers APIs by their interface (IXxxxApi), not concrete type
            // Find the interface that the concrete type implements
            var apiInterface = ResourceApi.ApiType.GetInterfaces()
                .FirstOrDefault(i => i.Namespace != null && i.Namespace.Contains("Apis.All") && i.Name.StartsWith("I"));

            if (apiInterface != null)
            {
                try
                {
                    var apiInstance = serviceProvider.GetService(apiInterface);
                    if (apiInstance != null)
                    {
                        return apiInstance;
                    }

                    Log.Warn($"Service provider returned null for interface {apiInterface.FullName}");
                }
                catch (Exception ex)
                {
                    Log.Warn($"DI resolution failed for interface {apiInterface.FullName}: {ex.Message}");
                }
            }

            // Try to resolve by concrete type as fallback
            try
            {
                var apiInstance = serviceProvider.GetService(ResourceApi.ApiType);
                if (apiInstance != null)
                {
                    return apiInstance;
                }

                Log.Warn($"Service provider returned null for type {ResourceApi.ApiType.FullName}");
            }
            catch (Exception ex)
            {
                Log.Warn($"DI resolution failed for {ResourceApi.ApiType.FullName}: {ex.Message}");
            }

            // Manual construction: create API with required dependencies
            // Constructor signature: (ILogger, ILoggerFactory, HttpClient, JsonSerializerOptionsProvider, ApiEvents, TokenProvider)
            try
            {
                var constructor = ResourceApi.ApiType.GetConstructors().FirstOrDefault();
                if (constructor != null)
                {
                    var parameters = constructor.GetParameters();
                    var args = new List<object>();

                    foreach (var param in parameters)
                    {
                        // GetService returns null when the dependency is not registered, which is the
                        // same value we would supply for an optional/unresolved parameter.
                        args.Add(serviceProvider.GetService(param.ParameterType));
                    }

                    return constructor.Invoke(args.ToArray());
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Manual API construction failed for {ResourceApi.ApiType.FullName}: {ex.Message}");
            }

            // Last resort fallback
            Log.Debug($"Falling back to Activator.CreateInstance for {ResourceApi.ApiType.FullName}");
            return Activator.CreateInstance(ResourceApi.ApiType, sdkConfiguration);
        }

        protected async Task<object> GetResourceFromUri(Uri resourceUri)
        {
            var api = GetApiInstance();
            var getByIdMethod = ResourceApi.GetExecutionMethod(ResourceApi.GetByIdMethod);
            var id = Path.GetFileName(resourceUri.ToString());

            var @params = new object[] {id}
                .Concat(getByIdMethod.BuildOptionalParameters())
                .ToArray();

            try
            {
                var taskResult = getByIdMethod.Invoke(api, @params);

                if (taskResult is Task task)
                {
                    await task;
                    var raw = task.GetType().GetProperty("Result")?.GetValue(task);
                    return new SdkOperationResponse(raw).Payload;
                }

                return new SdkOperationResponse(taskResult).Payload;
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
