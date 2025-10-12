# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

$toolVersions = @{
    octopusClient = "7.2.0"
}

<#
.SYNOPSIS
    Functions for managing Octopus Deploy.
.DESCRIPTION
    Contains functions for managing Octopus Deploy, including:

      - Create a new channel
      - Create a new release
      - Deploy a release

    Uses .NET tool version of Octopus Client.
#>
$ErrorActionPreference = "Stop"

& "$PSScriptRoot/load-path-resolver.ps1"
Import-Module -Force $folders.modules.invoke('tasks/TaskHelper.psm1')
Import-Module -Force $folders.modules.invoke('tools/ToolsHelper.psm1')

$defaultToolsPath = $env:toolsPath
if (-not $defaultToolsPath) {
    $implementation = (Get-Item "$PSScriptRoot/../../..").FullName
    $defaultToolsPath = Join-Path $implementation 'tools'
}

function Install-OctopusClient {
    <#
        .SYNOPSIS
            Installs the Octopus Client into the tools directory, if not already present. Is idempotent.
        .PARAMETER ToolsPath
            Optional override for tools path. Default value is "tools" directly at the repository root.
    #>
    param (
        [string]
        $ToolsPath = $defaultToolsPath
    )

    $parameters = @{
        Path = $ToolsPath
        Name = "Octopus.DotNet.Cli"
        Version = $toolVersions.octopusClient
    }
    Install-DotNetTool @parameters

    Test-Error
}

function Invoke-OctopusCreateChannel {
    <#
        .SYNOPSIS
            Creates a new channel in an existing Octopus project.
        .PARAMETER ToolsPath
            Optional override for tools path. Default value is "tools" directly at the repository root.
        .PARAMETER ServerBaseUrl
            Base URL for the Octopus Deploy server.
        .PARAMETER ApiKey
            API key for an Octopus Deploy user with permission to create channels.
        .PARAMETER Timeout
            Optional setting to override the default 600 second operation timeout.
        .PARAMETER Project
            Name of the Octopus Deploy project in which to create the channel.
        .PARAMETER Channel
            Name of the channel to create.
        .EXAMPLE
            $parms = @{
                ServerBaseUrl="https://intedfideploy1.msdf.org/"
                ApiKey="API-............"
                Timeout=601
                Project="Ed-Fi ODS Shared Instance (SQL Server)"
                Channel="testing"
            }
            Invoke-OctoCreateChannel @parms
    #>
    param (
        [string]
        $ToolsPath = $defaultToolsPath,

        [Parameter(Mandatory=$true)]
        [string]
        $ServerBaseUrl,

        [Parameter(Mandatory=$true)]
        [string]
        $ApiKey,

        [int]
        $Timeout = 600,

        [Parameter(Mandatory=$true)]
        [string]
        $Project,

        [Parameter(Mandatory=$true)]
        [string]
        $Channel
    )

    Install-OctopusClient

    $params = @(
        "--project", $Project,
        "--channel", $Channel,
        "--update-existing",
        "--server", $ServerBaseUrl,
        "--apiKey", $ApiKey,
        "--timeout", $Timeout
    )

    Write-Host -ForegroundColor Magenta "& dotnet-octo create-channel $params"
    &$ToolsPath/dotnet-octo create-channel $params

    Test-Error
}

function Invoke-OctopusCreateRelease {
    <#
        .SYNOPSIS
            Creates a new release in an existing channel on an Octopus Deploy project. Is idempotent.
        .PARAMETER ToolsPath
            Optional override for tools path. Default value is "tools" directly at the repository root.
        .PARAMETER ServerBaseUrl
            Base URL for the Octopus Deploy server.
        .PARAMETER ApiKey
            API key for an Octopus Deploy user with permission to create channels.
        .PARAMETER Timeout
            Optional setting to override the default 600 second operation timeout.
        .PARAMETER Project
            Name of the Octopus Deploy project in which to create the channel.
        .PARAMETER Channel
            Name of the channel to create.
        .PARAMETER PackageVersion
            Version of the package(s) to deploy.
        .PARAMETER Version
            Release version number. Defaults to same as packageVersion.
        .EXAMPLE
            $parms = @{
                ServerBaseUrl="https://intedfideploy1.msdf.org/"
                ApiKey="API-............"
                Timeout=601
                Project="Ed-Fi ODS Shared Instance (SQL Server)"
                Channel="testing"
                PackageVersion="3.4.0-b102345"
                Version="3.4.0-b102345-optionally-make-this-is-different-from-packageVersion"
            }
            Invoke-OctoCreateChannel @parms
    #>
    param (
        [string]
        $ToolsPath = $defaultToolsPath,

        [Parameter(Mandatory=$true)]
        [string]
        $ServerBaseUrl,

        [Parameter(Mandatory=$true)]
        [string]
        $ApiKey,

        [int]
        $Timeout = 600,

        [Parameter(Mandatory=$true)]
        [string]
        $Project,

        [Parameter(Mandatory=$true)]
        [string]
        $Channel,

        [Parameter(Mandatory=$true)]
        [string]
        $PackageVersion,

        [string]
        $Version = $PackageVersion
    )

    Install-OctopusClient

    $params = @(
        "--project", $Project,
        "--packageversion", $PackageVersion,
        "--version", $Version,
        "--channel", $Channel,
        "--ignoreexisting",
        "--server", $ServerBaseUrl,
        "--apiKey", $ApiKey,
        "--timeout", $Timeout
    )

    Write-Host -ForegroundColor Magenta "& dotnet-octo create-release $params"
    &$ToolsPath/dotnet-octo create-release $params

    Test-Error
}

function Invoke-OctopusDeployRelease {
    <#
        .SYNOPSIS
            Triggers deployment of an already-created release in Octopus Deploy.
        .PARAMETER ToolsPath
            Optional override for tools path. Default value is "tools" directly at the repository root.
        .PARAMETER ServerBaseUrl
            Base URL for the Octopus Deploy server.
        .PARAMETER ApiKey
            API key for an Octopus Deploy user with permission to create channels.
        .PARAMETER Timeout
            Optional setting to override the default 600 second operation timeout.
        .PARAMETER Project
            Name of the Octopus Deploy project in which to create the channel.
        .PARAMETER Channel
            Name of the channel to create.
        .PARAMETER DeploymentTimeout
            Optional setting to override the maximum time to wait for the deploy to finish.
            Deployment is not cancelled if the timespan is exceeded.
        .PARAMETER Environment
            The environment in which to deploy the release.
        .PARAMETER Version
            Release version number.
        .EXAMPLE
            $parms = @{
                ServerBaseUrl="https://intedfideploy1.msdf.org/"
                ApiKey="API-............"
                Timeout=601
                Project="Ed-Fi ODS Shared Instance (SQL Server)"
                Channel="testing"
                DeploymentTimeout="00:50:00"
                Environment="Staging"
                Version="3.4.0-b102345-optionally-make-this-is-different-from-packageVersion"
            }
            Invoke-OctoCreateChannel @parms
    #>
    param (
        [string]
        $ToolsPath = $defaultToolsPath,

        [Parameter(Mandatory=$true)]
        [string]
        $ServerBaseUrl,

        [Parameter(Mandatory=$true)]
        [string]
        $ApiKey,

        [int]
        $Timeout = 600,

        [Parameter(Mandatory=$true)]
        [string]
        $Project,

        [Parameter(Mandatory=$true)]
        [string]
        $Channel,

        [timespan]
        $DeploymentTimeout = "00:10:00",

        [Parameter(Mandatory=$true)]
        [string]
        $Environment,

        [Parameter(Mandatory=$true)]
        $Version
    )

    Install-OctopusClient

    $params = @(
        "--waitfordeployment",
        "--deploymenttimeout", $DeploymentTimeout,
        "--deployto", $Environment,
        "--project", $Project,
        "--version", $Version,
        "--channel", $Channel,
        "--server", $ServerBaseUrl,
        "--apiKey", $ApiKey,
        "--timeout", $Timeout
    )

    Write-Host -ForegroundColor Magenta "& dotnet-octo deploy-release $params"
    &$ToolsPath/dotnet-octo deploy-release $params

    Test-Error
}

Export-ModuleMember -Function `
    Invoke-OctopusCreateChannel, `
    Invoke-OctopusCreateRelease, `
    Invoke-OctopusDeployRelease
