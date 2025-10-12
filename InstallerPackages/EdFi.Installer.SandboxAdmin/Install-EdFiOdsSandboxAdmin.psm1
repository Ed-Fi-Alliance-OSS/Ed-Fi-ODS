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

function Install-EdFiOdsSandboxAdmin {
    <#
    .SYNOPSIS
        Installs the Ed-Fi ODS Sandbox Admin application into IIS.

    .DESCRIPTION
        Installs and configures the Ed-Fi ODS Sandbox Admin application in IIS
        running in Windows 10 or Windows Server 2016+. As needed, will create
        a new "Ed-Fi" website in IIS, configure it for HTTPS, and load the
        SandboxAdmin binaries as an an application.

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
        PS c:/> Install-EdFiOdsSandboxAdmin @parameters

        Use all available default values, connecting to databases on a single SQL Server instance.
        Connect to the database with integrated security. This will create IIS website "Ed-Fi" 
        with root c:\inetpub\Ed-Fi, and the application files will be in "c:\inetpub\Ed-Fi\SandboxAdmin".
        Installs the most recent full release of the SandboxAdmin software.

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
        PS c:/> Install-EdFiOdsSandboxAdmin @parameters

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
        PS c:/> Install-EdFiOdsSandboxAdmin @parameters

        Connect using integrated security with a specific Windows user. If the user does not already
        exist in SQL Server, the installer will create it with "sysadmin" role.
        After executing the installer, you must ensure that the application pool identity used by 
        SandboxAdmin is the same as the Windows user.

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
            OdsDbConnectionInfo = @{
                Engine="SqlServer"
                Server="edfi-sandbox.my-sql-server.example"
                UseIntegratedSecurity=$true
            }
            MasterDbConnectionInfo = @{
                Engine="SqlServer"
                Server="edfi-sandbox.my-sql-server.example"
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
        PS c:/> Install-EdFiOdsSandboxAdmin @parameters

        Use all available default values, connecting to databases on a single PostgreSQL server
        using the "postgres" user which has to be configured for password-less login in pgpass.conf.
        This will create IIS website "Ed-Fi" with root c:\inetpub\Ed-Fi, and the application files will
        be in "c:\inetpub\Ed-Fi\SandboxAdmin".
        Installs the most recent full release of the SandboxAdmin software.

    .EXAMPLE
        PS c:/> $parameters = @{
            PackageVersion     = '6.0.0'
            WebSitePath        = 'c:\inetpub\Ed-Fi'
            WebSitePort        = 8765
            WebApplicationPath = 'SandboxAdmin'
            WebApplicationName = 'SandboxAdmin6.0.0'
            Settings           = @{
                OAuthUrl                     = 'https://localhost/EdFiOdsWebApi'
                DefaultApplicationName       = 'My Sandbox Administrator'
                DefaultOperationalContextUri = 'uri://sample.edu'
                PreserveLoginUrl             = $false
                User                         = @{
                    'Test Admin' = @{
                        Email             = 'test@ed-fi.org'
                        Password          = '***REMOVED***'
                        Admin             = $true
                        NamespacePrefixes = @('uri://ed-fi.org', 'uri://gbisd.edu')
                        Sandboxes         = @{
                            'Populated Demonstration Sandbox' = @{
                                Key     = 'populatedSandbox'
                                Secret  = 'populatedSandboxSecret'
                                Type    = 'Sample'
                                Refresh = $false
                            }
                            'Minimal Demonstration Sandbox'   = @{
                                Key     = 'minimalSandbox'
                                Secret  = 'minimalSandboxSecret'
                                Type    = 'Minimal'
                                Refresh = $false
                            }
                        }
                    }
                }
            }
            DbConnectionInfo = @{
                Engine="SqlServer"
                Server="localhost"
                UseIntegratedSecurity=$true
            }
        }
        PS c:/> Install-EdFiOdsSandboxAdmin @parameters

        Detailed example setting many customizations.
    #>
    [CmdletBinding()]
    param (
        # NuGet package name. Default: EdFi.Suite3.Ods.SandboxAdmin.Web.
        [string]
        $PackageName = "EdFi.Suite3.Ods.SandboxAdmin",

        # NuGet package version. If not set, will retrieve the latest full release package.
        [string]
        $PackageVersion,

        # NuGet package source. default value is set for release package source for installer .
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

        # Web site port number. Default: 443.
        [int]
        $WebSitePort = 443,

        # Path for the web application. Default: "SandboxAdmin".
        [string]
        $WebApplicationPath = "SandboxAdmin", # NB: _must_ use backslash with IIS settings

        # Web application name. Default: "SandboxAdmin".
        [string]
        $WebApplicationName = "SandboxAdmin",

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
        [hashtable]
        [Parameter(Mandatory=$true, ParameterSetName="SharedCredentials")]
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

        #"EdFi_Admin.OdsInstances" entries will be based on this database connectivity 
        # information.
        #
        # The hashtable must include: Server, Engine (SqlServer or PostgreSQL), and
        # either UseIntegratedSecurity or Username and Password (Password can be skipped
        # for PostgreSQL when using pgconf file). Optionally can include Port.
        [hashtable]
        [Parameter(Mandatory=$true, ParameterSetName="SeparateCredentials")]
        $OdsDbConnectionInfo,

        # Database connectivity only for the "master" DB (if using SqlServer)
        # or "postgres" DB (if using PostgreSQL). Used for creating the Sandbox databases.
        #
        # The hashtable must include: Server, Engine (SqlServer or PostgreSQL), and
        # either UseIntegratedSecurity or Username and Password (Password can be skipped
        # for PostgreSQL when using pgconf file). Optionally can include Port.
        [hashtable]
        [Parameter(Mandatory=$true, ParameterSetName="SeparateCredentials")]
        $MasterDbConnectionInfo,

        # Whether to create the database server login for the application if they do not already exist
        # IMPORTANT: Database logins created by the installer will have database server administrator rights. 
        #            If more restrictive permissions are required, the database login used by the SandboxAdmin should be created manually
        #            before executing the installer.
        # 
        # To create a custom login for SQL Server:
        #    If integrated security is not enabled, a username and password must be provided in the database connection information (DbConnectionInfo) parameter(s)
        #    If integrated security is enabled, the username provided must be a valid Windows user, or left blank to use the default application pool identity
        #       The application pool identity used by SandboxAdmin needs to be manually updated to use the same Windows username 
        # To create a custom login for Postgres:
        #    If integrated security is not enabled, a username must be provided in the database connection information parameter(s). A password can be optionally specified
        #    If integrated security is enabled, pg_ident.conf map needs to be updated to use the username provided
        [bool]
        $CreateSqlLogin = $true,

        # Optional hashtable containing appSettings override values.
        [hashtable]
        $Settings = @{ OAuthUrl = "https://localhost/EdFiOdsWebApi" },
        
        # Initial client key to load into the appSettings.config file. Default: Random string value.
        [string]
        $PrePopulatedKey,
        
        # Initial client secret to load into the appSettings.config file. Default: Random string value.
        [string]
        $PrePopulatedSecret,
        
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
        WebSiteName = $WebSiteName
        WebSitePort = $WebSitePort
        WebApplicationName = $WebApplicationName
        AdminDatabaseName = $AdminDatabaseName
        SecurityDatabaseName = $SecurityDatabaseName
        DbConnectionInfo = $DbConnectionInfo
        AdminDbConnectionInfo = $AdminDbConnectionInfo
        SecurityDbConnectionInfo = $SecurityDbConnectionInfo
        OdsDbConnectionInfo = $OdsDbConnectionInfo
        MasterDbConnectionInfo = $MasterDbConnectionInfo
        CreateSqlLogin = $CreateSqlLogin
        Settings           = $Settings
        PrePopulatedKey = $PrePopulatedKey
        PrePopulatedSecret = $PrePopulatedSecret
        UnEncryptedConnection = $UnEncryptedConnection
    }

    $elapsed = Use-StopWatch {
        $result += Initialize-Configuration -Config $config
        $result += Get-SandboxAdminPackage $config
        $result += Invoke-TransformWebConfigAppSettings -Config $config
        $result += Invoke-TransformWebConfigConnectionStrings -Config $config
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
            $Config.DbConnectionInfo.ApplicationName = "Ed-Fi SandboxAdmin"
            $Config.engine = $Config.DbConnectionInfo.Engine
        }
        else {
            Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.AdminDbConnectionInfo
            Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.SecurityDbConnectionInfo
            Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.OdsDbConnectionInfo
            Assert-DatabaseConnectionInfo -DbConnectionInfo $Config.MasterDbConnectionInfo
            $Config.AdminDbConnectionInfo.ApplicationName = "Ed-Fi SandboxAdmin"
            $Config.SecurityDbConnectionInfo.ApplicationName = "Ed-Fi SandboxAdmin"
            $Config.OdsDbConnectionInfo.ApplicationName = "Ed-Fi SandboxAdmin"
            $Config.MasterDbConnectionInfo.ApplicationName = "Ed-Fi SandboxAdmin"
            $Config.engine = $Config.AdminDbConnectionInfo.Engine
        }
    }
}

function Get-SandboxAdminPackage {
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
        $settings = Merge-Hashtables $settings, (Get-DefaultCredentialSettings -PrepopulatedKey: $Config.PrepopulatedKey -PrepopulatedSecret: $Config.PrepopulatedSecret), $Config.Settings
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

            $Config.OdsDbConnectionInfo = $Config.DbConnectionInfo.Clone()
            $Config.MasterDbConnectionInfo = $Config.DbConnectionInfo.Clone()
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
        $Config.OdsDbConnectionInfo.DatabaseName = "EdFi_{0}"
        $Config.MasterDbConnectionInfo.DatabaseName = "master"
        if ($Config.engine -ieq "PostgreSQL") {
            $Config.MasterDbConnectionInfo.DatabaseName = "postgres"
        }
        
        $webConfigPath = "$($Config.PackageDirectory)/appsettings.json"
        $settings = Get-Content $webConfigPath | ConvertFrom-Json | ConvertTo-Hashtable

        Write-Host "Setting database connections in $($Config.WebConfigLocation)"

        $adminconnString = New-ConnectionString -ConnectionInfo $Config.AdminDbConnectionInfo -SspiUsername $Config.WebApplicationName
        $securityConnString = New-ConnectionString -ConnectionInfo $Config.SecurityDbConnectionInfo -SspiUsername $Config.WebApplicationName
        $odsConnString = New-ConnectionString -ConnectionInfo $Config.OdsDbConnectionInfo -SspiUsername $Config.WebApplicationName
        $masterConnString = New-ConnectionString -ConnectionInfo $Config.MasterDbConnectionInfo -SspiUsername $Config.WebApplicationName

        if ($Config.UnEncryptedConnection) {
            $adminconnString += ";Encrypt=false"
            $securityConnString += ";Encrypt=false"
            $odsConnString += ";Encrypt=false"
            $masterConnString += ";Encrypt=false"
        }

        if ($Config.engine -ieq "PostgreSQL") {
            # Enable connection pooling for PostgreSQL
            $poolingConfiguration = ";Pooling=true; Minimum Pool Size=10; Maximum Pool Size=50"
            $adminconnString += $poolingConfiguration
            $securityConnString += $poolingConfiguration
            $odsConnString += $poolingConfiguration
        }

        $connectionstrings = @{
            ConnectionStrings = @{
                EdFi_Admin = $adminconnString
                EdFi_Security = $securityConnString 
                EdFi_Ods = $odsConnString 
                EdFi_Master = $masterConnString
            }
        }

        $mergedSettings = Merge-Hashtables $settings, $connectionstrings
        New-JsonFile $webConfigPath  $mergedSettings -Overwrite
    }
}
function Get-DefaultCredentialSettings {
    param(
        [string] $PrePopulatedKey,

        [string] $PrePopulatedSecret
    )
    
    function Get-RandomString([int] $length = 20) {
        return ([char[]]([char]65..[char]90) + ([char[]]([char]97..[char]122)) + 0..9 | Sort-Object { Get-Random })[0..$length] -join ''
    }

    return @{
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
                        Key     = if ($PrePopulatedKey.Length -ne 0) {$PrePopulatedKey} else {Get-RandomString}
                        Secret  = if ($PrePopulatedSecret.Length -ne 0) {$PrePopulatedSecret} else {Get-RandomString}
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
            Add-SqlLogins $Config.AdminDbConnectionInfo $Config.WebApplicationName
            Add-SqlLogins $Config.SecurityDbConnectionInfo $Config.WebApplicationName
            Add-SqlLogins $Config.OdsDbConnectionInfo $Config.WebApplicationName
            Add-SqlLogins $Config.MasterDbConnectionInfo $Config.WebApplicationName
        }
    }
}

function Uninstall-EdFiOdsSandboxAdmin {
    <#
    .SYNOPSIS
        Removes the Ed-Fi ODS/API web application from IIS.
    .DESCRIPTION
        Removes the Ed-Fi ODS/API web application from IIS, including its application
        pool (if not used for any other application). Removes the web site as well if
        there are no remaining applications, and the site's app pool.

        Does not remove IIS or the URL Rewrite module.

    .EXAMPLE
        PS c:/> Uninstall-EdFiOdsSandboxAdmin

        Uninstall using all default values.
    .EXAMPLE
        PS c:/> $p = @{
            WebSiteName="Ed-Fi"
            WebApplicationPath="d:/octopus/applications/staging/Sandbox-3"
            WebApplicationName = "Sandbox"
        }
        PS c:/> Uninstall-EdFiOdsSandboxAdmin @p

        Uninstall when the web application and web site were setup with non-default values.
    #>
    [CmdletBinding()]
    param (
        # Path for storing installation tools, e.g. nuget.exe. Default: "./tools".
        [string]
        $ToolsPath = "$PSScriptRoot/tools",

        # Path for the web application. Default: "c:\inetpub\Ed-Fi\SandboxAdmin".
        [string]
        $WebApplicationPath = "c:\inetpub\Ed-Fi\SandboxAdmin",

        # Web application name. Default: "SandboxAdmin".
        [string]
        $WebApplicationName = "SandboxAdmin",

        # Web site name. Default: "Ed-Fi".
        [string]
        $WebSiteName = "Ed-Fi",

        # Turns off display of script run-time duration.
        [switch]
        $NoDuration
    )

    $result = @()

    $elapsed = Use-StopWatch {
        $parameters = @{
            WebApplicationPath = $WebApplicationPath
            WebApplicationName = $WebApplicationName
            WebSiteName        = $WebSiteName
        }
        $result += Uninstall-EdFiApplicationFromIIS @parameters
        $result
    }

    Test-Error

    if (-not $NoDuration) {
        $result += New-TaskResult -name "-" -duration "-"
        $result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format
        $result | Format-Table
    }
}

Export-ModuleMember -Function Install-EdFiOdsSandboxAdmin, Uninstall-EdFiOdsSandboxAdmin
