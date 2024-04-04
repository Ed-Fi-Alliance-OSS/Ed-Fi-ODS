// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.LoadTools.SmokeTest.SdkTests;
using EdFi.OdsApi.Sdk.Apis.All;
using NUnit.Framework;
using Moq;

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class DirectedGraphTests
    {
        private static readonly ISdkLibraryFactory SdkLibraryFactory =
            Mock.Of<ISdkLibraryFactory>(f => f.SdkLibrary == typeof(AcademicWeeksApi).Assembly);

        [Test]
        public void Should_order_types()
        {
            var cat = Mock.Of<ISdkCategorizer>(
                c => c.ModelTypes == new[]
                {
                    typeof(A),
                    typeof(B),
                    typeof(C),
                    typeof(D),
                    typeof(DReference),
                    typeof(E),
                    typeof(EReference),
                    typeof(FType),
                    typeof(FDescriptor)
                });

            var mds = new ModelDependencySort(cat);
            var sortedResult = mds.OrderedModels().ToList();

            foreach (var type in sortedResult)
            {
                Console.WriteLine(type.FullName);
            }

            Assert.IsTrue(sortedResult.IndexOf(typeof(A)) > sortedResult.IndexOf(typeof(B)));
            Assert.IsTrue(sortedResult.IndexOf(typeof(A)) > sortedResult.IndexOf(typeof(C)));
            Assert.IsTrue(sortedResult.IndexOf(typeof(A)) > sortedResult.IndexOf(typeof(FDescriptor)));
            Assert.IsTrue(sortedResult.IndexOf(typeof(A)) > sortedResult.IndexOf(typeof(FType)));

            Assert.IsTrue(sortedResult.IndexOf(typeof(B)) > sortedResult.IndexOf(typeof(DReference)));

            Assert.IsTrue(sortedResult.IndexOf(typeof(C)) > sortedResult.IndexOf(typeof(EReference)));

            Assert.IsTrue(sortedResult.IndexOf(typeof(DReference)) > sortedResult.IndexOf(typeof(D)));

            Assert.IsTrue(sortedResult.IndexOf(typeof(EReference)) > sortedResult.IndexOf(typeof(E)));

            Assert.IsTrue(sortedResult.IndexOf(typeof(FDescriptor)) > sortedResult.IndexOf(typeof(FType)));
        }

        [Test]
        public void Should_resolve_longer_reference()
        {
            var cat = Mock.Of<ISdkCategorizer>(
                c => c.ModelTypes == new[]
                {
                    typeof(Alpha),
                    typeof(BravoCharlieType),
                    typeof(AlphaBravoCharlieType)
                });

            var mds = new ModelDependencySort(cat);
            var sortedResult = mds.OrderedModels().ToList();

            foreach (var type in sortedResult)
            {
                Console.WriteLine(type.FullName);
            }

            Assert.IsTrue(sortedResult.IndexOf(typeof(Alpha)) > sortedResult.IndexOf(typeof(BravoCharlieType)));
            Assert.IsTrue(sortedResult.IndexOf(typeof(Alpha)) > sortedResult.IndexOf(typeof(AlphaBravoCharlieType)));
        }

        [Test]
        [Category("RunManually")]
        public void Should_order_types_from_Sdk()
        {
            var cat = new SdkCategorizer(SdkLibraryFactory);
            var mds = new ModelDependencySort(cat);
            var sortedResult = mds.OrderedModels().ToArray();

            foreach (var type in sortedResult)
            {
                Console.WriteLine(type.FullName);
            }
        }

        [Test]
        [Category("RunManually")]
        public void Should_order_Apis_from_Sdk()
        {
            var cat = new SdkCategorizer(SdkLibraryFactory);
            var mds = new ModelDependencySort(cat);
            var sortedResult = mds.OrderedApis().ToArray();

            foreach (var type in sortedResult)
            {
                Console.WriteLine(type.Name);
            }
        }

        public class A
        {
            public string Ignored1 { get; set; }

            public B B1 { get; set; }

            public C C1 { get; set; }

            public string fDescriptor { get; set; }

            public string fType { get; set; }
        }

        public class B
        {
            public DReference DReference1 { get; set; }
        }

        public class C
        {
            public List<EReference> EReference1 { get; set; }
        }

        public class D { }

        public class DReference
        {
            public D D1 { get; set; }
        }

        public class E
        {
            public EReference EReference1 { get; set; }
        }

        public class EReference
        {
            public E E1 { get; set; }
        }

        public class FDescriptor
        {
            public int? fDescriptorId { get; set; }

            public string codeValue { get; set; }

            public string shortDescription { get; set; }
        }

        public class FType
        {
            public int? fTypeId { get; set; }

            public string codeValue { get; set; }

            public string shortDescription { get; set; }
        }

        public class AlphaBravoCharlieType { }

        public class BravoCharlieType { }

        public class Alpha
        {
            /// <summary>
            ///     Extend to  alphaBravoCharlieType
            /// </summary>
            public string bravoCharlieType { get; set; }

            /// <summary>
            ///     throw away foobar, and reference to a BravoCharlieType
            /// </summary>
            public string foobarBravoCharlieType { get; set; }
        }
    }
}
