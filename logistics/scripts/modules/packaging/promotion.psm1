# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

function Get-AzurePackages {
    param(
        $FeedsURL
    )

    $uri = "$FeedsURL/packages?api-version=6.0-preview.1"
    $json = (Invoke-WebRequest -Uri $uri -UseBasicParsing).Content | ConvertFrom-Json

    $result = @{ }

    foreach ($value in $json.value) {
        $result.add(
            $value.normalizedName.ToLower().Trim(),
            $value.versions[0].version
        )
    }

    Write-Host "Found $($result.Count) azure packages at $uri."

    return $result
}

function Select-DotNetPackages {
    param (
        $Paths,
        $Pattern = '\s*>\s+(?<name>\S+)\s+(?<version>\d+\.\d+\.\d+-?\S*)'
    )

    $Paths | Out-Host
    $Pattern | Out-Host

    $result = @{ }

    foreach ($path in $Paths) {

        Write-Host -ForegroundColor Magenta "& dotnet restore `"$path`""
        $output = & dotnet restore "$path" | Out-Host

        Write-Host -ForegroundColor Magenta "& dotnet list `"$path`" package --include-transitive"
        $output = (& dotnet list "$path" package --include-transitive)

        $matches = [regex]::Matches($output, $Pattern)

        foreach ($match in $matches) {
            $normalizedName = $match.Groups['name'].ToString().ToLower().Trim()

            if (-not $result.ContainsKey($normalizedName)) {
                $result.add(
                    $normalizedName,
                    $match.Groups['version'].ToString()
                )
            }
        }
    }

    Write-Host "Found $($result.Count) dotnet packages at:"
    $Paths | Out-Host

    return $result
}

function Select-ConfigurationPackages {
    param (
        $configurationFile
    )

    $configuration = Get-Content $configurationFile | ConvertFrom-Json | ConvertTo-Hashtable

    $result = @{ }

    foreach ($key in $configuration.packages.Keys) { $result.add($configuration.packages[$key].PackageName.ToLower().Trim(), $configuration.packages[$key].PackageVersion) }

    Write-Host "Found $($result.Count) packages at $configurationFile."

    return $result
}

Function Invoke-PromotePackages {
    [cmdletbinding(SupportsShouldProcess)]
    param(
        [Parameter(Mandatory = $true)]
        $PackagesURL,

        [Parameter(Mandatory = $true)]
        $Username,

        [Parameter(Mandatory = $true)]
        [SecureString]$Password,

        [Parameter(Mandatory = $true)]
        $View,

        [Parameter(Mandatory = $true)]
        $Packages
    )

    $body = @{
        data      = @{
            viewId = $View
        }
        operation = 0
        packages  = @()
    }

    foreach ($key in $Packages.Keys) {
        $body.packages += @{
            id           = $key
            version      = $Packages[$key]
            protocolType = "NuGet"
        }
    }

    $parameters = @{
        Method      = "POST"
        ContentType = "application/json"
        Credential  = New-Object -TypeName PSCredential -ArgumentList $Username, $Password
        URI         = "$PackagesURL/nuget/packagesBatch?api-version=5.0-preview.1"
        Body        = ConvertTo-Json $Body -Depth 10
    }

    $parameters | Out-Host
    $parameters.URI | Out-Host
    $parameters.Body | Out-Host

    if ($PSCmdlet.ShouldProcess($PackagesURL)) {
        $response = Invoke-WebRequest @parameters
        $response | ConvertTo-Json -Depth 10 | Out-Host
    }

    Write-TeamCityBuildStatus "Packages promoted: $($Packages.Count)"
}
