<#
.SYNOPSIS
    Merges Ed-Fi-Extensions into Ed-Fi-ODS on the current branch, preserving
    history, then moves the Extensions workflow files to .github/workflows/.

.DESCRIPTION
    Performs the following steps:

      0. Validates prerequisites (git, git-filter-repo).
      1. Rewrites Ed-Fi-Extensions history in-place so every file is rooted
         under the target subdirectory (Ed-Fi-Extensions/) via git-filter-repo.
         WARNING: this permanently rewrites the source repo history.
                  GitHub is the backup.
      2. Adds Ed-Fi-Extensions as a temporary remote in Ed-Fi-ODS.
      3. Fetches the rewritten branch.
      4. Merges into the currently checked-out branch with
         --allow-unrelated-histories (staged, not auto-committed by default).
      5. git-mv's the Extensions workflow files to top-level .github/workflows/.
      6. Removes the temporary remote.

    Run with -WhatIf to see every action without executing any of them.
    Run with -PauseBetweenSteps to confirm each step interactively.

.PARAMETER SourceRepo
    Absolute path to the local Ed-Fi-Extensions repo.
    Default: D:\repos\ed-fi\ed-fi-extensions

.PARAMETER TargetRepo
    Absolute path to the local Ed-Fi-ODS repo (the merge target).
    Default: D:\repos\ed-fi\Ed-Fi-ODS

.PARAMETER TargetSubdir
    Subdirectory name inside TargetRepo where source content will be placed.
    Default: Ed-Fi-Extensions

.PARAMETER SourceBranch
    Branch in the source repo to rewrite and merge.  Default: main

.PARAMETER RemoteName
    Temporary remote name added to TargetRepo.  Default: extensions-merge

.PARAMETER FilterRepoScript
    Path to git-filter-repo.py.  Defaults to git-filter-repo.py in TargetRepo.
    Pass 'standalone' to use git-filter-repo on PATH, or 'module' for pip install.

.PARAMETER SkipFilterRepo
    Skip the git-filter-repo rewrite (use if already done on the source repo).

.PARAMETER SkipMoveWorkflows
    Skip moving .github/workflows from the subdir into the top-level dir.

.PARAMETER AutoCommit
    Commit the merge automatically after staging.
    Default: leave staged for manual review.

.PARAMETER PauseBetweenSteps
    Prompt for confirmation before each step.

.PARAMETER WhatIf
    Show every action that would be taken without executing any of them.

.EXAMPLE
    # Full dry-run (nothing changes)
    .\tools\Invoke-ExtensionsMerge.ps1 -WhatIf

.EXAMPLE
    # Interactive -- pause before each step
    .\tools\Invoke-ExtensionsMerge.ps1 -PauseBetweenSteps

.EXAMPLE
    # Fully automated -- auto-commit the merge
    .\tools\Invoke-ExtensionsMerge.ps1 -AutoCommit

.EXAMPLE
    # Skip filter-repo if source repo has already been rewritten
    .\tools\Invoke-ExtensionsMerge.ps1 -SkipFilterRepo
#>
[CmdletBinding(SupportsShouldProcess)]
param(
    [string] $SourceRepo        = 'D:\repos\ed-fi\ed-fi-extensions',
    [string] $TargetRepo        = 'D:\repos\ed-fi\Ed-Fi-ODS',
    [string] $TargetSubdir      = 'Ed-Fi-Extensions',
    [string] $SourceBranch      = 'main',
    [string] $RemoteName        = 'extensions-merge',
    [string] $FilterRepoScript  = '',
    [switch] $SkipFilterRepo,
    [switch] $SkipMoveWorkflows,
    [switch] $AutoCommit,
    [switch] $PauseBetweenSteps
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------

$script:stepNumber = 0

function Write-Step {
    param([string]$Message)
    $script:stepNumber++
    Write-Host ''
    Write-Host ('=' * 60) -ForegroundColor Cyan
    Write-Host "  Step $($script:stepNumber): $Message" -ForegroundColor Cyan
    Write-Host ('=' * 60) -ForegroundColor Cyan
}

function Write-Info { param([string]$M) Write-Host "  [i] $M" -ForegroundColor White }
function Write-Ok   { param([string]$M) Write-Host "  [+] $M" -ForegroundColor Green }
function Write-Warn { param([string]$M) Write-Host "  [!] $M" -ForegroundColor Yellow }
function Write-Fail { param([string]$M) Write-Host "  [X] $M" -ForegroundColor Red }

function Get-Confirm {
    param([string]$Description)
    if ($PauseBetweenSteps -and -not $WhatIfPreference) {
        Write-Host ''
        $ans = Read-Host "  Proceed with: $Description? [Y/n]"
        if ($ans -match '^[Nn]') {
            Write-Warn 'Skipped by user.'
            return $false
        }
    }
    return $true
}

function Invoke-Git {
    param(
        [string]   $WorkDir,
        [string[]] $Arguments,
        [switch]   $PassThru,
        [switch]   $AllowFailure   # don't throw on non-zero exit
    )
    Write-Info "git $($Arguments -join ' ')"

    if ($WhatIfPreference) {
        Write-Info "[WhatIf] Would run in $WorkDir"
        return [pscustomobject]@{ Ok = $true; Output = '' }
    }

    $result = & git -C $WorkDir @Arguments 2>&1
    $ok = ($LASTEXITCODE -eq 0)
    $text = ($result | ForEach-Object { "$_" }) -join "`n"

    if ($PassThru -or $AllowFailure) {
        return [pscustomobject]@{ Ok = $ok; Output = $text }
    }

    $text -split "`n" | ForEach-Object { Write-Host "    $_" }

    if (-not $ok) {
        throw "git command failed (exit $LASTEXITCODE): git $($Arguments -join ' ')"
    }

    return [pscustomobject]@{ Ok = $true; Output = $text }
}

# ---------------------------------------------------------------------------
# Step 0 -- Validate prerequisites
# ---------------------------------------------------------------------------

Write-Step 'Validate prerequisites'

if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Write-Fail 'git not found on PATH.  Install Git for Windows first.'
    exit 1
}
Write-Ok "git: $(& git --version)"

$script:filterRepoExe    = $null
$script:filterRepoScript = $null

if ($SkipFilterRepo) {
    Write-Ok 'git-filter-repo check skipped (--SkipFilterRepo).'
}
elseif ($WhatIfPreference) {
    Write-Info '[WhatIf] Would verify git-filter-repo is available.'
    $script:filterRepoExe = 'script'
}
else {
    # Pre-scan: look for git-filter-repo script file in the target repo root
    # (both hyphen and underscore variants, with and without .py extension)
    $repoCandidates  = @('git-filter-repo.py', 'git_filter_repo.py', 'git-filter-repo', 'git_filter_repo')
    $repoFilterFound = $repoCandidates |
        ForEach-Object { Join-Path $TargetRepo $_ } |
        Where-Object   { Test-Path $_ } |
        Select-Object -First 1

    # 1) Explicit path supplied by caller
    if ($FilterRepoScript -ne '' -and $FilterRepoScript -notin @('standalone', 'module')) {
        $resolved = Resolve-Path $FilterRepoScript -ErrorAction SilentlyContinue
        if ($null -eq $resolved) {
            Write-Fail "FilterRepoScript not found: $FilterRepoScript"
            exit 1
        }
        $script:filterRepoExe    = 'script'
        $script:filterRepoScript = $resolved.Path
        Write-Ok "git-filter-repo (explicit script): $($script:filterRepoScript)"
    }
    # 2) Script file in the target repo root (checked-in copy)
    elseif ($FilterRepoScript -eq '' -and $null -ne $repoFilterFound) {
        $script:filterRepoExe    = 'script'
        $script:filterRepoScript = $repoFilterFound
        Write-Ok "git-filter-repo (repo script): $($script:filterRepoScript)"
    }
    # 3) Standalone binary on PATH
    elseif ($FilterRepoScript -eq 'standalone' -or (Get-Command git-filter-repo -ErrorAction SilentlyContinue)) {
        $script:filterRepoExe = 'standalone'
        Write-Ok "git-filter-repo (standalone): $(& git-filter-repo --version 2>&1)"
    }
    # 4) Pip-installed Python module
    else {
        $savedPref  = $ErrorActionPreference
        $ErrorActionPreference = 'SilentlyContinue'
        $frVer      = & python -m git_filter_repo --version 2>&1
        $frExitCode = $LASTEXITCODE
        $ErrorActionPreference = $savedPref

        if ($frExitCode -eq 0) {
            $script:filterRepoExe = 'module'
            Write-Ok "git-filter-repo (python module): $($frVer -join ' ')"
        }
        else {
            Write-Fail 'git-filter-repo not found.  Options:'
            Write-Fail "  1. Place git-filter-repo.py in: $TargetRepo"
            Write-Fail '  2. Install via pip:  pip install git-filter-repo'
            Write-Fail '  3. See https://github.com/newren/git-filter-repo'
            exit 1
        }
    }
}

foreach ($p in @($SourceRepo, $TargetRepo)) {
    if (-not (Test-Path (Join-Path $p '.git'))) {
        Write-Fail "Not a git repository: $p"
        exit 1
    }
}
Write-Ok "Source repo : $SourceRepo"
Write-Ok "Target repo : $TargetRepo"

# Show current branch in target
$currentBranchR = Invoke-Git $TargetRepo @('rev-parse', '--abbrev-ref', 'HEAD') -PassThru
$currentBranch  = $currentBranchR.Output.Trim()
Write-Ok "Current branch in target: $currentBranch  (merge will land here)"

$statusR = Invoke-Git $TargetRepo @('status', '--porcelain') -PassThru
if ($statusR.Ok -and $statusR.Output.Trim() -ne '') {
    Write-Warn 'Target repo has uncommitted changes.  Consider stashing first.'
    if ($PauseBetweenSteps -and -not $WhatIfPreference) {
        $ans = Read-Host '  Continue anyway? [y/N]'
        if ($ans -notmatch '^[Yy]') { exit 1 }
    }
}

# ---------------------------------------------------------------------------
# Step 1 -- Rewrite source repo history into subdirectory (in-place)
# ---------------------------------------------------------------------------

Write-Step "Rewrite Ed-Fi-Extensions history in-place: all files under '$TargetSubdir/'"

if ($SkipFilterRepo) {
    Write-Ok 'Skipping git-filter-repo (--SkipFilterRepo specified).'
}
else {
    Write-Warn "This permanently rewrites '$SourceRepo' history."
    Write-Warn 'GitHub is the backup.  Proceeding...'

    if (Get-Confirm "python git-filter-repo.py --to-subdirectory-filter $TargetSubdir (in $SourceRepo)") {
        $frArgs = @(
            '--refs', "refs/heads/$SourceBranch",
            '--to-subdirectory-filter', $TargetSubdir,
            '--force'
        )

        if ($WhatIfPreference) {
            $label = if ($script:filterRepoScript) { $script:filterRepoScript } else { 'git-filter-repo' }
            Write-Info "[WhatIf] Would run in $SourceRepo :"
            Write-Info "  python '$label' $($frArgs -join ' ')"
        }
        else {
            Push-Location $SourceRepo
            try {
                switch ($script:filterRepoExe) {
                    'script'   { & python $script:filterRepoScript @frArgs }
                    'module'   { & python -m git_filter_repo @frArgs }
                    default    { & git-filter-repo @frArgs }
                }
                if ($LASTEXITCODE -ne 0) {
                    throw "git-filter-repo failed (exit $LASTEXITCODE)."
                }
            }
            finally {
                Pop-Location
            }
        }

        Write-Ok 'History rewritten.  Verifying root tree...'
        $treeR = Invoke-Git $SourceRepo @('ls-tree', '--name-only', 'HEAD') -PassThru
        if ($treeR.Ok) {
            Write-Info "Root entries now in source repo (should be '$TargetSubdir' only):"
            $treeR.Output -split "`n" | Where-Object { $_ } | ForEach-Object { Write-Info "  $_" }
        }
    }
}

# ---------------------------------------------------------------------------
# Step 2 -- Add temporary remote in target repo
# ---------------------------------------------------------------------------

Write-Step "Add temporary remote '$RemoteName' pointing to $SourceRepo"

$existingR = Invoke-Git $TargetRepo @('remote', 'get-url', $RemoteName) -PassThru -AllowFailure
if ($existingR.Ok) {
    Write-Warn "Remote '$RemoteName' already exists -- removing it first."
    if (Get-Confirm "git remote remove $RemoteName") {
        $null = Invoke-Git $TargetRepo @('remote', 'remove', $RemoteName)
    }
}

if (Get-Confirm "git remote add $RemoteName $SourceRepo") {
    $null = Invoke-Git $TargetRepo @('remote', 'add', $RemoteName, $SourceRepo)
    Write-Ok "Remote '$RemoteName' added -> $SourceRepo"
}

# ---------------------------------------------------------------------------
# Step 3 -- Fetch the rewritten branch
# ---------------------------------------------------------------------------

Write-Step "Fetch '$SourceBranch' from '$RemoteName'"

if (Get-Confirm "git fetch $RemoteName") {
    $null = Invoke-Git $TargetRepo @('fetch', $RemoteName)
    Write-Ok "Fetched $RemoteName/$SourceBranch"

    Write-Info 'Recent commits arriving from Ed-Fi-Extensions (newest first):'
    $logR = Invoke-Git $TargetRepo @('log', '--oneline', '-10', "$RemoteName/$SourceBranch") -PassThru
    if ($logR.Ok) {
        $logR.Output -split "`n" | Where-Object { $_ } | ForEach-Object { Write-Info "  $_" }
    }
}

# ---------------------------------------------------------------------------
# Step 4 -- Merge into current branch
# ---------------------------------------------------------------------------

Write-Step "Merge Ed-Fi-Extensions into current branch '$currentBranch'"

if (Get-Confirm "git merge --allow-unrelated-histories --no-commit $RemoteName/$SourceBranch") {
    Write-Info 'Merging (--no-commit so you can inspect before committing)...'
    $mergeArgs = @(
        'merge',
        '--allow-unrelated-histories',
        '--no-commit',
        '--no-ff',
        "$RemoteName/$SourceBranch"
    )

    if ($WhatIfPreference) {
        Write-Info "[WhatIf] Would run: git merge --allow-unrelated-histories --no-commit --no-ff $RemoteName/$SourceBranch"
    }
    else {
        $mergeR = Invoke-Git $TargetRepo $mergeArgs -PassThru -AllowFailure
        if (-not $mergeR.Ok -and $mergeR.Output -match 'CONFLICT') {
            Write-Warn 'Merge conflicts detected -- resolve them before committing:'
            $conflictR = Invoke-Git $TargetRepo @('diff', '--name-only', '--diff-filter=U') -PassThru
            $conflictR.Output -split "`n" | Where-Object { $_ } | ForEach-Object { Write-Warn "  CONFLICT: $_" }
        }
        elseif (-not $mergeR.Ok) {
            $mergeR.Output -split "`n" | ForEach-Object { Write-Info "  $_" }
            throw "git merge failed."
        }
        else {
            Write-Ok 'Merge staged.  No conflicts.'
        }
    }

    Write-Info 'Staged files preview (first 20):'
    $diffR = Invoke-Git $TargetRepo @('diff', '--name-status', '--cached') -PassThru
    if ($diffR.Ok) {
        $diffR.Output -split "`n" | Where-Object { $_ } | Select-Object -First 20 |
            ForEach-Object { Write-Info "  $_" }
    }
}

# ---------------------------------------------------------------------------
# Step 5 -- Move Extensions workflow files to top-level .github/workflows/
# ---------------------------------------------------------------------------

Write-Step "Move Ed-Fi-Extensions workflow files to top-level .github/workflows/"

if ($SkipMoveWorkflows) {
    Write-Ok 'Skipping workflow move (--SkipMoveWorkflows specified).'
}
else {
    # Enumerate workflow files from the git index (works before commit)
    $wfR = Invoke-Git $TargetRepo @('ls-files', '--cached', "$TargetSubdir/.github/workflows/") -PassThru
    $indexedWorkflows = $wfR.Output -split "`n" | Where-Object { $_ -match '\.yml$' }

    if (@($indexedWorkflows).Count -eq 0) {
        Write-Warn "No .yml files found in $TargetSubdir/.github/workflows/ in the index."
        Write-Warn 'They may already have been moved, or the merge has not staged them yet.'
    }
    else {
        Write-Info 'Workflow files to move:'
        $indexedWorkflows | ForEach-Object { Write-Info "  $_" }

        foreach ($srcPath in $indexedWorkflows) {
            $fileName  = Split-Path $srcPath -Leaf
            $destPath  = ".github/workflows/$fileName"
            $absTarget = Join-Path $TargetRepo $destPath

            if ((Test-Path $absTarget) -and -not $WhatIfPreference) {
                Write-Warn "Collision: $destPath already exists in Ed-Fi-ODS."
                Write-Warn '  Inspect both files manually; skipping git-mv for this file.'
                continue
            }

            if (Get-Confirm "git mv $srcPath -> $destPath") {
                $null = Invoke-Git $TargetRepo @('mv', $srcPath, $destPath)
                Write-Ok "Moved: $srcPath -> $destPath"
            }
        }

        $remainR = Invoke-Git $TargetRepo @('ls-files', '--cached', "$TargetSubdir/.github/") -PassThru
        if ($remainR.Output.Trim() -eq '') {
            Write-Ok "$TargetSubdir/.github/ is now empty in the index."
        }
        else {
            Write-Warn "$TargetSubdir/.github/ still has staged files (review manually):"
            $remainR.Output -split "`n" | Where-Object { $_ } | ForEach-Object { Write-Warn "  $_" }
        }
    }
}

# ---------------------------------------------------------------------------
# Step 6 -- Commit or prompt
# ---------------------------------------------------------------------------

Write-Step 'Commit merge or leave staged for manual review'

$commitMsg = @"
Merge Ed-Fi-Extensions into subdirectory '$TargetSubdir' (preserve history)

Content from Ed-Fi-Alliance-OSS/Ed-Fi-Extensions (main branch, 235 commits)
has been merged into the '$TargetSubdir/' subdirectory of this repository.

History was preserved using:
  python git-filter-repo.py --to-subdirectory-filter $TargetSubdir

Workflow files moved from $TargetSubdir/.github/workflows/ to .github/workflows/.

Remaining TODO:
  - Update Find Standard and Extension Versions.yml: remove checkout steps
  - Update Pkg EdFi.Ods.CodeGen.yml: remove checkout steps
  - Update Rebuild Database Templates.yml: repo references and API URLs
  - Add working-directory to moved Pkg *.yml workflow steps
  - Compare Directory.Packages.props and NuGet.Config from both repos
"@

if ($AutoCommit) {
    if (Get-Confirm 'git commit') {
        if ($WhatIfPreference) {
            Write-Info '[WhatIf] Would run: git commit'
            $commitMsg -split "`n" | ForEach-Object { Write-Info "  $_" }
        }
        else {
            $tmpMsg = [System.IO.Path]::GetTempFileName()
            Set-Content -Path $tmpMsg -Value $commitMsg -Encoding UTF8
            & git -C $TargetRepo commit --file $tmpMsg
            if ($LASTEXITCODE -ne 0) { throw 'git commit failed.' }
            Remove-Item $tmpMsg -ErrorAction SilentlyContinue
            Write-Ok 'Merge committed.'
        }
    }
}
else {
    Write-Host ''
    Write-Host '  The merge is staged but NOT committed.' -ForegroundColor Yellow
    Write-Host '  Review with:' -ForegroundColor Yellow
    Write-Host "      git -C '$TargetRepo' status" -ForegroundColor White
    Write-Host "      git -C '$TargetRepo' diff --cached --stat" -ForegroundColor White
    Write-Host '  Then commit with:' -ForegroundColor Yellow
    Write-Host "      git -C '$TargetRepo' commit" -ForegroundColor White
    Write-Host ''
    Write-Host '  Suggested commit message:' -ForegroundColor Cyan
    $commitMsg -split "`n" | ForEach-Object { Write-Host "    $_" }
}

# ---------------------------------------------------------------------------
# Step 7 -- Remove temporary remote
# ---------------------------------------------------------------------------

Write-Step "Remove temporary remote '$RemoteName'"

if (Get-Confirm "git remote remove $RemoteName") {
    $null = Invoke-Git $TargetRepo @('remote', 'remove', $RemoteName)
    Write-Ok "Remote '$RemoteName' removed."
}

# ---------------------------------------------------------------------------
# Done
# ---------------------------------------------------------------------------

Write-Host ''
Write-Host ('=' * 60) -ForegroundColor Green
Write-Host '  Merge script complete.' -ForegroundColor Green
Write-Host ('=' * 60) -ForegroundColor Green
Write-Host ''
Write-Host '  Next steps:' -ForegroundColor Cyan
Write-Host '  1. Resolve any remaining conflicts (git status).'
Write-Host '  2. Review staged changes:  git diff --cached --stat'
Write-Host '  3. Commit if not already done.'
Write-Host '  4. Update CI/workflow files per plan:'
Write-Host '       .github/prompts/plan-edFiExtensionsMerge.prompt.md'
Write-Host '  5. Push and open a PR.'
Write-Host ''
