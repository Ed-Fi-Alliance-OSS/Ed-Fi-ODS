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
    public class YearSpecificContextTests
    {
        private ISchoolYearContextProvider _schoolYearContextProvider;
        private HttpContext _httpContext;

        [SetUp]
        public void SetUp()
        {
            _schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();

            _httpContext = HttpContextHelper.GetActionContext().HttpContext;
        }

        [Test]
        public async Task Should_Not_Parse_School_Year_When_An_Array()
        {
            _httpContext.Request.RouteValues.Add("schoolYearFromRoute", "2010, 2011");

            var sut = new SchoolYearRouteContextMiddleware(_schoolYearContextProvider);

            await sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Not_Parse_Invalid_School_Year()
        {
            _httpContext.Request.RouteValues.Add("schoolYearFromRoute", "abc");

            var sut = new SchoolYearRouteContextMiddleware(_schoolYearContextProvider);

            await sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Not_Parse_A_Null_School_Year()
        {
            _httpContext.Request.RouteValues.Add("schoolYearFromRoute", null);

            var sut = new SchoolYearRouteContextMiddleware(_schoolYearContextProvider);

            await sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Not_Parse_An_Empty_School_Year()
        {
            _httpContext.Request.RouteValues.Add("schoolYearFromRoute", null);

            var sut = new SchoolYearRouteContextMiddleware(_schoolYearContextProvider);

            await sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Not_Parse_Whitespace_School_Year()
        {
            _httpContext.Request.RouteValues.Add("schoolYearFromRoute", " ");

            var sut = new SchoolYearRouteContextMiddleware(_schoolYearContextProvider);

            await sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Process_A_Valid_School_Year()
        {
            var year = DateTime.Now.Year;
            _httpContext.Request.RouteValues.Add("schoolYearFromRoute", year);

            var sut = new SchoolYearRouteContextMiddleware(_schoolYearContextProvider);

            await sut.InvokeAsync(_httpContext, context => Task.CompletedTask);

            A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(year)).MustHaveHappened();
        }
    }
}
