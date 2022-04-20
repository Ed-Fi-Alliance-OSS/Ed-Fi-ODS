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
            var code = result.StatusCode;
            var resource = GetResourceFromLocation(location, code);

            if (ResultsDictionary.ContainsKey(ResourceApi.ModelType.Name))
            {
                ResultsDictionary[ResourceApi.ModelType.Name].Add(resource);
            }

            return true;
        }

        private object GetResourceFromLocation(List<string> location, HttpStatusCode statusCode)
        {
            var resourceUri = new Uri(location[0]);

            // NOTE - Depending on the state of the test DB, the payload of the POST request may represent a resource that already exists even though a create is expected.
            // This existing resource could have dependencies that a newly created resource would not have
            // In order to prevent attempting to delete resources that have dependencies, we are only adding the results from a POST
            // that actually result in a new resource being created and no longer adding existing resources to the _createdDictionary
            // This results in skipping DELETE requests that would fail but it also has the side effect of skipping PUT and DELETE requests
            // that would succeed.  At this time the following PUT and DELETE requests are skipped:
            //  Put & Delete[EdFiStudentParentAssociation]
            //  Put & Delete[EdFiStudentEducationOrganizationAssociation]
            //  Put & Delete[EdFiEducationOrganizationInterventionPrescriptionAssociation]
            //  Put & Delete[EdFiStudentGradebookEntry]
            //  Put & Delete[EdFiSurveyQuestionResponse]
            //  Put[EdFiSurveySectionResponse]
            if (statusCode == HttpStatusCode.Created)
            {
                _createdDictionary.Add(ResourceApi.ModelType.Name, resourceUri);
            }

            return GetResourceFromUri(resourceUri);
        }
    }
}
