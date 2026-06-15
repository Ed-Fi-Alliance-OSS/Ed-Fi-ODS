// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest.SdkTests;
using EdFi.OdsApi.Sdk.Apis.All;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test.SmokeTests
{
    /// <summary>
    ///     Verifies that <see cref="SdkCategorizer" /> emits one resource per RESOURCE (model type),
    ///     not one per generated API type. The Homograph extension's homonym resources share the core
    ///     resource's OpenAPI tag, so e.g. ContactsApi carries both Contact and HomographContact.
    /// </summary>
    [TestFixture]
    public class SdkCategorizerTests
    {
        private static SdkCategorizer CreateCategorizer()
        {
            var factory = A.Fake<ISdkLibraryFactory>();
            A.CallTo(() => factory.SdkLibrary).Returns(typeof(ContactsApi).Assembly);
            return new SdkCategorizer(factory);
        }

        [Test]
        public void ContactsApi_with_homonym_yields_one_resource_per_model_type()
        {
            var categorizer = CreateCategorizer();

            var contactResources = categorizer.ResourceApis
                .Where(api => api.ApiType == typeof(ContactsApi))
                .ToList();

            contactResources.Count.ShouldBe(2);
            contactResources.Select(api => api.ModelType.Name)
                .ShouldBe(new[] { "EdFiContact", "HomographContact" }, ignoreOrder: true);
        }

        [Test]
        public void Each_homonym_resource_resolves_exactly_one_method_per_verb()
        {
            var categorizer = CreateCategorizer();

            var contactResources = categorizer.ResourceApis
                .Where(api => api.ApiType == typeof(ContactsApi))
                .ToList();

            contactResources.Count.ShouldBe(2);

            foreach (var api in contactResources)
            {
                // Previously PostMethod threw when an API type exposed more than one POST.
                Should.NotThrow(() => api.PostMethod);

                api.PostMethod.ShouldNotBeNull();
                api.PutMethod.ShouldNotBeNull();
                api.GetAllMethod.ShouldNotBeNull();
                api.GetByIdMethod.ShouldNotBeNull();
                api.DeleteMethod.ShouldNotBeNull();

                // The POST parameter type is the resource's model type.
                api.PostMethod.GetParameters().First().ParameterType.ShouldBe(api.ModelType);

                // The homonym resource's methods carry the generator's "_0" suffix; the core
                // resource's methods do not. This confirms each verb landed in the right group.
                var isHomonym = api.ModelType.Name == "HomographContact";
                api.PostMethod.Name.Contains("_0").ShouldBe(isHomonym);
                api.PutMethod.Name.Contains("_0").ShouldBe(isHomonym);
                api.GetAllMethod.Name.Contains("_0").ShouldBe(isHomonym);
                api.GetByIdMethod.Name.Contains("_0").ShouldBe(isHomonym);
                api.DeleteMethod.Name.Contains("_0").ShouldBe(isHomonym);
            }
        }

        [Test]
        public void Single_resource_api_type_yields_exactly_one_resource()
        {
            var categorizer = CreateCategorizer();

            var academicWeekResources = categorizer.ResourceApis
                .Where(api => api.ApiType == typeof(AcademicWeeksApi))
                .ToList();

            academicWeekResources.Count.ShouldBe(1);
            academicWeekResources[0].PostMethod.ShouldNotBeNull();
            academicWeekResources[0].GetAllMethod.ShouldNotBeNull();
            academicWeekResources[0].GetByIdMethod.ShouldNotBeNull();
        }

        [Test]
        public void ResourceApis_can_be_keyed_by_model_type_name_without_duplicate_keys()
        {
            // Regression for DestructiveMethodsGenerator and ModelDependencySort, which key by
            // ModelType (name). With one resource per API type a homonym surface produced a duplicate
            // (or a categorization throw); the per-resource split makes the model types distinct.
            var categorizer = CreateCategorizer();

            Should.NotThrow(() => categorizer.ResourceApis
                .ToDictionary(api => api.ModelType.Name, StringComparer.OrdinalIgnoreCase));
        }
    }
}
