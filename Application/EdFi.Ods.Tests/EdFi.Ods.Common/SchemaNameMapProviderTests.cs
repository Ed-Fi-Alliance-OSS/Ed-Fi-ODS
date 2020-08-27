// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Tests._Extensions;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common
{
    [TestFixture]
    public class SchemaNameMapProviderTests
    {
        protected string Result;

        private static SchemaNameMapProvider GetSchemaNameMapProvider(string logicalSchemaName, string physicalSchemaName)
        {
            var domainModelDefinitionsProvider = MockRepository.GenerateStub<IDomainModelDefinitionsProvider>();

            domainModelDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                          .Return(
                                               new DomainModelDefinitions(
                                                   new SchemaDefinition(logicalSchemaName, physicalSchemaName),
                                                   new AggregateDefinition[0],
                                                   new EntityDefinition[0],
                                                   new AssociationDefinition[0]));

            // Add a second schema to demonstrate correct matching with multiple schema entries
            var domainModelDefinitionsProvider2 = MockRepository.GenerateStub<IDomainModelDefinitionsProvider>();

            domainModelDefinitionsProvider2.Stub(x => x.GetDomainModelDefinitions())
                                           .Return(
                                                new DomainModelDefinitions(
                                                    new SchemaDefinition("AnotherSchema", "another"),
                                                    new AggregateDefinition[0],
                                                    new EntityDefinition[0],
                                                    new AssociationDefinition[0]));

            var schemaDefinitions =
                new DomainModelProvider(
                        new[]
                        {
                            domainModelDefinitionsProvider, domainModelDefinitionsProvider2
                        })
                   .GetDomainModel()
                   .Schemas;

            return new SchemaNameMapProvider(schemaDefinitions);
        }

        public class When_mapping_schema_names : LegacyTestFixtureBase
        {
            private string _suppliedPhysicalName;
            private string _suppliedLogicalName;
            private SchemaNameMap _actualSchemaNameMapByPhysicalName;
            private SchemaNameMap _actualSchemaNameMapByLogicalName;
            private SchemaNameMap _actualSchemaNameMapByProperCaseName;
            private SchemaNameMap _actualSchemaNameMapByUriSegment;

            protected override void Act()
            {
                _suppliedLogicalName = "Logical Name";
                _suppliedPhysicalName = "PhysicalName";

                var provider = GetSchemaNameMapProvider(_suppliedLogicalName, _suppliedPhysicalName);

                _actualSchemaNameMapByPhysicalName = provider.GetSchemaMapByPhysicalName(_suppliedPhysicalName);
                _actualSchemaNameMapByLogicalName = provider.GetSchemaMapByLogicalName(_suppliedLogicalName);
                _actualSchemaNameMapByProperCaseName = provider.GetSchemaMapByProperCaseName(_actualSchemaNameMapByPhysicalName.ProperCaseName);
                _actualSchemaNameMapByUriSegment = provider.GetSchemaMapByUriSegment(_actualSchemaNameMapByLogicalName.UriSegment);
            }

            [Assert]
            public void Should_map_all_names_to_and_from_each_other()
            {
                AssertHelper.All(

                    // Exact match checks
                    () => Assert.That(
                        _actualSchemaNameMapByLogicalName,
                        Is.SameAs(_actualSchemaNameMapByPhysicalName)),
                    () => Assert.That(
                        _actualSchemaNameMapByLogicalName,
                        Is.SameAs(_actualSchemaNameMapByProperCaseName)),
                    () => Assert.That(
                        _actualSchemaNameMapByLogicalName,
                        Is.SameAs(_actualSchemaNameMapByUriSegment))
                );
            }
        }

        public class When_mapping_schema_names_based_on_a_mixed_cased_hyphenated_logical_name : LegacyTestFixtureBase
        {
            private SchemaNameMap _actualSchemaNameMapByLogicalName;

            protected override void Act()
            {
                string suppliedLogicalName = "Hyphen-Ated";
                string suppliedPhysicalName = "hyph";

                var provider = GetSchemaNameMapProvider(suppliedLogicalName, suppliedPhysicalName);

                _actualSchemaNameMapByLogicalName = provider.GetSchemaMapByLogicalName(suppliedLogicalName);
            }

            [Assert]
            public void Should_create_ProperCaseName_by_converting_to_proper_casing_and_removing_hyphens()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.ProperCaseName, Is.EqualTo("HyphenAted"));
            }

            [Assert]
            public void Should_create_UriSegment_by_converting_to_lower_case_while_retaining_hyphens()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.UriSegment, Is.EqualTo("hyphen-ated"));
            }
        }

        public class When_mapping_schema_names_based_on_a_lower_cased_hyphenated_logical_name : LegacyTestFixtureBase
        {
            private SchemaNameMap _actualSchemaNameMapByLogicalName;

            protected override void Act()
            {
                string suppliedLogicalName = "hyphen-ated";
                string suppliedPhysicalName = "hyph";

                var provider = GetSchemaNameMapProvider(suppliedLogicalName, suppliedPhysicalName);

                _actualSchemaNameMapByLogicalName = provider.GetSchemaMapByLogicalName(suppliedLogicalName);
            }

            [Assert]
            public void Should_create_ProperCaseName_by_converting_to_proper_casing_and_removing_hyphens()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.ProperCaseName, Is.EqualTo("HyphenAted"));
            }

            [Assert]
            public void Should_create_UriSegment_by_converting_to_lower_case_while_retaining_hyphens()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.UriSegment, Is.EqualTo("hyphen-ated"));
            }
        }

        public class When_mapping_schema_names_based_on_a_logical_name_containing_spaces : LegacyTestFixtureBase
        {
            private SchemaNameMap _actualSchemaNameMapByLogicalName;

            protected override void Act()
            {
                string suppliedLogicalName = "Spaced out Logical name";
                string suppliedPhysicalName = "spacey";

                var provider = GetSchemaNameMapProvider(suppliedLogicalName, suppliedPhysicalName);

                _actualSchemaNameMapByLogicalName = provider.GetSchemaMapByLogicalName(suppliedLogicalName);
            }

            [Assert]
            public void Should_create_ProperCaseName_by_converting_to_proper_casing_and_removing_spaces()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.ProperCaseName, Is.EqualTo("SpacedOutLogicalName"));
            }

            [Assert]
            public void Should_create_UriSegment_by_converting_to_lower_case_and_replacing_spaces_with_hyphens()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.UriSegment, Is.EqualTo("spaced-out-logical-name"));
            }
        }

        public class When_mapping_schema_names_based_on_a_logical_name_that_looks_like_a_state_abbreviation : LegacyTestFixtureBase
        {
            private SchemaNameMap _actualSchemaNameMapByLogicalName;

            protected override void Act()
            {
                string suppliedLogicalName = "TX";
                string suppliedPhysicalName = "texas";

                var provider = GetSchemaNameMapProvider(suppliedLogicalName, suppliedPhysicalName);

                _actualSchemaNameMapByLogicalName = provider.GetSchemaMapByLogicalName(suppliedLogicalName);
            }

            [Assert]
            public void Should_create_ProperCaseName_using_DotNet_conventions_for_two_letter_abbreviations_of_leaving_them_upper_cased()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.ProperCaseName, Is.EqualTo("TX"));
            }

            [Assert]
            public void Should_create_UriSegment_by_retaining_the_original_value()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.UriSegment, Is.EqualTo("TX"));
            }
        }

        public class When_mapping_schema_names_based_on_a_logical_name_with_a_single_character_name : LegacyTestFixtureBase
        {
            private SchemaNameMap _actualSchemaNameMapByLogicalName;

            protected override void Act()
            {
                string suppliedLogicalName = "X";
                string suppliedPhysicalName = "x";

                var provider = GetSchemaNameMapProvider(suppliedLogicalName, suppliedPhysicalName);

                _actualSchemaNameMapByLogicalName = provider.GetSchemaMapByLogicalName(suppliedLogicalName);
            }

            [Assert]
            public void Should_create_ProperCaseName_by_converting_to_proper_casing()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.ProperCaseName, Is.EqualTo("X"));
            }

            [Assert]
            public void Should_create_UriSegment_by_converting_to_lower_case()
            {
                Assert.That(_actualSchemaNameMapByLogicalName.UriSegment, Is.EqualTo("x"));
            }
        }

        public class When_initializing_the_schema_name_map_provider_with_a_null_logical_name : LegacyTestFixtureBase
        {
            protected override void Act()
            {
                var provider = GetSchemaNameMapProvider(null, "physical");
            }

            [Assert]
            public void Should_throw_an_exception()
            {
                ActualException.ShouldBeExceptionType<ArgumentNullException>();
            }
        }

        public class When_initializing_the_schema_name_map_provider_with_an_empty_logical_name : LegacyTestFixtureBase
        {
            protected override void Act()
            {
                var provider = GetSchemaNameMapProvider(string.Empty, "physical");
            }

            [Assert]
            public void Should_throw_an_exception()
            {
                ActualException.ShouldBeExceptionType<ArgumentException>();
            }
        }

        public class When_initializing_the_schema_name_map_provider_with_a_null_physical_name : LegacyTestFixtureBase
        {
            protected override void Act()
            {
                var provider = GetSchemaNameMapProvider("Logical", null);
            }

            [Assert]
            public void Should_throw_an_exception()
            {
                ActualException.ShouldBeExceptionType<ArgumentNullException>();
            }
        }

        public class When_initializing_the_schema_name_map_provider_with_an_empty_physical_name : LegacyTestFixtureBase
        {
            protected override void Act()
            {
                var provider = GetSchemaNameMapProvider("Logical", string.Empty);
            }

            [Assert]
            public void Should_throw_an_exception()
            {
                ActualException.ShouldBeExceptionType<ArgumentException>();
            }
        }
    }
}
