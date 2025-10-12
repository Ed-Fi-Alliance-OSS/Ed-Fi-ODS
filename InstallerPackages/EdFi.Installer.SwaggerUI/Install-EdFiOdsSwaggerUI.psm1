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

# Import the following with global  scope so that they are available inside of script blocks
Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Application/Install.psm1
Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Application/Uninstall.psm1
Import-Module -Force -Scope Global $PSScriptRoot/AppCommon/Application/Configuration.psm1

function Install-EdFiOdsSwaggerUI {
    <#
    .SYNOPSIS
        Installs the Ed-Fi ODS Swagger application into IIS.

    .DESCRIPTION
        Installs and configures the Ed-Fi ODS Swagger application in IIS running
        in Windows 10 or Windows Server 2016+. As needed, will create a new "Ed-Fi"
        website in IIS, configure it for HTTPS, and load the SwaggerUI binaries as an
        application. Transforms the web.config by injecting the correct Ed-Fi ODS/API
        version and metadata URLs.

    .EXAMPLE
        PS c:/> $parameters = @{
            ToolsPath = "C:/temp/tools"
            WebApiMetadataUrl = "https://my-server.example/EdFiOdsWebApi/metadata"
            WebApiVersionUrl = "https://my-server.example/EdFiOdsWebApi"
            WebSitePath="c:\inetpub\Ed-Fi"
            WebApplicationPath="SwaggerUI"
        }
        PS c:/> Install-EdFiOdsSwaggerUI @parameters
    #>
    [CmdletBinding()]
    param (
        # NuGet package name. Default: EdFi.Suite3.Ods.SwaggerUI.
        [string]
        $PackageName = "EdFi.Suite3.Ods.SwaggerUI",

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

        # Web site port number. Default: 443.
        [int]
        $WebSitePort = 443,

        # Path for the web application. Default: "SwaggerUI".
        [string]
        $WebApplicationPath = "SwaggerUI", # NB: _must_ use backslash with IIS settings

        # Web application name. Default: "SwaggerUI".
        [string]
        $WebApplicationName = "SwaggerUI",

        # Full URL to the Ed-Fi ODS / API metadata endpoint.
        [string]
        [Obsolete("This parameter is deprecated, and will be removed in the near future.")]
        $WebApiMetadataUrl,

        # Full URL to the Ed-Fi ODS / API version endpoint.
        [string]
        [Parameter(Mandatory=$true)]
        $WebApiVersionUrl,

        # When true, pre-populated key and secret will not be injected into the config file.
        [switch]
        $DisablePrepopulatedCredentials,

        # Initial client key to load into the web.config file. Default: populatedSandbox.
        [string]
        $PrePopulatedKey = "populatedSandbox",

        # Initial client secret to load into the web.config file. Default: populatedSandboxSecret.
        [string]
        $PrePopulatedSecret = "populatedSandboxSecret",

        # Turns off display of script run-time duration.
        [switch]
        $NoDuration,
        
        # List of Tenants deployed
        # If MultiTenancy is enabled, then at least one valid tenant identifier must be provided
        [string[]]
        $Tenants,

        # Show Domains in Swagger.
        # Default value: true, set to false to hide domains.
        [bool]
        $ShowDomainsInSwaggerUI = $true
    )

    Write-InvocationInfo $MyInvocation

    Clear-Error

    $result = @()

    $Config = @{
        WebApplicationPath = (Join-Path $WebSitePath $WebApplicationPath)
        PackageName = $PackageName
        PackageVersion = $PackageVersion
        PackageSource = $PackageSource
        ToolsPath = $ToolsPath
        DownloadPath = $DownloadPath
        WebSitePath = $WebSitePath
        WebSiteName = $WebsiteName
        WebSitePort = $WebsitePort
        WebApplicationName = $WebApplicationName
        WebApiMetadataUrl = $WebApiMetadataUrl
        WebApiVersionUrl = $WebApiVersionUrl
        PrePopulatedKey = $PrePopulatedKey
        PrePopulatedSecret = $PrePopulatedSecret
        DisablePrepopulatedCredentials = $DisablePrepopulatedCredentials
        NoDuration = $NoDuration
        Tenants = $Tenants
        ShowDomainsInSwaggerUI = $ShowDomainsInSwaggerUI
    }

    $elapsed = Use-StopWatch {

        $result += Get-SwaggerPackage -Config $Config
        $result += Invoke-TransformWebConfigAppSettings -Config $Config
        $result += Install-Application -Config $Config

        $result
    }

    Test-Error

    if (-not $NoDuration) {
        $result += New-TaskResult -name "-" -duration "-"
        $result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format
        $result | Format-Table
    }
}

function Uninstall-EdFiOdsSwaggerUI {
    <#
    .SYNOPSIS
        Removes the Ed-Fi ODS/API web application from IIS.
    .DESCRIPTION
        Removes the Ed-Fi ODS/API web application from IIS, including its application
        pool (if not used for any other application). Removes the web site as well if
        there are no remaining applications, and the site's app pool.

        Does not remove IIS or the URL Rewrite module.

    .EXAMPLE
        PS c:/> Uninstall-EdFiOdsSwaggerUI

        Uninstall using all default values.
    .EXAMPLE
        PS c:/> $p = @{
            WebSiteName="Ed-Fi-3"
            WebApplicationPath="d:/octopus/applications/staging/SwaggerUI-3"
            WebApplicationName = "SwaggerUI"
        }
        PS c:/> Uninstall-EdFiOdsSwaggerUI @p

        Uninstall when the web application and web site were setup with non-default values.
    #>
    [CmdletBinding()]
    param (
        # Path for storing installation tools, e.g. nuget.exe. Default: "./tools".
        [string]
        $ToolsPath = "$PSScriptRoot/tools",

        # Path for the web application. Default: "c:\inetpub\Ed-Fi\SwaggerUI".
        [string]
        $WebApplicationPath = "c:\inetpub\Ed-Fi\SwaggerUI",

        # Web application name. Default: "SwaggerUI".
        [string]
        $WebApplicationName = "SwaggerUI",

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
            WebApplicationPath = $Config.WebApplicationPath
            WebApplicationName = $Config.WebApplicationName
            WebSiteName = $Config.WebSiteName
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

function Get-SwaggerPackage {
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

        $Config.PackageDirectory = $packageDir
        $Config.WebConfigLocation = $packageDir
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

function Invoke-TransformWebConfigAppSettings {
    [CmdletBinding()]
    param (
        [hashtable]
        [Parameter(Mandatory=$true)]
        $Config
    )

    Invoke-Task -Name ($MyInvocation.MyCommand.Name) -Task {

        if ($Config.DisablePrepopulatedCredentials) {
            $Config.PrePopulatedKey = [string]::Empty
            $Config.PrePopulatedSecret = [string]::Empty
        }
        
        $appSettings = @{
            WebApiVersionUrl = $Config.WebApiVersionUrl
            SwaggerUIOptions = @{
                ShowDomains = $Config.ShowDomainsInSwaggerUI
                OAuthConfigObject = @{
                    ClientId     = $Config.PrePopulatedKey
                    ClientSecret = $Config.PrePopulatedSecret
                }
            }
        }

        if ($Config.Tenants.Count -gt 0) {
            $appSettings += @{ Tenants = @() }
            
            foreach ($tenant in $Config.Tenants) {
                $appSettings.Tenants += @{ Tenant = $tenant }
            }
        }
        
        $settingsFile = Join-Path $Config.WebConfigLocation "appsettings.json"
        $settings = Get-Content $settingsFile | ConvertFrom-Json | ConvertTo-Hashtable
        $mergedSettings = Merge-Hashtables $settings, $appSettings
        New-JsonFile $settingsFile $mergedSettings -Overwrite
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

Export-ModuleMember -Function Install-EdFiOdsSwaggerUI, Uninstall-EdFiOdsSwaggerUI
