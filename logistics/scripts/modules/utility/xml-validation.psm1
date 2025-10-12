# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/tasks/TaskHelper.psm1')

function Get-XmlRoot {
    param(
        [Parameter(Mandatory = $true)]
        [string] $source
    )

    try {
        $streamReader = New-Object System.IO.StreamReader $source
        $xmlReader = [System.Xml.XmlReader]::Create($streamReader, (New-Object "System.Xml.XmlReaderSettings"))
        $xmlReader.MoveToContent() | Out-Null
        $result = @{
            name = $xmlReader.Name
            namespace = $xmlReader.NamespaceURI
            schema = ($xmlReader.GetAttribute("xsi:schemaLocation") -replace $xmlReader.NamespaceURI, "").Trim()
        }
        return $result
    }
    finally {
        foreach ($disposable in @($streamReader, $xmlReader)) {
            if ($null -ne $disposable -and $disposable -is [System.IDisposable]) {
                $disposable.Dispose()
            }
        }
    }

    return $result
}

Set-Alias -Scope Global Validate-Xml Invoke-XmlValidation
function Invoke-XmlValidation {
    <#
    .SYNOPSIS
        Validates Xml files.

    .DESCRIPTION
        Validates xml files using the schema location defined within an xml file.

    .PARAMETER source
        An absolute path to the folder to load samples from, for example: C:/MySampleXmlData/.
        Also supports specific version folders of the Data Standard repository, for example: C:/Ed-Fi-Standard/v3.0/ or C:/Ed-Fi-Standard/v2.0/
    .INPUTS
        [string] Source Directory
        [string] Filter
    .OUTPUTS
        None.
    .EXAMPLE
        PS> Validate-Xml -source "C:/edfi/Ed-Fi-Standard/v3.1/Samples/Sample XML/
    #>
    param(
        # The source directory where the files are located.
        [Parameter(Mandatory = $true)]
        [string] $source,

        # The filter used by Get-ChildItem
        [Parameter(Mandatory = $false)]
        [string] $filter = "*.xml",

        # The filter used by Get-ChildItem
        [Parameter(Mandatory = $false)]
        [switch] $recurse
    )

    $xmlFiles = Get-ChildItem -Path $source -Filter $filter -Recurse:$recurse

    $xmlReaderSettings = New-Object System.Xml.XmlReaderSettings
    $xmlReaderSettings.ValidationType = [System.Xml.ValidationType]::Schema
    $xmlReaderSettings.ValidationFlags =
    [System.Xml.Schema.XmlSchemaValidationFlags]::ProcessInlineSchema -bor
    [System.Xml.Schema.XmlSchemaValidationFlags]::ReportValidationWarnings
    $xmlReaderSettings.Schemas.XmlResolver = New-Object System.Xml.XmlUrlResolver

    $script:validationErrorCount = 0

    $validationHandler = [System.Xml.Schema.ValidationEventHandler] {
        if ($_.Severity -eq [System.Xml.Schema.XmlSeverityType]::Warning) {
            Write-Warning "$($_.Message)"
        }
        elseif ($_.Severity -eq [System.Xml.Schema.XmlSeverityType]::Error) {
            Write-Error "$($_.Message)"
            $script:validationErrorCount++
        }
    }
    $xmlReaderSettings.add_ValidationEventHandler($validationHandler)

    $previousErrorActionPreference = $ErrorActionPreference
    $ErrorActionPreference = "Continue"
    try {
        foreach ($file in $xmlFiles) {
            $elapsed = Use-StopWatch {
                Write-Host "Validating $file " -NoNewline
                $rootElement = Get-XmlRoot $file.FullName

                if ([string]::IsNullOrEmpty($rootElement.schema)) {
                    Write-Warning "No schema found for $file, skipping validation."
                    continue
                }
                $schemaFile = (Join-Path $file.Directory.FullName $rootElement.schema -Resolve)
                $xmlReaderSettings.Schemas.Add($rootElement.namespace, $schemaFile) | Out-Null
                $xmlReader = [System.Xml.XmlReader]::Create($file.FullName, $xmlReaderSettings)

                while ($xmlReader.Read()) { }
                $xmlReader.Dispose()
            }
            Write-Host $elapsed.duration -ForegroundColor DarkGray
        }
    }
    finally {
        $ErrorActionPreference = $previousErrorActionPreference
        if ($null -ne $xmlReader -and $xmlReader -is [System.IDisposable]) {
            $xmlReader.Dispose()
        }
    }

    if($script:validationErrorCount -gt 0) {
        throw [System.Xml.Schema.XmlSchemaValidationException] "Schema validation failed with $script:validationErrorCount error(s)."
    }
}

Export-ModuleMember -Function * -Alias *