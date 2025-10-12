# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/database-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/plugin/plugin-source.psm1')

function Get-DatabaseIds {
    return @{
        master   = @{ database = 'Master'; connectionStringKey = 'EdFi_Master' }
        admin    = @{ database = 'Admin'; connectionStringKey = 'EdFi_Admin' }
        security = @{ database = 'Security'; connectionStringKey = 'EdFi_Security' }
        ods      = @{ database = 'Ods'; connectionStringKey = 'EdFi_Ods' }
    }
}

function Get-AvailableFeatures {
    return @(
        @{
            featureName = "extensions";
        },
        @{
            featureName = "changeQueries";
            subTypeName = "Changes"
        },
        @{
            featureName = "ownershipBasedAuthorization";
            subTypeName = "RecordOwnership"
        }
    )
}

function Get-DefaultSubtypes {
    $subtypes = @()
    Get-AvailableFeatures |
        Where-Object { $null -ne $_.subTypeName } |
        ForEach-Object { $subtypes += $_.subTypeName }
    return $subtypes
}

function Get-RepositoryArtifactPaths {
    $filePaths = @()

    $filePaths += (Get-RepositoryResolvedPath("Application/EdFi.Ods.Standard")).Path
    Get-RepositoryNames | ForEach-Object { $filePaths += (Get-RepositoryRoot $_) }

    return $filePaths
}

function Get-ExtensionScriptFiles {
    <#
    .description
    Find all extension database files directories for the given extensions
    .outputs
    An array of resolved paths
    #>

    param(
        [string[]]
        [AllowNull()]
        [AllowEmptyCollection()]
        $artifactSources
    )
    if ($null -eq $artifactSources) { return @() }

    $output = @()
    $artifactSources | ForEach-Object { $output += (Get-RepositoryResolvedPath "Application/EdFi.Ods.Extensions.$_").Path }

    return $output
}

function Get-ExcludedExtensionSourcesFromConfig {
    [CmdletBinding()] param(
        [Parameter(Mandatory = $true)] $configFile
    )
    $jsonFromFile = (Get-Content $configFile -Raw -Encoding UTF8 | ConvertFrom-JSON)
    $jsonExcludedExtensions = $jsonFromFile.ApiSettings.ExcludedExtensions

    if ($jsonExcludedExtensions.Length -eq 0) { return "" }
    return $jsonExcludedExtensions
}

<#
.description
Given a Connection String Builder template and a list of replacement tokens,
return a new copy of the CSB for each token.
.parameter templateCSB
A Connection String Builder that has a database name with a {0} format string
token in it. For example, $templateCSB['Initial Catalog'] might be
"EdFi_{0}".
.parameter replacementTokens
An array of strings that will replace the {0} format string token. For example,
it might be a list of ODS years, like @("Ods_2014","Ods_2015","Ods_2016").
.outputs
Return one CSB, of the same type as was input, for each replacement token.
#>
function Get-DbConnectionStringBuilderFromTemplate {
    [CmdletBinding()] param(
        [Parameter(Mandatory = $true)] [System.Data.Common.DbConnectionStringBuilder] $templateCSB,
        [Parameter(Mandatory = $true)] [Array] $replacementTokens
    )
    foreach ($token in $replacementTokens) {
        $params = @{
            existingCSB = $templateCSB
            property = @{ }
        }
        if ($templateCSB.ContainsKey('Initial Catalog')) { $params.property['Initial Catalog'] = $templateCSB['Initial Catalog'] -f $token }
        if ($templateCSB.ContainsKey('Database')) {
            if ($templateCSB['Database'] -like '*{0}*') {
                $params.property['Database'] = $templateCSB['Database'] -f $token
            } elseif ($token -ne "Ods") {
                $templateCSB['Database'] = "EdFi_$token"
            }
        }

        New-DbConnectionStringBuilder @params
    }
}

Export-ModuleMember -Function `
    Get-DatabaseIds,
    Get-AvailableFeatures,
    Get-DefaultSubtypes,
    Get-RepositoryArtifactPaths,
    Get-ExtensionScriptFiles,
    Get-ExcludedExtensionSourcesFromConfig,
    Get-DbConnectionStringBuilderFromTemplate
