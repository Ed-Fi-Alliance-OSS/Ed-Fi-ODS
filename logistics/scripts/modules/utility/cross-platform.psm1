# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

function GetExeExtension() {
    return @(If (Get-IsWindows) { ".exe" } Else { "" })
}

function IsCommandAvailable {
    param (
        [String]
        [Parameter(Mandatory=$true)]
        $Command
    )

    try {
        Get-Command $Command -ErrorAction Stop | Out-Null
        return $true
    }
    catch {
        return $false 
    }
}

function EnsureCommandIsAvailable {
    param (
        [String]
        [Parameter(Mandatory=$true)]
        $Command
    )

    if (!(IsCommandAvailable $Command)) {
        throw "The next command is required by the script but it is not installed: $Command"
    }
}

function Get-IsWindows {
    <#
    .SYNOPSIS
        Checks to see if the current machine is a Windows machine.
    
    .EXAMPLE
        Get-IsWindows

        returns $True
    #>

    if ($null -eq $IsWindows) {
        # This section will only trigger when the automatic $IsWindows variable is not detected.
        # Every version of PS released on Linux contains this variable so it will always exist.
        # $IsWindows does not exist pre PS 6.
        return $true
    }

    return $IsWindows
}

function Get-DotnetRuntimes {

    try {
        $data = dotnet --list-runtimes
    }
    catch {
        throw "Running scripts require .NET Core SDK, available from https://dotnet.microsoft.com/download."
    }
    
    $runtimeArray = @()
    foreach($entry in $data){
        
        $values =  $entry.Split(" ",3)
        $runtime = $values[0]
        $version = [Version]$values[1].Split("-")[0] # Trim version at any pre-release information
        $path = $values[2] -replace '[][]',''
        $thisRuntime = [ordered]@{
            "Runtime" = $runtime;
            "Version" = $version;
            "Path" = $path;
        }
        $thisObject = [PSCustomObject]$thisRuntime
        $runtimeArray += $thisObject
    }
    return $runtimeArray
}

Export-ModuleMember -Function `
    Get-IsWindows,
    Get-DotnetRuntimes,
    IsCommandAvailable,
    EnsureCommandIsAvailable, 
    GetExeExtension
