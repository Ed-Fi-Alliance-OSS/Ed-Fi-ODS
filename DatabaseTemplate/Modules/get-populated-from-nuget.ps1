# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
.SYNOPSIS
    Downloads a nuget package containing the populated template backup
.DESCRIPTION
    Registers the supplied or default package source.
    Saves the specified package name and version to the populated template folder.
    Extracts the first .bak file from this package folder and moves it to the Database folder.
    The first .bak file found in the database folder will be used by the other scripts when creating a populated template.
.INPUTS
    [string] Package Name
    [string] Package Version
    [string] Package Source
.OUTPUTS
    None.
.EXAMPLE
    $params = @{
        packageName    = "EdFi.Samples.Ods"
        packageVersion = "3.3.0"
        packageSource  = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi/nuget/v3/index.json"
    }

    & "$PSScriptRoot/../Modules/get-populated-from-nuget.ps1" @params
#>

param (
    # The name of the nuget package.
    [Parameter(Mandatory)]
    [string] $packageName,
    # The specific version of the package. Prerelease versions are allowed.
    [Parameter(Mandatory)]
    [string] $packageVersion,
    # The url of the package feed to use. This feed will automatically be added if not found.
    [Parameter(Mandatory)]
    [string] $packageSource
)

& "$PSScriptRoot/../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "DatabaseTemplate/Modules/database-template-source.psm1")

# Ensure we have Tls12 support
if (-not [Net.ServicePointManager]::SecurityProtocol.HasFlag([Net.SecurityProtocolType]::Tls12))
{
    [Net.ServicePointManager]::SecurityProtocol += [Net.SecurityProtocolType]::Tls12
}
$providerName = 'NuGet'
if (-not (Get-PackageProvider | Where-Object { $_.Name -eq $providerName })) {
    Write-Host "Installing nuget package provider"
    Install-PackageProvider -Force -Name $providerName | Out-Null
}
if (-not (Get-PackageSource | Where-Object { $_.Location -eq $packageSource -and $_.ProviderName -eq $providerName })) {
    Write-Host "Registering nuget package source: $packageSource"
    Register-PackageSource -Name $packageSource -Location $packageSource -Provider $providerName | Out-Null
}

$savePackageArgs = @{
    Name            = $packageName
    Path            = $global:templateFolder
    RequiredVersion = $packageVersion
    Source          = $packageSource
    ProviderName    = $providerName
}
$package = (Save-Package @savePackageArgs)

if ($package) {
    Write-Host "Found populated template nuget package: $($package.Name) v$($package.Version)"

    $zipFilePath = "$global:templateFolder/$($package.PackageFilename -replace '.nupkg', '.zip')"
    $packageFolder = "$global:templateFolder/$($package.PackageFilename -replace '.nupkg','')"

    Copy-Item -Force -Path "$global:templateFolder/$($package.PackageFilename)" -Destination $zipFilePath
    if (Test-Path $zipFilePath) { Expand-Archive -Force -Path $zipFilePath -DestinationPath $packageFolder }

    if (Test-Path $packageFolder) {
        if (Test-Path $global:templateDatabaseFolder) { Remove-Item -Force -Recurse -Path $global:templateDatabaseFolder | Out-Null }
        New-Item -Path $global:templateDatabaseFolder -ItemType 'Directory' | Out-Null

        $backupFilePath = Get-TemplateBackupPath $packageFolder
        $backupFileDestinationPath = "$global:templateDatabaseFolder/$($package.Name).$($package.Version).bak"
        if (($null -ne $backupFilePath) -and (Test-Path $backupFilePath)) {
            Copy-Item -Path $backupFilePath -Destination $backupFileDestinationPath
        }
        else {
            Copy-Item -Path "$packageFolder/*" -Destination $global:templateDatabaseFolder
        }
        if (Test-Path $backupFileDestinationPath) { Write-Host "Successfully added $(Split-Path $backupFileDestinationPath -Leaf) to populated template source folder" }
    }

    if (Test-Path $zipFilePath) { Remove-Item -Force -Recurse -Path $zipFilePath }
    if (Test-Path $packageFolder) { Remove-Item -Force -Recurse -Path $packageFolder }
}

if ($error.count -gt 0 -or $LASTEXITCODE -gt 0) { exit 1; }
