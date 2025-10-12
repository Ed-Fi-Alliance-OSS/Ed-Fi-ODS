# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

[CmdLetBinding()]
param(
    # Command to execute, defaults to "Build".
    [string]
    [ValidateSet(
        "DotnetClean", 
        "Restore", 
        "Build", 
        "Test", 
        "Pack", 
        "Publish", 
        "CheckoutBranch", 
        "InstallCredentialHandler", 
        "StandardVersions", 
        "StandardTag", 
        "TpdmTag", 
        "TriggerImplementationRepositoryWorkflows")]
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

    [ValidateSet('4.0.0', '5.2.0', '6.0.0')]
    [string]  $StandardVersion

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
    if ($NuspecFilePath -Like "*.nuspec" -and $null -ne $PackageName){
 
        $xml = [xml](Get-Content $NuspecFilePath)
        $xml.package.metadata.id = $PackageName
        $xml.package.metadata.description = $PackageName
        $xml.Save($NuspecFilePath)

        $params = @{
            PackageDefinitionFile = $NuspecFilePath
            Version               = $version
            PackageId             = $PackageName
            OutputDirectory       = $packageOutput
            BuildConfiguration    = $Configuration
        }

        & "$PSScriptRoot//Initialize-PowershellForDevelopment.ps1"

        New-Package @params | Out-Host
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
        Invoke-Execute { dotnet test $solution  -c $Configuration --no-build --no-restore -v normal }
    } else {
        Invoke-Execute { dotnet test $solution  -c $Configuration --no-build --no-restore -v normal --filter TestCategory!~"$TestFilter" }
    }
}

function CheckoutBranch {
    Set-Location $RelativeRepoPath
    $odsBranch = $Env:REPOSITORY_DISPATCH_BRANCH
    Write-Output "OdsBranch: $odsBranch"
    if(![string]::IsNullOrEmpty($odsBranch)){
        $patternName = "refs/heads/$odsBranch"
        $does_corresponding_branch_exist = $false
        $does_corresponding_branch_exist = git ls-remote --heads origin $odsBranch | Select-String -Pattern $patternName -SimpleMatch -Quiet
        if ($does_corresponding_branch_exist -eq $true) {
            Write-Output "Corresponding branch for $odsBranch exists in $RelativeRepoPath repo, so checking it out"
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

function InstallCredentialHandler {

    # Does the same as: iex "& { $(irm https://aka.ms/install-artifacts-credprovider.ps1) }"
    # but this brings support for installing the provider on Linux.
    # Additionally, it's less likely to hit GitHub rate limits because this downloads it directly, instead of making a
    # request to https://api.github.com/repos/Microsoft/artifacts-credprovider/releases/latest to infer the latest version.

    $downloadPath = Join-Path ([IO.Path]::GetTempPath()) 'cred-provider.zip'
    
    $credProviderUrl = 'https://github.com/microsoft/artifacts-credprovider/releases/download/v1.4.1/Microsoft.Net6.NuGet.CredentialProvider.zip'
    Write-Host "Downloading artifacts-credprovider from $credProviderUrl ..."
    $webClient = New-Object System.Net.WebClient
    $webClient.DownloadFile($credProviderUrl, $downloadPath)
    Write-Host "Download complete." 

    if (-not (Test-Path $downloadPath)) {
        throw "'$downloadPath' not found."
    }

    # The provider should be installed in the path: ~/.nuget/plugins/netcore/CredentialProvider.Microsoft/<binaries>
    Write-Host "Extracting $downloadPath ..."
    Expand-Archive -Force -Path $downloadPath -DestinationPath '~/.nuget/'
    Write-Host "The artifacts-credprovider was successfully installed" -ForegroundColor Green
}

function StandardVersions {

    $standardProjectDirectory = Split-Path $Solution  -Resolve
    $standardProjectPath = Join-Path $standardProjectDirectory "/Standard/"
    $versions = (Get-ChildItem -Path $standardProjectPath -Directory -Force -ErrorAction SilentlyContinue | Select -ExpandProperty Name | %{ "'" + $_ + "'" }) -Join ','
    $standardVersions = "[$versions]"
    return $standardVersions
}

function StandardTag {

    if (-not $StandardVersion) {
        throw "StandardVersion is required."
    }
    return RepositoryTag('Ed-Fi-Standard')
}

function TpdmTag {

    if (-not $StandardVersion) {
        throw "StandardVersion is required."
    }
    return RepositoryTag('Ed-Fi-TPDM-Artifacts')
}

function RepositoryTag {
    param (
        [string]
        $Repository
    )

    $standardProjectDirectory = Split-Path $Solution  -Resolve
    $versionMapPath = Join-Path $standardProjectDirectory "/versionmap.json"
    $versionTag = (Get-Content $versionMapPath | ConvertFrom-Json).$Repository.$StandardVersion
    return $versionTag
}

function TriggerImplementationRepositoryWorkflows {
    <#
    .SYNOPSIS
        Searches for the corresponding PR in the Implementation repository; if found, 
        adds and removes a label to the PR, restarting all the PR workflows.
        Note that the workflows must be configured to be triggered by the `unlabeled` pull_request event type.
    #>
    
    Assert-EnvironmentVariablesInitialized(@("current_branch", "REPOSITORY_OWNER", "EDFI_ODS_IMP_TOKEN"))

    $headers = @{
        Authorization = "Bearer $Env:EDFI_ODS_IMP_TOKEN"
        Accept        = "application/vnd.github.v3+json"
    }
    $body = @{
        state = "open"
        head  = "${Env:REPOSITORY_OWNER}:${Env:current_branch}"
    }
    if ($Env:BASE_REF) {
        $body.Add('base', $Env:BASE_REF)
    }

    Write-Host "Looking for a PR in the Implementation repository with the next parameters=$($body | ConvertTo-Json)."

    $pr = Invoke-WebRequest `
        -Uri "https://api.github.com/repos/$Env:REPOSITORY_OWNER/Get-RepositoryRoot "Ed-Fi-ODS"/pulls" `
        -Body $body `
        -Headers $headers `
    | ConvertFrom-Json `
    | Select-Object -First 1

    if (-not $pr.number) {
        Write-Host "There's no matching PR."
        return
    }

    Write-Host "Triggering workflows in the matching PR: https://github.com/Ed-Fi-Alliance-OSS/Get-RepositoryRoot "Ed-Fi-ODS"/pull/$($pr.number)"

    $label = "Trigger from ODS repo"
    Invoke-WebRequest `
        -Method Post `
        -ContentType 'application/json' `
        -Uri "https://api.github.com/repos/Ed-Fi-Alliance-OSS/Get-RepositoryRoot "Ed-Fi-ODS"/issues/$($pr.number)/labels" `
        -Body @(@{labels = @($label) } | ConvertTo-Json) `
        -Headers $headers `
    | Out-Null
    
    Start-Sleep -Seconds 1
    
    Invoke-WebRequest `
        -Method Delete `
        -Uri "https://api.github.com/repos/Ed-Fi-Alliance-OSS/Get-RepositoryRoot "Ed-Fi-ODS"/issues/$($pr.number)/labels/$([uri]::EscapeDataString($label))" `
        -Headers $headers `
    | Out-Null

    Write-Output "EXIT_STEP=true">> $Env:GITHUB_ENV
}

function Assert-EnvironmentVariablesInitialized {
    param (
        [Parameter(Mandatory = $true)]
        [string[]]$Names
    )

    foreach ($name in $Names) {
        if (-not (Test-Path "Env:$name")) { 
            throw "The environment variable '$name' must be initialized."
        }
    }
}

function Invoke-Build {
    Write-Host "Building Version $version" -ForegroundColor Cyan
    Invoke-Step { DotnetClean }
    Invoke-Step { Compile }
}

function Invoke-DotnetClean {
    Invoke-Step { DotnetClean }
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

function Invoke-StandardVersions {
     Invoke-Step { StandardVersions }
}

function Invoke-StandardTag {
     Invoke-Step { StandardTag }
}

function Invoke-TpdmTag {
     Invoke-Step { TpdmTag }
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
        InstallCredentialHandler { Invoke-InstallCredentialHandler }
        StandardVersions { Invoke-StandardVersions }
        StandardTag { Invoke-StandardTag }
        TpdmTag { Invoke-TpdmTag }
        TriggerImplementationRepositoryWorkflows { TriggerImplementationRepositoryWorkflows }
        default { throw "Command '$Command' is not recognized" }
    }
}
