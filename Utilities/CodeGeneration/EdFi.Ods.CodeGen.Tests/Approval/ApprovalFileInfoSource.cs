// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.IO;
using System.Linq;
using EdFi.Ods.CodeGen.Tests.Approval_Tests;

namespace EdFi.Ods.CodeGen.Tests.Approval;

public class ApprovalFileInfoSource<TVersionMetadata> : IEnumerable
    where TVersionMetadata : IStandardVersionMetadata, new()
{
    private TVersionMetadata _versionMetadata;

    public ApprovalFileInfoSource()
    {
        _versionMetadata = new TVersionMetadata();
    }

    public IEnumerator GetEnumerator()
    {
        var generatedFileList = Path.Combine(
            ApprovalTestHelpers.OdsRepository,
            "Utilities",
            "CodeGeneration",
            "EdFi.Ods.CodeGen.Tests",
            "Approval",
            _versionMetadata.StandardVersion,
            $"{_versionMetadata.ApprovalsFileNamePrefix}.Generated_File_List.Standard.{_versionMetadata.StandardVersion}.approved.txt");

        var files = File.ReadAllLines(generatedFileList)
            .Select(x => new ApprovalFileInfo(Path.Combine(ApprovalTestHelpers.RepositoryRoot, x), ApprovalTestHelpers.OdsRepository, ApprovalTestHelpers.ExtensionRepository))
            .ToList();

        foreach (var file in files)
        {
            yield return file;
        }
    }
}