// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
    public class InstanceIdContextFilterTests : TestFixtureBase
    {
        protected InstanceIdContextFilter _instanceIdContextFilter;
        protected IInstanceIdContextProvider _instanceIdContextProvider;
        protected ActionExecutingContext _httpActionContext;
        protected string _instanceId;

        private ActionExecutingContext GetActionContext()
        {
            var actionContext = Stub<ActionContext>();
            var filterMetadata = Stub<IList<IFilterMetadata>>();
            var actionArguments = Stub<IDictionary<string, object>>();
            var controller = Stub<object>();

            actionContext.HttpContext = A.Fake<HttpContext>();
            actionContext.RouteData = A.Fake<RouteData>();

            actionContext.ActionDescriptor = A.Fake<ActionDescriptor>();
            RouteValueDictionary keyValuePairs = new RouteValueDictionary();

            keyValuePairs.Add("instanceIdFromRoute", _instanceId);

            ActionExecutingContext context = new ActionExecutingContext(actionContext, filterMetadata, actionArguments, controller);
            context.HttpContext.Request.RouteValues = keyValuePairs;
            return context;
        }

        protected override void Arrange()
        {
            _instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();
            _instanceIdContextFilter = new InstanceIdContextFilter(_instanceIdContextProvider);
            _httpActionContext = GetActionContext();
        }

        protected override void Act()
        {
            _instanceIdContextFilter.OnActionExecuting(_httpActionContext);
        }

        public class When_Instance_Id_Is_An_Array : InstanceIdContextFilterTests
        {
            protected override void Arrange()
            {
                _instanceId = "instance1, instance2";
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_Instance_Id()
            {
                A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
            }
        }

        public class When_Instance_Id_Is_Empty : InstanceIdContextFilterTests
        {
            protected override void Arrange()
            {
                _instanceId = "";
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_InValid_Instance_Id()
            {
                A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
            }
        }

        public class When_Instance_Id_Is_Null : InstanceIdContextFilterTests
        {
            protected override void Arrange()
            {
                _instanceId = null;
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_Instance_Id()
            {
                A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
            }
        }


        public class When_Instance_Id_Is_WhiteSpace : InstanceIdContextFilterTests
        {
            protected override void Arrange()
            {
                _instanceId = " ";
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_Instance_Id()
            {
                A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
            }
        }

        public class When_Instance_Id_Is_Special_Character_Other_Than_Hyphen : InstanceIdContextFilterTests
        {
            protected override void Arrange()
            {
                _instanceId = "@#$";
                base.Arrange();
            }

            [Test]
            public void Should_Not_Parse_Instance_Id()
            {
                A.CallTo(() => _instanceIdContextProvider.SetInstanceId(A<string>._)).MustNotHaveHappened();
            }
        }


        public class When_Instance_Id_Is_Valid_AlphaNumeric : InstanceIdContextFilterTests
        {
            protected override void Arrange()
            {
                _instanceId = "instance1";
                base.Arrange();
            }

            [Test]
            public void Should_Valid_Instance_Id()
            {
                A.CallTo(() => _instanceIdContextProvider.SetInstanceId(_instanceId)).MustHaveHappened();
            }
        }

        public class When_Instance_Id_Is_Valid_Guid : InstanceIdContextFilterTests
        {
            protected override void Arrange()
            {
                _instanceId = "eaa24756-3fac-4e46-b4bb-074ff4f5b846";
                base.Arrange();
            }

            [Test]
            public void Should_Valid_Instance_Id()
            {
                A.CallTo(() => _instanceIdContextProvider.SetInstanceId(_instanceId)).MustHaveHappened();
            }
        }

    }
}