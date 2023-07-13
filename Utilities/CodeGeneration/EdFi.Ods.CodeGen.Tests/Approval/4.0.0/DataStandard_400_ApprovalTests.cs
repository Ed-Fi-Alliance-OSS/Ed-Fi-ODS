// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.CodeGen.Tests.Approval;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.Approval_Tests;

public class V400 : IVersionMetadata
{
    public string StandardVersion => "4.0.0";

    public string ApprovalsFileNamePrefix => nameof(DataStandard_400_ApprovalTests);
}

[TestFixture]
public class DataStandard_400_ApprovalTests : ApprovalTestsBase<V400>
{
    [Test, TestCaseSource(typeof(ApprovalFileInfos<V400>))]
    public override void Verify(ApprovalFileInfo approvalFileInfo) => base.Verify(approvalFileInfo);
    
    [Test]
    public override void Generated_File_List() => base.Generated_File_List();
}

