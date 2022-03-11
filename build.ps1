# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

[CmdLetBinding()]
param(
    # Command to execute, defaults to "Build".
    [string]
    [ValidateSet("Clean", "Build", "Test", "Pack", "Publish")]
    $Command = "Build",

    [switch] $SelfContained,

    # Informational version number, defaults 1.0
    [string]
    $InformationalVersion = "1.0",

    # Build counter from the automation tool.
    [string]
    $BuildCounter = "1",

    # .NET project build configuration, defaults to "Release". Options are: Debug, Release.
    [string]
    [ValidateSet("Debug", "Release")]
    $Configuration = "Release"
)

$solution = "Application/EdFi.Admin.DataAccess/EdFi.Admin.DataAccess.sln"
$projectFile = "Application/EdFi.Admin.DataAccess/EdFi.Admin.DataAccess.csproj"
$version = "$InformationalVersion.$BuildCounter"
$packageName = "EdFi.Suite3.Admin.DataAccess"
$packageOutput = "$PSScriptRoot/NugetPackages"
$packagePath = "$packageOutput/$packageName.$version.nupkg"

function Invoke-Execute {
    param (
        [ScriptBlock]
        $Command
    )

    $global:lastexitcode = 0
    & $Command

    if ($lastexitcode -ne 0) {
        throw "Error executing command: $Command"
    }
}

function Invoke-Step {
    param (
        [ScriptBlock]
        $block
    )

    $command = $block.ToString().Trim()

    Write-Host
    Write-Host $command -fore CYAN

    &$block
}

function Invoke-Main {
    param (
        [ScriptBlock]
        $MainBlock
    )

    try {
        &$MainBlock
        Write-Host
        Write-Host "Build Succeeded" -fore GREEN
        exit 0
    } catch [Exception] {
        Write-Host
        Write-Error $_.Exception.Message
        Write-Host
        Write-Error "Build Failed"
        exit 1
    }
}

function Clean {
    Invoke-Execute { dotnet clean $solution -c $Configuration --nologo -v minimal }
}

function Compile {
    Invoke-Execute {
        dotnet --info
        dotnet build $solution -c $Configuration -p:AssemblyVersion=$version -p:FileVersion=$version -p:InformationalVersion=$InformationalVersion
    }
}

function Pack {
    Invoke-Execute {
        dotnet pack $projectFile -c $Configuration --output $packageOutput --no-build --verbosity normal -p:VersionPrefix=$version -p:NoWarn=NU5123 -p:PackageId=$packageName
    }
}

function Publish {
    Invoke-Execute {
        dotnet nuget push $packagePath -s $env:AZURE_ARTIFACT_URL -k $env:AZURE_ARTIFACT_NUGET_KEY --force-english-output
    }
}

function Test {
    Invoke-Execute { dotnet test $solution  -c $Configuration --no-build -v normal }
}

function Invoke-Build {
    Write-Host "Building Version $version" -ForegroundColor Cyan
    Invoke-Step { Clean }
    Invoke-Step { Compile }
}

function Invoke-Publish {
    Invoke-Step { Publish }
}

function Invoke-Tests {
    Invoke-Step { Test }
}

function Invoke-Pack {
    Invoke-Step { Pack }
}

Invoke-Main {
    switch ($Command) {
        Clean { Invoke-Clean }
        Build { Invoke-Build }
        Test { Invoke-Tests }
        Pack { Invoke-Pack }
        Publish { Invoke-Publish }
        default { throw "Command '$Command' is not recognized" }
    }
}