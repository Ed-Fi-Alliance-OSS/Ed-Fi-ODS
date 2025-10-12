# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
.Synopsis
Resolve paths across specified repositories

.Description
Resolve paths across specified repositories.

A folder anchor is used to allow resolution across repositories.
For overrides to work, the relative folder paths for the override and the core implementation must be the same.

.Parameter repositoryNames
The RepositoryNames argument has a default value of Ed-Fi-ODS and Get-RepositoryRoot "Ed-Fi-ODS".
The value can be overridden by either passing the repository names when the module is imported or by specifying an environment
variable 'PathResolverRepositoryOverride'. If both are specified, the repositories passed directly to the module during import have
preeminence. The format for the environment variable is semicolon separated values.

Important: Names of the repositories do not matter when they are specified. However the order is important. Repositories will be
interpreted with the first repository name as the most general or 'core' and the last repository specified as the most implementation
specific.

NOTE: When passing in repository names to Import-Module with -ArgumentList, some non-obvious syntax is required.
In short, it must be invoked like this:

    import-module path-resolve.psm1 -ArgumentList @(,@('root1','root2','rootN'))

The $repositoryNames parameter is an array, and -ArgumentList expects an array; in order for -ArgumentList to interpret the
$repositoryNames parameter as a single argument, rather than expand it as a list of multiple positional arguments, it must be passed
as an array within an array.
#>
param(
    [string[]] $repositoryNames
)

#Resolve if overrides or defaults are required
if ($null -eq $repositoryNames) {
    $repositoryNames = @('Ed-Fi-ODS')
}
if ([string]::IsNullOrWhiteSpace($env:PathResolverRepositoryOverride)) {
    Write-Host "Using repositories: $($repositoryNames -join ', ')"
}
else {
    $repositoryNames = @($env:PathResolverRepositoryOverride.Split(';'))
    Write-Host "Using repositories from environment variable: $($repositoryNames -join ', ')"
}

#Create new object in memory (not just a pointer)
$invertedRepositoryNames = $repositoryNames.Clone()
#Invert the values
[Array]::Reverse($invertedRepositoryNames)

#Works up the $path until it finds the first incidence of the $itemName in the $path.
#Then trims the end of the $path off at that point and returns the path. (does include $itemName)
#in the value returned.
function Get-AncestorItemPath ([string]$path, [string]$itemName) {
    $dirChar = [IO.Path]::DirectorySeparatorChar
    $pos = $path.LastIndexOf("$($dirChar)$itemName$($dirChar)", [System.StringComparison]::OrdinalIgnoreCase)

    if ($pos -lt 0) {
        if ($path.EndsWith("$($dirChar)$itemName", [System.StringComparison]::OrdinalIgnoreCase)) {
            $pos = $path.LastIndexOf("$($dirChar)$itemName", [System.StringComparison]::OrdinalIgnoreCase)
        }
        else {
            throw "Unable to locate '$itemName' in path '$path'."
        }
    }

    # Using Join-Path to be more Unix-friendly
    $newPath = Join-Path -Path $path.Substring(0, $pos) -ChildPath "$($dirChar)$itemName"
    return (Resolve-Path $newPath)
}

<#
.Synopsis
Formats an array of paths to put the paths in order by repository.

.Description
Formats an array of paths to put the paths in order by repository.
By default the most specific repository paths are first.
Does not support paths from outside of known repositories (throws exception).

.Parameter Path
The array of paths to order. The paths can be File/Directory Information objects or strings.

.Parameter GeneralFirst
Switch that indicates to sort the paths with the most general paths first.
#>
function Format-ArrayByRepositories ([object[]]$pathArray, [switch]$generalFirst) {
    $outPathArray = @()
    $repoNamesForSorting = if ($generalFirst) { $repositoryNames } else { $invertedRepositoryNames }
    foreach ($repo in $repoNamesForSorting) {
        foreach ($path in $pathArray) {
            #The get call here throws if the path is outside known repos.
            if ((Get-RepositoryNameFromPath $path) -eq $repo) {
                $outPathArray += $path
            }
        }
    }
    return $outPathArray
}

<#
.Synopsis
Returns the repository name of the repository the provided path is within.

.Description
Returns the repository name of the repository the provided path is within.
Throws an exception if a known repository is not found in the path.

.Parameter Path
The path to look up the repoisitory for.
#>
function Get-RepositoryNameFromPath ($path) {
    if ($path.GetType().name -match '(File|Directory)Info$') {
        $fullname = $path.FullName
    }
    else {
        $fullname = (Resolve-Path $path).Path
    }
    #TODO:Enhance this logic so that it handles "C:/projects/Ed-Fi-Core" (no trailing slash) as an input
    foreach ($repoName in $repositoryNames) {
        $repoRoot = "$(Get-RepositoryRoot $repoName)$([IO.Path]::DirectorySeparatorChar)"
        $escRegex = [Regex]::Escape($repoRoot.tolower())
        if ($fullname -match "^$escRegex") {
            return $repoName
        }
    }

    throw "Path: '$fullname' does not appear to be inside one of the repository roots."
}

function Get-RootPath {
    #Look up from this script's location to find the highest level common named folder.
    $logisticsBasePath = Get-AncestorItemPath $PSScriptRoot "logistics"
    #Jump up two levels to get the root.
    return Resolve-Path "$logisticsBasePath/../../"
}

#Using the Root path for the repositories, return back the path for the $repositoryName specified.
function Get-RootBasedRepositoryPath ([string]$repositoryName) {
    $root = Get-RootPath
    $repositoryPath = "$($root)$repositoryName"

    If (-not (Test-Path $repositoryPath)) {
        throw ("$repositoryName path not found under $($root)!")
    }
    return $repositoryPath
}

<#
.synopsis
Get the root of the specified repository.
.parameter RepositoryName
The name(s) of the repositories to find the root of.
If this is not specified, find the roots of all repositories in the path resolver.
#>
function Get-RepositoryRoot {
    [cmdletbinding()]
    param(
        [string[]]$repositoryName
    )
    if (-not $repositoryName) {
        $repositoryName = $repositoryNames
    }
    foreach ($repo in $repositoryName) {
        if (-not ($repositoryNames -contains $repo)) {
            throw "Tried to get the root of a repository named $repo, but the path resolver doesn't know about a repository with that name."
        }
        Write-Verbose "Getting repository root for repository: $repo"
        Get-RootBasedRepositoryPath $repo
    }
}

function Get-RepositoryNames {
    return $script:repositoryNames
}

<#
.Synopsis
Return paths to specified files, checking all repositories, and including only the most specific version of each file.

.Description
Return paths to specified files, checking all repositories, and including only the most specific version of each file.

For example, in a system with three repositories, laid out like this:

    /Ed-Fi-Core
        /1234.txt
        /qwer.txt
    /Ed-Fi-Plugins
        /qwer.txt
        /asdf.txt
    /Ed-Fi-Apps
        /asdf.txt
        /zxcv.txt

Seraching for zxcv.txt or asdf.txt returns the version in Ed-Fi-Apps; searching for qwer.txt returns the version in Ed-Fi-Plugins, and searching for 1234.txt returns the version in Ed-Fi-Core.

.Parameter PathSuffix
The path suffix to append to the repository path. E.g. if $pathSuffix is 'logistics', find files in <most specific repository>/logistics.
#>
function Get-RepositoryResolvedPath ([string]$pathSuffix) {
    foreach ($repositoryName in $invertedRepositoryNames) {
        $repositoryPath = Get-RootBasedRepositoryPath $repositoryName
        If (Test-Path "$repositoryPath/$pathSuffix") {
            return Resolve-Path "$repositoryPath/$pathSuffix"
        }
    }
    $errorMsg = "$pathSuffix was not found in the following repositories:`r`n{0}" -f ($invertedRepositoryNames -join "`r`n")
    throw ($errorMsg)
}

<#
.Synopsis
Return the most next most general repository path with the specified path suffix.

.Description
Return the next most general repository path with the specified path suffix. There must be more than 1 repositories in $repositoryNames, do not look in the calling or more specific repositories at all.

For example, if there are four repositories: Get-RepositoryRoot "Ed-Fi-ODS", Ed-Fi-ODS, Ed-Fi-Dashboards-Core and Ed-Fi-Apps and the calling script is in Ed-Fi-Apps look first in Ed-Fi-Dashboards-Core, if it does not have it then Ed-Fi-ODS, if it does return it. The assumption is then that the Ed-Fi-ODS script would again call this function and during that call the Ed-Fi-Apps, Ed-Fi-Dashboards-Core, and Ed-Fi-ODS repositroies would be ignored, and Get-RepositoryRoot "Ed-Fi-ODS" would be searched.

.Notes
This is useful when dot-sourcing or importing core scripts in an extension, so that the parent repository functionality can be inherited if it exists.

.Parameter PathSuffix
The path suffix to append to the repository path. E.g. if $pathSuffix is 'logistics', find files in <next most general repository>/logistics.
#>
function Get-CorePath ([string]$pathSuffix) {
    #If you don't pass me a path I'm going to use the old look up logic
    #This is only here for the $folders.core and that needs to be removed as soon as
    #web deployments no longer require it.
    if ("$pathSuffix" -eq "") {
        return Get-CorePathLegacy
    }
    else {
        #This has been switched to a dynamic lookup so that not every "core" repo has to have every folder.
        #Just give a single repo a pass on this check.
        if ($repositoryNames.Count -le 0) {
            #I'm just throwing here since any other response is really a hack.
            throw "Core path lookups are not supported in single repository implementations."
        }
        $callingPath = if ($MyInvocation.ScriptName) { $MyInvocation.ScriptName }else { "$((Get-Location).Path)/" }
        $callingRepo = Get-RepositoryNameFromPath $callingPath
        $checkedRepos = @()
        $notCheckedRepos = @()
        $callingRepoIndex = $invertedRepositoryNames.IndexOf($callingRepo)

        #Look for the next repository we find after the one that is callingRepo
        #If it has the file we're looking for, return it.
        for ($i = 0; $i -lt $invertedRepositoryNames.Length; $i++) {
            $repositoryName = $invertedRepositoryNames[$i]
            if ($i -lt $callingRepoIndex) {
                $notCheckedRepos += $repositoryName
            }
            elseif ($i -gt $callingRepoIndex) {
                $checkedRepos += $repositoryName
                $repositoryPath = Get-RootBasedRepositoryPath $repositoryName
                if (Test-Path "$repositoryPath/$pathSuffix") {
                    return Resolve-Path "$repositoryPath/$pathSuffix"
                }
            }
        }

        $errorMsg = "$pathSuffix was not found in the following repositories:`r`n{0}" -f ($checkedRepos -join "`r`n")
        if ($notCheckedRepos.Length -gt 0) {
            $errorMsg += "The following repositories were not checked as they were more specific than the caller: `r`n{0}" -f ($notCheckedRepos -join "`r`n")
        }
        throw ($errorMsg)
    }
}

<#
.Synopsis
Return the most general repository path with the specified path suffix.

.Description
Return the most general repository path with the specified path suffix. As long as there are more than 1 repositories in $repositoryNames, do not look in the least general repository at all.

For example, if there are three repositories: Ed-Fi-Core, Ed-Fi-Plugins, and Ed-Fi-Apps, look first in Ed-Fi-Core, and then in Ed-Fi-Plugins, for the specified path suffix. Ignore the path in Ed-Fi-Apps even if it does exist.

.Notes
This is useful when dot-sourcing or importing core scripts in an extension, so that the core functionality can be inherited if it exists, but it will not cause an infinite loop by attempting to import itself.

.Parameter PathSuffix
The path suffix to append to the repository path. E.g. if $pathSuffix is 'logistics', find files in <most general repository>/logistics.
#>
function Get-CorePathLegacy ([string]$pathSuffix) {
    #This has been switched to a dynamic lookup so that not every "core" repo has to have every folder.
    #Just give a single repo a pass on this check.
    if ($repositoryNames.Count -gt 1) {
        $implementationRepo = ($repositoryNames | select -Last 1)
    }
    else {
        Write-Host "Warning: Core path lookups are not typically used in single repository implementations."
        $implementationRepo = [string]::Empty
    }
    $checkedRepos = @()
    foreach ($repositoryName in $repositoryNames) {
        #skip the implementation repo. It is not ever going to be "core".
        if ($repositoryName -eq $implementationRepo) { continue; }
        $checkedRepos += $repositoryName
        $repositoryPath = Get-RootBasedRepositoryPath $repositoryName
        If (Test-Path "$repositoryPath/$pathSuffix") {
            return Resolve-Path "$repositoryPath/$pathSuffix"
        }
    }
    $errorMsg = "$pathSuffix was not found in the following repositories:`r`n{0}" -f ($checkedRepos -join "`r`n")
    throw ($errorMsg)
}

<#
.Synopsis
Select files in the repositories. Use files recursively from Apps to Core.

.Description
Iterate over all the repository paths, going from most specific to least. If the path exists with the specified path suffix select all the files listed that have not been resolved in a previous repository. Apply the filter to the file listing, aggregate, and return the result.

NOTE: The indexing utilized looks at the relative paths from the repository root when determining if a file has previously been selected.

.Parameter PathSuffix
The path suffix to append to the repository path. E.g. if $pathSuffix is 'logistics', find files in '<repository roots>/logistics'.

.Parameter Filter
Use a Get-ChildItem when selecting files, such as '*.sql'.

.Parameter Recurse
Select files recursively.
#>
function Select-RepositoryResolvedFiles {
    param(
        [string] $pathSuffix,
        [string] $filter,
        [switch] $recurse
    )
    $output = @()
    $namesTypes = @{ }
    #Using inverted listing so core goes last.
    foreach ($repositoryName in $invertedRepositoryNames) {
        $outputHolder = @()
        $repositoryPath = Get-RootBasedRepositoryPath $repositoryName
        If (Test-Path "$repositoryPath/$pathSuffix") {
            $repositoryResolvedPath = Resolve-Path "$repositoryPath/$pathSuffix"
            #Select all the files in the path that match the pattern where they are not listed in the index
            $outputHolder += gci -recurse:$recurse $repositoryResolvedPath -filter $filter | where { if (($namesTypes.Keys -contains ($_.FullName -Replace [regex]::Escape("$repositoryPath"), "")) -and ($namesTypes[($_.FullName -Replace [regex]::Escape("$repositoryPath"), "")] -eq $_.GetType())) { $false } else { $true } }
            #Add new files to index
            $outputHolder | % { $namesTypes.Add(($_.FullName -Replace [regex]::Escape("$repositoryPath"), ""), $_.GetType()) }
            #Add new files to output
            $output += $outputHolder
        }
    }
    return $output
}

<#
.Synopsis
Select items from all repositories. Return all items that match.

.Description
Iterate over all the repository paths, if the path exists with the specified path suffix, apply the filter to the file
listing, aggregate, and return the resulting items.

.Parameter PathSuffix
The path suffix to append to the repository path. E.g. if $pathSuffix is 'logistics', find items in
'C:/path/to/Ed-Fi-Core/logistics'.

.Parameter Filter
Use a Get-ChildItem filter when selecting items, such as '*.sql'.

.Parameter Recurse
Select items recursively.

.Parameter Directory
Select directories only.
#>
function Select-CumulativeRepositoryResolvedItems {
    param(
        [string] $pathSuffix,
        [string] $filter,
        [switch] $recurse,
        [switch] $directory
    )
    $output = @()
    foreach ($repositoryName in $repositoryNames) {
        $repositoryPath = Get-RootBasedRepositoryPath $repositoryName
        If (Test-Path "$repositoryPath/$pathSuffix") {
            $repositoryResolvedPath = Resolve-Path "$repositoryPath/$pathSuffix"
            #Select all the items in the path that match the pattern
            $output += Get-ChildItem $repositoryResolvedPath -filter $filter -recurse:$recurse -directory:$directory
        }
    }
    return $output
}

<#
.Synopsis
Select all extensions project directories from all repositories

.Description
Iterate over all the repository paths, if the path exists with the specified path suffix, apply the filter to the file
listing, aggregate, and return the result.

.Parameter PathSuffix
The path suffix to append to the repository path. E.g. if $pathSuffix is 'Application', find directories in
'C:/Projects/Ed-Fi-ODS/Application/'.

.Parameter Filter
Use a Get-ChildItem filter when selecting directories, such as 'EdFi.Ods.Extensions.*'.

.Parameter Recurse
Select directories recursively.

.EXAMPLE
PS C:/> Select-SupportingArtifactResolvedSources "Application" -filter "EdFi.Ods.Extensions.*"


    Directory: C:/Projects/Ed-Fi-ODS/Application


Mode                LastWriteTime         Length Name
----                -------------         ------ ----
d-----         3/7/2018   1:44 PM                EdFi.Ods.Extensions.GrandBend
d-----         3/7/2018   1:44 PM                EdFi.Ods.Extensions.Sample
#>
function Select-SupportingArtifactResolvedSources {
    param(
        [string] $pathSuffix = "Application",
        [string] $filter = "EdFi.Ods.Extensions.*",
        [switch] $recurse
    )
    return Select-CumulativeRepositoryResolvedItems -pathSuffix $pathSuffix -filter $filter -recurse:$recurse -directory
}

<#
.SYNOPSIS
Selects the extension name.

.DESCRIPTION
Returns the last segment of an extension project name.

.PARAMETER name
The full project name for this extension.

.PARAMETER exclude
A list of project names to exclude from the results

.EXAMPLE
-------------------------- EXAMPLE 1 --------------------------
PS C:/> Select-ExtensionArtifactResolvedName EdFi.Ods.Extensions.GrandBend
GrandBend

-------------------------- EXAMPLE 2 --------------------------
PS C:/> Select-ExtensionArtifactResolvedName C:/Projects/Get-RepositoryRoot "Ed-Fi-ODS"/Application/EdFi.Ods.Extensions.GrandBend
GrandBend

-------------------------- EXAMPLE 3 --------------------------
PS C:/> Select-SupportingArtifactResolvedSources | Select-ExtensionArtifactResolvedName
GrandBend
Sample

-------------------------- EXAMPLE 4 --------------------------
PS C:/> Select-SupportingArtifactResolvedSources | Select-ExtensionArtifactResolvedName -exclude "Sample"
GrandBend

#>
function Select-ExtensionArtifactResolvedName {
    param(
        [parameter(ValueFromPipeline = $true)] [string] $name,
        [string[]] $exclude = @()
    )
    Begin {
        $output = @()
    }
    Process {
        $output += $name.Split(".")[-1]
    }
    End {
        return $output.where( { $_ -notin $exclude })
    }
}

function Select-SupportingArtifactSubTypeFiles {
    param(
        [Parameter(Mandatory = $true)] [string] $source,
        [string[]] $subTypes,
        [string] $filter,
        [switch] $recurse
    )

    $output = @()
    if ($subtypes -eq $null -or $subtypes.Length -eq 0) {
        $resolvedSubtypes = @("*")
    }
    else {
        $resolvedSubtypes = @("*")

        foreach ($subType in $subTypes) {
            $resolvedSubTypes += @("${subType}/*")
        }
    }

    if (Test-Path $source) {
        foreach ($subType in $resolvedSubTypes) {
            if (Test-Path "$source/$subType/") {
                $output += Get-ChildItem "$source/$subType/" -filter $filter -recurse:$recurse
            }
        }
    }
    return $output
}

<#
.SYNOPSIS
Select supporting artifact database files from all repositories and any artifact sources provided.

.DESCRIPTION
Iterate over all the repository paths, if the database path exists with the specified script type and database type then
iterate over each subtype, or all subtypes if none specified, apply the filter to the file listing, aggregate, and
return a list of all files that match this criteria.

The directory naming convention follows the patterns:
<repositoryName>/<artifactType>/<scriptType>/<dbTypeName>/<subTypes> for repository level sources and
<repositoryName>/Application/EdFi.Ods.Extensions.<artifactType>/<scriptType>/<dbTypeName>/<subTypes>
for extension artifact sources.

.PARAMETER artifactType
The artifact type, such as 'Database', 'Metadata'.

.PARAMETER scriptType
The script type, such as 'Data', 'Structure'.

.PARAMETER scriptTypeName
The script type name, such as 'EdFi'.

.PARAMETER subTypes
An array of specific subtypes to look for when in the scriptTypeName directory. By default it will look in all directories.

.PARAMETER artifactSources
An array of artifact source names, such as 'GrandBend', 'Sample'.

.PARAMETER filter
Use a Get-ChildItem filter when selecting items, such as '*.sql'.

.PARAMETER recurse
Use a Get-ChildItem recurse when selecting items.

.EXAMPLE
PS C:/> Select-SupportingArtifactResolvedFiles -artifactType "Database" -scriptType "Structure" -scriptTypeName "EdFi" -artifactSources GrandBend,Sample -filter "*.sql"


    Directory: C:/Projects/Ed-Fi-Ods/Database/Structure/EdFi


Mode                LastWriteTime         Length Name
----                -------------         ------ ----
-a----         3/5/2018   5:13 PM            354 0010-Schemas.sql
-a----         3/5/2018   5:13 PM         370896 0020-Tables.sql
-a----         3/5/2018   5:13 PM         360633 0030-ForeignKeys.sql
-a----         3/5/2018   5:13 PM          28333 0040-IdColumnUniqueIndexes.sql
-a----         3/5/2018   5:13 PM         798899 0050-ExtendedProperties.sql
-a----         3/5/2018   5:13 PM            236 1001-Schemas.sql
-a----         3/5/2018   5:13 PM           1215 1002-Roles.sql
-a----         3/5/2018   5:13 PM             56 1003-Users.sql
-a----         3/5/2018   5:13 PM            881 1005-UserDefinedFunctions.sql
-a----         3/5/2018   5:13 PM          39373 1006-AuthViews.sql
-a----         3/5/2018   5:13 PM           3088 1007-AuthSynonyms.sql
-a----         3/5/2018   5:13 PM             33 1008-StoredProcedures.sql
-a----         3/5/2018   5:13 PM           8019 1011-CompositesHierarchicalViews.sql
-a----         3/5/2018   5:13 PM           1328 1014-Create-authorization-views-for-students-through-StudentEducationOrganizationAssociation.sql
-a----         3/5/2018   5:13 PM           4331 1015-Drop-unused-authorization-views-and-synonyms.sql
-a----         3/5/2018   5:13 PM           2156 1017-ChangeAuthViewColumnsToNvarchar.sql
-a----         3/5/2018   5:13 PM            134 1022-Add-SQL-Types-For-NHibernate-TVP-Support.sql
-a----         3/5/2018   5:13 PM           4080 1023-Create-Update-CommunityOrganization-Auth-Views.sql
-a----         3/5/2018   5:13 PM           2092 1024-AddAssessmentAuthViews.sql
-a----         3/5/2018   5:13 PM           4017 1025-Create-Update-PostSecondaryInstitution-Auth-Views.sql


    Directory: C:/Projects/Ed-Fi-ODS/Application/EdFi.Ods.Extensions.GrandBend/SupportingArtifacts/Database/Structure/EdFi


Mode                LastWriteTime         Length Name
----                -------------         ------ ----
-a----         3/7/2018   1:29 PM          10084 1000-EdFi_Ods_GrandBend.sql


    Directory: C:/Projects/Ed-Fi-ODS/Application/EdFi.Ods.Extensions.Sample/SupportingArtifacts/Database/Structure/EdFi


Mode                LastWriteTime         Length Name
----                -------------         ------ ----
-a----         3/7/2018   1:38 PM           6409 1001-EdFi_Ods_Sample.sql

#>
function Select-SupportingArtifactResolvedFiles {
    param(
        [Parameter(Mandatory = $true)] [string] $artifactType,
        [string] $scriptType = "*",
        [string] $scriptTypeName = "*",
        [string[]] $subTypes,
        [string[]] $artifactSources = @(),
        [string] $filter,
        [switch] $recurse
    )
    $output = @()
    foreach ($repositoryName in Get-RepositoryNames) {
        $repositoryPath = $(Get-RepositoryRoot $repositoryName)

        $repositorySource = "$repositoryPath/$artifactType/$scriptType/$scriptTypeName"
        $output += Select-SupportingArtifactSubTypeFiles $repositorySource $subTypes -filter $filter -recurse:$recurse

        foreach ($artifactSource in $artifactSources) {
            $extensionSource = "$repositoryPath/Application/EdFi.Ods.Extensions.$artifactSource/Artifacts/$scriptType/$scriptTypeName"
            $output += Select-SupportingArtifactSubTypeFiles $extensionSource $subTypes -filter $filter -recurse:$recurse
        }
    }
    return $output
}

#Sets a global folders variable. Is the primary access mechanism for resolving paths. Utilizes a delegate.
if (-not ($script:folders)) {
    $script:folders = @{ }
    #This is used in remote web deployments to find this path resolver and CANNOT be a delegate.
    $folders.core = Get-CorePath
    $folders.scripts = [System.Func[Object, Object]] { return (Get-RepositoryResolvedPath "logistics/scripts/$($args[0])") }
    $folders.base = [System.Func[Object, Object]] { return (Get-RepositoryResolvedPath "$($args[0])") }
    $folders.tools = [System.Func[Object, Object]] { return (Get-RepositoryResolvedPath "tools/$($args[0])") }
    $folders.modules = [System.Func[Object, Object]] { return (Get-RepositoryResolvedPath "logistics/scripts/modules/$($args[0])") }
    $folders.activities = [System.Func[Object, Object]] { return (Get-RepositoryResolvedPath "logistics/scripts/activities/$($args[0])") }
}

#Set aliases to maintain previous functionality
Set-Alias -Name Select-EdFiFiles -Value Select-RepositoryResolvedFiles -Description "Legacy passthru for Ed-Fi script calls"
Set-Alias -Name Select-EdFiDatabaseFiles -Value Select-CumulativeRepositoryResolvedItems -Description "Legacy passthru for Ed-Fi script calls"
Set-Alias -Name Select-CumulativeRepositoryResolvedFiles -Value Select-CumulativeRepositoryResolvedItems -Description "Legacy passthru for Ed-Fi script calls"
Set-Alias -Name Select-CumaltiveRepositoryResolvedFiles -Value Select-CumulativeRepositoryResolvedItems -Description "Correct spelling error in previous version"

$exportFunction = @(
    'Select-RepositoryResolvedFiles'
    'Select-CumulativeRepositoryResolvedItems'
    'Select-SupportingArtifactResolvedSources'
    'Select-SupportingArtifactResolvedFiles'
    'Select-ExtensionArtifactResolvedName'
    'Get-RootPath'
    'Get-CorePath'
    'Get-RepositoryResolvedPath'    
    'Get-RepositoryRoot'
    'Get-RepositoryNames'
    'Get-RepositoryNameFromPath'
    'New-Nuspec'
    'Add-FileToNuspec'
    'Add-RepositoryFileToNuspec'
    'Format-ArrayByRepositories'
)
$exportVariable = @(
    "folders"
)
$exportAlias = @(
    'Select-EdFiFiles'
    'Select-EdFiDatabaseFiles'
    'Select-CumaltiveRepositoryResolvedFiles'
)
Export-ModuleMember -Function $exportFunction -variable $exportVariable -alias $exportAlias
