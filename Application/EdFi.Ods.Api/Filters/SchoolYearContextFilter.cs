// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Context;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Api.Filters
{
    public class SchoolYearContextFilter : IActionFilter
    {
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;

        public SchoolYearContextFilter(ISchoolYearContextProvider schoolYearContextProvider)
        {
            _schoolYearContextProvider = schoolYearContextProvider;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.RouteValues.TryGetValue("schoolYearFromRoute", out object year))
            {
                return;
            }

            // Convert the object value to a string and try to parse it
            if (!int.TryParse(year as string, out int schoolYear))
            {
                return;
            }

            // If we're still here, set the context value
            _schoolYearContextProvider.SetSchoolYear(schoolYear);
        }
    }
}