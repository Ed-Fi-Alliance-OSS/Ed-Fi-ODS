# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

& "$PSScriptRoot/../../../../logistics/scripts/modules/load-path-resolver.ps1"

function New-Nuspec {
    param(
        [parameter(mandatory = $true)] $nuspecPath,
        [parameter(mandatory = $true)] [string] $id,
        [parameter(mandatory = $true)] [string] $description,

        [string] $version = "0.0.0",
        [string] $title,
        [string] $authors,
        [string] $owners,
        [bool] $requireLicenseAcceptance = $false,
        [string] $releaseNotes,
        [string] $copyright = "Copyright @ " + $((Get-Date).year) + " Ed-Fi Alliance, LLC and Contributors",
        [hashtable] $dependencies,
        [switch] $forceOverwrite
    )
    if (Test-Path $nuspecPath) {
        if (-not $forceOverwrite) {
            throw "Nuspec file at '$nuspecPath' already exists"
        }
        else {
            rm $nuspecPath
        }
    }
    '<?xml version="1.0"?>' | Out-File $nuspecPath
    $nuspecPath = Resolve-Path $nuspecPath
    [xml]$xml = Get-Content $nuspecPath

    $package = $xml.AppendChild($xml.CreateElement("package"))
    $metadata = $package.AppendChild($xml.CreateElement("metadata"))
    $metadata.AppendChild($xml.CreateElement("id")).AppendChild($xml.CreateTextNode("$id")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("version")).AppendChild($xml.CreateTextNode("$version")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("title")).AppendChild($xml.CreateTextNode("$title")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("authors")).AppendChild($xml.CreateTextNode("$authors")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("owners")).AppendChild($xml.CreateTextNode("$owners")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("requireLicenseAcceptance")).AppendChild($xml.CreateTextNode("$requireLicenseAcceptance".tolower())) | Out-Null
    $metadata.AppendChild($xml.CreateElement("description")).AppendChild($xml.CreateTextNode("$description")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("releaseNotes")).AppendChild($xml.CreateTextNode("$releaseNotes")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("copyright")).AppendChild($xml.CreateTextNode("$copyright")) | Out-Null
    $metadata.AppendChild($xml.CreateElement("tags")).AppendChild($xml.CreateTextNode("$tags")) | Out-Null
    if ($dependencies) {
        $metaDependencies = $metadata.AppendChild($xml.CreateElement("dependencies"))
        $dependenciesGroup = $metaDependencies.AppendChild($xml.CreateElement("group"))
        foreach ($packageVersionPair in $dependencies.GetEnumerator()) {
            $dependency = $dependenciesGroup.AppendChild($xml.CreateElement("dependency"))
            $dependencyAttribute = $xml.CreateAttribute("$($packageVersionPair.Key)")
            $dependencyAttribute.Value = "$($packageVersionPair.Value)"
            $dependency.Attibutes.Append($dependencyAttribute) | Out-Null
        }
    }
    $package.AppendChild($xml.CreateElement("files")) | Out-Null

    $xml.Save($nuspecPath)
}

<#
.synopsis
Include a file in a .nuspec NuGet package specification

.parameter SourceTargetPair
An array of hashtables, where each hashtable must contain a .source and a .target attribute.

The .target attribute is the relative path within the NuGet package, and might look like "lib/net45/" or "lib/net45/thing.dll".

The .source attribute is an array containing one or more references to files (whether FileInfo objects, relative path strings, or absolute path strings). DirectoryInfo objects and paths to directories are ignored.
#>
function Add-FileToNuspec {
    param(
        [parameter(mandatory = $true)] [hashtable[]] [ValidateScript( {
                if ([bool]$_.target -and [bool]$_.source) { return $true }
                else { Write-Host "SourceTargetPair entry failed validation: @{ source = $($_.source); target = $($_.target) } "; return $false }
            })] $sourceTargetPair,
        [parameter(mandatory = $true)] $nuspecPath
    )
    $nuspecPath = Resolve-Path $nuspecPath
    [xml]$xml = Get-Content $nuspecPath

    $filesElem = $xml.GetElementsByTagName('files')[0]
    foreach ($pair in $sourceTargetPair) {
        $resolvedTarget = $pair.target -replace '/', [IO.Path]::DirectorySeparatorChar -replace '\\\\', '\'
        foreach ($source in $pair.source) {
            if ((Get-Item $source).gettype() -match "DirectoryInfo") {
                continue
            }
            $resolvedSource = Resolve-Path $source

            $newFile = $xml.CreateElement("file")
            $newFile.SetAttribute('src', $resolvedSource)
            $newFile.SetAttribute('target', $resolvedTarget)

            Write-Verbose "Adding new XML element for file '$resolvedPath'"
            $filesElem.AppendChild($newFile) | Out-Null
        }
    }

    $xml.Save("$nuspecPath")
}

<#
.synopsis
Add a file from one of the $repositoryNames to a Nuspec package specification
#>
function Add-RepositoryFileToNuspec {
    param(
        [parameter(mandatory = $true)] [Object[]] $filePath,
        [parameter(mandatory = $true)] $nuspecPath
    )

    $sourceTargetPair = @()
    foreach ($file in $filePath) {
        if ($file.GetType().name -match '(File|Directory)Info$') {
            $fullname = $file.fullname
        }
        else {
            $fullname = Resolve-Path $file
        }
        $foundRepoRoot = $false
        foreach ($repoRoot in Get-RepositoryRoot) {
            $repoName = Split-Path -leaf $repoRoot

            $escRegex = [Regex]::Escape("$($repoRoot.tolower())$([IO.Path]::DirectorySeparatorChar)")
            if ($fullname -match "^$escRegex") {
                $relPath = $fullname -replace $escRegex, ''
                $sourceTargetPair += @(@{ source = $fullname; target = "$repoName$([IO.Path]::DirectorySeparatorChar)$relPath" })
                $foundRepoRoot = $true
                break
            }
        }
        if (-not $foundRepoRoot) {
            throw "File '$($artifact.fullname)' does not appear to be in one of the repository roots."
        }
    }
    Add-FileToNuspec -nuspecPath $nuspecPath -sourceTargetPair $sourceTargetPair
}

Export-ModuleMember -Function *
