# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -module Pester -version 5

BeforeAll { Import-Module -Force -Scope Global ($PSCommandPath.Replace('.tests.ps1', '.psm1')) }

Describe 'ConvertTo-Hashtable' {
    It "converts object to hashtable" {
        $a = '{ "x": "0" }' | ConvertFrom-Json | ConvertTo-Hashtable

        $a | Should -BeOfType [System.Collections.Hashtable]
        $a.x | Should -Be '0'
    }

    It "converts nested objects to hashtable" {
        $a = '{ "x": { "y": "0" } }' | ConvertFrom-Json | ConvertTo-Hashtable

        $a | Should -BeOfType [System.Collections.Hashtable]
        $a.x | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y | Should -Be '0'
    }

    It "converts doubly nested objects to hashtable" {
        $a = '{ "x": { "y": { "z": 0 } } }' | ConvertFrom-Json | ConvertTo-Hashtable

        $a | Should -BeOfType [System.Collections.Hashtable]
        $a.x | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y.z | Should -Be '0'
    }

    It "converts arrays to hashtable" {
        $a = '{ "x": [ 0, 1, 2 ] }' | ConvertFrom-Json | ConvertTo-Hashtable

        $a | Should -Not -BeNullOrEmpty
        # Array of int and array of long are both valid types
        try { $a.x | Should -BeOfType [int] }
        catch { $a.x | Should -BeOfType [long] }
        $a.x[0] | Should -Be 0
        $a.x[1] | Should -Be 1
        $a.x[2] | Should -Be 2
    }

    It "converts nested arrays to hashtable" {
        $a = '{ "x": { "y": [ 0, 1, 2 ] } }' | ConvertFrom-Json | ConvertTo-Hashtable

        $a | Should -Not -BeNullOrEmpty
        $a.x | Should -BeOfType [System.Collections.Hashtable]
        # Array of int and array of long are both valid types
        try { $a.x.y | Should -BeOfType [int] }
        catch { $a.x.y | Should -BeOfType [long] }
        $a.x.y[0] | Should -Be 0
        $a.x.y[1] | Should -Be 1
        $a.x.y[2] | Should -Be 2
    }

    It "converts doubly nested arrays to hashtable" {
        $a = '{ "x": { "y": { "z": [ 0, 1, 2 ] } } }' | ConvertFrom-Json | ConvertTo-Hashtable

        $a | Should -Not -BeNullOrEmpty
        $a | Should -BeOfType [System.Collections.Hashtable]
        $a.x | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y | Should -BeOfType [System.Collections.Hashtable]
        # Array of int and array of long are both valid types
        try { $a.x.y.z | Should -BeOfType [int] }
        catch { $a.x.y.z | Should -BeOfType [long] }
        $a.x.y.z[0] | Should -Be 0
        $a.x.y.z[1] | Should -Be 1
        $a.x.y.z[2] | Should -Be 2
    }

    It "converts nested arrays of objects to hashtable" {
        $a = '{ "x": { "y": { "z": [ { "a": 1, "b": 2 }, { "c": 3, "d": 4 }, { "e": 5, "f": 6 } ] } } }' | ConvertFrom-Json | ConvertTo-Hashtable

        $a | Should -Not -BeNullOrEmpty
        $a.x | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y.z | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y.z[0] | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y.z[0].a | Should -Be 1
        $a.x.y.z[0].b | Should -Be 2
        $a.x.y.z[1] | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y.z[1].c | Should -Be 3
        $a.x.y.z[1].d | Should -Be 4
        $a.x.y.z[2] | Should -BeOfType [System.Collections.Hashtable]
        $a.x.y.z[2].e | Should -Be 5
        $a.x.y.z[2].f | Should -Be 6
    }
}

Describe 'Get-HashtableDeepClone' {
    It "creates a deep clone of a nested hashtable" {
        $a = @{ x = 0 }
        $b = @{ y = 1; z = $a }
        $result = $b | Get-HashtableDeepClone

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result | Should -Not -Be $b
        $result.z | Should -Not -Be $a

        $result.y | Should -Be 1
        $result.z | Should -BeOfType [System.Collections.Hashtable]
        $result.z.x | Should -Be 0
    }

    It "creates a deep clone of a doubly nested hashtable" {
        $a = @{ w = 0 }
        $b = @{ x = $a }
        $c = @{ y = 1; z = $b }
        $result = $c | Get-HashtableDeepClone

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result | Should -Not -Be $c
        $result.z | Should -Not -Be $b
        $result.z.x | Should -Not -Be $a

        $result.y | Should -Be 1
        $result.z | Should -BeOfType [System.Collections.Hashtable]
        $result.z.x | Should -BeOfType [System.Collections.Hashtable]
        $result.z.x.w | Should -Be 0
    }
}

Describe 'Merge-HashtablesDeepRight' {
    It "merges two hashtables into a new hashtable" {
        $a = @{ w = 0; x = 1; y = @{ z = 2 } }
        $b = @{ a = 3; b = 4; c = @{ d = 5 } }
        $result = Merge-HashtablesDeepRight $a $b

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.w | Should -Be 0
        $result.x | Should -Be 1
        $result.y | Should -BeOfType [System.Collections.Hashtable]
        $result.y.z | Should -Be 2
        $result.a | Should -Be 3
        $result.b | Should -Be 4
        $result.c | Should -BeOfType [System.Collections.Hashtable]
        $result.c.d | Should -Be 5
    }

    It "overrides properties in the first hastable with properties from the second hashtable" {
        $a = @{ a = @{ b = 0; c = 1 }; y = 2 }
        $b = @{ a = @{ b = 3; c = 4 }; z = 5 }
        $result = Merge-HashtablesDeepRight $a $b

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -BeOfType [System.Collections.Hashtable]
        $result.a.b | Should -Be 3
        $result.a.c | Should -Be 4
        $result.y | Should -Be 2
        $result.z | Should -Be 5
    }

    It "is non destructive" {
        $a = @{ a = 0; b = @{ c = 1 } }
        $b = @{ x = 2; b = @{ c = 3; d = 4 } }
        $result = Merge-HashtablesDeepRight $a $b

        $result | Should -Not -BeExactly $a
        $result.b | Should -Not -BeExactly $b.b

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -Be 0
        $result.b | Should -BeOfType [System.Collections.Hashtable]
        $result.b.c | Should -Be 3
        $result.x | Should -Be 2
        $result.b.d | Should -Be 4
    }

    It "does not merge arrays" {
        $a = @{ a = 0; b = @( 0, 1, 2 ) }
        $b = @{ x = 2; b = @( 3, 4, 5 ) }
        $result = Merge-HashtablesDeepRight $a $b

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -Be 0
        $result.b | Should -BeOfType [int]
        $result.b[0] | Should -Be 3
        $result.b[1] | Should -Be 4
        $result.b[2] | Should -Be 5
    }
}

Describe 'Merge-Hashtables' {
    It "merges multiple hashtables into a new hashtable" {
        $a = @{ a = 0; b = @{ c = 1 } }
        $b = @{ b = @{ c = 2; d = @{ e = 3 } }; f = 4 }
        $c = @{ b = @{ d = @{ e = 5; g = @{ h = 6 } } }; i = @{ j = 7 } }
        $d = @{ k = 8; i = @{ l = 9 } }
        $result = Merge-Hashtables $a, $b, $c, $d

        # @{ a = 0; b = @{ c = 2; d = @{ e = 5; g = @{ h = 6 } } }; i = @{ j = 7; l = 9 }; k = 8 }
        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -Be 0
        $result.b | Should -BeOfType [System.Collections.Hashtable]
        $result.b.c | Should -Be 2
        $result.b.d | Should -BeOfType [System.Collections.Hashtable]
        $result.b.d.e | Should -Be 5
        $result.b.d.g | Should -BeOfType [System.Collections.Hashtable]
        $result.b.d.g.h | Should -Be 6
        $result.i | Should -BeOfType [System.Collections.Hashtable]
        $result.i.j | Should -Be 7
        $result.i.l | Should -Be 9
        $result.k | Should -Be 8
    }
}

Describe 'Merge-HashtablesOrDefaults' {
    It "merges multiple hashtables into a new hashtable only if value is null or whitespace" {
        $a = @{ a = " "; b = "0"; c = "1"; d = @{ e = " "; f = "2"; g = "3" } }
        $b = @{ a = "4"; b = " "; c = "5"; d = @{ e = "6"; f = " "; g = "8" } }
        $result = Merge-HashtablesOrDefaults $a, $b

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -Be "4"
        $result.b | Should -Be "0"
        $result.c | Should -Be "1"
        $result.d.e | Should -Be "6"
        $result.d.f | Should -Be "2"
        $result.d.g | Should -Be "3"
    }
}

Describe 'Get-FlatHashtable' {
    It "merges multiple hashtables into a new hashtable" {
        $a = @{
            b = @{
                d = @{
                    e = @(0, 1, 2);
                    g = @{
                        h = @(@{ l = 3; m = @{ n = 4 } }, 5)
                    }
                }
            };
            i = @{
                j = 6
            };
            k = @(
                @{ l = 7; m = @{ n = 8 } }
                @{ o = 9; p = @{ q = 10 } }
            )
        }
        $result = Get-FlatHashtable $a

        $result['b:d:e:0'] | Should -Be 0
        $result['b:d:e:1'] | Should -Be 1
        $result['b:d:e:2'] | Should -Be 2
        $result['b:d:g:h:0:l'] | Should -Be 3
        $result['b:d:g:h:0:m:n'] | Should -Be 4
        $result['b:d:g:h:1'] | Should -Be 5
        $result['i:j'] | Should -Be 6
        $result['k:0:l'] | Should -Be 7
        $result['k:0:m:n'] | Should -Be 8
        $result['k:1:o'] | Should -Be 9
        $result['k:1:p:q'] | Should -Be 10
    }
}

Describe 'Get-UnFlatHashtable' {
    It "converts objects into a new un-flattened hashtable" {
        $a = @{
            'a:b:c'     = 'd'
            'a:b:e:f:g' = 'h'
        }

        $result = Get-UnFlatHashtable $a

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -BeOfType [System.Collections.Hashtable]
        $result.a.b | Should -BeOfType [System.Collections.Hashtable]
        $result.a.b.c | Should -Be 'd'
        $result.a.b.e | Should -BeOfType [System.Collections.Hashtable]
        $result.a.b.e.f | Should -BeOfType [System.Collections.Hashtable]
        $result.a.b.e.f.g | Should -Be 'h'

    }

    It "converts arrays into a new un-flattened hashtable" {
        $a = @{
            '0' = 3
            '1' = 4
            '2' = 5
        }

        $result = Get-UnFlatHashtable $a

        $result | Should -BeOfType [int]
        @($result).Length | Should -Be 3
        $result[0] | Should -Be 3
        $result[1] | Should -Be 4
        $result[2] | Should -Be 5
    }

    It "ignores hashtables that do not have keys with consecutive integers" {
        $a = @{
            'a:0' = 3
            'a:1' = 4
            'a:2' = 5
            'a:b:0' = 6
            'a:b:1' = 7
            'a:b:2' = 8
        }

        $result = Get-UnFlatHashtable $a

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -BeOfType [System.Collections.Hashtable]
        $result.a["0"] | Should -Be 3
        $result.a["1"] | Should -Be 4
        $result.a["2"] | Should -Be 5
        $result.a.b | Should -BeOfType [int]
        @($result.a.b).Length | Should -Be 3
        $result.a.b["0"] | Should -Be 6
        $result.a.b["1"] | Should -Be 7
        $result.a.b["2"] | Should -Be 8
    }

    It "converts arrays of hashtables into a new un-flattened hashtable" {
        $a = @{
            'a:0:b' = 3
            'a:1:b' = 4
            'a:2:b' = 5
            'a:3:b:c:0' = 6
            'a:3:b:c:1' = 7
            'a:3:b:c:2' = 8
        }

        $result = Get-UnFlatHashtable $a

        $result | Should -BeOfType [System.Collections.Hashtable]
        $result.a | Should -BeOfType [System.Collections.Hashtable]
        @($result.a).Length | Should -Be 4
        $result.a[0].b | Should -Be 3
        $result.a[1].b | Should -Be 4
        $result.a[2].b | Should -Be 5
        $result.a[3].b | Should -BeOfType [System.Collections.Hashtable]
        $result.a[3].b.c | Should -BeOfType [int]
        $result.a[3].b.c[0] | Should -Be 6
        $result.a[3].b.c[1] | Should -Be 7
        $result.a[3].b.c[2] | Should -Be 8
    }
}

Describe "Convert-HashtableToArray" {
    Context "converts a hashtable to an array" {
        It "returns the hashtable for an empty hashtable" {
            $a = @{}
            $result = Convert-HashtableToArray $a
            $result | Should -Be $a
            $result | Should -BeOfType [System.Collections.Hashtable]
        }

        It "returns null for an null hashtable" {
            $a = $null
            $result = Convert-HashtableToArray $a
            $result | Should -Be $a
        }
    }
}
