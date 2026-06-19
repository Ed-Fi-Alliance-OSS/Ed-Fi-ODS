# DMS-1226 — Dual-mode SDK smoke-test response handling

**Ticket:** DMS-1226 (blocks DMS-1210)
**Date:** 2026-06-19
**Branch / worktree:** `DMS-1226` @ `C:\EdFi\Data-Management-Service-DMS-1226`
**Area:** `Utilities/DataLoading/EdFi.LoadTools/SmokeTest/SdkTests/`

## Background / root cause

The net10 / new-generator rewrite (ODS-6781) reworked SDK smoke-test execution to assume
**new-generator** SDK response shapes. `BaseTest` invokes the categorized verb method by
reflection, awaits it, and reads `StatusCode`, `RawContent`, `Ok()`, and a new-generator-style
`Headers` collection off the awaited result.

- **New-generator SDKs** (e.g. `EdFi.Suite3.OdsApi.TestSdk.Standard.6.1.0`) return a response
  object implementing `Client.IApiResponse` + `Client.IOk<T>`:
  `HttpStatusCode StatusCode`, `string RawContent`, `HttpResponseHeaders Headers`
  (with `TryGetValues(name, out IEnumerable<string>)`), and a public `T Ok()` method.
- **Old-generator** stock openapi-generator SDKs return **bare data** from the normal async
  methods: `Task<List<T>>` for `GetXxxAsync()`, `Task<T>` for `GetXxxByIdAsync()`. Those payloads
  have no `StatusCode` / `Headers` / `Ok()`.

So on old-generator SDKs the smoke sweep fails with runtime binder errors such as
`'System.Collections.Generic.List<...>' does not contain a definition for 'StatusCode'`.

DMS-1220 already made `BaseTest.GetApiInstance()` dual-mode (old-generator `Client.Configuration`
vs new-generator `IServiceProvider`), but **response handling and method selection were not**.
The old-generator status/headers/data are only available through the `*WithHttpInfoAsync`
companion methods (returning `Task<ApiResponse<T>>`), which `SdkCategorizer` currently excludes.

## Scope

In scope (confined to LoadTools SDK smoke-test execution):

1. **Method selection** — resolve, per resource verb, the old-generator `*WithHttpInfoAsync`
   companion when present so an `ApiResponse<T>` (carrying status/headers/data) is always returned;
   keep the bare async method for new-generator SDKs.
2. **Response handling** — a single shape-agnostic, reflection-based response abstraction that
   normalizes status code, payload, raw content, and the `Location` header across both families.
3. Update the verb test classes and `GetResourceFromUri` to consume that abstraction instead of
   `dynamic` member access.
4. Tests covering both response families with explicit stubs, including a regression for the
   original `List<T> has no StatusCode` shape.

## Non-goals

- No change to DMS API behavior, persistence, migrations, authorization, the OpenAPI contract, or
  backend behavior.
- No change to the non-SDK API smoke tests (`SmokeTest/ApiTests/`, which use a separate
  `GetBaseTest` hierarchy), the property builders, dependency sorting, or the Console wiring.
- No change to DMS-1220's `GetApiInstance()` dual-mode behavior or to the existing homonym/resource
  grouping logic in `SdkCategorizer.BuildResourceApis()`.
- No broad "contains `WithHttpInfo`" method matching, and no targeting of synchronous `WithHttpInfo`
  or `OrDefaultAsync` variants.

## Affected files

Production (`EdFi.LoadTools/SmokeTest/SdkTests/` unless noted):

| File | Change |
|------|--------|
| `SdkOperationResponse.cs` | **New.** Reflection-based response adapter. |
| `SmokeTest/Interfaces.cs` | Add `MethodInfo GetExecutionMethod(MethodInfo canonicalMethod)` to `IResourceApi`. |
| `SdkCategorizer.cs` | `ResourceApi`: implement `GetExecutionMethod` + companion resolution. Grouping unchanged. |
| `BaseTest.cs` | `PerformTest` resolves the execution method, builds the adapter, normalizes status, passes the adapter to `CheckResult`; `GetResourceFromUri` uses the execution GET-by-id method + adapter payload; `CheckResult` signature changes. |
| `GetAllTest.cs` | `CheckResult` reads `response.Payload`. |
| `PostTest.cs` | `CheckResult` reads `response.StatusCode` / `response.TryGetHeader("Location", …)`. |
| `PutTest.cs` / `DeleteTest.cs` | `CheckResult` reads `response.StatusCode`. |

`GetByIdTest.cs`, `GetByExampleTest.cs`, `GetAllSkipLimitTest.cs` need **no change**: they do not
override `CheckResult`, their `GetMethodInfo()` keeps returning the canonical method, and `BaseTest`
resolves the execution method centrally.

Tests (`EdFi.LoadTools.Test/SmokeTests/`):

| File | Change |
|------|--------|
| `SdkOperationResponseTests.cs` | **New.** Adapter unit tests over both response shapes + bare payload. |
| `BaseTestResponseHandlingTests.cs` | **New.** `PerformTest`/verb `CheckResult` over fake old- and new-generator APIs, incl. the regression. |
| `SdkCategorizerTestStubs.cs` | Add an old-generator-style stub API (bare + `WithHttpInfoAsync` companions) and a stub `ApiResponse<T>`. |
| `SdkCategorizerTests.cs` | Add `GetExecutionMethod` resolution / fallback / strictness tests. |

## Design

### Part 1 — Method selection (`ResourceApi`)

Ownership boundary: `SdkCategorizer`/`ResourceApi` owns *which `MethodInfo` to invoke*; `BaseTest`
owns *invoke → await → normalize*; verb classes own *verb-specific validation*. No reflection-based
name matching is spread across the verb classes.

- **Grouping is unchanged.** `BuildResourceApis()` still anchors resource groups on the normal CRUD
  method names and still excludes `WithHttpInfo` (and `OrDefault`) candidates. This preserves
  DMS-1220 homonym/resource grouping and prevents normal vs companion methods from colliding as
  duplicate verbs. The canonical `GetAllMethod` / `GetByIdMethod` / `PostMethod` / `PutMethod` /
  `DeleteMethod` properties keep their current meaning (resource identity, parameter inspection).
- **New companion resolver.** `IResourceApi` gains:

  ```csharp
  // Returns the method to actually invoke for a canonical verb method: the old-generator
  // WithHttpInfoAsync companion when one exists on this API type, otherwise the canonical method.
  MethodInfo GetExecutionMethod(MethodInfo canonicalMethod);
  ```

  `ResourceApi` precomputes a canonical→companion map in its constructor (for the five verb methods)
  and `GetExecutionMethod` returns the companion or falls back to the canonical method
  (so new-generator SDKs are unaffected).

- **Strict companion match.** Let `<stem>` be the canonical method name with only the terminal
  `Async` removed (the homonym token is preserved, e.g. `GetSchools_0`). The companion is resolved on
  the **same API type** in this strict candidate order:
  1. `<stem>WithHttpInfoAsync`
  2. `<stem>AsyncWithHttpInfo`
  3. fall back to the canonical method

  A candidate must be async (`Task`-returning), **not** an `OrDefault` variant, and have a
  positional parameter-type sequence compatible with the canonical method. If both `(1)` and `(2)`
  exist, prefer `WithHttpInfoAsync`. No broad `Contains("WithHttpInfo")` matching; synchronous
  `WithHttpInfo` is **not** targeted in this pass (the ticket and openapi-generator templates point
  to an async companion; supporting the sync form would need more careful parameter handling and
  would only be added if a required target package proves to lack any async companion).

Examples: `GetSchoolsAsync → GetSchoolsWithHttpInfoAsync` (or `GetSchoolsAsyncWithHttpInfo`),
`PostSchoolAsync → PostSchoolWithHttpInfoAsync`,
`DeleteSchoolByIdAsync → DeleteSchoolByIdWithHttpInfoAsync`,
`GetSchools_0Async → GetSchools_0WithHttpInfoAsync` (or `GetSchools_0AsyncWithHttpInfo`).

### Part 2 — Response abstraction (`SdkOperationResponse`)

A new internal type in `SmokeTest/SdkTests`, constructed from the raw awaited result, using
**reflection (not `dynamic`)** so missing members are controlled cases rather than binder crashes.

```csharp
internal sealed class SdkOperationResponse
{
    public SdkOperationResponse(object rawResult);

    public HttpStatusCode StatusCode { get; }          // normalized; see rules
    public bool HasStatusCode { get; }                 // false for a bare payload
    public object Payload { get; }                      // Ok() or Data or the bare result
    public string RawContent { get; }                   // null when absent
    public bool TryGetHeader(string name, out IEnumerable<string> values);
    public object RawResult { get; }                    // diagnostics only
}
```

Extraction rules:

1. **Status code** — read a `StatusCode` property; accept both `HttpStatusCode` and `int`
   (and other integer-convertibles), convert once to `HttpStatusCode`. If the property is absent
   (bare payload), `HasStatusCode` is `false` and `StatusCode` defaults to `200 OK`. This is the
   GET-read fallback: it never synthesizes `201`/`204`, so POST/PUT/DELETE — which require those
   exact codes — correctly fail when status is unavailable. (With companion resolution this path is
   only reached if no `WithHttpInfoAsync` companion exists.)
2. **Payload** (lazy) — if the raw result has a public zero-arg `Ok()` method, call it
   (new-generator); else if it has a `Data` property, use it (old-generator `ApiResponse`);
   else return the raw result itself (bare payload). Lazy so `Ok()` is only invoked when a consumer
   asks — and consumers only read `Payload` on success paths.
3. **Raw content** — read a `RawContent` property if present, else `null`.
4. **Headers** (`TryGetHeader`, case-insensitive, used for `Location`) — read a `Headers` property,
   then:
   - if it exposes `TryGetValues(string, out IEnumerable<string>)` (new-generator
     `HttpResponseHeaders`), use it;
   - otherwise enumerate it as key/value pairs via reflection (covers old-generator
     `Multimap<string, string>`, `IDictionary<string, string>`,
     `IDictionary<string, IEnumerable<string>>`, and list/multimap values), matching the name
     `OrdinalIgnoreCase` and coercing the value to `IEnumerable<string>` (a `string` value becomes a
     single-item sequence; an enumerable value is materialized to strings).

### Part 3 — `BaseTest` / verb wiring

- `PerformTest()`:
  ```csharp
  var canonicalMethod = GetMethodInfo();                 // verb class returns the canonical method
  // …existing null / ShouldPerformTest / NoData / @params guards…
  var methodInfo = ResourceApi.GetExecutionMethod(canonicalMethod);   // delegate resolution to ResourceApi
  var @params    = GetParams(methodInfo);                 // params built for the invoked method
  var api        = GetApiInstance();                      // DMS-1220 behavior unchanged
  var raw        = await invoke-and-unwrap(methodInfo, api, @params);
  var response   = new SdkOperationResponse(raw);
  // preserve debug logging: response.StatusCode, response.RawContent, 404 body
  if (IsExpectedResponse(response.StatusCode) && CheckResult(response, @params)) return true;
  return false;
  ```
  Building `@params` from the **execution** method keeps parameter arity correct even if a companion
  differs; the non-`Task` branch is retained (an `ApiResponse<T>` returned synchronously still works
  through the same adapter).
- `GetResourceFromUri()` invokes `ResourceApi.GetExecutionMethod(ResourceApi.GetByIdMethod)` and
  returns `new SdkOperationResponse(raw).Payload`.
- `CheckResult` signature changes from `CheckResult(dynamic result, …)` to
  `CheckResult(SdkOperationResponse response, …)`.
- Verb `CheckResult` bodies:
  - `GetAllTest`: `var data = response.Payload;` populate `ResultsDictionary` (empty list when null);
    keep the `failIfNoData` empty-result check.
  - `PostTest`: `response.StatusCode != HttpStatusCode.Created` → fail;
    `response.TryGetHeader("Location", out var values)` → record URI.
  - `PutTest` / `DeleteTest`: `response.StatusCode == HttpStatusCode.NoContent`.

This affects only the SDK `BaseTest` hierarchy (the seven SDK verb classes + the test-only
`TestableBaseTest`); nothing else consumes `SdkTests.BaseTest.CheckResult`.

## How old- vs new-generator is detected

| Signal | New-generator | Old-generator |
|--------|---------------|---------------|
| Method shape | bare `*Async` returns the response object | `*WithHttpInfoAsync` companion returns `Task<ApiResponse<T>>` |
| Companion presence | none → `GetExecutionMethod` returns canonical | present → resolved & invoked |
| `StatusCode` | `HttpStatusCode` | `int` (or `HttpStatusCode`) → normalized once |
| Payload | `Ok()` | `Data` |
| Headers | `HttpResponseHeaders.TryGetValues` | `Multimap`/dictionary enumeration |

Detection is structural (presence of the companion / member), per API type and per response object —
no runtime config flag is needed, and it composes with the existing `GetApiInstance()` detection.

## Edge cases & risks

- **Companion naming convention.** We accept **both** async suffixes — `…WithHttpInfoAsync`
  (openapi-generator ≥ v5.4.0, preferred) and `…AsyncWithHttpInfo` (the older suffix the pre-net10
  EdFi SDKs used) — to cover whichever the published old-generator ODS/DMS TestSdk ships (neither is
  cached locally, and repository history does not prove the current package suffix). Matching stays
  strict (exact candidate names, async, non-`OrDefault`, compatible parameter sequence); no broad
  matching, no synchronous variant.
- **`Ok()` on non-2xx (new-generator) throws.** `Payload` is lazy and consumers read it only after a
  2xx (`GetAllTest.CheckResult` runs only when `IsExpectedResponse` is true; `GetResourceFromUri`
  runs after a successful POST), preserving existing behavior.
- **Bare-payload fallback synthesizes 200.** Correct for GET reads; POST/PUT/DELETE still fail
  because they require `201`/`204`. `HasStatusCode` exposes the distinction for diagnostics.
- **Parameter arity.** `@params` is built from the execution method; the strict identical-parameter
  match makes this a no-op in practice but is correct if a companion ever differs.
- **No old-generator SDK cached locally.** Both shapes are proven with explicit stubs (consistent
  with the existing version-independent `SdkCategorizerTests`); full four-step sweep validation is
  deferred to CI / the scheduled smoke run.
- **`TreatWarningsAsErrors`** is on for both projects — the change must be warning-clean.

## Test plan

Drafted before implementation (TDD). All stubs are local so tests stay independent of the compiled
TestSdk version.

**`SdkOperationResponseTests` (adapter unit tests)**
- New-generator stub (`HttpStatusCode StatusCode`, `RawContent`, headers with `TryGetValues`,
  `Ok()`): status normalized, `Payload` via `Ok()`, `RawContent`, `TryGetHeader("location")`
  case-insensitive.
- Old-generator stub (`int StatusCode`, `Data`, multimap/dictionary `Headers`, optional
  `RawContent`): status normalized from `int`, `Payload` via `Data`, `TryGetHeader` over
  dictionary/multimap, missing `RawContent` → `null`.
- Header value coercion variants: `string`, `IEnumerable<string>`, `List<string>`.
- **Regression:** a bare `List<T>` raw result → `HasStatusCode == false`, `StatusCode == OK`,
  `Payload` is the list (the shape that previously threw `List<T> has no StatusCode`).

**`SdkCategorizerTests` / stubs (method selection)**
- Old-generator stub API (bare async **and** `WithHttpInfoAsync` companions): `GetExecutionMethod`
  returns the companion for every verb, and grouping still yields one resource per model with no
  duplicate-verb throw (proves `WithHttpInfo` support does not reintroduce duplicates).
- New-generator-style stub (bare only): `GetExecutionMethod` returns the canonical method.
- Companion with a mismatched parameter shape is **not** matched (falls back to canonical).
- Existing homonym/grouping tests continue to pass unchanged.

**`BaseTestResponseHandlingTests` (`PerformTest` / `CheckResult`)**
- GET-all against a fake **old-generator** API (legacy config path, companion resolved):
  `PerformTest` returns true and `ResultsDictionary` is populated from `ApiResponse.Data`.
  Asserts `GetExecutionMethod(GetAllMethod)` resolved the `WithHttpInfoAsync` companion — the
  end-to-end regression that previously failed.
- GET-all against a fake **new-generator** API: `PerformTest` returns true, payload via `Ok()`.
- `PostTest.CheckResult` (invoked via reflection, as `BaseTestGetApiInstanceTests` does for private
  members): `201` + `Location` → true and recorded; non-`201` → false; `201` without `Location` →
  false. Across both response shapes.
- `PutTest` / `DeleteTest.CheckResult`: `204` → true; anything else → false. Both shapes.
- `GetAllTest.CheckResult` with `failIfNoData` and an empty payload → false.

**Verification commands**
- `dotnet test Utilities/DataLoading/LoadTools.sln` (and targeted
  `Utilities/DataLoading/EdFi.LoadTools.Test`).
- Formatting/warnings clean (`TreatWarningsAsErrors`).
- Full local four-step sweep is impractical (no old-generator SDK locally); CI / the scheduled smoke
  run should validate all four SDK steps: NonDestructive DMS SDK, Destructive DMS SDK,
  NonDestructive ODS SDK, Destructive ODS SDK.

## Resolved decisions

1. **Companion suffix** — accept both async forms, candidate order `…WithHttpInfoAsync` then
   `…AsyncWithHttpInfo`, then fall back to the canonical method (strict; no broad/sync matching).
2. **`SdkOperationResponse` visibility** — `internal`; `EdFi.LoadTools` already declares
   `InternalsVisibleTo Include="EdFi.LoadTools.Test"` (the mechanism the existing categorizer tests
   use for `internal SdkCategorizer.BuildResourceApis`).
3. **Commit granularity** — (a) adapter + adapter tests, (b) resolver + categorizer tests,
   (c) `BaseTest`/verb wiring + integration-style tests; approval requested after each.
