// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.LoadTools.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdFi.LoadTools.Test
{
    public class ExtensionMethodsTests
    {
        [TestClass]
        public class InitialUpperCase
        {
            private const string LowerCase = "test";
            private const string UpperCase = "Test";

            [TestMethod]
            public void Should_capitalize_initial_lower_case()
            {
                Assert.AreEqual(LowerCase.InitialUpperCase(), UpperCase);
            }

            [TestMethod]
            public void Should_not_change_initial_upper_case()
            {
                Assert.AreEqual(UpperCase.InitialUpperCase(), UpperCase);
            }
        }

        [TestClass]
        public class AreMatchingSimpleTypes
        {
            [TestMethod]
            public void Should_match_overlapping_types()
            {
                Assert.IsTrue(ExtensionMethods.AreMatchingSimpleTypes("string", "String"));
                Assert.IsTrue(ExtensionMethods.AreMatchingSimpleTypes("string", "Token"));
            }

            [TestMethod]
            public void Should_identify_unmatched_types()
            {
                Assert.IsFalse(ExtensionMethods.AreMatchingSimpleTypes("string", "Int"));
            }

            [TestMethod]
            public void Should_not_match_simple_to_complex_types()
            {
                Assert.IsFalse(ExtensionMethods.AreMatchingSimpleTypes("string", "ComplexType"));
            }
        }

        [TestClass]
        public class IsPrimitiveType
        {
            [TestMethod]
            public void Should_match_my_types()
            {
                Assert.IsTrue(typeof(int).IsPrimitiveType());
                Assert.IsTrue(typeof(string).IsPrimitiveType());
                Assert.IsTrue(typeof(Guid).IsPrimitiveType());
                Assert.IsTrue(typeof(DateTime).IsPrimitiveType());
                Assert.IsFalse(typeof(object).IsPrimitiveType());
            }
        }

        [TestClass]
        public class GetUnderlyingTypeTests
        {
            [TestMethod]
            public void Should_work_for_nullables()
            {
                Assert.AreEqual(ExtensionMethods.GetUnderlyingType(typeof(int?)), typeof(int));
                Assert.AreEqual(ExtensionMethods.GetUnderlyingType(typeof(DateTime?)), typeof(DateTime));
                Assert.AreEqual(ExtensionMethods.GetUnderlyingType(typeof(Guid?)), typeof(Guid));
            }
        }

        [TestClass]
        public class When_matching_namespace_for_assessments
        {
            [TestMethod]
            public void Should_match_the_assessment_reference_assessment_identity_namespace_to_assessment_reference_namespace()
            {
                string xmlPropertyPath = "AssessmentReference/AssessmentIdentity/Namespace";
                string correctJsonPath = "assessmentReference/namespace";
                string invalidJsonPath = "studentObjectiveAssessments/objectiveAssessmentReference/namespace";

                double correctResult = ExtensionMethods.PropertyPathPercentMatchTo(xmlPropertyPath, correctJsonPath);
                double invalidResult = ExtensionMethods.PropertyPathPercentMatchTo(xmlPropertyPath, invalidJsonPath);

                Console.WriteLine("correctResult = {0:0.00}, invalidResult = {1:0.00}", correctResult, invalidResult);

                Assert.IsTrue(correctResult > invalidResult);
            }
        }
    }
}
