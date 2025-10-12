# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

[cmdletbinding(SupportsShouldProcess)]
param(
    [Parameter(Mandatory = $true)]
    $FeedsURL,

    [Parameter(Mandatory = $true)]
    $PackagesURL,

    [Parameter(Mandatory = $true)]
    $Username,

    [Parameter(Mandatory = $true)]
    [SecureString] $Password,

    [Parameter(Mandatory = $true)]
    $View,

    [Parameter(Mandatory = $true)]
    [String] $StandardVersion
)

$ErrorActionPreference = 'Stop'

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/promotion.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/settings/settings-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/hashtable.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")

$packages = @{ }

Invoke-Task -name 'Gather package versions' -task {

    $searchPaths = (Get-ChildItem (Get-RepositoryRoot) -Recurse -Filter '*.sln').FullName
    $configurationFile = (Get-RepositoryResolvedPath 'configuration.packages.json')

    $packages = Merge-Hashtables @(
        (Select-DotNetPackages $searchPaths),
        (Select-ConfigurationPackages $configurationFile)
    )

    $keysToRemove = @()

    foreach ($key in $packages.Keys) {
        foreach ($otherKey in $packages.Keys) {
            if ($key -ne $otherKey -and $otherKey.Contains($key) -and $otherKey.Contains($StandardVersion)) {
                $keysToRemove += $key
                break
            }
        }
    }

    foreach ($key in $keysToRemove) {
        $packages.Remove($key)
    }

    $azurePackages = (Get-AzurePackages $FeedsURL)

    $result = @{ }

    # intersection
    foreach ($key in $packages.Keys) {
        if (-not ($key -in $azurePackages.keys)) { continue }
                if ('latest' -eq  $packages[$key]) {
                    $result.add($key.ToLower(), $azurePackages[$key])
                }
                else {
                    $result.add($key.ToLower(), $packages[$key])
                }
    }

    Write-Host "Found $($result.Count) packages in common:"

    Write-FlatHashtable $result
}

Invoke-Task -name 'Promote packages' -task {

    $parameters = @{
        PackagesURL = $PackagesURL
        Username    = $Username
        Password    = $Password
        View        = $View
        Packages    = $result
    }

    if (-not $PSCmdlet.ShouldProcess($PackagesURL)) { $parameters.WhatIf = $true }

    Invoke-PromotePackages @parameters
}
