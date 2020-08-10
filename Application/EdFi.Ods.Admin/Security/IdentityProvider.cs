// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdFi.Ods.Admin.Contexts;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.DataProtection;

namespace EdFi.Ods.Admin.Security
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly AdminIdentityDbContext _adminIdentityDbContext;
        private readonly UserStore<IdentityUser> _identityUserStore;
        private readonly UserManager<IdentityUser> _identityUserManager;
        private readonly ILog _log = LogManager.GetLogger(typeof(IdentityProvider));

        public IdentityProvider(AdminIdentityDbContext adminIdentityDbContext)
        {
            _adminIdentityDbContext = adminIdentityDbContext;
            _identityUserStore = new UserStore<IdentityUser>(_adminIdentityDbContext);
            _identityUserManager = new UserManager<IdentityUser>(_identityUserStore);
            _identityUserManager.UserTokenProvider = new Microsoft.AspNet.Identity.EmailTokenProvider<IdentityUser, string>();

            _identityUserManager.UserValidator =
                new UserValidator<IdentityUser>(_identityUserManager) {AllowOnlyAlphanumericUserNames = false};
        }

        public bool VerifyUserExists(string userEmail)
        {
            var identityUser = _identityUserManager.FindByEmail(userEmail);
            return identityUser != null;
        }

        public bool VerifyUserEmailConfirmed(string userEmail)
        {
            var identityUser = _identityUserManager.FindByEmail(userEmail);
            return identityUser != null && identityUser.EmailConfirmed;
        }

        public bool VerifyUserPassword(string userName, string password)
        {
            var identityUser = _identityUserManager.FindByEmail(userName);
            var result = _identityUserManager.PasswordHasher.VerifyHashedPassword(identityUser.PasswordHash, password);

            return result == PasswordVerificationResult.Success;

        }

        public bool Login(string userEmail, string password)
        {
            var identityUser = _identityUserManager.FindByEmail(userEmail);
            var result = _identityUserManager.PasswordHasher.VerifyHashedPassword(identityUser.PasswordHash, password);

            return result == PasswordVerificationResult.Success;
        }

        public bool ResetUserPassword(string userName, string newPassword)
        {
            var identityUser = _identityUserManager.FindByEmail(userName);
            string token = _identityUserManager.GeneratePasswordResetToken(identityUser.Id);
            var result = _identityUserManager.ResetPassword(identityUser.Id, token, newPassword);

            if (!result.Succeeded)
            {
                _log.Error($"Failed resetting password for: {userName}. {string.Join(",", result.Errors)}");

            }

            return result.Succeeded;
        }

        public bool CreateUser(string userName, string email, string password, bool confirm = false)
        {
            IdentityResult result = _identityUserManager.Create(
                new IdentityUser()
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = confirm
                }, password);

            if (!result.Succeeded)
            {
                _log.Error($"Failed adding user: {userName} to asp net security. {string.Join(",", result.Errors)}");
            }

            return result.Succeeded;
        }

        public string GenerateEmailConfirmationToken(string email)
        {
            var identityUser = _identityUserManager.FindByEmail(email);
            return _identityUserManager.GenerateEmailConfirmationToken(identityUser.Id);
        }

        public bool ConfirmEmailWithToken(string email, string token)
        {
            IdentityResult result = null;
            var identityUser = _identityUserManager.FindByEmail(email);

            if (identityUser != null)
            {
                result = _identityUserManager.ConfirmEmail(identityUser.Id, token);

                if (!result.Succeeded)
                {
                    _log.Error($"Failed confirming token user: {identityUser.Email}. {string.Join(",", result.Errors)}");
                }

                return result.Succeeded;
            }
            return false;
        }

        public string GeneratePasswordResetToken(string email)
        {
            var identityUser = _identityUserManager.FindByEmail(email);
            return _identityUserManager.GeneratePasswordResetToken(identityUser.Id);
        }
    }
}
