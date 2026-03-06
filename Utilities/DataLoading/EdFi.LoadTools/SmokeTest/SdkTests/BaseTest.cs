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
                dynamic result = null;

                var methodInfo = GetMethodInfo();

                if (methodInfo == null)
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

                var @params = GetParams(methodInfo);

                if (@params == null)
                {
                    Log.Error($"Unable to find the test data for {ResourceApi.Name}.");
                    return false;
                }

                try
                {
                    var api = GetApiInstance();
                    Log.Debug($"API instance type: {api.GetType().FullName}");

                    var taskResult = methodInfo.Invoke(api, @params);

                    // The SDK methods return Task<IResponse>, so we need to await them
                    if (taskResult is Task task)
                    {
                        await task;
                        // Get the Result property from the completed task
                        var resultProperty = task.GetType().GetProperty("Result");
                        if (resultProperty != null)
                        {
                            result = resultProperty.GetValue(task);
                            Log.Debug($"Response status: {result.StatusCode}, Raw content length: {result.RawContent?.Length ?? 0}");
                            if (result.StatusCode == HttpStatusCode.NotFound && !string.IsNullOrEmpty(result.RawContent))
                            {
                                Log.Debug($"404 Response content: {result.RawContent}");
                            }
                        }
                    }
                    else
                    {
                        result = taskResult;
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

                var responseStatusCode = (HttpStatusCode) result.StatusCode;

                if (IsExpectedResponse(responseStatusCode) && CheckResult(result, @params))
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

        protected virtual bool CheckResult(dynamic result, object[] requestParameters)
        {
            return true;
        }

        private object GetApiInstance()
        {
            var serviceProvider = SdkConfigurationFactory.SdkConfiguration as IServiceProvider;

            if (serviceProvider != null)
            {
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
                        if (serviceProvider != null)
                        {
                            var service = serviceProvider.GetService(param.ParameterType);
                            if (service != null)
                            {
                                args.Add(service);
                            }
                            else
                            {
                                // Add null for optional parameters
                                args.Add(null);
                            }
                        }
                        else
                        {
                            args.Add(null);
                        }
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
            return Activator.CreateInstance(ResourceApi.ApiType, SdkConfigurationFactory.SdkConfiguration);
        }

        protected async Task<object> GetResourceFromUri(Uri resourceUri)
        {
            var api = GetApiInstance();
            var getByIdMethod = ResourceApi.GetByIdMethod;
            var id = Path.GetFileName(resourceUri.ToString());

            var @params = new object[] {id}
                .Concat(getByIdMethod.BuildOptionalParameters())
                .ToArray();

            try
            {
                var taskResult = getByIdMethod.Invoke(api, @params);

                // The SDK methods return Task<IResponse>, so we need to await them
                if (taskResult is Task task)
                {
                    await task;
                    // Get the Result property from the completed task
                    var resultProperty = task.GetType().GetProperty("Result");
                    if (resultProperty != null)
                    {
                        dynamic result = resultProperty.GetValue(task);
                        // The new SDK uses Ok() method instead of Data property
                        return result.Ok();
                    }
                }

                return null;
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
