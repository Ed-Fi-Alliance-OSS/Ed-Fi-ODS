// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Extensions;
using EdFi.Ods.Tests._Helpers;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
{
    [TestFixture]
    public class NamespaceBasedAuthorizationStrategyTests
    {
        [TestFixture]
        public class SingleItemAuthorizationTests
        {
            [Test]
            [TestCase(AuthorizationPhase.ProposedData)]
            [TestCase(AuthorizationPhase.ExistingData)]
            public void AuthorizationContextNamespaceIsEmpty_ShouldThrowAnException(AuthorizationPhase authorizationPhase)
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
                        data,
                        authorizationPhase),
                    new AuthorizationFilterContext(),
                    "NamespaceBased");
            
                //Assert
                var exception = (SecurityAuthorizationException)result.Exception.ShouldBeExceptionType<SecurityAuthorizationException>();

                if (authorizationPhase == AuthorizationPhase.ProposedData)
                {
                    exception.Detail.ShouldContain("Access to the resource could not be authorized. The 'Namespace' value has not been assigned but is required for authorization purposes.");
                    exception.Type.ShouldBe($"{EdFiProblemDetailsExceptionBase.BaseTypePrefix}:security:authorization:namespace:access-denied:namespace-required");
                }
                else if (authorizationPhase == AuthorizationPhase.ExistingData)
                {
                    exception.Detail.ShouldContain("Access to the resource could not be authorized. The existing 'Namespace' value has not been assigned but is required for authorization purposes.");
                    exception.Type.ShouldBe($"{EdFiProblemDetailsExceptionBase.BaseTypePrefix}:security:authorization:namespace:invalid-data:namespace-uninitialized");
                    exception.Message.ShouldContain($"The existing resource item is inaccessible to clients using the 'NamespaceBased' authorization strategy because the 'Namespace' value has not been assigned.");
                }
            }

            [Test]
            [TestCase(AuthorizationPhase.ProposedData)]
            [TestCase(AuthorizationPhase.ExistingData)]
            public void NonMatchingNamespaceClaims_ShouldThrowAnException(AuthorizationPhase authorizationPhase)
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
                        data,
                        authorizationPhase),
                    new AuthorizationFilterContext(),
                    "NamespaceBased");

                //Assert
                var exception = (SecurityAuthorizationException)result.Exception.ShouldBeExceptionType<SecurityAuthorizationException>();
                exception.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "security:authorization:namespace:access-denied:namespace-mismatch"));

                string existingLiteral = authorizationPhase == AuthorizationPhase.ExistingData ? "existing " : string.Empty;
                exception.Detail.ShouldContain($"Access to the resource could not be authorized. The {existingLiteral}'Namespace' value of the resource does not start with any of the caller's associated namespace prefixes ('uri://ed-fi.org/', 'uri://ed-fi-2.org/').");
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
                var exception = Assert.Throws<SecurityAuthorizationException>(
                    () => strategy.GetAuthorizationStrategyFiltering(
                        Array.Empty<EdFiResourceClaim>(),
                        new EdFiAuthorizationContext(
                            CreateApiClientContext(namespacePrefixes),
                            resource,
                            new[] { resourceUri },
                            action,
                            data,
                            AuthorizationPhase.ProposedData)));

                //Assert

                exception.Detail.ShouldContain("There was a problem authorizing the request. The caller has not been configured correctly for accessing resources authorized by Namespace.");
                exception.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "security:authorization:namespace:invalid-client:no-namespaces"));
                exception.Message.ShouldContain(
                    "The API client has been given permissions on a resource that uses the 'NamespaceBased' authorization strategy but the client doesn't have any namespace prefixes assigned.");
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
                        data,
                        AuthorizationPhase.ProposedData));

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
                        data,
                        AuthorizationPhase.ProposedData));

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
                                data,
                                AuthorizationPhase.ProposedData)))
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

                var exception = Assert.Throws<SecurityAuthorizationException>(
                    () => strategy.GetAuthorizationStrategyFiltering(
                        Array.Empty<EdFiResourceClaim>(),
                        new EdFiAuthorizationContext(
                            new ApiClientContext(),
                            resource,
                            new[] { resourceUri },
                            action,
                            data,
                            AuthorizationPhase.ProposedData)));

                // Assert
                exception.Detail.ShouldContain("There was a problem authorizing the request. The caller has not been configured correctly for accessing resources authorized by Namespace.");
                exception.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "security:authorization:namespace:invalid-client:no-namespaces"));
                exception.Message.ShouldContain(
                    "The API client has been given permissions on a resource that uses the 'NamespaceBased' authorization strategy but the client doesn't have any namespace prefixes assigned.");
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