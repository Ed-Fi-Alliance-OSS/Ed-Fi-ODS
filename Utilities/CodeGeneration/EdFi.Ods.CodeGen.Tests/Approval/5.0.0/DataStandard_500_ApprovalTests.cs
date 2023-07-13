// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.CodeGen.Tests.Approval;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.Approval_Tests;

public class V500 : IStandardVersionMetadata
{
    public string StandardVersion => "5.0.0";

    public string ApprovalsFileNamePrefix => nameof(DataStandard_500_ApprovalTests);
}

[TestFixture]
public class DataStandard_500_ApprovalTests : ApprovalTestsBase<V500>
{
    // =========================================================================================
    [Test, Explicit("WARNING!!! This copies all the generated files as approved files")]
    public void Create_Approved_Files() => CreateApprovedFiles();
    // =========================================================================================

    [Test, TestCaseSource(typeof(ApprovalFileInfoSource<V500>))]
    public void Verify(ApprovalFileInfo approvalFileInfo) => ApproveFile(approvalFileInfo);

    [Test]
    public void Generated_File_List() => ApproveGeneratedFileList();
}
