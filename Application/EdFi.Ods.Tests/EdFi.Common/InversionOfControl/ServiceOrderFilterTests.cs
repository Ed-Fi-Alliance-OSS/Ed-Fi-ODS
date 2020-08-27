// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.TestFixture;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Common.InversionOfControl
{
    internal interface ITestService { }

    internal class TestServiceA : ITestService { }

    internal class TestServiceB : ITestService { }

    internal class TestServiceC : ITestService { }

    internal class TestServiceD : ITestService { }

    internal class FakeHandler : IHandler
    {
        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            throw new NotImplementedException();
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            throw new NotImplementedException();
        }

        public void Init(IKernelInternal kernel)
        {
            throw new NotImplementedException();
        }

        public bool IsBeingResolvedInContext(CreationContext context)
        {
            throw new NotImplementedException();
        }

        public bool Release(Burden burden)
        {
            throw new NotImplementedException();
        }

        public object Resolve(CreationContext context)
        {
            throw new NotImplementedException();
        }

        public bool Supports(Type service)
        {
            throw new NotImplementedException();
        }

        public bool SupportsAssignable(Type service)
        {
            throw new NotImplementedException();
        }

        public object TryResolve(CreationContext context)
        {
            throw new NotImplementedException();
        }

        public ComponentModel ComponentModel { get; set; }

        public HandlerState CurrentState { get; private set; }
    }

    public static class ServiceOrderFilterTestHelper
    {
        public static IHandler[] GetHandlers()
        {
            var handlers = new List<IHandler>
                           {
                               GetHandler(typeof(TestServiceA)), GetHandler(typeof(TestServiceB)), GetHandler(typeof(TestServiceC)),
                               GetHandler(typeof(TestServiceD))
                           };

            return handlers.ToArray();
        }

        private static IHandler GetHandler(Type implType)
        {
            var handler = new FakeHandler();

            var componentModel = new ComponentModel(
                new ComponentName(implType.ToString(), true),
                new[]
                {
                    typeof(ITestService)
                },
                implType,
                null);

            handler.ComponentModel = componentModel;
            return handler;
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_Resolving_Nested_Handler_Order : TestFixtureBase
    {
        private IHandler[] _handlers;
        private IHandlersFilter<ITestService> _sof;
        private IHandler[] _orderedHandlers;

        protected override void Arrange()
        {
            _sof = new ServiceOrderHandlersFilter<ITestService>();

            _sof.Execute<TestServiceD>()
                .Before<TestServiceA>();

            _sof.Execute<TestServiceD>()
                .Before<TestServiceB>();

            _sof.Execute<TestServiceC>()
                .After<TestServiceB>();

            _handlers = ServiceOrderFilterTestHelper.GetHandlers();
        }

        protected override void Act()
        {
            _orderedHandlers = _sof.SelectHandlers(typeof(ITestService), _handlers);
        }

        [Test]
        public void Should_Return_The_Handlers_In_The_Correct_Order()
        {
            Assert.That(
                _orderedHandlers[0]
                   .ComponentModel.ComponentName.ToString(),
                Does.Contain(typeof(TestServiceD).ToString()));

            Assert.That(
                new[]
                {
                    typeof(TestServiceA).ToString(), typeof(TestServiceB).ToString()
                }.Contains(
                    _orderedHandlers[1]
                       .ComponentModel.ComponentName.ToString()));

            Assert.That(
                new[]
                {
                    typeof(TestServiceA).ToString(), typeof(TestServiceB).ToString()
                }.Contains(
                    _orderedHandlers[2]
                       .ComponentModel.ComponentName.ToString()));

            Assert.That(
                _orderedHandlers[3]
                   .ComponentModel.ComponentName.ToString(),
                Does.Contain(typeof(TestServiceC).ToString()));
        }
    }
}
