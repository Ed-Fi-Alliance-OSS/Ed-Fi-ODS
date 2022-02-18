// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        protected override object[] GetParams(MethodInfo methodInfo)
        {
            var model = BuildNewModel(ResourceApi.ModelType);

            return new[]
                   {
                       model
                   };
        }

        private object BuildNewModel(Type t, object obj = null)
        {
            obj = obj ?? Activator.CreateInstance(t, true);

            foreach (var propertyInfo in t.GetProperties())
            {
                if (!_propertyBuilders.Any(x => x.BuildProperty(obj, propertyInfo)))
                {
                    var propertyObj = CreateInstanceForTypesWithNoPublicConstructor(propertyInfo);
                    propertyInfo.SetValue(obj, BuildNewModel(propertyInfo.PropertyType, propertyObj));
                }

                // fill in one object in the list
                var list = propertyInfo.GetValue(obj) as IList;

                if (list == null)
                {
                    continue;
                }

                var listItemType = list.GetType().GetGenericArguments()[0];
                list.Add(BuildNewModel(listItemType));
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
            const BindingFlags flags = BindingFlags.NonPublic
                                       | BindingFlags.Public
                                       | BindingFlags.Instance
                                       | BindingFlags.CreateInstance
                                       | BindingFlags.OptionalParamBinding;

            var ctor = propertyInfo.PropertyType.GetConstructor(flags, null, new Type[0], null);

            var propertyObj = ctor == null
                ? Activator.CreateInstance(
                    propertyInfo.PropertyType, flags, null, new[]
                                                            {
                                                                Type.Missing
                                                            }, null)
                : ctor.Invoke(null);

            return propertyObj;
        }

        protected override MethodInfo GetMethodInfo()
        {
            return ResourceApi.PostMethod;
        }

        protected override bool CheckResult(dynamic result)
        {
            var location = result.Headers["Location"];
            var resource = GetResourceFromLocation(location);

            if (ResultsDictionary.ContainsKey(ResourceApi.ModelType.Name))
            {
                ResultsDictionary[ResourceApi.ModelType.Name].Add(resource);
            }

            return true;
        }

        private object GetResourceFromLocation(List<string>  location)
        {
            var resourceUri = new Uri(location[0]);
            _createdDictionary.Add(ResourceApi.ModelType.Name, resourceUri);
            return GetResourceFromUri(resourceUri);
        }
    }
}
