// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

// NOTE: Initial test fixture generated using ChatGPT
namespace EdFi.Ods.Api.Middleware.Tests
{
    [TestFixture]
    public class OdsInstanceIdentificationMiddlewareTests
    {
        private IContextProvider<OdsInstanceConfiguration> _contextProvider;
        private IOdsInstanceSelector _instanceSelector;
        private OdsInstanceIdentificationMiddleware _middleware;

        [SetUp]
        public void SetUp()
        {
            _contextProvider = A.Fake<IContextProvider<OdsInstanceConfiguration>>();
            _instanceSelector = A.Fake<IOdsInstanceSelector>();
            _middleware = new OdsInstanceIdentificationMiddleware(_contextProvider, _instanceSelector);
        }

        [Test]
        public async Task InvokeAsync_WithValidConfiguration_SetsContextAndInvokesNext()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var next = A.Fake<RequestDelegate>();
            var configuration = new OdsInstanceConfiguration(1, 1, "TheConnectionString", 
                new Dictionary<string, string>(), new Dictionary<DerivativeType, string>());

            A.CallTo(() => _instanceSelector.GetOdsInstanceAsync()).Returns(configuration);

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            A.CallTo(() => _contextProvider.Set(configuration)).MustHaveHappened();
            A.CallTo(() => next(context)).MustHaveHappened();
        }

        [Test]
        public async Task InvokeAsync_WithNullConfiguration_DoesNotSetContextAndInvokesNext()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var next = A.Fake<RequestDelegate>();

            A.CallTo(() => _instanceSelector.GetOdsInstanceAsync()).Returns(Task.FromResult(null as OdsInstanceConfiguration));

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            A.CallTo(() => _contextProvider.Set(A<OdsInstanceConfiguration>._)).MustNotHaveHappened();
            A.CallTo(() => next(context)).MustHaveHappened();
        }
    }
}
