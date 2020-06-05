// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Validation;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    public class DangerousTextTestObject
    {
        public DangerousTextTestObject(string name)
        {
            Name = name;
        }

        [NoDangerousText]
        public string Name { get; set; }
    }

    public class When_validating_empty_string_for_NoDangerousText : LegacyTestFixtureBase
    {
        private ICollection<ValidationResult> _actualResults;

        /// <summary>
        /// Executes the code to be tested.
        /// </summary>
        protected override void Act()
        {
            var testObject = new DangerousTextTestObject(string.Empty);

            var validator = new DataAnnotationsEntityValidator();
            _actualResults = validator.ValidateObject(testObject);
        }

        [Assert]
        public void Should_not_have_any_validation_errors()
        {
            Assert.That(_actualResults, Is.Empty);
        }
    }

    public class When_validating_string_with_safe_content_for_NoDangerousText : LegacyTestFixtureBase
    {
        private ICollection<ValidationResult> _actualResults;

        /// <summary>
        /// Executes the code to be tested.
        /// </summary>
        protected override void Act()
        {
            var testObject = new DangerousTextTestObject("Hello World");

            var validator = new DataAnnotationsEntityValidator();
            _actualResults = validator.ValidateObject(testObject);
        }

        [Assert]
        public void Should_not_have_any_validation_errors()
        {
            Assert.That(_actualResults, Is.Empty);
        }
    }

    public class When_validating_string_with_dangerous_content_for_NoDangerousText : LegacyTestFixtureBase
    {
        private ICollection<ValidationResult> _actualResults;

        /// <summary>
        /// Executes the code to be tested.
        /// </summary>
        protected override void Act()
        {
            var testObject = new DangerousTextTestObject("<Hello World>");

            var validator = new DataAnnotationsEntityValidator();
            _actualResults = validator.ValidateObject(testObject);
        }

        [Assert]
        public void Should_have_a_validation_error_regarding_a_potentially_dangerous_value()
        {
            Assert.That(_actualResults, Has.Count.EqualTo(1));

            Assert.That(
                _actualResults.Single()
                              .ErrorMessage,
                Does.Contain("potentially dangerous value"));
        }
    }

    public class When_validating_innocuous_string_that_contains_an_embedded_Javascript_event_name_for_NoDangerousText : LegacyTestFixtureBase
    {
        private ICollection<ValidationResult> _actualResults;

        /// <summary>
        /// Executes the code to be tested.
        /// </summary>
        protected override void Act()
        {
            var testObject = new DangerousTextTestObject("Moonshower"); // Includes 'onshow'

            var validator = new DataAnnotationsEntityValidator();
            _actualResults = validator.ValidateObject(testObject);
        }

        [Assert]
        public void Should_not_fail_validation()
        {
            Assert.That(_actualResults, Has.Count.EqualTo(0));
        }
    }

    public class When_validating_a_sample_dangerous_string_from_Arizona_API_security_assessment_report_for_NoDangerousText : LegacyTestFixtureBase
    {
        private ICollection<ValidationResult> _actualResults;

        /// <summary>
        /// Executes the code to be tested.
        /// </summary>
        protected override void Act()
        {
            // Initialize dangerous value
            var testObject =
                new DangerousTextTestObject(
                    @"\""}<script>var r=new XMLHttpRequest();</script>{, \""}<script>r.open('GET', document.location, false);r.send(null);</script>{, \""}<script>var h=r.getAllResponseHeaders().toLowerCase();</script>{, and \""}<script>alert(h);</script>{");

            var validator = new DataAnnotationsEntityValidator();
            _actualResults = validator.ValidateObject(testObject);
        }

        [Assert]
        public void Should_have_a_validation_error_regarding_a_potentially_dangerous_value()
        {
            Assert.That(_actualResults, Has.Count.EqualTo(1));

            Assert.That(
                _actualResults.Single()
                              .ErrorMessage,
                Does.Contain("potentially dangerous value"));
        }
    }
}
