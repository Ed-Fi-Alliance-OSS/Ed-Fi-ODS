# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

$env:ASPNETCORE_ENVIRONMENT="Development"

Start-Process powershell -WorkingDirectory $PSScriptRoot -ArgumentList {
    &dotnet run --project "EdFi.Ods.WebApi"
}
Start-Process powershell -WorkingDirectory $PSScriptRoot -ArgumentList {
    &dotnet run --project "EdFi.Ods.SwaggerUI"
}
Start-Process powershell -WorkingDirectory $PSScriptRoot -ArgumentList {
    &dotnet run --project "EdFi.Ods.SandboxAdmin"
}

Write-Output "If running on default configurations, the websites can be reached at:"
Write-Output "WebAPI --> http://localhost:54746"
Write-Output "SwaggerUI --> http://localhost:56641"
Write-Output "Sandbox Admin --> http://localhost:38928"