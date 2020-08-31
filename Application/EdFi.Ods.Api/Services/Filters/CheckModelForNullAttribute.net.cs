// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EdFi.Ods.Api.Services.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        private const string SingleParameterErrorMessage = "The request is invalid because it is missing a {0}.";
        private const string MultipleParametersErrorMessage = "The request is invalid because it is missing {0} ";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                return;
            }


            var nullArguments = actionContext.ActionArguments.Where(a => a.Value == null)
                                             .Select(a => a.Key)
                                             .ToArray();

            if (!nullArguments.Any())
            {
                return;
            }

            var errorMessage = nullArguments.Length == 1
                ? string.Format(SingleParameterErrorMessage, nullArguments[0] == "request" ? "request body" : nullArguments[0])
                : string.Format(MultipleParametersErrorMessage, string.Join("', '", nullArguments));

            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
        }
    }
}
#endif