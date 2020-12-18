// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware
{
    public static class HttpContextHelper
    {
        public static ActionExecutingContext GetActionContext()
        {
            var actionContext = A.Fake<ActionContext>();
            var filterMetadata = A.Fake<IList<IFilterMetadata>>();
            var actionArguments = A.Fake<IDictionary<string, object>>();
            var controller = A.Fake<object>();

            actionContext.HttpContext = A.Fake<HttpContext>();
            actionContext.RouteData = A.Fake<RouteData>();

            actionContext.ActionDescriptor = A.Fake<ActionDescriptor>();
            var routeValues = new RouteValueDictionary();

            var context = new ActionExecutingContext(actionContext, filterMetadata, actionArguments, controller);
            context.HttpContext.Request.RouteValues = routeValues;

            return context;
        }
    }
}
