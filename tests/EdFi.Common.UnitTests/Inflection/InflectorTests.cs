// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Inflection;
using NUnit.Framework;
using Shouldly;

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

        [Test]
        public void Words_are_inflected_to_singular_and_plural_forms_based_on_supplied_count_correctly()
        {
            "".ShouldSatisfyAllConditions(
                // Singular form supplied
                () => Inflector.Inflect("dog", 0).ShouldBe("dogs"),
                () => Inflector.Inflect("dog", 1).ShouldBe("dog"),
                () => Inflector.Inflect("dog", 2).ShouldBe("dogs"),
                
                // Plural form supplied
                () => Inflector.Inflect("dogs", 0).ShouldBe("dogs"),
                () => Inflector.Inflect("dogs", 1).ShouldBe("dog"),
                () => Inflector.Inflect("dogs", 2).ShouldBe("dogs"),
                
                // Singular form supplied
                () => Inflector.Inflect("doggy", 0).ShouldBe("doggies"),
                () => Inflector.Inflect("doggy", 1).ShouldBe("doggy"),
                () => Inflector.Inflect("doggy", 2).ShouldBe("doggies"),
                
                // Plural form supplied
                () => Inflector.Inflect("doggies", 0).ShouldBe("doggies"),
                () => Inflector.Inflect("doggies", 1).ShouldBe("doggy"),
                () => Inflector.Inflect("doggies", 2).ShouldBe("doggies")
            );
        }
        
        [Test]
        public void Words_are_inflected_using_overridden_singular_and_plural_forms_based_on_supplied_count_correctly()
        {
            "".ShouldSatisfyAllConditions(
                // No overrides, showing default Inflection behavior
                () => Inflector.Inflect("do", 0).ShouldBe("dos"),
                () => Inflector.Inflect("do", 1).ShouldBe("do"),
                () => Inflector.Inflect("do", 2).ShouldBe("dos"),
                
                // Overrides, showing Inflection using overrides
                () => Inflector.Inflect("do", 0, "does", "do").ShouldBe("do"),
                () => Inflector.Inflect("do", 1, "does", "do").ShouldBe("does"),
                () => Inflector.Inflect("do", 2, "does", "do").ShouldBe("do"),
                
                // Overrides, showing Inflection using overrides (ignoring the supplied word completely)
                () => Inflector.Inflect(null, 0, "does", "do").ShouldBe("do"),
                () => Inflector.Inflect(null, 1, "does", "do").ShouldBe("does"),
                () => Inflector.Inflect(null, 2, "does", "do").ShouldBe("do")
            );
        }
    }
}