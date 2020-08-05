// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Common.ChainOfResponsibility;
using EdFi.Ods.Common.InversionOfControl;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Common
{
    public class ChainOfResponsibilityFacilityTests
    {
        // An interface to be backed by a chain of responsibility in this test
        public interface ISomethingProvider
        {
            int GetSomething(int a, long b, string c, DateTime d, double e, float f, HashSet<string> g);
        }

        // A request object matching the provider method signature
        public class GetSomethingRequest
        {
            public int A { get; set; }

            public long B { get; set; }

            public string C { get; set; }

            public DateTime D { get; set; }

            public double E { get; set; }

            public float F { get; set; }

            public HashSet<string> G { get; set; }
        }

        // An interface to represent another dependency to be injected by the container onto a link
        public interface IAnotherProvider
        {
            void GetAnother();
        }

        public class FirstSomethingProvider
            : ChainOfResponsibilityBase<ISomethingProvider, GetSomethingRequest, int>, ISomethingProvider
        {
            private readonly IAnotherProvider anotherProvider;

            // Constructor required for Castle to wire up chain behavior
            public FirstSomethingProvider(ISomethingProvider next, IAnotherProvider anotherProvider)
                : base(next)
            {
                this.anotherProvider = anotherProvider;
            }

            // -------------------------------
            //  End core logic implementation
            // ===============================

            // Main interface entry point, handled by Chain of Responsibility facility
            public int GetSomething(int a, long b, string c, DateTime d, double e, float f, HashSet<string> g)
            {
                throw new NotImplementedException("Chain of Responsibility interceptor should handle this invocation.");
            }

            // ===============================
            // Begin core logic implementation
            // -------------------------------
            protected override bool CanHandleRequest(GetSomethingRequest request)
            {
                if (request.A == 1)
                {
                    return true;
                }

                return false;
            }

            protected override int HandleRequest(GetSomethingRequest request)
            {
                request.G.Add(
                    GetType()
                       .Name);

                return 1;
            }
        }

        public class SecondSomethingProvider
            : ChainOfResponsibilityBase<ISomethingProvider, GetSomethingRequest, int>, ISomethingProvider
        {
            // Constructor required for Castle to wire up chain behavior
            public SecondSomethingProvider(ISomethingProvider next)
                : base(next) { }

            // -------------------------------
            //  End core logic implementation
            // ===============================

            // Main interface entry point, handled by Chain of Responsibility facility
            public int GetSomething(int a, long b, string c, DateTime d, double e, float f, HashSet<string> g)
            {
                throw new NotImplementedException("Chain of Responsibility interceptor should handle this invocation.");
            }

            // ===============================
            // Begin core logic implementation
            // -------------------------------
            protected override bool CanHandleRequest(GetSomethingRequest request)
            {
                if (request.A == 2)
                {
                    return true;
                }

                return false;
            }

            protected override int HandleRequest(GetSomethingRequest request)
            {
                request.G.Add(
                    GetType()
                       .Name);

                return 2;
            }
        }

        public class When_resolving_a_chain_of_responsibility_using_IoC : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values
            private ISomethingProvider actualSomethingProvider;
            private HashSet<string> actualLinkedTypes;
            private int actualCall1Result;
            private int actualCall2Result;
            private Exception actualExceptionCall3;

            // External dependencies
            private IWindsorContainer container;
            private IAnotherProvider anotherProvider;

            protected override void EstablishContext()
            {
                container = new WindsorContainer();

                // Add the facility, capturing a reference so we can "Finalize" it
                ChainOfResponsibilityFacility facility = null;
                container.AddFacility<ChainOfResponsibilityFacility>(f => facility = f);

                // Perform all registrations of links in the chain using the standard approach
                container.Register(
                    Classes.FromThisAssembly()
                           .BasedOn<ISomethingProvider>()
                           .WithService
                           .FromInterface());

                // Finalize all Chain of Responsibility chains (registering the proxy last, required prior to Castle 3.x)
                facility.FinalizeChains();

                anotherProvider = mocks.Stub<IAnotherProvider>();

                container.Register(
                    Component.For<IAnotherProvider>()
                             .Instance(anotherProvider));
            }

            protected override void Act()
            {
                actualSomethingProvider = container.Resolve<ISomethingProvider>();
                actualLinkedTypes = new HashSet<string>();

                // Execute requests, with the 3rd one unhandled
                actualCall1Result = actualSomethingProvider.GetSomething(
                    1,
                    11,
                    "",
                    DateTime.Now,
                    0,
                    0,
                    actualLinkedTypes);

                actualCall2Result = actualSomethingProvider.GetSomething(
                    2,
                    22,
                    "",
                    DateTime.Now,
                    0,
                    0,
                    actualLinkedTypes);

                try
                {
                    actualSomethingProvider.GetSomething(3, 33, "", DateTime.Now, 0, 0, actualLinkedTypes);
                }
                catch (Exception ex)
                {
                    actualExceptionCall3 = ex;
                }
            }

            [Test]
            public void Should_properly_process_handled_requests()
            {
                Assert.That(actualCall1Result, Is.EqualTo(1));
                Assert.That(actualCall2Result, Is.EqualTo(2));
            }

            [Test]
            public void Should_resolve_all_links_in_chain()
            {
                Assert.That(actualLinkedTypes, Contains.Item("FirstSomethingProvider"));
                Assert.That(actualLinkedTypes, Contains.Item("SecondSomethingProvider"));
                Assert.That(actualLinkedTypes, Has.Count.EqualTo(2));
            }

            [Test]
            public void Should_throw_a_NotSupportedException_when_an_unhandled_request_is_made()
            {
                Assert.That(actualExceptionCall3, Is.TypeOf<NotSupportedException>());
            }
        }

        //For Chain of responsibilities with base abstract class 
        public class TestRequestBase { }

        public class TestRequest : TestRequestBase { }

        public interface ITestProvider
        {
            TestResponse Get(TestRequestBase request);
        }

        public class TestResponse { }

        public abstract class BaseTestProvider
            : ChainOfResponsibilityBase<ITestProvider, TestRequestBase, TestResponse>, ITestProvider
        {
            protected BaseTestProvider(ITestProvider next)
                : base(next) { }

            public abstract TestResponse Get(TestRequestBase request);

            protected override TestResponse HandleRequest(TestRequestBase request)
            {
                return Get(request);
            }
        }

        public class TestProvider : BaseTestProvider
        {
            public TestProvider(ITestProvider next)
                : base(next) { }

            protected override bool CanHandleRequest(TestRequestBase request)
            {
                return request is TestRequest;
            }

            public override TestResponse Get(TestRequestBase request)
            {
                return Get((TestRequest) request);
            }

            public TestResponse Get(TestRequest request)
            {
                return new TestResponse();
            }
        }

        public class When_resolving_a_chain_of_responsibility_with_base_class_using_IoC : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values
            private ITestProvider actualSomethingProvider;
            private TestResponse actualResponse;

            // External dependencies
            private IWindsorContainer container;

            protected override void EstablishContext()
            {
                container = new WindsorContainer();

                // Add the facility, capturing a reference so we can "Finalize" it
                ChainOfResponsibilityFacility facility = null;
                container.AddFacility<ChainOfResponsibilityFacility>(f => facility = f);

                // Perform all registrations of links in the chain using the standard approach
                container.Register(
                    Classes.FromThisAssembly()
                           .BasedOn<ITestProvider>()
                           .WithService
                           .FromInterface());

                // Finalize all Chain of Responsibility chains (registering the proxy last, required prior to Castle 3.x)
                facility.FinalizeChains();
            }

            protected override void Act()
            {
                actualSomethingProvider = container.Resolve<ITestProvider>();
                actualResponse = actualSomethingProvider.Get(new TestRequest());
            }

            [Test]
            public void Should_return_test_response()
            {
                Assert.That(actualResponse != null);
            }
        }

        public class LegacyChainOfResponsibilityTests
        {
            // Simple interface for the legacy test
            public interface ISomethingElseProvider
            {
                int GetSomethingElse(int a);
            }

            // Request matching the method
            public class GetSomethingElseRequest
            {
                public int A { get; set; }
            }

            // Original Chain of Responsibility implementation's chain "null" terminator
            public class NullSomethingElseProvider : ISomethingElseProvider
            {
                public int GetSomethingElse(int a)
                {
                    return default(int);
                }
            }

            public class FirstSomethingElseProvider
                : ChainOfResponsibilityBase<ISomethingElseProvider, GetSomethingElseRequest, int>,
                  ISomethingElseProvider
            {
                public FirstSomethingElseProvider(ISomethingElseProvider next)
                    : base(next) { }

                public int GetSomethingElse(int a)
                {
                    return 1;
                }

                protected override bool CanHandleRequest(GetSomethingElseRequest request)
                {
                    // Because the ProcessRequest method is not invoked by the link implementations 
                    // in this test, the only way this method would be called is if the the facility's
                    // interceptor has handled the GetSomethingElse call (and thus would throw this exception
                    // and fail the test).
                    throw new InvalidOperationException(
                        "ChainOfResponsibilityFacility's interceptor invoked ProcessRequest.");
                }

                protected override int HandleRequest(GetSomethingElseRequest request)
                {
                    throw new InvalidOperationException(
                        "ChainOfResponsibilityFacility's interceptor invoked ProcessRequest.");
                }
            }

            public class SecondSomethingElseProvider
                : ChainOfResponsibilityBase<ISomethingElseProvider, GetSomethingElseRequest, int>,
                  ISomethingElseProvider
            {
                public SecondSomethingElseProvider(ISomethingElseProvider next)
                    : base(next) { }

                public int GetSomethingElse(int a)
                {
                    return 2;
                }

                protected override bool CanHandleRequest(GetSomethingElseRequest request)
                {
                    // Because the ProcessRequest method is not invoked by the link implementations 
                    // in this test, the only way this method would be called is if the the facility's
                    // interceptor has handled the GetSomethingElse call (and thus would throw this exception
                    // and fail the test).
                    throw new InvalidOperationException(
                        "ChainOfResponsibilityFacility's interceptor invoked ProcessRequest.");
                }

                protected override int HandleRequest(GetSomethingElseRequest request)
                {
                    throw new InvalidOperationException(
                        "ChainOfResponsibilityFacility's interceptor invoked ProcessRequest.");
                }
            }

            public class When_using_the_legacy_ChainOfResponsiblityRegistrar_to_register_a_chain : LegacyTestFixtureBase
            {
                // Supplied values

                // Actual values
                private ISomethingElseProvider actualSomethingElseProvider;
                private Exception actualException;

                // External dependencies
                private IWindsorContainer container;

                protected override void EstablishContext()
                {
                    // Set up mocked dependences and supplied values
                    container = new WindsorContainer();

                    // Add the facility, capturing a reference so we can "Finalize" it
                    ChainOfResponsibilityFacility facility = null;
                    container.AddFacility<ChainOfResponsibilityFacility>(f => facility = f);

                    // Perform a legacy chain of responsibility registration
                    var registrar = new ChainOfResponsibilityRegistrar(container);

                    registrar.RegisterChainOf<ISomethingElseProvider, NullSomethingElseProvider>(
                        new[]
                        {
                            typeof(FirstSomethingElseProvider), typeof(SecondSomethingElseProvider)
                        });

                    // Finalize all Chain of Responsibility chains (registering the proxy last, required prior to Castle 3.x)
                    facility.FinalizeChains();
                }

                protected override void Act()
                {
                    // Perform the action to be tested
                    actualSomethingElseProvider = container.Resolve<ISomethingElseProvider>();

                    try
                    {
                        // Execute request
                        actualSomethingElseProvider.GetSomethingElse(1);
                    }
                    catch (Exception ex)
                    {
                        // An exception will be thrown if the new Chain of Responsiblity interceptor is invoked
                        actualException = ex;
                    }
                }

                [Test]
                public void Should_not_engage_the_ChainOfResponsibility_interceptor()
                {
                    Assert.That(
                        actualException,
                        Is.Null,
                        "ChainOfResponsibility interceptor was engaged on a legacy chain.");
                }
            }
        }

        public class MethodOverLoadTestFixture
        {
            // An interface to be backed by a chain of responsibility in this test
            public interface ISomethingWithMethodOverLoads
            {
                int GetSomething(int a, long b, string c, DateTime d, double e, float f, HashSet<string> g);

                int GetSomething(long b, int a);
            }

            public class FirstSomethingWithMethodOverLoads
                : ChainOfResponsibilityBase<ISomethingWithMethodOverLoads, GetSomethingRequest, int>, ISomethingWithMethodOverLoads
            {
                // Constructor required for Castle to wire up chain behavior
                public FirstSomethingWithMethodOverLoads(ISomethingWithMethodOverLoads next)
                    : base(next) { }

                // -------------------------------
                //  End core logic implementation
                // ===============================

                // Main interface entry point, handled by Chain of Responsibility facility
                public int GetSomething(int a, long b, string c, DateTime d, double e, float f, HashSet<string> g)
                {
                    return 1;
                }

                public int GetSomething(long b, int a)
                {
                    return 2;
                }

                // ===============================
                // Begin core logic implementation
                // -------------------------------
                protected override bool CanHandleRequest(GetSomethingRequest request)
                {
                    return request.A == 1;
                }

                protected override int HandleRequest(GetSomethingRequest request)
                {
                    return request.C == ""
                        ? GetSomething(request.B, request.A)
                        : GetSomething(request.A, request.B, request.C, request.D, request.E, request.F, request.G);
                }
            }

            public class SecondSomethingWithMethodOverloads
                : ChainOfResponsibilityBase<ISomethingWithMethodOverLoads, GetSomethingRequest, int>, ISomethingWithMethodOverLoads
            {
                // Constructor required for Castle to wire up chain behavior
                public SecondSomethingWithMethodOverloads(ISomethingWithMethodOverLoads next)
                    : base(next) { }

                // -------------------------------
                //  End core logic implementation
                // ===============================

                // Main interface entry point, handled by Chain of Responsibility facility
                public int GetSomething(int a, long b, string c, DateTime d, double e, float f, HashSet<string> g)
                {
                    return 6;
                }

                public int GetSomething(long b, int a)
                {
                    return 7;
                }

                // ===============================
                // Begin core logic implementation
                // -------------------------------
                protected override bool CanHandleRequest(GetSomethingRequest request)
                {
                    return request.A == 2;
                }

                protected override int HandleRequest(GetSomethingRequest request)
                {
                    return request.G == null
                        ? GetSomething(request.B, request.A)
                        : GetSomething(request.A, request.B, request.C, request.D, request.E, request.F, request.G);
                }
            }

            public class When_using_the_chain_of_responsibility_with_different_method_signatures : LegacyTestFixtureBase
            {
                private ISomethingWithMethodOverLoads _actualSomethingProvider;
                private int _actualCallForFirstResult1;
                private int _actualCallForFirstResult2;
                private int _actualCallForSecondResult1;
                private int _actualCallForSecondResult2;

                // External dependencies
                private IWindsorContainer _container;

                protected override void Arrange()
                {
                    // Set up mocked dependencies and supplied values
                    _container = new WindsorContainer();

                    // Add the facility, capturing a reference so we can "Finalize" it
                    ChainOfResponsibilityFacility facility = null;
                    _container.AddFacility<ChainOfResponsibilityFacility>(f => facility = f);

                    _container.Register(
                        Classes.FromThisAssembly()
                               .BasedOn<ISomethingWithMethodOverLoads>()
                               .WithService
                               .FromInterface());

                    // Finalize all Chain of Responsibility chains (registering the proxy last, required prior to Castle 3.x)
                    facility.FinalizeChains();
                }

                protected override void Act()
                {
                    _actualSomethingProvider = _container.Resolve<ISomethingWithMethodOverLoads>();

                    // Execute against the first implementation (can handle a == 1)
                    _actualCallForFirstResult1 = _actualSomethingProvider.GetSomething(1, 11, "", DateTime.Now, 0, 0, new HashSet<string>());
                    _actualCallForFirstResult2 = _actualSomethingProvider.GetSomething(22, 1);

                    // Execute against the second implementation can handle(a == 2)
                    _actualCallForSecondResult1 = _actualSomethingProvider.GetSomething(2, 11, "", DateTime.Now, 0, 0, new HashSet<string>());
                    _actualCallForSecondResult2 = _actualSomethingProvider.GetSomething(22, 2);

                    // unhandled request
                    var result = _actualSomethingProvider.GetSomething(0, 3);
                }

                [Assert]
                public void Should_return_the_value_from_the_method_indicated_by_the_signature_used()
                {
                    AssertHelper.All(
                        () => Assert.That(_actualCallForFirstResult1, Is.EqualTo(2)),
                        () => Assert.That(_actualCallForFirstResult2, Is.EqualTo(1)),
                        () => Assert.That(_actualCallForSecondResult1, Is.EqualTo(6)),
                        () => Assert.That(_actualCallForSecondResult2, Is.EqualTo(7)));
                }

                [Assert]
                public void Should_throw_for_unhandled_request()
                {
                    Assert.That(ActualException, Is.TypeOf<NotSupportedException>());
                }
            }
        }

        // TODO: Add tests that verify validations of chains, including:
        //       * Non-CoR-inheriting class registered first, followed by CoR-inheriting classes (should throw exception, invalid chain)
        //       * CoR-inheriting class registered first, followed by non-CoR-inheriting classes (should throw exception, invalid chain)
        //       * Make sure the facility doesn't get in the way of clean, single-implementation providers
        //       * Attempt to Finalize chains twice

        // TODO: Modify support for Request object instantiation to match what is produced by Resharper refactoring "Extract class from parameters"?
    }
}
