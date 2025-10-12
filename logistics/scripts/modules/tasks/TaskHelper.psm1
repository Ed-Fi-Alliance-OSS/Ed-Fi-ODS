# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.
function Clear-Error {
    $Error.Clear()
    # artificially setting an automatic variable needs to be done at a global scope level
    $global:LASTEXITCODE = 0
}

function Write-TaskInfo ([string] $name) {
    Write-TeamCityBlockOpened $name
    $border = ('-' * ($name.Length + 8))
    Write-Host
    Write-Host -ForegroundColor Cyan $border
    Write-Host -ForegroundColor Cyan "    $name    "
    Write-Host -ForegroundColor Cyan $border
    Write-Host
}

function Get-DurationString([TimeSpan] $elapsed) {
    $duration = ''
    if ($elapsed.TotalMilliseconds -lt 1000.0) { return "$($elapsed.Milliseconds)ms" }
    if ($elapsed.Hours -gt 0) { $duration += "$($elapsed.Hours)h" }
    if ($elapsed.Minutes -gt 0) { $duration += "$($elapsed.Minutes)m" }
    if ($elapsed.Seconds -gt 0) { $duration += "$($elapsed.Seconds)s" }
    return $duration
}
function Use-StopWatch([scriptblock] $scriptblock) {
    $elapsed = [System.Diagnostics.Stopwatch]::StartNew()
    . $scriptblock
    $elapsed.Stop()
    $elapsed | Add-Member -MemberType NoteProperty -Name 'duration' -Value (Get-DurationString $elapsed.Elapsed)
    $elapsed | Add-Member -MemberType NoteProperty -Name 'format' -Value ('{0:mm\:ss\.ff}' -f $elapsed.Elapsed)
    return $elapsed
}

function Test-ErrorVariable { return ($null -ne $Error -and $Error.count -gt 0) }

function Test-LastExitCodeVariable { return ($null -ne $LASTEXITCODE -and $LASTEXITCODE -ne 0) }

function Test-TaskAlreadyInvoked([string] $name) {
    if ($null -eq $global:InvokedTasks){ return $false }
    return ($global:InvokedTasks | Where-Object Task -eq $name | Measure-Object).Count -gt 0
}
function Test-TeamCityVersion { return (Test-Path env:TEAMCITY_VERSION) }

function Test-Error {
    if (Test-ErrorVariable) { throw $Error }
    if (Test-LastExitCodeVariable) { throw "Last operation had non-zero exit code: $LASTEXITCODE" }
    # https://www.jetbrains.com/help/teamcity/powershell.html#PowerShell-ErrorHandling
    if ((Test-TeamCityVersion) -and (Test-ErrorVariable -or Test-LastExitCodeVariable)) { exit $LASTEXITCODE }
}

function Write-TaskDuration ([string] $name, [string] $duration) {
    Write-Host "$name done in $duration."
    Write-TeamCityBlockClosed $name
}

function Write-TeamCityBlockOpened([string] $name) {
    if (Test-TeamCityVersion) { Write-Host "##teamcity[blockOpened name='$name']" }
}

function Write-TeamCityBlockClosed([string] $name) {
    if (Test-TeamCityVersion) { Write-Host "##teamcity[blockClosed name='$name']" }
}

function Write-TeamCityBuildStatus([string] $text) {
    if (Test-TeamCityVersion) { Write-Host "##teamcity[buildStatus text='$text']" }
}

function New-TaskResult([string] $name, [string] $duration) {
    return New-Object PSObject -property @{ Task = $name; Duration = $duration }
}

function Invoke-Task([string] $name, [scriptBlock] $task) {
    Clear-Error

    Write-TaskInfo $name

    $elapsed = Use-StopWatch($task)

    Test-Error

    Write-TaskDuration $name $elapsed.duration

    $result = New-TaskResult -name $name -duration $elapsed.format
    
    if ($null -eq $global:InvokedTasks){ $global:InvokedTasks = @() }
    $global:InvokedTasks += $result

    return $result
}

function Write-HashtableInfo([hashtable] $hashtable) {
    ($hashtable).GetEnumerator() | Sort-Object -Property Name | Format-Table -HideTableHeaders -AutoSize -Wrap | Out-Host
}

function Write-InvocationInfo {
    param(
        [System.Object] $Invocation
    )

    # allows more list properties to be displayed (default = 4)
    $global:FormatEnumerationLimit = 10

    Write-Host $Invocation.MyCommand.Name
    ($Invocation.BoundParameters).GetEnumerator() |
        Sort-Object -Property Key |
        Format-Table -HideTableHeaders -AutoSize -Wrap |
        Out-Host
}

function Write-ErrorAndThenExit([string] $message) { Write-Error $message; exit -1 }

function Write-Info([string] $message) { Write-Host $message -ForegroundColor Green }

Export-ModuleMember -function * -Alias *
