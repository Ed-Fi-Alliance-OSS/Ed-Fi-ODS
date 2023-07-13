// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.CodeGen.Tests.Approval;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.Approval_Tests;

[UseReporter(typeof(DiffReporter), typeof(NUnitReporter), typeof(PowerShellClipboardReporter))]
public abstract class ApprovalTestsBase
{
    private readonly string _approvalsFileNamePrefix;
    private readonly string _standardVersion;
    private const string GeneratedCs = "*.generated.cs";
    private const string GeneratedHbm = "*.generated.hbm.xml";
    private const string GeneratedSql = "*_generated.sql";

    private readonly ICodeRepositoryProvider _codeRepositoryProvider = new DeveloperCodeRepositoryProvider();
    private readonly Lazy<string> _repositoryRoot;
    private readonly Lazy<string> _extensionRepository;
    private readonly Lazy<string> _extensionRepositoryExtensionsFolder;
    private readonly Lazy<string> _odsRepository;
    private readonly Lazy<string> _odsRepositoryProjects;

    private static Func<List<ApprovalFileInfo>> _getApprovalFileInfos;

    // private static IEnumerable<ApprovalFileInfo> _approvalFileInfos = GetApprovalFileInfos();

    protected ApprovalTestsBase(string approvalsFileNamePrefix, string standardVersion)
    {
        _approvalsFileNamePrefix = approvalsFileNamePrefix;
        _standardVersion = standardVersion;

        _repositoryRoot = new Lazy<string>(
            () => _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Root));

        _extensionRepository = new Lazy<string>(
            () => _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.ExtensionsRepositoryName));

        _extensionRepositoryExtensionsFolder =
            new Lazy<string>(() => Path.Combine(_extensionRepository.Value, CodeRepositoryConventions.Extensions));

        _odsRepository =
            new Lazy<string>(() => _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods));

        _odsRepositoryProjects =
            new Lazy<string>(() => Path.Combine(_odsRepository.Value, CodeRepositoryConventions.Application));

        _getApprovalFileInfos =
            () =>
            {
                var generatedFileList = Path.Combine(
                    _odsRepository.Value,
                    "Utilities",
                    "CodeGeneration",
                    "EdFi.Ods.CodeGen.Tests",
                    "Approval",
                    _standardVersion,
                    $"{_approvalsFileNamePrefix}.{nameof(Generated_File_List)}.Standard.{_standardVersion}.approved.txt");

                var files = File.ReadAllLines(generatedFileList)
                    .Select(x => new ApprovalFileInfo(Path.Combine(_repositoryRoot.Value, x), _odsRepository.Value, _extensionRepository.Value))
                    .ToList();

                return files;
            };
    }

    [Explicit("WARNING!!! This copies all the generated files as approved files")]
    [Test]
    public void Create_Approved_Files()
    {
        CopyFiles(GetApprovalFileInfos());
    }

    /// <summary>
    /// Runs CodeGen once before verification
    /// </summary>
    [OneTimeSetUp]
    protected async Task SetUp()
    {
        await Program.Main(
            new[]
            {
                "--ExtensionPaths",
                _extensionRepository.Value,
                "--ExtensionVersion",
                "1.1.0",
                "--StandardVersion",
                _standardVersion
            });
    }

    /// <summary>
    /// Creates approval file containing all known generated files needed for verification
    /// </summary>
    [Test]
    public void Generated_File_List()
    {
        var files = new List<string>();

        files.AddRange(Directory.GetFiles(_extensionRepositoryExtensionsFolder.Value, GeneratedCs, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_extensionRepositoryExtensionsFolder.Value, GeneratedHbm, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_odsRepositoryProjects.Value, GeneratedSql, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_odsRepositoryProjects.Value, GeneratedCs, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_odsRepositoryProjects.Value, GeneratedHbm, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));

        files.Sort();

        using (var cleanup = NamerFactory.AsEnvironmentSpecificTest($"Standard.{_standardVersion}"))
        {
            Approvals.Verify(
                string.Join('\n', files.Select(x => Path.GetRelativePath(_repositoryRoot.Value, x)))
                    .Replace('\\', '/') + '\n' // Unix uses forward slash directory separator and files are terminated with newline
            );
        }
    }

    /// <summary>
    /// Runs all the approval tests as separate tests. Note the method name has not changed as it
    /// requires that the approved files would be renamed.
    /// </summary>
    /// <param name="approvalFileInfo"></param>
    [Test, TestCaseSource(nameof(GetApprovalFileInfos))]
    public void Verify(ApprovalFileInfo approvalFileInfo)
    {
        Console.WriteLine("Testing {0}", approvalFileInfo.SourcePath);

        if (!File.Exists(approvalFileInfo.SourcePath))
        {
            Assert.Fail("No source file found");
        }

        // need to backup the file as the approval test deletes the original file
        File.Copy(approvalFileInfo.SourcePath, approvalFileInfo.SourcePath + ".bak", true);

        using (var _ = NamerFactory.AsEnvironmentSpecificTest($"{approvalFileInfo.Scenario}"))
        {
            Approvals.VerifyFile(approvalFileInfo.SourcePath);
        }

        if (File.Exists(approvalFileInfo.SourcePath + ".bak"))
        {
            // restore the backup
            File.Copy(approvalFileInfo.SourcePath + ".bak", approvalFileInfo.SourcePath, overwrite: true);
            File.Delete(approvalFileInfo.SourcePath + ".bak");
        }
    }

    private static List<ApprovalFileInfo> GetApprovalFileInfos()
    {
        return _getApprovalFileInfos();
    }

    private void CopyFiles(IEnumerable<ApprovalFileInfo> files)
    {
        foreach (var file in files)
        {
            string ext = Path.GetExtension(file.GeneratedName);

            if (file.SourcePath.ToLower().Contains("obj")
                || file.SourcePath.ToLower().Contains("bin")
                || string.IsNullOrEmpty(ext))
            {
                continue;
            }

            switch (ext.ToLower())
            {
                case ".cs":
                case ".xml":
                case ".sql":

                    string destFileName = Path.Combine(
                        _odsRepository.Value
                        , "Utilities", "CodeGeneration", "EdFi.Ods.CodeGen.Tests", "Approval", _standardVersion
                        , $"{_approvalsFileNamePrefix}.Verify.{file.Scenario}.approved{ext}");

                    System.Console.WriteLine("Copying file: {0} to {1}", file.SourcePath, destFileName);

                    File.Copy(file.SourcePath, destFileName, true);

                    break;
                default:
                    continue;
            }
        }
    }
}
