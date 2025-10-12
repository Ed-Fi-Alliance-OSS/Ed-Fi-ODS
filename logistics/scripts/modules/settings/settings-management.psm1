# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/hashtable.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/config/config-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/plugin/plugin-source.psm1')

function Get-ProjectTypes {
    return @{
        WebApi                 = 'Application/EdFi.Ods.WebApi'
        SandboxAdmin           = 'Application/EdFi.Ods.SandboxAdmin'
        SwaggerUI              = 'Application/EdFi.Ods.SwaggerUI'
        Databases              = 'InstallerPackages/EdFi.RestApi.Databases'
    }
}

function Get-TestProjectTypes {
    return @{
        IntegrationTestHarness      = 'Application/EdFi.Ods.Api.IntegrationTestHarness'
        NHibernateTests             = 'Application/EdFi.Ods.Repositories.NHibernate.Tests'
        OdsUnitTests                = 'Application/EdFi.Ods.Tests'
        ApiIntegrationTests         = 'tests/EdFi.Ods.Api.IntegrationTests'
        CompositeSpecFlowTests      = 'tests/EdFi.Ods.WebApi.CompositeSpecFlowTests'
        WebApiIntegrationTests      = 'tests/EdFi.Ods.WebApi.IntegrationTests'
        AdminDataAccessIntegrationTests  = 'tests/EdFi.Admin.DataAccess.IntegrationTests'
        SecurityDataAccessIntegrationTests  = 'tests/EdFi.Security.DataAccess.IntegrationTests'
    }
}

function Get-DefaultDevelopmentSettingsByProject {
    return @{
        ((Get-ProjectTypes).WebApi)                 = @{
            Urls              = "http://localhost:54746"
            ApiSettings       = @{
                Engine           = ""
                PlainTextSecrets = $true
                StandardVersion  = ""
                ExtensionVersion  = ""
            }
            ConnectionStrings = @{ }
            Logging           = @{
                LogLevel = @{
                    Default = "Debug"
                }
            }
        }
        ((Get-ProjectTypes).SandboxAdmin)           = @{
            Urls                         = "http://localhost:38928"
            ApiSettings                  = @{
                Engine = ""
            }
            ConnectionStrings            = @{ }
            Logging                      = @{
                LogLevel = @{
                    Default = "Debug"
                }
            }
            OAuthUrl                     = "http://localhost:54746/oauth/"
            DefaultOperationalContextUri = "uri://ed-fi-api-host.org"
            MailSettings                 = @{
                Smtp = @{
                    UserName                 = "Bingo"
                    Password                 = "Tingo"
                    DeliveryMethod           = "SpecifiedPickupDirectory"
                    From                     = "noreply@ed-fi.org"
                    SpecifiedPickupDirectory = @{
                        PickupDirectoryLocation = "./Artifacts/Emails"
                    }

                }
            }
        }
        ((Get-ProjectTypes).SwaggerUI)              = @{
            Urls             = "http://localhost:56641"
            WebApiVersionUrl = "http://localhost:54746"
            Logging          = @{
                LogLevel = @{
                    Default = "Debug"
                }
            }
        }
        ((Get-TestProjectTypes).IntegrationTestHarness) = @{
            Urls              = "http://localhost:8765"
            ApiSettings       = @{
                Engine = ""
                StandardVersion  = ""
                ExtensionVersion  = ""
            }
            ConnectionStrings = @{ }
        }
        ((Get-TestProjectTypes).NHibernateTests) = @{
            ApiSettings       = @{
                Engine = ""
            }
            ConnectionStrings = @{ }
        }
        ((Get-TestProjectTypes).ApiIntegrationTests) = @{
            ApiSettings       = @{
                Engine = ""
            }
            ConnectionStrings = @{ }
        }
        ((Get-TestProjectTypes).CompositeSpecFlowTests) = @{
            ApiSettings       = @{
                Engine = ""
            }
            ConnectionStrings = @{ }
        }
        ((Get-TestProjectTypes).WebApiIntegrationTests) = @{
            ApiSettings       = @{
                Engine = ""
            }
            ConnectionStrings = @{ }
        }
        ((Get-TestProjectTypes).AdminDataAccessIntegrationTests) = @{
            ApiSettings       = @{
                Engine = ""
            }
            ConnectionStrings = @{ }
        }
        ((Get-TestProjectTypes).SecurityDataAccessIntegrationTests) = @{
            ApiSettings       = @{
                Engine = ""
            }
            ConnectionStrings = @{ }
        }
        ((Get-TestProjectTypes).OdsUnitTests) = @{
            ApiSettings       = @{
                Engine = ""
            }
            ConnectionStrings = @{ }
        }
    }
}

function Get-CredentialSettingsByProject {

    function Get-RandomString([int] $length = 20) {
        return ([char[]]([char]65..[char]90) + ([char[]]([char]97..[char]122)) + 0..9 | Sort-Object { Get-Random })[0..$length] -join ''
    }

    $populatedKey = Get-RandomString
    $populatedSecret = Get-RandomString

    return @{
        ((Get-ProjectTypes).SandboxAdmin) = @{
            User = @{
                "Test Admin" = @{
                    Email             = "test@ed-fi.org"
                    Password          = Get-RandomString
                    Admin             = "true"
                    NamespacePrefixes = @(
                        "uri://ed-fi.org"
                        "uri://gbisd.edu"
                        "uri://tpdm.ed-fi.org"
                    )
                    Sandboxes         = @{
                        "Populated Demonstration Sandbox" = @{
                            Key     = $populatedKey
                            Secret  = $populatedSecret
                            Type    = "Sample"
                            Refresh = "false"
                        }
                        "Minimal Demonstration Sandbox"   = @{
                            Key     = Get-RandomString
                            Secret  = Get-RandomString
                            Type    = "Minimal"
                            Refresh = "false"
                        }
                    }
                }
            }
        }
        ((Get-ProjectTypes).SwaggerUI)    = @{
            SwaggerUIOptions = @{
                OAuthConfigObject = @{
                    ClientId     = $populatedKey
                    ClientSecret = $populatedSecret
                }
            }
        }
    }
}

function Get-EdFiDeveloperPluginSettings {
    return @{
        Plugin = @{
            Folder  = "../../Plugin"
            Scripts = @("sample", "homograph", "tpdm", "profiles.sample", "studentTranscript.sample")
        }
    }
}

function Get-EdFiDeveloperPluginFolder {
    return @{
        Plugin = @{
            Folder  = "../../Plugin"
        }
    }
}

function Get-DatabaseTypes {
    return @{
        Ods      = 'Ods'
        Admin    = 'Admin'
        Security = 'Security'
        Master   = 'Master'
    }
}

function Get-ConnectionStringKeyByDatabaseTypes {
    return @{
        (Get-DatabaseTypes).Ods      = 'EdFi_Ods'
        (Get-DatabaseTypes).Admin    = 'EdFi_Admin'
        (Get-DatabaseTypes).Security = 'EdFi_Security'
        (Get-DatabaseTypes).Master   = 'EdFi_Master'
    }
}

function Get-DefaultConnectionStringsByEngine {
    return  @{
        SQLServer  = @{
            ConnectionStrings = @{
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Ods])      = "Server=(local); Trusted_Connection=True; Database=EdFi_{0};"
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Admin])    = "Server=(local); Trusted_Connection=True; Database=EdFi_Admin;"
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Security]) = "Server=(local); Trusted_Connection=True; Database=EdFi_Security; Persist Security Info=True;"
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Master])   = "Server=(local); Trusted_Connection=True; Database=master;"
            }
        }
        PostgreSQL = @{
            ConnectionStrings = @{
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Ods])      = "Host=localhost; Port=5432; Username=postgres; Database=EdFi_{0}; Pooling=true; Minimum Pool Size=10; Maximum Pool Size=50;"
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Admin])    = "Host=localhost; Port=5432; Username=postgres; Database=EdFi_Admin; Pooling=true; Minimum Pool Size=10; Maximum Pool Size=50;"
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Security]) = "Host=localhost; Port=5432; Username=postgres; Database=EdFi_Security; Pooling=true; Minimum Pool Size=10; Maximum Pool Size=50;"
                ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Master])   = "Host=localhost; Port=5432; Username=postgres; Database=postgres; Pooling=false;"
            }
        }
    }
}

function Get-DefaultTemplateSettingsByEngine {
    return  @{
        SQLServer  = @{
            ApiSettings = @{
                MinimalTemplateScript   = 'EdFiMinimalTemplate'
                PopulatedTemplateScript = 'GrandBend'
            }
        }
        PostgreSQL = @{
            ApiSettings = @{
                MinimalTemplateScript   = 'PostgreSQLMinimalTemplate'
                PopulatedTemplateScript = 'PostgreSQLPopulatedTemplate'
            }
        }
    }
}

function Get-DefaultTPDMTemplateSettingsByEngine {
    return  @{
        SQLServer  = @{
            ApiSettings = @{
                MinimalTemplateScript   = 'TPDMCoreMinimalTemplate'
                PopulatedTemplateScript = 'TPDMCorePopulatedTemplate'
            }
        }
        PostgreSQL = @{
            ApiSettings = @{
                MinimalTemplateScript   = 'TPDMCorePostgreSqlMinimalTemplate'
                PopulatedTemplateScript = 'TPDMCorePostgreSqlPopulatedTemplate'
            }
        }
    }
}

function Get-SubtypesByFeature {
    return @{
        changeQueries               = 'Changes'
        ownershipBasedAuthorization = 'RecordOwnership'
    }
}

function Assert-ValidAppSettings([string[]] $SettingsFiles = (Get-ChildItem "$(Get-RepositoryRoot 'Ed-Fi-ODS')/**/appsettings*.json" -Recurse)) {
    $result = @()

    foreach ($file in $SettingsFiles) {
        try {
            Get-Content $file -ErrorAction Stop | ConvertFrom-Json | Out-Null
            $result += @{ file = $file; success = $true }
        }
        catch {
            $result += @{ file = $file; success = $false; exception = $_ }
        }
    }

    return $result
}

function Add-ApplicationNameToConnectionStrings([hashtable] $Settings = @{ }, [string] $ApplicationName) {
    $csbs = Get-ConnectionStringBuildersFromSettings $Settings
    $newConnectionStrings = @{ }

    foreach ($key in $csbs.Keys) {
        if (-not [string]::IsNullOrEmpty($csbs[$key]['Application Name'])) { continue }
        $csbs[$key]['Application Name'] = (Split-Path -Leaf $ApplicationName).ToString()
        $newConnectionStrings[$key] = $csbs[$key].ToString()
    }

    $newSettings = Merge-Hashtables $Settings, @{ ConnectionStrings = $newConnectionStrings }

    return $newSettings
}

function Add-EncryptValueToConnectionStrings([hashtable] $Settings = @{ }, [string] $EncryptValue) {
    $csbs = Get-ConnectionStringBuildersFromSettings $Settings
    $newConnectionStrings = @{ }
    foreach ($key in $csbs.Keys) {
        if (-not [string]::IsNullOrEmpty($csbs[$key]['Encrypt'])) { continue }
        $csbs[$key]['Encrypt'] = (Split-Path -Leaf $EncryptValue).ToString()
        $newConnectionStrings[$key] = $csbs[$key].ToString()
    }
    $newSettings = Merge-Hashtables $Settings, @{ ConnectionStrings = $newConnectionStrings }
    return $newSettings
}

function Add-MssqlSqlLoginToConnectionStrings([hashtable] $Settings = @{ }, [string] $Username, [string] $Password) {
    $csbs = Get-ConnectionStringBuildersFromSettings $Settings
    $newConnectionStrings = @{ }
    foreach ($key in $csbs.Keys) {
        $csbs[$key]['trusted_connection'] = 'False'
        $csbs[$key]['user id'] = $Username
        $csbs[$key]['password'] = $Password
        $newConnectionStrings[$key] = $csbs[$key].ToString()
    }
    $newSettings = Merge-Hashtables $Settings, @{ ConnectionStrings = $newConnectionStrings 
                                                  Csbs = $csbs}
    return $newSettings
}

function Format-Json {
    <#
    .SYNOPSIS
        Prettifies JSON output.
    .DESCRIPTION
        Reformats a JSON string so the output looks better than what ConvertTo-Json outputs.
    .PARAMETER Json
        Required: [string] The JSON text to prettify.
    .PARAMETER Minify
        Optional: Returns the json string compressed.
    .PARAMETER Indentation
        Optional: The number of spaces (1..1024) to use for indentation. Defaults to 2.
    .PARAMETER AsArray
        Optional: If set, the output will be in the form of a string array, otherwise a single string is output.
    .EXAMPLE
        $json | ConvertTo-Json  | Format-Json -Indentation 2
    #>
    [CmdletBinding(DefaultParameterSetName = 'Prettify')]
    Param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)]
        [string] $Json,

        [Parameter(ParameterSetName = 'Minify')]
        [switch] $Minify,

        [Parameter(ParameterSetName = 'Prettify')]
        [ValidateRange(1, 1024)]
        [int] $Indentation = 2,

        [Parameter(ParameterSetName = 'Prettify')]
        [switch] $AsArray
    )

    if ($PSCmdlet.ParameterSetName -eq 'Minify') {
        return ($Json | ConvertFrom-Json) | ConvertTo-Json -Depth 100 -Compress
    }

    # If the input JSON text has been created with ConvertTo-Json -Compress
    # then we first need to reconvert it without compression
    if ($Json -notmatch '\r?\n') {
        $Json = ($Json | ConvertFrom-Json) | ConvertTo-Json -Depth 100
    }

    $indent = 0
    $regexUnlessQuoted = '(?=([^"]*"[^"]*")*[^"]*$)'

    $result = $Json -split '\r?\n' |
        ForEach-Object {
            # If the line contains a ] or } character,
            # we need to decrement the indentation level unless it is inside quotes.
            if ($_ -match "[}\]]$regexUnlessQuoted") {
                $indent = [Math]::Max($indent - $Indentation, 0)
            }

            # Replace all colon-space combinations by ": " unless it is inside quotes.
            $line = (' ' * $indent) + ($_.TrimStart() -replace ":\s+$regexUnlessQuoted", ': ')

            # If the line contains a [ or { character,
            # we need to increment the indentation level unless it is inside quotes.
            if ($_ -match "[\{\[]$regexUnlessQuoted") {
                $indent += $Indentation
            }

            $line
        }

    if ($AsArray) { return $result }
    return $result -Join [Environment]::NewLine
}

function New-JsonFile {
    param(
        [string] $FilePath,

        [hashtable] $Hashtable,

        [switch] $Overwrite
    )

    if (-not $Overwrite -and (Test-Path $FilePath)) { return }

    $Hashtable | ConvertTo-Json -Depth 10 | Format-Json | Out-File -FilePath $FilePath -NoNewline -Encoding UTF8
}

function Get-UserSecrets([string] $Project) {
    if ([string]::IsNullOrWhitespace($Project)) { return @{ } }

    $inputTable = @{ }

    try {
        $projectPath = Get-RepositoryResolvedPath $Project
    }
    catch {
        # if the project throws an error because it does not exist we swallow the error and return an empty hashtable
        return @{ }
    }

    $userSecretList = dotnet user-secrets list --project $projectPath --id (Get-UserSecretsIdByProject).$Project | Out-String

    if ($userSecretList -notlike "*No secrets configured for this application*" -and ($null -ne $userSecretList)) {
        $inputTable = ConvertFrom-StringData -StringData $userSecretList
    }

    return (Get-UnFlatHashtable($inputTable))
}

function Get-MergedAppSettings([string[]] $SettingsFiles = @() , [string]$Project) {

    $mergedSettings = @{ }

    foreach ($settingsFile in $SettingsFiles) {
        if (-not (Test-Path $settingsFile)) { continue }

        $settings = Get-Content $settingsFile | ConvertFrom-Json | ConvertTo-Hashtable
        $mergedSettings = Merge-Hashtables $mergedSettings, $settings
    }

    $userSecrets = Get-UserSecrets $Project

    $mergedSettings = Merge-Hashtables $mergedSettings, $userSecrets

    return $mergedSettings
}

function Get-ConnectionStringBuildersFromSettings([hashtable] $Settings = @{ }) {
    $connectionStrings = @{ }

    foreach ($key in $Settings.ConnectionStrings.Keys) {
        $csb = New-Object System.Data.Common.DbConnectionStringBuilder
        # using set_ConnectionString correctly uses the underlying C# setter functionality
        # resulting in a dictionary of connection string properties instead of a string
        $csb.set_ConnectionString($Settings.ConnectionStrings[$key])
        $connectionStrings[$key] = $csb
    }

    return $connectionStrings
}

function Get-EnabledFeaturesFromSettings([hashtable] $Settings = @{ }) {
    if ($Settings -eq $null) { return @() };

    return ($Settings.FeatureManagement.Keys | Where-Object { $Settings.FeatureManagement[$_] -eq $true })
}

function Get-FeatureSubTypesFromSettings([hashtable] $Settings = @{ }) {
    $enabledFeatureSubTypes = @()

    $enabledFeatures = (Get-EnabledFeaturesFromSettings $Settings)
    foreach ($feature in (Get-SubtypesByFeature).Keys) {
        $enabledFeatureSubTypes += ($enabledFeatures | Where-Object { $_ -eq $feature })
    }

    $enabledSubTypes = $enabledFeatureSubTypes | ForEach-Object { (Get-SubtypesByFeature)[$_] }

    return $enabledSubTypes
}

function Get-DatabaseScriptFoldersFromSettings([hashtable] $Settings = @{ }) {
    if ((Get-EnabledFeaturesFromSettings $Settings) -contains "Extensions") {
        $excludedExtensions = $Settings.ApiSettings.ExcludedExtensions
        $artifactSources = Select-SupportingArtifactResolvedSources |
            Select-ExtensionArtifactResolvedName -exclude $excludedExtensions
    }

    $folders = @()

    $folders = Get-RepositoryArtifactPaths

    $folders += Get-ExtensionScriptFiles $artifactSources

    $pluginFolder = (Get-PluginFolderFromSettings $Settings)
    if (-not [string]::IsNullOrWhitespace($pluginFolder)) {
        $pluginArtifactSource += ((Get-ChildItem -Path $pluginFolder -Filter "*Artifacts*" -Recurse -Directory).Parent).FullName

        if ($null -ne $pluginArtifactSource) { $folders += $pluginArtifactSource }
    }

    return $folders
}

function Add-DeploymentSpecificSettings([hashtable] $Settings = @{ }) {
    $newDeploymentSettings = @{
        ApiSettings = @{
            DatabaseTypes        = Get-DatabaseTypes
            ConnectionStringKeys = Get-ConnectionStringKeyByDatabaseTypes
            Csbs                 = Get-ConnectionStringBuildersFromSettings $Settings
            SubTypes             = Get-FeatureSubTypesFromSettings $Settings
            FilePaths            = Get-DatabaseScriptFoldersFromSettings $Settings
        }
    }

    return (Merge-Hashtables $Settings, $newDeploymentSettings)
}

function Update-DefaultDatabaseTemplate([hashtable] $Settings = @{ }) {

    $engine = $Settings.ApiSettings.Engine
    $standardVersion = $Settings.ApiSettings.StandardVersion
    if ([string]::IsNullOrWhiteSpace($standardVersion)) {
        $standardVersion = [Version]::new(6, 0, 0)
    }
    else {
        $standardVersion = [Version]$standardVersion
    }
    $defaultTemplateSettings = Get-DefaultTemplateSettingsByEngine
    $defaultTPDMTemplateSettings = Get-DefaultTPDMTemplateSettingsByEngine
    $defaultMinimalTemplates = @(
        $defaultTemplateSettings.SQLServer.ApiSettings.MinimalTemplateScript,
        $defaultTemplateSettings.PostgreSQL.ApiSettings.MinimalTemplateScript,
        $defaultTPDMTemplateSettings.SQLServer.ApiSettings.MinimalTemplateScript,
        $defaultTPDMTemplateSettings.PostgreSQL.ApiSettings.MinimalTemplateScript
    )
    $defaultPopulatedTemplates = @(
        $defaultTemplateSettings.SQLServer.ApiSettings.PopulatedTemplateScript,
        $defaultTemplateSettings.PostgreSQL.ApiSettings.PopulatedTemplateScript,
        $defaultTPDMTemplateSettings.SQLServer.ApiSettings.PopulatedTemplateScript,
        $defaultTPDMTemplateSettings.PostgreSQL.ApiSettings.PopulatedTemplateScript
    )

    # tpdm is embedded in the Ed-Fi ODS / API 6.0+ and is not a plugin anymore
    if ($Settings.Plugin.Scripts -notcontains "tpdm" -or $standardVersion -ge [Version]::new(6, 0, 0)) {
        if ($defaultMinimalTemplates -contains $Settings.ApiSettings.MinimalTemplateScript) {
            $Settings.ApiSettings.MinimalTemplateScript = $defaultTemplateSettings[$engine].ApiSettings.MinimalTemplateScript
        }
        if ($defaultPopulatedTemplates -contains $Settings.ApiSettings.PopulatedTemplateScript) {
            $Settings.ApiSettings.PopulatedTemplateScript = $defaultTemplateSettings[$engine].ApiSettings.PopulatedTemplateScript
        }
    }
    else {
        if ($defaultMinimalTemplates -contains $Settings.ApiSettings.MinimalTemplateScript) {
            $Settings.ApiSettings.MinimalTemplateScript = $defaultTPDMTemplateSettings[$engine].ApiSettings.MinimalTemplateScript
        }
        if ($defaultPopulatedTemplates -contains $Settings.ApiSettings.PopulatedTemplateScript) {
            $Settings.ApiSettings.PopulatedTemplateScript = $defaultTPDMTemplateSettings[$engine].ApiSettings.PopulatedTemplateScript
        }
    }

    return $Settings
}

function Add-OdsConnectionStringEncryptionKey([hashtable] $Settings = @{ }, [string] $ProjectName, [string] $AESKey) {
    if ((-not $ProjectName.Contains("Ods")) -or ($ProjectName.Contains("Swagger"))) { return $Settings }

    if([string]::IsNullOrWhiteSpace($settings.ApiSettings.OdsConnectionStringEncryptionKey)) {
        $Settings.ApiSettings.OdsConnectionStringEncryptionKey = $AESKey
    }

    return $Settings
}

function Add-TestSpecificAppSettings([hashtable] $Settings = @{ }, [string] $ProjectName) {
    if (-not $ProjectName.Contains("Test")) { return $Settings }

    $databaseName = @{
        ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Ods])      = "EdFi_Ods_Populated_Template_Test"
        ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Admin])    = "EdFi_Admin_Test"
        ((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Security]) = "EdFi_Security_Test"
    }

    $newSettings = @{
        ConnectionStrings = @{ }
    }

    $csbs = Get-ConnectionStringBuildersFromSettings $Settings
    foreach ($key in $databaseName.Keys) {
        $csbs[$key].database = $databaseName[$key]
        $newSettings.ConnectionStrings[$key] = $csbs[$key].ToString()
    }
    $newSettings = (Merge-Hashtables $Settings, $newSettings)

    return $newSettings
}

function Add-MultiTenantSettings([hashtable] $Settings = @{ }, [string] $ProjectName) {
    if ($ProjectName -ne (Get-ProjectTypes).WebApi) { return $Settings }
    
    $newSettings = @{
        FeatureManagement = (Get-DefaultFeatures).FeatureManagement
        ApiSettings       = @{}
        Tenants           = @{}
    }

    $csbs = Get-ConnectionStringBuildersFromSettings $Settings
    foreach ($tenant in $Settings.ApiSettings.Tenants -split ';' | ForEach-Object { $_ }) {
        $newSettings.Tenants += @{
            $tenant = @{
                ConnectionStrings = @{
                    EdFi_Admin = "$(Get-DbConnectionStringBuilderFromTemplate -templateCSB $csbs[((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Admin])] -replacementTokens "Admin_$($tenant)")"
                    EdFi_Security = "$(Get-DbConnectionStringBuilderFromTemplate -templateCSB $csbs[((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Security])] -replacementTokens "Security_$($tenant)")"
                }
            }
        }
    }
    
    $newSettings = (Merge-Hashtables $Settings, $newSettings)
    $newSettings = Set-Feature -Settings $newSettings -FeatureName "MultiTenancy" -IsEnabled $true
    return $newSettings
}

function Add-SwaggerUiTenantSettings([hashtable] $Settings = @{ }, [string] $ProjectName) {
    if ($ProjectName -ne (Get-ProjectTypes).SwaggerUI) { return $Settings }
    
    $Settings.Tenants = @()

    foreach ($tenant in $Settings.ApiSettings.Tenants -split ';' | ForEach-Object { $_ }) {
        $Settings.Tenants += @{ Tenant = $tenant }
    }
    
    return $Settings
}

function Add-SwaggerUiYearSettings([hashtable] $Settings = @{ }, [string] $ProjectName) {
    if ($ProjectName -ne (Get-ProjectTypes).SwaggerUI) { return $Settings }
    if (-not $Settings.ApiSettings.OdsTokens) { return $Settings }

    $Settings.Years = @()

    foreach ($year in $Settings.ApiSettings.OdsTokens -split ';' | ForEach-Object { $_ }) {
        # Validate if OdsToken includes a valid year.
        if ($year -imatch '_?(20[0-9]{2})') {
            $Settings.Years += @{ Year = $matches[1] }
        }
    }
    
    # If no years were found, skip adding an empty Year section in config
    if ($Settings.Years.Count -eq 0) { return $Settings }

    # Clear any duplicated year, taking into account multiple tenants with different school years
    # Ex. Tenant1_2021;Tenant1_2022;Tenant2_2021;Tenant2_2022;
    $Settings.Years = @($Settings.Years | Sort-Object | Get-Unique)

    return $Settings
}

function Add-MultiTenantTestHarnessSettings([hashtable] $Settings = @{ }, [string] $ProjectName) {
    if ($ProjectName -ne (Get-TestProjectTypes).IntegrationTestHarness) { return $Settings }
    
    $odsConnectionString = $Settings.ConnectionStrings.EdFi_Ods.replace('EdFi_Ods_Populated_Template_Test', 'EdFi_Ods_Populated_Template_{0}_Test')
    $newSettings = @{
        FeatureManagement = (Get-DefaultFeatures).FeatureManagement
        ApiSettings       = @{}
        Tenants = @{}
        ConnectionStrings = @{
            EdFi_Ods = $odsConnectionString
        }
    }
    
    $csbs = Get-ConnectionStringBuildersFromSettings $Settings
    foreach ($tenant in $Settings.ApiSettings.Tenants -split ';' | ForEach-Object { $_ }) {
        $newSettings.Tenants += @{
            $tenant = @{
                ConnectionStrings = @{
                    EdFi_Admin = "$(Get-DbConnectionStringBuilderFromTemplate -templateCSB $csbs[((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Admin])] -replacementTokens "Admin_$($tenant)_Test")"
                    EdFi_Security = "$(Get-DbConnectionStringBuilderFromTemplate -templateCSB $csbs[((Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Security])] -replacementTokens "Security_$($tenant)_Test")"
                }
            }
        }
    }
    
    $newSettings = (Merge-Hashtables $Settings, $newSettings)
    $newSettings = Set-Feature -Settings $newSettings -FeatureName "MultiTenancy" -IsEnabled $true
    return $newSettings
}

function Remove-ODSConnectionString([hashtable] $Settings = @{ }, [string] $ProjectName) {
    if (($ProjectName -eq ((Get-ProjectTypes).SandboxAdmin)) -or 
    ($ProjectName -eq ((Get-ProjectTypes).Databases)) -or
    ($ProjectName -eq ((Get-TestProjectTypes).IntegrationTestHarness)) -or
    ($ProjectName -eq ((Get-TestProjectTypes).NHibernateTests)) -or
    ($ProjectName -eq ((Get-TestProjectTypes).ApiIntegrationTests)) -or
    ($ProjectName -eq ((Get-TestProjectTypes).CompositeSpecFlowTests)) -or
    ($ProjectName -eq ((Get-TestProjectTypes).WebApiIntegrationTests)) -or
    ($ProjectName -eq ((Get-TestProjectTypes).DataAccessIntegrationTests))) { return $Settings }

    $newSettings = Get-HashtableDeepClone $settings
    $newSettings.ConnectionStrings.Remove('EdFi_Ods')

    return $newSettings
}

function Get-UserSecretsIdByProject {
    return @{
        ((Get-ProjectTypes).SandboxAdmin)               = "f1506d66-289c-44cb-a2e2-80411cc690ea"
        ((Get-ProjectTypes).SwaggerUI)                  = "f1506d66-289c-44cb-a2e2-80411cc690eb"
        ((Get-ProjectTypes).WebApi)                     = "f1506d66-289c-44cb-a2e2-80411cc690ec"
        ((Get-TestProjectTypes).IntegrationTestHarness) = "f1506d66-289c-44cb-a2e2-80411cc690ed"
    }
}

function New-DevelopmentAppSettings([hashtable] $Settings = @{ }) {
    $newSettingsFiles = @()
    $developmentSettingsByProject = Get-DefaultDevelopmentSettingsByProject

    $credentialSettingsByProject = Get-CredentialSettingsByProject

    $NewAESKey = New-AESKey

    foreach ($project in $developmentSettingsByProject.Keys) {
        $newDevelopmentSettings = (Get-DefaultConnectionStringsByEngine)[$Settings.ApiSettings.Engine]
        $newDevelopmentSettings = Add-ApplicationNameToConnectionStrings $newDevelopmentSettings $project

        if ($Settings.ApiSettings.Engine -eq 'SQLServer')
        {
            $newDevelopmentSettings = Add-EncryptValueToConnectionStrings $newDevelopmentSettings $false
        }

        if(-not [string]::IsNullOrEmpty($Settings.MssqlSaPassword)) {
            $newDevelopmentSettings = Add-MssqlSqlLoginToConnectionStrings $newDevelopmentSettings 'sa' $Settings.MssqlSaPassword
            $newDevelopmentSettings.Remove('MssqlSaPassword')
        }
       
        $newDevelopmentSettings = Merge-Hashtables $developmentSettingsByProject[$project], $newDevelopmentSettings

        $newDevelopmentSettings = Add-TestSpecificAppSettings $newDevelopmentSettings $project
        
        $newDevelopmentSettings = Merge-Hashtables $newDevelopmentSettings, $credentialSettingsByProject[$project], $Settings
        
        $newDevelopmentSettings = Remove-ODSConnectionString $newDevelopmentSettings $project

        $newDevelopmentSettings = Add-OdsConnectionStringEncryptionKey $newDevelopmentSettings $Project $NewAESKey

        $newDevelopmentSettings = Add-SwaggerUiYearSettings $newDevelopmentSettings $Project

        if ($Settings.InstallType -eq 'MultiTenant')
        {
            $newDevelopmentSettings = Add-MultiTenantSettings $newDevelopmentSettings $project
            $newDevelopmentSettings = Add-MultiTenantTestHarnessSettings $newDevelopmentSettings $project
            $newDevelopmentSettings = Add-SwaggerUiTenantSettings $newDevelopmentSettings $project
        }
        
        $projectPath = Get-RepositoryResolvedPath $Project

        $newDevelopmentSettingsPath = Join-Path $projectPath "appsettings.Development.json"
        New-JsonFile $newDevelopmentSettingsPath $newDevelopmentSettings -Overwrite
        $newSettingsFiles += $newDevelopmentSettingsPath
    }

    return $newSettingsFiles
}

function Set-Feature([hashtable] $Settings = @{ }, [string] $FeatureName, [bool] $IsEnabled) {
    if (-not $Settings.FeatureManagement) {
        $Settings.FeatureManagement = @{ }
    }

    $Settings.FeatureManagement[$FeatureName] = $IsEnabled
    return $Settings
}

function ConvertTo-Array($Value) {
    if ($null -eq $Value) { return $null }
    return , $Value.Split([Environment]::NewLine).Split(';')
}

function ConvertTo-Boolean($Value) {
    $result = $null
    if ([Boolean]::TryParse($Value, [ref]$result)) { return $result }
    return $null
}

function Get-ValueOrDefault($Value, $Default) {
    if ([string]::IsNullOrWhiteSpace($Value)) { return $Default }
    return $Value
}

function Get-DefaultFeatures() {
    return @{
        FeatureManagement = @{
            OpenApiMetadata = $true
            AggregateDependencies = $true
            TokenInfo = $true
            Extensions = $true
            Composites = $true
            Profiles = $true
            ChangeQueries = $true
            IdentityManagement = $false
            OwnershipBasedAuthorization = $true
            UniqueIdValidation = $false
            XsdMetadata = $true
            MultiTenancy = $false
            SerializedData = $true
            ResourceLinks = $true
        }
    }
}
