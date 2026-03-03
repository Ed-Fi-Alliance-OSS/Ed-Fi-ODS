// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class PostTest : BaseTest
    {
        private readonly Dictionary<string, Uri> _createdDictionary;
        private readonly IEnumerable<IPropertyBuilder> _propertyBuilders;

        public PostTest(IResourceApi resourceApi, Dictionary<string, List<object>> resultsDictionary,
                        IEnumerable<IPropertyBuilder> propertyBuilders, Dictionary<string, Uri> createdDictionary,
                        ISdkConfigurationFactory sdkConfigurationFactory)
            : base(resourceApi, resultsDictionary, sdkConfigurationFactory)
        {
            _propertyBuilders = propertyBuilders;
            _createdDictionary = createdDictionary;
        }

        // POST tests don't rely on existing data
        protected override bool NoDataAvailableForTheResource => false;

        protected override object[] GetParams(MethodInfo methodInfo)
        {
            var model = BuildNewModel(ResourceApi.ModelType);

            return new[] {model}
                .Concat(methodInfo.BuildOptionalParameters())
                .ToArray();
        }

        private object BuildNewModel(Type t, object obj = null)
        {
            // The new SDK models have required constructor parameters, so we use GetUninitializedObject
            // which creates an instance without calling any constructor
            if (obj == null)
            {
                try
                {
                    // Use RuntimeHelpers.GetUninitializedObject (modern .NET approach)
                    obj = RuntimeHelpers.GetUninitializedObject(t);
                }
                catch
                {
                    // Fallback to Activator for types that don't work with GetUninitializedObject
                    try
                    {
                        obj = Activator.CreateInstance(t, true);
                    }
                    catch
                    {
                        // If all else fails, return null - the test will skip this resource
                        return null;
                    }
                }
            }

            foreach (var propertyInfo in t.GetProperties())
            {
                if (!_propertyBuilders.Any(x => x.BuildProperty(obj, propertyInfo)))
                {
                    // Skip properties we can't instantiate or that are read-only
                    if (propertyInfo.SetMethod == null || propertyInfo.PropertyType.IsValueType || propertyInfo.PropertyType == typeof(string))
                    {
                        continue;
                    }

                    try
                    {
                        var propertyObj = CreateInstanceForTypesWithNoPublicConstructor(propertyInfo);
                        if (propertyObj != null)
                        {
                            propertyInfo.SetValue(obj, BuildNewModel(propertyInfo.PropertyType, propertyObj));
                        }
                    }
                    catch
                    {
                        // Skip properties that fail to build
                        continue;
                    }
                }

                // fill in one object in the list
                var list = propertyInfo.GetValue(obj) as IList;

                if (list == null)
                {
                    continue;
                }

                try
                {
                    var listItemType = list.GetType().GetGenericArguments()[0];
                    var listItem = BuildNewModel(listItemType);
                    if (listItem != null)
                    {
                        list.Add(listItem);
                    }
                }
                catch
                {
                    // Skip list items that fail to build
                    continue;
                }
            }

            dynamic hydratedInstance = obj;

            if (t.Name.Contains(EdFiConstants.EdOrgReference))
            {
                hydratedInstance.EducationOrganizationId = EdFiConstants.TestEdOrgId;
            }

            return hydratedInstance;
        }

        private static object CreateInstanceForTypesWithNoPublicConstructor(PropertyInfo propertyInfo)
        {
            try
            {
                // Try RuntimeHelpers first (works for types with required constructor parameters)
                return RuntimeHelpers.GetUninitializedObject(propertyInfo.PropertyType);
            }
            catch
            {
                // Fallback to original logic for types that need it
                const BindingFlags flags = BindingFlags.NonPublic
                                           | BindingFlags.Public
                                           | BindingFlags.Instance
                                           | BindingFlags.CreateInstance
                                           | BindingFlags.OptionalParamBinding;

                var ctor = propertyInfo.PropertyType.GetConstructor(flags, null, new Type[0], null);

                if (ctor != null)
                {
                    return ctor.Invoke(null);
                }

                // Last resort: try Activator with default value
                try
                {
                    return Activator.CreateInstance(propertyInfo.PropertyType);
                }
                catch
                {
                    return null;
                }
            }
        }

        protected override MethodInfo GetMethodInfo()
        {
            return ResourceApi.PostMethod;
        }

        protected override bool CheckResult(dynamic result, object[] requestParameters)
        {
            if (result.StatusCode != HttpStatusCode.Created)
            {
                Log.Error("Unable to create the resource since a resource with the same key already exists. If the underlying ODS already has data, this might be a randomly-generated key collision.");
                return false;
            }

            // Get Location header using TryGetValues (new SDK approach)
            if (result.Headers.TryGetValues("Location", out System.Collections.Generic.IEnumerable<string> locationValues))
            {
                var locationString = locationValues.FirstOrDefault();
                if (!string.IsNullOrEmpty(locationString))
                {
                    var resourceUri = new Uri(locationString);

                    // Add the POSTed resource to the ResultsDictionary so that it can be referenced by subsequent POSTs
                    ResultsDictionary.Add(ResourceApi.ModelType.Name, new List<object> { requestParameters.First() });
                    _createdDictionary.Add(ResourceApi.ModelType.Name, resourceUri);

                    return true;
                }
            }

            Log.Error("Location header not found in response");
            return false;
        }
    }
}
