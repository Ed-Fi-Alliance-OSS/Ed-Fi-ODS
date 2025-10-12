# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#Requires -Version 5

<#
.SYNOPSIS
    Sets environment variables containing the most recent pre-release
    minor/patch release of the 7.x line as well as the standard and extension version.

.DESCRIPTION
    Uses the [NuGet Server
    API](https://docs.microsoft.com/en-us/nuget/api/overview) to look for the
    latest compatible version of a NuGet package, where version is all or part
    of a Semantic Version. For example, if $PackageVersion = "5", this will
    download the most recent 5.minor.patch version. If $PackageVersion = "5.3",
    then it download the most recent 5.3.patch version. And if $PackageVersion =
    "5.3.1", then it will look for the exact version 5.3.1 and fail if it does
    not exist.

.OUTPUTS
    Sets the following environment variables: 
    - $env:ODS_MINIMAL_VERSION
    - $env:TPDM_MINIMAL_VERSION
    - $env:ODS_POPULATED_VERSION
    - $env:TPDM_POPULATED_VERSION
    - $env:ADMIN_VERSION
    - $env:SECURITY_VERSION
    - $env:API_VERSION
    - $env:SWAGGER_VERSION
    - $env:SANDBOX_VERSION
    - $env:STANDARD_VERSION
    - $env:EXTENSION_VERSION
    - $env:BULKLOAD_VERSION
    - $env:MSSQL_ODS_MINIMAL_VERSION
    - $env:MSSQL_TPDM_MINIMAL_VERSION
    - $env:MSSQL_ODS_POPULATED_VERSION
    - $env:MSSQL_TPDM_POPULATED_VERSION
    - $env:MSSQL_ADMIN_VERSION
    - $env:MSSQL_SECURITY_VERSION
#>
param(
    [string]
    $PackageVersion = "7.3",

    [string]
    [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
    $StandardVersion,

    [string]
    [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
    })]
    $ExtensionVersion,

    # Enable usage of prereleases
    [Switch]
    $PreRelease
)

$ErrorActionPreference = "Stop"

# Azure DevOps hosts the Ed-Fi packages, and it requires TLS 1.2
if (-not [Net.ServicePointManager]::SecurityProtocol.HasFlag([Net.SecurityProtocolType]::Tls12)) {
    [Net.ServicePointManager]::SecurityProtocol += [Net.SecurityProtocolType]::Tls12
}


<#
.SYNOPSIS
    Sorts versions semantically.

.DESCRIPTION
    Semantic Version sorting means that "5.3.111" comes before "5.3.2", despite
    2 being greater than 1.

.EXAMPLE
    Invoke-SemanticSort @("5.1.1", "5.1.11", "5.2.9")

    Output: @("5.2.9", "5.1.11", "5.1.1")
#>
function Invoke-SemanticSort {
    param(
        [Parameter(Mandatory=$true)]
        [string[]]
        $Versions
    )

    $major = @{label="major";expression={[int]$_.Split(".")[0]}}
    $minor = @{label="minor";expression={[int]$_.Split(".")[1]}}
    $patch = @{label="patch";expression={[int]$_.Split(".")[2]}}

    $Versions `
        | Select-Object $major, $minor, $patch `
        | Sort-Object major, minor, patch -Descending `
        | ForEach-Object { "$($_.major).$($_.minor).$($_.patch)" }
}


<#
.SYNOPSIS
    Looks up the most recent patch version for a NuGet package.

.DESCRIPTION
    Uses the [NuGet Server API](https://docs.microsoft.com/en-us/nuget/api/overview)
    to look for the latest compatible version of a NuGet package, where version is
    all or part of a Semantic Version. For example, if $PackageVersion = "5", this
    will download the most recent 5.minor.patch version. If $PackageVersion = "5.3",
    then it download the most recent 5.3.patch version. And if $PackageVersion = "5.3.1",
    then it will look for the exact version 5.3.1 and fail if it does not exist.

.OUTPUTS
    The latest version

.EXAMPLE
    Get-NugetPackageVersion -PackageName "EdFi.Suite3.RestApi.Databases" -PackageVersion "5.3"
#>
function Get-NugetPackageVersion {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $PackageName,

        [Parameter(Mandatory=$true)]
        [string]
        $PackageVersion,

        # URL for the pre-release package feed
        [string]
        $PreReleaseServiceIndex = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi/nuget/v3/index.json",

        # URL for the release package feed
        [string]
        $ReleaseServiceIndex = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi%40Release/nuget/v3/index.json",

        # Enable usage of prereleases
        [Switch]
        $PreRelease
    )

    # Pre-releases
    $nugetServicesURL = $ReleaseServiceIndex
    if ($PreRelease) {
        $nugetServicesURL = $PreReleaseServiceIndex
    }

    # The first URL just contains metadata for looking up more useful services
    $nugetServices = Invoke-RestMethod $nugetServicesURL

    $packageService = $nugetServices.resources `
                        | Where-Object { $_."@type" -like "PackageBaseAddress*" } `
                        | Select-Object -Property "@id" -ExpandProperty "@id"

    # Pad the package version out to three part semver
    switch ($PackageVersion.split(".").length) {
        1 { $versionSearch = "$PackageVersion.*.*"}
        2 { $versionSearch = "$PackageVersion.*" }
        3 { $versionSearch = $PackageVersion }
        default: { throw @"
Invalid version string ``$($PackageVersion)``. Should be one, two, or three components from a Semantic Version."
"@.Trim()
}
    }
    $lowerId = $PackageName.ToLower()

    # Lookup available packages
    $package = Invoke-RestMethod "$($packageService)$($lowerId)/index.json"

    # Sort by SemVer
    $versions = Invoke-SemanticSort $package.versions

    # Find the first available version that matches the requested version
    $version = $versions | Where-Object { $_ -like $versionSearch } | Select-Object -First 1

    if ($null -eq $version) {
        throw "Version ``$($PackageVersion)`` does not exist yet for ``$($PackageName)``."
    }

    $version
}

$env:ODS_MINIMAL_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Minimal.Template.PostgreSQL.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:TPDM_MINIMAL_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Minimal.Template.TPDM.Core.$ExtensionVersion.PostgreSQL.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:ODS_POPULATED_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Populated.Template.PostgreSQL.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:TPDM_POPULATED_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Populated.Template.TPDM.Core.$ExtensionVersion.PostgreSQL.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:ADMIN_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Database.Admin.PostgreSQL.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:SECURITY_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Database.Security.PostgreSQL.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:API_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.WebApi.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:SWAGGER_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.SwaggerUI -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:SANDBOX_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.SandboxAdmin -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:STANDARD_VERSION = $StandardVersion
$env:EXTENSION_VERSION = $ExtensionVersion
$env:BULKLOAD_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.BulkLoadClient.Console -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:MSSQL_ODS_MINIMAL_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Minimal.Template.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:MSSQL_TPDM_MINIMAL_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Minimal.Template.TPDM.Core.$ExtensionVersion.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:MSSQL_ODS_POPULATED_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Populated.Template.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:MSSQL_TPDM_POPULATED_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Suite3.Ods.Populated.Template.TPDM.Core.$ExtensionVersion.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:MSSQL_ADMIN_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Database.Admin.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
$env:MSSQL_SECURITY_VERSION = "$(Get-NugetPackageVersion -PackageName EdFi.Database.Security.Standard.$StandardVersion -PackageVersion $PackageVersion -PreRelease:$PreRelease)".Trim()
