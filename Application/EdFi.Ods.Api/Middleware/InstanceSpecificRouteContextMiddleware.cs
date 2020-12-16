// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware
{
    public class InstanceSpecificRouteContextMiddleware : IMiddleware
    {
        private const string Pattern = @"^[A-Za-z0-9-]+$";
        private readonly IInstanceIdContextProvider _instanceIdContextProvider;

        public InstanceSpecificRouteContextMiddleware(IInstanceIdContextProvider instanceIdContextProvider)
        {
            _instanceIdContextProvider = instanceIdContextProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.RouteValues.TryGetValue("instanceIdFromRoute", out object instance))
            {
                // Convert the object value to a string and see if it is empty
                var instanceId = instance as string;

                if (!string.IsNullOrEmpty(instanceId))
                {
                    //check that the character's are allowed
                    Match match = Regex.Match(instanceId, Pattern);

                    if (match.Success)
                    {
                        // If we're still here, set the context value
                        _instanceIdContextProvider.SetInstanceId(instanceId);
                    }
                }
            }

            await next(context);
        }
    }
}
