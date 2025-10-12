# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -version 5
param (
    # Informational version number, defaults 1.0    
    [string]
    [Parameter(Mandatory = $true)]
    $InformationalVersion = "1.0",

    # Build counter from the automation tool, defaults to 1
    [string]
    $BuildCounter = "1",

    # Build incrementer to add to the build counter to offset number from TeamCity builds, defaults to 0
    [string]
    $BuildIncrementer = "0",

    [string]
    $NuGetFeed,

    [string]
    $NuGetApiKey  
)
$ErrorActionPreference = "Stop"

Invoke-Expression "$PSScriptRoot/../prep-installer-package.ps1 $PSScriptRoot"

$verbose = $PSCmdlet.MyInvocation.BoundParameters["Verbose"]

Import-Module "$PSScriptRoot/../../logistics/scripts/modules/packaging/create-package.psm1" -Force

$newRevision = ([int]$BuildCounter) + ([int]$BuildIncrementer)
$SemanticVersion = "$InformationalVersion.$newRevision"

$parameters = @{
    PackageDefinitionFile = Resolve-Path ("$PSScriptRoot/EdFi.Installer.SandboxAdmin.nuspec")
    Version               = $SemanticVersion
    OutputDirectory       = Resolve-Path $PSScriptRoot
    Publish               = $true
    Source                = $NuGetFeed
    ApiKey                = $NuGetApiKey
}

Invoke-CreatePackage @parameters -Verbose:$verbose
