// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Linq;

namespace EdFi.Ods.CodeGen.Tests.Approval
{
    public class ApprovalFileInfo
    {
        private readonly string _odsRepository;
        private readonly string _extensionRepository;

        public ApprovalFileInfo(string sourcePath, string odsRepository, string extensionRepository)
        {
            _odsRepository = odsRepository;
            _extensionRepository = extensionRepository;
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
