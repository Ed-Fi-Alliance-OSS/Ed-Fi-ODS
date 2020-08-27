// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Common.Context;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Filters
{
    public class SchoolYearContextFilterTests : LegacyTestFixtureBase
    {
        protected SchoolYearContextFilter _schoolYearContextFilter;
        protected ISchoolYearContextProvider _schoolYearContextProvider;
        protected HttpActionContext _httpActionContext;
        protected string _schoolYear;

        private HttpActionContext GetActionContext()
        {
            var request =
                new HttpRequestMessage
                {
                    RequestUri = new Uri("http://owin/api/v3/" + _schoolYear + "/controller")
                };

            var controllerContext =
                new HttpControllerContext
                {
                    Request = request, RouteData = new HttpRouteData(new HttpRoute())
                };

            return new HttpActionContext
                   {
                       ControllerContext = controllerContext
                   };
        }

        protected override void Arrange()
        {
            _schoolYearContextProvider = MockRepository.GenerateMock<ISchoolYearContextProvider>();
            _schoolYearContextFilter = new SchoolYearContextFilter(_schoolYearContextProvider);
            _httpActionContext = GetActionContext();
        }

        protected override void Act()
        {
            _schoolYearContextFilter.OnActionExecuting(_httpActionContext);
        }

        public class When_School_Year_Is_An_Array : SchoolYearContextFilterTests
        {
            protected override void Arrange()
            {
                _schoolYear = "2017, 2018";
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_School_Year()
            {
                _schoolYearContextProvider.AssertWasNotCalled(x => x.SetSchoolYear(Arg<int>.Is.Anything));
            }
        }

        public class When_School_Year_Is_A_String : SchoolYearContextFilterTests
        {
            protected override void Arrange()
            {
                _schoolYear = "abc";
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_InValid_School_Year()
            {
                _schoolYearContextProvider.AssertWasNotCalled(x => x.SetSchoolYear(Arg<int>.Is.Anything));
            }
        }

        public class When_School_Year_Is_Null : SchoolYearContextFilterTests
        {
            protected override void Arrange()
            {
                _schoolYear = null;
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_School_Year()
            {
                _schoolYearContextProvider.AssertWasNotCalled(x => x.SetSchoolYear(Arg<int>.Is.Anything));
            }
        }

        public class When_School_Year_Is_Empty : SchoolYearContextFilterTests
        {
            protected override void Arrange()
            {
                _schoolYear = string.Empty;
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_School_Year()
            {
                _schoolYearContextProvider.AssertWasNotCalled(x => x.SetSchoolYear(Arg<int>.Is.Anything));
            }
        }

        public class When_School_Year_Is_WhiteSpace : SchoolYearContextFilterTests
        {
            protected override void Arrange()
            {
                _schoolYear = " ";
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_School_Year()
            {
                _schoolYearContextProvider.AssertWasNotCalled(x => x.SetSchoolYear(Arg<int>.Is.Anything));
            }
        }
    }
}
