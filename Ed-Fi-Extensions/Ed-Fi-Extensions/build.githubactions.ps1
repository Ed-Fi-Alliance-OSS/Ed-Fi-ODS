# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

[CmdLetBinding()]
param(
    # Command to execute, defaults to "Build".
    [string]
    [ValidateSet("DotnetClean", "Restore", "Build", "Test", "Pack", "Publish", "CheckoutBranch", "MaximumPathLengthLimitation", "InstallCredentialHandler", "ExtensionVersions")]
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
    $TestFilter,

    [string]
    $NuspecFilePath,

    [string]
    $RelativeRepoPath,

    [string]
    $Copyright = "Copyright @ " + $((Get-Date).year) + " Ed-Fi Alliance, LLC and Contributors",

    [ValidateSet('4.0.0', '5.0.0')]
    [string]  $StandardVersion,

    [ValidateSet('1.0.0', '1.1.0')]
    [string]  $ExtensionVersion
)

$newRevision = ([int]$BuildCounter) + ([int]$BuildIncrementer)
$version = "$InformationalVersion.$newRevision"
$packageOutput = "$PSScriptRoot/NugetPackages"
$packagePath = "$packageOutput/$PackageName.$version.nupkg"

if ([string]::IsNullOrWhiteSpace($Solution)){
    $Solution =$ProjectFile
}

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

function DotnetClean {
    Invoke-Execute { dotnet clean $Solution -c $Configuration --nologo -v minimal }
}

function Restore {
    Invoke-Execute { dotnet restore  $Solution --verbosity:normal }
}

function Compile {
    Invoke-Execute {
        dotnet --info
        dotnet build $Solution -c $Configuration --version-suffix $version --no-restore -p:StandardVersion=$StandardVersion
    }
}

function Pack {
    if ([string]::IsNullOrWhiteSpace($PackageName) -and [string]::IsNullOrWhiteSpace($NuspecFilePath)){
        Invoke-Execute {
            dotnet pack $ProjectFile -c $Configuration --output $packageOutput --no-build --no-restore --verbosity normal -p:VersionPrefix=$version -p:NoWarn=NU5123
        }
    }
    if ($NuspecFilePath -Like "*.nuspec" -and $null -ne $PackageName ){

        Write-Host "Updating package id and description to $PackageName"

        $xml = [xml](Get-Content $NuspecFilePath)
        $xml.package.metadata.id = $PackageName
        $xml.package.metadata.description = $PackageName
        $xml.Save($NuspecFilePath)
        nuget pack $NuspecFilePath -OutputDirectory $packageOutput -Version $version -Properties configuration=$Configuration -Properties copyright=$Copyright -Properties standardversion=$StandardVersion -Properties extensionversion=$ExtensionVersion -NoPackageAnalysis -NoDefaultExcludes
        
    }
    if ([string]::IsNullOrWhiteSpace($NuspecFilePath) -and $null -ne $PackageName){
        Invoke-Execute {
            dotnet pack $ProjectFile -c $Configuration --output $packageOutput --no-build --no-restore --verbosity normal -p:VersionPrefix=$version -p:NoWarn=NU5123 -p:PackageId=$PackageName
        }
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
        Invoke-Execute { dotnet test $solution  -c $Configuration --no-build  --no-restore -v normal }
    } else {
        Invoke-Execute { dotnet test $solution  -c $Configuration --no-build  --no-restore -v normal --filter TestCategory!~"$TestFilter" }
    }
}

function CheckoutBranch {
    Set-Location $RelativeRepoPath
    $odsBranch = $Env:REPOSITORY_DISPATCH_BRANCH
    Write-Output "OdsBranch: $odsBranch"
    if($odsBranch -ne ''){
        $patternName = "refs/heads/$odsBranch"
        $does_corresponding_branch_exist = $false
        $does_corresponding_branch_exist = git ls-remote --heads origin $odsBranch | Select-String -Pattern $patternName -SimpleMatch -Quiet
        if ($does_corresponding_branch_exist -eq $true) {
            Write-Output "Corresponding branch for $odsBranch exists in Implementation repo, so checking it out"
            git fetch origin $odsBranch
            git checkout $odsBranch
        } else {
            Write-Output "Corresponding branch for $odsBranch does not exist in Implementation repo, so not changing branch checked out"
        }
    } else {
        Write-Output "ref_name: $Env:REF_NAME"
        $current_branch = "$Env:REF_NAME"
        if ($current_branch -like "*/merge"){
            Write-Output "ref_name is PR, so using head_ref: $Env:HEAD_REF"
            $current_branch = "$Env:HEAD_REF"
        }
        $patternName = "refs/heads/$current_branch"
        Write-Output "Pattern Name is $patternName" -fore GREEN
        $branch_exists = $false
        $branch_exists = git ls-remote --heads origin $current_branch | Select-String -Pattern $patternName -SimpleMatch -Quiet
        if ($branch_exists -eq $true) {
            Write-Output "Current branch exists, so setting to $current_branch"
            git fetch origin $current_branch
            git checkout $current_branch
        } else {
            Write-Output "did not match on any results for changing ODS checkout branch"
        }
    }
}

function MaximumPathLengthLimitation {

    $ErrorActionPreference = 'Stop'

    $error.Clear()

    & "$PSScriptRoot/../Ed-Fi-ODS-Implementation/logistics/scripts/modules/load-path-resolver.ps1"

    $pluginParentFolderPath = (Get-RepositoryResolvedPath "Plugin/")
    $extensionFolderName = $PackageName.Replace('EdFi.Suite3.Ods.','')
    $extensionFolderName = $extensionFolderName -replace "^.*?(Extensions\.[^\.]+).*", '$1'
    $desinationPath = "$pluginParentFolderPath/$extensionFolderName.zip"
    Copy-Item -Path $packagePath -Destination $desinationPath -Recurse -Force -PassThru
    if (Test-Path $desinationPath) {
      Expand-Archive -Force -Path $desinationPath -DestinationPath "$pluginParentFolderPath/$extensionFolderName/"
    }
    Remove-Item -Path $desinationPath -Force
    $baseRootPathLength = (Get-RepositoryRoot "Ed-Fi-ODS-Implementation").Length - ("Ed-Fi-ODS-Implementation".Length)
    $sqlFileNameValues = "";
    $isMaximumPathLengthFound = $false
    $message = "";

    Get-ChildItem -Path $pluginParentFolderPath -Recurse -Force -Filter "*.sql" | Sort-Object {($_.FullName.Length)} -Descending | ForEach-Object {
        $sqlFilePath = $_.FullName
        $sqlFileLength = ($_.FullName.Length) -($baseRootPathLength)
        $sqlFileLength = $sqlFileLength -as [int]
        $sqlFileName = Split-Path $sqlFilePath -leaf
        $maximumlength = 180

        if ($sqlFileLength -ge $maximumlength)
        {
            $isMaximumPathLengthFound = $true
            $sqlFileNameValues +=  $sqlFileName + "`r`n"
            $message += "Found plugin extension SQL file '$sqlFilePath' exceeds 180 characters full file path length,"
            $message += "So Windows Operating system don't allow due to Maximum Path Length Limitation."
            $message += "Please reduce length of SQL file name and retry.`r`n"
        }
    }
    if ($isMaximumPathLengthFound) {
        Write-Host $message -ForegroundColor Green
        throw "Found plugin extension SQL file names '$sqlFileNameValues' exceeds 180 characters full file path length."
    }
}

function InstallCredentialHandler {
         if (Get-IsWindows -and -not Get-InstalledModule | Where-Object -Property Name -eq "7Zip4Powershell") {
              Install-Module -Force -Scope CurrentUser -Name 7Zip4Powershell
         }
          # using WebClient is faster then Invoke-WebRequest but shows no progress
          $sourceUrl = ' https://github.com/microsoft/artifacts-credprovider/releases/download/v1.0.0/Microsoft.NuGet.CredentialProvider.zip'
          $fileName = 'Microsoft.NuGet.CredentialProvider.zip'
          $zipFilePath = Join-Path ([IO.Path]::GetTempPath()) $fileName
          Write-host "Downloading file from $sourceUrl..."
          $webClient = New-Object System.Net.WebClient
          $webClient.DownloadFile($sourceUrl, $zipFilePath)
          Write-host "Download complete." 
          if (-not (Test-Path $zipFilePath)) {
              Write-Warning "Microsoft.NuGet.CredentialProvider file '$fileName' not found."
              exit 0
          }
          $packageFolder = Join-Path ([IO.Path]::GetTempPath()) 'Microsoft.NuGet.CredentialProvider/'
          if ($fileName.EndsWith('.zip')) {
              Write-host "Extracting $fileName..."
              
              if (Test-Path $zipFilePath) { Expand-Archive -Force -Path $zipFilePath -DestinationPath $packageFolder }
              Copy-Item -Path $packageFolder\* -Destination "~/.nuget/" -Recurse -Force
              Write-Host "Extracted to: ~\.nuget\plugins\" -ForegroundColor Green
          }

}

function Get-IsWindows {
    <#
    .SYNOPSIS
        Checks to see if the current machine is a Windows machine.
    .EXAMPLE
        Get-IsWindows returns $True
    #>
    if ($null -eq $IsWindows) {
        # This section will only trigger when the automatic $IsWindows variable is not detected.
        # Every version of PS released on Linux contains this variable so it will always exist.
        # $IsWindows does not exist pre PS 6.
        return $true
    }
    return $IsWindows
}

function ExtensionVersions {

    $extensionProjectDirectory = Split-Path $Solution  -Resolve
    $extensionProjectPath = Join-Path $extensionProjectDirectory "/Versions/"
    $versions = (Get-ChildItem -Path $extensionProjectPath -Directory -Force -ErrorAction SilentlyContinue | Select -ExpandProperty Name | %{ "'" + $_ + "'" }) -Join ','
    $extensionVersions = "[$versions]"      
    return $extensionVersions
}

function Invoke-Build {
    Write-Host "Building Version $version" -ForegroundColor Cyan
    Invoke-Step { DotnetClean }
    Invoke-Step { Compile }
}

function Invoke-Restore {
    Invoke-Step { Restore }
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

function Invoke-CheckoutBranch {
    Invoke-Step { CheckoutBranch }
}

function Invoke-InstallCredentialHandler {
    Invoke-Step { InstallCredentialHandler }
}

function Invoke-MaximumPathLengthLimitation {
    Invoke-Step { MaximumPathLengthLimitation }
}

function Invoke-ExtensionVersions {
    Invoke-Step { ExtensionVersions }
}

Invoke-Main {
    switch ($Command) {
        DotnetClean { Invoke-DotnetClean }
        Restore { Invoke-Restore }
        Build { Invoke-Build }
        Test { Invoke-Tests }
        Pack { Invoke-Pack }
        Publish { Invoke-Publish }
        CheckoutBranch { Invoke-CheckoutBranch }
        MaximumPathLengthLimitation { Invoke-MaximumPathLengthLimitation }
        InstallCredentialHandler { Invoke-InstallCredentialHandler }
        ExtensionVersions { Invoke-ExtensionVersions }        
        default { throw "Command '$Command' is not recognized" }
    }
}