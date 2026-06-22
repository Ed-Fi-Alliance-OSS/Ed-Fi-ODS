// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.SdkTests;
using EdFi.LoadTools.Test.SmokeTests.SdkStubs.Apis.All;
using EdFi.LoadTools.Test.SmokeTests.SdkStubs.Models.All;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test.SmokeTests
{
    /// <summary>
    ///     Verifies that <see cref="SdkCategorizer" /> emits one resource per RESOURCE (model type),
    ///     not one per generated API type. The Homograph extension's homonym resources share the core
    ///     resource's OpenAPI tag, so e.g. one ContactsApi carries both Contact and HomographContact.
    ///     These tests use stub SDK shapes (see SdkCategorizerTestStubs) so they are independent of the
    ///     specific TestSdk version the project is compiled against.
    /// </summary>
    [TestFixture]
    public class SdkCategorizerTests
    {
        private static SdkCategorizer CreateCategorizer()
        {
            var factory = A.Fake<ISdkLibraryFactory>();
            A.CallTo(() => factory.SdkLibrary).Returns(typeof(StubContactsApi).Assembly);
            return new SdkCategorizer(factory);
        }

        [Test]
        public void Homonym_api_with_index_suffix_yields_one_resource_per_model_type()
        {
            var resources = CreateCategorizer().ResourceApis
                .Where(api => api.ApiType == typeof(StubContactsApi))
                .ToList();

            resources.Count.ShouldBe(2);
            resources.Select(api => api.ModelType.Name)
                .ShouldBe(new[] { "EdFiContact", "HomographContact" }, ignoreOrder: true);
        }

        [Test]
        public void Homonym_api_with_distinct_stems_yields_one_resource_per_model_type()
        {
            var resources = CreateCategorizer().ResourceApis
                .Where(api => api.ApiType == typeof(StubSchoolsApi))
                .ToList();

            resources.Count.ShouldBe(2);
            resources.Select(api => api.ModelType.Name)
                .ShouldBe(new[] { "EdFiSchool", "HomographSchool" }, ignoreOrder: true);
        }

        [Test]
        public void Index_suffix_homonym_resources_each_resolve_one_method_per_verb()
        {
            var resources = CreateCategorizer().ResourceApis
                .Where(api => api.ApiType == typeof(StubContactsApi))
                .ToList();

            resources.Count.ShouldBe(2);

            foreach (var api in resources)
            {
                AssertEachVerbResolvesToOneMethod(api);

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
        public void Distinct_stem_homonym_resources_each_resolve_one_method_per_verb()
        {
            var resources = CreateCategorizer().ResourceApis
                .Where(api => api.ApiType == typeof(StubSchoolsApi))
                .ToList();

            resources.Count.ShouldBe(2);

            foreach (var api in resources)
            {
                AssertEachVerbResolvesToOneMethod(api);

                // The homonym resource's methods carry the "Homograph" stem; the core resource's do not.
                var isHomonym = api.ModelType.Name == "HomographSchool";
                api.PostMethod.Name.Contains("Homograph").ShouldBe(isHomonym);
                api.PutMethod.Name.Contains("Homograph").ShouldBe(isHomonym);
                api.GetAllMethod.Name.Contains("Homograph").ShouldBe(isHomonym);
                api.GetByIdMethod.Name.Contains("Homograph").ShouldBe(isHomonym);
                api.DeleteMethod.Name.Contains("Homograph").ShouldBe(isHomonym);
            }
        }

        [Test]
        public void Single_resource_api_type_yields_exactly_one_resource()
        {
            var resources = CreateCategorizer().ResourceApis
                .Where(api => api.ApiType == typeof(StubStudentsApi))
                .ToList();

            resources.Count.ShouldBe(1);
            resources[0].ModelType.Name.ShouldBe("EdFiStudent");
            AssertEachVerbResolvesToOneMethod(resources[0]);
        }

        [Test]
        public void Single_resource_api_with_irregular_plural_resolves_every_verb()
        {
            // Person -> People is an irregular plural. As a single-resource API it uses the fast path
            // (every method assigned to the one resource, no name-stem matching), so it is fully
            // supported. This documents that single-resource Person/People remains supported.
            var resources = CreateCategorizer().ResourceApis
                .Where(api => api.ApiType == typeof(StubPeopleApi))
                .ToList();

            resources.Count.ShouldBe(1);
            resources[0].ModelType.Name.ShouldBe("EdFiPerson");
            AssertEachVerbResolvesToOneMethod(resources[0]);
            resources[0].GetAllMethod.Name.ShouldBe("GetPeopleAsync");
        }

        [Test]
        public void Multi_resource_api_with_an_unmatched_candidate_fails_fast_with_diagnostics()
        {
            // A multi-resource (homonym) API whose GET-all pluralizes irregularly: the "People" stem
            // does not start with the "Person" POST stem, so the GET matches no resource group. The
            // categorizer must throw (naming the API type and method) rather than silently dropping it
            // and leaving GetAllMethod null. This is the multi-resource counterpart that "fails fast
            // with diagnostics" instead of silently dropping methods.
            var ex = Should.Throw<InvalidOperationException>(
                () => SdkCategorizer.BuildResourceApis(typeof(IrregularPluralMultiResourceStub)).ToList());

            ex.Message.ShouldContain("could not assign");
            ex.Message.ShouldContain(nameof(IrregularPluralMultiResourceStub));
            ex.Message.ShouldContain("GetPeopleAsync");
        }

        [Test]
        public void Resource_group_with_a_duplicate_verb_fails_fast_with_diagnostics()
        {
            // Two GET-all methods (plus a single POST so the no-POST guard passes) must fail fast at
            // construction with a diagnostic rather than deferring to an opaque SingleOrDefault throw.
            var methods = new[]
            {
                typeof(StubContactsApi).GetMethod(nameof(StubContactsApi.PostContactAsync)),
                typeof(StubContactsApi).GetMethod(nameof(StubContactsApi.GetContactsAsync)),
                typeof(StubContactsApi).GetMethod(nameof(StubContactsApi.GetContacts_0Async)),
            };

            var ex = Should.Throw<InvalidOperationException>(
                () => new ResourceApi(typeof(StubContactsApi), typeof(EdFiContact), methods));

            ex.Message.ShouldContain("GET-all");
            ex.Message.ShouldContain("GetContactsAsync");
            ex.Message.ShouldContain("GetContacts_0Async");
        }

        [Test]
        public void Resource_group_without_a_post_fails_fast_with_diagnostics()
        {
            var methods = new[]
            {
                typeof(StubContactsApi).GetMethod(nameof(StubContactsApi.GetContactsAsync)),
                typeof(StubContactsApi).GetMethod(nameof(StubContactsApi.GetContactsByIdAsync)),
            };

            var ex = Should.Throw<InvalidOperationException>(
                () => new ResourceApi(typeof(StubContactsApi), typeof(EdFiContact), methods));

            ex.Message.ShouldContain("without a POST");
            ex.Message.ShouldContain(nameof(EdFiContact));
        }

        [Test]
        public void Empty_resource_group_fails_fast_with_diagnostics()
        {
            var ex = Should.Throw<InvalidOperationException>(
                () => new ResourceApi(typeof(StubContactsApi), typeof(EdFiContact), Array.Empty<MethodInfo>()));

            ex.Message.ShouldContain("empty method group");
            ex.Message.ShouldContain(nameof(EdFiContact));
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

        [Test]
        public void Old_generator_api_resolves_the_WithHttpInfoAsync_companion_for_every_verb()
        {
            var api = SdkCategorizer.BuildResourceApis(typeof(OldGeneratorStyleApi)).Single();

            api.GetExecutionMethod(api.GetAllMethod).Name.ShouldBe("GetOldGenModelsWithHttpInfoAsync");
            api.GetExecutionMethod(api.GetByIdMethod).Name.ShouldBe("GetOldGenModelsByIdWithHttpInfoAsync");
            api.GetExecutionMethod(api.PostMethod).Name.ShouldBe("PostOldGenModelWithHttpInfoAsync");
            api.GetExecutionMethod(api.PutMethod).Name.ShouldBe("PutOldGenModelWithHttpInfoAsync");
            api.GetExecutionMethod(api.DeleteMethod).Name.ShouldBe("DeleteOldGenModelByIdWithHttpInfoAsync");
        }

        [Test]
        public void Old_generator_grouping_is_unchanged_by_WithHttpInfo_support()
        {
            // The bare CRUD methods still group into exactly one resource with one method per verb;
            // the WithHttpInfo companions are excluded from grouping, so no duplicate-verb throw.
            var resources = Should.NotThrow(
                () => SdkCategorizer.BuildResourceApis(typeof(OldGeneratorStyleApi)).ToList());

            resources.Count.ShouldBe(1);
            resources[0].ModelType.Name.ShouldBe(nameof(OldGenModel));
            resources[0].GetAllMethod.Name.ShouldBe("GetOldGenModelsAsync"); // canonical unchanged
        }

        [Test]
        public void Legacy_AsyncWithHttpInfo_suffix_is_also_resolved()
        {
            var api = SdkCategorizer.BuildResourceApis(typeof(OldGeneratorLegacySuffixApi)).Single();

            api.GetExecutionMethod(api.GetAllMethod).Name.ShouldBe("GetOldGenModelsAsyncWithHttpInfo");
            api.GetExecutionMethod(api.PostMethod).Name.ShouldBe("PostOldGenModelAsyncWithHttpInfo");
        }

        [Test]
        public void WithHttpInfoAsync_is_preferred_over_AsyncWithHttpInfo_when_both_exist()
        {
            var api = SdkCategorizer.BuildResourceApis(typeof(OldGeneratorBothSuffixesApi)).Single();

            api.GetExecutionMethod(api.GetAllMethod).Name.ShouldBe("GetOldGenModelsWithHttpInfoAsync");
        }

        [Test]
        public void New_generator_api_without_companions_resolves_the_canonical_method()
        {
            var api = CreateCategorizer().ResourceApis.First(a => a.ApiType == typeof(StubStudentsApi));

            api.GetExecutionMethod(api.GetAllMethod).ShouldBeSameAs(api.GetAllMethod);
            api.GetExecutionMethod(api.PostMethod).ShouldBeSameAs(api.PostMethod);
        }

        [Test]
        public void Companion_with_an_incompatible_parameter_shape_falls_back_to_canonical()
        {
            var api = SdkCategorizer.BuildResourceApis(typeof(OldGeneratorMismatchedCompanionApi)).Single();

            // The same-named companion takes an extra parameter, so it is rejected and the canonical
            // bare method is used instead.
            api.GetExecutionMethod(api.GetAllMethod).Name.ShouldBe("GetOldGenModelsAsync");
        }

        [Test]
        public void GetExecutionMethod_returns_null_for_a_null_canonical_method()
        {
            var api = SdkCategorizer.BuildResourceApis(typeof(OldGeneratorStyleApi)).Single();

            api.GetExecutionMethod(null).ShouldBeNull();
        }

        private static void AssertEachVerbResolvesToOneMethod(IResourceApi api)
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
        }
    }

    // Local stub shapes for the fail-fast tests. They deliberately live in this namespace - which has
    // no "Apis.All"/"Models.All" segment - so the whole-assembly categorizer scan never picks them up
    // (which would make the other categorizer tests fail fast on them). They are fed to
    // SdkCategorizer.BuildResourceApis directly instead.
    public class IrregularPersonModel { }

    public class IrregularStaffModel { }

    // Multi-resource (Person + Staff) API whose Person GET-all pluralizes irregularly (GetPeopleAsync).
    // "People" does not start with the "Person" POST stem, so it matches no resource group.
    public class IrregularPluralMultiResourceStub
    {
        public Task PostPersonAsync(IrregularPersonModel person) => Task.CompletedTask;

        public Task PostStaffAsync(IrregularStaffModel staff) => Task.CompletedTask;

        public Task GetPeopleAsync() => Task.CompletedTask;
    }

    // ----- old-generator-style stubs for GetExecutionMethod (companion resolution) -----

    public class OldGenModel { }

    // Stand-in for openapi-generator ApiResponse<T>: carries status, data and dictionary headers.
    public class StubApiResponse<T>
    {
        public StubApiResponse(int statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public int StatusCode { get; }

        public T Data { get; }

        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Headers { get; }
            = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IList<string>>();
    }

    // Old-generator API: bare CRUD async methods (categorized) plus WithHttpInfoAsync companions.
    public class OldGeneratorStyleApi
    {
        public Task<System.Collections.Generic.List<OldGenModel>> GetOldGenModelsAsync() =>
            Task.FromResult(new System.Collections.Generic.List<OldGenModel>());

        public Task<OldGenModel> GetOldGenModelsByIdAsync(string id) => Task.FromResult(new OldGenModel());

        public Task<OldGenModel> PostOldGenModelAsync(OldGenModel model) => Task.FromResult(model);

        public Task<OldGenModel> PutOldGenModelAsync(string id, OldGenModel model) => Task.FromResult(model);

        public Task DeleteOldGenModelByIdAsync(string id) => Task.CompletedTask;

        public Task<StubApiResponse<System.Collections.Generic.List<OldGenModel>>> GetOldGenModelsWithHttpInfoAsync() =>
            Task.FromResult(new StubApiResponse<System.Collections.Generic.List<OldGenModel>>(
                200, new System.Collections.Generic.List<OldGenModel>()));

        public Task<StubApiResponse<OldGenModel>> GetOldGenModelsByIdWithHttpInfoAsync(string id) =>
            Task.FromResult(new StubApiResponse<OldGenModel>(200, new OldGenModel()));

        public Task<StubApiResponse<OldGenModel>> PostOldGenModelWithHttpInfoAsync(OldGenModel model) =>
            Task.FromResult(new StubApiResponse<OldGenModel>(201, model));

        public Task<StubApiResponse<OldGenModel>> PutOldGenModelWithHttpInfoAsync(string id, OldGenModel model) =>
            Task.FromResult(new StubApiResponse<OldGenModel>(204, model));

        public Task<StubApiResponse<object>> DeleteOldGenModelByIdWithHttpInfoAsync(string id) =>
            Task.FromResult(new StubApiResponse<object>(204, null));
    }

    // Old-generator API using the older AsyncWithHttpInfo suffix.
    public class OldGeneratorLegacySuffixApi
    {
        public Task<System.Collections.Generic.List<OldGenModel>> GetOldGenModelsAsync() =>
            Task.FromResult(new System.Collections.Generic.List<OldGenModel>());

        public Task<OldGenModel> PostOldGenModelAsync(OldGenModel model) => Task.FromResult(model);

        public Task<StubApiResponse<System.Collections.Generic.List<OldGenModel>>> GetOldGenModelsAsyncWithHttpInfo() =>
            Task.FromResult(new StubApiResponse<System.Collections.Generic.List<OldGenModel>>(
                200, new System.Collections.Generic.List<OldGenModel>()));

        public Task<StubApiResponse<OldGenModel>> PostOldGenModelAsyncWithHttpInfo(OldGenModel model) =>
            Task.FromResult(new StubApiResponse<OldGenModel>(201, model));
    }

    // Old-generator API exposing BOTH suffixes for GET-all (WithHttpInfoAsync must win).
    public class OldGeneratorBothSuffixesApi
    {
        public Task<System.Collections.Generic.List<OldGenModel>> GetOldGenModelsAsync() =>
            Task.FromResult(new System.Collections.Generic.List<OldGenModel>());

        public Task<OldGenModel> PostOldGenModelAsync(OldGenModel model) => Task.FromResult(model);

        public Task<StubApiResponse<System.Collections.Generic.List<OldGenModel>>> GetOldGenModelsWithHttpInfoAsync() =>
            Task.FromResult(new StubApiResponse<System.Collections.Generic.List<OldGenModel>>(
                200, new System.Collections.Generic.List<OldGenModel>()));

        public Task<StubApiResponse<System.Collections.Generic.List<OldGenModel>>> GetOldGenModelsAsyncWithHttpInfo() =>
            Task.FromResult(new StubApiResponse<System.Collections.Generic.List<OldGenModel>>(
                200, new System.Collections.Generic.List<OldGenModel>()));
    }

    // Old-generator API whose same-named companion has an incompatible parameter shape.
    public class OldGeneratorMismatchedCompanionApi
    {
        public Task<System.Collections.Generic.List<OldGenModel>> GetOldGenModelsAsync() =>
            Task.FromResult(new System.Collections.Generic.List<OldGenModel>());

        public Task<OldGenModel> PostOldGenModelAsync(OldGenModel model) => Task.FromResult(model);

        public Task<StubApiResponse<System.Collections.Generic.List<OldGenModel>>> GetOldGenModelsWithHttpInfoAsync(int extra) =>
            Task.FromResult(new StubApiResponse<System.Collections.Generic.List<OldGenModel>>(
                200, new System.Collections.Generic.List<OldGenModel>()));
    }
}
