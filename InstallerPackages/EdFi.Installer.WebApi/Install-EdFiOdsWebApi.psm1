# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -version 5
$ErrorActionPreference = "Stop"

<#
To run manually from source code, instead of from an expanded NuGet package,
run the prep-installer-package.ps1 script first. Think of it as a "restore-packages"
step before compiling in C#.
#>

Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Utility/hashtable.psm1
Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Utility/nuget-helper.psm1
Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Utility/TaskHelper.psm1

Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Application/Install.psm1
Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Application/Uninstall.psm1
Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Application/Configuration.psm1

function Install-EdFiOdsWebApi {
    <#
    .SYNOPSIS
        Installs the Ed-Fi ODS WebApi application into IIS.

    .DESCRIPTION
        Installs and configures the Ed-Fi ODS WebApi application in IIS running in Windows 10 or
        Windows Server 2016+. As needed, will create a new "Ed-Fi" website in IIS, configure it
        for HTTPS, and load the WebAPI binaries as an an application. Transforms the web.config
        as needed for the database engine of choice, to set connection strings, and override
        default feature settings. Supports all install types: Sandbox, SingleTenant
        and MultiTenant.

        This function has two different parameter sets for database connectivity: one parameter for
        all three Ed-Fi databases residing the same server, and an alternate set of parameters
        for supporting databases residing on separate servers. However, all three databases
        must be on the same database engine - should not install on a mix of SQL Server and
        PostgreSQL.

    .EXAMPLE
        PS c:/> $parameters = @{
            DbConnectionInfo = @{
                Engine="SqlServer"
                Server="localhost"
                UseIntegratedSecurity=$true
            }
            UnEncryptedConnection = $true
        }
        PS c:/> Install-EdFiOdsWebApi @parameters

        Use all available default values, connecting to databases on a single SQL Server instance.
        Connect to the database with integrated security. This will create IIS website "Ed-Fi" 
        with root c:\inetpub\Ed-Fi, and the application files will be in "c:\inetpub\Ed-Fi\WebApi".
        Installs the most recent full release of the WebApi software.

    .EXAMPLE
        PS c:/> $parameters = @{
            DbConnectionInfo = @{
                Engine="SqlServer"
                Server="localhost"
                Username="user123"
                Password="password123"
                UseIntegratedSecurity=$false
            }
        }
        PS c:/> Install-EdFiOdsWebApi @parameters

        Connect using SQL Server Authentication (with a user and a password). If the user does not already
        exist in SQL Server, the installer will create it with "sysadmin" role.

    .EXAMPLE
        PS c:/> $parameters = @{
            DbConnectionInfo = @{
                Engine="SqlServer"
                Server="localhost"
                Username="NT AUTHORITY\LOCAL SERVICE"
                UseIntegratedSecurity=$true
            }
        }
        PS c:/> Install-EdFiOdsWebApi @parameters

        Connect using integrated security with a specific Windows user. If the user does not already
        exist in SQL Server, the installer will create it with "sysadmin" role.
        After executing the installer, you must ensure that the application pool identity used by 
        WebApi is the same as the Windows user.

    .EXAMPLE
        PS c:/> $parameters = @{
            AdminDbConnectionInfo = @{
                Engine="SqlServer"
                Server="edfi-auth.my-sql-server.example"
                UseIntegratedSecurity=$true
            }
            SecurityDbConnectionInfo = @{
                Engine="SqlServer"
                Server="edfi-auth.my-sql-server.example"
                UseIntegratedSecurity=$true
            }
        }
        PS c:/> Install-EdFiOdsWebApi @parameters

        Install with all web application defaults, but using separate database connections.

    .EXAMPLE
        PS c:/> $parameters = @{
            DbConnectionInfo = @{
                Engine="PostgreSQL"
                Server="localhost"
                Username="postgres"
            }
        }
        PS c:/> Install-EdFiOdsWebApi @parameters

        Use all available default values, connecting to databases on a single PostgreSQL server
        using the "postgres" user which has to be configured for password-less login in pgpass.conf.
        This will create IIS website "Ed-Fi" with root c:\inetpub\Ed-Fi, and the application files will
        be in "c:\inetpub\Ed-Fi\WebApi".
        Installs the most recent full release of the WebApi software.

    .EXAMPLE
        PS c:/> $parameters = @{
            DbConnectionInfo=@{
                DatabaseName="EdFi_Sandbox"
                Engine="SqlServer"
                Server="localhost"
                UseIntegratedSecurity=$true
            }
            IsSandbox=$true
        }
        PS c:/> Install-EdFiOdsWebApi @parameters

        Install in Sandbox mode on SQL Server with default IIS configuration.
        Override the default ODS database name. Note that a Sandbox connection string
        must include {0}. That token will be injected if it is omitted. Furthermore,
        the Sandbox mode expects "Ods" in the database name. Thus for input value
        "EdFi_Sandbox", the connection string will contain "EdFi_Sandbox_{0}" and the
        database server should have databases named "EdFi_Sandbox_Ods_Minimal_Template"
        and "EdFi_Sandbox_Ods_Populated_Template".

    .EXAMPLE
        PS c:/> $parameters = @{
            DbConnectionInfo=@{
                Engine="SqlServer"
                Server="my-sql-server.example"
                UseIntegratedSecurity=$true
            }
            WebApiFeatures = @{
                BearerTokenTimeoutMinutes="23"
                ExcludedExtensions=@{}
                FeatureManagement = @{
                    OpenApiMetadata = $true
                    AggregateDependencies = $true
                }
            }
        }
        PS c:/> Install-EdFiOdsWebApi @parameters

        Install in a single instance with basic database
        configuration, with override all available web.config app settings.
    #>
    [CmdletBinding()]
    param (
        # NuGet package name. Default: EdFi.Suite3.Ods.WebApi.
        [string]
        $PackageName = "EdFi.Suite3.Ods.WebApi.Standard.6.0.0",

        # NuGet package version. If not set, will retrieve the latest full release package.
        [string]
        $PackageVersion,

        # NuGet package source . default value is set for release package source for installer .
        [string]
        $PackageSource = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi%40Release/nuget/v3/index.json",
                
        # Path for storing installation tools, e.g. nuget.exe. Default: "./tools".
        [string]
        $ToolsPath = "$PSScriptRoot/tools",

        # Path for storing downloaded packages. Default: "./downloads".
        [string]
        $DownloadPath = "$PSScriptRoot/downloads",

        # Path for the IIS WebSite. Default: c:\inetpub\Ed-Fi.
        [string]
        $WebSitePath = "c:\inetpub\Ed-Fi", # NB: _must_ use backslash with IIS settings

        # Web site name. Default: "Ed-Fi".
        [string]
        $WebsiteName = "Ed-Fi",

        # Log destination path. 
        # 
        # Use {version} template string to include API's version.
        # To include a value from an environment variable use ${myVar}
        # Default: "${PROGRAMDATA}/Ed-Fi-ODS/WebApiLog.{version}.log".
        [string]
        $LogDestinationPath = "`${PROGRAMDATA}/Ed-Fi-ODS/WebApiLog.{version}.log",

        # Web site port number. Default: 443.
        [int]
        $WebSitePort = 443,

        # Directory for the web application. Default: "WebApi".
        [string]
        $WebApplicationPath = "WebApi", # NB: _must_ use backslash with IIS settings

        # Web application name. Default: "WebApi".
        [string]
        $WebApplicationName = "WebApi",

        # TLS certificate thumbprint, optional. When not set, a self-signed certificate will be created.
        [string]
        $CertThumbprint,

        # Used to indicate a sandbox install.
        [switch]
        $IsSandbox,

        # Name for the Admin database. Default: EdFi_Admin.
        [string]
        [Parameter(ParameterSetName="SharedCredentials")]
        $AdminDatabaseName = "EdFi_Admin",

        # Name for the Security database. Default: EdFi_Security.
        [string]
        [Parameter(ParameterSetName="SharedCredentials")]
        $SecurityDatabaseName = "EdFi_Security",

        # Shared database connectivity information.
        #
        # The hashtable must include: Server, Engine (SqlServer or PostgreSQL), and
        # either UseIntegratedSecurity or Username and Password (Password can be skipped
        # for PostgreSQL when using pgconf file). Optionally can include Port.
        # This can be used with IsMultiTenant flag.
        [hashtable]
        [Parameter(Mandatory=$true, ParameterSetName="SharedCredentials")]
        [Parameter(ParameterSetName="MultiTenant")]
        $DbConnectionInfo,

        # Database connectivity only for the admin database.
        #
        # The hashtable must include: Server, Engine (SqlServer or PostgreSQL), and
        # either UseIntegratedSecurity or Username and Password (Password can be skipped
        # for PostgreSQL when using pgconf file). Optionally can include Port and
        # DatabaseName.
        [hashtable]
        [Parameter(Mandatory=$true, ParameterSetName="SeparateCredentials")]
        $AdminDbConnectionInfo,

        # Database connectivity only for the security database.
        #
        # The hashtable must include: Server, Engine (SqlServer or PostgreSQL), and
        # either UseIntegratedSecurity or Username and Password (Password can be skipped
        # for PostgreSQL when using pgconf file). Optionally can include Port and
        # DatabaseName.
        [hashtable]
        [Parameter(Mandatory=$true, ParameterSetName="SeparateCredentials")]
        $SecurityDbConnectionInfo,

        # Optional overrides for features and settings in the web.config.
        #
        # The hashtable can include: BearerTokenTimeoutMinutes, ExcludedExtensionsSources,
        # and FeatureIsEnabled dictionary. The dictionary enable/disable any feature in
        # the web.config file, for example "changeQueries" or "composites".
        [hashtable]
        $WebApiFeatures,

        # Turns off display of script run-time duration.
        [switch]
        $NoDuration,
        
        # Create the database server login for the application if they do not already exist
        # IMPORTANT: Logins created by the installer will have database system administrator rights. 
        #            If more restrictive permissions are required, the SQL login used by the WebApi should be created manually.
        # If login credentials are provided in the DB connection information parameter, the new login will use these.
        # If no database credentials are provided in the DB connection information, integrated security must be selected and a new SQL login matching the 
        # application pool identity used by WebAPI will be created.
        # 
        # To create a custom login for SQL Server:
        #    If integrated security is not enabled, a username and password must be provided in the database connection information parameter(s)
        #    If integrated security is enabled, the username provided must be a valid Windows user
        #    If integrated security is enabled, the application pool identity used by WebAPI needs to be updated to use the same Windows username 
        # To create a custom login for Postgres:
        #    If integrated security is not enabled, a username and password must be provided in the database connection information parameter(s)
        #    If integrated security is enabled, pg_ident.conf map needs to be updated to use the username provided
        [bool]
        $CreateSqlLogin = $true,
        
        # Deploy WebApi with MultiTenant support. 
        # Passing this flag, requires to pass Tenants configuration.
        # When true, this flag will enable the MultiTenancy feature in FeatureManagement.
        [switch]
        [Parameter(Mandatory=$true, ParameterSetName="MultiTenant")]
        $IsMultiTenant,
        
        # List of Tenants with information required by the Tenants section in appsettings.json
        #
        # Each tenant hashtable can include: 
        #   - AdminDatabaseName and SecurityDatabaseName when used with DbConnectionInfo.
        #   - AdminDbConnectionInfo and SecurityDbConnectionInfo when DbConnectionInfo is not used.
        [hashtable]
        [Parameter(Mandatory=$true, ParameterSetName="MultiTenant")]
        $Tenants,
        
        # Set the encription key used to encrypt ODS connections.
        # Value should be a Base64 encoded 256-bit encryption key.
        # If empty, it iwll be set with a random New-AESKey key
        [string]
        $OdsConnectionStringEncryptionKey,
        
        # Set the ContextRouteTemplate.
        [string]
        $OdsContextRouteTemplate,
        
        # Set Encrypt=false for all connection strings
        # Not recomended for production environment.
        [switch]
        $UnEncryptedConnection
    )

    Write-InvocationInfo $MyInvocation

    Clear-Error

    $result = @()

    $config = @{
        WebApplicationPath = (Join-Path $WebSitePath $WebApplicationPath)
        PackageName = $PackageName
        PackageVersion = $PackageVersion
        PackageSource = $PackageSource
        ToolsPath = $ToolsPath
        DownloadPath = $DownloadPath
        WebSitePath = $WebSitePath
        WebSiteName = $WebsiteName
        LogDestinationPath = $LogDestinationPath
        WebSitePort = $WebsitePort
        CertThumbprint = $CertThumbprint
        WebApplicationName = $WebApplicationName
        IsSandbox = $IsSandbox
        AdminDatabaseName = $AdminDatabaseName
        SecurityDatabaseName = $SecurityDatabaseName
        DbConnectionInfo = $DbConnectionInfo
        AdminDbConnectionInfo = $AdminDbConnectionInfo
        SecurityDbConnectionInfo = $SecurityDbConnectionInfo
        WebApiFeatures = $WebApiFeatures
        NoDuration = $NoDuration
        CreateSqlLogin  = $CreateSqlLogin
        IsMultiTenant = $IsMultiTenant.IsPresent
        Tenants = $Tenants
        OdsConnectionStringEncryptionKey = $OdsConnectionStringEncryptionKey
        OdsContextRouteTemplate = $OdsContextRouteTemplate
        UnEncryptedConnection = $UnEncryptedConnection
    }

    $elapsed = Use-StopWatch {
        $result += Initialize-Configuration -Config $config
        $result += Get-WebApiPackage -Config $config
        $result += Invoke-TransformWebConfigAppSettings -Config $config
        
        if ($IsMultiTenant.IsPresent) {
            $result += Invoke-TransformWebConfigMultiTenantConnectionStrings -Config $config
        } else {
            $result += Invoke-TransformWebConfigConnectionStrings -Config $config
        }
        
        $result += Install-Application -Config $config
        $result += New-SqlLogins -Config $config

        $result
    }

    Test-Error

    if (-not $NoDuration) {
        $result += New-TaskResult -name "-" -duration "-"
        $result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format
        $result | Format-Table
    }
}

function New-JsonFile {
    param(
        [string] $FilePath,

        [hashtable] $Hashtable,

        [switch] $Overwrite
    )

    if (-not $Overwrite -and (Test-Path $FilePath)) { return }

    $Hashtable | ConvertTo-Json -Depth 10 | Out-File -FilePath $FilePath -NoNewline -Encoding UTF8
}

function Initialize-Configuration {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {
        # Validate the input parameters. Couldn't do so in the parameter declaration
        # because the function is contained in the Configuration module imported above.
        $Config.usingSharedCredentials = $Config.ContainsKey("DbConnectionInfo") -and (-not $null -eq $Config.DbConnectionInfo)
        if ($Config.usingSharedCredentials) {
            Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.DbConnectionInfo
            $Config.DbConnectionInfo.ApplicationName = "Ed-Fi ODS WebApi"
            $Config.engine = $Config.DbConnectionInfo.Engine
        }
        else {
            if ($Config.IsMultiTenant) {
                foreach ($tenantKey in $Config.Tenants.Keys) {
                    Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.Tenants[$tenantKey].AdminDbConnectionInfo -RequireDatabaseName
                    Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.Tenants[$tenantKey].SecurityDbConnectionInfo -RequireDatabaseName
                }
            } else {
                Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.AdminDbConnectionInfo
                Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.SecurityDbConnectionInfo
                $Config.AdminDbConnectionInfo.ApplicationName = "Ed-Fi ODS WebApi"
                $Config.SecurityDbConnectionInfo.ApplicationName = "Ed-Fi ODS WebApi"
                $Config.engine = $Config.AdminDbConnectionInfo.Engine
            }
        }
        
        if ([string]::IsNullOrWhiteSpace($Config.OdsConnectionStringEncryptionKey)) {
            $Config.OdsConnectionStringEncryptionKey = New-AESKey
        }
    }
}

function Get-WebApiPackage {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {
        $parameters = @{
            PackageName = $Config.PackageName
            PackageVersion = $Config.PackageVersion
            OutputDirectory = $Config.DownloadPath
            PackageSource = $Config.PackageSource
        }
        $packageDir = Get-NuGetPackage @parameters
        Test-Error

        $Config.PackageDirectory = $packageDir
        $Config.WebConfigLocation = $packageDir
    }
}

function Invoke-TransformWebConfigAppSettings {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {
        $settingsFile = Join-Path $Config.WebConfigLocation "appsettings.json"
        $settings = Get-Content $settingsFile | ConvertFrom-Json | ConvertTo-Hashtable
        $settings.ApiSettings.Engine = $Config.engine
        $settings.ApiSettings.OdsConnectionStringEncryptionKey = $Config.OdsConnectionStringEncryptionKey
        $settings.ApiSettings.OdsContextRouteTemplate = $Config.OdsContextRouteTemplate

        if ($Config.WebApiFeatures.FeatureManagement -ne $null) {
            foreach ($feature in $Config.WebApiFeatures.FeatureManagement.Keys) {
                $settings.FeatureManagement[$feature] = $Config.WebApiFeatures.FeatureManagement[$feature]
            }
        }

        # If IsMultiTenant flag was used, enable MultiTenancy feature
        if ($Config.IsMultiTenant) {
            $settings.FeatureManagement.MultiTenancy = $true
        }

        # Add a Log4net property override to specify the log's destination
        $splitPackageVersion = $Config.PackageVersion.Split(".")

        # If $splitPackageVersion has no value, fetch the latest package version from the PackageDirectory path
        if (-not $splitPackageVersion) {
            $packageName = $Config.PackageName
            $packageDirectory = $Config.PackageDirectory.Path.Split("\\") | Select-Object -Last 1
            $splitPackageVersion = $packageDirectory.Split('.') | Select-Object -Last 3
        }

        # We only care about Major/Minor for determining the log file name
        if ($splitPackageVersion.Count -lt 3) {
            throw "Invalid PackageVersion provided $($Config.PackageVersion). PackageVersion must include major, minor, and patch."
        }
        $logDestination = $Config.LogDestinationPath.replace("{version}", -join($splitPackageVersion[0], ".", $splitPackageVersion[1]))

        if ($null -eq $settings.Log4NetCore) {
            $settings.Log4NetCore = @{ }
        }

        if ($null -eq $settings.Log4NetCore.PropertyOverrides) {
            $settings.Log4NetCore.PropertyOverrides = @()
        }

        $rollingFileXpath = "/log4net/appender[@name='RollingFile']/file"
        if ($settings.Log4NetCore.PropertyOverrides.Where({ $_.XPath -eq $rollingFileXpath }).Count -eq 0) {
            $settings.Log4NetCore.PropertyOverrides += @{
                XPath = $rollingFileXpath
                Attributes = @{
                    Value = $logDestination
                }
            }
        }

        if ($Config.IsSandbox) {
            $settings.ApiSettings.PlainTextSecrets = $Config.WebApiFeatures.PlainTextSecrets
            if ($Config.WebApiFeatures.PlainTextSecrets -eq $null) {
                $settings.ApiSettings.PlainTextSecrets = $true
            }
        }

        if ($Config.WebApiFeatures.BearerTokenTimeoutMinutes) { 
            $settings.ApiSettings.BearerTokenTimeoutMinutes = $Config.WebApiFeatures.BearerTokenTimeoutMinutes 
        }

        if ($Config.WebApiFeatures.ExcludedExtensions) { 
            $settings.ApiSettings.ExcludedExtensions = $Config.WebApiFeatures.ExcludedExtensions 
        }

        New-JsonFile $settingsFile $settings -Overwrite
    }
}


function Invoke-TransformWebConfigConnectionStrings {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {
        if ($Config.usingSharedCredentials) {
            
            $Config.AdminDbConnectionInfo = $Config.DbConnectionInfo.Clone()
            $Config.AdminDbConnectionInfo.DatabaseName = $Config.AdminDatabaseName

            $Config.SecurityDbConnectionInfo = $Config.DbConnectionInfo.Clone()
            $Config.SecurityDbConnectionInfo.DatabaseName = $Config.SecurityDatabaseName
        }
        else {
            # Inject default database names if not provided
            if (-not $Config.AdminDbConnectionInfo.DatabaseName) {
                $Config.AdminDbConnectionInfo.DatabaseName = "EdFi_Admin"
            }

            if (-not $Config.SecurityDbConnectionInfo.DatabaseName) {
                $Config.SecurityDbConnectionInfo.DatabaseName = "EdFi_Security"
            }
        }

        $webConfigPath = "$($Config.PackageDirectory)/appsettings.json"
        $settings = Get-Content $webConfigPath | ConvertFrom-Json | ConvertTo-Hashtable

        Write-Host "Setting database connections in $($Config.WebConfigLocation)"

        $adminconnString = New-ConnectionString -ConnectionInfo $Config.AdminDbConnectionInfo -SspiUsername $Config.WebApplicationName
        $securityConnString = New-ConnectionString -ConnectionInfo $Config.SecurityDbConnectionInfo -SspiUsername $Config.WebApplicationName

        if ($Config.UnEncryptedConnection) {
            $adminconnString += ";Encrypt=false"
            $securityConnString += ";Encrypt=false"
        }
        
        $connectionstrings = @{
            ConnectionStrings = @{
                EdFi_Admin = $adminconnString
                EdFi_Security = $securityConnString 
            }
        }

        $mergedSettings = Merge-Hashtables $settings, $connectionstrings
        New-JsonFile $webConfigPath  $mergedSettings -Overwrite
    }
}

function Invoke-TransformWebConfigMultiTenantConnectionStrings {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {
        $webConfigPath = "$($Config.PackageDirectory)/appsettings.json"
        $settings = Get-Content $webConfigPath | ConvertFrom-Json | ConvertTo-Hashtable

        Write-Host "Setting database connections in $($Config.WebConfigLocation)"

        $newSettings = @{
            Tenants = @{}
        }

        foreach ($tenantKey in $Config.Tenants.Keys) {
            
            if ($Config.usingSharedCredentials) {
                $Config.Tenants[$tenantKey].AdminDbConnectionInfo = $Config.DbConnectionInfo.Clone()
                $Config.Tenants[$tenantKey].AdminDbConnectionInfo.DatabaseName = $Config.Tenants[$tenantKey].AdminDatabaseName

                $Config.Tenants[$tenantKey].SecurityDbConnectionInfo = $Config.DbConnectionInfo.Clone()
                $Config.Tenants[$tenantKey].SecurityDbConnectionInfo.DatabaseName = $Config.Tenants[$tenantKey].SecurityDatabaseName
            }
            
            $adminconnString = New-ConnectionString -ConnectionInfo $Config.Tenants[$tenantKey].AdminDbConnectionInfo -SspiUsername $Config.WebApplicationName
            $securityConnString = New-ConnectionString -ConnectionInfo $Config.Tenants[$tenantKey].SecurityDbConnectionInfo -SspiUsername $Config.WebApplicationName

            if ($Config.UnEncryptedConnection) {
                $adminconnString += ";Encrypt=false"
                $securityConnString += ";Encrypt=false"
            }

            $newSettings.Tenants += @{
                $tenantKey = @{
                    ConnectionStrings = @{
                        EdFi_Admin = $adminconnString
                        EdFi_Security = $securityConnString 
                    }
                }
            }
        }

        $mergedSettings = Merge-Hashtables $settings, $newSettings
        New-JsonFile $webConfigPath  $mergedSettings -Overwrite
    }
}

function Install-Application {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {
        $iisParams = @{
            SourceLocation = $Config.PackageDirectory
            WebApplicationPath = $Config.WebApplicationPath
            WebApplicationName = $Config.WebApplicationName
            WebSitePath = $Config.WebSitePath
            WebSitePort = $WebSitePort
            WebSiteName = $Config.WebSiteName
            CertThumbprint = $Config.CertThumbprint
        }
        Install-EdFiApplicationIntoIIS @iisParams
    }
}

function New-SqlLogins {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {

        if(-not $Config.CreateSqlLogin) {
            return;
        }

        if ($Config.usingSharedCredentials)
        {
            Add-SqlLogins $Config.DbConnectionInfo $Config.WebApplicationName
        }
        else
        {
            if ($Config.IsMultiTenant) {
                foreach ($tenantKey in $Config.Tenants.Keys) {
                    if ($Config.UseAlternateUserName ) { Write-Host ""; Write-Host "Regarding the Admin DB:"; }
                    Add-SqlLogins $Config.Tenants[$tenantKey].AdminDbConnectionInfo $Config.WebApplicationName

                    if ($Config.UseAlternateUserName ) { Write-Host ""; Write-Host "Regarding the Security DB:"; }
                    Add-SqlLogins $Config.Tenants[$tenantKey].SecurityDbConnectionInfo $Config.WebApplicationName
                }
            } else {
                if ($Config.UseAlternateUserName ) { Write-Host ""; Write-Host "Regarding the Admin DB:"; }
                Add-SqlLogins $Config.AdminDbConnectionInfo $Config.WebApplicationName
                
                if ($Config.UseAlternateUserName ) { Write-Host ""; Write-Host "Regarding the Security DB:"; }
                Add-SqlLogins $Config.SecurityDbConnectionInfo $Config.WebApplicationName
            }
        }
    }
}

function Uninstall-EdFiOdsWebApi {
    <#
    .SYNOPSIS
        Removes the Ed-Fi ODS/API web application from IIS.

    .DESCRIPTION
        Removes the Ed-Fi ODS/API web application from IIS, including its application
        pool (if not used for any other application). Removes the web site as well if
        there are no remaining applications, and the site's app pool.

        Does not remove IIS or the URL Rewrite module.

    .EXAMPLE
        Uninstall using all default values.

        PS c:/> Uninstall-EdFiOdsWebApi

    .EXAMPLE
        Uninstall when the web application and web site were setup with non-default values.

        PS c:/> $p = @{
            WebSiteName="Ed-Fi-3"
            WebApplicationPath="d:/octopus/applications/staging/EdFiOdsApi-3"
            WebApplicationName = "EdFiOdsWebApi"
        }
        PS c:/> Uninstall-EdFiOdsWebApi @p
    #>
    [CmdletBinding()]
    param (
        # Path for storing installation tools, e.g. nuget.exe. Default: "./tools".
        [string]
        $ToolsPath = "$PSScriptroot/tools",

        # Path for the web application. Default: "c:\inetpub\Ed-Fi\WebApi".
        [string]
        $WebApplicationPath = "c:\inetpub\Ed-Fi\WebApi",

        # Web application name. Default: "WebApi".
        [string]
        $WebApplicationName = "WebApi",

        # Web site name. Default: "Ed-Fi".
        [string]
        $WebSiteName = "Ed-Fi",

        # Turns off display of script run-time duration.
        [switch]
        $NoDuration
    )
    $config = @{
        ToolsPath = $ToolsPath
        WebApplicationPath = $WebApplicationPath
        WebApplicationName = $WebApplicationName
        WebSiteName = $WebSiteName
    }

    $result = @()

    $elapsed = Use-StopWatch {
        $parameters = @{
            WebApplicationPath = $config.WebApplicationPath
            WebApplicationName = $config.WebApplicationName
            WebSiteName = $config.WebSiteName
        }
        Uninstall-EdFiApplicationFromIIS @parameters

        $result
    }

    Test-Error

    if (-not $NoDuration) {
        $result += New-TaskResult -name "-" -duration "-"
        $result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format
        $result | Format-Table
    }
}

function New-AESKey() {
    <#
        .SYNOPSIS
            Generates and Base64-encodes a 256 bit key appropriate for use with AES encryption.
    #>

    $aes = [System.Security.Cryptography.Aes]::Create()
    $aes.KeySize = 256
    $aes.GenerateKey()
    [System.Convert]::ToBase64String($aes.Key)
}

Export-ModuleMember -Function Install-EdFiOdsWebApi, Uninstall-EdFiOdsWebApi, New-AESKey
