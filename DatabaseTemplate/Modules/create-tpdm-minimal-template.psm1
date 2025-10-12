# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.


$ErrorActionPreference = "Stop"

& "$PSScriptRoot/../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "DatabaseTemplate/Modules/create-database-template.psm1")

function Get-TPDMMinimalConfiguration([hashtable] $config = @{ }) {

    $config = Merge-Hashtables (Get-DefaultTemplateConfiguration $config), $config
    $config.appSettings.Plugin.Folder = "../../Plugin"
    $config.appSettings.Plugin.Scripts = @("tpdm")
    $config.appSettings = Merge-Hashtables $config.appSettings, (Get-DefaultTemplateSettingsByEngine)[$config.engine]
    $config.StandardVersion = $config.standardVersion
    $config.ExtensionVersion = $config.extensionVersion

    $config.Remove('apiClientNameSandbox')

    $config.testHarnessJsonConfigLEAs = @()
    $config.testHarnessJsonConfig = "$PSScriptRoot/testHarnessConfiguration.TPDM.json"

    $config.Remove('bulkLoadTempDirectorySample')
    $config.bulkLoadBootstrapInterchanges = @("InterchangeDescriptors")
    $config.bulkLoadMaxRequests = 1

    $config.schemaDirectories = @(
        (Get-RepositoryResolvedPath "Application/EdFi.Ods.Standard/Standard/$($config.standardVersion)/Artifacts/Schemas/")
        ("$(Get-PluginFolderFromSettings $config.appSettings)/Extensions.TPDM*/Artifacts/Schemas/")
    )

    $config.databaseBackupName = "EdFi.Ods.Minimal.Template.TPDM.Core"
    $config.packageNuspecName = "EdFi.Ods.Minimal.Template.TPDM.Core"
    $config.Id = "EdFi.Suite3.Ods.Minimal.Template.TPDM.Core"
    $config.Title = "EdFi.Suite3.Ods.Minimal.Template.TPDM.Core"
    $config.Description = "EdFi Ods Minimal Template TPDM Core"
    $config.Authors = "Ed-Fi Alliance"
    $config.Owners = "Ed-Fi Alliance"
    $config.Copyright = "Copyright @ " + $((Get-Date).year) + " Ed-Fi Alliance, LLC and Contributors"

    return $config
}

function Initialize-TPDMMinimalTemplate {
    <#
    .SYNOPSIS
        Creates a new Minimal Template.

    .DESCRIPTION
        By default this will:
        * Validate all xml files
        * Resets the admin and security database
        * Creates a new database for the minimal template data to be loaded into
        * Restores packages and build the bulk load client
        * Copies sample files to isolate the files into two sections one for each of the two load scenarios
        * Generates two apiclients with key/secret for the two necessary claimsets
        * Starts the test harness api
        * Executes first load scenario using the bootstrap data and claimset
        * Executes second load scenario using the rest of the sample data and the sandbox claimset
        * Stops the test harness api
        * Creates a backup of the new minimal template at: Get-RepositoryRoot "Ed-Fi-ODS"/DatabaseTemplate/Database/Minimal.Template.bak
        * Creates a .nuspec file for the new minimal template at: Get-RepositoryRoot "Ed-Fi-ODS"/DatabaseTemplate/Database/Minimal.Template.nuspec

    .PARAMETER samplePath
        An absolute path to the folder to load samples from, for example: C:/MySampleXmlData/.
        Also supports specific version folders of the Data Standard repository, for example: C:/Ed-Fi-Standard/v3.0/ or C:/Ed-Fi-Standard/v2.0/

    .PARAMETER noExtensions
        Ignores any extension sources when running the sql scripts against the database.

    .PARAMETER noValidation
        Disables xml validation.

    .parameter Engine
    The database engine provider, either 'SQLServer' or 'PostgreSQL'

    .parameter LocalDbBackupDirectory
        A locally accessable path mapped to the backup file directory used by a containerized SQLServer instance

    .parameter DbServerBackupDirectory
        A directory, within the filesystem of a containerized SQLServer instance, to which the database engine should write backup files

    .EXAMPLE
        PS> Initialize-TPDMMinimalTemplate -samplePath "C:/edfi/Ed-Fi-Standard/v3.2/"
    #>
    param(
        [Parameter(
            Mandatory = $false,
            HelpMessage = "An absolute path to the folder to load samples from, for example: C:/MySampleXmlData/.`r`nAlso supports specific version folders of the Data Standard repository, for example: C:/Ed-Fi-Standard/v3.0/ or C:/Ed-Fi-Standard/v2.0/"
        )]
        [ValidateNotNullOrEmpty()]
        [ValidateScript( { Resolve-Path $_ } )]
        [string] $samplePath = "$PSScriptRoot/../../../Ed-Fi-TPDM-Artifacts/",
        [switch] $noValidation,
        [ValidateSet('SQLServer', 'PostgreSQL')]
        [string] $engine = 'SQLServer',
        [string] $createByRestoringBackup,
        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [String] $StandardVersion,
        [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
        })]
        [string]  $ExtensionVersion,
        [String] $LocalDbBackupDirectory,
        [String] $DbServerBackupDirectory
    )

    Clear-Error

    $paramConfig = @{
        samplePath              = $samplePath
        noExtensions            = $noExtensions
        noValidation            = if ($PSBoundParameters.ContainsKey('noValidation')) { $noValidation } else { $true }
        engine                  = $engine
        createByRestoringBackup = $createByRestoringBackup
        standardVersion = $standardVersion
        extensionVersion = $extensionVersion
        LocalDbBackupDirectory = $LocalDbBackupDirectory
        DbServerBackupDirectory = $DbServerBackupDirectory
    }

    $config = (Get-TPDMMinimalConfiguration $paramConfig)
    Write-FlatHashtable $config

    if ([string]::IsNullOrWhiteSpace($config.createByRestoringBackup)) { $config.createByRestoringBackup = (Get-MinimalTemplateBackupPathFromSettings $config.appSettings) }

    $script:result = @()

    $elapsed = Use-StopWatch {
        try {
            $script:result += Invoke-Task 'Invoke-SetTestHarnessConfig' { Invoke-SetTestHarnessConfig $config }
            $script:result += Invoke-Task 'Remove-Plugins' { Remove-Plugins $config.appSettings }
            $script:result += Invoke-Task 'Get-Plugins' { Get-Plugins $config.appSettings }
            $script:result += Invoke-Task 'Invoke-SampleXmlValidation' { Invoke-SampleXmlValidation $config }
            $script:result += Invoke-Task 'New-TempDirectory' { New-TempDirectory $config }
            $script:result += Invoke-Task 'Copy-BootstrapInterchangeFiles' { Copy-BootstrapInterchangeFiles $config }
            $script:result += Invoke-Task 'Copy-SchemaFiles' { Copy-SchemaFiles $config }
            $script:result += Invoke-Task 'Add-RandomKeySecret' { Add-RandomKeySecret $config }
            $script:result += Invoke-Task 'Invoke-BuildLoadTools' { Invoke-BuildLoadTools $config }
            $script:result += Invoke-Task 'New-DatabaseTemplate' { New-DatabaseTemplate $config }
            $script:result += Invoke-Task 'Assert-DisallowedSchemas' { Assert-DisallowedSchemas $config }
            $script:result += Invoke-Task 'Invoke-StartTestHarness' { Invoke-StartTestHarness $config }
            $script:result += Invoke-Task 'Invoke-LoadBootstrapData' { Invoke-LoadBootstrapData $config }
            $script:result += Invoke-Task 'Stop-TestHarness' { Stop-TestHarness $config }
            $script:result += Invoke-Task 'Backup-DatabaseTemplate' { Backup-DatabaseTemplate $config }
            $script:result += Invoke-Task 'New-DatabaseTemplateNuspec' { New-DatabaseTemplateNuspec $config }
        }
        catch {
            Stop-TestHarness
            throw $_
        }
    }

    Test-Error

    $script:result += New-TaskResult -name '-' -duration '-'
    $script:result += New-TaskResult -name $MyInvocation.MyCommand.Name -duration $elapsed.format

    return $script:result | Format-Table
}

Export-ModuleMember -function * -Alias *
