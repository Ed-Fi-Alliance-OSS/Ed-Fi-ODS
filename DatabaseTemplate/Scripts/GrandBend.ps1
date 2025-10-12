# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -modules "path-resolver"

Import-Module (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/nuget-helper.psm1')
Import-Module (Get-RepositoryResolvedPath "logistics/scripts/modules/tools/ToolsHelper.psm1")

$configurationFile = (Get-RepositoryResolvedPath 'configuration.packages.json')
$configuration = (Get-Content $configurationFile | ConvertFrom-Json).packages.GrandBend

$parameters = @{
    packageName     = $configuration.packageName
    packageVersion  = $configuration.packageVersion
    packageSource   = $configuration.packageSource
    outputDirectory = "$PSScriptRoot/../Database"
}
$packagePath = Get-NuGetPackage @parameters

return Get-ChildItem "$packagePath/*.bak"
