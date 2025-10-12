# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/hashtable.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/cross-platform.psm1')

$script:testHarnessFolder = (Get-RepositoryResolvedPath "Application/EdFi.Ods.Api.IntegrationTestHarness")
$script:testHarnessName = (Get-Item $script:testHarnessFolder).Name

function Add-RandomKeySecret {
    param(
        [hashtable] $config
    )

    $content = (Get-Content (Get-ChildItem $config.testHarnessJsonConfig).FullName -Raw -Encoding UTF8 | ConvertFrom-Json)
    foreach ($vendor in $content.vendors) {
        foreach ($application in $vendor.applications) {
            foreach ($apiClient in $application.apiClients) {
                if (-not @($config.apiClientNameBootstrap, $config.apiClientNameSandbox) -contains $apiClient.ApiClientName) { continue; }

                if ([string]::IsNullOrWhiteSpace($config.apiKey)) { $randomKey = Get-RandomString }
                else { $randomKey = $config.apiKey }

                if ([string]::IsNullOrWhiteSpace($config.apiSecret)) { $randomSecret = Get-RandomString }
                else { $randomSecret = $config.apiSecret }

                $apiClient | Add-Member -MemberType NoteProperty -Name 'Key' -Value $randomKey
                $apiClient | Add-Member -MemberType NoteProperty -Name 'Secret' -Value $randomSecret

                $apiClient | Format-List | Out-Host

                if ($apiClient.ApiClientName -eq $config.apiClientNameBootstrap) {
                    $config.apiBootstrapKey = $randomKey
                    $config.apiBootstrapSecret = $randomSecret
                }
                if ($apiClient.ApiClientName -eq $config.apiClientNameSandbox) {
                    $config.apiSandboxKey = $randomKey
                    $config.apiSandboxSecret = $randomSecret
                }

                $testHarnessJsonConfigLEAs = $config.testHarnessJsonConfigLEAs
                if (-not ($null -eq $testHarnessJsonConfigLEAs) -and ($testHarnessJsonConfigLEAs.Length -gt 0)) {
                    $apiClient.LocalEducationOrganizations = $testHarnessJsonConfigLEAs
                }
            }
        }
    }

    $bulkLoadTempJsonConfig = $config.bulkLoadTempJsonConfig
    $content | ConvertTo-Json -Depth 10 | Set-Content $bulkLoadTempJsonConfig -Encoding UTF8

    Write-Host "Created Temp Config: $bulkLoadTempJsonConfig"
}

function Get-TestHarnessExecutable {
    $testHarnessExecutableFilter = "$(Get-RepositoryResolvedPath "/Application/$($script:testHarnessName)")/bin/**/$($script:testHarnessName)$(GetExeExtension)"
    $testHarnessExecutable = (Get-ChildItem -Recurse -Path $testHarnessExecutableFilter).FullName

    return $testHarnessExecutable
}

function Get-SdkGenExecutable {
    Param(
        [string] $buildConfiguration = "Debug"
    )
    $sdkGenExecutableFilter = "$(Get-RepositoryResolvedPath "/Utilities/SdkGen/EdFi.SdkGen.Console/bin/$buildConfiguration/**/EdFi.SdkGen.Console$(GetExeExtension)")"
    $sdkGenExecutable = (Get-ChildItem -Recurse -Path $sdkGenExecutableFilter).FullName

    return $sdkGenExecutable
}

function Invoke-SdkGenConsole {
    Param(
        [Parameter(Mandatory = $true)] [string] $apiMetadataUrl,
        [string] $buildConfiguration = "Debug",
        [string[]] $arguments = @("-p","-c","-i")

    )
    
    $sdkGenConsoleFolder = (Get-RepositoryResolvedPath "/Utilities/SdkGen/EdFi.SdkGen.Console" | Select-Object -ExpandProperty Path)
    $sdkGenConsoleExecutableFolderFullPath = (Get-SdkGenExecutable $buildConfiguration)
    $argumentList = @('-m', $apiMetadataUrl) + $arguments
    Start-Process $sdkGenConsoleExecutableFolderFullPath -ArgumentList $argumentList -WorkingDirectory $sdkGenConsoleFolder -NoNewWindow -Wait | Out-Host
}

function Start-TestHarness {
    param(
        [Parameter(Mandatory = $true)] [string] $apiUrl,
        [string] $configurationFilePath,
        [string] $environmentFilePath,
        [string] $testHarnessExecutable,
        [string] $testHarnessLogNamePrefix = ""
    )

    Stop-TestHarness

    if (![string]::IsNullOrEmpty($testHarnessLogNamePrefix)) { $testHarnessLogNamePrefix += "." }
    $Env:TEST_HARNESS_LOG_NAME_PREFIX = $testHarnessLogNamePrefix

    if ([string]::IsNullOrEmpty($testHarnessExecutable)) { $testHarnessExecutable = (Get-TestHarnessExecutable) }

    if (-not [string]::IsNullOrEmpty($configurationFilePath)) {
        if (Test-Path $configurationFilePath) {
            $params = @("--configurationFilePath=$configurationFilePath")
            if (-not [string]::IsNullOrEmpty($environmentFilePath)) { $params += @("--environmentFilePath=$environmentFilePath") }
            $params += "--environment=Development"

            Write-Host "$testHarnessExecutable $params" -ForegroundColor Magenta
            Start-Process $testHarnessExecutable -ArgumentList ($params -join " ") -NoNewWindow
        }
        else {
            throw "Configuration file '$configurationFilePath' does not exist."
        }
    }
    else {
        Start-Process $testHarnessExecutable -NoNewWindow
    }

    $timeOut = (Get-Date).AddSeconds(60);

    $response = @{}
    $isPingSuccessful = $false;

    while ($isPingSuccessful -eq $false -and (Get-Date) -le $timeOut) {
        try {
            $response = Invoke-RestMethod -Uri $apiUrl
            $isPingSuccessful = $true;
            Write-Host
        }
        catch {
            Write-Host "Waiting for TestHarness startup at $apiUrl..."
            Start-Sleep -s 1
        }
    }

    if ($isPingSuccessful -eq $false) {
        throw "No response from $apiUrl"
    }

    Write-FlatHashtable ($response | ConvertTo-Hashtable)
}

function Stop-TestHarness {
    Get-Process -name $script:testHarnessName -ErrorAction SilentlyContinue |
    ForEach-Object {
        $_ | Sort-Object -Property Name | Format-Table -AutoSize -Wrap | Out-Host
        Stop-Process -Id $_.Id
    }
}

Export-ModuleMember -function Add-RandomKeySecret, Start-TestHarness, Invoke-SdkGenConsole,
Stop-TestHarness -Alias *
