// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    [TestFixture]
    public class QueryBuilderExtensionsTests
    {
        private const string EdOrgToEdOrgViewName = "EducationOrganizationIdToEducationOrganizationId";

        [Test]
        public void Should_recognize_the_forward_education_organization_expansion()
        {
            QueryBuilderExtensions.IsForwardEducationOrganizationExpansion(
                    EdOrgToEdOrgViewName,
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    EducationOrganizationAuthorizationViewConstants.TargetColumnName)
                .ShouldBeTrue();
        }

        [Test]
        public void Should_not_recognize_the_inverted_orientation_of_the_same_view()
        {
            // The inverted relationship strategies pass the same view with the columns swapped. Treating that as the
            // forward expansion would authorize the wrong set of education organizations.
            QueryBuilderExtensions.IsForwardEducationOrganizationExpansion(
                    EdOrgToEdOrgViewName,
                    EducationOrganizationAuthorizationViewConstants.TargetColumnName,
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName)
                .ShouldBeFalse();
        }

        [Test]
        public void Should_not_recognize_a_different_authorization_view()
        {
            QueryBuilderExtensions.IsForwardEducationOrganizationExpansion(
                    "EducationOrganizationIdToStudentUSI",
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    "StudentUSI")
                .ShouldBeFalse();
        }
    }
}
