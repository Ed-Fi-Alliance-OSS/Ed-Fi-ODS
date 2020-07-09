// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Services.Providers;
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

        private List<EducationOrganizationIdentifiers> CreateEducationOrganizationIdentifiers()
        {
            return new List<EducationOrganizationIdentifiers>
            {
                new EducationOrganizationIdentifiers(
                    1234, "LocalEducationAgency", fullEducationOrganizationType: "edfi.LocalEducationOrganization",
                    nameOfInstitution: "Test LEA"),
                new EducationOrganizationIdentifiers(
                    123401, "School", fullEducationOrganizationType: "edfi.School",
                    nameOfInstitution: "School belonging to LEA")
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

            // info schema validation to get all the columns
            var schemaSqlQuery = A.Fake<ISQLQuery>();

            A.CallTo(() => session.CreateSQLQuery(A<string>.That.Contains("information_schema.columns")))
                .Returns(schemaSqlQuery);

            A.CallTo(() => schemaSqlQuery.ListAsync<string>(CancellationToken.None))
                .Returns(new List<string>());

            // setting up education organization identifier calls, need to guarantee we are using the same object for each call.
            var edOrgIdentifierSqlQuery = A.Fake<ISQLQuery>();

            A.CallTo(() => session.CreateSQLQuery(A<string>.That.Contains("auth.educationorganizationidentifiers")))
                .Returns(edOrgIdentifierSqlQuery);

            A.CallTo(
                    () => edOrgIdentifierSqlQuery.SetResultTransformer(
                        Transformers.AliasToBean<EducationOrganizationIdentifiers>()))
                .Returns(edOrgIdentifierSqlQuery);

            A.CallTo(() => edOrgIdentifierSqlQuery.ListAsync<EducationOrganizationIdentifiers>(CancellationToken.None))
                .Returns(CreateEducationOrganizationIdentifiers());

            // Act
            var tokenInfoProvider = new TokenInfoProvider(sessionFactory);

            var results = await tokenInfoProvider.GetTokenInfoAsync(CreateApiContext());

            // Assert
            // validate we went down the path
            A.CallTo(() => sessionFactory.OpenStatelessSession())
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => session.CreateSQLQuery(A<string>.That.Contains("information_schema.columns")))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => schemaSqlQuery.ListAsync<string>(CancellationToken.None))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => session.CreateSQLQuery(A<string>.That.Contains("auth.educationorganizationidentifiers")))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => edOrgIdentifierSqlQuery.ListAsync<EducationOrganizationIdentifiers>(CancellationToken.None))
                .MustHaveHappenedOnceExactly();

            // validate we have a valid object
            results.ShouldNotBeNull();
            results.NamespacePrefixes.Count().ShouldBe(1);
            results.AssignedProfiles.ShouldBeEmpty();
            results.EducationOrganizations.Count().ShouldBe(2);
        }
    }
}
