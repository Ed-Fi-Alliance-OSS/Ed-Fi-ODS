# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

function ConvertTo-Hashtable {
    param(
        [Parameter(ValueFromPipeline = $true)]
        [PSObject] $Object
    )

    $result = @{ }

    $keys = $Object | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty Name

    foreach ($key in $keys) {
        if ($Object.$key -is [PSObject]) {
            $result[$key] = $Object.$key | ConvertTo-Hashtable
        }
        elseif ($Object.$key -is [Object[]]) {
            $result[$key] = @()
            for ($i = 0; $i -lt @($Object.$key).Count; $i++) {
                if ($Object.$key[$i] -is [PSObject]) {
                    $result[$key] += $Object.$key[$i] | ConvertTo-Hashtable
                } else {
                    $result[$key] += $Object.$key[$i]
                }
            }
        }
        else {
            $result[$key] = $Object.$key
        }
    }

    return $result
}

function Get-HashtableDeepClone {
    param(
        [Parameter(ValueFromPipeline = $true)]
        [Hashtable] $Hashtable
    )

    $result = @{ }

    foreach ($key in $Hashtable.Keys) {
        if ($Hashtable[$key] -is [Hashtable]) {
            $result[$key] = $Hashtable[$key] | Get-HashtableDeepClone
        }
        else {
            $result[$key] = $Hashtable[$key]
        }
    }

    return $result
}

$script:MergeWithDefault = { param($Key, $Left, $Right) return $Right[$Key] }

function Merge-HashtablesDeepRight {
    param(
        [Hashtable] $HashtableLeft,

        [Hashtable] $HashtableRight,

        [scriptblock] $MergeWith = $script:MergeWithDefault
    )

    $result = $HashtableLeft | Get-HashtableDeepClone

    foreach ($key in $HashtableRight.Keys) {
        if ($HashtableLeft[$key] -is [Hashtable] -and $HashtableRight[$key] -is [Hashtable]) {
            $result[$key] = (Merge-HashtablesDeepRight $HashtableLeft[$key] $HashtableRight[$key] $MergeWith)
        }
        else {
            $result[$key] = (& $MergeWith $key $HashtableLeft $HashtableRight)
        }
    }

    return $result
}

function Merge-Hashtables {
    param(
        [Hashtable[]] $Hashtables,

        [scriptblock] $MergeWith = $script:MergeWithDefault
    )

    $result = $Hashtables[0] | Get-HashtableDeepClone

    for ($i = 0; $i -lt @($Hashtables).Count; $i++) {
        $result = Merge-HashtablesDeepRight $result $Hashtables[$i + 1] $MergeWith
    }

    return $result
}

function Merge-HashtablesOrDefaults {
    param(
        [Hashtable[]] $Hashtables
    )

    $MergeWith = {
        param(
            $Key,

            $Left,

            $Right
        )

        if (-not ([string]::IsNullOrWhiteSpace($Left[$Key]))) { return $Left[$Key] }

        return (& $script:MergeWithDefault $Key $Left $Right)
    }

    return (Merge-Hashtables $Hashtables $MergeWith)
}

function Get-FlatHashtable {
    param(
        [hashtable] $Hashtable,

        [string] $Delimiter = ':'
    )

    $result = @{ }

    function Get-FlatObject {
        param(
            $Object,

            [string] $Name
        )

        if ($Object -is [Hashtable]) {
            foreach ($key in $Object.Keys) {
                Get-FlatObject $Object[$key] "$Name$key$Delimiter"
            }
        }
        elseif ($Object -is [Object[]]) {
            for ($i = 0; $i -lt @($Object).Count; $i++) {
                Get-FlatObject $Object[$i] "$Name$i$Delimiter"
            }
        }
        else {
            $result[$Name.Trim($Delimiter)] = $Object
        }
    }

    Get-FlatObject($Hashtable)

    return $result
}

function Write-FlatHashtable {
    param(
        [Parameter(ValueFromPipeline = $true)]
        [Hashtable] $Hashtable
    )

    (Get-FlatHashtable ($Hashtable)).GetEnumerator() |
        Sort-Object -Property Name |
        Format-Table -HideTableHeaders -AutoSize -Wrap |
        Out-Host
}

function Get-UnFlatObject {
    param(
        [string] $Key,

        $Value,

        $Object,

        [string] $Delimiter = ':'
    )

    $firstKey, $remainingKeys = ($Key -split $Delimiter, 2)

    if (-not $Object.ContainsKey($firstKey)) {
        $Object[$firstKey] = @{ }
    }

    if ($remainingKeys) {
        $Object[$firstKey] = Get-UnFlatObject $remainingKeys $Value $Object[$firstKey] $Delimiter
    }
    else {
        $Object[$firstKey] = $Value
    }

    return $Object
}

function Convert-HashtableToArray {
    param(
        [Parameter(ValueFromPipeline = $true)]
        $Hashtable
    )

    if ($null -eq $Hashtable -or 0 -eq $Hashtable.Keys.Count) { return $Hashtable }

    $result = $null

    $keysAsIntegers = ($Hashtable.Keys | ForEach-Object { $_ -as [int] }) | Sort-Object -Unique
    $isConsecutiveIntegers = ($keysAsIntegers.Count -eq $Hashtable.Keys.Count) -and ($null -eq (Compare-Object $keysAsIntegers @(0..$keysAsIntegers[-1])))

    if ($isConsecutiveIntegers) {
        $result = @()
        foreach ($key in $keysAsIntegers) {
            if ($Hashtable[$key -as [string]] -is [Hashtable]) {
                $result += ($Hashtable[$key -as [string]] | Convert-HashtableToArray)
            }
            else {
                $result += $Hashtable[$key -as [string]]
            }
        }
    }
    else {
        $result = $Hashtable | Get-HashtableDeepClone
        foreach ($key in $Hashtable.Keys) {
            if ($Hashtable[$key] -is [Hashtable]) {
                $result[$key] = $Hashtable[$key] | Convert-HashtableToArray
            }
            else {
                $result[$key] = $Hashtable[$key]
            }
        }
    }

    return $result
}

function Get-UnFlatHashtable {
    param(
        [Hashtable] $Hashtable
    )

    $result = @{ }

    foreach ($key in $Hashtable.Keys) {
        $result = Get-UnFlatObject $key $Hashtable[$key] $result
    }

    return Convert-HashtableToArray($result)
}

Export-ModuleMember -Function *
