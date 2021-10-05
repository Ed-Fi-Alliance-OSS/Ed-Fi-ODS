// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;

namespace EdFi.Ods.Api.IntegrationTests.MsSql
{
    public class MsSqlEducationOrganizationTests : EducationOrganizationTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class MsSqlSchoolTests : SchoolTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class MsSqlStaffUsiToEducationOrganizationIdAuthViewTests : StaffUsiToEducationOrganizationIdAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class MsSqlStudentUsiToEducationOrganizationIdAuthViewTests : StudentUsiToEducationOrganizationIdAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class MsSqlStudentUsiToEducationOrganizationIdThroughEdOrgAssociationAuthViewTests : StudentUsiToEducationOrganizationIdThroughEdOrgAssociationAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class MsSqlParentUsiToEducationOrganizationIdAuthViewTests : ParentUsiToEducationOrganizationIdAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class MsSqlCommunityProviderTests : CommunityProviderTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class MsSqlOrganizationDepartmentTests : OrganizationDepartmentTests
    {
        protected override IDbConnection BuildTestConnection() => MsSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => MsSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => MsSqlTestsGlobalSetup.TestDisabledReason; }
    }
}
