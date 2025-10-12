# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -version 5

param (
    [string]
    [Parameter(Mandatory = $true)]
    $PackageDirectory 
)
$ErrorActionPreference = "Stop"

Push-Location $PackageDirectory

$edFiRepoContainer = "$PackageDirectory/../../.."
$repositoryNames = @('Get-RepositoryRoot "Ed-Fi-ODS"')
& "$edFiRepoContainer/Get-RepositoryRoot "Ed-Fi-ODS"/logistics/scripts/modules/load-path-resolver.ps1" $repositoryNames
Import-Module -Force $folders.modules.invoke("packaging/nuget-helper.psm1")

$configurationFile = (Get-RepositoryResolvedPath 'configuration.packages.json')
$configuration = (Get-Content $configurationFile | ConvertFrom-Json).packages.AppCommon

# Download App Common
$parameters = @{
    PackageName = $configuration.packageName
    PackageVersion = $configuration.packageVersion
    packageSource  = $configuration.packageSource
}
$appCommonDirectory = Get-NuGetPackage @parameters

# Move AppCommon's modules to a local AppCommon directory
@(
    "Application"
    "Environment"
    "IIS"
    "Utility"
) | ForEach-Object {
    $parameters = @{
        Recurse = $true
        Force = $true
        Path = "$appCommonDirectory/$_"
        Destination = "$PackageDirectory/AppCommon/$_"
    }
    Copy-Item @parameters
}

Pop-Location
