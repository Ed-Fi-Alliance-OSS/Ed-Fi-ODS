// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Sandbox.Admin.Extensions;
using EdFi.Ods.SandboxAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.SandboxAdmin.Filters
{
    public class SetCurrentUserInfoAttribute : ActionFilterAttribute
    {
        private readonly Func<ISecurityService> _securityServiceLocator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //NOTE:  This uses a Func to supply the security service rather than normal constructor injection.  This allows
        //       us to create the filter during App_Start, but wait until the request cycle to resolve the dependencies.
        //       This allows us to use LifecyclePerWebRequest with the Castle container.  Castle can't handle resolving
        //       PerWebRequest dependencies during App_Start.
        public SetCurrentUserInfoAttribute(Func<ISecurityService> securityServiceLocator
            , IHttpContextAccessor httpContextAccessor)
        {
            _securityServiceLocator = securityServiceLocator;
            _httpContextAccessor = httpContextAccessor;
        }

        private ISecurityService SecurityService
        {
            get { return _securityServiceLocator(); }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                return;
            }

            string currentUserName = _httpContextAccessor.HttpContext.User?.Identity?.Name;
            var userLookup = SecurityService.GetCurrentUser(currentUserName);
            ((Controller)(filterContext.Controller)).ViewBag.UserLookup = userLookup;
        }
    }
}