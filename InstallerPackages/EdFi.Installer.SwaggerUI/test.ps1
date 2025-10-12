# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# This script should not be included in the NuGet package. It can be used
# to run various test scenarios during manual/exploratory testing.
Param(
    $Scenario
)

& "../..//logistics/scripts/modules/load-path-resolver.ps1"

Import-Module -Force -Scope Global "$PSScriptRoot/Install-EdFiOdsSwaggerUI.psm1"

function Invoke-Install {
    $p = @{
        ToolsPath = "../../tools"
        WebApiMetadataUrl = "https://edfi-wrk118/EdFiOdsWebApi/metadata"
        WebApiVersionUrl = "https://edfi-wrk118/EdFiOdsWebApi"
    }

    Install-EdFiOdsSwaggerUI @p
}

function Invoke-SchoolYears {
    $p = @{
        ToolsPath = "../../tools"
        WebApiMetadataUrl = "https://edfi-wrk118/EdFiOdsWebApi/metadata"
        WebApiVersionUrl = "https://edfi-wrk118/EdFiOdsWebApi"
    }

    Install-EdFiOdsSwaggerUI @p
}

function Invoke-Tenants {
    $p = @{
        ToolsPath = "../../tools"
        WebApiMetadataUrl = "https://edfi-wrk118/EdFiOdsWebApi/metadata"
        WebApiVersionUrl = "https://edfi-wrk118/EdFiOdsWebApi"
        Tenants = @("Tenant1","Tenant2")
    }

    Install-EdFiOdsSwaggerUI @p
}

function Invoke-DifferentPackageSource {
    $p = @{
        ToolsPath = "../../tools"
        WebApiMetadataUrl = "https://edfi-wrk118/EdFiOdsWebApi/metadata"
        WebApiVersionUrl = "https://edfi-wrk118/EdFiOdsWebApi"
        PackageSource  = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi/nuget/v3/index.json"
    }

    Install-EdFiOdsSwaggerUI @p
}

function Invoke-KeyAndSecret {
    $p = @{
        ToolsPath = "../../tools"
        WebApiMetadataUrl = "https://edfi-wrk118/EdFiOdsWebApi/metadata"
        WebApiVersionUrl = "https://edfi-wrk118/EdFiOdsWebApi"
        PrePopulatedKey = "key!"
        PrePopulatedSecret = "Secret!"
    }

    Install-EdFiOdsSwaggerUI @p
}

function Invoke-KeyAndSecret {
    $p = @{
        ToolsPath = "../../tools"
        WebApiMetadataUrl = "https://edfi-wrk118/EdFiOdsWebApi/metadata"
        WebApiVersionUrl = "https://edfi-wrk118/EdFiOdsWebApi"
        PrePopulatedKey = "key!"
        PrePopulatedSecret = "Secret!"
    }

    Install-EdFiOdsSwaggerUI @p
}

function Invoke-Uninstall {
    $p = @{
        ToolsPath = "../../tools"
    }

    UnInstall-EdFiOdsSwaggerUI @p
}

try {
    switch ($Scenario) {
        "Install" { Invoke-Install }
        "SchoolYears" { Invoke-SchoolYears }
        "Tenants" { Invoke-Tenants }
        "DifferentPackageSource" { Invoke-DifferentPackageSource }
        "KeyAndSecret" { Invoke-KeyAndSecret }
        "Uninstall" { Invoke-Uninstall }
        default {
            Write-Host "Valid test scenarios are: "
            Write-Host "    Install"
            Write-Host "    SchoolYears"
            Write-Host "    Tenants"
            Write-Host "    DifferentPackageSource"
            Write-Host "    KeyAndSecret"
            Write-Host "    Uninstall"
        }
    }
}
catch {
    $ErrorRecord = $_
    $ErrorRecord | Format-List * -Force
    $ErrorRecord.InvocationInfo | Format-List *
    $Exception = $ErrorRecord.Exception
    for ($i = 0; $Exception; $i++, ($Exception = $Exception.InnerException)) {
        "$i" * 80
        $Exception | Format-List * -Force
    }
}
