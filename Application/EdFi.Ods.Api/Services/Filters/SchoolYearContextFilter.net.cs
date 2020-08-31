// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Services.Filters
{
    public class SchoolYearContextFilter : ActionFilterAttribute
    {
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;

        public SchoolYearContextFilter(ISchoolYearContextProvider schoolYearContextProvider)
        {
            _schoolYearContextProvider = schoolYearContextProvider;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            object year;

            if (!actionContext.RequestContext.RouteData.Values.TryGetValue("schoolYearFromRoute", out year))
            {
                return;
            }

            int schoolYear;

            // Convert the object value to a string and try to parse it
            if (!int.TryParse(year as string, out schoolYear))
            {
                return;
            }

            // If we're still here, set the context value
            _schoolYearContextProvider.SetSchoolYear(schoolYear);
        }
    }
}
#endif