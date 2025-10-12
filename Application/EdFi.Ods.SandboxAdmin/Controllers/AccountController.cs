// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Ods.SandboxAdmin.Services.Extensions;
using EdFi.Ods.SandboxAdmin.Services.Models;
using EdFi.Ods.SandboxAdmin.Services.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EdFi.Ods.SandboxAdmin.Services;
using EdFi.Ods.SandboxAdmin.Services.Models.Results;
using EdFi.Ods.SandboxAdmin.Services.Models.Account;

namespace EdFi.Ods.SandboxAdmin.Controllers
{
    public class AccountController : Controller
    {
        private const string PasswordResetCompleteMessageKey = "PasswordResetCompleteMessage";
        private readonly IClientAppRepo _clientAppRepo;
        private readonly IPasswordService _passwordService;
        private readonly IUserAccountManager _userAccountManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(
            IUserAccountManager userAccountManager,
            IPasswordService passwordService,
            IClientAppRepo clientAppRepo,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userAccountManager = userAccountManager;
            _passwordService = passwordService;
            _clientAppRepo = clientAppRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        public ActionResult SessionInfo()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = SecurityRoles.Administrator)]
        public async Task<ActionResult> Create(CreateLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAccountManager.Create(model);

                if (result.UserStatus == UserStatus.Created)
                {
                    result.RedirectRoute = Url.Action("ActivationSent");
                }

                return Json(result);
            }

            // Failed Model Validation
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(BuildJsonResponseFromModelState());
        }

        [HttpGet]
        [ActionName("Create")]
        [Authorize(Roles = SecurityRoles.Administrator)]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ActivationSent()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResetSent()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword(string email, string marker)
        {
            return View(
                new PasswordResetViewModel
                {
                    Marker = marker,
                    Email = email
                });
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(PasswordResetModel model)
        {
            var result = await _userAccountManager.ResetPassword(model);

            if (result.Success)
            {
                return RedirectToAction("PasswordResetSuccessful");
            }

            TempData.SetErrorMessage(result.Message);

            if (PasswordResetStatus.BadPassword == result.ResetStatus)
            {
                return View(
                    new PasswordResetViewModel
                    {
                        Marker = model.Marker,
                        Email = model.Email
                    });
            }

            if (PasswordResetStatus.RequestExpired == result.ResetStatus)
            {
                return RedirectToAction("ForgotPassword");
            }

            //Must be bad username.
            return RedirectToAction("ForgotPassword", "Account");
        }

        [HttpGet]
        public async Task<ActionResult> ActivateAccount(string email, string marker)
        {
            var validation = await _passwordService.ConfirmAccount(email, marker);

            if (validation.Success)
            {
                return View(
                    new PasswordResetViewModel
                    {
                        Marker = marker,
                        Email = validation.UserName
                    });
            }

            TempData.SetErrorMessage(validation.Message);
            return RedirectToAction("ForgotPassword");
        }

        [HttpPost]
        public async Task<ActionResult> ActivateAccount(PasswordResetModel model)
        {
            var result = await _userAccountManager.ResetPassword(model);

            if (result.Success)
            {
                TempData[PasswordResetCompleteMessageKey] = "Account Activated";
                return RedirectToAction("PasswordResetSuccessful");
            }

            TempData.SetErrorMessage(result.Message);

            if (PasswordResetStatus.BadPassword == result.ResetStatus)
            {
                return View(
                    new PasswordResetViewModel
                    {
                        Marker = model.Marker,
                        Email = model.Email
                    });
            }

            if (PasswordResetStatus.RequestExpired == result.ResetStatus)
            {
                return RedirectToAction("ResendAccountActivation");
            }

            //Must be bad username.
            return RedirectToAction("ResendAccountActivation");
        }

        [HttpPost]
        public ActionResult ResendPasswordResetEmail(string userName)
        {
            return RedirectToAction("ResetSent");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var result = await _userAccountManager.ForgotPassword(model);

            if (result.Success)
            {
                return RedirectToAction("ResetSent");
            }

            if (result.HasMessage)
            {
                TempData.SetErrorMessage(result.Message);
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = SecurityRoles.Administrator)]
        public ActionResult ResendAccountActivation()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = SecurityRoles.Administrator)]
        public async Task<ActionResult> ResendAccountActivation(ForgotPasswordModel model)
        {
            var result = await _userAccountManager.ResendConfirmationAsync(model);

            if (result.Success)
            {
                return RedirectToAction("ActivationSent");
            }

            if (result.HasMessage)
            {
                TempData.SetErrorMessage(result.Message);
            }

            return View();
        }

        [HttpGet]
        public ActionResult PasswordResetSuccessful()
        {
            var message = TempData[PasswordResetCompleteMessageKey] ?? "Password Reset Complete";

            return View(
                new PasswordResetCompletViewModel
                {
                    Message = (string)message
                });
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            model.UserName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var result = await _userAccountManager.ChangePassword(model);

            if (result.Success)
            {
                return RedirectToAction("ChangePasswordSuccess");
            }

            TempData.SetErrorMessage(result.Message);
            return RedirectToAction("ChangePassword");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userAccountManager.Login(model.EmailAddress, model.Password, model.RememberMe))
                {
                    var user = _clientAppRepo.GetUser(model.EmailAddress);

                    return Json(
                        new
                        {
                            success = true,
                            name = user.FullName,
                            authenticated = true
                        });
                }

                //Failed Login
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                return Json(
                    new
                    {
                        success = false,
                        message = "The email address or password provided is incorrect."
                    });
            }

            // Failed Model Validation
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(BuildJsonResponseFromModelState());
        }

        [HttpGet]
        [ActionName("Login")]
        public ActionResult ForcedLogin()
        {
            return View();
        }

        private object BuildJsonResponseFromModelState()
        {
            var message = GetErrorMessageFromModelState();
            var failingFields = GetFailedFieldsFromModelState();

            var data = new
            {
                success = false,
                message,
                failingFields
            };

            return data;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return Json(
                new
                {
                    success = true,
                    authenticated = false
                });
        }

        private string[] GetFailedFieldsFromModelState()
        {
            return ModelState.Where(x => x.Value.Errors.Count > 0)
                             .Select(x => x.Key)
                             .ToArray();
        }

        private string GetErrorMessageFromModelState()
        {
            var errorMessages = ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
            return string.Join("\n", errorMessages);
        }
    }
}