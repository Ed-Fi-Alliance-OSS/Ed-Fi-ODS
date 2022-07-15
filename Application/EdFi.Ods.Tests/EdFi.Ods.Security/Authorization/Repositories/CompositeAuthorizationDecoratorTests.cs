// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Composites.Infrastructure;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.Claims;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using Test.Common._Stubs;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Repositories
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CompositeAuthorizationDecoratorTests
    {
        /// <summary>
        /// Creates a Student resource with the necessary Entity and Aggregate instances to obtain the correct name.
        /// </summary>
        /// <returns></returns>
        private static Resource CreateStudentResource()
        {
            var domainModelBuilder = new DomainModelBuilder();

            var schema = EdFiConventions.PhysicalSchemaName;

            var entityName = new FullName(schema, "Student");

            domainModelBuilder.AddAggregate(new AggregateDefinition(entityName, new FullName[0]));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    schema,
                    "Student",
                    new EntityPropertyDefinition[0],
                    new EntityIdentifierDefinition[0]));

            domainModelBuilder.AddSchema(new SchemaDefinition(EdFiConventions.LogicalName, schema));

            var domainModel = domainModelBuilder.Build();

            var resourceModel = new ResourceModel(domainModel);

            var entity = domainModel.EntityByFullName[entityName];

            // Create the Resource using the Entity
            var resource =
                (Resource)
                Activator.CreateInstance(
                    typeof(Resource),
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    new object[]
                    {
                        resourceModel,
                        entity
                    },
                    CultureInfo.CurrentCulture);

            return resource;
        }

        public class When_authorizing_a_request_that_passes_authorization : ScenarioFor<HqlBuilderAuthorizationDecorator>
        {
            private const string SuppliedFilterName = "StudentFilter";
            private const string SuppliedParameterName = "TheParameter";
            private const string SuppliedParameterValue = "TheValue";

            private bool _actualInclusionResult;

            private EdFiAuthorizationContext _actualAuthorizationContext;
            private HqlBuilderContext _hqlBuilderContext;
            private CompositeDefinitionProcessorContext _processorContext;
            private ClaimsPrincipal _expectedClaimsPrincipal;

            /// <summary>
            /// Prepares the state of the scenario (creating stubs, test data, etc.).
            /// </summary>
            protected override void Arrange()
            {
                Given<IAuthorizationFilteringProvider>(
                    new FakeAuthorizationFilteringProvider(
                        SuppliedFilterName,
                        SuppliedParameterName,
                        SuppliedParameterValue));

                var suppliedFilterText = $"TheField = :{SuppliedParameterName}";

                A.CallTo(() => 
                        Given<IEducationOrganizationIdNamesProvider>()
                            .GetAllNames())
                            .Returns(Array.Empty<string>());

                AuthorizationFilterDefinition ignored;

                A.CallTo(
                        () => Given<IAuthorizationFilterDefinitionProvider>()
                            .TryGetAuthorizationFilterDefinition(SuppliedFilterName, out ignored))
                    .Returns(true)
                    .AssignsOutAndRefParameters(
                        new AuthorizationFilterDefinition(
                            SuppliedFilterName,
                            // This is how the HQL filter text is now obtained (with elimination of the INHibernateFilterTextProvider) 
                            suppliedFilterText,
                            (criteria, junction, arg3, arg4, arg5) => { },
                            (filterDefinition, filterContext, resource, filterIndex, qb, useOuterJoins) => { },
                            (ctx1, ctx2) => null));

                Supplied("ResourceUriValue", "uri://some-value");

                A.CallTo(() =>
                        Given<IResourceClaimUriProvider>()
                            .GetResourceClaimUris(A<Resource>.Ignored))
                    .Returns(new[] {Supplied<string>("ResourceUriValue")});

                var claimsIdentityProvider = new ClaimsIdentityProvider(
                    new ApiKeyContextProvider(new CallContextStorage()),
                    new StubSecurityRepository());

                var apiClientDetails = new ApiClientDetails
                {
                    ApiKey = Guid.NewGuid()
                        .ToString("n"),
                    ApplicationId = 999,
                    ClaimSetName = "SomeClaimSet",
                    NamespacePrefixes = new List<string> {"Namespace"},
                    EducationOrganizationIds = new[] { 123, 234 },
                    OwnershipTokenIds = new List<short?> { 1 }
                };

                var claimsIdentity = claimsIdentityProvider.GetClaimsIdentity(
                    apiClientDetails.EducationOrganizationIds,
                    apiClientDetails.ClaimSetName,
                    apiClientDetails.NamespacePrefixes,
                    apiClientDetails.Profiles.ToList(),
                    apiClientDetails.OwnershipTokenIds.ToList());

                _expectedClaimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                ClaimsPrincipal.ClaimsPrincipalSelector = () => _expectedClaimsPrincipal;

                Resource resource = CreateStudentResource();

                // Create the builder context
                _hqlBuilderContext = new HqlBuilderContext(
                    new StringBuilder(),
                    new StringBuilder(),
                    new StringBuilder(),
                    new StringBuilder(),
                    new Dictionary<string, object>(),
                    null,
                    0,
                    new Dictionary<string, CompositeSpecificationParameter>(),
                    new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase),
                    new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase),
                    new AliasGenerator());

                // Create the processor context
                _processorContext = new CompositeDefinitionProcessorContext(
                    null,
                    null,
                    new XElement("BaseResource"),
                    resource,
                    null,
                    null,
                    null,
                    int.MinValue,
                    null);
            }

            /// <summary>
            /// Executes the code to be exercised for the scenario.
            /// </summary>
            protected override void Act()
            {
                // Run initial authorization check
                _actualInclusionResult = SystemUnderTest.TryIncludeResource(_processorContext, _hqlBuilderContext);

                CompositeQuery buildResult;

                // Build result for the root resource, applying filters to the builder context
                SystemUnderTest.TryBuildForRootResource(
                    _hqlBuilderContext,
                    _processorContext,
                    out buildResult);

                _actualAuthorizationContext =
                    (Given<IAuthorizationFilteringProvider>() as FakeAuthorizationFilteringProvider)
                    .ActualAuthorizationContext;
            }

            [Assert]
            public void Should_indicate_resource_should_be_included()
            {
                Assert.That(_actualInclusionResult, Is.True);
            }

            [Assert]
            public void
                Should_attempt_to_authorize_the_request_with_the_authorization_context_referencing_the_corresponding_NHibernate_entity_type()
            {
                Assert.That(_actualAuthorizationContext.Type, Is.SameAs(typeof(Student)));
            }

            [Assert]
            public void
                Should_attempt_to_authorize_the_request_with_the_authorization_context_referencing_the_current_claims_principal()
            {
                Assert.That(_actualAuthorizationContext.Principal, Is.SameAs(_expectedClaimsPrincipal));
            }

            [Assert]
            public void
                Should_attempt_to_authorize_the_request_with_the_authorization_context_with_the_corresponding_resource_URI()
            {
                Assert.That(
                    _actualAuthorizationContext.Resource.Single()
                        .Value,
                    Is.EqualTo(Supplied<string>("ResourceUriValue")));
            }

            [Assert]
            public void Should_attempt_to_authorize_the_request_with_the_authorization_context_with_the_Read_action_URI()
            {
                Assert.That(
                    _actualAuthorizationContext.Action.Single()
                        .Value,
                    Is.EqualTo("http://ed-fi.org/odsapi/actions/read"));
            }

            [Assert]
            public void Should_apply_the_supplied_filter_and_parameter_values_to_the_builder_context_for_subsequent_inclusion_at_execution_of_the_query()
            {
                Assert.That(_hqlBuilderContext.CurrentQueryFilterParameterValueByName, Has.Count.EqualTo(1));

                Assert.That(_hqlBuilderContext.CurrentQueryFilterParameterValueByName.Keys, Is.EquivalentTo(new [] { SuppliedParameterName }));

                Assert.That(
                    _hqlBuilderContext.CurrentQueryFilterParameterValueByName[SuppliedParameterName],
                    Is.EqualTo(SuppliedParameterValue));
            }
        }

        public class When_authorizing_a_request_that_fails_authorization : ScenarioFor<HqlBuilderAuthorizationDecorator>
        {
            // private bool? _actualInclusionResult;

            /// <summary>
            /// Prepares the state of the scenario (creating stubs, test data, etc.).
            /// </summary>
            protected override void Arrange()
            {
                A.CallTo(() =>
                        Given<IAuthorizationFilteringProvider>()
                            .GetAuthorizationFiltering(A<EdFiAuthorizationContext>.Ignored, A<AuthorizationBasisMetadata>.Ignored))
                    .Throws(new EdFiSecurityException("Test exception"));
            }

            /// <summary>
            /// Executes the code to be exercised for the scenario.
            /// </summary>
            protected override void Act()
            {
                Resource resource = CreateStudentResource();

                // Create the builder context
                var hqlBuilderContext = new HqlBuilderContext(
                    new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder());

                // Create the processor context
                var processorContext = new CompositeDefinitionProcessorContext(
                    null,
                    null,
                    new XElement("BaseResource"),
                    resource,
                    null,
                    null,
                    null,
                    int.MinValue,
                    null);

                SystemUnderTest.TryIncludeResource(processorContext, hqlBuilderContext);
            }

            [Assert]
            public void Should_throw_a_security_exception()
            {
                ActualException.ShouldBeOfType<EdFiSecurityException>();
            }
        }

        private class FakeAuthorizationFilteringProvider : IAuthorizationFilteringProvider
        {
            private readonly string _filterName;
            private readonly string _parameterName;
            private readonly object _parameterValue;

            public FakeAuthorizationFilteringProvider(string filterName, string parameterName, object parameterValue)
            {
                _filterName = filterName;
                _parameterName = parameterName;
                _parameterValue = parameterValue;
            }

            public EdFiAuthorizationContext ActualAuthorizationContext { get; private set; }

            /// <summary>
            /// Authorizes a multiple-item read request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
            /// </summary>
            /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
            /// <param name="authorizationBasisMetadata"></param>
            /// <returns></returns>
            public IReadOnlyList<AuthorizationStrategyFiltering> GetAuthorizationFiltering(EdFiAuthorizationContext authorizationContext, AuthorizationBasisMetadata authorizationBasisMetadata)
            {
                ActualAuthorizationContext = authorizationContext;

                return new[]
                {
                    new AuthorizationStrategyFiltering()
                    {
                        AuthorizationStrategyName = "Test",
                        Filters = new[]
                        {
                            new AuthorizationFilterContext
                            {
                                FilterName = _filterName,
                                ClaimEndpointValues = new[] { _parameterValue },
                                ClaimParameterName = _parameterName
                            }
                        } 
                    }
                };
            }
        }
    }
}