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
    public class IdentificationCodeMatchTests
    {
        public class When_other_IdentificationCodeMatch_is_null : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private IdentificationCodeMatch _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = null;
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_IdentificationCodeMatch_are_the_same_object : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private IdentificationCodeMatch _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = _identificationCodeMatch1;
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_IdentificationCodeMatch_are_equal : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private IdentificationCodeMatch _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_AssigningOrganizationIdentificationCode_property_is_not_equal : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private IdentificationCodeMatch _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "OtherAssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_IdentificationCode_property_is_not_equal : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private IdentificationCodeMatch _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = new IdentificationCodeMatch
                {
                    IdentificationCode = "OtherIdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_all_properties_are_not_equal : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private IdentificationCodeMatch _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = new IdentificationCodeMatch();
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_null : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private object _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = null;
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_the_same_object : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private object _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = _identificationCodeMatch1;
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_other_anonymous_object_is_not_the_same_type : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private object _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = new
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals(_identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_equal : TestFixtureBase
        {
            private IdentificationCodeMatch _identificationCodeMatch1;
            private IdentificationCodeMatch _identificationCodeMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _identificationCodeMatch1 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _identificationCodeMatch2 = new IdentificationCodeMatch
                {
                    IdentificationCode = "IdentificationCode",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _identificationCodeMatch1.Equals((object) _identificationCodeMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }
    }
}
