// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Tests.TestExtension;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;
using StaffEntity = EdFi.Ods.Entities.NHibernate.StaffAggregate.EdFi.Staff;
using StaffResource = EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Staff;
using StaffAddressResource = EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.StaffAddress;
using StaffProfileResource = EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Writable.Staff;
using StaffAddressProfileResource = EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Readable.StaffAddress;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Conventions
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ExtensionsConventionsTests
    {
        public class When_getting_extension_resource_class_assembly_qualified_name : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;

            protected override void Arrange()
            {
                _expectedResult = Namespaces.Resources.BaseNamespace + ".TalentMgmt.EdFi.Extensions.Staff.TestStaffExtension, " +
                                  Namespaces.Extensions.BaseNamespace + ".Staff";
            }

            protected override void Act()
            {
                string extensionName = "Staff";

                _actualResult = ExtensionsConventions.GetExtensionResourceClassAssemblyQualifiedName(extensionName, "TalentMgmt", "TestStaff");
            }

            [Test]
            public void Should_return_resource_class_assembly_qualified_name()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_getting_extension_class_assembly_qualified_name_and_edFiStandardType_is_an_edfi_entity : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;
            private readonly string _entityName = "Staff";
            private readonly string _extensionName = "GrandBend";

            protected override void Arrange()
            {
                _expectedResult =
                    $"{Namespaces.Entities.NHibernate.BaseNamespace}.{_entityName}Aggregate.{_extensionName}.{_entityName}Extension, {Namespaces.Extensions.BaseNamespace}.{_extensionName}";
            }

            protected override void Act()
            {
                _actualResult = ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(typeof(StaffEntity), "GrandBend");
            }

            [Test]
            public void Should_return_correctly_constructed_extension_class_assembly_qualified_name_for_edfi_entity_and_extension_provided()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class
            When_getting_extension_class_assembly_qualified_name_and_edFiStandardType_is_an_edfi_resource_not_within_a_profile_assembly :
                TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;
            private readonly string _entityName = "Staff";
            private readonly string _extensionName = "GrandBend";

            protected override void Arrange()
            {
                _expectedResult =
                    $@"{Namespaces.Resources.BaseNamespace}.{_entityName}.{EdFiConventions.ProperCaseName}.Extensions.{_extensionName}.{_entityName}Extension, {Namespaces.Extensions.BaseNamespace}.{_extensionName}";
            }

            protected override void Act()
            {
                _actualResult = ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(typeof(StaffResource), "GrandBend");
            }

            [Test]
            public void Should_return_correctly_constructed_extension_class_assembly_qualified_name_for_edfi_resource_and_extension_provided()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class
            When_getting_extension_class_assembly_qualified_name_and_edFiStandardType_is_an_edfi_child_resource_not_within_a_profile_assembly :
                TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;
            private readonly string _entityName = "StaffAddress";
            private readonly string _aggregateRootName = "Staff";
            private readonly string _extensionName = "GrandBend";

            protected override void Arrange()
            {
                _expectedResult =
                    $@"{Namespaces.Resources.BaseNamespace}.{_aggregateRootName}.{EdFiConventions.ProperCaseName}.Extensions.{_extensionName}.{_entityName}Extension, {Namespaces.Extensions.BaseNamespace}.{_extensionName}";
            }

            protected override void Act()
            {
                _actualResult = ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(typeof(StaffAddressResource), "GrandBend");
            }

            [Test]
            public void Should_return_correctly_constructed_extension_class_assembly_qualified_name_for_edfi_resource_and_extension_provided()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class
            When_getting_extension_class_assembly_qualified_name_and_edFiStandardType_is_an_edfi_resource_within_a_profile_assembly : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;
            private readonly string _entityName = "Staff";
            private readonly string _extensionName = "GrandBend";
            private readonly string _edFiName = "EdFi";

            protected override void Arrange()
            {
                _expectedResult =
                    $@"{Namespaces.Resources.BaseNamespace}.{_entityName}.{_edFiName}.Test_Profile_StaffOnly_Resource_IncludeAll_Writable.Extensions.{_extensionName}.{_entityName}Extension, EdFi.Ods.Profiles.Test";
            }

            protected override void Act()
            {
                _actualResult = ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(typeof(StaffProfileResource), "GrandBend");
            }

            [Test]
            public void Should_return_correctly_constructed_extension_class_assembly_qualified_name_for_edfi_profile_resource_and_extension_provided()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class
            When_getting_extension_class_assembly_qualified_name_and_edFiStandardType_is_an_edfi_child_resource_within_a_profile_assembly :
                TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;
            private readonly string _entityName = "StaffAddress";
            private readonly string _aggregateRootName = "Staff";
            private readonly string _extensionName = "GrandBend";
            private readonly string _edFiName = "EdFi";

            protected override void Arrange()
            {
                _expectedResult =
                    $@"{Namespaces.Resources.BaseNamespace}.{_aggregateRootName}.{_edFiName}.Test_Profile_StaffOnly_Resource_IncludeAll_Readable.Extensions.{_extensionName}.{_entityName}Extension, EdFi.Ods.Profiles.Test";
            }

            protected override void Act()
            {
                _actualResult = ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(typeof(StaffAddressProfileResource), "GrandBend");
            }

            [Test]
            public void Should_return_correctly_constructed_extension_class_assembly_qualified_name_for_edfi_profile_resource_and_extension_provided()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class
            When_checking_if_an_assembly_is_an_extension_assembly_and_assembly_full_name_is_prefixed_with_extension_assembly_namespace_prefix :
                TestFixtureBase
        {
            private Assembly _extensionAssembly;
            private bool _actualResult;

            protected override void Arrange()
            {
                _extensionAssembly = new ExtensionAssembly();
            }

            protected override void Act()
            {
                _actualResult = _extensionAssembly.IsExtensionAssembly();
            }

            [Test]
            public void Should_return_true()
            {
                Assert.That(_actualResult, Is.True);
            }
        }

        private class ExtensionAssembly : Assembly
        {
            public override string FullName
                => $"{Namespaces.Extensions.BaseNamespace}.GrandBend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        }

        public class When_getting_proper_case_name_from_logical_name_containing_a_hyphen : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;

            protected override void Arrange()
            {
                _expectedResult = "EdFi";
            }

            protected override void Act()
            {
                string logicalName = "Ed-Fi";

                _actualResult = ExtensionsConventions.GetProperCaseNameForLogicalName(logicalName);
            }

            [Test]
            public void Should_return_correct_namespace_segment_for_provided_logical_name()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_getting_proper_case_name_from_logical_name_not_containing_a_hyphen : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;

            protected override void Arrange()
            {
                _expectedResult = "GrandBend";
            }

            protected override void Act()
            {
                string extensionName = "GrandBend";

                _actualResult = ExtensionsConventions.GetProperCaseNameForLogicalName(extensionName);
            }

            [Test]
            public void Should_return_correct_namespace_segment_for_provided_logical_name()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_getting_proper_case_name_from_assembly_name : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;

            protected override void Arrange()
            {
                _expectedResult = "GrandBend";
            }

            protected override void Act()
            {
                string extensionAssemblyName = $"{Namespaces.Extensions.BaseNamespace}.GrandBend";

                _actualResult = ExtensionsConventions.GetProperCaseNameFromAssemblyName(extensionAssemblyName);
            }

            [Test]
            public void Should_return_correct_propercase_name_segment_for_provided_assembly_name()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_getting_aggregate_extension_member_name_and_entity_provided_is_not_an_aggregate_extension : TestFixtureBase
        {
            protected override void Act()
            {
                var domainModel =
                    new DomainModelProvider(
                        new IDomainModelDefinitionsProvider[]
                        {
                            new DomainModelDefinitionsProvider(), new EdFiDomainModelDefinitionsProvider()
                        }).GetDomainModel();

                ExtensionsConventions.GetAggregateExtensionMemberName(
                    domainModel.Entities.FirstOrDefault(e => e.Name == "StaffLeaveExtension"));
            }

            [Test]
            public void Should_return_correct_propercase_name_segment_for_provided_assembly_name()
            {
                AssertHelper.All(
                    () => Assert.That(ActualException.GetType(), Is.EqualTo(typeof(Exception))),
                    () => Assert.That(ActualException.Message, Is.EqualTo("The supplied 'aggregateExtensionEntity' was not an aggregate extension."))
                );
            }
        }

        public class When_getting_aggregate_extension_member_name : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;

            protected override void Act()
            {
                _expectedResult = "TestExtension_StaffLeaveReasons";

                var domainModel =
                    new DomainModelProvider(
                        new IDomainModelDefinitionsProvider[]
                        {
                            new DomainModelDefinitionsProvider(), new EdFiDomainModelDefinitionsProvider()
                        }).GetDomainModel();

                _actualResult = ExtensionsConventions.GetAggregateExtensionMemberName(
                    domainModel.Entities.FirstOrDefault(e => e.Name == "StaffLeaveReason"));
            }

            [Test]
            public void Should_return_correct_propercase_name_segment_for_provided_assembly_name()
            {
                Assert.That(
                    _actualResult,
                    Is.EqualTo(_expectedResult));
            }
        }

        public class When_getting_extension_class_name : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;

            protected override void Act()
            {
                _expectedResult = "StaffExtension";

                _actualResult = ExtensionsConventions.GetExtensionClassName("Staff");
            }

            [Test]
            public void Should_return_class_name_with_extension_appended_to_it()
            {
                Assert.That(
                    _actualResult,
                    Is.EqualTo(_expectedResult));
            }
        }

        public class When_checking_if_property_info_is_an_extension_collection_property : TestFixtureBase
        {
            [Test]
            public void Should_return_true_if_extension_collection_property_info_is_provided()
            {
                Assert.That(
                    typeof(StaffEntity).GetProperty("Extensions").IsExtensionCollectionProperty(),
                    Is.True);
            }
        }

        public class
            When_checking_if_property_info_is_an_extension_collection_property_and_provided_property_info_is_not_a_valid_extension_collection_property :
                TestFixtureBase
        {
            [Test]
            public void Should_return_false()
            {
                Assert.That(
                    typeof(StaffEntity).GetProperty("StaffAddresses").IsExtensionCollectionProperty(),
                    Is.False);
            }
        }

        public class When_getting_entity_type_full_name_for_standard_entity : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;
            private Entity _staffLeaveEntity;

            protected override void Arrange()
            {
                _expectedResult = typeof(StaffEntity).FullName;
            }

            protected override void Act()
            {
                var domainModel =
                    new DomainModelProvider(
                        new IDomainModelDefinitionsProvider[]
                        {
                            new DomainModelDefinitionsProvider(), new EdFiDomainModelDefinitionsProvider()
                        }).GetDomainModel();

                _staffLeaveEntity = domainModel.Entities.First(e => e.Name == "StaffLeave");

                _expectedResult =
                    $"{Namespaces.Entities.NHibernate.BaseNamespace}.{_staffLeaveEntity.Name}Aggregate.{EdFiConventions.ProperCaseName}.{_staffLeaveEntity.Name}";

                _actualResult = _staffLeaveEntity.EntityTypeFullName(EdFiConventions.ProperCaseName);
            }

            [Test]
            public void Should_return_correct_type_full_name()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_getting_entity_type_full_name_for_extension_entity : TestFixtureBase
        {
            private string _expectedResult;
            private string _actualResult;
            private readonly string _entityName = "StaffLeaveReason";
            private readonly string _extensionPropercaseName = "TestExtension";
            private Entity _entity;

            protected override void Arrange()
            {
                _expectedResult = typeof(StaffEntity).FullName;
            }

            protected override void Act()
            {
                var domainModel =
                    new DomainModelProvider(
                        new IDomainModelDefinitionsProvider[]
                        {
                            new DomainModelDefinitionsProvider(), new EdFiDomainModelDefinitionsProvider()
                        }).GetDomainModel();

                _entity = domainModel.Entities.First(e => e.Name == _entityName);

                _expectedResult =
                    $"{Namespaces.Entities.NHibernate.BaseNamespace}.{_entity.Aggregate.AggregateRoot.Name}Aggregate.{_extensionPropercaseName}.{_entity.Name}";

                _actualResult = _entity.EntityTypeFullName(_extensionPropercaseName);
            }

            [Test]
            public void Should_return_correct_type_full_name()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }
    }
}
