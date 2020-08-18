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
    public class UniqueIdToIdentificationCodeKeyTests
    {
        public class When_other_UniqueIdToIdentificationCodeKey_is_null : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = null;
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_UniqueIdToIdentificationCodeKey_are_the_same_object : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = _uniqueIdToIdentificationCodeKey1;
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_UniqueIdToIdentificationCodeKey_are_equal : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_PersonType_property_is_not_equal : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "OtherPersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_IdentificationSystemDescriptorUri_property_is_not_equal : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "OtherIdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_IdentificationCode_property_is_not_equal : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "OtherIdentificationCode",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_EducationOrganizationId_property_is_not_equal : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 54321,
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_all_properties_are_not_equal : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new UniqueIdToIdentificationCodeKey();
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_null : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private object _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = null;
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_the_same_object : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private object _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = _uniqueIdToIdentificationCodeKey1;
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_other_anonymous_object_is_not_the_same_type : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private object _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals(_uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_equal : TestFixtureBase
        {
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey1;
            private UniqueIdToIdentificationCodeKey _uniqueIdToIdentificationCodeKey2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdToIdentificationCodeKey1 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };

                _uniqueIdToIdentificationCodeKey2 = new UniqueIdToIdentificationCodeKey
                {
                    PersonType = "PersonType",
                    IdentificationSystemDescriptorUri = "IdentificationSystemDescriptorUri",
                    UniqueId = "UniqueId",
                    EducationOrganizationId = 12345,
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdToIdentificationCodeKey1.Equals((object) _uniqueIdToIdentificationCodeKey2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }
    }
}
