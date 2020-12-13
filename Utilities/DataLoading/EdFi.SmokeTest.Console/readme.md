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