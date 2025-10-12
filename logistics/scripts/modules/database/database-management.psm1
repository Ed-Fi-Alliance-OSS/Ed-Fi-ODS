# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/database/database-utility.psm1')

function Test-SqlServerModuleInstalled { $null -ne (Get-InstalledModule | where -Property Name -eq SqlServer) }

function Test-SqlServerModuleImported { $null -ne (Get-Module SqlServer) }

function Use-SqlServerModule {
    if (Test-SqlServerModuleImported) { return }

    if (Test-SqlServerModuleInstalled) {
        Import-Module -Force -Scope Global SqlServer
    }
    else {
        # Ensure we have Tls12 support
        if (-not [Net.ServicePointManager]::SecurityProtocol.HasFlag([Net.SecurityProtocolType]::Tls12)) {
            [Net.ServicePointManager]::SecurityProtocol += [Net.SecurityProtocolType]::Tls12
        }

        Write-Host "Installing SqlServer Module"
        Install-Module -Name SqlServer -MinimumVersion "21.1.18068" -Scope CurrentUser -Force -AllowClobber | Out-Null
        Import-Module -Force -Scope Global SqlServer
    }
}

<#
.description
Create a new Connection String Builder object
.parameter existingCSB
Use the passed CSB as the base, but allow it to be overridden.
.parameter property
Hashtable containing named properties for a connection string builder. Will override values on -existingCSB.
.parameter credential
Use these credentials. Will override values on -existingCSB and any values passed as -property.
NOTE: If this parameter is null, or if EITHER the username OR password in the credential is an empty string, use a trusted connection / integrated security instead
.parameter username
Use this username. Will override values on -existingCSB and any values passed as -property
NOTE: If EITHER the username OR password is null or an empty string, use a trusted connection / integrated security instead
.parameter password
Use this password. Can be a string or a SecureString object. Will override values on -existingCSB and any values passed as -property
NOTE: If EITHER the username OR password is null or an empty string, use a trusted connection / integrated security instead
.outputs
Always outputs a System.Data.Common.DbConnectionStringBuilder object, even if the -existingCSB parameter was a specific type of CSB, such as SqlConnectionStringBuilder.
If passed a specific CSB type, all default properties will be stripped out.
#>
function New-DbConnectionStringBuilder {
    [cmdletbinding(DefaultParameterSetName = "NoCredential")] param(
        [System.Data.Common.DbConnectionStringBuilder] $existingCSB,

        [Hashtable] $property,

        # Do not give a type, so that this may be $null or a PSCredential object
        # NOTE that there is no such thing as a null PSCredential object - the closest thing is [PSCredential]::Empty
        [Parameter(Mandatory = $true, ParameterSetName = "Credential")]
        # [System.Management.Automation.PSCredential]
        [AllowNull()] $credential,

        [Parameter(Mandatory = $true, ParameterSetName = "UserPass")]
        [AllowEmptyString()] [string] $username,

        # Do not give a type, so that this might be a string or a SecureString
        [Parameter(Mandatory = $true, ParameterSetName = "UserPass")]
        [AllowNull()] $password
    )

    $newDbCSB = New-Object System.Data.Common.DbConnectionStringBuilder $true

    # Copy all properties, stripping out all default properties (if any).
    # When copying strongly typed specific connection strings like
    # SqlConnectionStringBuilder, all default properties are copied also. By
    # contrast, when copying a generic DbConnectionStringBuilder, there are no
    # defaults to copy, and the resulting object is less cluttered.
    if ($existingCSB.Keys.Count -gt 0) {
        # Strip out default properties by comparing input CSB to an empty one
        $typeName = $existingCSB.GetType().FullName
        $emptySpecificCSB = New-Object $typeName
        $newDbCSB = New-DbConnectionStringBuilder
        foreach ($key in $existingCSB.keys) {
            $value = $existingCSB[$key]
            if($key -eq 'Encrypt')
            {
                $newDbCSB[$key] =$value
            }
            elseif (-not ($emptySpecificCSB[$key] -eq $value)) {
                $newDbCSB[$key] = [String]::Copy($value)
            }
        }
    }

    if ($property.Keys.Count -gt 0) {
        $property.Keys | % { $newDbCSB[$_] = [String]::Copy($property[$_]) }
    }

    if ($PsCmdlet.ParameterSetName -eq "Credential") {
        if ($credential) {
            # Note that we assume this is a PSCredential object, but it could
            # be anything with a string UserName property and a string or
            # SecureString Password property
            $tmpUser = $credential.UserName
            $tmpPass = $credential.Password
        }
        else {
            $tmpUser = $tmpPass = $null
        }
    }
    elseif ($PsCmdlet.ParameterSetName -eq "UserPass") {
        $tmpUser = $username
        $tmpPass = $password
    }

    if ($PsCmdlet.ParameterSetName -notmatch "NoCredential") {
        if ($tmpPass -and $tmpPass.GetType().FullName -eq "System.Security.SecureString") {
            $tmpPass = Decrypt-SecureString $tmpPass
        }

        if ($tmpUser -and $tmpPass) {
            $newDbCSB["Uid"] = $tmpUser
            $newDbCSB["Pwd"] = $tmpPass
            $newDbCSB.Remove("Trusted_Connection") | Out-Null
        } else {
            $newDbCSB["Uid"] = $null
            $newDbCSB["Pwd"] = $null
            $newDbCSB["Trusted_Connection"] = "yes"
        }
    }

    return $newDbCSB
}

<#
.synopsis
Obtain a Connection String Builder object from a connection string in a config
file.
.description
Given a Web/App.config file and the name of a connection string, return a
Connection String Builder object that can represent the connection string.
.parameter configFile
The location of a Web.config or App.config file
.parameter connectionStringName
The name of the desired connection string, as determined by the 'name'
attribute of the <add> XML element which adds the connection string.
#>
function Get-DbConnectionStringBuilderFromConfig {
    [CmdletBinding()] param(
        [Parameter(Mandatory = $true)] $configFile,
        [String[]] $connectionStringName
    )

    $csbs = @{ }

    $jsonFromFile = (Get-Content $configFile -Raw -Encoding UTF8 | ConvertFrom-JSON)
    $connStrEntries=$jsonFromFile.connectionStrings

    $connStrEntries.PSObject.Properties | ForEach-Object {
        $csb = New-Object System.Data.Common.DbConnectionStringBuilder
        # using set_ConnectionString correctly uses the underlying C# setter functionality resulting in a dictionary of connection string properties
        $csb.set_ConnectionString($_.Value)
        $csbs[$_.Name] = $csb
    }

    if ($connectionStringName) {
        $csbs | ? { $connectionStringName -contains $_.Name }
        $csbs.GetEnumerator() | ? { $connectionStringName -contains $_.key }
    }
    else {
        $csbs
    }
}

# NOTE: Changes to this parameter block must be reflected in that of Backup-TransactionLog!
<#
.parameter csb
A valid connection string builder object representing the database
.parameter sqlServer
The name of the SQL server to connect to
.parameter databaseName
The name of the database to back up
.parameter username
The username for a SQL Server account. (If this is empty, use Trusted Authentication.)
.parameter password
The password for a SQL Server account. (If this is empty, use Trusted Authentication.)
.parameter backupActionType
The type of backup to perform
.parameter backupDirectory
A folder that the SQL Server user has access to where the bak file can be saved. If this is null, back up to the default backup folder. The backup file will be named after the database, and backed up to this folder.
NOTE: This must be a path local to the SQL server, not (necessarily) to the machine this function is called on
.parameter overwriteExisting
If passed, run the backup WITH INIT and WITH FORMAT, which will overwrite any existing "backup set" on the "media". In other words, if the backup file already exists, passing this option will overwrite any existing data in that backup file. Without this option, on the other hand, we attempt to append a new backup set, leaving any existing data in the backup file alone.
Useful in a circumstance where a backup has been taken with compression disabled, and then this function (which enables compression) attempts to write a backup to the same location. If this option is not passed, the backup will fail.
.parameter DbServerBackupDirectory
A path accessable to the database server in which to save the backup file
.outputs
Return the file path of the newly created backup file
#>
Function Backup-Database {
    [cmdletbinding(DefaultParameterSetName = "legacy")] param(
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = "csb")]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [Parameter(Position = 0, mandatory = $true, ParameterSetName = "legacy")]
        [string] $sqlServer,

        [Parameter(Position = 1, mandatory = $true, ParameterSetName = "legacy")]
        [string] $databaseName,

        [Parameter(Position = 2, mandatory = $false, ParameterSetName = "legacy")]
        [AllowEmptyString()] [string] $username,

        [Parameter(Position = 3, mandatory = $false, ParameterSetName = "legacy")]
        [AllowNull()] [System.Security.SecureString] $password,

        [Parameter(Position = 4, mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 1, mandatory = $false, ParameterSetName = "csb")]
        [string] $backupDirectory,

        [Parameter(Position = 5, mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 2, mandatory = $false, ParameterSetName = "csb")]
        [switch] $overwriteExisting,

        [Parameter(Position = 6, Mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 3, Mandatory = $false, ParameterSetName = "csb")]
        [Microsoft.SqlServer.Management.Smo.BackupActionType]
        $backupActionType = "Database",

        [Parameter(Position = 7, Mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 4, Mandatory = $false, ParameterSetName = "csb")]
        [string]
        $LocalDbBackupDirectory,

        [Parameter(Position = 8, Mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 5, Mandatory = $false, ParameterSetName = "csb")]
        [string]
        $DbServerBackupDirectory
    )

    try {
        Use-SqlServerModule
    }
    catch {
        Write-Error $("ERROR: " + $_.Exception.ToString());
    }

    if ($PsCmdlet.ParameterSetName -match "legacy") {
        $csb = New-DbConnectionStringBuilder -username $username -password $password -property @{
            Server = $sqlServer
            Database = $databaseName
        }
    }
    
    $databaseName = $csb.Database

    $server = Get-Server -csb $csb
    $local = @("localhost", "127.0.0.1", [Environment]::MachineName)

    if(-not $backupDirectory) { $backupDirectory = $server.Settings.BackupDirectory }

    if($DbServerBackupDirectory) { $backupDirectory = $DbServerBackupDirectory }

    $localBakDirectory = if ($LocalDbBackupDirectory) { $LocalDbBackupDirectory } else { $backupDirectory }

    if (Test-DatabaseExists -csb $csb) {
        if ($backupActionType -eq "log") {
            $dbServerBakFilePath = "$backupDirectory/$databaseName_log.bak"
            $bakFilePath = "$localBakDirectory/$databaseName_log.bak"
        }
        else {
            $dbServerBakFilePath = "$backupDirectory/$databaseName.bak"
            $bakFilePath = "$localBakDirectory/$databaseName.bak"
        }
        $localBakFileDirectory = [System.IO.Path]::GetFullPath("$bakFilePath")

        #Run setup/clean up if the sql server is the machine runing the script, or if it is a remote path.
        if ($local -contains $csb.DataSource -or ($localBakFileDirectory.StartsWith("\\") -and (Test-Path "$([Io.Path]::GetPathRoot($localBakFileDirectory))"))) {
            # Make sure the backup folder exists
            [IO.Directory]::CreateDirectory($localBakFileDirectory) | Out-Null

            # Delete the existing backup file
            if (Test-Path $bakFilePath) {
                ri $bakFilePath
            }
        }
        else {
            Write-Host "The machine executing this script is not the the SQL Server and the backup path is not remote.`r`nLocal backup paths are local to the SQL server. Skipping preliminary backup path validations."
        }

        # Create a backup object
        $smoBackup = New-Object ("Microsoft.SqlServer.Management.Smo.Backup")

        $smoBackup.Action = $backupActionType
        $smoBackup.BackupSetDescription = "Full $backupActionType Backup for $databaseName"
        $smoBackup.BackupSetName = "$databaseName $backupActionType Backup"
        $smoBackup.CompressionOption = "On"
        $smoBackup.Database = $databaseName
        $smoBackup.MediaDescription = "Disk"
        $smoBackup.Devices.AddDevice($dbServerBakFilePath, "File")

        # Wipe any existing backup sets in the file (if the file exists)
        # NOTE: Because $bakFilePath is a path on the SQL Server, not necessarily the machine running this function, we cannot run `Remove-Item $bakFilePath`
        # NOTE: Docs are confusing and sometimes wrong, but FormatMedia *does* apply to disk backups, and for it to take effect it *requires* the Initialize and SkipTapeHeader options.
        # SEE ALSO: https://connect.microsoft.com/SQLServer/feedback/details/683594/backup-sqldatabase-cmdlet-help
        # DEBUGGING NOTE: It's useful to take backups with different options set in SSMS and hit the "Script" button to see what SQL they generate
        if ($overwriteExisting) {
            $smoBackup.Initialize = $true
            $smoBackup.FormatMedia = $true
            $smoBackup.SkipTapeHeader = $true
        }

        $smoBackup.SqlBackup($server)

        return $bakFilePath
    }
    else {
        Write-Host "Cannot backup $backupActionType for '$databaseName' because that database does not exist on server '$($csb.DataSource)'"
    }
}

<#
.description
Get a new SQL connection string.
DEPRECATED. New code should use New-DbConnectionStringBuilder and/or COnvert-CommonDbCSBtoSqlCSB
#>
Function Get-SqlConnectionString {
    [cmdletbinding()] param(
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'legacy')]
        [string] $serverName,

        [Parameter(Position = 1, Mandatory = $true, ParameterSetName = 'legacy')]
        [string] $databaseName,

        [Parameter(Position = 2, Mandatory = $false, ParameterSetName = 'legacy')]
        [Net.NetworkCredential] $creds,

        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'CSB')]
        [System.Data.Common.DbConnectionStringBuilder] $dbCSB
    )
    if ($PsCmdlet.ParameterSetName -eq "legacy") {
        if (($creds -eq $null) -or ($creds.UserName -eq "")) {
            "Server=$serverName;Database=$databaseName;Trusted_Connection=True;"
        }
        else {
            "Server=$serverName;Database=$databaseName;User ID=$($creds.UserName);Password=$($creds.Password);"
        }
    }
    else {
        (New-DbConnectionStringBuilder -existingCSB $dbCSB).ConnectionString
    }
}

Function Get-Server {
    [cmdletbinding(DefaultParameterSetName = 'basic')] param(
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'basic')]
        [string] $sql_server,

        [Parameter(Position = 1, Mandatory = $false, ParameterSetName = 'basic')]
        [AllowEmptyString()] [string] $username = $null,

        [Parameter(Position = 2, Mandatory = $false, ParameterSetName = 'basic')]
        [AllowNull()] [System.Security.SecureString] $password = $null,

        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'csb')]
        [System.Data.Common.DbConnectionStringBuilder] $csb
    )

    Use-SqlServerModule


    if ($PsCmdlet.ParameterSetName -eq "csb") {
        $sql_server = $csb.DataSource
        $username = $csb['user id']
        if([string]::IsNullOrWhitespace($username)) {
            $username = $csb['uid']
        }

        $passwordString = $csb.Password
        if([string]::IsNullOrWhitespace($passwordString)) {
            $passwordString = $csb['Pwd']
        }


        if ($null -ne $passwordString) {
            $secureStringPassword = ConvertTo-SecureString $passwordString -AsPlainText -force
        }
    }


    if ($username) {
        # Initialize Server instance using standard security
        # Write-Host "Connecting to SQL Server using standard security for user '$username'..."

        $s = New-Object ('Microsoft.SqlServer.Management.Smo.Server') $sql_server
        $s.ConnectionContext.LoginSecure = $false
        $s.ConnectionContext.Login = $username
        $s.ConnectionContext.SecurePassword = $secureStringPassword
    }
    else {
        # Initialize Server instance using integrated security
        # Write-Host "Connecting to SQL Server using integrated security..."

        $s = New-Object ('Microsoft.SqlServer.Management.Smo.Server') $sql_server
    }

    # Don't let operations performed on this Server time out
    $s.ConnectionContext.StatementTimeout = 0

    $s
}

Function Initialize-SqlLogin {
    param(
        [string] $serverName,
        [string] $loginName,
        [Security.SecureString] $securePassword,
        [string] $adminUser,
        [Security.SecureString] $adminSecurePassword,
        [Microsoft.SqlServer.Management.Smo.Server] $serverInstance
    )
    if (-not $serverInstance) {
        $serverInstance = Get-Server $serverName $adminUser $adminSecurePassword
    }
    $login = $serverInstance.Logins | where { $_.Name -eq $loginName }
    # Before creating, check if login already exists
    if (-not($login) -and $securePassword) {
        $login = New-Object 'Microsoft.SqlServer.Management.SMO.Login' $serverInstance, $loginName
        #$login.DefaultDatabase = $defaultDatabaseName
        $login.LoginType = [Microsoft.SqlServer.Management.Smo.LoginType]::SqlLogin
        #$login.Enable()
        $login.Create($securePassword)
        Write-Host "Login '$loginName' created."
    }
    return $login
}

Function Invoke-SqlReader {
    [cmdletbinding()] param(
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'object')]
        [ValidateScript( {
                #Must have connection string
                (-not [string]::IsNullOrWhitespace($_.connectionString)) -and
                #Must have timeout
                ($_.timeOut -ne $null) -and
                #Must have a batch
                ($_.scriptBatches.Count -gt 0)
            })]
        [PSCustomObject]$sqlscript,

        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'legacy')]
        [string] $connectionString,

        [Parameter(Position = 1, Mandatory = $true, ParameterSetName = 'legacy')]
        [string]$sql,

        [Parameter(Position = 2, Mandatory = $false, ParameterSetName = 'legacy')]
        [Int32]$commandTimeout
    )
    #This function is here for legacy use. New uses should call Invoke-SqlScript with the -returnDataSet flag.
    if ($PsCmdlet.ParameterSetName -eq "object") {
        $dataSets = Invoke-SqlScript $sqlscript -returnDataSet
    }
    else {
        if ($PSBoundParameters.ContainsKey('commandTimeout')) {
            $dataSets = Invoke-SqlScript $connectionString $sql $commandTimeout -returnDataSet
        }
        else {
            $dataSets = Invoke-SqlScript $connectionString $sql -returnDataSet
        }
    }
    $result = @{ }
    $index = 0
    foreach ($dataSet in $dataSets) {
        foreach ($table in $dataSet.Tables) {
            foreach ($row in $table.Rows) {
                $result.add($index, $row.ItemArray)
                $index++ | Out-Null
            }
        }
    }
    return $result
}

Function Invoke-SqlScript {
    [cmdletbinding()] param(
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'object')]
        [ValidateScript( {
                if ([string]::IsNullOrWhitespace($_.connectionString)) {
                    throw "Connection string not specified"
                    return $false
                }
                elseif ($_.timeOut -eq $null) {
                    throw "Timeout not specified"
                    return $false
                }
                elseif ($_.scriptBatches.Count -le 0) {
                    throw "Script batches not specified"
                    return $false
                }
                else {
                    return $true
                }
            })]
        [PSCustomObject] $sqlscript,
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = 'legacy')]
        [string]$connectionString,
        [Parameter(Position = 1, Mandatory = $true, ParameterSetName = 'legacy')]
        [string]$sql,
        [Parameter(Position = 2, Mandatory = $false, ParameterSetName = 'legacy')]
        [Int32]$commandTimeout,
        [Parameter(Position = 3, Mandatory = $false, ParameterSetName = 'legacy')]
        [Parameter(Position = 1, Mandatory = $false, ParameterSetName = 'object')]
        [switch]$returnDataSet
    )

    Use-SqlServerModule

    if ($PsCmdlet.ParameterSetName -eq "legacy") {
        #We don't have the variables in context here, ignore metadata.
        $newSqlScript = New-SqlScript -scriptSql $sql -ignoreMetadata
        $newsqlScript.connectionString = $connectionString
        #Only override the timeout if it is passed
        if ($PSBoundParameters.ContainsKey('commandTimeout')) {
            $newsqlScript.timeout = $commandTimeout
        }
        #Set default timeout if we haven't been given one.
        if ($newsqlScript.timeOut -eq $null) {
            $newsqlScript.timeOut = 30
        }
        #Callback with object to enforce validation.
        return Invoke-SqlScript $newsqlscript -returnDataSet:$returnDataSet.IsPresent
    }

    #setup connection.
    $conn = New-Object Microsoft.SqlServer.Management.Common.ServerConnection
    $conn.ConnectionString = $sqlscript.connectionString
    $conn.StatementTimeout = $sqlScript.timeOut
    $srv = New-Object Microsoft.SqlServer.Management.Smo.Server($conn)
    try {
        #Initialize Variables
        $resultDataSets = @()
        $variableBlock = $sqlscript.scriptVariables -join [Environment]::NewLine
        foreach ($batch in $sqlScript.scriptBatches) {
            # Skip empty commands
            if ([string]::IsNullOrWhitespace($batch.script)) {
                continue
            }
            $sqlToExecute = $variableBlock + [Environment]::NewLine + $batch.script
            try {

                for ($i = 0; $i -lt $batch.executionCount; $i++) {
                    if ($returnDataSet.IsPresent) {
                        $resultDataSets += $srv.ConnectionContext.ExecuteWithResults($sqlToExecute)
                    }
                    else {
                        $srv.ConnectionContext.ExecuteNonQuery($sqlToExecute) | Out-Null
                    }
                }
            }
            catch {
                Write-Output "Script Stacktrace: " $_.ScriptStackTrace
                Write-Output "Failing script: " $sqlToExecute
                Write-Output "Last successful command:" $previousBatch
                throw $_
            }

            # Make note of last successful command to aid in any troubleshooting
            $previousBatch = $sqlToExecute
        }
    }
    catch {
        Write-Error $("ERROR: " + $_.Exception.ToString());
    }
    finally {
        # Clean up
        $srv.ConnectionContext.Disconnect()
    }
    if ($returnDataSet.IsPresent) {
        return $resultDataSets
    }
    else { return }
}

<#
.synopsis
Disconnect all users from a database
.description
Disconnect all users from a database, in order to put it in a state where it can be dropped (or renamed)
.parameter CSB
A DbConnectionStringBuilder object that points to the database in question and contains correct credentials with permission to kill DB processes
.parameter safe
In addition to killing all user processes, also take the database offline and online again to make doubly sure that the database can be dropped or renamed
.notes
The database must exist or else this function will throw
#>
Function Clear-DatabaseUsers {
    param(
        [Parameter(Mandatory = $true)] [System.Data.Common.DbConnectionStringBuilder] $csb,
        [switch] [Alias("safe")] $forceOffline
    )

    Use-SqlServerModule

    # DEV NOTES:
    # In the past, this was a very simple function that looked (something) like this:
    #
    #     $smo = Get-Server -csb $csb
    #     $dbName = $csb['Database']
    #     $smo.KillAllProcesses($dbName)
    #     $db = $smo.Databases.Item("$dbName")
    #     $db.SetOffline()
    #     $db.SetOnline()
    #
    # However, this doesn't appear to work - it throws no errors, but attempting to drop the database after this fails with an error:
    #
    #     ERROR: Exception calling "KillAllProcesses" with "1" argument(s): "Drop all active database connections failed for Server 'NameOfSqlServer'. "
    #
    # By contrast, this version does two things:
    #
    # 1) It attempts to brute-force kill all user processes using T-SQL
    # 2) If -safe is passed, it subsequently sets the database to offline then online again

    $databaseName = $csb['Database']
    $masterCSB = New-DbConnectionStringBuilder -existingCSB $csb -property @{'Database' = 'master' }
    Write-Host "masterCSB is $masterCSB"  -ForegroundColor Blue
    $masterConnStr = Get-SqlConnectionString -dbCSB $masterCSB

    # Kill all the database processes using T-SQL:
    $killUsersSQL = @(
        "DECLARE @execSql VARCHAR(1000), @databaseName VARCHAR(100)"
        "SET @databaseName = '$databaseName'"
        "SET @execSql = ''"

        "SELECT @execSql = @execSql + 'kill ' + convert(varchar(10), spid) + ' '"
        "FROM master..sysprocesses"
        "WHERE db_name(dbid) = '$databaseName'"
        "AND DBID <> 0 AND spid <> @@spid AND status <> 'background'"

        "EXEC (@execSql)"
        "GO"
    ) -join "`n"
    Write-Host "Killing all processes."
    Invoke-SqlScript -connectionString $masterConnStr -sql $killUsersSQL

    if ($forceOffline) {
        # Take the database offline as a way to *force* all users to disconnect

        $scriptCommand = {
            param(
                [string] $sql_server,
                [string] $database_name,
                [string] $username,
                [string] $plainPass,
                [string] $thisModulePath
            )
            Import-Module $thisModulePath
            $masterCSB = New-DbConnectionStringBuilder -username $username -password $plainPass -property @{
                'Data Source' = $sql_server
                'Database' = 'master'
            }
            $smo = Get-Server -csb $masterCSB
            $db = $smo.Databases.Item("$database_name")
            $db.SetOffline()
            $db.SetOnline()
        }
        $scriptParameters = @{
            sql_server = $csb['Data Source']
            database_name = $csb['Database']
            thisModulePath = Resolve-Path $folders.modules.invoke('database/database-management.psm1')
        }
        if ($username -ne $null) { $scriptParameters.Add("username", $csb['Uid']) }
        if ($password -ne $null) { $scriptParameters.Add("plainPass", $csb['Pwd']) }

        $anotherThread = [Powershell]::Create()
        $anotherThread.AddScript($scriptCommand)
        $anotherThread.AddParameters($scriptParameters)
        $job1 = $anotherThread.BeginInvoke()

        $timeout = 0
        do {
            if ($job1.AsyncState -eq "Failed") {
                throw "Stopping $databaseName failed!"
                break
            }
            Write-Host "Status: $($job1.AsyncState)"
            Start-Sleep 10
            $timeout++
        }
        while ($timeout -lt 600 -and -not ($job1.IsCompleted))

        if ($timeout -ge 599) {
            throw "Failed to stop $databaseName after 10 min. Please check if there are any active connection to the database."
        }
    }
}

Function Remove-Database {
    [cmdletbinding(DefaultParameterSetName = "legacy")] param(
        [Parameter(Position = 0, ParameterSetName = "csb", Mandatory = $true)]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [Parameter(Position = 0, ParameterSetName = "legacy", Mandatory = $true)]
        [Alias("sql_server")] [string] $sqlServer,

        [Parameter(Position = 1, ParameterSetName = "legacy", Mandatory = $true)]
        [Alias("database_name")] [string] $database,

        [Parameter(Position = 2, ParameterSetName = "legacy")]
        [AllowEmptyString()] [string] $username = $null,

        [Parameter(Position = 3, ParameterSetName = "legacy")]
        [AllowNull()] [System.Security.SecureString] $password = $null,

        [Parameter(Position = 2, ParameterSetName = "csb")]
        [Parameter(Position = 4, ParameterSetName = "legacy")]
        [switch] $safe
    )

    Use-SqlServerModule

    if ($PsCmdlet.ParameterSetName -match "legacy") {
        $csb = New-DbConnectionStringBuilder -username $username -password $password -property @{
            Server = $sqlServer
            Database = $database
        }
    }
    $databaseName = $csb['Database']
    $masterCSB = New-DbConnectionStringBuilder -existingCSB $csb -property @{'Database' = 'master' }
    if (-not [string]::IsNullOrWhitespace($MssqlSaPassword)) {
        $masterCSB["Uid"] = 'sa'
        $masterCSB["Pwd"] = $MssqlSaPassword
        $masterCSB["Trusted_Connection"] = "no"
    }

    $masterConnStr = Get-SqlConnectionString -dbCSB $masterCSB

    Write-Host "Starting removal of database $databaseName..."
    if (Test-DatabaseExists -csb $csb) {
        Write-Host "Database '$databaseName' does exist. Clearing users and processes."
        Clear-DatabaseUsers -csb $csb -safe:$safe
        # NOTE: We use DROP DATABASE rather than the SMO's .KillDatabase() function because the former can
        #       drop a database stuck in "Restoring" state, but the latter cannot
        $dropDatabase = @(
            "IF DATABASEPROPERTYEX('$databaseName', 'Status') != 'RESTORING'"
            "BEGIN"
                "ALTER DATABASE [$databaseName] SET SINGLE_USER WITH ROLLBACK IMMEDIATE"
            "END"
            "GO"
            "DROP DATABASE [$databaseName]"
            "GO"
        ) -join "`n"
        Write-Host "Dropping the $databaseName Database."
        Invoke-SqlScript -connectionString $masterConnStr -sql $dropDatabase
    }
    else {
        Write-Host "Database '$databaseName' did not exist and was not removed"
    }
}

Function New-Database {
    <#
    .Synopsis
    Creates a new Sql Server database.

    .Description
    Creates a new database using the specified recovery model

    .Parameter sqlServer
    The Sql Server Server object to use for this operation. Use the Get-Server function to instantiate.

    .Parameter databaseName
    The name of the database to create.

    .Parameter recoveryModel
    The recovery model to use for the new database. Options are 'Simple', 'Full', and 'BulkLogged'. Default is Simple.
#>
    [cmdletbinding()]
    param(
        [parameter(mandatory = $true)]
        [Microsoft.SqlServer.Management.Smo.Server] $sqlServer,
        [parameter(mandatory = $true)]
        [string] $databaseName,
        [parameter(mandatory = $false)]
        [string] $recoveryModel = "Simple"
    )

    Use-SqlServerModule

    # Instantiate the database object and create database
    $db = New-Object ('Microsoft.SqlServer.Management.Smo.Database') ($sqlServer, $databaseName)

    if ($recoveryModel -eq "Full") {
        Write-Host "Creating database '$databaseName' with 'Full' recovery model..."
        $db.RecoveryModel = [Microsoft.SqlServer.Management.Smo.RecoveryModel]::Full
    }
    elseif ($recoveryModel -eq "BulkLogged") {
        Write-Host "Creating database '$databaseName' with 'BulkLogged' recovery model..."
        $db.RecoveryModel = [Microsoft.SqlServer.Management.Smo.RecoveryModel]::BulkLogged
    }
    else {
        #Simple
        Write-Host "Creating database '$databaseName' with 'Simple' recovery model..."
        $db.RecoveryModel = [Microsoft.SqlServer.Management.Smo.RecoveryModel]::Simple
    }
    $db.Create()
    return $db
}

<#
    .Synopsis
    Get a valid log and/or data file location for e.g. database restores.
    .Description
    Query a db server SMO and return a valid log and/or data file location for
    database restores. If the server has set a DefaultFile property, return it.
    If not, use the MasterDBPath property.
#>
function Get-SmoFileLocation {
    [cmdletbinding()] param(
        [Parameter(mandatory = $true)] [Microsoft.SqlServer.Management.Smo.Server] $server,
        [Parameter(mandatory = $true)] [ValidateSet("Data", "Log")] [string] $fileType
    )

    Use-SqlServerModule

    $SmoProps = @{
        Data = @{
            Default = "DefaultFile"
            Master = "MasterDBPath"
        }
        Log = @{
            Default = "DefaultLog"
            Master = "MasterDBLogPath"
        }
    }
    foreach ($ft in $fileType) {
        $default = $server.$($SmoProps.$ft.Default)
        $master = $server.$($SmoProps.$ft.Master)
        if ($default) {
            Write-Verbose "Using Default at '$default' for the $ft files"
            return $default
        }
        else {
            Write-Verbose "Using Master at '$master' for the $ft files"
            return $master
        }
    }
}

# NOTE: Changes to this parameter block must be reflected in that of Restore-TransactionLog!
<#
.parameter csb
A valid connection string builder object representing the database
.parameter sqlServer
The name of the SQL server to connect to
.parameter databaseName
The name of the database to restore
.parameter username
The username for a SQL Server account. (If this is empty, use Trusted Authentication.)
.parameter password
The password for a SQL Server account. (If this is empty, use Trusted Authentication.)
.parameter backupFile
A file that the SQL Server user has access to
NOTE: This must be a path local to the SQL server, not (necessarily) to the machine this function is called on
.parameter usersToReassociate
A hashtable of @{username=password} for SQL Server users to reassociate after the restore
.parameter dataPath
The path to store the data file(s) for the restored database. If null, use default.
.parameter logPath
The path to store the log file(s) for the restored database. If null, use default.
.parameter noRecovery
If passed, the database will be in "Restoring" state.
.parameter restoreActionType
The type of restore to perform
#>
Function Restore-Database {
    [cmdletbinding(DefaultParameterSetName = "legacy")] param(
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = "csb")]
        [System.Data.Common.DbConnectionStringBuilder] $csb,

        [Parameter(Position = 0, mandatory = $true, ParameterSetName = "legacy")]
        [string] $sqlServer,

        [Parameter(Position = 1, mandatory = $true, ParameterSetName = "legacy")]
        [string] $databaseName,

        [Parameter(Position = 2, mandatory = $false, ParameterSetName = "legacy")]
        [AllowEmptyString()] [string] $username,

        [Parameter(Position = 3, mandatory = $false, ParameterSetName = "legacy")]
        [AllowNull()] [System.Security.SecureString] $password,

        [Parameter(Position = 4, mandatory = $true, ParameterSetName = "legacy")]
        [Parameter(Position = 1, mandatory = $true, ParameterSetName = "csb")]
        [string] $backupFile,

        [Parameter(Position = 5, mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 2, mandatory = $false, ParameterSetName = "csb")]
        [Hashtable] $usersToReassociate,

        [Parameter(Position = 6, mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 3, mandatory = $false, ParameterSetName = "csb")]
        [string] $dataPath,

        [Parameter(Position = 7, mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 4, mandatory = $false, ParameterSetName = "csb")]
        [string] $logPath,

        [Parameter(Position = 8, mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 5, mandatory = $false, ParameterSetName = "csb")]
        [switch] $noRecovery,

        [Parameter(Position = 9, mandatory = $false, ParameterSetName = "legacy")]
        [Parameter(Position = 6, mandatory = $false, ParameterSetName = "csb")]
        [Microsoft.SqlServer.Management.Smo.RestoreActionType]
        $restoreActionType = "Database"
    )

    try {
        Use-SqlServerModule
    }
    catch {
        Write-Error $("ERROR: " + $_.Exception.ToString());
    }

    if ($PsCmdlet.ParameterSetName -match "legacy") {
        $csb = New-DbConnectionStringBuilder -username $username -password $password -property @{
            Server = $sqlServer
            Database = $databaseName
        }
    }
    
    $server = Get-Server -csb $csb
    $smoRestore = New-Object("Microsoft.SqlServer.Management.Smo.Restore")

    # Add the bak file as a device
    $backupDevice = New-Object("Microsoft.SqlServer.Management.Smo.BackupDeviceItem") ($backupFile, "File")
    $smoRestore.Devices.Add($backupDevice)

    if (-not $dataPath) { $dataPath = Get-SmoFileLocation -server $server -filetype data }
    if (-not $logPath) { $logPath = Get-SmoFileLocation -server $server -filetype log }

    foreach ($row in $smoRestore.ReadFileList($server).Rows) {
        if ([IO.Path]::GetExtension($row[1]) -eq ".ldf") {
            $designatedPath = $logPath
        }
        else {
            $designatedPath = $dataPath
        }
        $dbFilePath = $row[1]
        $dbFile = New-Object("Microsoft.SqlServer.Management.Smo.RelocateFile")
        $dbFile.LogicalFileName = $row[0]
        $dbFile.PhysicalFileName = [IO.Path]::Combine($dataPath, $csb.Database + [IO.Path]::GetExtension($dbFilePath))
        Write-Host "dbFile.LogicalFileName = $($dbFile.LogicalFileName)"
        Write-Host "dbFile.PhysicalFileName = $($dbFile.PhysicalFileName )"
        $smoRestore.RelocateFiles.Add($dbFile) | Out-Null
    }

    # Set options
    $smoRestore.Database = $csb.Database
    $smoRestore.NoRecovery = $noRecovery
    $smoRestore.ReplaceDatabase = if ($restoreActionType -eq [Microsoft.SqlServer.Management.Smo.RestoreActionType]::Database) { $true } else { $false }
    $smoRestore.Action = $restoreActionType

    $backupSets = $smoRestore.ReadBackupHeader($server)
    $smoRestore.FileNumber = $backupSets.Rows.Count # Most recent backup in the set

    # Write-Host "DEBUG: backup sets in file: $($smoRestore.FileNumber)"

    # Show notifications
    $smoRestore.PercentCompleteNotification = 10

    #$smoRestoreDetails = $smoRestore.ReadBackupHeader($server)
    #"Database Name from Backup Header : " + $smoRestoreDetails.Rows[0][$csb.InitialCatalog]

    # Forcibly close all connections on the target database
    $server.KillAllProcesses($csb.Database)

    #create server users for db users to be re-associated
    if ($usersToReassociate -ne $null) {
        foreach ($user in $usersToReassociate.Keys) {
            Write-Host "Reassociating user: $user"
            Initialize-SqlLogin $null "$user" $usersToReassociate["$user"] -serverInstance $server
        }
    }

    # Restore the database
    $smoRestore.SqlRestore($server)

    $db = $server.Databases[$csb.Database]

    # Reassociate user accounts with logins on server
    # (Useful in scenarios where database is being restored on a different server)
    if ($usersToReassociate -ne $null) {
        foreach ($user in $usersToReassociate.Keys) {
            Write-Host "Reassociating user account '$user' ..."
            $query = "IF EXISTS (SELECT name FROM sys.database_principals WHERE name = `'$user`')"
            $query += "BEGIN `nALTER USER $user with LOGIN=$user `nEND"
            $db.ExecuteNonQuery($query)
        }
    }

    # set the db_owner of the database
    $user = if (-not [string]::IsNullOrWhitespace($csb['user id'])) { 
        $csb['user id'] 
    } elseif (-not [string]::IsNullOrWhitespace($csb['uid'])){
        $csb['uid'] 
    } else { 
        [System.Security.Principal.WindowsIdentity]::GetCurrent().Name 
    }
    Write-Host "Setting db_owner: $user"
    if ([string]::IsNullOrWhitespace($user)) {
        $databaseName = $csb["Database"]
        $query = "USE [$databaseName]; DECLARE @owner_sid  AS VARCHAR(100);
        SELECT @owner_sid=suser_sname(owner_sid) FROM SYS.DATABASES WHERE name = `'$databaseName`';"
        $query += "IF @owner_sid <> `'$user`' BEGIN EXEC sp_changedbowner `'$user`' END"
        $db.ExecuteNonQuery($query)
        Write-Host "sp_changedbowner  query : " $query
    }
    $db.Refresh()
}

Function Test-DatabaseExists {
    [cmdletbinding(DefaultParameterSetName = "legacy")] param(
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = "csb")] [System.Data.Common.DbConnectionStringBuilder] $csb,
        [Parameter(Position = 0, Mandatory = $true, ParameterSetName = "legacy")] [Microsoft.SqlServer.Management.Smo.Server] $server,
        [Parameter(Position = 1, Mandatory = $true, ParameterSetName = "legacy")] [string] $databaseName
    )

    Use-SqlServerModule

    if ($PsCmdlet.ParameterSetName -match "csb") {  
        if (-not [string]::IsNullOrWhitespace($settings.MssqlSaPassword)) {
            $csb["Uid"] = 'sa'
            $csb["Pwd"] = $Settings.MssqlSaPassword
            $csb["Trusted_Connection"] = "no"
        }

        $server = Get-Server -csb $csb
        $databaseName = $csb["Database"]
    }
    $found = $false
    #Makesure we have the latest database information.
    $server.Databases.Refresh($true)
    foreach ($db in $server.Databases) {
        if ($db.Name -eq $databaseName) {
            $found = $true
            break
        }
    }
    Write-Verbose "Database '$databaseName' on '$server' exists is: $found"
    return $found
}

Export-ModuleMember -Function `
    Use-SqlServerModule,
    New-DbConnectionStringBuilder,
    Get-DbConnectionStringBuilderFromConfig,
    Backup-Database,
    Get-SqlConnectionString,
    Get-Server,
    Initialize-SqlLogin,
    Invoke-SqlReader,
    Invoke-SqlScript,
    Clear-DatabaseUsers,
    Remove-Database,
    New-Database,
    Get-SmoFileLocation,
    Restore-Database,
    Test-DatabaseExists
