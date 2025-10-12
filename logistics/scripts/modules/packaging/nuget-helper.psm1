# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/utility/cross-platform.psm1")

function Get-NuGetPackage {
    <#
    .SYNOPSIS
        Download and unzip a NuGet package for the purpose of bundling into another package.
    .DESCRIPTION
        Uses nuget command line to download a NuGet package and unzip it into an output
        directory. Uses the Ed-Fi Azure Artifacts package feed by default. Default output directory
        is ./downloads.
    .PARAMETER packageName
        Alias "applicationId". Name of the package to download.
    .PARAMETER packageVersion
        Package version number. Can include pre-release information. Optional. If not
        specified, installs the most recent full release version.
    .PARAMETER outputDirectory
        The path into which the package is unzipped. Defaults to "./downloads".
    .PARAMETER packageSource
        The NuGet package source. Defaults to "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi/nuget/v3/index.json".
    .EXAMPLE
        $parameters = @{
            packageName = "EdFi.Suite3.Ods.WebApi"
            packageVersion = "6.0.0-b11661"
        }
        Get-NuGetPackage @parameters
    #>
    [CmdletBinding()]
    param (
        [string]
        [Parameter(Mandatory = $true)]
        [Alias("applicationId")]
        $PackageName,

        [string]
        $PackageVersion,

        [string]
        $OutputDirectory = './downloads',

        [string]
        $PackageSource = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi/nuget/v3/index.json",

        [switch]
        $ExcludeVersion
    )

    # 'dotnet add' requires a project or solution be specified,
    # even if it's contents are not used.
    # Therefore, when creating a package defined by a .nuspec file,
    # we must create an empty project and then delete it after packing is complete

    $temporaryProjectDirectory = "$(Get-RepositoryResolvedPath)temporary-project"
    $temporaryProjectName = "temporary-project"
    
    $parameters = @(
        "new", "classlib"
        "--name", $temporaryProjectName
        "--output", $temporaryProjectDirectory
    )

    Write-Host -ForegroundColor Magenta "& dotnet $parameters"
    & dotnet $parameters | Out-Null

    $packageDestinationPath = "$OutputDirectory/$PackageName.$PackageVersion/"

    if ($ExcludeVersion) {
        $packageDestinationPath = "$OutputDirectory/$PackageName/"
    }

    $parameters = @(
        "add", $temporaryProjectDirectory
        "package", $PackageName
        "-s", $PackageSource
        "--package-directory", $OutputDirectory
    )

    if ($PackageVersion) {
        $parameters += "-v"
        $parameters += $PackageVersion
    }

    If(-not (test-path -PathType container $OutputDirectory))
    {
        New-Item -ItemType Directory -Path $OutputDirectory | Out-Null
    }

    Write-Host -ForegroundColor Magenta "& dotnet $parameters"
    & dotnet $parameters | Out-Null

    if (-not (Test-Path "$OutputDirectory/$PackageName.$PackageVersion-temp/")) {
        New-Item -Path "$OutputDirectory/$PackageName.$PackageVersion-temp/" -ItemType Directory | Out-Null
    }

    if (-not (Test-Path $packageDestinationPath)) {
        New-Item -Path $packageDestinationPath -ItemType Directory | Out-Null
    }

    Move-Item -Force -Path "$OutputDirectory/$($PackageName.ToLower())/$PackageVersion/*" -Destination "$OutputDirectory/$PackageName.$PackageVersion-temp"
    Move-Item -Force -Path "$OutputDirectory/$PackageName.$PackageVersion-temp/*" -Destination $packageDestinationPath
    Remove-Item -Recurse -Force "$OutputDirectory/$PackageName.$PackageVersion-temp/" | Out-Null

    if ($ExcludeVersion) {
        Remove-Item -Recurse -Force "$OutputDirectory/$($PackageName.ToLower())/$PackageVersion" | Out-Null
    } else {
        Remove-Item -Recurse -Force "$OutputDirectory/$($PackageName.ToLower())" | Out-Null
    }

    if(Test-Path $temporaryProjectDirectory) {
        Remove-Item -Path $temporaryProjectDirectory -Recurse -Force | Out-Null 
    } 
        
    return $packageDestinationPath
}

$exports = @(
    "Get-NuGetPackage"
)

Export-ModuleMember -Function $exports
