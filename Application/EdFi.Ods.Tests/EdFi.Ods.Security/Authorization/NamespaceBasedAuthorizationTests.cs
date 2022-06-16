// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Database.NamingConventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Tests._Extensions;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization
{
    [TestFixture]
    public class NamespaceBasedAuthorizationStrategyTests
    {
        [Test]
        public void NamespaceBasedAuthorization_EmptyNamespaceClaim()
        {
            //Arrange
            var strategy = new NamespaceBasedAuthorizationStrategy();

            var claims = new List<Claim>
            {
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, string.Empty),
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, string.Empty)
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

            string resource = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
            string action = @"http://ed-fi.org/ods/actions/manage";

            var data = new NamespaceBasedAuthorizationContextData
            {
                Namespace = @"uri://ed-fi.org/"
            };

            //Act

            var exception = Assert.Throws<EdFiSecurityException>(
                () => strategy.GetAuthorizationStrategyFiltering(
                        new List<Claim>(), new EdFiAuthorizationContext(new ApiKeyContext(), principal, new[] {resource}, action, data)));

            exception.Message.ShouldBe(
                "Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('"
                + EdFiOdsApiClaimTypes.NamespacePrefix + "') or the claim values were all empty.");

            //Assert
        }

        [Test]
        public void NamespaceBasedAuthorization_EmptyResourceNamespace()
        {
            //Arrange
            var filterDefinitionsFactory = new NamespaceBasedAuthorizationFilterDefinitionsFactory(A.Fake<IDatabaseNamingConvention>());

            var claims = new List<Claim>
            {
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, @"uri://ed-fi.org/"),
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, @"uri://ed-fi-2.org/")
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

            string resource = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
            string action = @"http://ed-fi.org/ods/actions/manage";

            var data = new NamespaceBasedAuthorizationContextData
            {
                Namespace = @""
            };

            //Act
            var filterDefinition = filterDefinitionsFactory.CreateAuthorizationFilterDefinitions().Single();

            var result = filterDefinition.AuthorizeInstance(
                new EdFiAuthorizationContext(new ApiKeyContext(), principal, new[] { resource }, action, data),
                new AuthorizationFilterContext());
            
            //Assert
            result.Exception.ShouldBeExceptionType<EdFiSecurityException>();
            result.Exception.Message.ShouldBe("Access to the resource item could not be authorized because the Namespace of the resource is empty.");
        }

        [Test]
        public void NamespaceBasedAuthorization_MatchOnNamespace_ShouldThrowNoExceptions()
        {
            //Arrange
            var strategy = new NamespaceBasedAuthorizationStrategy();

            var claims = new List<Claim>
            {
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, @"uri://ed-fi.org/"),
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, @"uri://ed-fi-2.org/")
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

            string resource = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
            string action = @"http://ed-fi.org/ods/actions/manage";

            var data = new NamespaceBasedAuthorizationContextData
            {
                Namespace = @"uri://ed-fi.org/"
            };

            //Act
            strategy.GetAuthorizationStrategyFiltering(
                new List<Claim>(),
                new EdFiAuthorizationContext(new ApiKeyContext(), principal, new[] { resource }, action, data));

            //Assert
        }

        [Test]
        public void NamespaceBasedAuthorization_MismatchedNamespaces()
        {
            //Arrange
            var filterDefinitionsFactory = new NamespaceBasedAuthorizationFilterDefinitionsFactory(A.Fake<IDatabaseNamingConvention>());

            var claims = new List<Claim>
            {
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, @"uri://ed-fi.org/"),
                new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, @"uri://ed-fi-2.org/")
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

            string resource = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
            string action = @"http://ed-fi.org/ods/actions/manage";

            var data = new NamespaceBasedAuthorizationContextData
            {
                Namespace = @"uri://www.TEST.org/"
            };

            //Act
            var filterDefinition = filterDefinitionsFactory.CreateAuthorizationFilterDefinitions().Single();

            var result = filterDefinition.AuthorizeInstance(
                new EdFiAuthorizationContext(new ApiKeyContext(), principal, new[] { resource }, action, data),
                new AuthorizationFilterContext());

            //Assert
            result.Exception.ShouldBeExceptionType<EdFiSecurityException>();
            result.Exception.Message.ShouldBe("Access to the resource item could not be authorized based on the caller's NamespacePrefix claims: 'uri://ed-fi.org/', 'uri://ed-fi-2.org/'.");
        }

        [Test]
        public void NamespaceBasedAuthorization_NoNamespaceClaim()
        {
            //Arrange
            var strategy = new NamespaceBasedAuthorizationStrategy();

            var claims = new List<Claim>();
            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

            string resource = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
            string action = @"http://ed-fi.org/ods/actions/manage";

            var data = new NamespaceBasedAuthorizationContextData
            {
                Namespace = @"uri://ed-fi.org/"
            };

            //Act

            var exception = Assert.Throws<EdFiSecurityException>(() => strategy.GetAuthorizationStrategyFiltering(
                new List<Claim>(),
                new EdFiAuthorizationContext(new ApiKeyContext(), principal, new[] { resource }, action, data)));

            exception.Message.ShouldBe(
                "Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('"
                + EdFiOdsApiClaimTypes.NamespacePrefix + "') or the claim values were all empty.");

        }
    }
}