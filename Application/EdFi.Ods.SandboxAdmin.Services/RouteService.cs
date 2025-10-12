// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.SandboxAdmin.Services
{
    public class RouteService : IRouteService
    {
        private readonly IUrlHelper _urlHelper;

        public RouteService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public string GetRouteForPasswordReset(string email, string marker)
        {
            return _urlHelper.Action(
                "ResetPassword",
                "Account",
                new
                {
                    Email = email,
                    Marker = marker
                },
                _urlHelper.ActionContext.HttpContext.Request.Scheme
            );
        }

        public string GetRouteForActivation(string email, string marker)
        {
            return _urlHelper.Action(
                "ActivateAccount",
                "Account",
                new
                {
                    Email = email,
                    Marker = marker
                },
                _urlHelper.ActionContext.HttpContext.Request.Scheme
            );
        }
    }
}
