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
    [Test, TestCaseSource(typeof(ApprovalFileInfoSource<V500>))]
    public override void Verify(ApprovalFileInfo approvalFileInfo) => base.Verify(approvalFileInfo);

    [Test]
    public override void Generated_File_List() => base.Generated_File_List();
}