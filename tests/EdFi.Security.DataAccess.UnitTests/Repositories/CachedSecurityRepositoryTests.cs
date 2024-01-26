// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Utils;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Security.DataAccess.UnitTests.Repositories
{
    [TestFixture]
    public class CachedSecurityRepositoryTests
    {
        protected ISecurityContextFactory _securityContextFactory;
        protected CachedSecurityRepository _systemUnderTest;

        [SetUp]
        protected void ArrangeBase()
        {
            _securityContextFactory = A.Fake<ISecurityContextFactory>();
            A.CallTo(() => _securityContextFactory.CreateContext()).Returns(SecurityContextMock.GetMockedSecurityContext());
        }

        protected void InitializeSystemUnderTest(int cacheTimeoutInMinutes)
        {
            _systemUnderTest = new CachedSecurityRepository(_securityContextFactory, cacheTimeoutInMinutes);
            _systemUnderTest.GetClaimsForClaimSet("ClaimSet");

            // Should hit the database after calling a getter because it has lazy initialization
            A.CallTo(() => _securityContextFactory.CreateContext()).MustHaveHappened(1, Times.Exactly);
            Fake.ClearRecordedCalls(_securityContextFactory);
        }

        public class When_constructing_repository_with_missing_or_invalid_cache_timeout : CachedSecurityRepositoryTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void Should_throw_argument_exception(int cacheTimeoutInMinutes)
            {
                Should.Throw<ArgumentException>(() => new CachedSecurityRepository(_securityContextFactory, cacheTimeoutInMinutes));
            }
        }

        public class When_executing_decorated_method_with_ten_minute_cache_expiration_but_five_minutes_have_passed : CachedSecurityRepositoryTests
        {
            [Test]
            public void Should_not_request_new_context()
            {
                DateTime initialCacheTime = new DateTime(2020, 03, 01, 12, 00, 00);
                SystemClock.Now = () => initialCacheTime;
                InitializeSystemUnderTest(10);

                SystemClock.Now = () => initialCacheTime.AddMinutes(5);
                _systemUnderTest.GetClaimsForClaimSet("ClaimSet");
                A.CallTo(() => _securityContextFactory.CreateContext()).MustNotHaveHappened();
            }
        }

        public class When_executing_decorated_method_with_ten_minute_cache_expiration_but_fifteen_minutes_have_passed : CachedSecurityRepositoryTests
        {
            [Test]
            public void Should_request_new_context_exactly_once()
            {
                DateTime initialCacheTime = new DateTime(2020, 03, 01, 12, 00, 00);
                SystemClock.Now = () => initialCacheTime;
                InitializeSystemUnderTest(10);

                SystemClock.Now = () => initialCacheTime.AddMinutes(15);
                _systemUnderTest.GetClaimsForClaimSet("ClaimSet");
                _systemUnderTest.GetClaimsForClaimSet("ClaimSet");
                A.CallTo(() => _securityContextFactory.CreateContext()).MustHaveHappened(1, Times.Exactly);
            }
        }
    }
}
