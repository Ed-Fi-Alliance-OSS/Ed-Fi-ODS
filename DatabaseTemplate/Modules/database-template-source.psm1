# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -modules "path-resolver"

$databaseTemplateFolder = Resolve-Path "$PSScriptRoot/../"
$databaseTemplateScriptFolder = "$databaseTemplateFolder/Scripts"
$databaseTemplateModulesFolder = "$databaseTemplateFolder/Modules"
$databaseTemplateDatabaseFolder = "$databaseTemplateFolder/Database"
$databasePopulatedTemplateScriptConfigKey = "PopulatedTemplateScript"
$databaseMinimalTemplateScriptConfigKey = "MinimalTemplateScript"

# required for get-populated-from-nuget.ps1 and for get-template-from-web.ps1
$global:templateDatabaseFolder = $databaseTemplateDatabaseFolder
$global:templateFolder = $databaseTemplateFolder

function Get-TemplateScriptNameFromConfig {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$configFileName,
        [parameter(Mandatory)]
        [string]$configKey
    )
    $scriptName = ""
    $jsonFromFile = (Get-Content $configFileName -Raw -Encoding UTF8 | ConvertFrom-JSON)
    $databasetemplate=$jsonFromFile.databaseTemplate

    foreach($object_properties in $databasetemplate.PsObject.Properties)
    {
        if($object_properties.Name -eq $configKey)
        {
            $scriptName = $object_properties.Value
            break
        }
    }

    if ([string]::IsNullOrWhiteSpace($scriptName)) { return "" }
    return $scriptName
}

function Get-TemplateScripts {
    $result = @()

    $result += Get-ChildItem $databaseTemplateScriptFolder -File
    $result += Get-ChildItem $databaseTemplateModulesFolder -File

    return ($result | Where-Object { $_.extension -in ".ps1", ".psm1" })
}

function Get-TemplateScriptPath {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$scriptName
    )
    $scriptPath = Get-ChildItem $databaseTemplateScriptFolder -File -Filter "$scriptName.ps1"
    return $scriptPath | Select-Object -First 1 -ExpandProperty FullName
}

# specific for the testing database
function Get-EdFiDefaultPopulatedTemplateBackupPath {
    return Initialize-TemplateSourceFromScriptName -scriptName "Grandbend"
}

function Get-EdFiDefaultMinimalTemplateBackupPath {
    return Initialize-TemplateSourceFromScriptName -scriptName "EdFiMinimalTemplate"
}

function Get-PopulatedTemplateBackupPath {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$configFileName
    )
    return Get-TemplateSourceFromConfig -configFileName $configFileName -configKey $databasePopulatedTemplateScriptConfigKey
}

function Get-MinimalTemplateBackupPath {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$configFileName
    )
    return Get-TemplateSourceFromConfig -configFileName $configFileName -configKey $databaseMinimalTemplateScriptConfigKey
}

function Invoke-TemplateScript {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$scriptPath
    )
    if (-not (Test-Path $scriptPath)) { return }
    & $scriptPath
}

function Get-TemplateBackupPath {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline)]
        [string]$backupFolder = $databaseTemplateDatabaseFolder,
        [parameter(ValueFromPipeline)]
        [string]$engine
    )
    if (-not (Test-Path $backupFolder)) { return }

    if($engine -eq "PostgreSQL"){
        return (Get-ChildItem $backupFolder -File -Filter "*.sql" | Select-Object -First 1 -Expand FullName)
    } else {
        return (Get-ChildItem $backupFolder -File -Filter "*.bak" | Select-Object -First 1 -Expand FullName)
    }
}

function Get-TemplateSourceFromConfig {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$configFileName,
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$configKey
    )
    $scriptName = Get-TemplateScriptNameFromConfig -configFileName $configFileName  -configKey $configKey
    return Initialize-TemplateSourceFromScriptName $scriptName
}

function Initialize-TemplateSourceFromScriptName {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [string]$scriptName,
        [ValidateSet('SQLServer', 'PostgreSQL')]
        [string] $engine = 'SQLServer'
    )

    $filePath = (Get-RepositoryResolvedPath 'configuration.packages.json')
    $scriptPath = Get-TemplateScriptPath $scriptName

    $tempconfig = New-TemporaryFile
    Copy-Item -Path $filePath -Destination $tempconfig

    Update-PackageName $scriptName  $filePath
    $returnedPath = Invoke-TemplateScript $scriptPath

    Copy-Item -Path $tempconfig -Destination $filePath
    Remove-Item $tempconfig

    # $returnedPath can be a valid backup file or a folder with a valid backup inside
    if ((Get-Item $returnedPath) -is  [System.IO.DirectoryInfo]) {
        return Get-TemplateBackupPath $returnedPath $engine
    }
    else {
        return $returnedPath
    }
}

function Update-PackageName([string] $scriptName, [string] $filePath) {

    if($scriptName -eq 'Northridge' -or $scriptName -eq 'NorthridgePostgreSql'){  return }
    
    $config = Get-Content $filePath | ConvertFrom-Json
    $packageName = $config.packages.($scriptName).PackageName

    $StandardVersion = $Settings.ApiSettings.StandardVersion
    $ExtensionVersion = $Settings.ApiSettings.ExtensionVersion

    $config.packages.($scriptName).PackageName = $packageName.Replace("{StandardVersion}",$StandardVersion).Replace("{ExtensionVersion}", $ExtensionVersion)
    $config | ConvertTo-Json | Format-Json | Out-File -FilePath $filePath -Encoding UTF8
}

function Get-MinimalTemplateBackupPathFromSettings {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [hashtable] $Settings
    )

    if (-not [string]::IsNullOrWhiteSpace($Settings.Azure.MinimalStorageUri)) { return $Settings.Azure.MinimalStorageUri }
    return Initialize-TemplateSourceFromScriptName $Settings.ApiSettings.MinimalTemplateScript
}

function Get-PopulatedTemplateBackupPathFromSettings {
    [CmdletBinding()] param(
        [parameter(ValueFromPipeline, Mandatory)]
        [hashtable] $Settings
    )

    if (-not [string]::IsNullOrWhiteSpace($Settings.Azure.PopulatedStorageUri)) { return $Settings.Azure.PopulatedStorageUri }
    return Initialize-TemplateSourceFromScriptName $Settings.ApiSettings.PopulatedTemplateScript $Settings.ApiSettings.Engine
}

Export-ModuleMember -Function Get-MinimalTemplateBackupPath,
Get-PopulatedTemplateBackupPath,
Get-EdFiDefaultMinimalTemplateBackupPath,
Get-EdFiDefaultPopulatedTemplateBackupPath,
Get-TemplateBackupPath,
Get-TemplateScripts,
Get-MinimalTemplateBackupPathFromSettings,
Get-PopulatedTemplateBackupPathFromSettings
