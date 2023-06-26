// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private ApiClientContext CreateApiContext()
        {
            var educationOrganizationIds = new[] {1234};

            var namespacePrefixes = new[] {"uri://ed-fi.org"};

            return new ApiClientContext(
                Guid.NewGuid().ToString("n"), "Claim Set", educationOrganizationIds, namespacePrefixes, new List<string>(),
                "descriptor", null, null, null, 0);
        }

        private List<TokenInfoEducationOrganizationData> CreateEducationOrganizationIdentifiers()
        {
            return new List<TokenInfoEducationOrganizationData>
            {
                new TokenInfoEducationOrganizationData
                {
                    EducationOrganizationId = 6000203,
                    NameOfInstitution = "The University of Texas at Austin",
                    Discriminator = "edfi.PostSecondaryInstitution",
                    AncestorEducationOrganizationId = 6000203,
                    AncestorDiscriminator = "edfi.PostSecondaryInstitution"
                },
                new TokenInfoEducationOrganizationData
                {
                    EducationOrganizationId = 19255901,
                    NameOfInstitution = "Communities in Schools of Grand Bend",
                    Discriminator = "edfi.CommunityProvider",
                    AncestorEducationOrganizationId = 19255901,
                    AncestorDiscriminator = "edfi.CommunityProvider"
                },
                new TokenInfoEducationOrganizationData
                {
                    EducationOrganizationId = 19255901,
                    NameOfInstitution = "Communities in Schools of Grand Bend",
                    Discriminator = "edfi.CommunityProvider",
                    AncestorEducationOrganizationId = 19,
                    AncestorDiscriminator = "edfi.CommunityOrganization"
                },
                new TokenInfoEducationOrganizationData
                {
                    EducationOrganizationId = 255901107,
                    NameOfInstitution = "Grand Bend Elementary School",
                    Discriminator = "edfi.School",
                    AncestorEducationOrganizationId = 255901,
                    AncestorDiscriminator = "edfi.LocalEducationAgency"
                },
                new TokenInfoEducationOrganizationData
                {
                    EducationOrganizationId = 255901107,
                    NameOfInstitution = "Grand Bend Elementary School",
                    Discriminator = "edfi.School",
                    AncestorEducationOrganizationId = 255901107,
                    AncestorDiscriminator = "edfi.School"
                },
                new TokenInfoEducationOrganizationData
                {
                    EducationOrganizationId = 255901107,
                    NameOfInstitution = "Grand Bend Elementary School",
                    Discriminator = "edfi.School",
                    AncestorEducationOrganizationId = 255950,
                    AncestorDiscriminator = "edfi.EducationServiceCenter"
                },
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
                        Transformers.AliasToBean<TokenInfoEducationOrganizationData>()))
                .Returns(edOrgIdentifierSqlQuery);

            A.CallTo(() => edOrgIdentifierSqlQuery.ListAsync<TokenInfoEducationOrganizationData>(CancellationToken.None))
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

            A.CallTo(() => edOrgIdentifierSqlQuery.ListAsync<TokenInfoEducationOrganizationData>(CancellationToken.None))
                .MustHaveHappenedOnceExactly();

            var postSecondaryEntry = results.EducationOrganizations.SingleOrDefault(d => d["education_organization_id"].Equals(6000203));
            var communityProviderEntry = results.EducationOrganizations.SingleOrDefault(d => d["education_organization_id"].Equals(19255901));
            var schoolEntry = results.EducationOrganizations.SingleOrDefault(d => d["education_organization_id"].Equals(255901107));

            results.EducationOrganizations.ShouldSatisfyAllConditions(
                // validate we have a valid object
                () => results.ShouldNotBeNull(),
                () => results.NamespacePrefixes.Count().ShouldBe(1),
                () => results.AssignedProfiles.ShouldBeEmpty(),
                
                // Verify correct preparation of the Education Organization data
                () => results.EducationOrganizations.Count().ShouldBe(3),
                
                // Verify the entries
                () => postSecondaryEntry.ShouldNotBeNull(),
                () => communityProviderEntry.ShouldNotBeNull(),
                () => schoolEntry.ShouldNotBeNull(),

                // ---------------------------
                // Verify post-secondary entry
                // ---------------------------
                () => postSecondaryEntry.Count.ShouldBe(4),
                () => postSecondaryEntry["name_of_institution"].ShouldBe("The University of Texas at Austin"),
                () => postSecondaryEntry["type"].ShouldBe("edfi.PostSecondaryInstitution"),
                () => postSecondaryEntry["education_organization_id"].ShouldBe(6000203),

                // Verify post-secondary entry's concrete education organization identifiers
                () => postSecondaryEntry["post_secondary_institution_id"].ShouldBe(6000203),

                // --------------------------------
                // Verify community provider entry
                // --------------------------------
                () => communityProviderEntry.Count.ShouldBe(5),
                () => communityProviderEntry["name_of_institution"].ShouldBe("Communities in Schools of Grand Bend"),
                () => communityProviderEntry["type"].ShouldBe("edfi.CommunityProvider"),
                () => communityProviderEntry["education_organization_id"].ShouldBe(19255901),

                // Verify community provider entry's concrete education organization identifiers
                () => communityProviderEntry["community_provider_id"].ShouldBe(19255901),
                () => communityProviderEntry["community_organization_id"].ShouldBe(19),

                // --------------------------------
                // Verify school entry
                // --------------------------------
                () => schoolEntry.Count.ShouldBe(6),
                () => schoolEntry["name_of_institution"].ShouldBe("Grand Bend Elementary School"),
                () => schoolEntry["type"].ShouldBe("edfi.School"),
                () => schoolEntry["education_organization_id"].ShouldBe(255901107),

                // Verify school entry's concrete education organization identifiers
                () => schoolEntry["school_id"].ShouldBe(255901107),
                () => schoolEntry["local_education_agency_id"].ShouldBe(255901),
                () => schoolEntry["education_service_center_id"].ShouldBe(255950)
            );
            
            /*  For reference: Expected JSON output
                "education_organizations": [
                    {
                        "education_organization_id": 19255901,
                        "name_of_institution": "Communities in Schools of Grand Bend",
                        "type": "edfi.CommunityProvider",
                        "community_organization_id": 19,
                        "community_provider_id": 19255901
                    },
                    {
                        "education_organization_id": 255901107,
                        "name_of_institution": "Grand Bend Elementary School",
                        "type": "edfi.School",
                        "local_education_agency_id": 255901,
                        "education_service_center_id": 255950,
                        "school_id": 255901107
                    },
                    {
                        "education_organization_id": 6000203,
                        "name_of_institution": "The University of Texas at Austin",
                        "type": "edfi.PostSecondaryInstitution",
                        "post_secondary_institution_id": 6000203
                    }
                ],
             */
        }
    }
}