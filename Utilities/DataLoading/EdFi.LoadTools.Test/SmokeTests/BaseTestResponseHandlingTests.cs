// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.SdkTests;
using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test.SmokeTests
{
    /// <summary>
    ///     End-to-end coverage of the dual-mode response handling: GetAllTest.PerformTest over a fake
    ///     old-generator API (legacy Activator construction, WithHttpInfoAsync companion resolved) and a
    ///     fake new-generator API (DI construction, bare method returning a response object), plus the
    ///     verb CheckResult overrides over both response shapes.
    /// </summary>
    [TestFixture]
    public class BaseTestResponseHandlingTests
    {
        [Test]
        public async Task GetAll_over_old_generator_api_resolves_companion_and_populates_results()
        {
            var resourceApi = SdkCategorizer.BuildResourceApis(typeof(FakeOldGenApi)).Single();

            // Regression guard: the bare GetFakeModelsAsync (Task<List<...>>) would have thrown
            // "List<...> has no StatusCode"; the WithHttpInfoAsync companion must be selected.
            resourceApi.GetExecutionMethod(resourceApi.GetAllMethod)
                .Name.ShouldBe("GetFakeModelsWithHttpInfoAsync");

            var results = new Dictionary<string, List<object>>();
            var factory = LegacyConfigurationFactory();

            var test = new GetAllTest(resourceApi, results, factory);

            (await test.PerformTest()).ShouldBeTrue();
            results.ShouldContainKey(nameof(FakeModel));
            results[nameof(FakeModel)].Count.ShouldBe(1);
        }

        [Test]
        public async Task GetAll_over_new_generator_api_uses_bare_method_and_Ok_payload()
        {
            var resourceApi = SdkCategorizer.BuildResourceApis(typeof(FakeNewGenApi)).Single();
            resourceApi.GetExecutionMethod(resourceApi.GetAllMethod)
                .ShouldBeSameAs(resourceApi.GetAllMethod);

            var results = new Dictionary<string, List<object>>();
            var fakeApi = new FakeNewGenApi();
            var factory = ServiceProviderFactory(fakeApi);

            var test = new GetAllTest(resourceApi, results, factory);

            (await test.PerformTest()).ShouldBeTrue();
            results.ShouldContainKey(nameof(FakeModel));
            results[nameof(FakeModel)].Count.ShouldBe(1);
        }

        [Test]
        public void Post_check_result_records_location_on_201_created()
        {
            var created = new Dictionary<string, Uri>();
            var results = new Dictionary<string, List<object>>();
            var post = new PostTest(
                FakeResourceApi(), results, Array.Empty<IPropertyBuilder>(), created, A.Fake<ISdkConfigurationFactory>());

            using var message = new HttpResponseMessage();
            message.Headers.TryAddWithoutValidation("Location", "http://api/fakemodels/1");
            var response = new SdkOperationResponse(
                new NewGenStub(HttpStatusCode.Created, new FakeModel(), message.Headers));

            InvokeCheckResult(post, response, new object[] { new FakeModel() }).ShouldBeTrue();
            created.ShouldContainKey(nameof(FakeModel));
            created[nameof(FakeModel)].ToString().ShouldBe("http://api/fakemodels/1");
        }

        [Test]
        public void Post_check_result_fails_when_not_created()
        {
            var post = new PostTest(
                FakeResourceApi(), new Dictionary<string, List<object>>(), Array.Empty<IPropertyBuilder>(),
                new Dictionary<string, Uri>(), A.Fake<ISdkConfigurationFactory>());

            var response = new SdkOperationResponse(new StubApiResponse<FakeModel>(400, new FakeModel()));

            InvokeCheckResult(post, response, new object[] { new FakeModel() }).ShouldBeFalse();
        }

        [Test]
        public void Post_check_result_fails_when_location_missing()
        {
            var post = new PostTest(
                FakeResourceApi(), new Dictionary<string, List<object>>(), Array.Empty<IPropertyBuilder>(),
                new Dictionary<string, Uri>(), A.Fake<ISdkConfigurationFactory>());

            using var message = new HttpResponseMessage();
            var response = new SdkOperationResponse(
                new NewGenStub(HttpStatusCode.Created, new FakeModel(), message.Headers));

            InvokeCheckResult(post, response, new object[] { new FakeModel() }).ShouldBeFalse();
        }

        [Test]
        public void Put_check_result_succeeds_only_on_204_no_content()
        {
            var put = new PutTest(
                FakeResourceApi(), new Dictionary<string, List<object>>(), new Dictionary<string, Uri>(),
                A.Fake<ISdkConfigurationFactory>());

            InvokeCheckResult(put, new SdkOperationResponse(new StubApiResponse<object>(204, null)), EmptyParams)
                .ShouldBeTrue();
            InvokeCheckResult(put, new SdkOperationResponse(new StubApiResponse<object>(200, null)), EmptyParams)
                .ShouldBeFalse();
        }

        [Test]
        public void Delete_check_result_succeeds_only_on_204_no_content()
        {
            var delete = new DeleteTest(
                FakeResourceApi(), new Dictionary<string, List<object>>(), new Dictionary<string, Uri>(),
                A.Fake<ISdkConfigurationFactory>());

            InvokeCheckResult(delete, new SdkOperationResponse(new StubApiResponse<object>(204, null)), EmptyParams)
                .ShouldBeTrue();
            InvokeCheckResult(delete, new SdkOperationResponse(new StubApiResponse<object>(200, null)), EmptyParams)
                .ShouldBeFalse();
        }

        [Test]
        public void GetAll_check_result_fails_when_no_data_but_data_required()
        {
            var results = new Dictionary<string, List<object>>();
            var getAll = new GetAllTest(FakeResourceApi(), results, A.Fake<ISdkConfigurationFactory>(), failIfNoData: true);

            var response = new SdkOperationResponse(new StubApiResponse<List<FakeModel>>(200, new List<FakeModel>()));

            InvokeCheckResult(getAll, response, EmptyParams).ShouldBeFalse();
        }

        // ----- helpers -----

        private static readonly object[] EmptyParams = Array.Empty<object>();

        private static IResourceApi FakeResourceApi()
        {
            var resourceApi = A.Fake<IResourceApi>();
            A.CallTo(() => resourceApi.ModelType).Returns(typeof(FakeModel));
            return resourceApi;
        }

        private static ISdkConfigurationFactory LegacyConfigurationFactory()
        {
            var factory = A.Fake<ISdkConfigurationFactory>();
            // Not an IServiceProvider => legacy mode => Activator.CreateInstance(ApiType, config).
            A.CallTo(() => factory.SdkConfiguration).Returns(new FakeOldGenConfig());
            return factory;
        }

        private static ISdkConfigurationFactory ServiceProviderFactory(object apiInstance)
        {
            var services = new ServiceCollection();
            services.AddSingleton(apiInstance.GetType(), apiInstance);
            var provider = services.BuildServiceProvider();

            var factory = A.Fake<ISdkConfigurationFactory>();
            A.CallTo(() => factory.SdkConfiguration).Returns(provider);
            return factory;
        }

        private static bool InvokeCheckResult(BaseTest test, SdkOperationResponse response, object[] requestParameters)
        {
            var method = test.GetType().GetMethod("CheckResult", BindingFlags.Instance | BindingFlags.NonPublic);
            method.ShouldNotBeNull();

            try
            {
                return (bool) method.Invoke(test, new object[] { response, requestParameters });
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                throw ex.InnerException;
            }
        }

        // ----- fake SDK shapes (public so cross-assembly Activator/DI construction works) -----

        public sealed class FakeModel { }

        public sealed class FakeOldGenConfig { }

        // New-generator-style response object: HttpStatusCode StatusCode, Ok(), Headers, RawContent.
        public sealed class NewGenStub
        {
            private readonly object _payload;

            public NewGenStub(HttpStatusCode statusCode, object payload, HttpResponseHeaders headers)
            {
                StatusCode = statusCode;
                _payload = payload;
                Headers = headers;
            }

            public HttpStatusCode StatusCode { get; }

            public string RawContent => null;

            public HttpResponseHeaders Headers { get; }

            public object Ok() => _payload;
        }

        // Old-generator-style API: constructed from a config (legacy path), exposes bare async methods
        // plus WithHttpInfoAsync companions returning StubApiResponse<T>.
        public sealed class FakeOldGenApi
        {
            public FakeOldGenApi(FakeOldGenConfig config)
            {
                _ = config;
            }

            public Task<List<FakeModel>> GetFakeModelsAsync() =>
                Task.FromResult(new List<FakeModel> { new() });

            public Task<StubApiResponse<List<FakeModel>>> GetFakeModelsWithHttpInfoAsync() =>
                Task.FromResult(new StubApiResponse<List<FakeModel>>(200, new List<FakeModel> { new() }));

            public Task<FakeModel> GetFakeModelsByIdAsync(string id) => Task.FromResult(new FakeModel());

            public Task<StubApiResponse<FakeModel>> GetFakeModelsByIdWithHttpInfoAsync(string id) =>
                Task.FromResult(new StubApiResponse<FakeModel>(200, new FakeModel()));

            public Task<FakeModel> PostFakeModelAsync(FakeModel model) => Task.FromResult(model);

            public Task<StubApiResponse<FakeModel>> PostFakeModelWithHttpInfoAsync(FakeModel model) =>
                Task.FromResult(new StubApiResponse<FakeModel>(201, model));

            public Task<FakeModel> PutFakeModelAsync(string id, FakeModel model) => Task.FromResult(model);

            public Task<StubApiResponse<FakeModel>> PutFakeModelWithHttpInfoAsync(string id, FakeModel model) =>
                Task.FromResult(new StubApiResponse<FakeModel>(204, model));

            public Task DeleteFakeModelByIdAsync(string id) => Task.CompletedTask;

            public Task<StubApiResponse<object>> DeleteFakeModelByIdWithHttpInfoAsync(string id) =>
                Task.FromResult(new StubApiResponse<object>(204, null));
        }

        // New-generator-style API: bare async methods returning response objects; no companions.
        public sealed class FakeNewGenApi
        {
            public Task<NewGenStub> GetFakeModelsAsync() =>
                Task.FromResult(new NewGenStub(HttpStatusCode.OK, new List<FakeModel> { new() }, null));

            public Task<NewGenStub> GetFakeModelsByIdAsync(string id) =>
                Task.FromResult(new NewGenStub(HttpStatusCode.OK, new FakeModel(), null));

            public Task<NewGenStub> PostFakeModelAsync(FakeModel model) =>
                Task.FromResult(new NewGenStub(HttpStatusCode.Created, model, null));

            public Task<NewGenStub> PutFakeModelAsync(string id, FakeModel model) =>
                Task.FromResult(new NewGenStub(HttpStatusCode.NoContent, model, null));

            public Task<NewGenStub> DeleteFakeModelByIdAsync(string id) =>
                Task.FromResult(new NewGenStub(HttpStatusCode.NoContent, null, null));
        }
    }
}
