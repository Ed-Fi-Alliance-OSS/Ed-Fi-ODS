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
using EdFi.Ods.Api.NHibernate;
using EdFi.Ods.Api.NHibernate.Composites;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Common.Composites;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Repositories;
using EdFi.Ods.Security.Claims;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using Test.Common._Stubs;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization.Repositories
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
                Given<IEdFiAuthorizationProvider>(
                    new FakeAuthorizationProvider(
                        SuppliedFilterName,
                        SuppliedParameterName,
                        SuppliedParameterValue));

                var suppliedFilterText = $"TheField = :{SuppliedParameterName}";

                A.CallTo(() => 
                    Given<INHibernateFilterTextProvider>()
                    .TryGetHqlFilterText(
                                A<Type>.Ignored,
                                A<string>.Ignored,
                                out suppliedFilterText))
                    .Returns(true);

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
                    EducationOrganizationIds = new List<int>
                    {
                        123,
                        234
                    }
                };

                var claimsIdentity = claimsIdentityProvider.GetClaimsIdentity(
                    apiClientDetails.EducationOrganizationIds,
                    apiClientDetails.ClaimSetName,
                    apiClientDetails.NamespacePrefixes,
                    apiClientDetails.Profiles.ToList());

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
                    (Given<IEdFiAuthorizationProvider>() as FakeAuthorizationProvider)
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
                    Given<IEdFiAuthorizationProvider>()
                    .GetAuthorizationFilters(A<EdFiAuthorizationContext>.Ignored))
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

        private class FakeAuthorizationProvider : IEdFiAuthorizationProvider
        {
            private readonly string _filterName;
            private readonly string _parameterName;
            private readonly object _parameterValue;

            public FakeAuthorizationProvider(string filterName, string parameterName, object parameterValue)
            {
                _filterName = filterName;
                _parameterName = parameterName;
                _parameterValue = parameterValue;
            }

            public EdFiAuthorizationContext ActualAuthorizationContext { get; private set; }

            /// <summary>
            /// Authorizes a single-item request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
            /// </summary>
            /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
            public Task AuthorizeSingleItemAsync(
                EdFiAuthorizationContext authorizationContext,
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Authorizes a multiple-item read request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
            /// </summary>
            /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
            /// <param name="filterBuilder">A builder used to activate filters and assign parameter values.</param>
            /// <returns></returns>
            public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(EdFiAuthorizationContext authorizationContext)
            {
                ActualAuthorizationContext = authorizationContext;

                return new[]
                {
                    new AuthorizationFilterDetails
                    {
                        FilterName = _filterName,
                        ClaimEndpointName = _parameterName,
                        ClaimValues = new [] {_parameterValue}
                    }
                };
            }

            public bool TryAuthorizeResourceActionOnly(EdFiAuthorizationContext authorizationContext,
                out string securityExceptionMessage)
            {
                throw new NotImplementedException();
            }

            public void AuthorizeResourceActionOnly(EdFiAuthorizationContext authorizationContext)
            {
                throw new NotImplementedException();
            }
        }
    }
}
