// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Common.Infrastructure.Composites;
using EdFi.Ods.Tests._Extensions;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.AuthorizationStrategies
{
    public class When_generating_aliases_using_instance_state : LegacyTestFixtureBase
    {
        // Supplied values

        // Actual values
        private HashSet<string> _actualAliases;

        // Dependencies
        protected override void Act()
        {
            // Execute code under test
            var generator = new AliasGenerator("fltr_", useSharedState: false);
            generator.Reset();

            _actualAliases = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            int i = 0;

            while (i++ < 100000)
            {
                string nextAlias = generator.GetNextAlias();

                if (!_actualAliases.Add(nextAlias))
                {
                    Assert.Fail("Duplicate alias generated: '{0}'", nextAlias);
                }
            }

            Assert.Fail("Possible infinite loop detected in alias generation.  Stopped at 100,000 aliases.");
        }

        [Assert]
        public void Should_generate_17576_unique_aliases_before_throwing_an_InvalidOperationException()
        {
            _actualAliases.Count.ShouldBe(26 * 26 * 26);
            ActualException.ShouldBeExceptionType<InvalidOperationException>();
        }
    }

    public class When_generating_aliases_using_shared_state : LegacyTestFixtureBase
    {
        // Supplied values

        // Actual values
        private HashSet<string> _actualAliases;

        // Dependencies
        protected override void Act()
        {
            // Execute code under test
            var generator = new AliasGenerator("fltr_", useSharedState: true);
            generator.Reset();

            _actualAliases = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            int i = 0;

            string firstAlias = null;

            while (i++ < 100000)
            {
                string nextAlias = generator.GetNextAlias();

                if (firstAlias == null)
                {
                    firstAlias = nextAlias;
                }

                if (!_actualAliases.Add(nextAlias))
                {
                    // If we looped around
                    if (nextAlias == firstAlias && i == 26 * 26 * 26 + 1)
                    {
                        break;
                    }

                    Assert.Fail("Duplicate alias generated: '{0}'", nextAlias);
                }
            }

            if (i >= 100000)
            {
                Assert.Fail("Possible infinite loop detected in alias generation.  Stopped at 100,000 aliases.");
            }
        }

        [Assert]
        public void Should_not_generate_an_exception()
        {
            ActualException.ShouldBeNull();
        }
    }

    public class When_generating_aliases_using_multiple_generators_using_shared_state : LegacyTestFixtureBase
    {
        private AliasGenerator _generator1;
        private AliasGenerator _generator2;
        private AliasGenerator _generator3;
        private AliasGenerator _instanceGenerator;

        protected override void Act()
        {
            // Execute code under test
            _generator1 = new AliasGenerator("1_", useSharedState: true);
            _generator1.Reset();

            _generator2 = new AliasGenerator("1_", useSharedState: true);
            _generator2.Reset();

            _generator3 = new AliasGenerator("1_", useSharedState: true);
            _generator3.Reset();

            _instanceGenerator = new AliasGenerator("1_", useSharedState: false);
        }

        [Assert]
        public void Should_generate_incremented_aliases_across_multiple_generators()
        {
            Assert.That(_generator1.GetNextAlias(), Is.EqualTo("1_aaa"));
            Assert.That(_generator2.GetNextAlias(), Is.EqualTo("1_aab"));
            Assert.That(_generator3.GetNextAlias(), Is.EqualTo("1_aac"));

            Assert.That(_instanceGenerator.GetNextAlias(), Is.EqualTo("1_aaa"));

            Assert.That(_generator3.GetNextAlias(), Is.EqualTo("1_aad"));
            Assert.That(_generator2.GetNextAlias(), Is.EqualTo("1_aae"));

            Assert.That(_instanceGenerator.GetNextAlias(), Is.EqualTo("1_aab"));

            Assert.That(_generator1.GetNextAlias(), Is.EqualTo("1_aaf"));

            Assert.That(_instanceGenerator.GetNextAlias(), Is.EqualTo("1_aac"));
        }
    }
}
