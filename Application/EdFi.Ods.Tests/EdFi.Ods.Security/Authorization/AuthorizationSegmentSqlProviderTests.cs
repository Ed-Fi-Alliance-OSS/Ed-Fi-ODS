// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.TestFixture;
using FakeItEasy;
using Npgsql;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
{
    [TestFixture]
    public class AuthorizationSegmentsSqlProviderTests
    {
        [TestFixture]
        public class When_building_the_sqlserver_specific_sql_for_relationship_authorization_segments
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var authorizationSegmentsSqlProvider = new SqlServerAuthorizationSegmentSqlProvider();
                var parameterIndex = 0;
                var authorizationSegments = GetRelationshipAuthorizationSegments();

                var result = authorizationSegmentsSqlProvider.BuildAuthorization(authorizationSegments, ref parameterIndex);

                Assert.Multiple(
                    () =>
                    {
                        result.ShouldNotBeNull();
                        result.Value.Length.ShouldBe(4);

                        result.Value.Any(x => x.GetType() != typeof(SqlParameter))
                            .ShouldBeFalse();
                    });

                // parameters are set correctly
                Assert.Multiple(
                    () =>
                    {
                        result.Value[0]
                            .ParameterName.ShouldBe("@p0");

                        result.Value[1]
                            .ParameterName.ShouldBe("@p1");

                        result.Value[2]
                            .ParameterName.ShouldBe("@p2");

                        result.Value[3]
                            .ParameterName.ShouldBe("@p3");

                        result.Value[0]
                            .Value.ShouldBeOfType<DataTable>();

                        result.Value[1]
                            .Value.ShouldBe(738953);

                        result.Value[2]
                            .Value.ShouldBe(880001);

                        result.Value[3]
                            .Value.ShouldBe(738953);
                    });

                var sql = result.Key;

                var expectedSql =
                    $"SELECT 1 WHERE EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToStaffUSI a WHERE a.LocalEducationAgencyId IN (SELECT Id from @p0) and a.StaffUSI = @p1){Environment.NewLine}\tAND EXISTS (SELECT 1 FROM auth.SchoolIdToStaffUSI a WHERE a.SchoolId = @p2 and a.StaffUSI = @p3);";

                sql.ShouldBe(expectedSql);
            }
        }

        [TestFixture]
        public class When_building_the_postgres_specific_sql_for_relationship_authorization_segments
        {
            [Test]
            public void Should_generate_valid_sql_and_parameters()
            {
                var authorizationSegmentsSqlProvider = new PostgresAuthorizationSegmentSqlProvider();
                var parameterIndex = 0;
                var authorizationSegments = GetRelationshipAuthorizationSegments();

                var result = authorizationSegmentsSqlProvider.BuildAuthorization(authorizationSegments, ref parameterIndex);

                Assert.Multiple(
                    () =>
                    {
                        result.ShouldNotBeNull();
                        result.Value.Length.ShouldBe(6);

                        result.Value.Any(x => x.GetType() != typeof(NpgsqlParameter))
                            .ShouldBeFalse();
                    });

                // parameters are set correctly
                Assert.Multiple(
                    () =>
                    {
                        result.Value[0]
                            .ParameterName.ShouldBe("@p0");

                        result.Value[1]
                            .ParameterName.ShouldBe("@p1");

                        result.Value[2]
                            .ParameterName.ShouldBe("@p2");

                        result.Value[3]
                            .ParameterName.ShouldBe("@p3");

                        result.Value[4]
                            .ParameterName.ShouldBe("@p4");

                        result.Value[5]
                            .ParameterName.ShouldBe("@p5");

                        result.Value[0]
                            .Value.ShouldBe(780);

                        result.Value[1]
                            .Value.ShouldBe(880);

                        result.Value[2]
                            .Value.ShouldBe(980);

                        result.Value[3]
                            .Value.ShouldBe(738953);

                        result.Value[4]
                            .Value.ShouldBe(880001);

                        result.Value[5]
                            .Value.ShouldBe(738953);
                    });

                var sql = result.Key;

                var expectedSql =
                    $"SELECT 1 WHERE EXISTS (SELECT 1 FROM auth.LocalEducationAgencyIdToStaffUSI a WHERE a.LocalEducationAgencyId IN (@p0, @p1, @p2) and a.StaffUSI = @p3){Environment.NewLine}\tAND EXISTS (SELECT 1 FROM auth.SchoolIdToStaffUSI a WHERE a.SchoolId = @p4 and a.StaffUSI = @p5);";

                sql.ShouldBe(expectedSql);
            }
        }

        private static AuthorizationSegmentCollection GetRelationshipAuthorizationSegments()
        {
            var suppliedContextData = new RelationshipsAuthorizationContextData
            {
                SchoolId = 880001,
                StaffUSI = 738953
            };

            var suppliedEdFiResourceClaimValue = new EdFiResourceClaimValue(
                "manage",
                new List<int>
                {
                    780,
                    880,
                    980
                });

            var suppliedClaims = new List<Claim>
            {
                JsonClaimHelper.CreateClaim(
                    "http://ed-fi.org/ods/identity/claims/domains/generalData",
                    suppliedEdFiResourceClaimValue)
            };

            var educationOrganizationCache = A.Fake<IEducationOrganizationCache>();

            A.CallTo(
                    () =>
                        educationOrganizationCache.GetEducationOrganizationIdentifiers(A<int>._))
                .Returns(new EducationOrganizationIdentifiers(0, "LocalEducationAgency"));

            var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                suppliedClaims,
                educationOrganizationCache,
                suppliedContextData);

            return builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                .ExistingValuesMustBeAssociated(x => x.SchoolId, x => x.StaffUSI)
                .GetSegments();
        }
    }
}
