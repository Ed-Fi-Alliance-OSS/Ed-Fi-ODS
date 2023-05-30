// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Extensions;
using EdFi.Ods.Tests._Helpers;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
{
    [TestFixture]
    public class NamespaceBasedAuthorizationStrategyTests
    {
        [TestFixture]
        public class SingleItemAuthorizationTests
        {
            [Test]
            public void AuthorizationContextNamespaceIsEmpty_ShouldThrowAnException()
            {
                //Arrange
                var filterDefinitionsFactory = new NamespaceBasedAuthorizationFilterDefinitionsFactory(A.Fake<IDatabaseNamingConvention>());

                var namespacePrefixes = new[]
                {
                    @"uri://ed-fi.org/",
                    @"uri://ed-fi-2.org/"
                };
                var resource = new Resource("Ignored");
                string resourceUri = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
                string action = @"http://ed-fi.org/ods/actions/manage";

                var data = new NamespaceBasedAuthorizationContextData
                {
                    Namespace = @""
                };

                //Act
                var filterDefinition = filterDefinitionsFactory.CreateAuthorizationFilterDefinitions().Single();

                var result = filterDefinition.AuthorizeInstance(
                    new EdFiAuthorizationContext(
                        CreateApiClientContext(namespacePrefixes),
                        resource,
                        new[] { resourceUri },
                        action,
                        data),
                    new AuthorizationFilterContext());
            
                //Assert
                result.Exception.ShouldBeExceptionType<EdFiSecurityException>();
                result.Exception.Message.ShouldBe("Access to the resource item could not be authorized because the Namespace of the resource is empty.");
            }

            [Test]
            public void NonMatchingNamespaceClaims_ShouldThrowAnException()
            {
                //Arrange
                var filterDefinitionsFactory = new NamespaceBasedAuthorizationFilterDefinitionsFactory(A.Fake<IDatabaseNamingConvention>());

                var namespacePrefixes = new[]
                {
                    @"uri://ed-fi.org/",
                    @"uri://ed-fi-2.org/"
                };

                var resource = new Resource("Ignored");
                string resourceUri = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
                string action = @"http://ed-fi.org/ods/actions/manage";

                var data = new NamespaceBasedAuthorizationContextData
                {
                    Namespace = @"uri://www.TEST.org/"
                };

                //Act
                var filterDefinition = filterDefinitionsFactory.CreateAuthorizationFilterDefinitions().Single();

                var result = filterDefinition.AuthorizeInstance(
                    new EdFiAuthorizationContext(
                        CreateApiClientContext(namespacePrefixes),
                        resource,
                        new[] { resourceUri },
                        action,
                        data),
                    new AuthorizationFilterContext());

                //Assert
                result.Exception.ShouldBeExceptionType<EdFiSecurityException>();
                result.Exception.Message.ShouldBe("Access to the resource item could not be authorized based on the caller's NamespacePrefix claims: 'uri://ed-fi.org/', 'uri://ed-fi-2.org/'.");
            }
        }

        [TestFixture]
        public class AuthorizationFilteringTests
        {
            [Test]
            public void EmptyNamespaceClaims_ShouldThrowAnException()
            {
                //Arrange
                var resource = new Resource("Ignored");
                
                var strategy = new NamespaceBasedAuthorizationStrategy();

                var namespacePrefixes = new[] { "", "" };

                string resourceUri = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
                string action = @"http://ed-fi.org/ods/actions/manage";

                var data = new NamespaceBasedAuthorizationContextData
                {
                    Namespace = @"uri://ed-fi.org/"
                };

                //Act
                var exception = Assert.Throws<EdFiSecurityException>(
                    () => strategy.GetAuthorizationStrategyFiltering(
                        Array.Empty<EdFiResourceClaim>(),
                        new EdFiAuthorizationContext(
                            CreateApiClientContext(namespacePrefixes),
                            resource,
                            new[] { resourceUri },
                            action,
                            data)));

                //Assert
                exception.Message.ShouldBe(
                    "Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('"
                    + EdFiOdsApiClaimTypes.NamespacePrefix + "') or the claim values were all empty.");
            }

            [Test]
            public void ClaimsMatchNamespaceWithoutPrefix_ShouldNotThrowAnException()
            {
                //Arrange
                var domainModel = this.LoadDomainModel("ClaimsMatchNamespaceWithoutPrefix");

                var resource = domainModel.ResourceModel.GetAllResources().Single();

                var strategy = new NamespaceBasedAuthorizationStrategy();

                var namespacePrefixes = new[]
                {
                    @"uri://ed-fi.org/",
                    @"uri://ed-fi-2.org/"
                };

                string resourceUri = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
                string action = @"http://ed-fi.org/ods/actions/manage";

                var data = new NamespaceBasedAuthorizationContextData
                {
                    Namespace = @"uri://ed-fi.org/One/Two/Three"
                };

                //Act
                strategy.GetAuthorizationStrategyFiltering(
                    Array.Empty<EdFiResourceClaim>(),
                    new EdFiAuthorizationContext(
                        CreateApiClientContext(namespacePrefixes),
                        resource,
                        new[] { resourceUri },
                        action,
                        data));

                //Assert
                // No exception
            }

            [Test]
            public void ClaimsMatchNamespaceWithPrefix_ShouldNotThrowAnException()
            {
                var domainModel = this.LoadDomainModel("ClaimsMatchNamespaceWithoutPrefix");

                //Arrange
                var resource = domainModel.ResourceModel.GetAllResources().Single();

                var strategy = new NamespaceBasedAuthorizationStrategy();

                var namespacePrefixes = new[]
                {
                    @"uri://ed-fi.org/",
                    @"uri://ed-fi-2.org/"
                };

                string resourceUri = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
                string action = @"http://ed-fi.org/ods/actions/manage";

                var data = new NamespaceBasedAuthorizationContextData
                {
                    Namespace = @"uri://ed-fi.org/One/Two/Three"
                };

                //Act
                strategy.GetAuthorizationStrategyFiltering(
                    Array.Empty<EdFiResourceClaim>(),
                    new EdFiAuthorizationContext(
                        CreateApiClientContext(namespacePrefixes),
                        resource,
                        new[] { resourceUri },
                        action,
                        data));

                //Assert
            }

            [Test]
            public void NoNamespacePropertyPresent_ShouldThrowAnException()
            {
                //Arrange
                var domainModel = this.LoadDomainModel("NoNamespacePropertyPresent");

                var resource = domainModel.ResourceModel.GetAllResources().Single();
                var requestContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
                A.CallTo(() => requestContextProvider.Get()).Returns(new DataManagementResourceContext(resource));

                var strategy = new NamespaceBasedAuthorizationStrategy();

                var namespacePrefixes = new[]
                {
                    @"uri://ed-fi.org/",
                    @"uri://ed-fi-2.org/"
                };

                string resourceUri = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
                string action = @"http://ed-fi.org/ods/actions/manage";

                var data = new NamespaceBasedAuthorizationContextData
                {
                    Namespace = @"uri://ed-fi.org/One/Two/Three"
                };

                //Act
                Should.Throw<Exception>(
                        () => strategy.GetAuthorizationStrategyFiltering(
                            Array.Empty<EdFiResourceClaim>(),
                            new EdFiAuthorizationContext(
                                CreateApiClientContext(namespacePrefixes),
                                resource,
                                new[] { resourceUri },
                                action,
                                data)))
                    .MessageShouldContain(
                        "There is no Namespace-based property in the 'edfi.TestResource' resource to use for Namespace-based authorization.");

                //Assert
            }

            [Test]
            public void NoNamespaceClaims_ShouldThrowAnException()
            {
                //Arrange
                var resource = new Resource("Ignored");

                var strategy = new NamespaceBasedAuthorizationStrategy();

                string resourceUri = @"http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor";
                string action = @"http://ed-fi.org/ods/actions/manage";

                var data = new NamespaceBasedAuthorizationContextData
                {
                    Namespace = @"uri://ed-fi.org/One/Two/Three"
                };

                //Act

                var exception = Assert.Throws<EdFiSecurityException>(
                    () => strategy.GetAuthorizationStrategyFiltering(
                        Array.Empty<EdFiResourceClaim>(),
                        new EdFiAuthorizationContext(
                            new ApiClientContext(),
                            resource,
                            new[] { resourceUri },
                            action,
                            data)));

                // Assert
                exception.Message.ShouldBe(
                    "Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('"
                    + EdFiOdsApiClaimTypes.NamespacePrefix + "') or the claim values were all empty.");
            }
        }
        
        private static ApiClientContext CreateApiClientContext(string[] namespacePrefixes) => new(
            null, 
            null,
            null,
            namespacePrefixes, 
            null,
            null,
            null,
            null,
            null,
            0);
    }
}