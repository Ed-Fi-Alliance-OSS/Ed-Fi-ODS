# DMS-1226 Dual-mode SDK smoke-test response handling — Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Make `EdFi.LoadTools` SDK smoke tests work against both old-generator (bare-data) and new-generator (response-object) Ed-Fi SDKs.

**Architecture:** (1) `ResourceApi` resolves each verb's `*WithHttpInfoAsync` companion in old-generator mode so an `ApiResponse<T>` carrying status/headers/data is always returned; (2) a reflection-based `SdkOperationResponse` adapter normalizes status, payload, raw content, and the `Location` header across both response families; (3) `BaseTest` invokes the resolved method, builds the adapter, and hands it to verb `CheckResult` overrides.

**Tech Stack:** C# / .NET 10, NUnit, Shouldly, FakeItEasy.

**Spec:** `docs/superpowers/specs/2026-06-19-dms-1226-sdk-smoke-dual-mode-response-design.md`

## Global Constraints

- **License header** — every new `.cs` file starts with the 4-line SPDX header:
  ```csharp
  // SPDX-License-Identifier: Apache-2.0
  // Licensed to the Ed-Fi Alliance under one or more agreements.
  // The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
  // See the LICENSE and NOTICES files in the project root for more information.
  ```
- **`TreatWarningsAsErrors` is on** for `EdFi.LoadTools` and `EdFi.LoadTools.Test` — the build must be warning-clean (no unused usings, no unreferenced fields).
- **Target framework:** `net10.0`.
- **Do not** change DMS API behavior, persistence, migrations, authorization, the OpenAPI contract, the Console wiring, the non-SDK `ApiTests`/`CommonTests` hierarchies, `GetApiInstance()`'s DMS-1220 behavior, or `SdkCategorizer` resource grouping.
- **Logging:** keep the existing log statements as-is; do not add new logging of external/server-controlled data (CodeQL log-injection rule).
- **All paths are relative to** the worktree root `C:\EdFi\Data-Management-Service-DMS-1226`.
- **Commit only when a task says to** (the user has approved the 3 commits below); ask for approval after each task.
- `SdkOperationResponse` is `internal`; the test project already has access via the existing
  `<InternalsVisibleTo Include="EdFi.LoadTools.Test" />` in `EdFi.LoadTools.csproj`.
- Run tests with: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj`
  (filter individual fixtures with `--filter`).

---

## Task 1: `SdkOperationResponse` adapter + adapter tests

**Files:**
- Create: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/SdkOperationResponse.cs`
- Create (Test): `Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/SdkOperationResponseTests.cs`

**Interfaces:**
- Consumes: nothing.
- Produces:
  ```csharp
  internal sealed class SdkOperationResponse
  {
      public SdkOperationResponse(object rawResult);
      public object RawResult { get; }
      public bool HasStatusCode { get; }
      public HttpStatusCode StatusCode { get; }                 // int-or-enum normalized; OK when absent
      public object Payload { get; }                            // Ok() | Data | raw
      public string RawContent { get; }                         // null when absent
      public bool TryGetHeader(string name, out IEnumerable<string> values);  // case-insensitive
  }
  ```

- [ ] **Step 1: Write the failing adapter tests**

Create `Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/SdkOperationResponseTests.cs`:

```csharp
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using EdFi.LoadTools.SmokeTest.SdkTests;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test.SmokeTests
{
    /// <summary>
    ///     Exercises <see cref="SdkOperationResponse" /> over both SDK response families using local
    ///     stub shapes: a new-generator object (HttpStatusCode StatusCode, RawContent,
    ///     HttpResponseHeaders Headers, public Ok()) and an old-generator ApiResponse (int StatusCode,
    ///     Data, dictionary/multimap Headers, optional RawContent), plus a bare payload.
    /// </summary>
    [TestFixture]
    public class SdkOperationResponseTests
    {
        [Test]
        public void New_generator_response_normalizes_status_payload_rawcontent_and_location()
        {
            var payload = new List<string> { "a", "b" };
            using var message = new HttpResponseMessage();
            message.Headers.TryAddWithoutValidation("Location", "http://api/schools/123");

            var raw = new NewGenResponseStub
            {
                StatusCode = HttpStatusCode.Created,
                RawContent = "{}",
                Headers = message.Headers,
                PayloadValue = payload
            };

            var response = new SdkOperationResponse(raw);

            response.HasStatusCode.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.RawContent.ShouldBe("{}");
            response.Payload.ShouldBeSameAs(payload);
            response.TryGetHeader("location", out var values).ShouldBeTrue(); // case-insensitive
            values.ShouldBe(new[] { "http://api/schools/123" });
        }

        [Test]
        public void Old_generator_response_normalizes_int_status_data_and_multimap_location()
        {
            var payload = new List<string> { "x" };
            var headers = new Dictionary<string, IList<string>>
            {
                ["Location"] = new List<string> { "http://api/schools/9" }
            };

            var raw = new OldGenListHeaderStub
            {
                StatusCode = 201,
                Data = payload,
                Headers = headers
            };

            var response = new SdkOperationResponse(raw);

            response.HasStatusCode.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.RawContent.ShouldBeNull();
            response.Payload.ShouldBeSameAs(payload);
            response.TryGetHeader("LOCATION", out var values).ShouldBeTrue();
            values.ShouldBe(new[] { "http://api/schools/9" });
        }

        [Test]
        public void Old_generator_string_dictionary_headers_are_supported()
        {
            var raw = new OldGenStringHeaderStub
            {
                StatusCode = 200,
                Data = new List<string>(),
                Headers = new Dictionary<string, string> { ["Location"] = "http://api/x/1" }
            };

            var response = new SdkOperationResponse(raw);

            response.TryGetHeader("Location", out var values).ShouldBeTrue();
            values.ShouldBe(new[] { "http://api/x/1" });
        }

        [Test]
        public void Missing_location_header_returns_false_and_empty_values()
        {
            var raw = new OldGenListHeaderStub
            {
                StatusCode = 204,
                Data = null,
                Headers = new Dictionary<string, IList<string>>()
            };

            var response = new SdkOperationResponse(raw);

            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            response.TryGetHeader("Location", out var values).ShouldBeFalse();
            values.ShouldBeEmpty();
        }

        [Test]
        public void Bare_list_payload_is_the_shape_that_previously_crashed()
        {
            var bare = new List<string> { "only", "data" };

            // The original code did (HttpStatusCode)((dynamic)result).StatusCode, which threw a
            // RuntimeBinderException ("List<...> does not contain a definition for StatusCode").
            Should.Throw<Exception>(() =>
            {
                dynamic d = bare;
                _ = d.StatusCode;
            });

            // The adapter handles the same shape without throwing.
            var response = new SdkOperationResponse(bare);

            response.HasStatusCode.ShouldBeFalse();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            response.Payload.ShouldBeSameAs(bare);
            response.RawContent.ShouldBeNull();
            response.TryGetHeader("Location", out _).ShouldBeFalse();
        }

        [Test]
        public void Null_raw_result_is_handled_defensively()
        {
            var response = new SdkOperationResponse(null);

            response.HasStatusCode.ShouldBeFalse();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            response.Payload.ShouldBeNull();
            response.RawContent.ShouldBeNull();
            response.TryGetHeader("Location", out _).ShouldBeFalse();
        }

        // ----- stub response shapes -----

        private sealed class NewGenResponseStub
        {
            public HttpStatusCode StatusCode { get; set; }
            public string RawContent { get; set; }
            public HttpResponseHeaders Headers { get; set; }
            public object PayloadValue { get; set; }
            public object Ok() => PayloadValue;
        }

        private sealed class OldGenListHeaderStub
        {
            public int StatusCode { get; set; }
            public object Data { get; set; }
            public IDictionary<string, IList<string>> Headers { get; set; }
        }

        private sealed class OldGenStringHeaderStub
        {
            public int StatusCode { get; set; }
            public object Data { get; set; }
            public IDictionary<string, string> Headers { get; set; }
        }
    }
}
```

- [ ] **Step 2: Run the tests to verify they fail to compile**

Run: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj --filter FullyQualifiedName~SdkOperationResponseTests`
Expected: FAIL — build error, `SdkOperationResponse` does not exist.

- [ ] **Step 3: Create the adapter**

Create `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/SdkOperationResponse.cs`:

```csharp
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

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    /// <summary>
    ///     Shape-agnostic view over an SDK operation result. New-generator SDKs return a response
    ///     object (Client.IApiResponse + Client.IOk&lt;T&gt;) exposing HttpStatusCode StatusCode,
    ///     RawContent, HttpResponseHeaders Headers and a public T Ok() method. Old-generator SDKs,
    ///     invoked through their *WithHttpInfoAsync companions, return ApiResponse&lt;T&gt; with an int
    ///     (or HttpStatusCode) StatusCode, a Data property, a Multimap/dictionary Headers and an
    ///     optional RawContent. This type normalizes both via reflection so a missing member is a
    ///     controlled case rather than a runtime binder crash.
    /// </summary>
    internal sealed class SdkOperationResponse
    {
        private const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;

        private readonly object _raw;
        private readonly object _statusCodeValue; // null when the raw result carries no StatusCode

        public SdkOperationResponse(object rawResult)
        {
            _raw = rawResult;
            _statusCodeValue = _raw?.GetType().GetProperty("StatusCode", PublicInstance)?.GetValue(_raw);
        }

        /// <summary>The raw SDK result. Diagnostics only.</summary>
        public object RawResult => _raw;

        /// <summary>True when the raw result actually carried a StatusCode (i.e. it is a response wrapper).</summary>
        public bool HasStatusCode => _statusCodeValue != null;

        /// <summary>
        ///     Status normalized to HttpStatusCode. Accepts HttpStatusCode and int (old-generator).
        ///     Defaults to 200 OK when the raw result has no StatusCode (a bare payload): correct for
        ///     GET reads, while POST/PUT/DELETE - which require 201/204 - still fail because 200 never
        ///     satisfies their checks.
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                switch (_statusCodeValue)
                {
                    case null:
                        return HttpStatusCode.OK;
                    case HttpStatusCode httpStatusCode:
                        return httpStatusCode;
                    default:
                        return (HttpStatusCode) Convert.ToInt32(_statusCodeValue);
                }
            }
        }

        /// <summary>
        ///     The response payload: new-generator Ok(), else old-generator Data, else the raw result
        ///     itself (a bare payload). Computed on access so Ok() is only invoked when a consumer asks.
        /// </summary>
        public object Payload
        {
            get
            {
                if (_raw == null)
                {
                    return null;
                }

                var type = _raw.GetType();

                var okMethod = type.GetMethod("Ok", PublicInstance, null, Type.EmptyTypes, null);
                if (okMethod != null)
                {
                    return okMethod.Invoke(_raw, null);
                }

                var dataProperty = type.GetProperty("Data", PublicInstance);
                if (dataProperty != null)
                {
                    return dataProperty.GetValue(_raw);
                }

                return _raw;
            }
        }

        /// <summary>The raw response body when present (new-generator and some old-generator), else null.</summary>
        public string RawContent =>
            _raw?.GetType().GetProperty("RawContent", PublicInstance)?.GetValue(_raw) as string;

        /// <summary>
        ///     Case-insensitive header lookup that works across new-generator HttpResponseHeaders
        ///     (TryGetValues) and old-generator Multimap / IDictionary header collections.
        /// </summary>
        public bool TryGetHeader(string name, out IEnumerable<string> values)
        {
            values = Enumerable.Empty<string>();

            var headers = _raw?.GetType().GetProperty("Headers", PublicInstance)?.GetValue(_raw);
            if (headers == null)
            {
                return false;
            }

            // New-generator HttpResponseHeaders (and anything else exposing the same method).
            var tryGetValues = headers.GetType().GetMethod(
                "TryGetValues",
                PublicInstance,
                null,
                new[] { typeof(string), typeof(IEnumerable<string>).MakeByRefType() },
                null);

            if (tryGetValues != null)
            {
                var args = new object[] { name, null };
                if (tryGetValues.Invoke(headers, args) is true && args[1] is IEnumerable<string> headerValues)
                {
                    values = headerValues.ToList();
                    return true;
                }

                return false;
            }

            // Old-generator dictionary/multimap headers: enumerate key/value pairs reflectively.
            if (headers is IEnumerable entries)
            {
                foreach (var entry in entries)
                {
                    if (entry == null)
                    {
                        continue;
                    }

                    var entryType = entry.GetType();
                    if (entryType.GetProperty("Key")?.GetValue(entry) is not string key
                        || !string.Equals(key, name, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    values = CoerceToStrings(entryType.GetProperty("Value")?.GetValue(entry));
                    return true;
                }
            }

            return false;
        }

        private static IEnumerable<string> CoerceToStrings(object value)
        {
            switch (value)
            {
                case null:
                    return Enumerable.Empty<string>();
                case string single:
                    return new[] { single };
                case IEnumerable<string> many:
                    return many.ToList();
                case IEnumerable enumerable:
                    return enumerable.Cast<object>().Select(o => o?.ToString()).ToList();
                default:
                    return new[] { value.ToString() };
            }
        }
    }
}
```

- [ ] **Step 4: Run the tests to verify they pass**

Run: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj --filter FullyQualifiedName~SdkOperationResponseTests`
Expected: PASS (6 tests).

- [ ] **Step 5: Commit**

```bash
git add Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/SdkOperationResponse.cs \
        Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/SdkOperationResponseTests.cs
git commit -m "[DMS-1226] Add shape-agnostic SdkOperationResponse adapter for SDK smoke tests"
```

**STOP — request approval before Task 2.**

---

## Task 2: `GetExecutionMethod` companion resolver + categorizer tests

**Files:**
- Modify: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/Interfaces.cs` (add `GetExecutionMethod` to `IResourceApi`)
- Modify: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/SdkCategorizer.cs` (`ResourceApi` implements it)
- Modify (Test): `Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/SdkCategorizerTests.cs` (new tests + local stubs)

**Interfaces:**
- Consumes: existing `ResourceApi(Type apiType, Type modelType, IEnumerable<MethodInfo> resourceMethods)`, canonical verb properties `GetAllMethod` / `GetByIdMethod` / `PostMethod` / `PutMethod` / `DeleteMethod`, and `static IEnumerable<ResourceApi> SdkCategorizer.BuildResourceApis(Type)`.
- Produces: `MethodInfo IResourceApi.GetExecutionMethod(MethodInfo canonicalMethod)` — returns the
  old-generator `*WithHttpInfoAsync` (preferred) or `*AsyncWithHttpInfo` companion when present on the
  same API type with a matching parameter-type sequence; otherwise the canonical method.

- [ ] **Step 1: Write the failing categorizer tests + stubs**

Append these tests inside the existing `SdkCategorizerTests` class in
`Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/SdkCategorizerTests.cs` (before the closing
`AssertEachVerbResolvesToOneMethod` helper is fine — place them among the other `[Test]` methods):

```csharp
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
```

Then append these local stub types at the bottom of the file, inside
`namespace EdFi.LoadTools.Test.SmokeTests` (next to `IrregularPluralMultiResourceStub`). They live in
this plain namespace deliberately so the whole-assembly categorizer scan (which keys on
`Apis.All` / `Models.All`) never picks them up; the tests feed them to `BuildResourceApis` directly.

```csharp
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
```

Note: `SdkCategorizerTests.cs` already has `using System.Threading.Tasks;`, `using System.Linq;`,
`using EdFi.LoadTools.SmokeTest;`, and `using EdFi.LoadTools.Test.SmokeTests.SdkStubs.Apis.All;`
(for `StubStudentsApi`). No new `using` is required.

- [ ] **Step 2: Run the tests to verify they fail to compile**

Run: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj --filter FullyQualifiedName~SdkCategorizerTests`
Expected: FAIL — build error, `IResourceApi` has no `GetExecutionMethod`.

- [ ] **Step 3: Add `GetExecutionMethod` to the `IResourceApi` interface**

In `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/Interfaces.cs`, add the member to `IResourceApi`
(after `DeleteMethod`):

```csharp
        MethodInfo DeleteMethod { get; }

        // Returns the method to actually invoke for a canonical verb method: the old-generator
        // *WithHttpInfoAsync (or *AsyncWithHttpInfo) companion when present on this API type,
        // otherwise the canonical method (new-generator SDKs).
        MethodInfo GetExecutionMethod(MethodInfo canonicalMethod);
```

- [ ] **Step 4: Implement companion resolution in `ResourceApi`**

In `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/SdkCategorizer.cs`:

First add the Tasks namespace to the `using` block at the top of the file (after
`using System.Text.RegularExpressions;`):

```csharp
using System.Text.RegularExpressions;
using System.Threading.Tasks;
```

Then, inside the `ResourceApi` constructor, after the `DeleteMethod = SingleVerb(...)` assignment
(the last statement in the constructor), build the canonical→companion map:

```csharp
            DeleteMethod = SingleVerb(
                methods, apiType, modelType, "DELETE",
                m => m.Name.StartsWith("Delete") && !m.Name.StartsWith("Deletes"));

            _executionMethods = new Dictionary<MethodInfo, MethodInfo>();
            foreach (var canonical in new[] { GetAllMethod, GetByIdMethod, PostMethod, PutMethod, DeleteMethod })
            {
                if (canonical != null)
                {
                    _executionMethods[canonical] = ResolveExecutionMethod(apiType, canonical);
                }
            }
```

Add the backing field next to the other `ResourceApi` members (e.g. just above `public Type ApiType { get; }`):

```csharp
        private readonly Dictionary<MethodInfo, MethodInfo> _executionMethods;

        public Type ApiType { get; }
```

Then add the public method and the two private helpers (place them next to `SingleVerb`, before
`private static string Describe(...)`):

```csharp
        // Returns the WithHttpInfo execution companion resolved at construction, or the canonical
        // method itself when none applies (new-generator SDKs, or an unmapped method).
        public MethodInfo GetExecutionMethod(MethodInfo canonicalMethod)
        {
            if (canonicalMethod == null)
            {
                return null;
            }

            return _executionMethods.TryGetValue(canonicalMethod, out var executionMethod)
                ? executionMethod
                : canonicalMethod;
        }

        // Resolves the old-generator async WithHttpInfo companion for a canonical "<stem>Async"
        // method, or returns the canonical method when none qualifies. Strict: same API type, exact
        // candidate name (WithHttpInfoAsync preferred, then AsyncWithHttpInfo), async (Task-returning),
        // non-OrDefault, and an identical positional parameter-type sequence. No broad matching and no
        // synchronous WithHttpInfo variant.
        private static MethodInfo ResolveExecutionMethod(Type apiType, MethodInfo canonicalMethod)
        {
            if (!canonicalMethod.Name.EndsWith("Async", StringComparison.Ordinal))
            {
                return canonicalMethod;
            }

            var stem = canonicalMethod.Name.Substring(0, canonicalMethod.Name.Length - "Async".Length);
            var canonicalParameterTypes = canonicalMethod.GetParameters().Select(p => p.ParameterType).ToArray();

            foreach (var candidateName in new[] { stem + "WithHttpInfoAsync", stem + "AsyncWithHttpInfo" })
            {
                var companion = apiType.GetMethods()
                    .FirstOrDefault(m =>
                        m.Name == candidateName
                        && !m.Name.Contains("OrDefault")
                        && typeof(Task).IsAssignableFrom(m.ReturnType)
                        && ParameterTypesMatch(m, canonicalParameterTypes));

                if (companion != null)
                {
                    return companion;
                }
            }

            return canonicalMethod;
        }

        private static bool ParameterTypesMatch(MethodInfo candidate, IReadOnlyList<Type> canonicalParameterTypes)
        {
            var candidateParameters = candidate.GetParameters();

            if (candidateParameters.Length != canonicalParameterTypes.Count)
            {
                return false;
            }

            for (var i = 0; i < candidateParameters.Length; i++)
            {
                if (candidateParameters[i].ParameterType != canonicalParameterTypes[i])
                {
                    return false;
                }
            }

            return true;
        }
```

- [ ] **Step 5: Run the tests to verify they pass**

Run: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj --filter FullyQualifiedName~SdkCategorizerTests`
Expected: PASS (all existing categorizer tests + the 7 new tests).

- [ ] **Step 6: Commit**

```bash
git add Utilities/DataLoading/EdFi.LoadTools/SmokeTest/Interfaces.cs \
        Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/SdkCategorizer.cs \
        Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/SdkCategorizerTests.cs
git commit -m "[DMS-1226] Resolve old-generator WithHttpInfoAsync companions in ResourceApi"
```

**STOP — request approval before Task 3.**

---

## Task 3: `BaseTest` / verb wiring + integration-style tests

**Files:**
- Modify: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/BaseTest.cs`
- Modify: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/GetAllTest.cs`
- Modify: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/PostTest.cs`
- Modify: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/PutTest.cs`
- Modify: `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/DeleteTest.cs`
- Create (Test): `Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/BaseTestResponseHandlingTests.cs`

**Interfaces:**
- Consumes: `SdkOperationResponse` (Task 1), `IResourceApi.GetExecutionMethod` (Task 2),
  `SdkCategorizer.BuildResourceApis` (existing), `StubApiResponse<T>`/`OldGenModel` (Task 2 stubs).
- Produces: `protected virtual bool CheckResult(SdkOperationResponse response, object[] requestParameters)`
  as the new `BaseTest` contract consumed only by the SDK verb classes.

- [ ] **Step 1: Write the failing integration tests**

Create `Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/BaseTestResponseHandlingTests.cs`:

```csharp
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
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
```

This file reuses `StubApiResponse<T>`, `OldGenModel` is **not** needed here (the fakes use the
fixture-local `FakeModel`). `StubApiResponse<T>` comes from Task 2's `SdkCategorizerTests.cs`
additions (same test assembly/namespace).

- [ ] **Step 2: Run the tests to verify they fail**

Run: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj --filter FullyQualifiedName~BaseTestResponseHandlingTests`
Expected: FAIL — build error, `CheckResult` still takes `dynamic` (signature mismatch) and the verb
classes have not been rewired.

- [ ] **Step 3: Rewire `BaseTest`**

In `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/BaseTest.cs`, replace the body of
`PerformTest()` (the `using (...) { ... }` block, lines 40-125) with:

```csharp
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
```

In the same file, change the `CheckResult` virtual signature:

```csharp
        protected virtual bool CheckResult(SdkOperationResponse response, object[] requestParameters)
        {
            return true;
        }
```

And replace the body of `GetResourceFromUri` (the `try { ... }` block) so it uses the execution
method and the adapter payload:

```csharp
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
```

- [ ] **Step 4: Rewire `GetAllTest`**

In `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/GetAllTest.cs`, replace the `CheckResult`
override with:

```csharp
        protected override bool CheckResult(SdkOperationResponse response, object[] requestParameters)
        {
            if (response.Payload is System.Collections.IEnumerable data)
            {
                var items = data.Cast<object>().ToList();
                ResultsDictionary[ResourceApi.ModelType.Name] = items;

                if (failIfNoData && items.Count == 0)
                {
                    // Destructive SDK tests create a record for all the entities, so at least one record is expected.
                    Log.Error("The request did not return any records, but at least one was expected.");
                    return false;
                }
            }
            else
            {
                ResultsDictionary[ResourceApi.ModelType.Name] = new List<object>();
            }

            return true;
        }
```

- [ ] **Step 5: Rewire `PostTest`**

In `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/PostTest.cs`, replace the `CheckResult`
override with:

```csharp
        protected override bool CheckResult(SdkOperationResponse response, object[] requestParameters)
        {
            if (response.StatusCode != HttpStatusCode.Created)
            {
                Log.Error("Unable to create the resource since a resource with the same key already exists. If the underlying ODS already has data, this might be a randomly-generated key collision.");
                return false;
            }

            if (response.TryGetHeader("Location", out var locationValues))
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
```

- [ ] **Step 6: Rewire `PutTest` and `DeleteTest`**

In `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/PutTest.cs`, replace the `CheckResult`
override with:

```csharp
        protected override bool CheckResult(SdkOperationResponse response, object[] requestParameters)
            => response.StatusCode == HttpStatusCode.NoContent;
```

In `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/DeleteTest.cs`, replace the `CheckResult`
override with:

```csharp
        protected override bool CheckResult(SdkOperationResponse response, object[] requestParameters)
            => response.StatusCode == HttpStatusCode.NoContent;
```

- [ ] **Step 7: Run the new tests to verify they pass**

Run: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj --filter FullyQualifiedName~BaseTestResponseHandlingTests`
Expected: PASS (8 tests).

- [ ] **Step 8: Run the full LoadTools test project to verify no regressions**

Run: `dotnet test Utilities/DataLoading/EdFi.LoadTools.Test/EdFi.LoadTools.Test.csproj`
Expected: PASS (all tests, including the existing `SdkCategorizerTests`, `BaseTestGetApiInstanceTests`,
`SdkConfigurationFactoryTests`, `APIGetTests`, etc.).

- [ ] **Step 9: Commit**

```bash
git add Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/BaseTest.cs \
        Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/GetAllTest.cs \
        Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/PostTest.cs \
        Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/PutTest.cs \
        Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/DeleteTest.cs \
        Utilities/DataLoading/EdFi.LoadTools.Test/SmokeTests/BaseTestResponseHandlingTests.cs
git commit -m "[DMS-1226] Centralize dual-mode SDK response handling in BaseTest"
```

**STOP — request approval.**

---

## Final verification (after Task 3 approval)

- [ ] Run the whole LoadTools solution test suite if feasible:
  `dotnet test Utilities/DataLoading/LoadTools.sln`
  Expected: PASS.
- [ ] Confirm the build is warning-clean (no `TreatWarningsAsErrors` failures):
  `dotnet build Utilities/DataLoading/LoadTools.sln`
- [ ] Note in the PR/handoff: full four-step SDK sweep (NonDestructive DMS SDK, Destructive DMS SDK,
  NonDestructive ODS SDK, Destructive ODS SDK) must be validated by CI / the scheduled smoke run,
  since no old-generator SDK is available locally.

---

## Self-review notes

- **Spec coverage:** method selection (Task 2), response abstraction (Task 1), `BaseTest`/verb wiring
  + signature change (Task 3), dual suffix + strict matching (Task 2 `ResolveExecutionMethod` + tests),
  both response families + bare-payload regression (Tasks 1 & 3), `GetResourceFromUri` payload (Task 3),
  categorizer "no duplicate verbs" (Task 2 test). All mapped.
- **Type consistency:** `SdkOperationResponse` members (`StatusCode`, `HasStatusCode`, `Payload`,
  `RawContent`, `TryGetHeader`, `RawResult`) are used identically in Tasks 1 and 3;
  `GetExecutionMethod(MethodInfo)` defined in Task 2 is consumed in Task 3; `StubApiResponse<T>` /
  `OldGenModel` defined in Task 2 are reused in Task 3.
- **No placeholders:** every code step contains complete content; commands have expected output.
