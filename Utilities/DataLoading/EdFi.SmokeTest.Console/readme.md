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
