# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

#requires -module Pester -version 5

BeforeAll { Import-Module -Force -Scope Global ($PSCommandPath.Replace('.tests.ps1', '.psm1')) }

Describe 'Assert-ValidAppSettings' {
    It "returns successful when settings are valid" {
        $file = "TestDrive:\test.json"
        Set-Content $file -value '{ "object": { "array": [ 0, 1, 2 ] }, "property": "value" }'
        $result = Assert-ValidAppSettings $file

        $result | Should -Not -BeNullOrEmpty
        $result.success | Should -Be $true
    }

    It "returns unsuccessfully with exception when settings are invalid" {
        $file = "TestDrive:\test.json"
        Set-Content $file -value '{ "object": { "array": [ 0, 1, 2 ] }, "property": "value" }X'
        $result = Assert-ValidAppSettings $file

        $result | Should -Not -BeNullOrEmpty
        $result.success | Should -Be $false
        $result.exception | Should -Not -BeNullOrEmpty
    }

    It "returns unsuccessfully with exception when file is not found" {
        $result = Assert-ValidAppSettings "notFound.json"

        $result.success | Should -Be $false
        $result.exception | Should -Not -BeNullOrEmpty
    }

    It "returns results for multiple files" {
        $files = ("TestDrive:\test0.json", "TestDrive:\test1.json", "TestDrive:\test2.json")
        Set-Content $files[0] -value '{ "object": { "array": [ 0, 1, 2 ] }, "property": "value" }'
        Set-Content $files[1] -value '{ "object": { "array": [ 0, 1, 2 ] }, "property": "value" }X'
        Set-Content $files[2] -value '{ "object": { "array": [ 0, 1, 2 ] }, "property": "value" }'
        $result = Assert-ValidAppSettings $files

        $result[0].success | Should -Be $true
        $result[1].success | Should -Be $false
        $result[1].exception | Should -Not -BeNullOrEmpty
        $result[2].success | Should -Be $true
    }
}

Describe 'Get-FeatureSubTypesFromSettings' {
    It "returns a single known subtype" {
        $subtypes = Get-FeatureSubTypesFromSettings @{
            FeatureManagement = @{
                ChangeQueries = $true
            }
            ApiSettings = @{}
        }

        $subtypes | Should -Not -BeNullOrEmpty
        $subtypes | Should -Not -BeNullOrEmpty
        @($subtypes).Length | Should -Be 1
        $subtypes | Should -Be 'changes'
    }

    It "returns multiple known subtypes" {
        $subtypes = Get-FeatureSubTypesFromSettings @{
            FeatureManagement = @{
                ChangeQueries = $true
                OwnershipBasedAuthorization = $true
            }
            ApiSettings = @{}
        }

        $subtypes | Should -Not -BeNullOrEmpty
        @($subtypes).Length | Should -Be 2
        $subtypes | Should -Contain 'changes'
        $subtypes | Should -Contain 'RecordOwnership'
    }

    It "returns only known subtypes" {
        $subtypes = Get-FeatureSubTypesFromSettings @{
            FeatureManagement = @{
                ChangeQueries = $true
                OwnershipBasedAuthorization = $true
                Unknown = $true
            }
            ApiSettings = @{}
        }

        @($subtypes).Length | Should -Be 2
        $subtypes | Should -Not -BeNullOrEmpty
        $subtypes | Should -Contain 'changes'
        $subtypes | Should -Contain 'RecordOwnership'
    }

    It "returns only enabled subtypes" {
        $subtypes = Get-FeatureSubTypesFromSettings @{
            FeatureManagement = @{
                ChangeQueries = $false
                OwnershipBasedAuthorization = $true
            }
            ApiSettings = @{}
        }

        @($subtypes).Length | Should -Be 1
        $subtypes | Should -Not -BeNullOrEmpty
        $subtypes | Should -Contain 'RecordOwnership'
    }

    It "returns `$null if setting are not present" {
        $subtypes = Get-FeatureSubTypesFromSettings $null

        $subtypes | Should -BeNullOrEmpty
    }
}

Describe 'Get-EnabledFeaturesFromSettings' {
    It "returns all enabled features" {
        $features = Get-EnabledFeaturesFromSettings @{
            FeatureManagement = @{
                Extensions = $true
                Profiles = $false
                OpenApiMetadata = $true
            }
            ApiSettings = @{}
        }

        $features | Should -Not -BeNullOrEmpty
        @($features).Length | Should -Be 2
        $features | Should -contain 'Extensions'
        $features | Should -contain 'OpenApiMetadata'
    }

    It "returns no features if non are enabled" {
        $features = Get-EnabledFeaturesFromSettings @{
            FeatureManagement = @{
                Extensions = $false
                Profiles = $false
                OpenApiMetadata = $false
            }
            ApiSettings = @{}
        }

        $features | Should -BeNullOrEmpty
        @($features).Length | Should -Be 0
    }

    It "returns `$null if setting are not present" {
        $features = Get-EnabledFeaturesFromSettings $null

        $features | Should -BeNullOrEmpty
    }
}

Describe 'Get-MergedSettings' {
    It "returns merged settings from multiple files as a hashtable" {
        $appSettings = "TestDrive:\appSettings.json"
        Set-Content $appSettings -value '{ "object": { "array": [ 0, 1, 2 ] }, "property": "value" }'

        $developmentAppSettings =  "TestDrive:\appSettings.Development.json"
        Set-Content $developmentAppSettings -value '{ "object": { "array": [ 0 ], "newProperty": "value" }, "property": "newValue" }'

        $appSettingsFiles = @(
            $appSettings,
            $developmentAppSettings
        )
        $settings = Get-MergedAppSettings $appSettingsFiles ((Get-ProjectTypes).WebApi)

        $settings | Should -Not -BeNullOrEmpty
        $settings.object | Should -Not -BeNullOrEmpty
        $settings.object.array | Should -Not -BeNullOrEmpty
        $settings.object.array.Length | Should -Be 1
        $settings.property | Should -Not -BeNullOrEmpty
        $settings.property | Should -be 'newValue'
        $settings.object.newProperty | Should -Not -BeNullOrEmpty
    }
}

Describe 'Set-Feature' {
    It "returns a settings object with a new feature when the feature does not exist" {
        $appSettings = "TestDrive:\appSettings.json"
        Set-Content $appSettings -value '{ "FeatureManagement": { } }'

        $settings = Get-MergedAppSettings $appSettings
        $settings = Set-Feature -Settings $settings -FeatureName "NewFeature" -IsEnabled $true

        $settings | Should -Not -BeNullOrEmpty
        $settings.FeatureManagement | Should -Not -BeNullOrEmpty
        $settings.FeatureManagement.Keys.Count | Should -Be 1

        $featureEnabled = $settings.FeatureManagement.NewFeature

        $featureEnabled | Should -Not -BeNullOrEmpty
        $featureEnabled | Should -Be $true
    }

    It "returns a settings file with an updated feature" {
        $appSettings = "TestDrive:\appSettings.json"
        $settings = Set-Content $appSettings -value '{ "FeatureManagement": { "Feature": false } }'

        $settings = Get-MergedAppSettings $appSettings
        $settings = Set-Feature -Settings $settings -FeatureName "Feature" -IsEnabled $true

        $settings | Should -Not -BeNullOrEmpty
        $settings.FeatureManagement | Should -Not -BeNullOrEmpty
        $settings.FeatureManagement.Keys.Count | Should -Be 1

        $featureEnabled = $settings.FeatureManagement.Feature

        $featureEnabled | Should -Not -BeNullOrEmpty
        $featureEnabled | Should -Be $true
    }
}

Describe 'Update-DefaultDatabaseTemplate' {
    It "should update template defaults when switching engines from PostgreSQL to SQLServer" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'PostgreSQLMinimalTemplate'
                PopulatedTemplateScript = 'PostgreSQLPopulatedTemplate'
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'EdFiMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'GrandBend'
    }

    It "should update template defaults when switching engines from SQLServer to PostgreSQL" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'PostgreSQL'
                MinimalTemplateScript   = 'EdFiMinimalTemplate'
                PopulatedTemplateScript = 'GrandBend'
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'PostgreSQLMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'PostgreSQLPopulatedTemplate'
    }

    It "should update templates to grandbend when disabling tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'TPDMCoreMinimalTemplate'
                PopulatedTemplateScript = 'TPDMCorePopulatedTemplate'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @()
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'EdFiMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'GrandBend'
    }

    It "should update templates to grandbend when switching engines from PostgreSQL to SQLServer and disabling tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'TPDMCorePostgreSqlMinimalTemplate'
                PopulatedTemplateScript = 'TPDMCorePostgreSqlPopulatedTemplate'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @()
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'EdFiMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'GrandBend'
    }

    It "should update templates to grandbend when switching engines from SQLServer to PostgreSQL and disabling tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'PostgreSQL'
                MinimalTemplateScript   = 'TPDMCoreMinimalTemplate'
                PopulatedTemplateScript = 'TPDMCorePopulatedTemplate'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @()
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'PostgreSQLMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'PostgreSQLPopulatedTemplate'
    }

    It "should update template defaults when enabling tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'EdFiMinimalTemplate'
                PopulatedTemplateScript = 'GrandBend'
                StandardVersion = '5.2.0'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @("tpdm")
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'TPDMCoreMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'TPDMCorePopulatedTemplate'
    }

    It "should update template defaults when switching engines from SQLServer to PostgreSQL and enabling tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'PostgreSQL'
                MinimalTemplateScript   = 'EdFiMinimalTemplate'
                PopulatedTemplateScript = 'GrandBend'
                StandardVersion = '5.2.0'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @("tpdm")
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'TPDMCorePostgreSqlMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'TPDMCorePostgreSqlPopulatedTemplate'
    }

    It "should update template defaults when switching engines from PostgreSQL to SQLServer and enabling tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'PostgreSQLMinimalTemplate'
                PopulatedTemplateScript = 'PostgreSQLPopulatedTemplate'
                StandardVersion = '5.2.0'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @("tpdm")
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'TPDMCoreMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'TPDMCorePopulatedTemplate'
    }

    It "should not update if templates are not set to any of the defaults when enabling tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'SomeMinimal'
                PopulatedTemplateScript = 'SomePopulated'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @("tpdm")
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'SomeMinimal'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'SomePopulated'
    }

    It "should not update if templates are not set to any of the defaults when disabling  tpdm" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'SomeMinimal'
                PopulatedTemplateScript = 'SomePopulated'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @("")
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'SomeMinimal'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'SomePopulated'
    }

    It "should update template to grandbend when enabling tpdm and data standard is 6.0.0 or higher" {
        $settings = Update-DefaultDatabaseTemplate @{
            ApiSettings = @{
                StandardVersion = '6.0.0'
                Engine = 'SQLServer'
                MinimalTemplateScript   = 'TPDMCoreMinimalTemplate'
                PopulatedTemplateScript = 'TPDMCorePopulatedTemplate'
            }
            Plugin = @{
                Folder  = "../../Plugin"
                Scripts = @("tpdm")
            }
        }

        $settings.ApiSettings.MinimalTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.MinimalTemplateScript | Should -Be 'EdFiMinimalTemplate'
        $settings.ApiSettings.PopulatedTemplateScript | Should -Not -BeNullOrEmpty
        $settings.ApiSettings.PopulatedTemplateScript | Should -Be 'GrandBend'
    }
}