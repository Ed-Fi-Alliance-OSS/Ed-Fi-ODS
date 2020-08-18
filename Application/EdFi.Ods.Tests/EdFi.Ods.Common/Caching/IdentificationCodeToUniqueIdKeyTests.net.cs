// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Caching
{
    [TestFixture]
    public class IdentificationCodeToUniqueIdKeyTests
    {
        public class When_other_IdentificationCodeToUniqueIdKey_is_null : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = null;
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_IdentificationCodeToUniqueIdKey_are_the_same_object : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = _identificationCodeToUniqueIdKey1;
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_IdentificationCodeToUniqueIdKey_are_equal : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_PersonType_property_is_not_equal : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "OtherPersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_IdentificationSystemDescriptorUri_property_is_not_equal : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "OtherIdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_IdentificationCode_property_is_not_equal : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "OtherIdentificationCode",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_EducationOrganizationId_property_is_not_equal : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 54321,
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_all_properties_are_not_equal : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new IdentificationCodeToUniqueIdKey();
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_null : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private object _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = null;
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_the_same_object : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private object _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = _identificationCodeToUniqueIdKey1;
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_other_anonymous_object_is_not_the_same_type : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private object _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals(_identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_equal : TestFixtureBase
        {
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey1;
            private IdentificationCodeToUniqueIdKey _identificationCodeToUniqueIdKey2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeToUniqueIdKey1 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };

                _identificationCodeToUniqueIdKey2 = new IdentificationCodeToUniqueIdKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    IdentificationCodeValue = "IdentificationCodeValue",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeToUniqueIdKey1.Equals((object) _identificationCodeToUniqueIdKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }
    }
}
