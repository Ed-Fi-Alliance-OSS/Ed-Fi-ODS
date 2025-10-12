# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

$ErrorActionPreference = "Stop"

Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/cross-platform.psm1')

function Export-BacPac {
        <#
    .SYNOPSIS
        Exports a database using the sqlpackage executable .

    .DESCRIPTION
        Exports the specific database using the sqlpackage executable. The server is defaulted to local host. An exception will be thrown
        if the sqlpackage executable is not found.

    .PARAMETER sqlPackagePath
        An absolute path to the folder to execute sqlpackage executable from: e.g.C:/sqlpackage/

    .PARAMETER database
        Database to export.

    .PARAMETER artifactOutput
        An absolute path to the output file. e.g. c:/tmp/artifacts/edfi_security.bacpac

    .PARAMETER server
        The sql server to connect to. (Defaulted to locahost).

    .EXAMPLE
        PS> Export-BacPac -database edfi_security -sqlPackagePath C:/sqlpackage/ -artifactOutput c:/tmp/artifacts/edfi_security.bacpac
    #>
    [CmdletBinding()]
    param(
        [Parameter(
            Mandatory = $true,
            HelpMessage = "Path to the sqlpackage executable is required.\n\rExample: c:/sqlpackage"
        )]
        [ValidateNotNullOrEmpty()]
        [ValidateScript( { Resolve-Path $_ } )]
        [string] $sqlPackagePath,

        [Parameter(
            Mandatory = $true,
            HelpMessage = "Database for export is required.\n\rExample: EdFi_Admin"
        )]
        [ValidateNotNullOrEmpty()]
        [string] $database,

        [Parameter(
            Mandatory = $true,
            HelpMessage = "Full name of the artifact to export is required.\n\rExample: ./edfi_admin.bacpac"
        )]
        [ValidateNotNullOrEmpty()]
        [string] $artifactOutput,

        [ValidateNotNullOrEmpty()]
        [string] $server = "."
    )
    
    $executable = Join-Path $sqlPackagePath "sqlpackage$(GetExeExtension)"
    
    if (-not (Test-Path $executable)) {
        throw [System.IO.FileNotFoundException] "$executable not found."
    }

    $params = @()
    $params += "/a:export"
    $params += "/sdn:" + $database
    $params += "/tf:" + $artifactOutput
    $params += "/ssn:" + $server
    $params += "/sec:False" # Source Encrypt Connection

    Write-Host -ForegroundColor Magenta $executable $params
    & $executable $params
}

Export-ModuleMember -Function Export-BacPac
