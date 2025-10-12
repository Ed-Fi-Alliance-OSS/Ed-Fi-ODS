# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# This script should not be included in the NuGet package. It can be used
# to run various test scenarios during manual/exploratory testing.
Param(
    $Scenario
)

import-module -force "$PSScriptRoot/Install-EdFiOdsWebApi.psm1"

function Invoke-DifferentWebSite {
    $p = @{
        ToolsPath = "../../tools"
        DbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        WebSiteName = "DifferentWebSite"
        WebSitePath = "c:\inetpub\DifferentWebSite"
        WebSitePort = 444
        WebApplicationPath = "c:\inetpub\DifferentWebSite\DifferentAppPath"
        WebApplicationName = "SomethingElse"
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-NonDefaultApplication {
    $p = @{
        ToolsPath = "../../tools"
        DbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        PackageName = "EdFi.Ods.WebApi.SF"
        PackageVersion = "3.4.0-b10567"
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-DifferentPackageSource {
    $p = @{
        ToolsPath = "../../tools"
        DbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        PackageSource  = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi/nuget/v3/index.json"
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-DifferentStandardVersion {
    $p = @{
        ToolsPath = "../../tools"
        DbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        PackageName = "EdFi.Suite3.Ods.WebApi.Standard.4.0.0"
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-SeparateConnectionInfo {
    $p = @{
        ToolsPath = "../../tools"
        AdminDbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        SecurityDbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-CommonConnectionInfo {
    $p = @{
        ToolsPath = "../../tools"
        DbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-MultiTenantCommonConnectionInfo {
    $p = @{
        IsMultiTenant = $true
        ToolsPath = "../../tools"
        DbConnectionInfo = @{
            Engine = "SqlServer"
            Server = "localhost"
            UseIntegratedSecurity = $true
        }
        Tenants = @{
            Tenant1 = @{
                AdminDatabaseName = "EdFi_Admin_Tenant1"
                SecurityDatabaseName = "EdFi_Security_Tenant1"
            }
            Tenant2 = @{
                AdminDatabaseName = "EdFi_Admin_Tenant2"
                SecurityDatabaseName = "EdFi_Security_Tenant2"
            }
        }
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-MultiTenantSeparateConnectionInfo {
    $p = @{
        IsMultiTenant = $true
        ToolsPath = "../../tools"
        Tenants = @{
            Tenant1 = @{
                AdminDbConnectionInfo = @{
                    Engine = "SqlServer"
                    Server = "localhost"
                    DatabaseName = "EdFi_Admin_Tenant1"
                    UseIntegratedSecurity = $true
                }
                SecurityDbConnectionInfo = @{
                    Engine = "SqlServer"
                    Server = "localhost"
                    DatabaseName = "EdFi_Security_Tenant1"
                    UseIntegratedSecurity = $true
                }
            }
            Tenant2 = @{
                AdminDbConnectionInfo = @{
                    Engine = "SqlServer"
                    Server = "localhost"
                    DatabaseName = "EdFi_Admin_Tenant2"
                    UseIntegratedSecurity = $true
                }
                SecurityDbConnectionInfo = @{
                    Engine = "SqlServer"
                    Server = "localhost"
                    DatabaseName = "EdFi_Security_Tenant2"
                    UseIntegratedSecurity = $true
                }
            }
        }
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-FeatureOverride {
    $p = @{
        ToolsPath = "../../tools"
        AdminDbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        SecurityDbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        WebApiFeatures = @{
            BearerTokenTimeoutMinutes="BearerTokenTimeoutMinutes"
            ExcludedExtensionSources="GrandBend"
            FeatureIsEnabled=@{
                changeQueries = $true
                openApiMetadata = $false
                composites = $false
                profiles = $false
                identityManagement = $false
                extensions = $false
                ownershipBasedAuthorization = $true
                uniqueIdValidation = $true
            }
        }
    }
    Install-EdFiOdsWebApi @p
}

function Invoke-Uninstall {
    $p = @{
        ToolsPath = "../../tools"
        WebApplicationPath = "c:\inetpub\Ed-Fi\WebApi"
        WebApplicationName = "WebApi"
        WebSiteName = "Ed-Fi"        
    }
    Uninstall-EdFiOdsWebApi @p
}

function Invoke-UninstallDifferentWebSite {
    $p = @{
        WebApplicationName = "SomethingElse"
        WebSiteName = "DifferentWebSite"
        WebApplicationPath = "c:\inetpub\DifferentWebSite\DifferentAppPath"
    }
    Uninstall-EdFiOdsWebApi @p
}

function Invoke-Sandbox {
    $p = @{
        ToolsPath = "../../tools"
        DbConnectionInfo = @{
            Engine="SqlServer"
            Server="localhost"
            UseIntegratedSecurity=$true
        }
        IsSandbox = $true
    }
    Install-EdFiOdsWebApi @p
}

try {
    switch ($Scenario) {
        "DifferentPackageSource" { Invoke-DifferentPackageSource }
        "DifferentStandardVersion" { Invoke-DifferentStandardVersion }
        "SeparateConnectionInfo" { Invoke-SeparateConnectionInfo } 
        "CommonConnectionInfo" { Invoke-CommonConnectionInfo }
        "FeatureOverride" { Invoke-FeatureOverride }
        "DifferentWebSite" { Invoke-DifferentWebSite }
        "NonDefaultApplication" { Invoke-NonDefaultApplication }
        "MultiTenantCommonConnectionInfo" { Invoke-MultiTenantCommonConnectionInfo }
        "MultiTenantSeparateConnectionInfo" { Invoke-MultiTenantSeparateConnectionInfo }
        "Sandbox" { Invoke-Sandbox }
        "Uninstall" { Invoke-Uninstall }
        "UninstallDifferentWebSite" { Invoke-UninstallDifferentWebSite }
        default { 
            Write-Host "Valid test scenarios are: "
            Write-Host "    DifferentPackageSource"
            Write-Host "    DifferentStandardVersion"
            Write-Host "    SeparateConnectionInfo"
            Write-Host "    CommonConnectionInfo"
            Write-Host "    FeatureOverride"
            Write-Host "    DifferentWebSite"
            Write-Host "    NonDefaultApplication"
            Write-Host "    MultiTenantCommonConnectionInfo"
            Write-Host "    MultiTenantSeparateConnectionInfo"
            Write-Host "    Sandbox"
            Write-Host "    Uninstall"
            Write-Host "    UninstallDifferentWebSite"
        }
    }
}
catch {
    $ErrorRecord= $_
    $ErrorRecord | Format-List * -Force
    $ErrorRecord.InvocationInfo |Format-List *
    $Exception = $ErrorRecord.Exception
    for ($i = 0; $Exception; $i++, ($Exception = $Exception.InnerException))
    {
        "$i" * 80
        $Exception |Format-List * -Force
    }
}