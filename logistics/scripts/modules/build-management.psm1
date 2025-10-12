# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.


$ErrorActionPreference = "Stop"

& "$PSScriptRoot/../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/config/config-management.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/settings/settings-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/database/database-management.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/database/postgres-database-management.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")

function Remove-EdFiSQLServerDatabases {
    <#
    .description
        Removes all databases based on the EdFi_Ods templated connection string
    .parameter Force
        No action will be taken unless this parameter is passed
    #>
    param([switch] $Force)

    $connectionStrings = (Get-ConnectionStringBuildersFromSettings (Get-DefaultConnectionStringsByEngine)['SqlServer'])

    $master = (Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Master]
    $ods = (Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Ods]

    $sqlServer = Get-Server $connectionStrings[$master]
    $connectionString = (Get-DbConnectionStringBuilderFromTemplate -templateCSB $connectionStrings[$ods] -replacementTokens "*")

    $databaseTemplate = $connectionString["Database"]
    $edfiDatabases = $sqlServer.Databases | Where-Object -Property IsSystemObject -EQ $false | Where-Object -Property Name -Like $databaseTemplate

    if ($edfiDatabases.Length -le 0) {
        Write-Host "No EdFi databases were found for removal."
        return
    }

    Write-Host "Found $($edfiDatabases.Length) databases matching '$databaseTemplate':"
    foreach ($databaseName in $edfiDatabases.Name) { Write-Host "  -  $databaseName" }

    if (-not $Force) {
        Write-Host "Please re-run command with the 'Force' parameter to PERMANENTLY REMOVE these databases."
        return
    }

    foreach ($database in $edfiDatabases) {
        $connectionString = New-DbConnectionStringBuilder -existingCSB $connectionString -property @{ 'Database' = $database.Name }
        Remove-Database -csb $connectionString
    }
}

function Remove-EdFiPostgreSQLDatabases {
    <#
    .description
        Removes all databases based on the EdFi_Ods templated connection string
    .parameter Force
        No action will be taken unless this parameter is passed
    #>
    param([switch] $Force)

    $connectionStrings = (Get-ConnectionStringBuildersFromSettings (Get-DefaultConnectionStringsByEngine)['PostgreSQL'])

    $ods = (Get-ConnectionStringKeyByDatabaseTypes)[(Get-DatabaseTypes).Ods]

    $connectionString = (Get-DbConnectionStringBuilderFromTemplate -templateCSB $connectionStrings[$ods] -replacementTokens "*")

    $databaseTemplate = $connectionString["Database"]
    $params = @{
        serverName = $connectionString.host
        portNumber = $connectionString.port
        userName   = $connectionString.username
        database   = 'postgres'
        commands   = @(
            "UPDATE pg_database SET datistemplate='false', datallowconn='true' WHERE datname SIMILAR TO '$databaseTemplate';"
            "SELECT datname FROM pg_database WHERE datname SIMILAR TO '$databaseTemplate';"
        )
    }
    $edfiDatabases = (Invoke-PsqlCommand @params | Where-Object { -not [string]::IsNullOrWhiteSpace($_) } | Sort-Object)

    if ($edfiDatabases.Length -le 0) {
        Write-Host "No EdFi databases were found for removal."
        return
    }

    Write-Host "Found $($edfiDatabases.Length) databases matching '$databaseTemplate':"
    foreach ($databaseName in $edfiDatabases) { Write-Host "  -  $databaseName" }

    if (-not $Force) {
        Write-Host "Please re-run command with the 'Force' parameter to PERMANENTLY REMOVE these databases."
        return
    }

    foreach ($database in $edfiDatabases) {
        $connectionString = New-DbConnectionStringBuilder -existingCSB $connectionString -property @{ 'Database' = $database.Trim() }

        $params = @{
            serverName   = $connectionString.host
            portNumber   = $connectionString.port
            userName     = $connectionString.username
            databaseName = $connectionString.Database
        }
        Remove-PostgreSQLDatabase @params
    }
}

function Remove-EdFiDatabases {
    <#
    .description
        Removes all databases based on the EdFi_Ods templated connection string
    .parameter Engine
        The database engine provider, either "SQLServer" or "PostgreSQL"
    .parameter Force
        No action will be taken unless this parameter is passed
    #>
    param(
        [ValidateSet('SQLServer', 'PostgreSQL')]
        [String] $Engine = 'SQLServer',

        [switch] $Force
    )

    if ($engine -eq 'SQLServer') { Remove-EdFiSQLServerDatabases -Force:$Force }

    if ($engine -eq 'PostgreSQL') { Remove-EdFiPostgreSQLDatabases -Force:$Force }
}

function New-OctopusChannel {
    param(
        [string] $octopusServer,
        [string] $octopusApiKey,
        [string] $octopusProjectId,
        [string] $packageVersion,
        [string] $prereleaseSuffix
    )

    $preReleaseMarkerIndex = $packageVersion.IndexOf("-");
    if ($preReleaseMarkerIndex -ne -1) {
        $packageVersion = $packageVersion.Substring(0, $preReleaseMarkerIndex)
    }

    $splitPackageVersion = $packageVersion.Split(".")
    # We only care about Major/Minor for determining channel, so only look at the first two entries
    if ($splitPackageVersion.Count -lt 2) {
        throw "Invalid Package Version provided $packageVersion.  Package version must include major and minor."
    }

    $majorVersion = $splitPackageVersion[0]
    $minorVersion = $splitPackageVersion[1]

    $channelName = "v$majorVersion.$minorVersion$prereleaseSuffix";

    $headers = @{ "X-Octopus-ApiKey" = $octopusApiKey }

    $odsApiChannelGetUri = "$octopusServer/api/projects/$octopusProjectId/channels/?skip=0&take=100"
    $channelPostUri = "$octopusServer/api/channels/"
    $response = Invoke-RestMethod -Method 'Get' -Uri $odsApiChannelGetUri -Headers $headers -UseBasicParsing
    if ($response.Items.Name -contains $channelName) {
        Write-Host "Channel $channelName already exists."
    }
    else {
        Write-Host "Creating channel $channelName"

        # Build version string allowing any package that has the same major/minor version, including prerelease packages
        # For example, Major = 5, Minor = 2
        # Built version string: [5.2-0,5.3-0)
        # Allowed: 5.2.0, 5.2.33, 5.2.9000, 5.2.8753-b290384
        # Blocked: 5.1.0, 5.1.9999, 5.1.0-b290384, 5.3.0, 5.3.9999, 5.3.0-b290384
        # See https://github.com/NuGet/Home/issues/6434 for recommendation around using "-0" on the version match to manage prerelease
        $versionRangeStartMajorVersion = $majorVersion
        $versionRangeStartMinorVersion = $minorVersion
        $versionRangeEndMajorVersion = $majorVersion
        $versionRangeEndMinorVersion = [int]$minorVersion + 1

        $newChannelObject = @{
            IsDefault = $false
            Rules     = @(
                @{
                    Actions      = @(
                        "Deploy Databases",
                        "Install API NuGet package",
                        "Install Admin NuGet Package",
                        "Install Swagger NuGet package"
                    )
                    VersionRange = "[$versionRangeStartMajorVersion.$versionRangeStartMinorVersion-0,$versionRangeEndMajorVersion.$versionRangeEndMinorVersion-0)"
                }
            )
            Name      = $channelName
            ProjectId = $octopusProjectId
        }

        $newChannelJson = ConvertTo-Json $newChannelObject -Depth 100 -Compress
        $createResponse = Invoke-WebRequest -Method 'Post' -Uri $channelPostUri -Headers $headers -Body $newChannelJson -UseBasicParsing
        if ($createResponse.StatusCode -ne 201) {
            Write-Host $createResponse
            throw "Channel creation $channelName failed"
        }
        Write-Host "Channel creation $channelName succeeded"
    }
    if (Test-TeamCityVersion) { Write-Host "##teamcity[setParameter name='octopus.release.channel' value='$channelName']" }
}

Export-ModuleMember -function * -Alias *
