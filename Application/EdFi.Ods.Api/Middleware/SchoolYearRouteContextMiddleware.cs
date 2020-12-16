// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware
{
    public class SchoolYearRouteContextMiddleware : IMiddleware
    {
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;

        public SchoolYearRouteContextMiddleware(ISchoolYearContextProvider schoolYearContextProvider)
        {
            _schoolYearContextProvider = schoolYearContextProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.RouteValues.TryGetValue("schoolYearFromRoute", out object year))
            {
                if (int.TryParse(year.ToString(), out int schoolYear))
                {
                    _schoolYearContextProvider.SetSchoolYear(schoolYear);
                }
            }

            await next(context);
        }
    }
}
