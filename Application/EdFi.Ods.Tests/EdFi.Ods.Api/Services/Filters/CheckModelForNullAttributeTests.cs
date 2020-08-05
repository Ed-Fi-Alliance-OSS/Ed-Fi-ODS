// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using EdFi.Ods.Api.Services.Filters;
using EdFi.TestFixture;
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
            [Assert]
            public void Existing_arguments_should_not_trigger_filter()
            {
                var actionContext = new HttpActionContext();
                var actionFilter = new CheckModelForNullAttribute();
                actionContext.ActionArguments.Add("request", "ParameterValue");
                actionContext.ActionArguments.Add("classParameter", new CheckModelForNullAttribute());

                actionFilter.OnActionExecuting(actionContext);
                actionContext.Response.ShouldBeNull();
            }

            [Assert]
            public void Single_null_argument_should_trigger_filter()
            {
                var httpActionDescriptor = Stub<HttpActionDescriptor>();

                var controllerContext = new HttpControllerContext
                                        {
                                            Request = new HttpRequestMessage()
                                        };

                var actionContext = new HttpActionContext(controllerContext, httpActionDescriptor);
                var actionFilter = new CheckModelForNullAttribute();
                actionContext.ActionArguments.Add("requestParameter", "ParameterValue");
                actionContext.ActionArguments.Add("classParameter", null);

                actionFilter.OnActionExecuting(actionContext);
                var response = actionContext.Response;
                response.ShouldNotBeNull();
                response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

                var responseMessage = response.Content.ReadAsStringAsync()
                                              .Result;

                responseMessage.ShouldBe("{\"Message\":\"The request is invalid because it is missing a classParameter.\"}");
            }

            [Assert]
            public void Multiple_null_arguments_should_trigger_filter()
            {
                var httpActionDescriptor = Stub<HttpActionDescriptor>();

                var controllerContext = new HttpControllerContext
                                        {
                                            Request = new HttpRequestMessage()
                                        };

                var actionContext = new HttpActionContext(controllerContext, httpActionDescriptor);
                var actionFilter = new CheckModelForNullAttribute();
                actionContext.ActionArguments.Add("requestParameter", null);
                actionContext.ActionArguments.Add("classParameter", null);

                actionFilter.OnActionExecuting(actionContext);
                var response = actionContext.Response;
                response.ShouldNotBeNull();
                response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

                var responseMessage = response.Content.ReadAsStringAsync()
                                              .Result;

                responseMessage.ShouldBe("{\"Message\":\"The request is invalid because it is missing requestParameter', 'classParameter \"}");

            }
        }
    }
}
