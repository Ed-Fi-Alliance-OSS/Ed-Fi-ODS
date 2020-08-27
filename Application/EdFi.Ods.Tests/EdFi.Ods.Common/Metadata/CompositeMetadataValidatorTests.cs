// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Metadata;
using EdFi.TestFixture;
using FluentValidation.Results;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Metadata
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CompositeMetadataValidatorTests
    {
        public class When_validating_composite_metadata_documents_and_no_validation_exceptions_exist : TestFixtureBase
        {
            private CompositeMetadataValidator _compositeMetadataValidator;
            private ValidationResult _validationResult;

            private readonly XDocument _validCompositeDefinition = XDocument.Parse(
                @"<?xml version='1.0' encoding='utf-8'?>
                                                        <CompositeMetadata organizationCode='OrganizationCode'>
                                                          <Category displayName='Test' name='test'>
                                                            <Routes>      
                                                            </Routes>
                                                            <Composites>
                                                              <Composite name='CompositeName'>
                                                                <BaseResource name='TestResource'>
                                                                  <Property name='TestProperty' />
                                                                </BaseResource>
                                                              </Composite>
                                                            </Composites>
                                                          </Category>
                                                        </CompositeMetadata>");

            protected override void Arrange()
            {
                _validCompositeDefinition.AddAnnotation("PathToCompositeDefinition");
                _compositeMetadataValidator = new CompositeMetadataValidator();
            }

            protected override void Act()
            {
                _validationResult = _compositeMetadataValidator.Validate(_validCompositeDefinition);
            }

            [Test]
            public void Should_return_empty_list_of_validation_results()
            {
                Assert.That(
                    _validationResult.IsValid,
                    Is.True,
                    string.Join(Environment.NewLine, _validationResult.Errors.Select(e => e.ErrorMessage)));
            }
        }

        public class When_validating_composite_metadata_documents_and_validation_exceptions_exist : TestFixtureBase
        {
            private CompositeMetadataValidator _compositeMetadataValidator;
            private ValidationResult _validationResult;

            private readonly XDocument _invalidCompositeDefinition = XDocument.Parse(
                @"<?xml version='1.0' encoding='utf-8'?>
                                                        <CompositeMetadata organizationCode='OrganizationCode'>
                                                          <Category displayName='Test' name='test'>
                                                            <Routes>      
                                                            </Routes>
                                                            <Composites>
                                                              <InvalidElment name='CompositeName'>
                                                                <BaseResource name='TestResource'>
                                                                  <Property name='TestProperty' />
                                                                </BaseResource>
                                                              </InvalidElment>
                                                            </Composites>
                                                          </Category>
                                                        </CompositeMetadata>");

            protected override void Arrange()
            {
                _invalidCompositeDefinition.AddAnnotation("PathToCompositeDefinition");
                _compositeMetadataValidator = new CompositeMetadataValidator();
            }

            protected override void Act()
            {
                _validationResult = _compositeMetadataValidator.Validate(_invalidCompositeDefinition);
            }

            [Test]
            public void Should_return_an_invalid_validation_result_containing_validation_errors_and_path_to_invalid_composite_definitoin()
            {
                AssertHelper.All(
                    () => { Assert.That(_validationResult.IsValid, Is.False); },
                    () =>
                    {
                        Assert.That(
                            _validationResult.Errors.First()
                                             .ErrorMessage.Contains("PathToCompositeDefinition"));
                    },
                    () =>
                    {
                        Assert.That(
                            _validationResult.Errors.First()
                                             .ErrorMessage.Contains("The element 'Composites' has invalid child element 'InvalidElment'"));
                    }
                );
            }
        }
    }
}
