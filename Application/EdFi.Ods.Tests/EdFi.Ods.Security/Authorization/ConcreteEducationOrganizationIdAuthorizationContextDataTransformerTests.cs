// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using EdFi.Ods.Api.Common.Exceptions;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Tests._Extensions;
using Rhino.Mocks;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
{
    public class Feature_Converting_EducationOrganizationId_to_appropriate_concrete_type
        : LegacyTestFixtureBase
    {
        private static IEducationOrganizationCache Given_a_cache_that_returns_all_identifiers_as_type(string educationOrganizationType)
        {
            var cache = MockRepository.GenerateStub<IEducationOrganizationCache>();

            cache.Stub(x => x.GetEducationOrganizationIdentifiers(Arg<int>.Is.Anything))
                 .Return(new EducationOrganizationIdentifiers(0, educationOrganizationType));

            return cache;
        }

        private static IEducationOrganizationCache Given_a_cache_that_returns_no_identifiers()
        {
            return MockRepository.GenerateStub<IEducationOrganizationCache>();
        }

        private static RelationshipsAuthorizationContextData Given_context_data_for_EducationOrganizationId_of_999()
        {
            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = 999;
            return contextData;
        }

        public class When_attempting_to_convert_a_context_with_a_null_education_organization_identifier : LegacyTestFixtureBase
        {
            // Supplied values
            private RelationshipsAuthorizationContextData _suppliedContextData;

            // Actual values
            private RelationshipsAuthorizationContextData _actualContextData;

            // Dependencies
            private IEducationOrganizationCache _educationOrganizationCache;

            protected override void Act()
            {
                // Execute code under test
                var transformer = new ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<RelationshipsAuthorizationContextData>(
                    _educationOrganizationCache = Given_a_cache_that_returns_no_identifiers());

                _suppliedContextData = new RelationshipsAuthorizationContextData();

                _actualContextData = transformer.GetConcreteAuthorizationContextData(_suppliedContextData);
            }

            [Assert]
            public void Should_return_same_instance()
            {
                _actualContextData.ShouldBeSameAs(_suppliedContextData);
            }

            [Assert]
            public void Should_not_try_to_look_the_identifier_up_in_the_cache()
            {
                _educationOrganizationCache.AssertWasNotCalled(
                    x =>
                        x.GetEducationOrganizationIdentifiers(Arg<int>.Is.Anything));
            }
        }

        public class When_converting_a_known_identifier_that_is_an_unhandled_type
            : LegacyTestFixtureBase
        {
            // Actual values
            protected RelationshipsAuthorizationContextData _actualContextData;

            protected override void Act()
            {
                // Execute code under test
                var transformer = new ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<RelationshipsAuthorizationContextData>(
                    Given_a_cache_that_returns_all_identifiers_as_type("SomethingUnhandled"));

                _actualContextData = transformer.GetConcreteAuthorizationContextData(
                    Given_context_data_for_EducationOrganizationId_of_999());
            }

            [Assert]
            public void Should_throw_a_NotSupportedException_indicating_the_type_is_not_handled()
            {
                ActualException.ShouldNotBeNull();
                ActualException.ShouldBeExceptionType<NotSupportedException>();
                ActualException.Message.ShouldContain("Unhandled");
            }
        }

        public class When_converting_an_unknown_identifier
            : LegacyTestFixtureBase
        {
            // Actual values
            protected RelationshipsAuthorizationContextData _actualContextData;

            protected override void Act()
            {
                // Execute code under test
                var transformer = new ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<RelationshipsAuthorizationContextData>(
                    Given_a_cache_that_returns_no_identifiers());

                _actualContextData = transformer.GetConcreteAuthorizationContextData(
                    Given_context_data_for_EducationOrganizationId_of_999());
            }

            [Assert]
            public void Should_throw_a_NotFoundException_indicating_the_identifer_could_not_be_found()
            {
                ActualException.ShouldNotBeNull();
                ActualException.ShouldBeExceptionType<NotFoundException>();
                ActualException.Message.ShouldContain("identifier");
                ActualException.Message.ShouldContain("could not be found");
            }
        }

        public abstract class When_converting_a_known_identifier_of_a_known_type
            : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values
            protected RelationshipsAuthorizationContextData _actualContextData;

            protected abstract string ConcreteEducationOrganizationType { get; }

            protected override void Act()
            {
                // Execute code under test
                var transformer = new ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<RelationshipsAuthorizationContextData>(
                    Given_a_cache_that_returns_all_identifiers_as_type(ConcreteEducationOrganizationType));

                _actualContextData = transformer.GetConcreteAuthorizationContextData(
                    Given_context_data_for_EducationOrganizationId_of_999());
            }

            [Assert]
            public void Should_clear_the_EducationOrganizationId_on_the_context()
            {
                _actualContextData.EducationOrganizationId.ShouldBeNull();
            }

            [Assert]
            public void Should_set_the_concrete_identifier_value_on_the_context_data()
            {
                var values = _actualContextData.ToDictionary();

                object concreteValue;

                values.TryGetValue(ConcreteEducationOrganizationType + "Id", out concreteValue)
                      .ShouldBeTrue(string.Format("Unable to find property '{0}'Id.", ConcreteEducationOrganizationType));

                concreteValue.ShouldBe(999);
            }

            [Assert]
            public void Should_not_set_any_other_values_on_the_context()
            {
                (from p in _actualContextData.GetType()
                                             .GetProperties()
                 where p.Name != ConcreteEducationOrganizationType + "Id"
                       && p.Name != "ConcreteEducationOrganizationIdPropertyName"
                 select p.GetValue(_actualContextData))
                   .All(x => x == null)
                   .ShouldBeTrue("One or more properties on the context data was set.  They should be null.");
            }
        }

        public class WhenConvertingAKnownIdentifierOfAKnownTypeThatIsAStateEducationAgency
            : When_converting_a_known_identifier_of_a_known_type
        {
            protected override string ConcreteEducationOrganizationType
            {
                get { return "StateEducationAgency"; }
            }
        }

        public class WhenConvertingAKnownIdentifierOfAKnownTypeThatIsAnEducationServiceCenter
            : When_converting_a_known_identifier_of_a_known_type
        {
            protected override string ConcreteEducationOrganizationType
            {
                get { return "EducationServiceCenter"; }
            }
        }

        public class WhenConvertingAKnownIdentifierOfAKnownTypeThatIsALocalEducationAgency
            : When_converting_a_known_identifier_of_a_known_type
        {
            protected override string ConcreteEducationOrganizationType
            {
                get { return "LocalEducationAgency"; }
            }
        }

        public class WhenConvertingAKnownIdentifierOfAKnownTypeThatIsASchool
            : When_converting_a_known_identifier_of_a_known_type
        {
            protected override string ConcreteEducationOrganizationType
            {
                get { return "School"; }
            }
        }

        public class WhenConvertingAKnownIdentifierOfAKnownTypeThatIsAnEducationOrganizationNetwork
            : When_converting_a_known_identifier_of_a_known_type
        {
            protected override string ConcreteEducationOrganizationType
            {
                get { return "EducationOrganizationNetwork"; }
            }
        }
    }
}
