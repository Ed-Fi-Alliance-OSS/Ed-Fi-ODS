// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Linq;
using EdFi.Ods.Common.Inflection;
using NUnit.Framework;

namespace EdFi.Ods.Common.UnitTests.Inflection
{
    [TestFixture]
    public class InflectorTests
    {
        [Test]
        public void MakeInitialLowerCase_test()
        {
            const string source = "TheQuickBrownFoxJumpedOverTheLazyDog";
            const string expected = "theQuickBrownFoxJumpedOverTheLazyDog";
            var result = Inflector.MakeInitialLowerCase(source);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MakeInitialUpperCase_test()
        {
            const string source = "theQuickBrownFoxJumpedOverTheLazyDog";
            const string expected = "TheQuickBrownFoxJumpedOverTheLazyDog";
            var result = Inflector.MakeInitialUpperCase(source);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CollapseNames_test_no_overlaps()
        {
            var result = Inflector.CollapseNames("AlphaBravo", "CharlieDelta");
            Assert.AreEqual("AlphaBravoCharlieDelta", result);
        }

        [Test]
        public void CollapseNames_test_one_overlap()
        {
            var result = Inflector.CollapseNames("AlphaBravo", "BravoCharlie");
            Assert.AreEqual("AlphaBravoCharlie", result);
        }

        [Test]
        public void CollapseNames_test_two_overlaps()
        {
            var result = Inflector.CollapseNames("AlphaBravoCharlie", "BravoCharlieDelta");
            Assert.AreEqual("AlphaBravoCharlieDelta", result);
        }

        [Test]
        public void CollapseNames_test_subsumed()
        {
            var result = Inflector.CollapseNames("AlphaBravo", "AlphaBravoCharlieDelta");
            Assert.AreEqual("AlphaBravoCharlieDelta", result);
        }

        [Test]
        public void CollapseNames_test_three_terms()
        {
            var result = Inflector.CollapseNames("AlphaBravo", "BravoCharlie", "CharlieDelta");
            Assert.AreEqual("AlphaBravoCharlieDelta", result);
        }

        [Test]
        public void CollapseNames_test_ambiguous_overlap()
        {
            var result = Inflector.CollapseNames(
                "AlphaBravoCharlieBravoCharlie",
                "BravoCharlieCharlie",
                "CharlieDelta");
            Assert.AreEqual("AlphaBravoCharlieBravoCharlieCharlieDelta", result);
        }

        [Test]
        public void CollapseNames_test_lower_case_first_character()
        {
            var result = Inflector.CollapseNames("alpha", "Alpha", "alpha");
            Assert.AreEqual("Alpha", result);
        }

        [Test]
        public void StripLeftTerms_test()
        {
            var result = Inflector.StripLeftTerms("AlphaBravoCharlieBravoCharlie")
                                  .ToArray();
            Assert.AreEqual(4, result.Length);
            Assert.IsFalse(result.Contains("AlphaBravoCharlieBravoCharlie"));
            Assert.IsTrue(result.Contains("BravoCharlieBravoCharlie"));
            Assert.IsTrue(result.Contains("CharlieBravoCharlie"));
            Assert.IsTrue(result.Contains("BravoCharlie"));
            Assert.IsTrue(result.Contains("Charlie"));
            Assert.IsFalse(result.Contains(string.Empty));
        }
    }
}