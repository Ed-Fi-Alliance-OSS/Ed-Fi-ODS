# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

[CmdLetBinding()]
param(
    [string]
    [ValidateSet("Get-TpdmTag")]
    $Command = "Get-TpdmTag",

    [string]
    $StandardVersion
)

function Get-TpdmTag {
    param (
        [string]
        $StandardVersion
    )

    (Get-Content versionmap.json | ConvertFrom-Json).'Ed-Fi-TPDM-Artifacts'.$StandardVersion
}

try {
    switch ($Command) {
        Get-TpdmTag { Get-TpdmTag($standardversion) }
    }
    exit 0
} catch [Exception] {
    Write-Host
    Write-Error $_.Exception.Message
    exit 1
}