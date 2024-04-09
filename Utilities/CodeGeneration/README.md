# Ed-Fi-CodeGen
Code generation on the Ed-Fi ODS/API solution.

Code generation includes:
* Entities
* Resources
* NHibernate Mappings
* SQL Resource Claims
* Required Classes for Extensions
* Required Classes for Profiles

## Target Audience
Ed-Fi ODS software developers and implementers.

## Prerequisites
To build the application the following tools are needed:
* .NET 8 SDK (https://dotnet.microsoft.com/download)
* Visual Studio 2022 (https://visualstudio.microsoft.com/downloads/)

## Testing the generated artifacts against the main solution
* Run `initdev` on the main solution first
* run `Rebuild-Solution` or `initdev -NoCodegen`
