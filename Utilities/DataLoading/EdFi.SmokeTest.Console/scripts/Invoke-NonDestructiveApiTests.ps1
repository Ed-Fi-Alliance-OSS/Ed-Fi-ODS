# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

Param(
    [string]
    [Parameter(Mandatory=$true)]
    $key,

    [string]
    [Parameter(Mandatory=$true)]
    $secret,

    [string]
    $apiUrl = "http://localhost:54746"
)
$ErrorActionPreference = 'Stop'

& dotnet run --project ../EdFi.SmokeTest.Console.csproj -- -k $key -s $secret -b $apiUrl -t NonDestructiveApi | Write-Host
