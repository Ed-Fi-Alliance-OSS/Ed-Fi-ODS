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
    $apiUrl = "http://localhost:54746/data/v3",

    [string]
    $tokenUrl = "http://localhost:54746",

    [string]
    $metadataUrl = "http://localhost:54746/metadata"
)
$ErrorActionPreference = 'Stop'

$exe = ".\bin\debug\EdFi.SmokeTest.Console.exe"

if (-not(Test-Path($exe)))
{
    Throw "Build the solution in debug mode first"
}

&$exe -k $key -s $secret -a $apiUrl -o $tokenUrl -m $metadataUrl -t NonDestructiveApi | Write-Host
