# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/hashtable.psm1')

function Get-TeamCityParameters {

    if (-not (Test-TeamCityVersion)) { return @{ } }

    function Get-Parameters([string] $Path) { return Get-Content $Path -Raw -Encoding UTF8 | ConvertFrom-StringData }

    $result = @{ }

    $result = Merge-Hashtables $result, (Get-Parameters $env:TEAMCITY_BUILD_PROPERTIES_FILE)
    $result = Merge-Hashtables $result, (Get-Parameters $result['teamcity.configuration.properties.file'])
    $result = Merge-Hashtables $result, (Get-Parameters $result['teamcity.runner.properties.file'])

    return $result
}
