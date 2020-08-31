// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Filters;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Filters
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CheckModelForNullAttributeTests
    {
        [TestFixture]
        public class When_calling_the_check_model_for_null_action_filter : TestFixtureBase
        {
            private ActionExecutingContext actionexecutingcontext;
            private ActionContext actioncontext;
            private IList<IFilterMetadata> filtermetadata;
            private IDictionary<string, object> actionarguments;

            [Assert]
            public void Existing_arguments_should_not_trigger_filter()
            {
                actioncontext = new ActionContext();
                actioncontext.HttpContext = A.Fake<HttpContext>();
                actioncontext.RouteData = A.Fake<RouteData>();
                actioncontext.ActionDescriptor = A.Fake<ActionDescriptor>();
                filtermetadata = A.Fake<IList<IFilterMetadata>>();
                actionarguments = A.Fake<IDictionary<string, object>>();
                actionexecutingcontext = new ActionExecutingContext(actioncontext, filtermetadata, actionarguments,this);
                var actionFilter = new CheckModelForNullAttribute();
                actionexecutingcontext.ActionDescriptor.Properties.Add("request", "ParameterValue");
                actionexecutingcontext.ActionDescriptor.Properties.Add("classParameter", new CheckModelForNullAttribute());

                actionFilter.OnActionExecuting(actionexecutingcontext);
                actionexecutingcontext.Result.ShouldBeNull();
            }

            [Assert]
            public void Single_null_argument_should_trigger_filter()
            {
                actioncontext = new ActionContext();
                actioncontext.HttpContext = A.Fake<HttpContext>();
                actioncontext.RouteData = A.Fake<RouteData>();
                actioncontext.ActionDescriptor = A.Fake<ActionDescriptor>();
                filtermetadata = A.Fake<IList<IFilterMetadata>>();
                actionarguments = A.Fake<IDictionary<string, object>>();
                actionexecutingcontext = new ActionExecutingContext(actioncontext, filtermetadata, actionarguments, this);
                actionexecutingcontext.ActionDescriptor.Properties.Add("request", "ParameterValue");
                actionexecutingcontext.ActionDescriptor.Properties.Add("classParameter", null);

                var actionFilter = new CheckModelForNullAttribute();

                actionFilter.OnActionExecuting(actionexecutingcontext);
                BadRequestObjectResult response =(BadRequestObjectResult)actionexecutingcontext.Result;
                response.ShouldNotBeNull();

                var responseMessage = response.Value;
                responseMessage.ShouldBe("The request is invalid because it is missing a classParameter.");
            }

            [Assert]
            public void Multiple_null_arguments_should_trigger_filter()
            {
                var actionFilter = new CheckModelForNullAttribute();
                actioncontext = new ActionContext();
                actioncontext.HttpContext = A.Fake<HttpContext>();
                actioncontext.RouteData = A.Fake<RouteData>();
                actioncontext.ActionDescriptor = A.Fake<ActionDescriptor>();
                filtermetadata = A.Fake<IList<IFilterMetadata>>();
                actionarguments = A.Fake<IDictionary<string, object>>();
                actionexecutingcontext = new ActionExecutingContext(actioncontext, filtermetadata, actionarguments, this);
                actionexecutingcontext.ActionDescriptor.Properties.Add("request", null);
                actionexecutingcontext.ActionDescriptor.Properties.Add("classParameter", null);

                actionFilter.OnActionExecuting(actionexecutingcontext);
                BadRequestObjectResult response = (BadRequestObjectResult)actionexecutingcontext.Result;
                response.ShouldNotBeNull();

                var responseMessage = response.Value;
                responseMessage.ShouldBe("The request is invalid because it is missing request', 'classParameter ");
            }
        }
    }
}
#endif
