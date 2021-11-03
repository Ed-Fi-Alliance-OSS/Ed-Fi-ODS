// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.TokenInfo;
using FakeItEasy;
using NHibernate;
using NHibernate.Transform;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Providers
{
    [TestFixture]
    public class TokenInfoProviderTests
    {
        private ApiKeyContext CreateApiContext()
        {
            var educationOrganizationIds = new[] {1234};

            var namespacePrefixes = new[] {"uri://ed-fi.org"};

            return new ApiKeyContext(
                Guid.NewGuid().ToString("n"), "Claim Set", educationOrganizationIds, namespacePrefixes, new List<string>(),
                "descriptor", null, null);
        }

        private List<TokenInfoData> CreateEducationOrganizationIdentifiers()
        {
            return new List<TokenInfoData>
            {
                new TokenInfoData(
                    1234, "Test LEA","edfi.LocalEducationAgency","edfi.LocalEducationAgency",1234),
                new TokenInfoData(
                    255901001, "Test LEA","edfi.School","edfi.LocalEducationAgency",255901001),
            };
        }

        [Test]
        public async Task Should_get_education_organization_identifiers_for_a_user_lea_context()
        {
            // Arrange
            var sessionFactory = A.Fake<ISessionFactory>();
            var session = A.Fake<IStatelessSession>();

            A.CallTo(() => sessionFactory.OpenStatelessSession())
                .Returns(session);

            // setting up education organization identifier calls, need to guarantee we are using the same object for each call.
            var edOrgIdentifierSqlQuery = A.Fake<ISQLQuery>();

            A.CallTo(() => session.CreateSQLQuery(A<string>.That.Contains("auth.EducationOrganizationIdToEducationOrganizationId")))
                .Returns(edOrgIdentifierSqlQuery);

            A.CallTo(
                    () => edOrgIdentifierSqlQuery.SetResultTransformer(
                        Transformers.AliasToBean<TokenInfoData>()))
                .Returns(edOrgIdentifierSqlQuery);

            A.CallTo(() => edOrgIdentifierSqlQuery.ListAsync<TokenInfoData>(CancellationToken.None))
                .Returns(CreateEducationOrganizationIdentifiers());

            // Act
            var tokenInfoProvider = new TokenInfoProvider(sessionFactory);

            var results = await tokenInfoProvider.GetTokenInfoAsync(CreateApiContext());

            // Assert
            // validate we went down the path
            A.CallTo(() => sessionFactory.OpenStatelessSession())
                .MustHaveHappenedOnceExactly();


            A.CallTo(() => session.CreateSQLQuery(A<string>.That.Contains("auth.EducationOrganizationIdToEducationOrganizationId")))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => edOrgIdentifierSqlQuery.ListAsync<TokenInfoData>(CancellationToken.None))
                .MustHaveHappenedOnceExactly();

            // validate we have a valid object
            results.ShouldNotBeNull();
            results.NamespacePrefixes.Count().ShouldBe(1);
            results.AssignedProfiles.ShouldBeEmpty();
            results.EducationOrganizations.Count().ShouldBe(2);
        }
    }
}