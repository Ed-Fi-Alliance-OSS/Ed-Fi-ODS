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
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.Approval;

[UseReporter(typeof(DiffReporter), typeof(NUnitReporter), typeof(PowerShellClipboardReporter))]
public abstract class ApprovalTestsBase<TVersionMetadata>
    where TVersionMetadata : IStandardVersionMetadata, new()
{
    private readonly string _approvalsFileNamePrefix;
    private readonly string _standardVersion;
    private const string GeneratedCs = "*.generated.cs";
    private const string GeneratedHbm = "*.generated.hbm.xml";
    private const string GeneratedSql = "*_generated.sql";

    private readonly string _extensionRepositoryExtensionsFolder;
    private readonly string _odsRepositoryProjects;

    protected ApprovalTestsBase()
    {
        var metadata = new TVersionMetadata();

        _approvalsFileNamePrefix = metadata.ApprovalsFileNamePrefix;
        _standardVersion = metadata.StandardVersion;
        _extensionRepositoryExtensionsFolder = Path.Combine(ApprovalTestHelpers.ExtensionRepository, CodeRepositoryConventions.Extensions);
        _odsRepositoryProjects = Path.Combine(ApprovalTestHelpers.OdsRepository, CodeRepositoryConventions.Application);
    }

    protected void CreateApprovedFiles()
    {
        var files = new ApprovalFileInfoSource<TVersionMetadata>();
        CopyFiles(files.Cast<ApprovalFileInfo>());
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
                ApprovalTestHelpers.ExtensionRepository,
                "--ExtensionVersion",
                "1.1.0",
                "--StandardVersion",
                _standardVersion
            });
    }

    /// <summary>
    /// Creates approval file containing all known generated files needed for verification
    /// </summary>
    protected void ApproveGeneratedFileList()
    {
        var files = new List<string>();

        files.AddRange(Directory.GetFiles(_extensionRepositoryExtensionsFolder, GeneratedCs, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_extensionRepositoryExtensionsFolder, GeneratedHbm, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_odsRepositoryProjects, GeneratedSql, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_odsRepositoryProjects, GeneratedCs, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));
        files.AddRange(Directory.GetFiles(_odsRepositoryProjects, GeneratedHbm, SearchOption.AllDirectories).Where(filePath => filePath.Contains(_standardVersion)));

        files.Sort();

        using var cleanup = NamerFactory.AsEnvironmentSpecificTest($"Standard.{_standardVersion}");

        Approvals.Verify(
            string.Join('\n', files.Select(x => Path.GetRelativePath(ApprovalTestHelpers.RepositoryRoot, x)))
                .Replace('\\', '/') + '\n' // Unix uses forward slash directory separator and files are terminated with newline
        );
    }

    /// <summary>
    /// Runs all the approval tests as separate tests. Note the method name has not changed as it
    /// requires that the approved files would be renamed.
    /// </summary>
    /// <param name="approvalFileInfo"></param>
    protected void ApproveFile(ApprovalFileInfo approvalFileInfo)
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
                        ApprovalTestHelpers.OdsRepository
                        , "Utilities", "CodeGeneration", "EdFi.Ods.CodeGen.Tests", "Approval", _standardVersion
                        , $"{_approvalsFileNamePrefix}.Verify.{file.Scenario}.approved{ext}");

                    Console.WriteLine("Copying file: {0} to {1}", file.SourcePath, destFileName);

                    File.Copy(file.SourcePath, destFileName, true);

                    break;
                default:
                    continue;
            }
        }
    }
}
