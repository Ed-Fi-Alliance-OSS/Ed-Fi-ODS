# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

# This script should not be included in the NuGet package. It can be used
# to run various test scenarios during manual/exploratory testing.
Param(
    [Parameter(Mandatory = $true)]
    [ValidateSet(
        'Install',
        'InstallPostgreSQL',
        'InstallCustomPackage',
        'Uninstall',
        'InstallCustomSettings',
        'UninstallCustomSettings'
    )]
    $Scenario
)

Import-Module -Force -Global "$PSScriptRoot/Install-EdFiOdsSandboxAdmin.psm1"

function Invoke-Install { Install-EdFiOdsSandboxAdmin }

function Invoke-InstallPostgreSQL { Install-EdFiOdsSandboxAdmin -Engine PostgreSQL }

function Invoke-InstallCustomPackage {
    $parameters = @{ PackageSource = "https://pkgs.dev.azure.com/ed-fi-alliance/Ed-Fi-Alliance-OSS/_packaging/EdFi/nuget/v3/index.json" }
    Install-EdFiOdsSandboxAdmin @parameters
}

function Invoke-InstallCustomSettings {
    # this should match the example for the Install-EdFiOdsSandboxAdmin function in Install-EdFiOdsSandboxAdmin.psm1
    $parameters = @{
        PackageVersion     = '6.0.0'
        WebSitePath        = 'c:\inetpub\SandboxAdmin'
        WebSitePort        = 8765
        WebApplicationPath = 'c:\inetpub\SandboxAdmin\6.0.0'
        WebApplicationName = 'SandboxAdmin6.0.0'
        Settings           = @{
            ConnectionStrings            = @{
                EdFi_Ods      = 'Server=(local); Trusted_Connection=True; Database=EdFi_{0}; Application Name=EdFi.Ods.SandboxAdmin'
                EdFi_Admin    = 'Server=(local); Trusted_Connection=True; Database=EdFi_Admin; Application Name=EdFi.Ods.SandboxAdmin'
                EdFi_Security = 'Server=(local); Trusted_Connection=True; Database=EdFi_Security; Persist Security Info=True; Application Name=EdFi.Ods.SandboxAdmin'
                EdFi_Master   = 'Server=(local); Trusted_Connection=True; Database=master; Application Name=EdFi.Ods.SandboxAdmin'
            }
            OAuthUrl                     = 'https://localhost/EdFiOdsWebApi'
            DefaultApplicationName       = 'My Sandbox Administrator'
            DefaultOperationalContextUri = 'uri://sample.edu'
            PreserveLoginUrl             = $false
            User                         = @{
                'Test Admin' = @{
                    Email             = 'test@ed-fi.org'
                    Password          = '***REMOVED***'
                    Admin             = $true
                    NamespacePrefixes = @('uri://ed-fi.org', 'uri://gbisd.edu')
                    Sandboxes         = @{
                        'Populated Demonstration Sandbox' = @{
                            Key     = 'populatedSandbox'
                            Secret  = 'populatedSandboxSecret'
                            Type    = 'Sample'
                            Refresh = $false
                        }
                        'Minimal Demonstration Sandbox'   = @{
                            Key     = 'minimalSandbox'
                            Secret  = 'minimalSandboxSecret'
                            Type    = 'Minimal'
                            Refresh = $false
                        }
                    }
                }
            }
        }
    }

    Install-EdFiOdsSandboxAdmin @parameters
}

function Invoke-Uninstall { UnInstall-EdFiOdsSandboxAdmin }

function Invoke-UninstallCustomSettings {
    $parameters = @{
        WebApplicationPath = "c:\inetpub\SandboxAdmin\6.0.0"
        WebApplicationName = "SandboxAdmin"
    }

    UnInstall-EdFiOdsSandboxAdmin @parameters
}

try {
    & "Invoke-$Scenario"
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
