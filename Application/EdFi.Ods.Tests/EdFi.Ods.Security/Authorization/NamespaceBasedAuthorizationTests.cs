// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.AuthorizationStrategies.NamespaceBased;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
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
                () => strategy.AuthorizeSingleItemAsync(
                    new List<Claim>(), new EdFiAuthorizationContext(principal, new[] {resource}, action, data), CancellationToken.None)
                    .WaitSafely());

            exception.Message.ShouldBe(
                "Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('"
                + EdFiOdsApiClaimTypes.NamespacePrefix + "') or the claim values were all empty.");

            //Assert
        }

        [Test]
        public void NamespaceBasedAuthorization_EmptyResourceNamespace()
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
                           Namespace = @""
                       };

            //Act

            var exception = Assert.Throws<EdFiSecurityException>(
                () => strategy.AuthorizeSingleItemAsync(
                    new List<Claim>(), new EdFiAuthorizationContext(principal, new[] {resource}, action, data), CancellationToken.None)
                    .WaitSafely());

            exception.Message.ShouldBe("Access to the resource item could not be authorized because the Namespace of the resource is empty.");

            //Assert
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
            strategy.AuthorizeSingleItemAsync(new List<Claim>(), new EdFiAuthorizationContext(principal, new[] {resource}, action, data), CancellationToken.None)
                .WaitSafely();

            //Assert
        }

        [Test]
        public void NamespaceBasedAuthorization_MismatchedNamespaces()
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
                           Namespace = @"uri://www.TEST.org/"
                       };

            //Act
            var exception = Assert.Throws<EdFiSecurityException>(
                () =>
                    strategy.AuthorizeSingleItemAsync(
                        new List<Claim>(), new EdFiAuthorizationContext(principal, new[] {resource}, action, data), CancellationToken.None)
                        .WaitSafely());

            exception.Message.ShouldBe("Access to the resource item with namespace 'uri://www.TEST.org/' could not be authorized based on the caller's NamespacePrefix claims: 'uri://ed-fi.org/', 'uri://ed-fi-2.org/'.");
            //Assert
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

            var exception = Assert.Throws<EdFiSecurityException>(
                () =>
                    strategy.AuthorizeSingleItemAsync(
                        new List<Claim>(), new EdFiAuthorizationContext(principal, new[] {resource}, action, data), CancellationToken.None)
                        .WaitSafely());

            exception.Message.ShouldBe(
                "Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('"
                + EdFiOdsApiClaimTypes.NamespacePrefix + "') or the claim values were all empty.");

            //Assert
        }
    }
}
