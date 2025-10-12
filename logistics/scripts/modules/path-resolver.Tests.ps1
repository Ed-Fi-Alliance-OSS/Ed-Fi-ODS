BeforeAll { 
    Import-Module "$PSScriptRoot/utility/cross-platform.psm1"
    Import-Module -Force -Scope Global ($PSCommandPath.Replace('.tests.ps1', '.psm1'))
}
Describe 'Select-RepositoryResolvedFiles' {
    It 'Returns two valid and reachable paths' {
        $RepositoryFiles = Select-RepositoryResolvedFiles "logistics"
        Test-Path $RepositoryFiles.FullName | Should -Be ($true, $true)
    }
}
Describe 'Select-CumulativeRepositoryResolvedItems' {
    It 'Returns two valid and reachable paths' {
        $RepositoryFiles = Select-CumulativeRepositoryResolvedItems "logistics"
        Test-Path $RepositoryFiles.FullName | Should -Be ($true, $true)
    }
}

Describe 'Get-RootPath' {
    It 'Returns a valid and reachable Root path' {
        $getRootPath = Get-RootPath
        Test-Path $getRootPath.Path | Should -Be $true
    }
}
Describe 'Get-CorePath' {
    It 'Returns an ODS Core path' {
        $getCorePath = Get-CorePath
        Test-Path $getCorePath.Path | Should -Be $true
        $getCorePath.Path.TrimEnd([IO.Path]::DirectorySeparatorChar) | Should -BeLike "*Ed-Fi-ODS"
    }
}
Describe 'Get-RepositoryResolvedPath' {
    It 'Return paths to specified files, checking all repositories' {
        Get-RepositoryResolvedPath
    }
}
Describe 'Get-RepositoryRoot' {
    It 'Returns valid and reachable repository roots' {
        $getRepositoryRoot = Get-RepositoryRoot
        Test-Path $getRepositoryRoot[0] | Should -Be $true
        Test-Path $getRepositoryRoot[1] | Should -Be $true
    }
}
Describe 'Get-RepositoryNames' {
    It 'Returns the repositoryNames variable' {
        Get-RepositoryNames | Should -Not -BeNullOrEmpty
    }
}
