# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
.DESCRIPTION
    Deploys Admin or Security databases for packaging
#>
param(
    # The type of database to create, either 'Admin' or 'Security'
    [Parameter(Mandatory = $true)]
    [ValidateSet('Admin', 'Security')]
    [string] $DatabaseType,

    # Override the default NuGet package id
    [string] $PackageName,

    # An absolute path to the folder containing sqlpackage.exe. Example: 'C:/Program Files/Microsoft SQL Server/150/DAC/bin'
    [string] $SQLPackage = 'C:/Program Files/Microsoft SQL Server/150/DAC/bin',

    # An absolute path to the output folder to store artifacts.
    [string] $Output = "C:/tmp/EdFi.Database",

    [string[]] $PathResolverOverride,

    [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
    [String] $standardVersion,

    [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
    })]
    [string]  $ExtensionVersion
)

$ErrorActionPreference = 'Stop'

if ($PathResolverOverride.Length -gt 0) {
    & "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1" $PathResolverOverride
}
else {
    & "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
}
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'Application/SolutionScripts/InitializeDevelopmentEnvironment.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'DatabaseTemplate/Modules/create-database-bacpac.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/create-package.psm1')

Clear-Error

if (-not (Test-Path $SQLPackage)) { throw "SQLPackage.exe not found at '$SQLPackage'" }
if ([string]::IsNullOrWhitespace($PackageName)) { $PackageName = "EdFi.Database.$DatabaseType" }

$settings = @{ ApiSettings = @{ } }
if ($StandardVersion) { $settings.ApiSettings.StandardVersion = $StandardVersion }
if ($ExtensionVersion) { $settings.ApiSettings.ExtensionVersion = $ExtensionVersion }
Set-DeploymentSettings $settings | Out-Null

Write-InvocationInfo $MyInvocation

$tasks = [ordered] @{
    'New SQLServer Settings'                               = {
        $settings = @{ ApiSettings = @{ Engine = 'SQLServer' } }

        $settingsFiles = @(
            "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.json",
            "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.Development.json"
        )

        New-DevelopmentAppSettings $settings

        Write-Host 'created sql server settings files:' -ForegroundColor Green
        $settingsFiles | Write-Host

        $sqlServerSettings = Get-MergedAppSettings $settingsFiles

        $sqlServerSettings = Set-Feature -Settings $sqlServerSettings -FeatureName 'Extensions' -IsEnabled $false
        $sqlServerSettings = Set-Feature -Settings $sqlServerSettings -FeatureName 'ChangeQueries' -IsEnabled $true
        $sqlServerSettings = Add-DeploymentSpecificSettings $sqlServerSettings

        Write-Host
        Write-FlatHashtable $sqlServerSettings
    }
    'New PostgreSQL Settings'                              = {
        $settings = @{ ApiSettings = @{ Engine = 'PostgreSQL' } }

        $settingsFiles = @(
            "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.json",
            "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.Development.json"
        )

        New-DevelopmentAppSettings $settings
        Write-Host 'created postgres settings files:' -ForegroundColor Green
        $settingsFiles | Write-Host

        $postgresSettings = Get-MergedAppSettings $settingsFiles

        $postgresSettings = Set-Feature -Settings $postgresSettings -FeatureName 'Extensions' -IsEnabled $false
        $postgresSettings = Set-Feature -Settings $postgresSettings -FeatureName 'ChangeQueries' -IsEnabled $true
        $postgresSettings = Add-DeploymentSpecificSettings $postgresSettings

        Write-Host
        Write-FlatHashtable $postgresSettings
    }
    "Reset SQLServer $DatabaseType Database"               = {
        $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$DatabaseType]
        $params = @{
            engine           = $sqlServerSettings.ApiSettings.engine
            csb              = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
            database         = $databaseType
            filePaths        = $sqlServerSettings.ApiSettings.FilePaths
            subTypeNames     = $sqlServerSettings.ApiSettings.SubTypes
            dropDatabase     = $true
            standardVersion  = $StandardVersion
            extensionVersion = $ExtensionVersion
        }
        Initialize-EdFiDatabaseWithDbDeploy @params
    }
    "Reset PostgreSQL $DatabaseType Database"              = {
        $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$DatabaseType]
        $params = @{
            engine           = $postgresSettings.ApiSettings.engine
            csb              = $postgresSettings.ApiSettings.csbs[$connectionStringKey]
            database         = $databaseType
            filePaths        = $postgresSettings.ApiSettings.FilePaths
            subTypeNames     = $postgresSettings.ApiSettings.SubTypes
            dropDatabase     = $true
            standardVersion  = $StandardVersion
            extensionVersion = $ExtensionVersion
        }
        Initialize-EdFiDatabaseWithDbDeploy @params
    }
    "Export SQLServer $DatabaseType Database to Backup"    = {
        $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$DatabaseType]
        $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
        $params = @{
            databaseConnectionString = $csb
            databaseBackupName       = $csb['database']
            backupDirectory          = $Output
            multipleBackups          = $true
            engine                   = $sqlServerSettings.ApiSettings.Engine
        }
        Write-FlatHashtable $params
        Backup-DatabaseTemplate $params
    }
    "Export SQLServer $DatabaseType Database to BACPAC"    = {
        $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
        $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
        $databaseName = $csb['database']
        $params = @{
            sqlPackagePath = $SQLPackage
            database       = $databaseName
            artifactOutput = (Join-Path $Output "$databaseName.bacpac")
        }
        Write-FlatHashtable $params
        Export-BacPac @params
    }
    "Export PostgreSQL $DatabaseType Database to SQL File" = {
        $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$DatabaseType]
        $csb = $postgresSettings.ApiSettings.csbs[$connectionStringKey]
        $params = @{
            databaseConnectionString = $csb
            databaseBackupName       = $csb['database']
            backupDirectory          = $Output
            multipleBackups          = $true
            engine                   = $postgresSettings.ApiSettings.Engine
        }
        Write-FlatHashtable $params
        Backup-DatabaseTemplate $params
    }
    'Create SQLServer Backup .nuspec'                      = {
        $name = "$PackageName.Standard.$StandardVersion"
        $nuspecPath = Join-Path $Output "$name.nuspec"

        $params = @{
            forceOverwrite           = $true
            nuspecPath               = $nuspecPath
            id                       = $name
            description              = $name
            version                  = '$version$'
            authors                  = '$authors$'
            owners                   = '$owners$'
            copyright                = '$copyright$'
            requireLicenseAcceptance = $false
        }
        New-Nuspec @params

        $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
        $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
        $databaseName = $csb['database']
        $filesToPackage = (Get-ChildItem "$Output/$databaseName.bak" | foreach { @{ source = $_.FullName; target = '.' } })
        $filesToPackage.source | Write-Host

        $params = @{
            nuspecPath       = $nuspecPath
            sourceTargetPair = $filesToPackage
        }
        Add-FileToNuspec @params

        Write-Host
        Write-Host "Created $nuspecPath" -ForegroundColor Green
        Write-Host
    }
    'Create SQLServer BACPAC .nuspec'                      = {
        $name = "$PackageName.BACPAC.Standard.$StandardVersion"
        $nuspecPath = Join-Path $Output "$name.nuspec"

        $params = @{
            forceOverwrite           = $true
            nuspecPath               = $nuspecPath
            id                       = $name
            description              = $name
            version                  = '$version$'
            authors                  = '$authors$'
            owners                   = '$owners$'
            copyright                = '$copyright$'
            requireLicenseAcceptance = $false
        }
        New-Nuspec @params

        $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
        $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
        $databaseName = $csb['database']
        $filesToPackage = (Get-ChildItem "$Output/$databaseName.bacpac" | foreach { @{ source = $_.FullName; target = '.' } })
        $filesToPackage.source | Write-Host

        $params = @{
            nuspecPath       = $nuspecPath
            sourceTargetPair = $filesToPackage
        }
        Add-FileToNuspec @params

        Write-Host
        Write-Host "Created $nuspecPath" -ForegroundColor Green
        Write-Host
    }
    'Create PostgreSQL Backup .nuspec'                     = {
        $name = "$PackageName.PostgreSQL.Standard.$StandardVersion"
        $nuspecPath = Join-Path $Output "$name.nuspec"

        $params = @{
            forceOverwrite           = $true
            nuspecPath               = $nuspecPath
            id                       = $name
            description              = $name
            version                  = '$version$'
            authors                  = '$authors$'
            owners                   = '$owners$'
            copyright                = '$copyright$'
            requireLicenseAcceptance = $false
        }
        New-Nuspec @params

        $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
        $csb = $postgresSettings.ApiSettings.csbs[$connectionStringKey]
        $databaseName = $csb['database']
        $filesToPackage = (Get-ChildItem "$Output/$databaseName.sql" | foreach { @{ source = $_.FullName; target = '.' } })
        $filesToPackage.source | Write-Host

        $params = @{
            nuspecPath       = $nuspecPath
            sourceTargetPair = $filesToPackage
        }
        Add-FileToNuspec @params

        Write-Host
        Write-Host "Created $nuspecPath" -ForegroundColor Green
        Write-Host
    }
}

$script:result = @()

$elapsed = Use-StopWatch {
    if (-not [string]::IsNullOrWhiteSpace((Get-DeploymentSettings).Plugin.Folder)) { $script:result += Install-Plugins }
    # only the security database currently has codegen artifacts
    if ($DatabaseType -eq 'Security') { $script:result += Invoke-CodeGen -StandardVersion $StandardVersion -ExtensionVersion $ExtensionVersion }
    $script:result += Install-DbDeploy

    foreach ($task in $tasks.Keys) { $script:result += Invoke-Task -name $task -task $tasks[$task] }
}

Test-Error

$script:result += New-TaskResult -name '-' -duration '-'
$script:result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format

return $script:result | Format-Table
