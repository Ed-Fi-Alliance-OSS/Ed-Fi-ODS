# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -version 5

$ErrorActionPreference = 'Stop'

$script:deploymentSettingsFiles = @()
$script:deploymentSettingsOverrides = @{ }

function Initialize-DeploymentEnvironment {
    <#
    .description
        Deploy databases from the EdFi.RestApi.Databases NuGet package created by ./prep-package.ps1
    .parameter PathResolverRepositoryOverride
        A semicolon-separated string of repositories to pass to path-resolver, such as 'Ed-Fi-ODS;Get-RepositoryRoot "Ed-Fi-ODS"'
    .parameter InstallType
        The type of deployment to install: 'Sandbox', 'SingleTenant' or 'MultiTenant'
    .parameter Engine
        The database engine provider, either 'SQLServer' or 'PostgreSQL'
    .parameter ExcludedExtensionSources
        A comma separated string of extensions sources to exclude from database deployment.
        Any values specified will be excluded from the resolved extension sources list.
        If no sources are passed then any resolved sources found by the artifact source resolver will be used.
    .parameter EnabledFeatureNames
        Any subtype features specified will be enabled.
    .parameter OdsTokens
        A semicolon-separated string of tokens to use when creating Ods database instances.
        For a year specific deployment a valid value could be '2013;2014;2015;2016;2017'.
        For a district specific deployment a valid value could be '255901;255902'.
    .parameter OdsDatabaseTemplateName
        Template to use when deploying Ods database. Allowed values: minimal, populated. Defaults to minimal.
    .parameter DropDatabases (Alias Transient)
        If supplied the database will be dropped without being backed up before being recreated from scripts and/or migrations.
        By default databases are not dropped and will be backup before being migrated when needed.
    .parameter NoDuration
        Turn off duration display
    .parameter UsePlugins
        Runs database scripts from downloaded plugin extensions in addition to extensions found in the Get-RepositoryRoot "Ed-Fi-ODS"
    .parameter StandardVersion
        Standard Version.
    .parameter ExtensionVersion
        Extension Version.
    .parameter MssqlSaPassword
        IMPORTANT: Only use this parameter for deployment in isolated, ephemeral environments (i.e. a disposable container in an isolated CI/CD pipeline.) 
                   This password will be stored as plain-text in connection strings and may be present in log files or other unprotected formats.
        When using SQLServer, the password for 'sa' user account, which will be used for all database connection, overriding all other authentication methods or credentials.
    #>
    param(
        [string] $PathResolverRepositoryOverride,

        [ValidateSet('Sandbox', 'SingleTenant', 'MultiTenant')]
        [string] $InstallType,

        [ValidateSet('SQLServer', 'PostgreSQL')]
        [String] $Engine,

        [string] $ExcludedExtensionSources,

        [string] $EnabledFeatureNames,

        [Alias('OdsYears')]
        [string[]] $OdsTokens,

        [ValidateSet("minimal", "populated")]
        [string] $OdsDatabaseTemplateName,

        [Alias('Transient')]
        [switch] $DropDatabases,

        [switch] $NoDuration,

        [switch] $UsePlugins,

        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [String] $StandardVersion,

        [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
        })]
        [String] $ExtensionVersion,

        [Parameter(Mandatory=$false)]
        [string] $MssqlSaPassword
    )

    # if path-resolver is not present assume that the script is being ran in a deployment scenario
    # from inside the EdFi.RestApi.Databases NuGet Package created by ./prep-package.ps1
    if (-not (Get-Module | Where-Object -Property Name -eq 'path-resolver')) {
        $pathResolver = (Get-ChildItem "$PSScriptRoot/*/logistics/scripts/modules/load-path-resolver.ps1" | Select-Object -Last 1)

        if ([string]::IsNullOrWhiteSpace($PathResolverRepositoryOverride)) {
            & $pathResolver
        }
        else {
            & $pathResolver ($PathResolverRepositoryOverride.Split(';'))
        }
        $env:toolsPath = (Join-Path (Get-RootPath) 'tools')
    }

    Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'DatabaseTemplate/Modules/database-template-source.psm1')
    Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/database-lifecycle.psm1')
    Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/settings/settings-management.psm1')
    Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")
    Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/tools/ToolsHelper.psm1')
    Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/hashtable.psm1')
    Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/plugin/plugin-source.psm1')

    Write-InvocationInfo $MyInvocation

    Clear-Error

    $script:deploymentSettingsFiles += @((Get-RepositoryResolvedPath 'configuration.packages.json'))

    if (!($script:deploymentSettingsFiles -like '*EdFi.Ods.WebApi/appsettings.json')){
        if ($Engine -eq 'PostgreSQL') {
            $script:deploymentSettingsFiles += @((Join-Path $PSScriptRoot 'configuration.postgreSQL.json'))
        }
        else {
            $script:deploymentSettingsFiles += @((Join-Path $PSScriptRoot 'configuration.json'))
        }
    }
    
    $settings = @{ ApiSettings = @{ NoDuration = $NoDuration.IsPresent } }

    if ($InstallType) { $settings.InstallType = $InstallType }
    if ($EnabledFeatureNames) { $settings.ApiSettings.EnabledFeatureNames = $EnabledFeatureNames }
    if ($ExcludedExtensionSources) { $settings.ApiSettings.ExcludedExtensionSources = $ExcludedExtensionSources }
    if ($Engine) { $settings.ApiSettings.Engine = $Engine }
    if ($OdsTokens) { $settings.ApiSettings.OdsTokens = $OdsTokens }
    if ($OdsDatabaseTemplateName) { $settings.ApiSettings.OdsDatabaseTemplateName = $OdsDatabaseTemplateName }
    if ($DropDatabases.IsPresent) { $settings.ApiSettings.DropDatabases = $DropDatabases.IsPresent }
    if ($UsePlugins.IsPresent) { $settings = (Merge-Hashtables $settings, (Get-EdFiDeveloperPluginSettings)) }
    if ($StandardVersion) { $settings.ApiSettings.StandardVersion = $StandardVersion }
    if ($ExtensionVersion) { $settings.ApiSettings.ExtensionVersion = $ExtensionVersion }
    if ($MssqlSaPassword) { $settings.MssqlSaPassword = $MssqlSaPassword }

    Set-DeploymentSettings $settings | Out-Null
    $settings = Get-DeploymentSettings
    Write-FlatHashtable $settings
    
    $script:result = @()

    $elapsed = Use-StopWatch {
        if (-not [string]::IsNullOrWhiteSpace((Get-DeploymentSettings).Plugin.Folder) -and -not (Test-TaskAlreadyInvoked("Install-Plugins"))) { $script:result += Install-Plugins }
        if ($null -eq (Get-DotNetTool $env:toolsPath "EdFi.Db.Deploy").Version) { $script:result += Install-DbDeploy }

        $script:result += Reset-AdminDatabase
        $script:result += Reset-SecurityDatabase

        if ($settings.InstallType -ne 'Sandbox') {
            $script:result += Reset-OdsDatabase
        }
        else {
            $script:result += Remove-SandboxDatabases
            $script:result += Reset-MinimalTemplateDatabase
            $script:result += Reset-PopulatedTemplateDatabase
        }
    }

    Test-Error

    if (-not $NoDuration) {
        $script:result += New-TaskResult -name '-' -duration '-'
        $script:result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format
        return $script:result | Format-Table
    }

    return $script:result
}

function Set-DeploymentSettingsFiles([string[]] $DeploymentSettingsFiles) {
    <#
    .description
        Sets the settings files to be used during deployment
    .parameter DeploymentSettingsFiles
        The full path to the settings files
        when using initdev this uses
            appsettings.json, appsettings.Development.json, appsettings.user.json from the EdFi.Ods.WebApi project
        when using EdFi.RestApi.Databases for deployment this uses
            Get-RepositoryRoot "Ed-Fi-ODS"/InstallerPackages/EdFi.RestApi.Databases/configuration.json
    #>

    $script:deploymentSettingsFiles = $DeploymentSettingsFiles

    return $script:deploymentSettingsFiles
}

function Get-DeploymentSettingsFiles {
    <#
    .description
        Returns the array of settings files
    #>

    return $script:deploymentSettingsFiles
}

function Set-DeploymentSettings([hashtable] $Settings = @{ }) {
    <#
    .description
        Configures values that will override any values coming from settings files
    .parameter Settings
        A hashtable containing any additional settings.
        Values set by this parameter will be merged overridding any previous values configured by this function.
    #>

    $script:deploymentSettingsOverrides = $Settings

    return $script:deploymentSettingsOverrides
}

function Get-DeploymentSettings {
    <#
    .synopsis
        Gets merged configuration values from the configuration file and any overrides
    .description
        Gets merged configuration values taking both the fresh values from the configuration file configured by the
        Set-DeploymentSettingsFiles function and overrides those values with any values configured through the Set-ApiSettings.
        This function should be called for every task that needs fresh values
        from a configuration file otherwise any configuration file changes will be ignored until the scripts are re-imported.
    #>

    $mergedSettings = Get-MergedAppSettings $script:deploymentSettingsFiles ((Get-ProjectTypes).WebApi)

    $mergedSettings = Merge-Hashtables $mergedSettings, $script:deploymentSettingsOverrides

    $defaultSettings = (Get-DefaultDevelopmentSettingsByProject)[((Get-ProjectTypes).WebApi)]

    if ([string]::IsNullOrWhiteSpace($mergedSettings.ApiSettings.Engine)) { $mergedSettings.ApiSettings.Engine = 'SQLServer' }
    $defaultSettings = Merge-Hashtables $defaultSettings, (Get-DefaultConnectionStringsByEngine)[$mergedSettings.ApiSettings.Engine]
    $defaultSettings = Merge-Hashtables $defaultSettings, (Get-DefaultTemplateSettingsByEngine)[$mergedSettings.ApiSettings.Engine]

    $defaultSettings = Add-ApplicationNameToConnectionStrings $defaultSettings ((Get-ProjectTypes).Databases)

    $mergedSettings = Merge-HashtablesOrDefaults $mergedSettings, $defaultSettings

    $mergedSettings = Add-DeploymentSpecificSettings $mergedSettings

    $mergedSettings = Update-DefaultDatabaseTemplate $mergedSettings

    if(-not [string]::IsNullOrEmpty($mergedSettings.MssqlSaPassword)) {
        $mergedSettings = Add-MssqlSqlLoginToConnectionStrings $mergedSettings 'sa' $mergedSettings.MssqlSaPassword
    }

    return $mergedSettings
}

function Install-Plugins { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }
function Install-DbDeploy { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }
function Reset-AdminDatabase { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }
function Reset-SecurityDatabase { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }
function Reset-OdsDatabase { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }
function Remove-SandboxDatabases { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }
function Reset-MinimalTemplateDatabase { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }
function Reset-PopulatedTemplateDatabase { Invoke-Task -name ($MyInvocation.MyCommand.Name) -task $deploymentTasks[$MyInvocation.MyCommand.Name] }


Set-Alias -Scope Global Reset-PopulatedTemplate Reset-PopulatedTemplateDatabase
Set-Alias -Scope Global Remove-Sandboxes Remove-SandboxDatabases
Set-Alias -Scope Global Reset-YearSpecificDatabase Reset-OdsDatabase

$deploymentTasks = @{
    'Install-Plugins'               = {
        $settings = Get-DeploymentSettings
        Get-Plugins $settings
    }
    'Install-DbDeploy'               = {
        $settings = Get-DeploymentSettings

        $packageSettings = $settings.packages['EdFi.Db.Deploy']
        $parameters = @{
            Name    = $packageSettings.packageName
            Version = $packageSettings.packageVersion
            Source  = @($packageSettings.packageSource, (Join-Path $env:toolsPath "CachedPackages"))
            Path    = $env:toolsPath
        }
        
        Install-DotNetTool @parameters
    }
    'Reset-AdminDatabase'             = {
        $settings = Get-DeploymentSettings
        $databaseType = $settings.ApiSettings.DatabaseTypes.Admin
        $connectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$databaseType]
        $databaseName = $databaseType
        $replacementTokens = @($databaseName)
        if ($settings.InstallType -eq 'MultiTenant') {
            foreach ($tenantKey in $settings.Tenants.keys) {
                $csb = New-Object System.Data.Common.DbConnectionStringBuilder
                $csb.set_ConnectionString($settings.Tenants[$tenantKey].ConnectionStrings[$connectionStringKey])
                write-host $csb
                Initialize-EdFiDatabase $settings $databaseType $csb
            }
        } else {
            $csb = $settings.ApiSettings.csbs[$connectionStringKey]
            Initialize-EdFiDatabase $settings $databaseType $csb
        }
    }
    'Reset-SecurityDatabase'          = {
        $settings = Get-DeploymentSettings
        $databaseType = $settings.ApiSettings.DatabaseTypes.Security
        $connectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$databaseType]
        $databaseName = $databaseType
        if ($settings.InstallType -eq 'MultiTenant') {
            foreach ($tenantKey in $settings.Tenants.keys) {
                $csb = New-Object System.Data.Common.DbConnectionStringBuilder
                $csb.set_ConnectionString($settings.Tenants[$tenantKey].ConnectionStrings[$connectionStringKey])
                write-host $csb
                Initialize-EdFiDatabase $settings $databaseType $csb
            }
        } else {
            $csb = $settings.ApiSettings.csbs[$connectionStringKey]
            Initialize-EdFiDatabase $settings $databaseType $csb
        }
    }
    'Reset-OdsDatabase'               = {
        $settings = Get-DeploymentSettings
        $databaseType = $settings.ApiSettings.DatabaseTypes.Ods
        $connectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$databaseType]
        $databaseName = $databaseType
        $replacementTokens = @($databaseName)
        if ($settings.ApiSettings.OdsDatabaseTemplateName -eq 'populated') {
            $backupPath = Get-PopulatedTemplateBackupPathFromSettings $settings
        }
        else {
            $backupPath = Get-MinimalTemplateBackupPathFromSettings $settings
        }
        if ($settings.ApiSettings.OdsTokens) { $replacementTokens = $settings.ApiSettings.OdsTokens -split ';' | ForEach-Object { "${databaseName}_$($_)" } }
        $csbs = Get-DbConnectionStringBuilderFromTemplate -templateCSB $settings.ApiSettings.csbs[$connectionStringKey] -replacementTokens $replacementTokens
        foreach ($csb in $csbs) { Initialize-EdFiDatabase $settings $databaseType $csb $backupPath }
    }
    'Remove-SandboxDatabases'         = {
        $settings = Get-DeploymentSettings
        $masterConnectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$settings.ApiSettings.DatabaseTypes.Master]
        $odsConnectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$settings.ApiSettings.DatabaseTypes.Ods]
        $masterCSB = $settings.ApiSettings.csbs[$masterConnectionStringKey]
        $templateCSB = $settings.ApiSettings.csbs[$odsConnectionStringKey]
        Remove-EdFiSandboxDatabases -masterCSB $masterCSB -edfiOdsTemplateCSB $templateCSB -Engine $settings.ApiSettings.engine
    }
    'Reset-MinimalTemplateDatabase'   = {
        $settings = Get-DeploymentSettings
        $settings.ApiSettings.DropDatabases = $true
        $databaseType = $settings.ApiSettings.DatabaseTypes.Ods
        $csb = (Get-DbConnectionStringBuilderFromTemplate -templateCSB $settings.ApiSettings.csbs[$settings.ApiSettings.ConnectionStringKeys[$databaseType]] -replacementTokens $settings.ApiSettings.minimalTemplateSuffix)
        $backupPath = Get-MinimalTemplateBackupPathFromSettings $settings
        Initialize-EdFiDatabase $settings $databaseType $csb $backupPath
    }
    'Reset-PopulatedTemplateDatabase' = {
        $settings = Get-DeploymentSettings
        $settings.ApiSettings.DropDatabases = $true
        $databaseType = $settings.ApiSettings.DatabaseTypes.Ods
        $csb = (Get-DbConnectionStringBuilderFromTemplate -templateCSB $settings.ApiSettings.csbs[$settings.ApiSettings.ConnectionStringKeys[$databaseType]] -replacementTokens $settings.ApiSettings.populatedTemplateSuffix)
        $backupPath = Get-PopulatedTemplateBackupPathFromSettings $settings
        Initialize-EdFiDatabase $settings $databaseType $csb $backupPath
    }
}

Export-ModuleMember -function * -Alias *
