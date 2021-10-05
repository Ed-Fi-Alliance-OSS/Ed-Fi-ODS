// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;

namespace EdFi.Ods.Api.IntegrationTests.PgSql
{
    public class PgSqlEducationOrganizationTests : EducationOrganizationTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class PgSqlSchoolTests : SchoolTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class PgSqlStaffUsiToEducationOrganizationIdAuthViewTests : StaffUsiToEducationOrganizationIdAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class PgSqlStudentUsiToEducationOrganizationIdAuthViewTests : StudentUsiToEducationOrganizationIdAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class PgSqlStudentUsiToEducationOrganizationIdThroughEdOrgAssociationAuthViewTests : StudentUsiToEducationOrganizationIdThroughEdOrgAssociationAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class PgSqlParentUsiToEducationOrganizationIdAuthViewTests : ParentUsiToEducationOrganizationIdAuthViewTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class PgSqlCommunityProviderTests : CommunityProviderTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }

    public class PgSqlOrganizationDepartmentTests : OrganizationDepartmentTests
    {
        protected override IDbConnection BuildTestConnection() => PgSqlTestsGlobalSetup.BuildConnection();
        protected override string TestFailedReason { get => PgSqlTestsGlobalSetup.TestFailedReason; }
        protected override string TestDisabledReason { get => PgSqlTestsGlobalSetup.TestDisabledReason; }
    }
}