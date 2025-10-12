// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.SandboxAdmin.Services.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.SandboxAdmin.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ActionResult Index()
        {
            var user = _httpContextAccessor.HttpContext.User;

            var isLoggedIn = user.Identity.IsAuthenticated;
            var shouldLogin = !isLoggedIn;
            bool isAdmin = false;

            try
            {
                isAdmin = isLoggedIn && user.IsInRole("Administrator");
            }
            catch (InvalidOperationException)
            {
                // Ignore InvalidOperationException if the user account was deleted
                // Could potentially catch this by also checking WebSecurity.UserExists(user.Identity.Name)
                // as part of IsLoggedIn, but this scenario is only likely to happen (and throw) in a test environment
                // Also set that the user should login, to render correctly and give the not found error on login
                shouldLogin = true;
            }

            var model = new IndexViewModel
            {
                UserShouldLogin = shouldLogin,
                UserIsAdmin = isAdmin
            };

            return View(model);
        }
    }
}
