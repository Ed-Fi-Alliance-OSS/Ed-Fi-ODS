// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.Approval_Tests;

[TestFixture]
public class DataStandard_500_ApprovalTests : ApprovalTestsBase
{
    private const string StandardVersion = "5.0.0";

    public DataStandard_500_ApprovalTests() : base(nameof(DataStandard_500_ApprovalTests), StandardVersion) { }
}