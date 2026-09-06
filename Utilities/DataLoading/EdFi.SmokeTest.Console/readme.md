## run the API tests
-k populatedSandbox -s populatedSandboxSecret -b "http://localhost:54746" -t NonDestructiveApi
-k populatedSandbox -s populatedSandboxSecret -b "http://localhost:54746" -y 2016 -t NonDestructiveApi

## run the non-destructive SDK tests
-k populatedSandbox -s populatedSandboxSecret -b "http://localhost:54746"  -t NonDestructiveSdk -l "..\..\..\EdFi.LoadTools.Test\bin\Debug\EdFi.OdsApi.Sdk.dll"

## run the destructive SDK tests
-k populatedSandbox -s populatedSandboxSecret -a "http://localhost:54746" -t DestructiveSdk -l "..\..\..\EdFi.LoadTools.Test\bin\Debug\EdFi.OdsApi.Sdk.dll"

To disable authorization you can run this query on the EdFi_Security database
  update [EdFi_Security].[dbo].[ResourceClaimAuthorizationMetadatas] set AuthorizationStrategy_AuthorizationStrategyId = 1

Deleting the EdFi_Security database will cause it to be rebuilt with the default claims

## SDK data path

For SDK test sets the tool builds the new-generator SDK's `HttpClient.BaseAddress` by injecting a
data-management path segment onto the API server URL. This segment defaults to `/data/v3`, which matches
the standard ODS convention, so ordinary ODS runs need no change. APIs that serve data routes under a
different path can override it &mdash; for example DMS serves data under `/data`.

Behavior of the configured value (`OdsApi:DataPath`):

- Non-empty values are normalized to a leading slash with no trailing slash (`data/v3/` becomes `/data/v3`).
- Empty, whitespace, or `/` injects no segment; the server URL's own path is used (trailing slash trimmed).
- If the server URL already contains the configured data path, it is not appended again (the check is a
  simple substring match, preserved from earlier behavior); the trailing slash is still trimmed.

Override in `appsettings.json`:

```json
{
  "OdsApi": {
    "DataPath": "/data"
  }
}
```

Override with an environment variable (standard .NET double-underscore section separator):

```powershell
$env:OdsApi__DataPath = "/data"
```

Override from the command line:

```powershell
dotnet run --project EdFi.SmokeTest.Console.csproj -- --data-path /data
```

The `-d` short form is equivalent to `--data-path`.

Configuration sources are applied in this order, with later sources overriding earlier ones:
`appsettings.json` < environment variables < command-line arguments < user secrets.

## destructive SDK numeric fallback

When OpenAPI omits `minimum` and `maximum` for a required numeric property, destructive SDK tests generate
integer values from `1` through `OdsApi:DefaultNumericFallbackMax` and then repeat from `1`. Because the values
wrap, they are **not** guaranteed to be unique once more than `DefaultNumericFallbackMax` no-bounds numeric
properties have been generated.

The default of `999` is a heuristic: it keeps generated values inside common decimal precision caps such as
`999.99` for fields like `hoursPerWeek`. It is not derived from the server's actual constraints, so a resource
with a tighter unpublished cap (for example a `decimal(4,2)` field capped at `99.99`) may still reject the
generated value. In that case lower `DefaultNumericFallbackMax` to fit the strictest required field under test.

This generic fallback does **not** preserve identity or EducationOrganization (EdOrg) semantics. EdOrg id safety
is provided by the dedicated EdOrg path in `EducationOrganizationIdBuilder`, not by this fallback:

- EdOrg ids listed in `EducationOrganizationIdOverrides` use their configured values.
- Non-overridden EdOrg ids are generated from a separate range starting at
  `DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart` (`1000`), well above the generic
  `1..DefaultNumericFallbackMax` range, so they do not collide with EdOrg ids that already exist on a populated
  template.

Override the maximum in `appsettings.json`:

```json
{
  "OdsApi": {
    "DefaultNumericFallbackMax": 999
  }
}
```

Override the maximum from the command line:

```powershell
dotnet run --project EdFi.SmokeTest.Console.csproj -- --defaultNumericFallbackMax 999
```
