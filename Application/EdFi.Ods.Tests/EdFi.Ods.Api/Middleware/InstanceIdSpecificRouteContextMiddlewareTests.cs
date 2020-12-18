// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Context;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware
{
    [TestFixture]
    public class InstanceIdSpecificRouteContextMiddlewareTests
    {
        private IInstanceIdContextProvider _instanceIdContextProvider;
        private HttpContext _httpContext;
        private InstanceIdSpecificRouteContextMiddleware _sut;

        [SetUp]
        public void SetUp()
        {
            _instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();

            _httpContext = HttpContextHelper.GetActionContext().HttpContext;

            _sut = new InstanceIdSpecificRouteContextMiddleware(_instanceIdContextProvider);
        }

        [Test]
        public async Task Should_Not_Parse_Null_InstanceId()
        {
            _httpContext.Request.RouteValues.Add("instanceIdFromRoute", null);

            await _sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Not_Parse_Empty_InstanceId()
        {
            _httpContext.Request.RouteValues.Add("instanceIdFromRoute", string.Empty);

            await _sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Not_Parse_WhiteSpace_InstanceId()
        {
            _httpContext.Request.RouteValues.Add("instanceIdFromRoute", " ");

            await _sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Parse_Valid_InstanceId()
        {
            string instanceId = Guid.NewGuid().ToString("n");

            _httpContext.Request.RouteValues.Add("instanceIdFromRoute", instanceId);

            await _sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _instanceIdContextProvider.SetInstanceId(instanceId)).MustHaveHappenedOnceExactly();
        }
    }
}
