# Ed-Fi-CodeGen
Code generation on the Ed-Fi ODS/API solution.

Code generation includes:
* Entities
* Resources
* NHibernate Mappings
* SQL Resource Claims
* Required Classes for Bulk Load
* Required Classes for Extensions
* Required Classes for Profiles

## Target Audience
Ed-Fi ODS software developers and implementers.

## Prerequisites
To build the application the following tooles are needed:
* .NET Core 2.2 SDK (https://dotnet.microsoft.com/download)
* Visual Studio 2017 (https://visualstudio.microsoft.com/downloads/)

## Execution
Run the following command to run the tool:

`EdFi.Ods.CodeGen.Console.exe`

## Testing the generated artifacts against the main solution
* Run initdev on the main solution first
** if getting errors either clean the solution using `git clean -xdf` or delete the bin and obj folders from EdFi.Ods.Common and EdFi.Ods.Xml
* Disable code generation from the T4TextTemplating.Targets by disabling run generation on build.
* Compile and run EdFi.Ods.CodeGen.Console.exe
* run Rebuild-Solution

## Known issues
* net core does not play nice with the main solution, if getting errors either clean the solution using `git clean -xdf` or delete the bin and obj folders from EdFi.Ods.Common and EdFi.Ods.Xml before opening the solution in Visual Studio.
