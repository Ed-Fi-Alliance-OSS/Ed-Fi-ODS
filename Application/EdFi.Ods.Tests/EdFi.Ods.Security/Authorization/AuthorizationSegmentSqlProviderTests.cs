// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Security.Utilities;
using FakeItEasy;
using NHibernate;
using Npgsql;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
{
    [TestFixture]
    public class AuthorizationSegmentsSqlProviderTests
    {
        private const int SuppliedLea1 = 780;
        private const int SuppliedLea2 = 880;
        private const int SuppliedLea3 = 980;

        private const int SuppliedPostSecondaryInstitutionId = 111;

        private static RelationshipsAuthorizationContextData _suppliedAuthorizationContext;
        private static EdFiResourceClaimValue _suppliedClaim;
        private static readonly List<int> AllSuppliedLeaIds = new List<int>
        {
            SuppliedLea1,
            SuppliedLea2,
            SuppliedLea3
        };

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_StaffUSI
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationViewsProvider = A.Fake<AuthorizationViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationViewsProvider.GetAuthorizationViews())
                    .Returns(new List<string>
                    {
                        "auth.LocalEducationAgencyIdToStaffUSI",
                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    AllSuppliedLeaIds,
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),

                    // 2 parameters are the SQL Server TVP and the StaffUSI segment
                    () => result.Parameters.Length.ShouldBe(2),

                    () => result.Parameters.Any(x => x.GetType() != typeof(SqlParameter))
                            .ShouldBeFalse(),

                    // TVP parameters is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[0].Value).Rows[0][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[0]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[1][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[1]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[2][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[2]),

                    // Second parameter is for the LEA to StaffUSI segment
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI)
                );

                var sql = result.Sql;

                var expectedSql =
$@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToStaffUSI a WHERE a.LocalEducationAgencyId IN (SELECT Id from @p0) and a.StaffUSI = @p1)
);";

                sql.ShouldBe(expectedSql, StringCompareShould.IgnoreLineEndings);
            }
        }

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_both_StaffUSI_and_SchoolId
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationViewsProvider = A.Fake<AuthorizationViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationViewsProvider.GetAuthorizationViews())
                    .Returns(new List<string>
                    {
                        "auth.LocalEducationAgencyIdToSchoolId",
                        "auth.LocalEducationAgencyIdToStaffUSI",
                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    AllSuppliedLeaIds,
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                        .ClaimsMustBeAssociatedWith(x => x.SchoolId));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),

                    // 2 parameters are the SQL Server TVP and the StaffUSI segment
                    () => result.Parameters.Length.ShouldBe(4),

                    () => result.Parameters.Any(x => x.GetType() != typeof(SqlParameter))
                            .ShouldBeFalse(),

                    // TVP parameters is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[0].Value).Rows[0][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[0]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[1][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[1]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[2][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[2]),

                    // Second parameter is for the LEA to StaffUSI segment
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI),

                    // TVP parameters is defined as expected
                    () => result.Parameters[2].ParameterName.ShouldBe("@p2"),
                    () => result.Parameters[2].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[2].Value).Rows[0][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[0]),
                    () => ((DataTable)result.Parameters[2].Value).Rows[1][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[1]),
                    () => ((DataTable)result.Parameters[2].Value).Rows[2][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[2]),

                    // Second parameter is for the LEA to SchoolId segment
                    () => result.Parameters[3].ParameterName.ShouldBe("@p3"),
                    () => result.Parameters[3].Value.ShouldBe(_suppliedAuthorizationContext.SchoolId)
                );

                var sql = result.Sql;

                var expectedSql =
$@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToStaffUSI a WHERE a.LocalEducationAgencyId IN (SELECT Id from @p0) and a.StaffUSI = @p1)
)
AND
(
EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToSchoolId a WHERE a.LocalEducationAgencyId IN (SELECT Id from @p2) and a.SchoolId = @p3)
);";

                sql.ShouldBe(expectedSql, StringCompareShould.IgnoreLineEndings);
            }
        }

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_StaffUSI_and_SchoolId_with_multiple_EdOrg_types
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationViewsProvider = A.Fake<AuthorizationViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationViewsProvider.GetAuthorizationViews())
                    .Returns(new List<string>
                    {
                        "auth.PostSecondaryInstitutionIdToStaffUSI",
                        "auth.PostSecondaryInstitutionIdToSchoolId",
                        "auth.LocalEducationAgencyIdToStaffUSI",
                        "auth.LocalEducationAgencyIdToSchoolId",
                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    new List<int>
                    {
                        SuppliedLea1,
                        SuppliedPostSecondaryInstitutionId,
                        SuppliedLea2
                    }, // Multiple types of EdOrgIds
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                        .ClaimsMustBeAssociatedWith(x => x.SchoolId));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),

                    // 4 parameters are the SQL Server TVP for each of the StaffUSI and School segments
                    () => result.Parameters.Length.ShouldBe(8),

                    () => result.Parameters.Any(x => x.GetType() != typeof(SqlParameter))
                            .ShouldBeFalse(),

                    // -----------------------------
                    // Claims to StaffUSI segment
                    // -----------------------------
                    // TVP parameters for LEA Ids is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[0].Value).Rows[0][0].ShouldBe(SuppliedLea1),
                    () => ((DataTable)result.Parameters[0].Value).Rows[1][0].ShouldBe(SuppliedLea2),

                    // Second parameter is for the LEA to StaffUSI segment
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI),

                    // Single-value parameter for PostSecondary is defined as expected
                    () => result.Parameters[2].ParameterName.ShouldBe("@p2"),
                    () => result.Parameters[2].Value.ShouldBeOfType<int>(),
                    () => result.Parameters[2].Value.ShouldBe(SuppliedPostSecondaryInstitutionId),

                    // Second parameter is for the PostSecondary to StaffUSI segment
                    () => result.Parameters[3].ParameterName.ShouldBe("@p3"),
                    () => result.Parameters[3].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI),

                    // ---------------------------
                    // Claims to SchoolId segment
                    // ---------------------------
                    // TVP parameters for LEAIds is defined as expected
                    () => result.Parameters[4].ParameterName.ShouldBe("@p4"),
                    () => result.Parameters[4].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[4].Value).Rows[0][0].ShouldBe(SuppliedLea1),
                    () => ((DataTable)result.Parameters[4].Value).Rows[1][0].ShouldBe(SuppliedLea2),

                    // Second parameter is for the LEA to SchoolId segment
                    () => result.Parameters[5].ParameterName.ShouldBe("@p5"),
                    () => result.Parameters[5].Value.ShouldBe(_suppliedAuthorizationContext.SchoolId),

                    // Single-value parameter for PostSecondary is defined as expected
                    () => result.Parameters[6].ParameterName.ShouldBe("@p6"),
                    () => result.Parameters[6].Value.ShouldBeOfType<int>(),
                    () => result.Parameters[6].Value.ShouldBe(SuppliedPostSecondaryInstitutionId),

                    // Second parameter is for the PostSecondary to SchoolId segment
                    () => result.Parameters[7].ParameterName.ShouldBe("@p7"),
                    () => result.Parameters[7].Value.ShouldBe(_suppliedAuthorizationContext.SchoolId)
                );

                var sql = result.Sql;

                var expectedSql =
$@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToStaffUSI a WHERE a.LocalEducationAgencyId IN (SELECT Id from @p0) and a.StaffUSI = @p1)
OR EXISTS (SELECT 1 FROM auth.PostSecondaryInstitutionIdToStaffUSI a WHERE a.PostSecondaryInstitutionId = @p2 and a.StaffUSI = @p3)
)
AND
(
EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToSchoolId a WHERE a.LocalEducationAgencyId IN (SELECT Id from @p4) and a.SchoolId = @p5)
OR EXISTS (SELECT 1 FROM auth.PostSecondaryInstitutionIdToSchoolId a WHERE a.PostSecondaryInstitutionId = @p6 and a.SchoolId = @p7)
);";

                sql.ShouldBe(expectedSql, StringCompareShould.IgnoreLineEndings);
            }
        }

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_StaffUSI_and_SchoolId_with_multiple_EdOrg_types_with_some_authorization_views_not_supported
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationViewsProvider = A.Fake<AuthorizationViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationViewsProvider.GetAuthorizationViews())
                    .Returns(new List<string>
                    {
                        // Not supported for this test:
                        // "auth.LocalEducationAgencyIdToStaffUSI",
                        "auth.PostSecondaryInstitutionIdToStaffUSI",

                        // Not supported for this test:
                        // "auth.PostSecondaryInstitutionIdToSchoolId",
                        "auth.LocalEducationAgencyIdToSchoolId",

                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    new List<int>
                    {
                        SuppliedLea1,
                        SuppliedPostSecondaryInstitutionId,
                        SuppliedLea2
                    }, // Multiple types of EdOrgIds
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                        .ClaimsMustBeAssociatedWith(x => x.SchoolId));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),

                    // 4 parameters are the SQL Server TVP for each of the StaffUSI and School segments
                    () => result.Parameters.Length.ShouldBe(4),

                    () => result.Parameters.Any(x => x.GetType() != typeof(SqlParameter))
                            .ShouldBeFalse(),

                    // -----------------------------
                    // Claims to StaffUSI segment
                    // -----------------------------
                    // Single-value parameter for PostSecondary is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<int>(),
                    () => result.Parameters[0].Value.ShouldBe(SuppliedPostSecondaryInstitutionId),

                    // Second parameter is for the PostSecondary to StaffUSI segment
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI),

                    // ---------------------------
                    // Claims to SchoolId segment
                    // ---------------------------
                    // TVP parameters for LEAIds is defined as expected
                    () => result.Parameters[2].ParameterName.ShouldBe("@p2"),
                    () => result.Parameters[2].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[2].Value).Rows[0][0].ShouldBe(SuppliedLea1),
                    () => ((DataTable)result.Parameters[2].Value).Rows[1][0].ShouldBe(SuppliedLea2),

                    // Second parameter is for the LEA to SchoolId segment
                    () => result.Parameters[3].ParameterName.ShouldBe("@p3"),
                    () => result.Parameters[3].Value.ShouldBe(_suppliedAuthorizationContext.SchoolId)
                );

                var sql = result.Sql;

                var expectedSql =
$@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.PostSecondaryInstitutionIdToStaffUSI a WHERE a.PostSecondaryInstitutionId = @p0 and a.StaffUSI = @p1)
)
AND
(
EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToSchoolId a WHERE a.LocalEducationAgencyId IN (SELECT Id from @p2) and a.SchoolId = @p3)
);";

                sql.ShouldBe(expectedSql, StringCompareShould.IgnoreLineEndings);
            }
        }

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_StaffUSI_and_SchoolId_with_multiple_EdOrg_types_with_all_authorization_views_of_one_segment_not_supported
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationViewsProvider = A.Fake<AuthorizationViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationViewsProvider.GetAuthorizationViews())
                    .Returns(new List<string>
                    {
                        // Not supported for this test:
                        // "auth.LocalEducationAgencyIdToStaffUSI",
                        "auth.PostSecondaryInstitutionIdToStaffUSI",

                        // Not supported for this test:
                        // "auth.PostSecondaryInstitutionIdToSchoolId",
                        // "auth.LocalEducationAgencyIdToSchoolId",

                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    new List<int>
                    {
                        SuppliedLea1,
                        SuppliedPostSecondaryInstitutionId,
                        SuppliedLea2
                    }, // Multiple types of EdOrgIds
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                        .ClaimsMustBeAssociatedWith(x => x.SchoolId));

                Should.Throw<EdFiSecurityException>(
                        () => authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex)
                    )
                    .Message.ShouldBe(
                        "Unable to authorize the request because there is no authorization support for associating the API client's associated education organization types ('LocalEducationAgency', 'PostSecondaryInstitution') with the resource.");
            }
        }

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_without_a_supporting_authorization_view
        {
            [Test]
            public void Should_throw_an_exception_when_convention_based_view_name_is_not_supported()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationViewsProvider = A.Fake<AuthorizationViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationViewsProvider.GetAuthorizationViews())
                    .Returns(new List<string>
                    {
                        // Not supported in this test:
                        // "auth.LocalEducationAgencyIdToStaffUSI",
                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    AllSuppliedLeaIds,
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI));

                Should.Throw<Exception>(
                        () =>
                        {
                            authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(
                                authorizationSegments,
                                ref parameterIndex);
                        })
                    .Message.ShouldBe(
                        "Unable to authorize the request because there is no authorization support for associating the API client's associated education organization types ('LocalEducationAgency') with the resource.");
            }
        }

        [TestFixture]
        public class When_building_the_Postgres_specific_sql_for_relationship_authorization_segments_only_associated_with_StaffUSI
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationViewsProvider = A.Fake<AuthorizationViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationViewsProvider.GetAuthorizationViews())
                    .Returns(new List<string>
                    {
                        "auth.LocalEducationAgencyIdToStaffUSI",
                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new PostgresAuthorizationSegmentSqlProvider(mockAuthorizationViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    AllSuppliedLeaIds,
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),
                    () => result.Parameters.Length.ShouldBe(
                        _suppliedClaim.EducationOrganizationIds.Count + 1), // + 1 is for StaffUSI segment

                    () => result.Parameters.Any(x => x.GetType() != typeof(NpgsqlParameter))
                            .ShouldBeFalse(),

                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBe(_suppliedClaim.EducationOrganizationIds[0]),

                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedClaim.EducationOrganizationIds[1]),

                    () => result.Parameters[2].ParameterName.ShouldBe("@p2"),
                    () => result.Parameters[2].Value.ShouldBe(_suppliedClaim.EducationOrganizationIds[2]),

                    () => result.Parameters[3].ParameterName.ShouldBe("@p3"),
                    () => result.Parameters[3].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI)
                );

                var sql = result.Sql;

                var expectedSql =
$@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToStaffUSI a WHERE a.LocalEducationAgencyId IN (@p0, @p1, @p2) and a.StaffUSI = @p3)
);";

                sql.ShouldBe(expectedSql, StringCompareShould.IgnoreLineEndings);
            }
        }

        private static IReadOnlyList<ClaimsAuthorizationSegment> GetRelationshipAuthorizationSegments(
            List<int> claimEducationOrganizationIds,
            Action<AuthorizationBuilder<RelationshipsAuthorizationContextData>> buildAuthorizations)
        {
            _suppliedAuthorizationContext = new RelationshipsAuthorizationContextData
            {
                SchoolId = 880001,
                StaffUSI = 738953
            };

            _suppliedClaim = new EdFiResourceClaimValue(
                "manage",
                claimEducationOrganizationIds);

            var suppliedClaims = new List<Claim>
            {
                JsonClaimHelper.CreateClaim(
                    "http://ed-fi.org/ods/identity/claims/domains/generalData",
                    _suppliedClaim)
            };

            var educationOrganizationCache = A.Fake<IEducationOrganizationCache>();

            A.CallTo(() => educationOrganizationCache.GetEducationOrganizationIdentifiers(
                    A<int>.That.Matches(x => x == SuppliedLea1 || x == SuppliedLea2 || x == SuppliedLea3)))
                .Returns(new EducationOrganizationIdentifiers(0, "LocalEducationAgency"));

            A.CallTo(() => educationOrganizationCache.GetEducationOrganizationIdentifiers(SuppliedPostSecondaryInstitutionId))
                .Returns(new EducationOrganizationIdentifiers(0, "PostSecondaryInstitution"));

            var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                suppliedClaims,
                educationOrganizationCache,
                _suppliedAuthorizationContext);

            buildAuthorizations(builder);

            return builder.GetSegments();
        }
    }
}
