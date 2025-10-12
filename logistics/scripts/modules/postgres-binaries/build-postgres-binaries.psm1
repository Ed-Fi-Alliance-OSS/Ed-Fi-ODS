# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

$ErrorActionPreference = "Stop"

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/tasks/TaskHelper.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/packaging.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/cross-platform.psm1')

function Get-DefaultConfiguration([hashtable] $config = @{ }) {
    $config.binariesSourceUrl = 'http://get.enterprisedb.com/postgresql/'
    $config.binariesArchiveName = 'postgresql-{0}-1-windows-x64-binaries.zip'
    $config.binariesVersion = '16.3'
    $config.binariesTempDirectory = Join-Path ([IO.Path]::GetTempPath()) 'PostgreSQL.Binaries'
    $config.binariesArchiveExtractedName = 'pgsql'

    $config.archiveName = ($config.binariesArchiveName -f $config.binariesVersion)
    $config.archiveSourceUrl = $config.binariesSourceUrl.Trim('/'), $config.archiveName -join '/'
    $config.archivePath = Join-Path $config.binariesTempDirectory $config.archiveName
    $config.archiveExtractedPath = Join-Path $config.binariesTempDirectory $config.binariesArchiveExtractedName

    $config.packagePath = Join-Path $config.binariesTempDirectory 'package'
    $config.packageFiles = @(
        @{ source = Join-Path $PSScriptRoot 'LICENSE.md'; target = "/" }
        @{ source = Join-Path $config.archiveExtractedPath 'bin/'; target = 'tools/' }
    )

    return $config
}

function New-PostgresBinariesPackage([hashtable] $config = (Get-DefaultConfiguration)) {
    Write-HashtableInfo $config

    $script:tasks = @(
        'Remove-TempDirectory'
        'New-TempDirectory'
        'Get-PostgresBinaries'
        'Expand-PostgresBinariesArchive'
        'New-PackageDirectory'
        'Copy-PackageFiles'
        'New-PackageNuspec'
    )

    $script:result = @()

    $elapsed = Use-StopWatch {
        foreach ($task in $tasks) {
            $script:result += Invoke-Task -name $task -task { & $task $config }
        }
    }

    Test-Error

    $script:result += New-TaskResult -name '-' -duration '-'
    $script:result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format

    return $script:result | Format-Table
}

function Remove-TempDirectory([hashtable] $config = (Get-DefaultConfiguration)) {
    if (-not (Test-Path $config.binariesTempDirectory)) { return }

    Remove-Item $config.binariesTempDirectory -Force -Recurse

    Write-Host "Removed Temp Directory: " -NoNewLine
    Write-Host $config.binariesTempDirectory -ForegroundColor DarkGray
}

function New-TempDirectory([hashtable] $config = (Get-DefaultConfiguration)) {
    $config.binariesTempDirectory = New-Item -Force $config.binariesTempDirectory -ItemType Directory

    Write-Host "New Temp Directory: " -NoNewLine
    Write-Host $config.binariesTempDirectory -ForegroundColor Green

    return $config.binariesTempDirectory
}

function Get-PostgresBinaries([hashtable] $config = (Get-DefaultConfiguration)) {
    Write-Host "Downloading Archive: " -NoNewLine
    Write-Host $config.archiveSourceUrl -ForegroundColor DarkGray

    $webClient = New-Object System.Net.WebClient
    $webClient.DownloadFile($config.archiveSourceUrl, $config.archivePath)

    if (-not (Test-Path $config.archivePath)) { return }

    Write-Host "Archive Downloaded: " -NoNewLine
    Write-Host $config.archivePath -ForegroundColor Green
}

function Expand-PostgresBinariesArchive([hashtable] $config = (Get-DefaultConfiguration)) {
    if (Get-IsWindows -and -not (Get-InstalledModule | Where-Object -Property Name -eq "7Zip4Powershell")) {
        Write-Host "Installing 7Zip4Powershell Module" -NoNewLine
        Install-Module -Force -Scope CurrentUser -Name 7Zip4Powershell
    }

    Write-Host "Expanding Archive: " -NoNewLine
    Write-Host $config.archivePath -ForegroundColor DarkGray
    
    if (Get-IsWindows){
        Get-7ZipInformation -ArchiveFileName $config.archivePath | Out-Host
        Expand-7Zip -ArchiveFileName $config.archivePath -TargetPath $config.binariesTempDirectory
    }
    else {
        EnsureCommandIsAvailable "7z"
        7z l @($config.archivePath) | Out-Host
        $arguments = @("x", $config.archivePath, "-o$($config.binariesTempDirectory)")
        7z @arguments
    }

    if (-not (Test-Path $config.archiveExtractedPath)) { return }

    Write-Host "Archive Expanded: " -NoNewLine
    Write-Host $config.archiveExtractedPath -ForegroundColor Green
}

function New-PackageDirectory([hashtable] $config = (Get-DefaultConfiguration)) {
    New-Item -Path $config.packagePath -ItemType "Directory" -Force | Out-Null

    if (-not (Test-Path $config.packagePath)) { return }

    Write-Host "New Package Directory: " -NoNewLine
    Write-Host $config.packagePath -ForegroundColor Green
}

function Copy-PackageFiles([hashtable] $config = (Get-DefaultConfiguration)) {
    foreach ($file in $config.packageFiles) {

        $target = Join-Path $config.packagePath $file.target
        New-Item -Path $target -ItemType "Directory" -Force
        $items = Get-ChildItem $file.source -Recurse

        foreach ($item in $items) {
            Write-Host "copy $($item.Fullname)" -ForegroundColor DarkGray

            $destination = Copy-Item -Path $item.Fullname -destination $target -Force -PassThru

            Write-Host '  -> ' -NoNewLine -ForegroundColor DarkGray
            Write-Host $destination.FullName -ForegroundColor Green
        }
    }
}

function New-PackageNuspec([hashtable] $config = (Get-DefaultConfiguration)) {
    $nuspecPath = Join-Path $config.packagePath 'package.nuspec'

    $params = @{
        nuspecPath               = $nuspecPath
        id                       = '$id$'
        title                    = '$title$'
        description              = '$description$'
        version                  = '$version$'
        authors                  = '$authors$'
        copyright                = '$copyright$'
        owners                   = '$owners$'
        requireLicenseAcceptance = $false
        forceOverwrite           = $true
    }
    New-Nuspec @params

    [xml]$xml = Get-Content $nuspecPath
    $newFile = $xml.CreateElement('file')

    $newFile.SetAttribute('src', '**/*')
    $newFile.SetAttribute('target', '.')

    $filesElem = $xml.GetElementsByTagName('files')[0]
    $filesElem.AppendChild($newFile)

    $xml.Save($nuspecPath)

    Write-Host "Nuspec Created: " -NoNewline
    Write-Host (Get-ChildItem $nuspecPath).FullName -ForegroundColor Green
    Write-Host
}

Export-ModuleMember -Function New-PostgresBinariesPackage
