// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Validation
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NoUnsuppliedRequiredMembersWithMeaningfulDefaultsAttributeTests
    {
        [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
        private class TestResourceClassWithMembersWithMeaningfulDefaultValues : IHasRequiredMembersWithMeaningfulDefaultValues
        {
            public int NonMeaningfulDefaultValue {get; set; }

            private bool _meaningfulDefaultValueExplicitlyAssigned = false;
            private int _meaningfulDefaultValue;

            public int MeaningfulDefaultValue
            {
                get => _meaningfulDefaultValue;
                set
                {
                    _meaningfulDefaultValue = value;
                    _meaningfulDefaultValueExplicitlyAssigned = true;
                }
            }

            public IEnumerable<string> GetUnassignedMemberNames()
            {
                if (!_meaningfulDefaultValueExplicitlyAssigned)
                {
                    yield return "MeaningfulDefaultValue";
                }
            }
        }

        public class
            When_validating_a_resource_decorated_with_NoUnSuppliedRequiredMembersWithMeaningfulDefaults_and_a_meaningful_member_is_unassigned
            : TestFixtureBase
        {
            private readonly List<ValidationResult> _validationResults = new List<ValidationResult>();
            private TestResourceClassWithMembersWithMeaningfulDefaultValues _resource;

            protected override void Arrange()
            {
                _resource = new TestResourceClassWithMembersWithMeaningfulDefaultValues();
            }

            protected override void Act()
            {
                Validator.TryValidateObject(_resource, new ValidationContext(_resource, null, null), _validationResults, true);
            }

            [Assert]
            public void Should_return_validation_exception_for_MeaningfulDefaultValue()
            {
                AssertHelper.All(() => Assert.That(_validationResults.Count, Is.EqualTo(1)),
                () => Assert.That(_validationResults[0].MemberNames.First(), Is.EqualTo("MeaningfulDefaultValue")));
            }
        }

        public class
            When_validating_a_resource_decorated_with_NoUnSuppliedRequiredMembersWithMeaningfulDefaults_and_a_meaningful_member_is_assigned
            : TestFixtureBase
        {
            private readonly List<ValidationResult> _validationResults = new List<ValidationResult>();
            private TestResourceClassWithMembersWithMeaningfulDefaultValues _resource;

            protected override void Arrange()
            {
                _resource = new TestResourceClassWithMembersWithMeaningfulDefaultValues() { MeaningfulDefaultValue = 0 };
            }

            protected override void Act()
            {
                Validator.TryValidateObject(_resource, new ValidationContext(_resource, null, null), _validationResults, true);
            }

            [Assert]
            public void Should_return_validation_exception_for_MeaningfulDefaultValue()
            {
                Assert.That(_validationResults.Count, Is.EqualTo(0));
            }
        }
    }
}
