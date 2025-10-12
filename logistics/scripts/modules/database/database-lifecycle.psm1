# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

$ErrorActionPreference = "Stop"

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/config/config-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/database-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/postgres-database-management.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/tasks/TaskHelper.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/tools/ToolsHelper.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/utility/hashtable.psm1')

function Get-SQLServerDatabaseRemoveStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb
    )

    Write-Host "Executing SQLServerRemoveStrategy..."

    if (-not $Settings.ApiSettings.DropDatabases) { return }

    Remove-Database -csb $csb -safe | Out-Null
}

function Get-SQLServerDatabaseCreateStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [string] $CreateByRestoringBackup
    )

    Write-Host "Executing SQLServerCreateStrategy..."

    if (-not (Test-DatabaseExists -csb $csb) -and $CreateByRestoringBackup) {
        # Copy the backup to a location that the SQL Server has permission to see
        Write-Host "Using backup $createByRestoringBackup"
        $backupDir = if($Settings.DbServerBackupDirectory) { $Settings.DbServerBackupDirectory } elseif ($msSqlBackupPath) { $msSqlBackupPath } else { Get-Server -csb $csb | Select-Object -Expand BackupDirectory }
        $backupCopyDestinationDir = if($Settings.LocalDbBackupDirectory) { $Settings.LocalDbBackupDirectory } else { $backupDir }
        $backupFileName = Split-Path $CreateByRestoringBackup -leaf
        $restorableBackup = Join-Path $backupDir $backupFileName

        Write-Host "Copying to backup directory $backupCopyDestinationDir"

        Copy-Item $CreateByRestoringBackup $backupCopyDestinationDir -PassThru
        Restore-Database -csb $csb -backupFile $restorableBackup
    }
}

function Get-AzureSQLServerDatabaseCreateStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [string] $CreateByRestoringBackup
    )

    Write-Host "Executing AzureSQLServerDatabaseCreateStrategy..."

    $databaseExists = Test-DatabaseExists -csb $csb

    if ($databaseExists) { return }

    if ([string]::IsNullOrWhiteSpace($CreateByRestoringBackup)) {
        $params = @{
            ResourceGroupName = $Settings.Azure.ResourceGroupName
            ServerName = $Settings.Azure.ServerName
            DatabaseName = $csb.InitialCatalog
            RequestedServiceObjectiveName = $Settings.Azure.ServiceObjectiveName
        }
        $database = New-AzSqlDatabase @params
        $database | fl | Out-Host
        return
    }

    $params = @{
        ResourceGroupName          = $Settings.Azure.ResourceGroupName
        ServerName                 = $Settings.Azure.ServerName
        DatabaseName               = $csb.InitialCatalog
        StorageKeyType             = $Settings.Azure.StorageKeyType
        StorageKey                 = $Settings.Azure.StorageKey
        StorageUri                 = $CreateByRestoringBackup
        AdministratorLogin         = $csb.UserID
        AdministratorLoginPassword = (ConvertTo-SecureString $csb.Password -AsPlainText -Force)
        Edition                    = $Settings.Azure.Edition
        ServiceObjectiveName       = $Settings.Azure.ServiceObjectiveName
        DatabaseMaxSizeBytes       = $Settings.Azure.DatabaseMaxSizeBytes
    }
    $importRequest = New-AzSqlDatabaseImport @params
    Write-Host "import request:"
    $importRequest | fl | Out-Host

    $importStatus = Get-AzSqlDatabaseImportExportStatus -OperationStatusLink $importRequest.OperationStatusLink

    Write-Host "Importing $CreateByRestoringBackup"
    $progress = ""
    while ($importStatus.Status -eq "InProgress")
    {
        $importStatus = Get-AzSqlDatabaseImportExportStatus -OperationStatusLink $importRequest.OperationStatusLink
        if ($importStatus.StatusMessage -ne $progress) {
            Write-Host $importStatus.StatusMessage
            $progress = $importStatus.StatusMessage
        }
        Write-Host -NoNewline "."
        Start-Sleep -s 10
    }
    $importStatus | fl | Out-Host
}

function Get-SQLServerDatabaseScriptStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb
    )

    Write-Host "Executing SQLServerDatabaseScriptStrategy..."
    
    if([string]::IsNullOrEmpty($Settings.ApiSettings.StandardVersion))
    {
        $Settings.ApiSettings.StandardVersion ='6.0.0'
    }
    
    $params = @{
        Verb             = "Deploy"
        Engine           = $Settings.ApiSettings.Engine
        Database         = $Database
        ConnectionString = $csb
        FilePaths        = $Settings.ApiSettings.FilePaths
        Features         = $Settings.ApiSettings.SubTypes
        StandardVersion  = $Settings.ApiSettings.StandardVersion
        ExtensionVersion = $Settings.ApiSettings.ExtensionVersion
    }
    if ($Database -eq $Settings.ApiSettings.DatabaseTypes.Ods) { $params.DatabaseTimeoutInSeconds = $Settings.ApiSettings.PopulatedTemplateDBTimeOutInSeconds }
    Invoke-DbDeploy @params
}

function Get-SQLServerDatabaseBackupStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb
    )

    Write-Host "Executing SQLServerBackupStrategy..."

    $databaseNeedsBackup = (
        (-not $Settings.ApiSettings.DropDatabases) -and
        (Test-DatabaseExists -csb $csb) -and
        (Test-DatabaseHasScriptsToApply -Database $Database -ConnectionString $csb -FilePaths $Settings.ApiSettings.FilePaths -Features $Settings.ApiSettings.SubTypes)
    )

    if ($databaseNeedsBackup) {
        $sqlBackupPath = if($Settings.DbServerBackupDirectory) { $Settings.DbServerBackupDirectory } elseif ($Settings.ApiSettings.msSqlBackupPath) { $Settings.ApiSettings.msSqlBackupPath } else { Get-Server -csb $csb | Select-Object -Expand BackupDirectory }
        Write-Host "Backing up database $($csb.InitialCatalog) to $sqlBackupPath..."
        Backup-Database -csb $csb -backupDirectory "$sqlBackupPath/" -DbServerBackupDirectory $Settings.DbServerBackupDirectory -LocalDbBackupDirectory $Settings.LocalDbBackupDirectory -overwriteExisting | Out-Null
    }
    else {
        Write-Host "No backup required for database $($csb.InitialCatalog)"
    }
}

function Get-PostgreSQLDatabaseRemoveStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb
    )

    if (-not $Settings.ApiSettings.DropDatabases) { return }

    Write-Host "Executing PostgreSQLRemoveStrategy..."

    $params = @{
        serverName   = $csb.host
        portNumber   = $csb.port
        userName     = $csb.username
        databaseName = $csb.database
    }
    Remove-PostgresSQLDatabaseAsTemplate @params
    Remove-PostgreSQLDatabase @params
}

function Get-PostgreSQLDatabaseCreateStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [string] $CreateByRestoringBackup
    )

    Write-Host "Executing PostgreSQLCreateStrategy..."

    $params = @{
        serverName   = $csb.host
        portNumber   = $csb.port
        userName     = $csb.username
        databaseName = $csb.database
    }
    $databaseExists = (Test-PostgreSQLDatabaseExists @params)

    if (-not $databaseExists -and $CreateByRestoringBackup) {
        Install-PostgreSQLTemplate @params -backupFile $CreateByRestoringBackup
    }
}

function Get-PostgreSQLDatabaseScriptStrategy {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb
    )

    Write-Host "Executing PostgreSQLDatabaseScriptStrategy..."
    $params = @{
        Verb             = "Deploy"
        Engine           = $Settings.ApiSettings.engine
        Database         = $Database
        ConnectionString = $csb
        FilePaths        = $Settings.ApiSettings.FilePaths
        Features         = $Settings.ApiSettings.SubTypes
        StandardVersion  = $settings.ApiSettings.StandardVersion
        ExtensionVersion = $Settings.ApiSettings.ExtensionVersion
    }
    if ($Database -eq $Settings.ApiSettings.DatabaseTypes.Ods) { $params.DatabaseTimeoutInSeconds = $Settings.ApiSettings.PopulatedTemplateDBTimeOutInSeconds }
    Invoke-DbDeploy @params

    $params = @{
        serverName   = $csb.host
        portNumber   = $csb.port
        userName     = $csb.username
        databaseName = $csb.database
    }
    Set-PostgresSQLDatabaseAsTemplate @params
}

function Get-NoStrategy {}

function New-EdFiDatabaseLifecycle {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [string] $CreateByRestoringBackup,

        [scriptblock]
        $BackupStrategy,

        [scriptblock]
        $RemoveStrategy,

        [scriptblock]
        $CreateStrategy,

        [scriptblock]
        $ScriptStrategy
    )

    $params = @{}

    if ($Settings.ApiSettings.Engine -eq 'SQLServer') {
        Use-SqlServerModule

        if (-not [string]::IsNullOrWhiteSpace($Settings.Azure)) {
            $strategies = @{
                BackupStrategy = ${function:Get-NoStrategy}
                RemoveStrategy = ${function:Get-NoStrategy}
                CreateStrategy = ${function:Get-AzureSQLServerDatabaseCreateStrategy}
                ScriptStrategy = ${function:Get-SQLServerDatabaseScriptStrategy}
            }
            Merge-Hashtables $params, $strategies
        } else {
            $strategies = @{
                BackupStrategy = ${function:Get-SQLServerDatabaseBackupStrategy}
                RemoveStrategy = ${function:Get-SQLServerDatabaseRemoveStrategy}
                CreateStrategy = ${function:Get-SQLServerDatabaseCreateStrategy}
                ScriptStrategy = ${function:Get-SQLServerDatabaseScriptStrategy}
            }
            Merge-Hashtables $params, $strategies
        }
    }

    if ($Settings.ApiSettings.Engine -eq 'PostgreSQL') {
        $strategies = @{
            BackupStrategy = ${function:Get-NoStrategy}
            RemoveStrategy = ${function:Get-PostgreSQLDatabaseRemoveStrategy}
            CreateStrategy = ${function:Get-PostgreSQLDatabaseCreateStrategy}
            ScriptStrategy = ${function:Get-PostgreSQLDatabaseScriptStrategy}

        }
        Merge-Hashtables $params, $strategies
    }

    # Override database engine defaults with any custom strategies
    if ($null -ne $BackupStrategy) { $params.BackupStrategy = $BackupStrategy }
    if ($null -ne $RemoveStrategy) { $params.RemoveStrategy = $RemoveStrategy }
    if ($null -ne $CreateStrategy) { $params.CreateStrategy = $CreateStrategy }
    if ($null -ne $ScriptStrategy) { $params.ScriptStrategy = $ScriptStrategy }

    return $params
}

function Initialize-EdFiDatabase {
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $Settings,

        [Parameter(Mandatory = $true)]
        [string]
        $Database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $CSB,

        [string] $CreateByRestoringBackup,

        [scriptblock]
        $BackupStrategy,

        [scriptblock]
        $RemoveStrategy,

        [scriptblock]
        $CreateStrategy,

        [scriptblock]
        $ScriptStrategy
    )

    if (($Settings.ApiSettings.Engine -eq 'SQLServer') -and ([string]::IsNullOrEmpty($CSB['Encrypt']))) {
        $CSB['Encrypt'] = $false
    }

    if (($Settings.ApiSettings.Engine -eq 'SQLServer') -and (-not [string]::IsNullOrEmpty($Settings.MssqlSaPassword))) {
        $CSB['Uid'] = 'sa'
        $CSB['Pwd'] = $Settings.MssqlSaPassword
        $CSB['trusted_connection'] = 'False'
    }

    Write-InvocationInfo $MyInvocation

    $lifecycle = New-EdFiDatabaseLifecycle @PSBoundParameters

    & $lifecycle.BackupStrategy $Settings $Database $CSB
    & $lifecycle.RemoveStrategy $Settings $Database $CSB
    & $lifecycle.CreateStrategy $Settings $Database $CSB $CreateByRestoringBackup
    & $lifecycle.ScriptStrategy $Settings $Database $CSB
}

<#
.description
Runs the dotnet tool "EdFi.Db.Deploy" with WhatIf verb to determine whether there are migration scripts on the filesystem that haven't been applied to an Ed-Fi database

.parameter Engine
The database engine provider, either "SQLServer" or "PostgreSQL"

.parameter Database
The database type to be deployed.

.parameter ConnectionString
The full connection string to the database server.

.parameter FilePaths
An array of paths to database script diretories. It may contain paths to extension script directories.

.parameter Features
An optional array of features (aka "sub types") to deploy.

.example
Test with the ODS database, with GrandBend and Sample extensions and with
Change Queries enabled, to the "EdFi_Ods" database on a local SQL
Server instance:

$splat = @{
    Engine = "SQLServer";
    Database = "EdFi";
    ConnectionString = "server=localhost;database=EdFi_Ods;integrated security=sspi";
    FilePaths = @(
            "C:/Source/3.x/Ed-Fi-ODS",
            "C:/Source/3.x/Ed-Fi-ODS/Application/EdFi.Ods.Extensions.GrandBend",
            "C:/Source/3.x/Ed-Fi-ODS/Application/EdFi.Ods.Extensions.Sample"
    );
    Features = @(
        "Changes"
    )
}
Test-DatabaseHasScriptsToApply @splat
#>
function Test-DatabaseHasScriptsToApply {

    param(
        [ValidateSet('SQLServer', 'PostgreSQL')]
        [String] $Engine = 'SQLServer',

        # EdFi, EdFi_Admin, and EdFiSecurity are the "database id" values in the
        # initdev process. The real values of ODS, Admin, and Security are
        # provided as a convenience for those who directly invoke this command.
        [ValidateSet('EdFi', 'EdFi_Admin', 'EdFiSecurity', 'Ods', 'Admin', 'Security')]
        [String] $Database = 'EdFi',

        [Parameter(Mandatory = $true)] [String] $ConnectionString,

        [Parameter(Mandatory = $true)]
        [String[]]
        $FilePaths,

        [String[]]
        [AllowNull()]
        [AllowEmptyCollection()]
        $Features = @(),

        [Int]
        $DatabaseTimeoutInSeconds
    )

    $params = @{
        Verb                     = "WhatIf"
        Engine                   = $Engine
        Database                 = $Database
        ConnectionString         = $ConnectionString
        FilePaths                = $FilePaths
        Features                 = $Features
        DatabaseTimeoutInSeconds = $DatabaseTimeoutInSeconds
        StandardVersion          = $Settings.ApiSettings.StandardVersion
        ExtensionVersion         = $Settings.ApiSettings.ExtensionVersion
    }

    $exitCode = Invoke-DbDeploy @params

    return $exitCode -eq 1
}

<#
.synopsis
Initialize a database and apply migrations

.parameter csb
A Connection String Builder object for the database to build

.parameter database
The database type to use when loading

.parameter filePaths
Array of paths to sql scripts and extension directories

.parameter subTypeNames
Scripts with these SubType names should be included. These should be
"normalized" aka contain no spaces.

.parameter dropDatabase
The database is "transient" - that is, it's dropped if it already exists, and
it isn't backed up. By default, all databases are considered "persistent". That
is, not dropped if they already exists, but migrated instead, and backed up
before migrations are applied.

.parameter createByRestoringBackup
Instead of creating the database from scratch, use this backup file. After the
backup is restored, the database will be synced normally. Note: The backup file
must have a dbo.DeployJournal like the module expects.

.parameter msSqlBackupPath
When using a traditional SQLServer host, a location to store backups of databases before they are dropped or migrated.
If this is not provided, the default backup path on the SQL server is used.

.parameter LocalDbBackupDirectory
A locally accessable path mapped to the backup file directory used by a containerized SQLServer instance

.parameter DbServerBackupDirectory
A directory, within the filesystem of a containerized SQLServer instance, to which the database engine should write backup files

#>
function Initialize-EdFiDatabaseWithDbDeploy {
    [CmdletBinding()]
    param(
        [ValidateSet('SQLServer', 'PostgreSQL')]
        [String] $engine = 'SQLServer',

        [Parameter(Mandatory = $true)]
        [string] $database,

        [Parameter(Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [Parameter(Mandatory = $true)]
        [string[]] $filePaths,

        [string[]] $subTypeNames,

        [Alias('transient')]
        [switch] $dropDatabase,

        [string] $createByRestoringBackup,

        [string] $msSqlBackupPath,

        [Int] $databaseTimeoutInSeconds = 60,
        
        [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
        [String] $standardVersion,

        [ValidateScript({
                if ($_ -match '^(?!0\.0\.0)\d+\.\d+\.\d+?$') {
                    $true
                } else {
                    throw "Value '{0}' is an invalid version. Supply a valid version in the format 'X.Y.Z' where X, Y, and Z are non-zero digits."
                }
        })]
        [string]  $extensionVersion,
        [string]  $LocalDbBackupDirectory,
        [string]  $DbServerBackupDirectory
    )

    Write-InvocationInfo $MyInvocation

    if ($engine -eq 'PostgreSQL') {
        $scriptParams = @{
            serverName   = $csb.host
            portNumber   = $csb.port
            userName     = $csb.username
            databaseName = $csb.database
        }

        Remove-PostgresSQLDatabaseAsTemplate @scriptParams

        if ($dropDatabase) {
            Remove-PostgreSQLDatabase @scriptParams
        }

        $databaseExists = (Test-PostgreSQLDatabaseExists @scriptParams)

        if (-not ($databaseExists) -and $createByRestoringBackup) {
            $params = @{
                serverName   = $csb.host
                portNumber   = $csb.port
                userName     = $csb.username
                databaseName = $csb.database
                backupFile   = $createByRestoringBackup
            }
            Install-PostgreSQLTemplate @params
        }

        $params = @{
            Verb                     = "Deploy"
            Engine                   = $Engine
            Database                 = $database
            ConnectionString         = $csb
            FilePaths                = $filePaths
            Features                 = $subTypeNames
            DatabaseTimeoutInSeconds = $databaseTimeoutInSeconds
            StandardVersion          = $standardVersion
            ExtensionVersion         = $extensionVersion
          }
        Invoke-DbDeploy @params
        
        Set-PostgresSQLDatabaseAsTemplate @scriptParams
        return;
    }

     if (($engine -eq 'SQLServer') -and (-not [string]::IsNullOrEmpty($MssqlSaPassword))) {
        $csb['Uid'] = 'sa'
        $csb['Pwd'] = $MssqlSaPassword
        $csb['trusted_connection'] = 'False'
    }

    $databaseNeedsBackup = (
        (-not $dropDatabase) -and
        (Test-DatabaseExists -csb $csb) -and
        (Test-DatabaseHasScriptsToApply -Database $database -ConnectionString $csb -FilePaths $filePaths -Features $subTypeNames -DatabaseTimeoutInSeconds $databaseTimeoutInSeconds)
    )

    if ($databaseNeedsBackup) {
        $msSqlBackupPath = if ($msSqlBackupPath) { $msSqlBackupPath } else { Get-Server -csb $csb | Select-Object -Expand BackupDirectory }
        Write-Host "Backing up database $($csb.InitialCatalog) to $msSqlBackupPath..."
        Backup-Database -csb $csb -backupDirectory "$msSqlBackupPath/" -overwriteExisting | Out-Null
    }
    else {
        Write-Host "No backup required for database $($csb.InitialCatalog)"
    }

    if ($dropDatabase) {
        Remove-Database -csb $csb -safe | Out-Null
    }

    if (-not (Test-DatabaseExists -csb $csb)) {
        if ($createByRestoringBackup) {
            # Copy the backup to a location that the SQL Server has permission to see
            Write-Host "Using backup $createByRestoringBackup"
            $backupDir = if($DbServerBackupDirectory) { $DbServerBackupDirectory } elseif ($msSqlBackupPath) { $msSqlBackupPath } else { Get-Server -csb $csb | Select-Object -Expand BackupDirectory }
            $backupCopyDestinationDir = if($LocalDbBackupDirectory) { $LocalDbBackupDirectory } else { $backupDir }
            
            $backupFileName = Split-Path $CreateByRestoringBackup -leaf
    
            $restorableBackup = "$backupDir/$backupFileName"
    
            Write-Host "Copying to backup directory $backupCopyDestinationDir"
    
            Copy-Item $CreateByRestoringBackup $backupCopyDestinationDir -PassThru
            Restore-Database -csb $csb -backupFile $restorableBackup
        }
    }

    $params = @{
        Verb                     = "Deploy"
        Engine                   = $Engine
        Database                 = $database
        ConnectionString         = $csb
        FilePaths                = $filePaths
        Features                 = $subTypeNames
        DatabaseTimeoutInSeconds = $databaseTimeoutInSeconds
        StandardVersion          = $standardVersion
        ExtensionVersion         = $extensionVersion
    }
    Invoke-DbDeploy @params
}

<#
.description
Remove all sandbox ODS databases

.parameter masterCSB
A CSB with sysadmin credentials on the database server

.parameter edfiOdsTemplateDbName
A database name with a placeholder {0} token in it. The function replaces the
token with the string "Sandbox_", and assumes that any database that
with the resulting string is a sandbox

.example
Remove-EdFiSandboxDatabases -masterCSB $masterCSB -edfiOdsTemplateDbName "EdFi_Ods_{0}"
In this example, the function looks for databases that begin with the string
"EdFi_Ods_Sandbox_" and deletes them.
#>
function Remove-EdFiSandboxDatabases {
    [CmdletBinding()] param(
        [Parameter(Mandatory = $true)] [System.Data.Common.DbConnectionStringBuilder] $masterCSB,
        [Parameter(Mandatory = $true)] [System.Data.Common.DbConnectionStringBuilder] $edfiOdsTemplateCSB,
        [Parameter(Mandatory = $true)] [String] $Engine
    )

    if ($Engine -eq 'SQLServer') {
        Remove-SqlServerSandboxDatabase $masterCSB $edfiOdsTemplateCSB
    }
    else {
        $params = @{
            serverName       = $masterCSB["host"]
            portNumber       = $masterCSB["port"]
            userName         = $masterCSB["username"]
            databaseTemplate = $edfiOdsTemplateCSB["database"]
        }

        Remove-EdFiPostgresSandboxDatabases @params
    }
}

function Remove-SqlServerSandboxDatabase {
    param(
        [System.Data.Common.DbConnectionStringBuilder] $masterCSB,
        [System.Data.Common.DbConnectionStringBuilder] $edfiOdsTemplateCSB
    )

    # If we don't throw here, the .StartsWith() command below will match all databases, including system databases
    $templateDatabase = $edfiOdsTemplateCSB['Database']
    if (-not $templateDatabase) {
        throw "The template CSB does not define a database"
    }

    $templateBaseName = $templateDatabase -f "Ods_Sandbox_"

    if ($templateDatabase -like '*{0}*') {
        $smo = Get-Server -csb $masterCSB
        foreach ($db in $smo.Databases) {
            if ($db.Name.StartsWith("$templateBaseName")) {
                Write-Verbose "Removing sandbox database: $($db.Name)"
                $sandboxCSB = New-DbConnectionStringBuilder -existingCSB $masterCSB -property @{Database = $db.Name }
                Remove-Database -csb $sandboxCSB
            }
        }
    }
}

Export-ModuleMember -Function *
