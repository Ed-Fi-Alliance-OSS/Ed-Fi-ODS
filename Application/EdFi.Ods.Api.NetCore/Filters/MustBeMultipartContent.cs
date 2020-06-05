// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace EdFi.Ods.Api.NetCore.Filters
{
    public class MustBeMultipartContent : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!MediaTypeHeaderValue.TryParse(context.HttpContext.Request.ContentType, out MediaTypeHeaderValue headerValue))
            {
                context.Result = new BadRequestObjectResult("The request body must be a mime multipart object");
            }
        }
    }
}
