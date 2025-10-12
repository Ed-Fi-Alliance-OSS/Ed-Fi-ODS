# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/utility/cross-platform.psm1")

$directorySeparatorChar = [IO.Path]::DirectorySeparatorChar
if (Get-IsWindows) {
    # In Windows, double backslashes are needed for the filters to work
    $directorySeparatorChar += $directorySeparatorChar
}

$testAssemblies = (Get-ChildItem -recurse -File $((Get-RepositoryRoot "Ed-Fi-ODS") + "/*Tests.dll") | `
        Where-Object { $_.FullName -match "$($directorySeparatorChar)bin$($directorySeparatorChar)?" `
            -and $_.FullName -notmatch "$($directorySeparatorChar)net48$($directorySeparatorChar)?" `
            -and $_.fullName -notmatch "ApprovalTests.dll" `
            -and $_.fullName -notmatch "$($directorySeparatorChar)ref$($directorySeparatorChar)?" })
$reports = (Get-RepositoryRoot "Ed-Fi-ODS") + "/reports/"

if (Test-Path $reports) {
    Remove-Item -Path $reports -Force -Recurse
}

New-Item -ItemType Directory -Force -Path $reports

$testAssembliesFailedToExecute = @()

foreach ($assembly in $testAssemblies) {
    Write-Host ( "Testing assembly " + $assembly)

    if (Test-TeamCityVersion) {
        $reportName = $reports + (Get-ChildItem $assembly | Select-Object -ExpandProperty Name) + ".xml"
    } else {
        $reportName = $reports + (Get-ChildItem $assembly | Select-Object -ExpandProperty Name) + ".trx"
    }

    # Log both to file and console. With "minimal" set, only failing tests will be listed in detail in the console.
    & dotnet test $assembly --logger ("trx;LogFileName=" + $reportName) --logger "console;verbosity=minimal" --nologo

    if (($LASTEXITCODE -gt 0)) {
        $testAssembliesFailedToExecute += $assembly
    }
    Write-Host "assembly exit code: $LASTEXITCODE"
}

if ($testAssembliesFailedToExecute.count -gt 0) {
    Write-Error "Tests failed to execute."
}
