// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Collections.Generic;
using EdFi.Ods.Api.Filters;
using EdFi.Ods.Common.Context;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Filters
{
    public class SchoolYearContextFilterTests : TestFixtureBase
    {
        protected SchoolYearContextFilter _schoolYearContextFilter;
        protected ISchoolYearContextProvider _schoolYearContextProvider;
        protected ActionExecutingContext _httpActionContext;
        protected string _schoolYear;

        private ActionExecutingContext GetActionContext()
        {
            var actioncontext = Stub<ActionContext>();
            var filtermetadata = Stub<IList<IFilterMetadata>>();
            var actionArguments = Stub<IDictionary<string, object>>();
            var controller = Stub<object>();

            actioncontext.HttpContext = A.Fake<HttpContext>();
            actioncontext.RouteData = A.Fake<RouteData>();

            actioncontext.ActionDescriptor = A.Fake<ActionDescriptor>();
            RouteValueDictionary keyValuePairs = new RouteValueDictionary();

            keyValuePairs.Add("schoolYearFromRoute", _schoolYear);

            ActionExecutingContext context = new ActionExecutingContext(actioncontext, filtermetadata, actionArguments, controller);
            context.HttpContext.Request.RouteValues = keyValuePairs;
            return context;

        }

        protected override void Arrange()
        {
            _schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();
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
                A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
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
                A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
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
                A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
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
                A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
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
                A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustNotHaveHappened();
            }
        }

        public class When_School_Year_Is_Valid : SchoolYearContextFilterTests
        {
            protected override void Arrange()
            {
                _schoolYear = "2020";
                base.Arrange();
            }

            [Test]
            public void Should_Valid_School_Year()
            {
                A.CallTo(() => _schoolYearContextProvider.SetSchoolYear(A<int>._)).MustHaveHappened();
            }
        }
    }
}
#endif