# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

[CmdLetBinding()]
param(
    # Command to execute, defaults to "Build".
    [string]
    [ValidateSet("Clean", "Build", "Test", "Pack", "Sign", "Publish")]
    $Command = "Build",

    [switch] $SelfContained,

    # Informational version number, defaults 1.0
    [string]
    $InformationalVersion = "1.0",

    # Build counter from the automation tool.
    [string]
    $BuildCounter = "1",

    [string]
    $BuildIncrementer = "0",

    # .NET project build configuration, defaults to "Release". Options are: Debug, Release.
    [string]
    [ValidateSet("Debug", "Release")]
    $Configuration = "Release",

    [bool]
    $DryRun = $false,

    [string]
    $NugetApiKey,

    [string]
    $EdFiNuGetFeed,

    # .Net Project Solution Name
    [string]
    $Solution,

    # .Net Project Name
    [string]
    $ProjectFile,

    [string]
    $PackageName,

    [string]
    $TestFilter

)

$newRevision = ([int]$BuildCounter) + ([int]$BuildIncrementer)
$version = "$InformationalVersion.$newRevision"
$packageOutput = "$PSScriptRoot/NugetPackages"
$packagePath = "$packageOutput/$PackageName.$version.nupkg"

function Invoke-Execute {
    param (
        [ScriptBlock]
        $Command,

        [switch]
        $ContainsPassword
    )

    $global:lastexitcode = 0
    & $Command

    if ($lastexitcode -ne 0) {
        $message = If ($ContainsPassword) { "The last command failed." } Else { "Error executing command: $Command" }
        throw $message
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
    Invoke-Execute { dotnet clean $Solution -c $Configuration --nologo -v minimal }
}

function Compile {
    Invoke-Execute {
        dotnet --info
        dotnet build $Solution -c $Configuration -p:AssemblyVersion=$version -p:FileVersion=$version -p:InformationalVersion=$InformationalVersion
    }
}

function Pack {
    if (-not $PackageName){
        Invoke-Execute {
            dotnet pack $ProjectFile -c $Configuration --output $packageOutput --no-build --verbosity normal -p:VersionPrefix=$version -p:NoWarn=NU5123
        }
    } else {
        Invoke-Execute {
            dotnet pack $ProjectFile -c $Configuration --output $packageOutput --no-build --verbosity normal -p:VersionPrefix=$version -p:NoWarn=NU5123 -p:PackageId=$PackageName
        }
    }
}

function Sign {
    # Base64-encoded .pfx. This is a self-signed certificate meant for testing purposes. 
    # The final .pfx will be stored in GitHub secrets and accessed through an env var
    $certificateString = "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"
    $certificateBytes = [System.Convert]::FromBase64String($certificateString)
    
    $certificatePath = "certificate.pfx"
    Set-Content $certificatePath -Value $certificateBytes -AsByteStream

    Try
    {
        Invoke-Execute {
        
            # The final password will be stored in GitHub secrets and accessed through an env var
            dotnet nuget sign $packagePath --certificate-path $certificatePath --certificate-password test123
    
        } -ContainsPassword
    }
    Finally
    {
        Remove-Item $certificatePath
    }
}

function Publish {
    Invoke-Execute {

        if (-not $NuGetApiKey) {
            throw "Cannot push a NuGet package without providing an API key in the `NuGetApiKey` argument."
        }

        if (-not $EdFiNuGetFeed) {
            throw "Cannot push a NuGet package without providing a feed in the `EdFiNuGetFeed` argument."
        }

        if($DryRun){
            Write-Host "Dry run enabled, not pushing package."
        } else {
            Write-Host "Pushing $packagePath to $EdFiNuGetFeed"

            dotnet nuget push $packagePath --api-key $NuGetApiKey --source $EdFiNuGetFeed
        }
    }
}

function Test {
    if(-not $TestFilter) {
        Invoke-Execute { dotnet test $solution  -c $Configuration --no-build -v normal }
    } else {
        Invoke-Execute { dotnet test $solution  -c $Configuration --no-build -v normal --filter TestCategory!~"$TestFilter" }
    }
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

function Invoke-Sign {
    Invoke-Step { Sign }
}

Invoke-Main {
    switch ($Command) {
        Clean { Invoke-Clean }
        Build { Invoke-Build }
        Test { Invoke-Tests }
        Pack { Invoke-Pack }
        Sign { Invoke-Sign }
        Publish { Invoke-Publish }
        default { throw "Command '$Command' is not recognized" }
    }
}