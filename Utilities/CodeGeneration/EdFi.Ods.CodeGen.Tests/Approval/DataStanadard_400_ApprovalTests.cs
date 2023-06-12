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
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.Approval_Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter), typeof(NUnitReporter), typeof(PowerShellClipboardReporter))]
    public class DataStanadard_400_ApprovalTests
    {
        private const string StandardVersion = "4.0.0";
        private const string GeneratedCs = "*.generated.cs";
        private const string GeneratedHbm = "*.generated.hbm.xml";
        private const string GeneratedSql = "*_generated.sql";

        private static readonly ICodeRepositoryProvider _codeRepositoryProvider = new DeveloperCodeRepositoryProvider();
        private static readonly string _repositoryRoot =
            _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Root);
        private static readonly string _extensionRepository =
            _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.ExtensionsRepositoryName);
        private static readonly string _extensionRepositoryExtensionsFolder =
            Path.Combine(_extensionRepository, CodeRepositoryConventions.Extensions);
        private static readonly string _odsRepository =
            _codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods);
        private static readonly string _odsRepositoryProjects = Path.Combine(
            _odsRepository, CodeRepositoryConventions.Application);

        private static IEnumerable<ApprovalFileInfo> _approvalFileInfos = GetApprovalFileInfos();

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
                    _extensionRepository,
                    "--ExtensionVersion",
                    "1.1.0",
                    "--StandardVersion",
                    StandardVersion
                });
        }

        /// <summary>
        /// Creates approval file containing all known generated files needed for verification
        /// </summary>
        [Test]
        public void Generated_File_List()
        {
            var files = new List<string>();

            files.AddRange(Directory.GetFiles(_extensionRepositoryExtensionsFolder, GeneratedCs, SearchOption.AllDirectories));
            files.AddRange(Directory.GetFiles(_extensionRepositoryExtensionsFolder, GeneratedHbm, SearchOption.AllDirectories));
            files.AddRange(Directory.GetFiles(_odsRepositoryProjects, GeneratedSql, SearchOption.AllDirectories));
            files.AddRange(Directory.GetFiles(_odsRepositoryProjects, GeneratedCs, SearchOption.AllDirectories));
            files.AddRange(Directory.GetFiles(_odsRepositoryProjects, GeneratedHbm, SearchOption.AllDirectories));

            files.Sort();

            using (var cleanup = NamerFactory.AsEnvironmentSpecificTest($"Standard.{StandardVersion}"))
            {
                Approvals.Verify(
                    string.Join('\n', files.Select(x => Path.GetRelativePath(_repositoryRoot, x)))
                          .Replace('\\', '/') + '\n' // Unix uses forward slash directory separator and files are terminated with newline
                );
            }
        }

        /// <summary>
        /// Runs all the approval tests as separate tests. Note the method name has not changed as it
        /// requires that the approved files would be renamed.
        /// </summary>
        /// <param name="approvalFileInfo"></param>
        [Test, TestCaseSource(nameof(_approvalFileInfos))]
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
            var generatedFileList = Path.Combine(
                _odsRepository,
                "Utilities", "CodeGeneration", "EdFi.Ods.CodeGen.Tests", "Approval", $"{nameof(DataStanadard_400_ApprovalTests)}.{nameof(Generated_File_List)}.Standard.{StandardVersion}.approved.txt");

            var files = File.ReadAllLines(generatedFileList)
                .Select(x => new ApprovalFileInfo(Path.Combine(_repositoryRoot, x)))
                .ToList();

            return files;
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
                            _odsRepository
                            , "Utilities", "CodeGeneration", "EdFi.Ods.CodeGen.Tests", "Approval"
                            , $"ApprovalTests.Verify.{file.Scenario}.approved{ext}");

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
                SourcePath = sourcePath.Replace("\\", "/");
                Scenario = $"{CreateScenario(sourcePath)}";
                GeneratedName = sourcePath.Split("/").LastOrDefault();
            }

            public string SourcePath { get; }

            public string GeneratedName { get; }

            public string Scenario { get; }

            private string CreateScenario(string sourcePath)
                => sourcePath
                    .Replace(_extensionRepository, string.Empty)
                    .Replace(_odsRepository, string.Empty)
                    .Replace("/", "_")
                    .Replace("_Application_", string.Empty)
                    .Replace("_Extensions_", string.Empty)
                    .Replace("_Database_", string.Empty)
                    .Replace("_Versions_", ".")
                    .Replace("EdFi.Ods.", string.Empty)
                    .Replace("_Standard_", "_Std_")
                    .Replace(Path.GetExtension(sourcePath), string.Empty)
                    .Trim('_');

            public override string ToString() => Scenario;
        }
    }
}
