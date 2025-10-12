Param (
    [Alias("p")]
    [Parameter(Mandatory=$true, Position=0, HelpMessage="The full or relative path to the XML security metadata/policy file to be processed.")]
    [string] $PolicyFileName,
    [Alias("o")]
    [Parameter(Mandatory=$false, Position=1, HelpMessage="The full or relative path for the output SQL script filename (defaults to same location as policy document).")]
    [string] $OutputFileName,
    [Alias("d")]
    [Parameter(Mandatory=$false, Position=2, HelpMessage="The database dialect for the generated SQL script (if not supplied, will detect using file path conventions for PgSql and MsSql).")]
    [ValidateSet('PostgreSql','SqlServer')]
    [string] $DatabaseEngine
)

$saxonVersion = "10.9.0"

Write-Host "Installing Saxon XSLT transformer (nuget)..."
Install-Package -Name Saxon-HE -RequiredVersion $saxonVersion -ProviderName NuGet -Verbose -Source https://www.nuget.org/api/v2

$transform_exe = Get-ChildItem "$env:ProgramFiles\PackageManagement\NuGet\Packages\Saxon-HE.$saxonVersion\tools\Transform.exe"

If (Test-Path $transform_exe) {
    If (-not [IO.Path]::IsPathRooted($PolicyFileName)) {
        $PolicyFileName = "$PSScriptRoot\$PolicyFileName"
    }

    if ([string]::IsNullOrEmpty($OutputFileName)) {
        $OutputFileName = [IO.Path]::ChangeExtension($PolicyFileName, "sql");
    }

    If (-not [IO.Path]::IsPathRooted($OutputFileName)) {
        $OutputFileName = "$PSScriptRoot\$OutputFileName"
    }

    if ([string]::IsNullOrEmpty($DatabaseEngine)) {
        if ($PolicyFileName.Contains("PgSql")) {
            $DatabaseEngine = "PostgreSql";
        } elseif ($PolicyFileName.Contains("MsSql")) {
            $DatabaseEngine = "SqlServer";
        }
    }

    $StylesheetFileName = "Xslt\Security-Metadata-SQL-Generator.xslt"

    Write-Host "Transforming '$PolicyFileName' using stylesheet for $DatabaseEngine into '$OutputFileName'..." -ForegroundColor Cyan
    . $transform_exe -im:$DatabaseEngine -s:"$PolicyFileName" -xsl:"$StylesheetFileName" -o:"$OutputFileName"
} else {
    Write-Host "Saxon XSLT transformer not found."
}
