// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Entities.NHibernate.SexDescriptorAggregate.EdFi;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Validation
{
    public class DescriptorNamespaceValidatorTests
    {
        [TestFixture]
        public class When_validating_descriptor_namespace_is_empty : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = string.Empty
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors[0]
                      .ToString()
                      .ShouldBe("Namespace is required.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_is_whitespace : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = "\t \r\n"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors[0]
                      .ToString()
                      .ShouldBe("Namespace is required.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_has_invalid_format : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = "ed-fi.org/SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors[0]
                      .ToString()
                      .ShouldBe(
                           "Namespace has invalid format. Valid namespace format is uri://[organization name]/[descriptor name]. Example: 'uri://ed-fi.org/AcademicSubjectDescriptor'");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_no_organization_name : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = "uri:///SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors[0]
                      .ToString()
                      .ShouldBe(
                           "organization name is required. Valid namespace format is uri://[organization name]/[descriptor name]. Example: 'uri://ed-fi.org/AcademicSubjectDescriptor'");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_no_descriptor_name : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = "uri://ed-fi.org/"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors[0]
                      .ToString()
                      .ShouldBe(
                           "descriptor name is required. Valid namespace format is uri://[organization name]/[descriptor name]. Example: 'uri://ed-fi.org/AcademicSubjectDescriptor'");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_invalid_scheme : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = "urn://ed-fi.org/SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors.First()
                      .ToString()
                      .ShouldBe("'urn' is not a valid value for namespace scheme. Namespaces must be prefixed with 'uri://'.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_invalid_organization_name : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = "uri://<>#%{}|\\^~[]/SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors.First()
                      .ToString()
                      .ShouldBe(
                           "'<>#%{}|\\^~[]' is not a valid value for organization name. Organization names may only contain alphanumeric and these special characters \"$-_.+!*'(),\".");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_invalid_descriptor_name : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "CodeValue", Namespace = "uri://ed-fi.org/<>#%{}|\\^~[]"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors.First()
                      .ToString()
                      .ShouldBe(
                           "'<>#%{}|\\^~[]' is not a valid value for descriptor name. Descriptor names may only contain alphanumeric characters.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_code_value_is_empty : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = string.Empty, Namespace = "uri://ed-fi.org/SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors[0]
                      .ToString()
                      .ShouldBe("Code Value is required.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_code_value_is_whitespace : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "\t \r\n", Namespace = "uri://ed-fi.org/SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors.First()
                      .ToString()
                      .ShouldBe("Code Value is required.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_with_invalid_code_value : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "Code#Value", Namespace = "uri://ed-fi.org/SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(1);

                result.Errors.First()
                      .ToString()
                      .ShouldBe("'Code#Value' is not a valid value for Code Value. Code values may not contain '#'.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_no_code_value_or_namespace : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = string.Empty, Namespace = string.Empty
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(2);

                result.Errors[0]
                      .ToString()
                      .ShouldBe("Namespace is required.");

                result.Errors[1]
                      .ToString()
                      .ShouldBe("Code Value is required.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_invalid_code_value_and_invalid_namespace_format : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "Code#Value", Namespace = "InvalidNamespaceFormat"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(2);

                result.Errors[0]
                      .ToString()
                      .ShouldBe(
                           "Namespace has invalid format. Valid namespace format is uri://[organization name]/[descriptor name]. Example: 'uri://ed-fi.org/AcademicSubjectDescriptor'");

                result.Errors[1]
                      .ToString()
                      .ShouldBe("'Code#Value' is not a valid value for Code Value. Code values may not contain '#'.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_namespace_with_invalid_code_value_and_scheme_and_organization_name_and_descriptor_name : TestBase
        {
            [Test]
            public void Should_return_validation_error()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "Code#Value", Namespace = "urn://<>#%{}|\\^~[]/<>#%{}|\\^~[]"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeFalse();
                result.Errors.Count.ShouldBe(4);

                result.Errors[0]
                      .ToString()
                      .ShouldBe("'urn' is not a valid value for namespace scheme. Namespaces must be prefixed with 'uri://'.");

                result.Errors[1]
                      .ToString()
                      .ShouldBe(
                           "'<>#%{}|\\^~[]' is not a valid value for organization name. Organization names may only contain alphanumeric and these special characters \"$-_.+!*'(),\".");

                result.Errors[2]
                      .ToString()
                      .ShouldBe(
                           "'<>#%{}|\\^~[]' is not a valid value for descriptor name. Descriptor names may only contain alphanumeric characters.");

                result.Errors[3]
                      .ToString()
                      .ShouldBe("'Code#Value' is not a valid value for Code Value. Code values may not contain '#'.");
            }
        }

        [TestFixture]
        public class When_validating_descriptor_with_valid_namespace_and_code_value : TestBase
        {
            [Test]
            public void Should_return_valid()
            {
                var sexDescriptor = new SexDescriptor
                                    {
                                        SexDescriptorId = 1, CodeValue = "Male", Namespace = "uri://ed-fi.org/SexDescriptor"
                                    };

                var validator = new DescriptorNamespaceValidator();
                var result = validator.Validate(sexDescriptor);
                result.IsValid.ShouldBeTrue();
                result.Errors.Count.ShouldBe(0);
            }
        }
    }
}
