using EdFi.Ods.Common.Attributes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Attributes
{
    public class MinMaxAttributeTests
    {

        [TestFixture]
        public class When_validating_an_int_within_min_and_max_values
        {
            [Test]
            public void Should_return_success()
            {
                var result = new MinMaxAttribute(minValue: 1, maxValue: 10).IsValid(5);
                result.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_a_decimal_within_min_and_max_values
        {
            [Test]
            public void Should_return_success()
            {
                var result = new MinMaxAttribute(minValue: new decimal(1.2345), maxValue: new decimal(10.9876)).IsValid(new decimal(5.4321));
                result.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_a_null_value
        {
            [Test]
            public void Should_return_success()
            {
                var result = new MinMaxAttribute(minValue: 1, maxValue: 10).IsValid(null);
                result.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_an_int_greater_than_max
        {
            [Test]
            public void Should_return_failure()
            {
                var result = new MinMaxAttribute(minValue: 1, maxValue: 10).IsValid(11);
                result.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_validating_a_decimal_greater_than_max
        {
            [Test]
            public void Should_return_failure()
            {
                var result = new MinMaxAttribute(minValue: new decimal(1.2345), maxValue: new decimal(10.9876)).IsValid(new decimal(11.23456));
                result.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_validating_an_int_less_than_min
        {
            [Test]
            public void Should_return_failure()
            {
                var result = new MinMaxAttribute(minValue: 1, maxValue: 10).IsValid(-1);
                result.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_validating_a_decimal_less_than_min
        {
            [Test]
            public void Should_return_failure()
            {
                var result = new MinMaxAttribute(minValue: new decimal(1.2345), maxValue: new decimal(10.9876)).IsValid(new decimal(-2.3456));
                result.ShouldBeFalse();
            }
        }
    }
}
