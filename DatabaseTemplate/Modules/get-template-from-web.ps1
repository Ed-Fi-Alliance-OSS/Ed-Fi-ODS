# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
.SYNOPSIS
    Downloads a backup file or zip archive containing the template backup
.DESCRIPTION
    Given a source url to a backup file or zip archive this will download and extract if necessary to the Database folder.
.INPUTS
    [uri] Source Url
    [string] File Name
.OUTPUTS
    None.
#>
param (
    # The source url to download the backup from
    [Parameter(Mandatory)]
    [uri] $sourceUrl,

    # The name of the file that is downloaded from the source url
    [Parameter(Mandatory)]
    [string] $fileName
)

& "$PSScriptRoot/../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "DatabaseTemplate/Modules/database-template-source.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/utility/cross-platform.psm1")

$isArchiveFile = $fileName.EndsWith('.zip') -or $fileName.EndsWith('.7z')
$archiveBackupFilePath = Join-Path $global:templateFolder $fileName
$finalBackupFilePath = Join-Path $global:templateDatabaseFolder $fileName

if (Test-Path $finalBackupFilePath) {
    Write-Host "Template found, using existing file at $finalBackupFilePath"
    return $finalBackupFilePath
}

# using WebClient is faster then Invoke-WebRequest but shows no progress
Write-Host "Downloading file from $sourceUrl..."
$webClient = New-Object System.Net.WebClient

if ($isArchiveFile) {
    if (-not (Test-Path $archiveBackupFilePath)) {
        $webClient.DownloadFile($sourceUrl, $archiveBackupFilePath)
    }

    if (-not (Test-Path $archiveBackupFilePath)) {
        Write-Error "Template source file '$archiveBackupFilePath' not found."

        exit -1
    }
}
else {
    $webClient.DownloadFile($sourceUrl, $finalBackupFilePath)

    if (-not (Test-Path $finalBackupFilePath)) {
        Write-Error "Template source file '$finalBackupFilePath' not found."

        exit -1
    }
}

Write-Host "Download complete."

if ($isArchiveFile) {
    Write-Host "Extracting $archiveBackupFilePath..."
    $targetPath = $finalBackupFilePath.split('.')[-2]
    if (Get-IsWindows) {
        if (-not (Get-InstalledModule "7Zip4Powershell" -ErrorAction silentlycontinue)) {
            Install-Module -Force -Scope CurrentUser -Name 7Zip4Powershell
        }
        Expand-7Zip -ArchiveFileName $archiveBackupFilePath -TargetPath $targetPath
    }
    else {
        EnsureCommandIsAvailable "7z"
        $arguments = @("x", $archiveBackupFilePath, "-o$targetPath")
        7z @arguments | Out-Null
    }
    Write-Host "Extracted to: $targetPath" -ForegroundColor Green
    $finalBackupFilePath = $targetPath
}

if ($error.count -gt 0 -or $LASTEXITCODE -gt 0) { exit 1; }

return $finalBackupFilePath