# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
.SYNOPSIS
    Downloads a zip archive containing the populated template backup
.DESCRIPTION
    Given a source url to a zip archive this will download and unzip to the Database folder.
.INPUTS
    [uri] Source Url
    [string] File Name
.OUTPUTS
    None.
#>
param (
    # The source url to download the zip archive from
    [Parameter(Mandatory)]
    [uri] $sourceUrl,
    # The name of the file that is downloaded from the source url
    [Parameter(Mandatory)]
    [string] $fileName
)

& "$PSScriptRoot/../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "DatabaseTemplate/Modules/database-template-source.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/cross-platform.psm1')

if (Get-IsWindows -and -not Get-InstalledModule | Where-Object -Property Name -eq "7Zip4Powershell") {
    Install-Module -Force -Scope CurrentUser -Name 7Zip4Powershell
}

# using WebClient is faster then Invoke-WebRequest but shows no progress
Write-host "Downloading file from $sourceUrl..."
$webClient = New-Object System.Net.WebClient
$webClient.DownloadFile($sourceUrl, "$global:templateFolder/$fileName")

Write-host "Download complete."

if (Test-Path $global:templateDatabaseFolder) { Remove-Item -Force -Recurse -Path $global:templateDatabaseFolder | Out-Null }
New-Item -Path $global:templateDatabaseFolder -ItemType "Directory" | Out-Null

if (-not (Test-Path "$global:templateFolder/$fileName")) {
    Write-Warning "Populated Template source file '$fileName' not found."
    exit 0
}

if ($fileName.EndsWith('.zip') -or $fileName.EndsWith('.7z')) {
    Write-host "Extracting $fileName..."
    if (Get-IsWindows){
        Expand-7Zip -ArchiveFileName "$global:templateFolder/$fileName" -TargetPath "$global:templateDatabaseFolder"
    }
    else {
        EnsureCommandIsAvailable "7z"
        $arguments = @("x", "$global:templateFolder/$fileName", "-o$global:templateDatabaseFolder")
        7z @arguments | Out-Null
    }
    Write-Host "Extracted to: $global:templateDatabaseFolder/$fileName" -ForegroundColor Green
}
if ($error.count -gt 0 -or $LASTEXITCODE -gt 0) { exit 1; }