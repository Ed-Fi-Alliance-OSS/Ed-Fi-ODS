// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Web;
using EdFi.Ods.Admin.Contexts;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace EdFi.Ods.Admin.Security
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly UserManager<IdentityUser> _identityUserManager;
        private readonly RoleManager<IdentityRole> _identityRoleManager;
        private readonly ILog _log = LogManager.GetLogger(typeof(IdentityProvider));

        public IdentityProvider(AdminIdentityDbContext adminIdentityDbContext)
        {
            var identityUserStore = new UserStore<IdentityUser>(adminIdentityDbContext);
            _identityUserManager = new UserManager<IdentityUser>(identityUserStore);
            _identityUserManager.UserTokenProvider = new Microsoft.AspNet.Identity.EmailTokenProvider<IdentityUser, string>();

            _identityUserManager.UserValidator =
                new UserValidator<IdentityUser>(_identityUserManager) {AllowOnlyAlphanumericUserNames = false};

            var roleStore = new RoleStore<IdentityRole>(adminIdentityDbContext);
            _identityRoleManager = new RoleManager<IdentityRole>(roleStore);
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
            var identityUser = _identityUserManager.FindByName(userName);

            if (identityUser == null)
            {
                return false;
            }

            var result = _identityUserManager.PasswordHasher.VerifyHashedPassword(identityUser.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        public IdentityUser FindUser(string userName)
        {
            return _identityUserManager.FindByName(userName);
        }

        public IdentityUser FindUserByEmail(string userEmail)
        {
            return _identityUserManager.FindByEmail(userEmail);
        }

        public bool Login(string userEmail, string password)
        {
            var identityUser = _identityUserManager.FindByEmail(userEmail);
            var result = _identityUserManager.PasswordHasher.VerifyHashedPassword(identityUser.PasswordHash, password);

            if (result == PasswordVerificationResult.Success)
            {
                var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;

                var userIdentity = _identityUserManager.CreateIdentity(
                    identityUser, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() {IsPersistent = false}, userIdentity);
                return true;
            }

            return false;
        }

        public bool ResetUserPassword(string userName, string newPassword)
        {
            var identityUser = _identityUserManager.FindByName(userName);
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

        public void CreateRole(string role)
        {
            if (_identityRoleManager.FindByName(role) == null)
            {
                _log.Debug($"Adding role: {role} to asp net security.");
                _identityRoleManager.Create(new IdentityRole() {Name = role});
            }
        }

        public void AddToRoles(string userId, IEnumerable<string> roles)
        {
            _identityUserManager.AddToRoles(userId, roles.ToArray());
        }
    }
}
