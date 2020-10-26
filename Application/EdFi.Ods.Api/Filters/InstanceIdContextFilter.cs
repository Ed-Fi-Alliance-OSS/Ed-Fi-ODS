// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace EdFi.Ods.Api.Filters
{
    public class InstanceIdContextFilter : IActionFilter
    {
        private const string Pattern = @"^[A-Za-z0-9-]+$";

        private readonly IInstanceIdContextProvider _instanceIdContextProvider;

        public InstanceIdContextFilter(IInstanceIdContextProvider instanceIdContextProvider)
        {
            _instanceIdContextProvider = instanceIdContextProvider;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.RouteValues.TryGetValue("instanceIdFromRoute", out object instance))
            {
                return;
            }

            // Convert the object value to a string and see if it is empty
            string instanceId = instance as string;
            if (string.IsNullOrEmpty(instanceId))
            {
                return;
            }

            //check that the character's are allowed
            Match match = Regex.Match(instanceId, Pattern);
            if (!match.Success)
            {
                return;
            }

            // If we're still here, set the context value
            _instanceIdContextProvider.SetInstanceId(instanceId);
        }
    }
}