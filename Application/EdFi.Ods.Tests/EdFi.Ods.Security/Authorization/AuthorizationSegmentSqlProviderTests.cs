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
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.Utilities;
using FakeItEasy;
using NHibernate;
using Npgsql;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization
{
    [TestFixture]
    public class AuthorizationSegmentsSqlProviderTests
    {
        private const int SuppliedEdOrg1 = 780;
        private const int SuppliedEdOrg2 = 880;
        private const int SuppliedEdOrg3 = 980;

        private const int SuppliedPostSecondaryInstitutionId = 111;

        private static RelationshipsAuthorizationContextData _suppliedAuthorizationContext;
        private static EdFiResourceClaimValue _suppliedClaim;
        private static readonly List<int> AllSuppliedEdOrgIds = new List<int>
        {
            SuppliedEdOrg1,
            SuppliedEdOrg2,
            SuppliedEdOrg3
        };

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_StaffUSI
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationTablesAndViewsProvider = A.Fake<AuthorizationTablesAndViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews())
                    .Returns(new List<string>
                    {
                        "auth.EducationOrganizationIdToStaffUSI",
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationTablesAndViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    AllSuppliedEdOrgIds,
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),

                    // 2 parameters are the SQL Server TVP holding the claim EdOrgId values and the StaffUSI
                    () => result.Parameters.Length.ShouldBe(2),

                    () => result.Parameters.ShouldAllBe(p => p is SqlParameter),

                    // TVP parameters is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[0].Value).Rows[0][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[0]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[1][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[1]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[2][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[2]),

                    // Second parameter is for the StaffUSI
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI)
                );

                var sql = result.Sql;

                var expectedSql =
                    $@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStaffUSI a WHERE a.SourceEducationOrganizationId IN (SELECT Id from @p0) and a.StaffUSI = @p1)
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

                var mockAuthorizationTablesAndViewsProvider = A.Fake<AuthorizationTablesAndViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews())
                    .Returns(new List<string>
                    {
                        "auth.EducationOrganizationIdToEducationOrganizationId",
                        "auth.EducationOrganizationIdToStaffUSI",
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationTablesAndViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    AllSuppliedEdOrgIds,
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                        .ClaimsMustBeAssociatedWith(x => x.SchoolId));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),

                    // 2 parameters for each segment are the SQL Server TVP containing claim EdOrgId values and the StaffUSI (or SchoolId) value
                    () => result.Parameters.Length.ShouldBe(4),

                    () => result.Parameters.ShouldAllBe(p => p is SqlParameter),

                    // TVP parameters is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[0].Value).Rows[0][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[0]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[1][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[1]),
                    () => ((DataTable)result.Parameters[0].Value).Rows[2][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[2]),

                    // Second parameter is for the StaffUSI auth context value
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI),

                    // TVP parameters is defined with the EdOrgId claim values
                    () => result.Parameters[2].ParameterName.ShouldBe("@p2"),
                    () => result.Parameters[2].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[2].Value).Rows[0][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[0]),
                    () => ((DataTable)result.Parameters[2].Value).Rows[1][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[1]),
                    () => ((DataTable)result.Parameters[2].Value).Rows[2][0].ShouldBe(_suppliedClaim.EducationOrganizationIds[2]),

                    // Second parameter is for the SchoolId auth context value
                    () => result.Parameters[3].ParameterName.ShouldBe("@p3"),
                    () => result.Parameters[3].Value.ShouldBe(_suppliedAuthorizationContext.SchoolId)
                );

                var sql = result.Sql;

                var expectedSql =
                    $@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStaffUSI a WHERE a.SourceEducationOrganizationId IN (SELECT Id from @p0) and a.StaffUSI = @p1)
)
AND
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToEducationOrganizationId a WHERE a.SourceEducationOrganizationId IN (SELECT Id from @p2) and a.TargetEducationOrganizationId = @p3)
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

                var mockAuthorizationTablesAndViewsProvider = A.Fake<AuthorizationTablesAndViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews())
                    .Returns(new List<string>
                    {
                        "auth.EducationOrganizationIdToEducationOrganizationId",
                        "auth.EducationOrganizationIdToStaffUSI",
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationTablesAndViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    new List<int>
                    {
                        SuppliedEdOrg1,
                        SuppliedPostSecondaryInstitutionId,
                        SuppliedEdOrg2
                    }, // Multiple types of EdOrgIds
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                        .ClaimsMustBeAssociatedWith(x => x.SchoolId));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(() => result.ShouldNotBeNull(),

                    // 4 parameters are the SQL Server TVP containing the EdOrgId claim values, and the StaffUSI (or SchoolId) auth context value
                    () => result.Parameters.Length.ShouldBe(4), () => result.Parameters.ShouldAllBe(p => p is SqlParameter),

                    // -----------------------------
                    // Claims to StaffUSI segment
                    // -----------------------------
                    // TVP parameters for EdOrgId claim values is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<DataTable>(), 
                    () => ((DataTable)result.Parameters[0].Value).Rows.Count.ShouldBe(3),
                    () => ((DataTable)result.Parameters[0].Value).Rows[0][0].ShouldBe(SuppliedEdOrg1),
                    () => ((DataTable)result.Parameters[0].Value).Rows[1][0].ShouldBe(SuppliedPostSecondaryInstitutionId),
                    () => ((DataTable)result.Parameters[0].Value).Rows[2][0].ShouldBe(SuppliedEdOrg2),

                    // Second parameter is for the StaffUSI auth context value
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI),

                    // Single-value parameter for PostSecondary is defined as expected
                    () => result.Parameters[2].ParameterName.ShouldBe("@p2"),
                    () => result.Parameters[2].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[2].Value).Rows.Count.ShouldBe(3),
                    () => ((DataTable)result.Parameters[2].Value).Rows[0][0].ShouldBe(SuppliedEdOrg1),
                    () => ((DataTable)result.Parameters[2].Value).Rows[1][0].ShouldBe(SuppliedPostSecondaryInstitutionId),
                    () => ((DataTable)result.Parameters[2].Value).Rows[2][0].ShouldBe(SuppliedEdOrg2),

                    // Second parameter is for the PostSecondary to StaffUSI segment
                    () => result.Parameters[3].ParameterName.ShouldBe("@p3"),
                    () => result.Parameters[3].Value.ShouldBe(_suppliedAuthorizationContext.SchoolId)
                );

                var sql = result.Sql;

                var expectedSql =
                    $@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStaffUSI a WHERE a.SourceEducationOrganizationId IN (SELECT Id from @p0) and a.StaffUSI = @p1)
)
AND
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToEducationOrganizationId a WHERE a.SourceEducationOrganizationId IN (SELECT Id from @p2) and a.TargetEducationOrganizationId = @p3)
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

                var mockAuthorizationTablesAndViewsProvider = A.Fake<AuthorizationTablesAndViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews())
                    .Returns(new List<string>
                    {
                        "auth.EducationOrganizationIdToStaffUSI",
                        "auth.EducationOrganizationIdToEducationOrganizationId",
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationTablesAndViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    new List<int>
                    {
                        // Multiple types of EdOrgIds
                        SuppliedEdOrg1,
                        SuppliedPostSecondaryInstitutionId,
                        SuppliedEdOrg2
                    },
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                        .ClaimsMustBeAssociatedWith(x => x.SchoolId));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),

                    // 4 parameters are the SQL Server TVPs for the EdOrgId claims, and auth context values for each of the StaffUSI and School segments
                    () => result.Parameters.Length.ShouldBe(4),

                    () => result.Parameters.ShouldAllBe(p => p is SqlParameter),

                    // -----------------------------
                    // Claims to StaffUSI segment
                    // -----------------------------
                    // Single-value parameter for PostSecondary is defined as expected
                    () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                    () => result.Parameters[0].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[0].Value).Rows.Count.ShouldBe(3),
                    () => ((DataTable)result.Parameters[0].Value).Rows[0][0].ShouldBe(SuppliedEdOrg1),
                    () => ((DataTable)result.Parameters[0].Value).Rows[1][0].ShouldBe(SuppliedPostSecondaryInstitutionId),
                    () => ((DataTable)result.Parameters[0].Value).Rows[2][0].ShouldBe(SuppliedEdOrg2),

                    // Second parameter is for the PostSecondary to StaffUSI segment
                    () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                    () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StaffUSI),

                    // ---------------------------
                    // Claims to SchoolId segment
                    // ---------------------------
                    // TVP parameters for LEAIds and PostSecondaryInstitution is defined as expected
                    () => result.Parameters[2].ParameterName.ShouldBe("@p2"),
                    () => result.Parameters[2].Value.ShouldBeOfType<DataTable>(),
                    () => ((DataTable)result.Parameters[2].Value).Rows.Count.ShouldBe(3),
                    () => ((DataTable)result.Parameters[2].Value).Rows[0][0].ShouldBe(SuppliedEdOrg1),
                    () => ((DataTable)result.Parameters[2].Value).Rows[1][0].ShouldBe(SuppliedPostSecondaryInstitutionId),
                    () => ((DataTable)result.Parameters[2].Value).Rows[2][0].ShouldBe(SuppliedEdOrg2),

                    // Second parameter is for the LEA to SchoolId segment
                    () => result.Parameters[3].ParameterName.ShouldBe("@p3"),
                    () => result.Parameters[3].Value.ShouldBe(_suppliedAuthorizationContext.SchoolId)
                );

                var sql = result.Sql;

                var expectedSql =
                    $@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStaffUSI a WHERE a.SourceEducationOrganizationId IN (SELECT Id from @p0) and a.StaffUSI = @p1)
)
AND
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToEducationOrganizationId a WHERE a.SourceEducationOrganizationId IN (SELECT Id from @p2) and a.TargetEducationOrganizationId = @p3)
);";

                sql.ShouldBe(expectedSql, StringCompareShould.IgnoreLineEndings);
            }
        }

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_StudentUSI_with_one_EdOrg_types_with_authorization_views_of_authorizationPathModifier_not_supported
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationTablesAndViewsProvider = A.Fake<AuthorizationTablesAndViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews())
                    .Returns(new List<string>
                    {
                        "auth.EducationOrganizationIdToStudentUSI",
                        "auth.EducationOrganizationIdToStudentUSIThroughEdOrgAssociation"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationTablesAndViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    new List<int>
                    {
                        SuppliedEdOrg1
                    },
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StudentUSI, "ThroughSomethingElse"));

                Should.Throw<EdFiSecurityException>(
                        () => authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex)
                    )
                    .Message.ShouldBe(
                "Unable to authorize the request because the following authorization view(s) could not be found: 'auth.EducationOrganizationIdToStudentUSIThroughSomethingElse'.");
            }
        }

        [TestFixture]
        public class When_building_the_SqlServer_specific_sql_for_relationship_authorization_segments_associated_with_StudentUSI_with_one_EdOrg_types_with_authorization_views_of_authorizationPathModifier_supported
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationTablesAndViewsProvider = A.Fake<AuthorizationTablesAndViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews())
                    .Returns(new List<string>
                    {
                        "auth.EducationOrganizationIdToStudentUSI",
                        "auth.EducationOrganizationIdToStudentUSIThroughEdOrgAssociation"
                    });

                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider(mockAuthorizationTablesAndViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    new List<int>
                    {
                        SuppliedEdOrg1
                    },
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StudentUSI, "ThroughEdOrgAssociation"));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                            () => result.ShouldNotBeNull(),
                            () => result.Parameters.Length.ShouldBe(2),

                            () => result.Parameters.ShouldAllBe(p => p is SqlParameter),

                            () => result.Parameters[0].ParameterName.ShouldBe("@p0"),
                            () => result.Parameters[0].Value.ShouldBe(SuppliedEdOrg1),

                            () => result.Parameters[1].ParameterName.ShouldBe("@p1"),
                            () => result.Parameters[1].Value.ShouldBe(_suppliedAuthorizationContext.StudentUSI)

                        );

                var sql = result.Sql;

                var expectedSql =
                    $@"SELECT 1 WHERE
(
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStudentUSIThroughEdOrgAssociation a WHERE a.SourceEducationOrganizationId = @p0 and a.StudentUSI = @p1)
);";

                sql.ShouldBe(expectedSql, StringCompareShould.IgnoreLineEndings);
            }
        }

        [TestFixture]
        public class When_building_the_Postgres_specific_sql_for_relationship_authorization_segments_only_associated_with_StaffUSI
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var mockISessionFactory = A.Fake<ISessionFactory>();

                var mockAuthorizationTablesAndViewsProvider = A.Fake<AuthorizationTablesAndViewsProvider>(x => x.WithArgumentsForConstructor(new object[] { mockISessionFactory }));

                A.CallTo(() => mockAuthorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews())
                    .Returns(new List<string>
                    {
                        "auth.EducationOrganizationIdToStaffUSI",
                        "auth.SchoolIdToStaffUSI"
                    });

                var authorizationSegmentsSqlProvider = new PostgresAuthorizationSegmentSqlProvider(mockAuthorizationTablesAndViewsProvider);
                var parameterIndex = 0;

                var authorizationSegments = GetRelationshipAuthorizationSegments(
                    AllSuppliedEdOrgIds,
                    builder => builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI));

                var result = authorizationSegmentsSqlProvider.GetAuthorizationQueryMetadata(authorizationSegments, ref parameterIndex);

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),
                    () => result.Parameters.Length.ShouldBe(
                    
                        // + 1 is for StaffUSI segment
                        _suppliedClaim.EducationOrganizationIds.Count + 1),

                    () => result.Parameters.ShouldAllBe(p => p is NpgsqlParameter),

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
EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStaffUSI a WHERE a.SourceEducationOrganizationId IN (@p0, @p1, @p2) and a.StaffUSI = @p3)
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
                StaffUSI = 738953,
                StudentUSI = 9999
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

            A.CallTo(() => educationOrganizationCache.GetEducationOrganizationIdentifiers(SuppliedEdOrg1))
                .Returns(new EducationOrganizationIdentifiers(0, "StateEducationAgency"));
            
            A.CallTo(() => educationOrganizationCache.GetEducationOrganizationIdentifiers(SuppliedEdOrg2))
                .Returns(new EducationOrganizationIdentifiers(0, "EducationServiceCenter"));
            
            A.CallTo(() => educationOrganizationCache.GetEducationOrganizationIdentifiers(SuppliedEdOrg3))
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
