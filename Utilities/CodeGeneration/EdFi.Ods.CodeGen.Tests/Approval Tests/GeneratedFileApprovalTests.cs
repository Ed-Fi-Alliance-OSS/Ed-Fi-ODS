// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.Approval_Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter), typeof(NUnitReporter), typeof(PowerShellClipboardReporter))]
    public class GeneratedFileApprovalTests
    {
        private const string GeneratedCs = "*.generated.cs";
        private const string GeneratedHbm = "*.generated.hbm.xml";
        private const string GeneratedSql = "*_generated.sql";

        private static readonly ICodeRepositoryProvider _codeRepositoryProvider = new DeveloperCodeRepositoryProvider();
        private static readonly IEnumerable<ApprovalFileInfo> ApprovalFileInfos = GetApprovalFileInfos();

        [Explicit("WARNING!!! This copies all the generated files as approved files")]
        [Test]
        public void Create_Approved_Files()
        {
            CopyFiles(GetApprovalFileInfos());
        }

        /// <summary>
        /// Runs all the approval tests as separate tests. Note the method name has not changed as it
        /// requires that the approved files would be renamed.
        /// </summary>
        /// <param name="approvalFileInfo"></param>
        [Explicit("Run this test after codegen has been run.")]
        [Test, TestCaseSource(nameof(ApprovalFileInfos))]
        public void Verify_All(ApprovalFileInfo approvalFileInfo)
        {
            System.Console.WriteLine("Testing {0}", approvalFileInfo.SourcePath);

            if (!File.Exists(approvalFileInfo.SourcePath))
            {
                Assert.Fail("No source file found");
            }

            // need to backup the file as the approval test deletes the original file
            File.Copy(approvalFileInfo.SourcePath, approvalFileInfo.SourcePath + ".bak", true);

            using (ApprovalResults.ForScenario(approvalFileInfo.Scenario))
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
            var approvalFileInfos = new List<ApprovalFileInfo>();

            approvalFileInfos.AddRange(
                GetGeneratedFiles(Path.Combine(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.ExtensionsFolderName), @"Extensions"), GeneratedCs));

            approvalFileInfos.AddRange(
                GetGeneratedFiles(Path.Combine(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.ExtensionsFolderName), @"Extensions"), GeneratedHbm));

            approvalFileInfos.AddRange(
                GetGeneratedFiles(Path.Combine(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods), @"Application"), GeneratedCs));

            approvalFileInfos.AddRange(
                GetGeneratedFiles(Path.Combine(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods), @"Application"), GeneratedHbm));

            approvalFileInfos.AddRange(
                GetGeneratedFiles(Path.Combine(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods), @"Artifacts"), GeneratedSql));

            return approvalFileInfos;
        }

        private static IEnumerable<ApprovalFileInfo> GetGeneratedFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories)
                            .Select(x => new ApprovalFileInfo(x));
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
                            _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods)
                          , @"Utilities\CodeGeneration\EdFi.Ods.CodeGen.Tests\Approval Tests"
                          , $"GeneratedFileApprovalTests.Verify_All.ForScenario.{file.Scenario}.approved{ext}");

                        System.Console.WriteLine("Copying file: {0} to {1}", file.SourcePath, destFileName);

                        File.Copy(file.SourcePath, destFileName, true);

                        break;
                    default:
                        continue;
                }
            }
        }

        public class ApprovalFileInfo
        {
            public ApprovalFileInfo(string sourcePath)
            {
                SourcePath = sourcePath;
                Scenario = $"{CreateScenario(sourcePath)}";
                GeneratedName = sourcePath.Split('\\').LastOrDefault();
            }

            public string SourcePath { get; }

            public string GeneratedName { get; }

            public string Scenario { get; }

            private string CreateScenario(string sourcePath)
            {
                var ext = Path.GetExtension(sourcePath);

                string generatedFileName = sourcePath.Contains(CodeRepositoryConventions.ExtensionsFolderName)
                    ? sourcePath.Replace(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.ExtensionsFolderName), string.Empty).Replace("\\", "_")
                    : sourcePath.Replace(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods), string.Empty).Replace("\\", "_");

                return generatedFileName.Replace("_Application_", string.Empty)
                                        .Replace("_Extensions_", string.Empty)
                                        .Replace("_Database_", string.Empty)
                                        .Replace(ext, string.Empty)
                                        .Replace("EdFi.Ods.", string.Empty);
            }

            public override string ToString() => Scenario;
        }
    }
}
