// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Api.NetCore.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        private const string SingleParameterErrorMessage = "The request is invalid because it is missing a {0}.";
        private const string MultipleParametersErrorMessage = "The request is invalid because it is missing {0} ";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            var nullArguments = context.ActionDescriptor.Properties
                .Where(a => a.Value == null)
                .Select(a => a.Key)
                .ToArray();

            if (!nullArguments.Any())
            {
                return;
            }

            var errorMessage = nullArguments.Length == 1
                ? string.Format(
                    SingleParameterErrorMessage, (string) nullArguments[0] == "request"
                        ? "request body"
                        : nullArguments[0])
                : string.Format(MultipleParametersErrorMessage, string.Join("', '", nullArguments));

            context.Result = new BadRequestObjectResult(errorMessage);
        }
    }
}
