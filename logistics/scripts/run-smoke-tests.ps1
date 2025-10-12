# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -version 5

<#
.SYNOPSIS
    Runs smoke tests against the specified api.

.DESCRIPTION
    By default this will:
    * Reset-Admin Database
    * Reset-Security Database
    * Reset-TestPopulateTemplate Database
    * Creates a new test harness json in env:temp
    * Builds the test Load Tools solution
    * Run Smoke Tests non destructive tests by default

    .PARAMETER apiUrl
    The url for accessing the api website deployment, must NOT end in a forward slash, for example: https://api-stage.ed-fi.org/api/api/ods/v3

    .PARAMETER key
    The key used to authenticate for the smoke test (Default: sandbox generated key)

    .PARAMETER secret
    The secret used to authenticate for the smoke test (Default: sandbox generated secret)

    .PARAMETER namespaceUri
    Overrride the URI to use when generating namespace values (Default: uri://ed-fi.org/)

    .PARAMETER schoolYear
    The School Year to use for all api requests (Default: (Get-Date).year)

    .PARAMETER testSets
    The types of test sets to run. NonDestructiveApi, NonDestructiveSdk, or DestructiveSdk (Default: NonDestructiveApi, NonDestructiveSdk)

    .PARAMETER noRebuild
    Disables the rebuild of the load tools solution

    .EXAMPLE
    PS> run-smoke-tests.ps1
#>
param(
    [string] $apiUrl = "http://localhost:8765",
    [string] $key = $null,
    [string] $secret = $null,
    [string] $namespaceUri = "uri://ed-fi.org/",
    [string] $schoolYear = $null,
    [string[]] $testSets = @("NonDestructiveApi"),
    [string] $smokeTestExe = "./EdFi.SmokeTest.Console/tools/EdFi.SmokeTest.Console.exe",
    [string] $smokeTestDll = "./EdFi.OdsApi.Sdk/lib/EdFi.OdsApi.Sdk.dll",
    [switch] $noRebuild,
    [string] $testHarnessLogNamePrefix,
    [switch] $isMultiTenancy
)

$ErrorActionPreference = 'Stop'

$error.Clear()

& "$PSScriptRoot/../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/utility/cross-platform.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/LoadTools.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/TestHarness.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/hashtable.psm1')

if ([string]::IsNullOrWhiteSpace($key)) { $key = Get-RandomString }
if ([string]::IsNullOrWhiteSpace($secret)) { $secret = Get-RandomString }

if ([string]::IsNullOrWhiteSpace($smokeTestExe) -or -not (Test-Path $smokeTestExe)) {
    $smokeTestExeFileName = "EdFi.SmokeTest.Console$(GetExeExtension)"
    $smokeTestExe = "$(Get-RepositoryResolvedPath "Utilities/DataLoading/EdFi.SmokeTest.Console")/bin/**/$smokeTestExeFileName"
}
else { $noRebuild = $true }

if ([string]::IsNullOrWhiteSpace($smokeTestDll) -or -not(Test-Path $smokeTestDll)) {
    $smokeTestDll = "$(Get-RepositoryResolvedPath "Utilities/DataLoading/EdFi.LoadTools.Test")/bin/**/EdFi.OdsApi.Sdk.dll"
}

function Get-SmokeTestConfiguration {
    $config = @{ }

    $config.apiUrlBase = $apiUrl
    $config.apiNamespaceUri = $namespaceUri
    $config.apiKey = $key
    $config.apiSecret = $secret
    $config.apiClientNameSandbox = "ODS/API"
    $config.apiYear = $schoolYear
    $config.smokeTestExecutable = $smokeTestExe
    $config.smokeTestDll = $smokeTestDll
    $config.apiAppConfig = "$(Get-RepositoryResolvedPath "Application/EdFi.Ods.Api.IntegrationTestHarness")/bin/**/appsettings.json"
    $config.noExtensions = $false
    $config.isMultiTenancy = $isMultiTenancy.IsPresent

    $config.testSets = $testSets

    $config.loadToolsSolution = (Get-RepositoryResolvedPath "Utilities/DataLoading/LoadTools.sln")

    $config.testHarnessAppConfig = "$(Get-RepositoryResolvedPath "Application/EdFi.Ods.Api.IntegrationTestHarness")/bin/**/appsettings.json"
    $config.testHarnessJsonConfig = "$(Get-RepositoryResolvedPath "logistics/scripts/smokeTestHarnessConfiguration.json")"
    if ($isMultiTenancy.IsPresent) { $config.testHarnessJsonConfig = "$(Get-RepositoryResolvedPath "logistics/scripts/smokeTestHarnessConfiguration - Multitenancy.json")" }
    $config.testHarnessJsonConfigLEAs = @()

    $config.bulkLoadTempJsonConfig = Join-Path ([IO.Path]::GetTempPath()) "smokeTestconfig.json"

    $config.buildConfiguration = "Debug"
    if (-not [string]::IsNullOrWhiteSpace($env:msbuild_buildConfiguration)) { $config.buildConfiguration = $env:msbuild_buildConfiguration }
    if (-not [string]::IsNullOrWhiteSpace($env:msbuild_exe)) { $config.msbuild_exe = $env:msbuild_exe }

    return $config
}

$errorCode = 0;

try {
    Clear-Error

    $config = Get-SmokeTestConfiguration
    $config.GetEnumerator() | Sort-Object -Property Name | Format-Table -HideTableHeaders -AutoSize -Wrap

    $script:result = @()

    if (-not $noRebuild) {
        $script:result += Invoke-Task "Invoke-BuildLoadTools" { Invoke-BuildLoadTools $config }
    }

    $script:result += Invoke-Task "Add-RandomKeySecret" { Add-RandomKeySecret $config }

    $script:result += Invoke-Task "Start-TestHarness" {
        $params = @{
            apiUrl                = $config.apiUrlBase
            configurationFilePath = $config.bulkLoadTempJsonConfig
            testHarnessLogNamePrefix = $testHarnessLogNamePrefix
        }
        Start-TestHarness @params
    }

    $script:result += Invoke-Task "Invoke-SmokeTestClient" { Invoke-SmokeTestClient $config }

    Test-Error

    $script:result += New-TaskResult -name '-' -duration '-'
    $script:result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format

    return $script:result | Format-Table
}
catch {
    Write-Host $_
    $errorCode = 1;
}
finally {
    Stop-TestHarness
    exit $errorCode;
}
