# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -version 5

$ErrorActionPreference = 'Stop'

& "$PSScriptRoot/../../logistics/scripts/modules/load-path-resolver.ps1"
$implementationRepo = Get-Item "$PSScriptRoot/../.." | Select-Object -Expand Name
$env:toolsPath = $toolsPath = (Join-Path (Get-RepositoryRoot $implementationRepo) 'tools')

Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'DatabaseTemplate/Modules/create-minimal-template.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'DatabaseTemplate/Modules/create-populated-template.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'DatabaseTemplate/Modules/database-template-source.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/build-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/settings/settings-teamcity.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/config/config-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/database-lifecycle.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/database-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/postgres-database-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/create-package.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/nuget-helper.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/restore-packages.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/plugin/plugin-source.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/settings/settings-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'InstallerPackages/EdFi.RestApi.Databases/Deployment.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tools/ToolsHelper.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/utility/key-management.psm1")

Set-Alias -Scope Global Reset-PopulatedTemplateFromSamples Initialize-PopulatedTemplate
Set-Alias -Scope Global Reset-MinimalTemplateFromSamples Initialize-MinimalTemplate

Set-DeploymentSettingsFiles @(
    "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.json",
    "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.Development.json",
    (Get-RepositoryResolvedPath 'configuration.packages.json')
)

Set-DeploymentSettings @{ ApiSettings = @{ DropDatabases = $true } }

Set-Alias -Scope Global initdev Initialize-DevelopmentEnvironment
function Initialize-DevelopmentEnvironment {
    <#
    .description
        Builds the ODS/API solution and deploys the necessary databases in order to setup a complete development environment.
    .parameter InstallType
        The type of deployment to install: 'Sandbox', 'SingleTenant', 'MultiTenant'.
    .parameter OdsTokens
        A semicolon-separated string which requires single quotes or an array of strings for OdsTokens to use when creating Ods database instances.
        Example for Array of Strings in this format @("2021","2023")
        Example for semicolon-separated string which requires single quote in this format '2021;2023'
    .parameter Tenants
        A semicolon-separated string which requires single quotes or an array of strings for Tenants to use when InstallType is MultiTenant.
        Example for Array of Strings in this format @("Tenant1","Tenant2")
        Example for semicolon-separated string which requires single quote in this format 'Tenant1;Tenant2'
    .parameter Engine
        The database engine provider, either "SQLServer" or "PostgreSQL".
    .parameter NoRebuild
        Skip the Invoke-RebuildSolution task which uses MSBuild to rebuild the main solution file: Get-RepositoryRoot "Ed-Fi-ODS"/Application/Ed-Fi-Ods.sln.
    .parameter NoRestore
        Ignore the Restoring Nuget package on Invoke-RebuildSolution task which uses MSBuild to rebuild the main solution file: Get-RepositoryRoot "Ed-Fi-ODS"/Application/Ed-Fi-Ods.sln.
    .parameter NoCodeGen
        Skip the Invoke-CodeGen task which is to generate artifacts consumed by the api.
    .parameter NoDeploy
        Skip the Initialize-DeploymentEnvironment task which is primarily used to setup developer/production environments. Mainly used by continuous integration.
    .parameter RunPester
        Runs the Invoke-PesterTests task which will run the Pester tests in addition to the other initdev pipeline tasks.
    .parameter RunDotnetTest
        Runs the dotnet tests for the main solution file: Get-RepositoryRoot "Ed-Fi-ODS"/Application/Ed-Fi-Ods.sln.
    .parameter RunPostman
        Runs the Invoke-PostmanIntegrationTests task which will run the Postman integration tests in addition to the other initdev pipeline tasks.
    .parameter RunSmokeTest
        Runs the Invoke-SmokeTests task which will run the smoke tests, against the in-memory api, in addition to the other initdev pipeline tasks.
    .parameter RunSdkGen
        Runs the Invoke-SdkGen task which will build and run the sdk gen console
    .parameter GenerateApiSdkPackage
        Generates ApiSdk package after running SdkGen
    .parameter GenerateTestSdkPackage
        Generates TestSdk package after running SdkGen
    .parameter UsePlugins
        Runs database scripts from downloaded plugin extensions in addition to extensions found in the Get-RepositoryRoot "Ed-Fi-ODS".
    .parameter PackageVersion
        Package version passed from CI that is used in Invoke-SdkGen
    .parameter MssqlSaPassword
        IMPORTANT: Only use this parameter for deployment in isolated, ephemeral environments (i.e. a disposable container in an isolated CI/CD pipeline.) 
                   This password will be stored as plain-text in connection strings and may be present in log files or other unprotected formats.
        When using SQLServer, the password for 'sa' user account, which will be used for all database connection, overriding all other authentication methods or credentials.
    .parameter LocalDbBackupDirectory
        A locally accessable path mapped to the backup file directory used by a containerized SQLServer instance
    .parameter DbServerBackupDirectory
        A directory, within the filesystem of a containerized SQLServer instance, to which the database engine should write backup files
    .parameter StandardVersion
        Standard Version.
    .parameter ExtensionVersion
        Extension Version.
	.parameter JavaPath
        Path to the java executable (used for SDK generation).
    #>
    param(
        [ValidateSet('Sandbox', 'SingleTenant', 'MultiTenant')]
        [Parameter(Mandatory=$false)]
        [string] $InstallType = 'Sandbox',

        [Alias('OdsYears')]
        [Parameter(Mandatory=$false)]
        [string[]] $OdsTokens,
        
        [Parameter(Mandatory=$false)]
        [string[]] $Tenants,

        [ValidateSet('SQLServer', 'PostgreSQL')]
        [Parameter(Mandatory=$false)]
        [String] $Engine = 'SQLServer',

        [Alias('NoCompile')]
        [Parameter(Mandatory=$false)]
        [switch] $NoRebuild,

        [Parameter(Mandatory=$false)]
        [switch] $NoRestore,

        [Alias('NoCodeGen')]
        [Parameter(Mandatory=$false)]
        [switch] $ExcludeCodeGen,

        [Parameter(Mandatory=$false)]
        [switch] $NoDeploy,

        [Parameter(Mandatory=$false)]
        [switch] $RunPester,

        [Parameter(Mandatory=$false)]
        [switch] $RunDotnetTest,

        [Parameter(Mandatory=$false)]
        [switch] $RunPostman,

        [Parameter(Mandatory=$false)]
        [switch] $RunSmokeTest,

        [Parameter(Mandatory=$false)]
        [switch] $RunSdkGen,

        [Parameter(Mandatory=$false)]
        [switch] $GenerateApiSdkPackage,

        [Parameter(Mandatory=$false)]
        [switch] $GenerateTestSdkPackage,

        [Parameter(Mandatory=$false)]
        [switch] $UsePlugins,

        [Parameter(Mandatory=$false)]
        [String] $RepositoryRoot,

        [Parameter(Mandatory=$false)]
        [string] $PackageVersion,

        [Parameter(Mandatory=$false)]
        [string] $MssqlSaPassword,

        [Parameter(Mandatory=$false)]
        [string] $LocalDbBackupDirectory,

        [Parameter(Mandatory=$false)]
        [string] $DbServerBackupDirectory,

        [Parameter(Mandatory=$false)]
        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [String] $StandardVersion = '6.0.0',

        [Parameter(Mandatory=$false)]
        [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
        })]
        [String] $ExtensionVersion = '1.1.0',
		
		[Parameter(Mandatory=$false)]
        [String] $JavaPath
    )

    if ((-not [string]::IsNullOrWhiteSpace($OdsTokens)) -and ($InstallType -ine 'SingleTenant') -and ($InstallType -ine 'MultiTenant')) {
        throw "The OdsTokens parameter can only be used with the 'SingleTenant' or 'MultiTenant' InstallType."
    }
    
    if (($InstallType -eq 'MultiTenant') -and ([string]::IsNullOrWhiteSpace($Tenants))) {
        throw "The Tenants parameter is required with the 'MultiTenant' InstallType."
    }

    if ((-not [string]::IsNullOrEmpty($MssqlSaPassword)) -and ($Engine -ne 'SQLServer')) {
        throw "The MssqlSaPassword parameter can only be used with the 'SQLServer' Engine."
    }

    Clear-Error

    $script:result = @()

    $elapsed = Use-StopWatch {

        $settings = @{ ApiSettings = @{ } }

        if ($InstallType) { $settings.InstallType = $InstallType }
        if ($OdsTokens) { $settings.ApiSettings.OdsTokens = $OdsTokens }
        if ($Tenants) { $settings.ApiSettings.Tenants = $Tenants }
        if ($Engine) { $settings.ApiSettings.Engine = $Engine }
        if ($StandardVersion) { $settings.ApiSettings.StandardVersion = $StandardVersion }
        if ($ExtensionVersion) { $settings.ApiSettings.ExtensionVersion = $ExtensionVersion }
        if ($MssqlSaPassword) { $settings.MssqlSaPassword = $MssqlSaPassword }
        if ($DbServerBackupDirectory) { $settings.DbServerBackupDirectory = $DbServerBackupDirectory }
        if ($LocalDbBackupDirectory) { $settings.LocalDbBackupDirectory = $LocalDbBackupDirectory }
        Set-DeploymentSettings $settings | Out-Null

        if ($UsePlugins.IsPresent) { $settings = (Merge-Hashtables $settings, (Get-EdFiDeveloperPluginSettings)) }

        $settingsFile = "$(Get-RepositoryResolvedPath 'Application/EdFi.Ods.WebApi')/appsettings.json"
        $appsettings = Get-Content $settingsFile | ConvertFrom-Json | ConvertTo-Hashtable

        $pluginFolderPath = $appsettings.Plugin.Folder
        if ((-not [string]::IsNullOrWhiteSpace($pluginFolderPath)) -AND (($pluginFolderPath -eq './Plugin') -OR ($pluginFolderPath -eq '../../Plugin'))) { 
            $settings = (Merge-Hashtables $settings, (Get-EdFiDeveloperPluginFolder))
        }
        
        $global:InvokedTasks = $null
        $script:result += Invoke-NewDevelopmentAppSettings $settings

        if (-not [string]::IsNullOrWhiteSpace((Get-DeploymentSettings).Plugin.Folder)) { $script:result += Install-Plugins }

        if (-not $ExcludeCodeGen) { $script:result += Invoke-CodeGen -Engine $Engine -RepositoryRoot $RepositoryRoot -StandardVersion $StandardVersion -ExtensionVersion $ExtensionVersion }

        Write-Host -ForegroundColor Magenta "Invoke-RebuildSolution NoRestore is " $noRestore

        if (-not $NoRebuild) {
            if (-not $NoRestore) {
                $script:result += Invoke-RebuildSolution  -buildConfiguration "Debug"  -verbosity "minimal" -solutionPath (Get-RepositoryResolvedPath "Application/Ed-Fi-Ods.sln") -noRestore $false -standardVersion $StandardVersion
            }
            else {
                $script:result += Invoke-RebuildSolution -standardVersion $StandardVersion
            }
        }

        $script:result += Install-DbDeploy
        $script:result += Reset-TestAdminDatabase
        $script:result += Reset-TestSecurityDatabase

        if (-not ($NoDeploy)) {
            $script:result += Reset-TestPopulatedTemplateDatabase

            $params = @{
                InstallType   = $InstallType
                Engine        = $Engine
                OdsTokens     = $OdsTokens
                DropDatabases = $true
                NoDuration    = $true
                UsePlugins    = $UsePlugins.IsPresent
                MssqlSaPassword = $MssqlSaPassword
            }
            $script:result += Initialize-DeploymentEnvironment @params
        }

        if ($RunPester) { $script:result += Invoke-PesterTests }

        if ($RunDotnetTest) { $script:result += Invoke-DotnetTest }

        if ($RunPostman) { $script:result += Invoke-PostmanIntegrationTests }

        if ($RunSmokeTest) { $script:result += Invoke-SmokeTests }

        if ($RunSdkGen) { $script:result += Invoke-SdkGen $GenerateApiSdkPackage $GenerateTestSdkPackage $PackageVersion $NoRestore $StandardVersion $JavaPath }
    }

    $script:result += New-TaskResult -name '-' -duration '-'
    $script:result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format

    return $script:result | Format-Table
}

function Get-RandomString {
    [Obsolete("This function is deprecated, and will be removed in the near future.")]
    Param(
        [int] $length = 20
    )

    return ([char[]]([char]65..[char]90) + ([char[]]([char]97..[char]122)) + 0..9 | Sort-Object { Get-Random })[0..$length] -join ""
}

function Invoke-NewDevelopmentAppSettings([hashtable] $Settings = @{ }) {
    <#
    .description
        Generates appsettings.Development.json for the following projects:
            EdFi.Ods.WebApi
            EdFi.Ods.Api.IntegrationTestHarness
            EdFi.Ods.SandboxAdmin.Web
            EdFi.Ods.SwaggerUI
        See the Get-DefaultDevelopmentSettingsByProject in settings-managements.psm1 for the default settings.
    #>
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        $newSettingsFiles = New-DevelopmentAppSettings $Settings

        Write-Host 'created settings files:' -ForegroundColor Green
        $newSettingsFiles | Write-Host

        Write-Host
        Write-Host 'initdev is now using the following settings files:' -ForegroundColor Green
        $results = Assert-ValidAppSettings (Get-DeploymentSettingsFiles)
        foreach ($result in $results) {
            if ($result.success) {
                Write-Host $result.file -NoNewline
                Write-Host " ok" -ForegroundColor Green
            }
            elseif (-not $result.success) {
                Write-Host $result.file -ForegroundColor Red
                Write-Host $result.exception -ForegroundColor Red
            }
        }
        if ($results | where { $null -ne $_.exception }) { throw "invalid appsettings found" }

        Write-Host
        Write-Host 'initdev is now using the following settings:' -ForegroundColor Green
        Write-FlatHashtable (Get-DeploymentSettings)

        Write-Warning "The following settings are being overridden by the $(Split-Path -Leaf (Get-ProjectTypes).WebApi) project's user secrets:"
        Write-FlatHashtable (Get-UserSecrets ((Get-ProjectTypes).WebApi))
    }
}

Set-Alias -Scope Global Rebuild-Solution Invoke-RebuildSolution
Function Invoke-RebuildSolution {
    Param(
        [string] $buildConfiguration = "Debug",
        [string] $verbosity = "minimal",
        [string] $solutionPath = (Get-RepositoryResolvedPath "Application/Ed-Fi-Ods.sln"),
        [Boolean] $noRestore = $false,
        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [string]  $standardVersion
    )
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        if ((Get-DeploymentSettings).Engine -eq 'PostgreSQL') { $buildConfiguration = 'Npgsql' }
        if (-not [string]::IsNullOrWhiteSpace($env:msbuild_buildConfiguration)) { $buildConfiguration = $env:msbuild_buildConfiguration }

        $params = @{
            Path               = $solutionPath
            BuildConfiguration = $buildConfiguration
            LogVerbosityLevel  = $verbosity
            noRestore          = $noRestore
            standardVersion    = $StandardVersion
        }

        ($params).GetEnumerator() | Sort-Object -Property Name | Format-Table -HideTableHeaders -AutoSize -Wrap | Out-Host

        $BuildLogDirectoryPath = (Get-Location)

        $solutionFileName = (Get-ItemProperty -LiteralPath $solutionPath).Name
        $buildLogFilePath = (Join-Path -Path $BuildLogDirectoryPath -ChildPath $solutionFileName) + ".msbuild.log"

        Write-Host -ForegroundColor Magenta "& dotnet build $solutionPath -c $buildConfiguration -v $verbosity /flp:v=$verbosity /flp:logfile=$buildLogFilePath"
        if ($noRestore) {
            & dotnet build $solutionPath -c $buildConfiguration -v $verbosity /flp:v=$verbosity /flp:logfile=$buildLogFilePath --no-restore -p:StandardVersion=$StandardVersion | Out-Host
        }
        else
        {
            & dotnet build $solutionPath -c $buildConfiguration -v $verbosity /flp:v=$verbosity /flp:logfile=$buildLogFilePath  -p:StandardVersion=$StandardVersion | Out-Host
        }

        # If we can't find the build's log file in order to inspect it, write a warning and return null.
        if (!(Test-Path -LiteralPath $buildLogFilePath -PathType Leaf)) {
            Write-Warning ("Cannot find the build log file at '$buildLogFilePath', so unable to determine if build succeeded or not.")
            return
        }

        # Get if the build succeeded or not.
        [bool] $buildFailed = (Select-String -Path $buildLogFilePath -Pattern "Build FAILED." -SimpleMatch -Quiet)

        if ($buildFailed) {
            Write-Host 'Ensure that the Visual Studio SDK is installed.'
            throw "Build failed. Check the build log file '$buildLogFilePath' for errors."
        }

        return
    }
}

function Reset-EmptySandboxDatabase {
    Invoke-Task -name ($MyInvocation.MyCommand.Name) -task {
        $settings = Get-DeploymentSettings
        $settings.ApiSettings.DropDatabases = $true
        $databaseType = $settings.ApiSettings.DatabaseTypes.Ods
        $csb = Get-DbConnectionStringBuilderFromTemplate -templateCSB $settings.ApiSettings.csbs[$settings.ApiSettings.ConnectionStringKeys[$databaseType]] -replacementTokens 'Ods_Sandbox_Empty'
        Initialize-EdFiDatabase $settings $databaseType $csb
    }
}

function Reset-TestAdminDatabase {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        $settings = Get-DeploymentSettings
        # turn on all available features for the test database to ensure all the schema components are available
        $settings.ApiSettings.SubTypes = Get-DefaultSubtypes
        $settings.ApiSettings.DropDatabases = $true
        $databaseType = $settings.ApiSettings.DatabaseTypes.Admin
        $connectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$databaseType]
        $databaseName = $databaseType
        $replacementTokens = @("$($databaseName)_Test")
        if ($settings.InstallType -eq 'MultiTenant') { $replacementTokens = $settings.Tenants.Keys | ForEach-Object { "${databaseName}_$($_)_Test" } }
        $csbs = Get-DbConnectionStringBuilderFromTemplate -templateCSB $settings.ApiSettings.csbs[$connectionStringKey] -replacementTokens $replacementTokens
        foreach ($csb in $csbs) { Initialize-EdFiDatabase $settings $databaseType $csb }
    }
}

function Reset-TestSecurityDatabase {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        $settings = Get-DeploymentSettings
        # turn on all available features for the test database to ensure all the schema components are available
        $settings.ApiSettings.SubTypes = Get-DefaultSubtypes
        $settings.ApiSettings.DropDatabases = $true
        $databaseType = $settings.ApiSettings.DatabaseTypes.Security
        $connectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$databaseType]
        $databaseName = $databaseType
        $replacementTokens = @("$($databaseName)_Test")
        if ($settings.InstallType -eq 'MultiTenant') { $replacementTokens = $settings.Tenants.Keys | ForEach-Object { "${databaseName}_$($_)_Test" } }
        $csbs = Get-DbConnectionStringBuilderFromTemplate -templateCSB $settings.ApiSettings.csbs[$connectionStringKey] -replacementTokens $replacementTokens
        foreach ($csb in $csbs) { Initialize-EdFiDatabase $settings $databaseType $csb }
    }
}

Set-Alias -Scope Global Reset-TestPopulatedTemplate Reset-TestPopulatedTemplateDatabase
# deploy separate database used by the ODS/API tests
function Reset-TestPopulatedTemplateDatabase {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        $settings = Get-DeploymentSettings
        $replacementTokens = @("$($settings.ApiSettings.populatedTemplateSuffix)_Test")
        # turn on all available features for the test database to ensure all the schema components are available
        $settings.ApiSettings.SubTypes = Get-DefaultSubtypes
        $settings.ApiSettings.DropDatabases = $true
        $databaseType = $settings.ApiSettings.DatabaseTypes.Ods
        $connectionStringKey = $settings.ApiSettings.ConnectionStringKeys[$databaseType]
        if ($settings.InstallType -eq 'MultiTenant') { $replacementTokens = $settings.Tenants.Keys | ForEach-Object { "$($settings.ApiSettings.populatedTemplateSuffix)_$($_)_Test" } }
        $csbs = Get-DbConnectionStringBuilderFromTemplate -templateCSB $settings.ApiSettings.csbs[$connectionStringKey] -replacementTokens $replacementTokens
        $createByRestoringBackup = Get-PopulatedTemplateBackupPathFromSettings $settings
        foreach ($csb in $csbs) { Initialize-EdFiDatabase $settings $databaseType $csb $createByRestoringBackup }
    }
}

Set-Alias -Scope Global Run-CodeGen Invoke-CodeGen
function Invoke-CodeGen {
    <#
    .description
        Generates the solution and extensions code.
    .parameter Engine
        The database engine provider, either "SQLServer" or "PostgreSQL".
    .parameter ExtensionPaths
        Array of paths for the extension location, required only if extensions are located outside the CodeRepositoryPath.
    .parameter RepositoryRoot
        Path to the code repository where the ODS is located.
    .parameter StandardVersion
        EdFi Standard Version.
    .parameter ExtensionVersion
        Extension Version. Required only if the extension version is different than 1.0.0 .
    #>
    param(
        [ValidateSet('SQLServer', 'PostgreSQL')]
        [String] $Engine,
        
        [string[]] $ExtensionPaths,
        
        [String] $RepositoryRoot,
        
        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [Parameter(Mandatory=$true)]
        [string] $StandardVersion,
        
        [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
        })]
        [Parameter(Mandatory=$true)]
        [string] $ExtensionVersion
    )

    Install-CodeGenUtility

    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        if ([string]::IsNullOrEmpty($Engine)) {
            $Engine = (Get-DeploymentSettings).ApiSettings.Engine
        }

        $codeGen = (Join-Path $toolsPath 'EdFi.Ods.CodeGen')

        if ([string]::IsNullOrEmpty($RepositoryRoot)) {
            $RepositoryRoot = (Get-RepositoryRoot $implementationRepo).Replace($implementationRepo, '')
        }

        $parameters = @(
            "-r", $RepositoryRoot,
            "-e", $Engine,
            "--standardVersion", $StandardVersion,
            "--extensionVersion", $ExtensionVersion
        )
        
        if ($ExtensionPaths.Length -gt 0) {
            $parameters += "--ExtensionPaths"
            $parameters += $ExtensionPaths
        }
        
        Write-Host -ForegroundColor Magenta "& $codeGen $parameters"
        & $codeGen $parameters | Out-Host
    }
}

function Install-DbDeploy {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        $settings = Get-DeploymentSettings

        $packageSettings = $settings.packages['EdFi.Db.Deploy']
        $parameters = @{
            Name    = $packageSettings.packageName
            Version = $packageSettings.packageVersion
            Source  = $packageSettings.packageSource
        }
        if ([string]::IsNullOrWhiteSpace($parameters.Path)) { $parameters.Path = $toolsPath }
        Install-DotNetTool @parameters
    }
}

function Install-CodeGenUtility {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        $settings = Get-DeploymentSettings

        $packageSettings = $settings.packages['EdFi.Ods.CodeGen']
        $parameters = @{
            Name    = $packageSettings.packageName
            Version = $packageSettings.packageVersion
            Source  = $packageSettings.packageSource
        }
        if ([string]::IsNullOrWhiteSpace($parameters.Path)) { $parameters.Path = $toolsPath }
        Install-DotNetTool @parameters
    }
}

function Invoke-PesterTests {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {

        $pester = Get-InstalledModule | ? -Property Name -eq "Pester"

        if ($null -eq $pester) {
            Write-Host "Installing Pester"
            Install-Module -Name Pester -Scope CurrentUser -MinimumVersion 5.3.3 -Force -SkipPublisherCheck | Out-Null
        }

        $reports = (Get-RepositoryRoot "Get-RepositoryRoot "Ed-Fi-ODS"") + "/reportsNUnit"

        if (Test-Path $reports) {
            Remove-Item -Path $reports -Force -Recurse
        }

        New-Item -ItemType Directory -Force -Path $reports

        $config = @{
            Run = @{
                Exit = $true
            }
            TestResult = @{ 
                Enabled = $true
                OutputPath  = $reports + "/PesterTestResults.xml"
            }
            Output = @{
                Verbosity = "Detailed"
            }
        }

        Invoke-Pester -Configuration $config
    }
}

function Invoke-PostmanIntegrationTests {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        & (Get-RepositoryResolvedPath "logistics/scripts/Invoke-PostmanIntegrationTests.ps1")
    }
}

function Invoke-SdkGen {
    param(
        [Boolean] $GenerateApiSdkPackage,
        [Boolean] $GenerateTestSdkPackage,
        [string] $PackageVersion,
        [Boolean] $NoRestore,
        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [String] $StandardVersion,
		[String] $JavaPath
    )
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        & $(Get-RepositoryResolvedPath "logistics/scripts/Invoke-SdkGen.ps1") -generateApiSdkPackage $GenerateApiSdkPackage -generateTestSdkPackage $GenerateTestSdkPackage -packageVersion $PackageVersion -noRestore $NoRestore -standardVersion $StandardVersion -javaPath $JavaPath
    }
}

function Invoke-SmokeTests {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        & (Get-RepositoryResolvedPath "logistics/scripts/run-smoke-tests.ps1") -testHarnessLogNamePrefix "SmokeTests"
    }
}

function Invoke-DotnetTest {
    Invoke-Task -name $MyInvocation.MyCommand.Name -task {
        & (Get-RepositoryResolvedPath "logistics/scripts/run-tests.ps1")
    }
}

function Get-DefaultNuGetProperties {
    $buildConfiguration = 'Debug'
    if (-not [string]::IsNullOrWhiteSpace($env:msbuild_buildConfiguration)) { $buildConfiguration = $env:msbuild_buildConfiguration }

    return @(
        "authors=Ed-Fi Alliance"
        "owners=Ed-Fi Alliance"
        "copyright=Copyright @ " + $((Get-Date).year) + " Ed-Fi Alliance, LLC and Contributors"
        "configuration=$buildConfiguration"
    )
}

function New-DatabasesPackage {
    param(
        [string] $ProjectPath,

        [string] $PackageId,

        [string] $Version,

        [string[]] $Properties = @(),

        [string] $OutputDirectory,

        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [string] $StandardVersion

    )

    Invoke-Task -name "$($MyInvocation.MyCommand.Name) ($(Split-Path $ProjectPath -Leaf))" -task {
        if ([string]::IsNullOrWhiteSpace($PackageId)) { $PackageId = (Split-Path $ProjectPath -Leaf) }

        Write-Host -ForegroundColor Magenta "& `"$ProjectPath/prep-package.ps1`" $PackageId $StandardVersion"
        & "$ProjectPath/prep-package.ps1" $PackageId $StandardVersion
        Write-Host

        $params = @{
            PackageDefinitionFile = (Get-ChildItem "$ProjectPath/$PackageId.nuspec")
            PackageId             = $PackageId
            Version               = $Version
            Properties            = $Properties
            OutputDirectory       = $OutputDirectory
        }
        New-Package @params | Out-Host
    }
}

function New-WebPackage {
    param(

        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [string] $StandardVersion,

        [string] $ProjectPath,

        [string] $PackageDefinitionFile = "$ProjectPath/bin/*/*/publish/$(Split-Path $ProjectPath -Leaf).nuspec",

        [string] $PackageId,

        [string] $Version,

        [string[]] $Properties = @(),

        [string] $OutputDirectory`
    )

    Invoke-Task -name "$($MyInvocation.MyCommand.Name) ($(Split-Path $ProjectPath -Leaf))" -task {

        $buildConfiguration = 'Debug'
        if (-not [string]::IsNullOrWhiteSpace($env:msbuild_buildConfiguration)) { $buildConfiguration = $env:msbuild_buildConfiguration }

        $params = @(
            "publish", $ProjectPath,
            "--configuration", $buildConfiguration,
            "--no-restore",
            "-p:StandardVersion=$StandardVersion"
        )

        Write-Host -ForegroundColor Magenta "& dotnet $params"
        & dotnet $params | Out-Host
        Write-Host

        $PackageDefinitionFile = (Get-ChildItem $PackageDefinitionFile)
        if (-not [string]::IsNullOrWhiteSpace($PackageId)) {
            [xml] $xml = Get-Content $PackageDefinitionFile
            $xml.package.metadata.id = $PackageId
            $xml.Save($PackageDefinitionFile)
        }

        $params = @{
            PackageDefinitionFile = $PackageDefinitionFile
            Version               = $Version
            Properties            = $Properties
            OutputDirectory       = $OutputDirectory
        }

        New-Package @params | Out-Host
    }
}

Export-ModuleMember -Function * -Alias *
