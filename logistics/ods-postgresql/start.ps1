# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

if (-not (Test-Path $PSScriptRoot/.env -PathType leaf)) {
    Write-Host "No .env file was found - using the default credentials posgres/P@ssw0rd" -ForegroundColor Magenta
} 

docker compose -f $PSScriptRoot/docker-compose.yml up -d