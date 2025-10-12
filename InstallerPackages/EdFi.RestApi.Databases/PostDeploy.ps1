# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# Octopus lifecycle script called automatically after deploying the EdFi.RestApi.Databases NuGet package created by ./prep-package.ps1
# see: https://octopus.com/docs/deployment-examples/custom-scripts/scripts-in-packages
param(
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $PathResolverRepositoryOverride,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $InstallType,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $OdsYears,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $OdsTokens,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $Transient,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $ExcludedExtensionSources,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $EnabledFeatureNames,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [string] $UsePlugins,
    [Obsolete("This parameter is deprecated, and will be removed in the near future. Please use the configuration.json instead.")]
    [switch] $WhatIf
)

# maintains previous functionality where passed parameters override octopus parameters but without requiring those octopus parameters
function Add-Parameter([hashtable] $hashtable, [string] $name, $value) {
    if ($null -ne $OctopusParameters -and -not [string]::IsNullOrWhiteSpace($OctopusParameters[$name])) {
        Write-Warning "The Octopus parameter '$name' is deprecated, and will be removed in the near future. Please use the configuration.json instead."
        $hashtable[$name] = $OctopusParameters[$name]
    }
    if (-not [string]::IsNullOrWhiteSpace($value)) { $hashtable[$name] = $value }
    return $hashtable
}

$deploymentParams = @{ }

Add-Parameter $deploymentParams 'PathResolverRepositoryOverride' $PathResolverRepositoryOverride
Add-Parameter $deploymentParams 'InstallType' $InstallType

# Fall back to OdsYears Octopus parameter if no tokens provided, for backwards compatibility
Add-Parameter $deploymentParams 'OdsTokens' $OdsTokens
if ([string]::IsNullOrWhiteSpace($deploymentParams.OdsTokens) -and -not [string]::IsNullOrWhiteSpace($deploymentParams.OdsYears)) {
    $deploymentParams.OdsTokens = $OdsYears
}

if ([Boolean]::TryParse((Add-Parameter $deploymentParams 'Transient' $Transient).Transient, [ref]$Transient)) { $deploymentParams.Transient = $Transient }
Add-Parameter $deploymentParams 'ExcludedExtensionSources' $ExcludedExtensionSources
Add-Parameter $deploymentParams 'EnabledFeatureNames' $EnabledFeatureNames
if ([Boolean]::TryParse((Add-Parameter $deploymentParams 'UsePlugins' $UsePlugins).UsePlugins, [ref]$UsePlugins)) { $deploymentParams.UsePlugins = $UsePlugins }

Import-Module -Force -Scope Global "$PSScriptRoot/Deployment.psm1"
Initialize-DeploymentEnvironment @deploymentParams
