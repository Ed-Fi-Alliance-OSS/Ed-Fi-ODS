// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;
using StaffEntity = EdFi.Ods.Entities.NHibernate.StaffAggregate.EdFi.Staff;
using StaffResource = EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Staff;
using StaffProfileResource = EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Writable.Staff;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Conventions
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EdFiConventionsTests
    {
        public class When_checking_if_an_assembly_is_a_standard_assembly_and_assembly_fullname_starts_with_standard_assembly_name_prefix
            : TestFixtureBase
        {
            [Test]
            public void Should_return_true()
            {
                Assert.That(typeof(StaffResource).Assembly.IsStandardAssembly(), Is.True);
            }
        }

        public class When_checking_if_an_assembly_is_a_profile_assembly_and_assembly_contains_profile_xml_definition_file_as_manifest_resource
            : TestFixtureBase
        {
            [Test]
            public void Should_return_true()
            {
                Assert.That(EdFiConventions.IsProfileAssembly(typeof(StaffProfileResource).Assembly), Is.True);
            }
        }

        public class When_building_an_edfi_namespace_and_a_class_name_is_provided : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult =
                    EdFiConventions.BuildNamespace(
                        $"{Namespaces.Resources.BaseNamespace}",
                        EdFiConventions.ProperCaseName,
                        "Staff");
            }

            [Test]
            public void Should_return_correctly_constructed_namespace_containing_classname_in_the_right_location()
            {
                Assert.That(_actualResult, Is.EqualTo($"{Namespaces.Resources.BaseNamespace}.Staff.{EdFiConventions.ProperCaseName}"));
            }
        }

        public class When_building_an_edfi_namespace_and_a_class_name_is_not_provided : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult =
                    EdFiConventions.BuildNamespace(
                        $"{Namespaces.Resources.BaseNamespace}",
                        EdFiConventions.ProperCaseName);
            }

            [Test]
            public void Should_return_correctly_constructed_namespace_without_a_classname()
            {
                Assert.That(_actualResult, Is.EqualTo($"{Namespaces.Resources.BaseNamespace}.{EdFiConventions.ProperCaseName}"));
            }
        }

        public class When_building_an_extension_namespace_and_a_class_name_is_provided : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult =
                    EdFiConventions.BuildNamespace(
                        $"{Namespaces.Resources.BaseNamespace}",
                        "Sample",
                        "StaffExtension",
                        isExtensionObject: true);
            }

            [Test]
            public void Should_return_correctly_constructed_namespace_containing_classname_in_the_right_location()
            {
                Assert.That(_actualResult, Is.EqualTo($"{Namespaces.Resources.BaseNamespace}.Sample.StaffExtension"));
            }
        }

        public class When_creating_a_resource_namespace_and_the_resourceSchemaProperCaseName_is_null : TestFixtureBase
        {
            protected override void Act()
            {
                EdFiConventions.CreateResourceNamespace(null, "TestResource", null, null, null, null);
            }

            [Test]
            public void Should_throw_ArgumentNullException()
            {
                AssertHelper.All(
                    () => Assert.That(ActualException.GetType(), Is.EqualTo(typeof(ArgumentNullException))),
                    () => Assert.That(
                        ActualException.Message.Replace(Environment.NewLine, " "),
                        Is.EqualTo("Value cannot be null. Parameter name: resourceSchemaProperCaseName")));
            }
        }

        public class When_creating_a_resource_namespace_and_the_resourceName_is_null : TestFixtureBase
        {
            protected override void Act()
            {
                EdFiConventions.CreateResourceNamespace("SchemaProperCaseName", null, null, null, null, null);
            }

            [Test]
            public void Should_throw_ArgumentNullException_indicating_resourceName_parameter_cannot_be_null()
            {
                AssertHelper.All(
                    () => Assert.That(ActualException.GetType(), Is.EqualTo(typeof(ArgumentNullException))),
                    () => Assert.That(
                        ActualException.Message.Replace(Environment.NewLine, " "),
                        Is.EqualTo("Value cannot be null. Parameter name: resourceName")));
            }
        }

        public class
            When_creating_a_resource_namespace_and_the_profileNamespaceName_is_null_but_the_profileNamespaceBaseChildrenConcreteContext_was_provided
            : TestFixtureBase
        {
            protected override void Act()
            {
                EdFiConventions.CreateResourceNamespace("SchemaProperCaseName", "ResourceName", null, null, "ConcreteContext", null);
            }

            [Test]
            public void Should_throw_Exception()
            {
                AssertHelper.All(
                    () => Assert.That(ActualException.GetType(), Is.EqualTo(typeof(Exception))),
                    () =>
                        Assert.That(
                            ActualException.Message.Replace(Environment.NewLine, " "),
                            Is.EqualTo(
                                @"profileNamespaceBaseChildrenConcreteContext was supplied without a value for profileNamespaceName.")));
            }
        }

        public class When_creating_a_resource_namespace_for_non_profile_filtered_standard_edfi_resource : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult = EdFiConventions.CreateResourceNamespace(
                    "SchemaProperCaseName",
                    "ResourceName",
                    null,
                    null,
                    null,
                    null);
            }

            [Test]
            public void Should_return_correctly_constructed_namespace()
            {
                Assert.That(_actualResult, Is.EqualTo($"{Namespaces.Resources.BaseNamespace}.ResourceName.SchemaProperCaseName"));
            }
        }

        public class When_creating_a_resource_namespace_for_profile_filtered_standard_edfi_resource_with_readable_writable_context : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult = EdFiConventions.CreateResourceNamespace(
                    "SchemaProperCaseName",
                    "ResourceName",
                    "ProfileNamespaceName",
                    "ReadableWritableContext",
                    null,
                    null);
            }

            [Test]
            public void Should_return_correctly_constructed_namespace()
            {
                Assert.That(
                    _actualResult,
                    Is.EqualTo(
                        $"{Namespaces.Resources.BaseNamespace}.ResourceName.SchemaProperCaseName.ProfileNamespaceNameReadableWritableContext"));
            }
        }

        public class When_creating_a_resource_namespace_for_non_profile_filtered_extension_resource : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult = EdFiConventions.CreateResourceNamespace(
                    "SchemaProperCaseName",
                    "ResourceName",
                    null,
                    null,
                    null,
                    "ExtensionSchemaProperCaseName");
            }

            [Test]
            public void Should_return_correctly_constructed_namespace()
            {
                Assert.That(
                    _actualResult,
                    Is.EqualTo($"{Namespaces.Resources.BaseNamespace}.ResourceName.SchemaProperCaseName.Extensions.ExtensionSchemaProperCaseName"));
            }
        }

        public class When_creating_a_resource_namespace_for_profile_filtered_extension_resource : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult = EdFiConventions.CreateResourceNamespace(
                    "SchemaProperCaseName",
                    "ResourceName",
                    "ProfileNamespaceName",
                    "ReadableWritableContext",
                    null,
                    "ExtensionSchemaProperCaseName");
            }

            [Test]
            public void Should_return_correctly_constructed_namespace()
            {
                var expectedResult =
                    $@"{Namespaces.Resources.BaseNamespace}.ResourceName.SchemaProperCaseName.ProfileNamespaceNameReadableWritableContext.Extensions.ExtensionSchemaProperCaseName";

                Assert.That(_actualResult, Is.EqualTo(expectedResult));
            }
        }

        public class When_creating_a_resource_interface_name_for_profile_or_extension_context : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult = new Resource("TestResource").GetResourceInterfaceName(
                    "SchemaProperCaseName",
                    true,
                    true);
            }

            [Test]
            public void Should_return_correctly_constructed_namespace()
            {
                Assert.That(_actualResult, Is.EqualTo($"{Namespaces.Entities.Common.RelativeNamespace}.SchemaProperCaseName.ITestResource"));
            }
        }

        public class When_creating_a_resource_interface_name_for_non_profile_and_extension_context : TestFixtureBase
        {
            private string _actualResult;

            protected override void Act()
            {
                _actualResult = new Resource("TestResource").GetResourceInterfaceName(
                    "SchemaProperCaseName",
                    false,
                    false);
            }

            [Test]
            public void Should_return_correctly_constructed_namespace()
            {
                Assert.That(_actualResult, Is.EqualTo("ITestResource"));
            }
        }

        public class When_determining_if_type_is_edfi_entity_and_type_full_name_starts_with_entities_nhibernate_base_namespace : TestFixtureBase
        {
            [Test]
            public void Should_return_true_indicating_provided_entity_is_an_edfi_entity()
            {
                Assert.That(typeof(StaffEntity).IsEdFiEntity(), Is.True);
            }
        }

        public class When_determining_if_type_is_edfi_resource_class_and_type_full_name_starts_with_resource_base_namespace : TestFixtureBase
        {
            [Test]
            public void Should_return_true_indicating_provided_resource_is_an_edfi_resource()
            {
                Assert.That(typeof(StaffResource).IsEdFiResourceClass(), Is.True);
            }
        }
    }
}
