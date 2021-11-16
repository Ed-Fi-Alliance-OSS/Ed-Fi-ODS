using System;
using System.Linq;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Validation;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Extensions
{
    public class ValidationExtensionsTests
    {
        [TestFixture]
        public class When_class_with_required_non_default_throws_exception_during_validation
        {
            [Test]
            public void Should_still_capture_validation_message()
            {
                var testClass = new ClassThatWillThrowValidationException { Value = "NewValueHere" };

                var validators = new IEntityValidator[] { new DataAnnotationsEntityValidator() };
                var results = validators.ValidateObject(testClass);

                results.IsValid().ShouldBe(false);
                results.Count.ShouldBe(1);
                results.First().ErrorMessage.ShouldBe("Test validation failure message.");
            }
        }
    }

    class ClassThatWillThrowValidationException
    {
        private string _value;

        [RequiredWithNonDefault]
        public string Value
        {
            get => throw new Exception("Test validation failure message.");
            set => _value = value;
        }
    }
}
