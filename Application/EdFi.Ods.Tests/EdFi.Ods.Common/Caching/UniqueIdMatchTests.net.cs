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
    public class UniqueIdMatchTests
    {
        public class When_other_UniqueIdMatch_is_null : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private UniqueIdMatch _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = null;
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_UniqueIdMatch_are_the_same_object : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private UniqueIdMatch _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = _uniqueIdMatch1;
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_UniqueIdMatch_are_equal : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private UniqueIdMatch _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_AssigningOrganizationIdentificationCode_property_is_not_equal : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private UniqueIdMatch _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "OtherAssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_UniqueId_property_is_not_equal : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private UniqueIdMatch _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = new UniqueIdMatch
                {
                    UniqueId = "OtherUniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_all_properties_are_not_equal : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private UniqueIdMatch _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = new UniqueIdMatch();
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_null : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private object _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = null;
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_the_same_object : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private object _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = _uniqueIdMatch1;
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }

        public class When_other_anonymous_object_is_not_the_same_type : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private object _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = new
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals(_uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_false()
            {
                _result.ShouldBeFalse();
            }
        }

        public class When_other_anonymous_object_is_equal : TestFixtureBase
        {
            private UniqueIdMatch _uniqueIdMatch1;
            private UniqueIdMatch _uniqueIdMatch2;

            private bool _result;

            protected override void Arrange()
            {
                _uniqueIdMatch1 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };

                _uniqueIdMatch2 = new UniqueIdMatch
                {
                    UniqueId = "UniqueId",
                    AssigningOrganizationIdentificationCode = "AssigningOrganizationIdentificationCode",
                };
            }

            protected override void Act()
            {
                _result = _uniqueIdMatch1.Equals((object) _uniqueIdMatch2);
            }

            [Assert]
            public void Should_return_true()
            {
                _result.ShouldBeTrue();
            }
        }
    }
}
