# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
.DESCRIPTION
    Deploys databases needed for Cloud ODS export

.PARAMETER sqlPackagePath
    An absolute path to the folder containing sqlpackage.exe. Example: C:/Program Files/Microsoft SQL Server/150/DAC/bin

.PARAMETER artifactPath
   An absolute path to the output folder to store artifacts.
#>
param(
    [Parameter(
        HelpMessage = 'Path to the sqlpackage.exe is required.`n`rExample: C:/Program Files/Microsoft SQL Server/150/DAC/bin'
    )]
    [ValidateNotNullOrEmpty()]
    [string] $sqlPackagePath = 'C:/Program Files/Microsoft SQL Server/150/DAC/bin',

    [Parameter(
        HelpMessage = 'Path the the output folder is required.`n`rExample: C:/tmp/EdFi.CloudOds'
    )]
    [ValidateNotNullOrEmpty()]
    [string] $artifactPath = (Join-Path ([IO.Path]::GetTempPath()) 'EdFi.CloudOds'),

    [string] $packageName = 'EdFi.CloudODS',

    [Obsolete("This parameter is deprecated, and will be removed in the near future.")]
    [switch] $WhatIf,

    [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
    [String] $StandardVersion,

    [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
    })]
    [string]  $ExtensionVersion
)

if (-not (Test-Path $sqlPackagePath)) { throw "Could not find sqlpackage.exe at $sqlPackagePath" }

$ErrorActionPreference = 'Stop'

$repositoryNames = @('Ed-Fi-Ods', 'Get-RepositoryRoot "Ed-Fi-ODS"', 'Ed-Fi-ODS-AdminApp/Application/EdFi.Ods.AdminApp.Web')
Import-Module -Force -Scope Global "$PSScriptRoot/../../../../../logistics/scripts/modules/path-resolver.psm1" -ArgumentList @(, $repositoryNames)
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'Application/SolutionScripts/InitializeDevelopmentEnvironment.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'DatabaseTemplate/Modules/create-database-bacpac.psm1')

Clear-Error

Write-InvocationInfo $MyInvocation

# sql server specific settings
$settings = @{
    ApiSettings = @{
        Engine = 'SQLServer';
        Mode   = "SharedInstance"
    }
}

$newSettingsFiles = @(
    "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.json",
    "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.Development.json"
)

New-DevelopmentAppSettings $settings

Write-Host 'created sql server settings files:' -ForegroundColor Green
$newSettingsFiles | Write-Host

$sqlServerSettings = Get-MergedAppSettings $newSettingsFiles

$sqlServerSettings = Set-Feature -Settings $sqlServerSettings -FeatureName "Extensions" -IsEnabled $false
$sqlServerSettings = Set-Feature -Settings $sqlServerSettings -FeatureName "ChangeQueries" -IsEnabled $true
$sqlServerSettings = Add-DeploymentSpecificSettings $sqlServerSettings

# postgres specific settings
Write-Host

$settings = @{
    ApiSettings = @{
        Engine = 'PostgreSQL'
    }
}

New-DevelopmentAppSettings $settings
Write-Host 'created postgres settings files:' -ForegroundColor Green
$newSettingsFiles | Write-Host

$postgresSettings = Get-MergedAppSettings $newSettingsFiles

$postgresSettings = Set-Feature -Settings $postgresSettings -FeatureName "Extensions" -IsEnabled $false
$postgresSettings = Set-Feature -Settings $postgresSettings -FeatureName "ChangeQueries" -IsEnabled $true
$postgresSettings = Add-DeploymentSpecificSettings $postgresSettings

Write-Host
Write-Host 'sqlServerSettings:' -ForegroundColor Green
Write-FlatHashtable $sqlServerSettings

Write-Host
Write-Host 'postgresSettings:' -ForegroundColor Green
Write-FlatHashtable $postgresSettings

$deploymentTasks = @(
    @{
        Name   = 'Deploy Admin Database to SQLServer'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Admin
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
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
    }
    @{
        Name   = 'Deploy Security Database to SQLServer'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Security
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
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
    }
    @{
        Name   = 'Deploy Empty Template Database to SQLServer'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $params = @{
                engine           = $sqlServerSettings.ApiSettings.engine
                csb              = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods'
                database         = $databaseType
                filePaths        = $sqlServerSettings.ApiSettings.FilePaths
                subTypeNames     = $sqlServerSettings.ApiSettings.SubTypes
                dropDatabase     = $true
                standardVersion  = $StandardVersion
                extensionVersion = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy @params
        }
    }
    @{
        Name   = 'Deploy Minimal Template Database to SQLServer'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $backupPath = Get-MinimalTemplateBackupPathFromSettings $sqlServerSettings
            $params = @{
                engine                  = $sqlServerSettings.ApiSettings.engine
                csb                     = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Minimal_Template'
                database                = $databaseType
                filePaths               = $sqlServerSettings.ApiSettings.FilePaths
                subTypeNames            = $sqlServerSettings.ApiSettings.SubTypes
                dropDatabase            = $true
                createByRestoringBackup = $backupPath
                standardVersion         = $StandardVersion
                extensionVersion        = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy @params
        }
    }
    @{
        Name   = 'Deploy Populated Template Database to SQLServer'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $backupPath = Get-PopulatedTemplateBackupPathFromSettings $sqlServerSettings
            $params = @{
                engine                  = $sqlServerSettings.ApiSettings.engine
                csb                     = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Populated_Template'
                database                = $databaseType
                filePaths               = $sqlServerSettings.ApiSettings.FilePaths
                subTypeNames            = $sqlServerSettings.ApiSettings.SubTypes
                dropDatabase            = $true
                createByRestoringBackup = $backupPath
                standardVersion         = $StandardVersion
                extensionVersion        = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy  @params
        }
    }
    @{
        Name   = 'Deploy Admin Database to PostgreSQL'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Admin
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $params = @{
                engine              = $postgresSettings.ApiSettings.engine
                csb                 = $postgresSettings.ApiSettings.csbs[$connectionStringKey]
                database            = $databaseType
                filePaths           = $postgresSettings.ApiSettings.FilePaths
                subTypeNames        = $postgresSettings.ApiSettings.SubTypes
                dropDatabase        = $true
                standardVersion     = $StandardVersion
                extensionVersion    = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy @params
        }
    }
    @{
        Name   = 'Deploy Security Database to PostgreSQL'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Security
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $params = @{
                engine            = $postgresSettings.ApiSettings.engine
                csb               = $postgresSettings.ApiSettings.csbs[$connectionStringKey]
                database          = $databaseType
                filePaths         = $postgresSettings.ApiSettings.FilePaths
                subTypeNames      = $postgresSettings.ApiSettings.SubTypes
                dropDatabase      = $true
                standardVersion   = $StandardVersion
                extensionVersion  = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy @params
        }
    }
    @{
        Name   = 'Deploy Empty Template Database to PostgreSQL'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $params = @{
                engine            = $postgresSettings.ApiSettings.engine
                csb               = Get-DbConnectionStringBuilderFromTemplate -templateCSB $postgresSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods'
                database          = $databaseType
                filePaths         = $postgresSettings.ApiSettings.FilePaths
                subTypeNames      = $postgresSettings.ApiSettings.SubTypes
                dropDatabase      = $true
                standardVersion   = $StandardVersion
                extensionVersion  = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy @params
        }
    }
    @{
        Name   = 'Deploy Minimal Template Database to PostgreSQL'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $backupPath = Get-MinimalTemplateBackupPathFromSettings $postgresSettings
            $params = @{
                engine                  = $postgresSettings.ApiSettings.engine
                csb                     = Get-DbConnectionStringBuilderFromTemplate -templateCSB $postgresSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Minimal_Template'
                database                = $databaseType
                filePaths               = $postgresSettings.ApiSettings.FilePaths
                subTypeNames            = $postgresSettings.ApiSettings.SubTypes
                dropDatabase            = $true
                createByRestoringBackup = $backupPath
                standardVersion         = $StandardVersion
                extensionVersion        = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy @params
        }
    }
    @{
        Name   = 'Deploy Populated Template Database to PostgreSQL'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $backupPath = Get-PopulatedTemplateBackupPathFromSettings $postgresSettings
            $params = @{
                engine                  = $postgresSettings.ApiSettings.engine
                csb                     = Get-DbConnectionStringBuilderFromTemplate -templateCSB $postgresSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Populated_Template'
                database                = $databaseType
                filePaths               = $postgresSettings.ApiSettings.FilePaths
                subTypeNames            = $postgresSettings.ApiSettings.SubTypes
                dropDatabase            = $true
                createByRestoringBackup = $backupPath
                standardVersion         = $StandardVersion
                extensionVersion        = $ExtensionVersion
            }
            Initialize-EdFiDatabaseWithDbDeploy  @params
        }
    }
    @{
        Name   = 'Export Admin Database from SQLServer as .bak'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Admin
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $sqlServerSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Security Database from SQLServer as .bak'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Security
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $sqlServerSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Empty Template Database from SQLServer as .bak'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods'
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $sqlServerSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Minimal Template Database from SQLServer as .bak'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Minimal_Template'
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $sqlServerSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Populated Template Database from SQLServer as .bak'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Populated_Template'
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $sqlServerSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Admin Database from SQLServer as .bacpac'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Admin
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
            $databaseName = $csb['Database']
            $params = @{
                sqlPackagePath = $sqlPackagePath
                database       = $databaseName
                artifactOutput = (Join-Path $artifactPath 'EdFi_Admin.bacpac')
            }
            Export-BacPac @params
        }
    }
    @{
        Name   = 'Export Security Database from SQLServer as .bacpac'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Security
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = $sqlServerSettings.ApiSettings.csbs[$connectionStringKey]
            $databaseName = $csb['Database']
            $params = @{
                sqlPackagePath = $sqlPackagePath
                database       = $databaseName
                artifactOutput = (Join-Path $artifactPath 'EdFi_Security.bacpac')
            }
            Export-BacPac @params
        }
    }
    @{
        Name   = 'Export Empty Template Database from SQLServer as .bacpac'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods'
            $databaseName = $csb['Database']
            $params = @{
                sqlPackagePath = $sqlPackagePath
                database       = $databaseName
                artifactOutput = (Join-Path $artifactPath 'EdFi_Ods.bacpac')
            }
            Export-BacPac @params
        }
    }
    @{
        Name   = 'Export Minimal Template Database from SQLServer as .bacpac'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Minimal_Template'
            $databaseName = $csb['Database']
            $params = @{
                sqlPackagePath = $sqlPackagePath
                database       = $databaseName
                artifactOutput = (Join-Path $artifactPath 'EdFi_Ods_Minimal_Template.bacpac')
            }
            Export-BacPac @params
        }
    }
    @{
        Name   = 'Export Populated Template Database from SQLServer as .bacpac'
        Script = {
            $databaseType = $sqlServerSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $sqlServerSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $sqlServerSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Populated_Template'
            $databaseName = $csb['Database']
            $params = @{
                sqlPackagePath = $sqlPackagePath
                database       = $databaseName
                artifactOutput = (Join-Path $artifactPath 'EdFi_Ods_Populated_Template.bacpac')
            }
            Export-BacPac @params
        }
    }
    @{
        Name   = 'Export Admin Database from PostgreSQL as .sql'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Admin
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = $postgresSettings.ApiSettings.csbs[$connectionStringKey]
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $postgresSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Security Database from PostgreSQL as .sql'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Security
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = $postgresSettings.ApiSettings.csbs[$connectionStringKey]
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $postgresSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Empty Template Database from PostgreSQL as .sql'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $postgresSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods'
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $postgresSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Minimal Template Database from PostgreSQL as .sql'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $postgresSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Minimal_Template'
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $postgresSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name   = 'Export Populated Template Database from PostgreSQL as .sql'
        Script = {
            $databaseType = $postgresSettings.ApiSettings.DatabaseTypes.Ods
            $connectionStringKey = $postgresSettings.ApiSettings.ConnectionStringKeys[$databaseType]
            $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $postgresSettings.ApiSettings.csbs[$connectionStringKey] -replacementTokens 'Ods_Populated_Template'
            $params = @{
                databaseConnectionString = $csb
                databaseBackupName       = $csb['Database']
                backupDirectory          = $artifactPath
                multipleBackups          = $true
                engine                   = $postgresSettings.ApiSettings.Engine
            }
            Write-FlatHashtable $params
            Backup-DatabaseTemplate $params
        }
    }
    @{
        Name = 'Create Archives'
        Script = {
            if (-not (Get-InstalledModule | Where-Object -Property Name -eq '7Zip4Powershell')) {
                Install-Module -Force -Scope CurrentUser -Name 7Zip4Powershell
            }

            $filesToArchive = Get-ChildItem $artifactPath -Directory
            foreach ($file in $filesToArchive) {
                Write-Host "$($file.FullName) => $artifactPath/$($file.Name).zip"
                Compress-7Zip -Path $file.FullName -ArchiveFileName "$artifactPath/$($file.Name).zip" -Format Zip
            }
            Write-Host
        }
    }
    @{
        Name   = 'Create Cloud ODS .nuspec file'
        Script = {
            $nuspecPath = "$artifactPath/$packageName.nuspec"

            # Create a Nuspec file with an empty <files> element
            New-Nuspec -forceOverwrite -nuspecPath $nuspecPath -id $packageName -description $packageName -authors 'Ed-Fi Alliance' -owners 'Ed-Fi Alliance'

            $filesToPackage = (Get-ChildItem $artifactPath -Exclude *.nuspec | where { ! $_.PSIsContainer } | foreach { @{ source = $_.FullName; target = "." } })
            $filesToPackage.source | Write-Host

            # Add all files in the artifacts directory to the root of the nuspec package definition
            Add-FileToNuspec -nuspecPath $nuspecPath -sourceTargetPair $filesToPackage

            Write-Host
            Write-Host "Created $nuspecPath" -ForegroundColor Green
            Write-Host
        }
    }
)

$script:result = @()

$elapsed = Use-StopWatch {
    $script:result += Install-CodeGenUtility
    $script:result += Invoke-CodeGen
    $script:result += Install-DbDeploy

    foreach ($task in $deploymentTasks) {
        $script:result += Invoke-Task -name $task.Name -task $task.Script
    }
}

Test-Error

$script:result += New-TaskResult -name '-' -duration '-'
$script:result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format

return $script:result | Format-Table
