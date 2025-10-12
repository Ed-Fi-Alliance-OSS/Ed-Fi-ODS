# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#Requires -Version 5.0

Import-Module -Force -Scope Global "$PSScriptRoot/logistics/scripts/modules/path-resolver.psm1"
Import-Module -Force -Scope Global "$PSScriptRoot/logistics/scripts/modules/utility/cross-platform.psm1"
$global:SolutionScriptsDir = Resolve-Path "$PSScriptRoot/Application/SolutionScripts"

function Find-BlockedFiles {
    if (!(Get-IsWindows)) {
        return
    }
    enum ZoneIdentifiers {
        Internet = 3
    }

    ForEach ($repository in Get-RepositoryNames) {
        $zoneIdentifierFiles = Get-ChildItem -Path $PSScriptRoot/../$repository -recurse -Include *.ps1, *.psm1 |
            Select-Object -Expand FullName | Get-Item -Stream "Zone.Identifier" -ErrorAction SilentlyContinue |
            Select-Object -ExpandProperty FileName |
            ForEach-Object { $_ + ":Zone.Identifier" }

        if ($zoneIdentifierFiles.Length -gt 0) {
            $zoneIdentifierFiles | ForEach-Object {
                $zoneIdStr = Get-Content $_ | Select-String -Pattern 'ZoneId';
                $zoneIdStrParsed = $zoneIdStr -split "=";
                $fileZoneIdentifier = [int] $zoneIdStrParsed[1]

                if ($fileZoneIdentifier -eq [ZoneIdentifiers]::Internet) {

                    throw "Blocked file(s) detected.  If you download code via a .zip file, before extracting ensure that you check Unblock in the file's " +
                    "Properties dialog to allow the contents of the contained scripts to execute properly."
                }
            }
        }
    }
}

function global:Update-SolutionScripts {
    foreach ($file in (gci $global:SolutionScriptsDir)) {
        if ($file.extension -eq '.ps1') {
            Write-Host "        Sourcing: $file"
            . $file.fullname
        }
        elseif ($file.extension -eq '.psm1') {
            Write-Host "Importing Module: $file"
            Import-Module $file.fullname -Force
        }
    }
}

Find-BlockedFiles
Update-SolutionScripts

