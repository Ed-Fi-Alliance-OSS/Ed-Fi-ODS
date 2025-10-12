# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.


$ErrorActionPreference = "Stop"

& "$PSScriptRoot/../../../logistics/scripts/modules/load-path-resolver.ps1"
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath "logistics/scripts/modules/tasks/TaskHelper.psm1")
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/packaging/restore-packages.psm1')
Import-Module -Force -Scope Global (Get-RepositoryResolvedPath 'logistics/scripts/modules/settings/settings-management.psm1')

function Invoke-BuildLoadTools {
    param(
        [hashtable] $config
    )

    $buildConfiguration = $config.buildConfiguration
    $solutionPath = $config.loadToolsSolution
    $verbosity = "minimal"

    if (-not [string]::IsNullOrWhiteSpace($env:msbuild_buildConfiguration)) { $buildConfiguration = $env:msbuild_buildConfiguration }


    $params = @{
        Path               = $solutionPath
        BuildConfiguration = $buildConfiguration
        LogVerbosityLevel  = $verbosity
    }

    ($params).GetEnumerator() | Sort-Object -Property Name | Format-Table -HideTableHeaders -AutoSize -Wrap | Out-Host

    $BuildLogDirectoryPath = (Get-Location)

    $solutionFileName = (Get-ItemProperty -LiteralPath $solutionPath).Name
    $buildLogFilePath = (Join-Path -Path $BuildLogDirectoryPath -ChildPath $solutionFileName) + ".msbuild.log"

    dotnet build $solutionPath -c $buildConfiguration -v $verbosity /flp:v=$verbosity /flp:logfile=$buildLogFilePath | Out-Host

     # If we can't find the build's log file in order to inspect it, write a warning and return null.
     if (!(Test-Path -LiteralPath $buildLogFilePath -PathType Leaf)) {
        Write-Warning ("Cannot find the build log file at '$buildLogFilePath', so unable to determine if build succeeded or not.")
        return
    }

    # Get if the build succeeded or not.
    [bool] $buildFailed = (Select-String -Path $buildLogFilePath -Pattern "Build FAILED." -SimpleMatch -Quiet)

    if ($buildFailed) {
        throw "Build failed. Check the build log file '$buildLogFilePath' for errors."
    }

    return
}

function Invoke-SmokeTestClient {
    param(
        [hashtable] $config
    )

    Write-HashtableInfo $config

    $smokeTestExecutableOrDll = (Get-ChildItem -Recurse $config.smokeTestExecutable).FullName
    $smokeTestSdkDll = (Get-ChildItem -Recurse $config.smokeTestDll).FullName
    $testSetDependsOnSdk = ($config.testSets -contains 'NonDestructiveSdk') -or ($config.testSets -contains 'DestructiveSdk')

    if (-not (Test-Path $smokeTestExecutableOrDll)) { throw [System.IO.FileNotFoundException] "$smokeTestExecutableOrDll not found." }

    if ([string]::IsNullOrWhiteSpace($config.apiUrlBase)) {throw "apiUrlBase is required"}
    if ([string]::IsNullOrWhiteSpace($config.apiKey)) { throw "apiKey is required" }
    if ([string]::IsNullOrWhiteSpace($config.apiSecret)) { throw "apiSecret is required" }
    if ([string]::IsNullOrWhiteSpace($config.apiYear)) { $config.apiYear = [string]::Empty }

    if ([string]::IsNullOrWhiteSpace($config.apiNamespaceUri)) { $config.apiNamespaceUri = "uri://ed-fi.org/" }

    if ($testSetDependsOnSdk -and -not (Test-Path $smokeTestSdkDll)) { throw [System.IO.FileNotFoundException]  "$smokeTestSdkDll not found." }

    foreach ($testSet in $config.testSets) {
        $params = @(
            '-b', ('"{0}"' -f $config.apiUrlBase),
            '-k', ('"{0}"' -f $config.apiKey),
            '-s', ('"{0}"' -f $config.apiSecret),
            '-n', ('"{0}"' -f $config.apiNamespaceUri),
            '-t', ('"{0}"' -f $testSet)
        )

        if ($config.apiYear) {
            $params += '-y'
            $params += ('"{0}"' -f $config.apiYear)
         }
        if ($testSetDependsOnSdk) {
            $params += '-l'
            $params += ('"{0}"' -f $smokeTestSdkDll)
        }


        if ($smokeTestExecutableOrDll.EndsWith('.dll')) {
            Write-Host -ForegroundColor Magenta "& dotnet $smokeTestExecutableOrDll $params"
            & dotnet $smokeTestExecutableOrDll $params
        } else {
            $params = ($params -join " ")
            Write-Host -ForegroundColor Magenta $smokeTestExecutableOrDll $params
            $exitCode = (Start-Process -FilePath $smokeTestExecutableOrDll -ArgumentList $params -NoNewWindow -PassThru -Wait).ExitCode
            if ($exitCode -gt 0) { throw "$testSet exited with an error" }
        }

        Test-Error
    }
}

function Invoke-BulkLoadClient {
    param(
        [hashtable] $config
    )

    Write-HashtableInfo $config

    $apiKey = $config.apiKey
    $apiSecret = $config.apiSecret
    $apiBaseUrl = $config.apiUrlBase
    $apiYear = $config.apiYear
    $bulkLoadConnectionLimit = $config.bulkLoadConnectionLimit
    $bulkLoadDirectoryData = $config.bulkLoadDirectoryData
    $bulkLoadDirectoryMetadata = $config.bulkLoadDirectoryMetadata -replace '\\', '/'
    $bulkLoadDirectoryWorking = $config.bulkLoadDirectoryWorking -replace '\\', '/'
    $bulkLoadForceReloadMetadata = $config.bulkLoadForceReloadMetadata
    $bulkLoadMaxRequests = $config.bulkLoadMaxRequests
    $BulkLoadNoXmlValidation = $config.BulkLoadNoXmlValidation
    $bulkLoadRetries = $config.bulkLoadRetries
    $bulkLoadTaskCapacity = $config.bulkLoadTaskCapacity

    $params = @()
    if (-not [string]::IsNullOrWhiteSpace($apiKey)) { $params += "-k", $apiKey }
    if (-not [string]::IsNullOrWhiteSpace($apiSecret)) { $params += "-s", $apiSecret }
    if (-not [string]::IsNullOrWhiteSpace($apiBaseUrl)) { $params += "-b", $apiBaseUrl }
    if (-not [string]::IsNullOrWhiteSpace($apiYear)) { $params += "-y", $apiYear }
    if (-not [string]::IsNullOrWhiteSpace($bulkLoadConnectionLimit)) { $params += "-c", $bulkLoadConnectionLimit }
    if (-not [string]::IsNullOrWhiteSpace($bulkLoadDirectoryData)) { $params += "-d", "`"$bulkLoadDirectoryData`"" }
    if (-not [string]::IsNullOrWhiteSpace($bulkLoadDirectoryMetadata)) { $params += "-i", "`"$bulkLoadDirectoryMetadata`"" }
    if (-not [string]::IsNullOrWhiteSpace($bulkLoadDirectoryWorking)) { $params += "-w", "`"$bulkLoadDirectoryWorking`"" }
    if ($bulkLoadForceReloadMetadata) { $params += "-f" }
    if (-not [string]::IsNullOrWhiteSpace($bulkLoadMaxRequests)) { $params += "-l", $bulkLoadMaxRequests }
    if ($BulkLoadNoXmlValidation) { $params += "-n" }
    if (-not [string]::IsNullOrWhiteSpace($bulkLoadRetries)) { $params += "-r", $bulkLoadRetries }
    if (-not [string]::IsNullOrWhiteSpace($bulkLoadTaskCapacity)) { $params += "-t", $bulkLoadTaskCapacity }

    $executable = (Get-ChildItem -Recurse $config.bulkLoadClientExecutable).FullName

    Write-Host -ForegroundColor Magenta $executable $params
    $exitCode = (Start-Process -FilePath $executable -ArgumentList $params -NoNewWindow -PassThru -Wait).ExitCode

    Test-Error
    if ($exitCode -gt 0) { throw "BulkLoadClient exited with non-zero exit code" }
}

function Get-RandomString {
    Param(
        [int] $length = 20
    )
    return ([char[]]([char]65..[char]90) + ([char[]]([char]97..[char]122)) + 0..9 | Sort-Object { Get-Random })[0..$length] -join ""
}

function Invoke-SetTestHarnessConfig {
    param(
        [hashtable] $config
    )

    $settings = $config.appSettings

    if ($config.noExtensions)
    {
        $settings = Set-Feature -Settings $settings -FeatureName "Extensions" -IsEnabled $false
    }

    New-JsonFile $config.appSettingsFiles[-1] $settings -Overwrite
}

Export-ModuleMember -function Add-RandomKeySecret,
Get-RandomString,
Invoke-BulkLoadClient,
Invoke-SmokeTestClient,
Invoke-BuildLoadTools,
Invoke-SetTestHarnessConfig  -Alias *
