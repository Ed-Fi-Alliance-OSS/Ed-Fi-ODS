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
        private readonly IIdentityContextFactory _identityContextFactory;
        private readonly ILog _log = LogManager.GetLogger(typeof(IdentityProvider));

        public IdentityProvider(IIdentityContextFactory identityContextFactory)
        {
            _identityContextFactory = identityContextFactory;
        }

        public bool VerifyUserExists(string userEmail)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                var identityUser = identityUserManager.FindByEmail(userEmail);
                return identityUser != null;
            }
        }
                

        public bool VerifyUserEmailConfirmed(string userEmail)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                var identityUser = identityUserManager.FindByEmail(userEmail);
                return identityUser != null && identityUser.EmailConfirmed;
            }
        }

        public bool VerifyUserPassword(string userName, string password)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                var identityUser = identityUserManager.FindByName(userName);

                if (identityUser == null)
                {
                    return false;
                }

                var result = identityUserManager.PasswordHasher.VerifyHashedPassword(identityUser.PasswordHash, password);
                return result == PasswordVerificationResult.Success;
            }
        }

        public IdentityUser FindUser(string userName)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                return identityUserManager.FindByName(userName);
            }
        }

        public IdentityUser FindUserByEmail(string userEmail)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                return identityUserManager.FindByEmail(userEmail);
            }
        }

        public bool Login(string userEmail, string password)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                var identityUser = identityUserManager.FindByEmail(userEmail);

                if (identityUser == null)
                {
                    return false;
                }

                var result = identityUserManager.PasswordHasher.VerifyHashedPassword(identityUser.PasswordHash, password);

                if (result == PasswordVerificationResult.Success)
                {
                    var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;

                    var userIdentity = identityUserManager.CreateIdentity(
                        identityUser, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(new AuthenticationProperties() {IsPersistent = false}, userIdentity);
                    return true;
                }

                return false;
            }
        }

        public bool ResetUserPassword(string userName, string newPassword)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                var identityUser = identityUserManager.FindByName(userName);

                if (identityUser == null)
                {
                    return false;
                }

                string token = identityUserManager.GeneratePasswordResetToken(identityUser.Id);
                var result = identityUserManager.ResetPassword(identityUser.Id, token, newPassword);

                if (!result.Succeeded)
                {
                    _log.Error($"Failed resetting password for: {userName}. {string.Join(",", result.Errors)}");
                }

                return result.Succeeded;
            }
        }

        public bool CreateUser(string userName, string email, string password, bool confirm = false)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                IdentityResult result = identityUserManager.Create(
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
        }

        public string GenerateEmailConfirmationToken(string email)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                var identityUser = identityUserManager.FindByEmail(email);
                return identityUserManager.GenerateEmailConfirmationToken(identityUser.Id);
            }
        }

        public bool ConfirmEmailWithToken(string email, string token)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
               
                var identityUser = identityUserManager.FindByEmail(email);

                if (identityUser != null)
                {               
                   IdentityResult result = identityUserManager.ConfirmEmail(identityUser.Id, token);

                    if (!result.Succeeded)
                    {
                        _log.Error($"Failed confirming token user: {identityUser.Email}. {string.Join(",", result.Errors)}");
                    }

                    return result.Succeeded;
                }

                return false;
            }
        }

        public string GeneratePasswordResetToken(string email)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                var identityUser = identityUserManager.FindByEmail(email);
                return identityUserManager.GeneratePasswordResetToken(identityUser.Id);
            }
        }

        public void CreateRole(string role)
        {
            using (var identityRoleManager = GetIdentityRoleManager())
            {
                if (identityRoleManager.FindByName(role) == null)
                {
                    _log.Debug($"Adding role: {role} to asp net security.");
                    identityRoleManager.Create(new IdentityRole() {Name = role});
                }
            }
        }

        public void AddToRoles(string userId, IEnumerable<string> roles)
        {
            using (var identityUserManager = GetIdentityUserManager())
            {
                identityUserManager.AddToRoles(userId, roles.ToArray());
            }
        }

        private UserManager<IdentityUser> GetIdentityUserManager()
        {
            IdentityContext context = _identityContextFactory.CreateContext();
            var identityUserStore = new UserStore<IdentityUser>(context);
            var identityUserManager = new UserManager<IdentityUser>(identityUserStore);
            identityUserManager.UserTokenProvider = new Microsoft.AspNet.Identity.EmailTokenProvider<IdentityUser, string>();

            identityUserManager.UserValidator =
                new UserValidator<IdentityUser>(identityUserManager) {AllowOnlyAlphanumericUserNames = false};

            return identityUserManager;
        }

        private RoleManager<IdentityRole> GetIdentityRoleManager()
        {
            IdentityContext context = _identityContextFactory.CreateContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var identityRoleManager = new RoleManager<IdentityRole>(roleStore);
            return identityRoleManager;
        }
    }
}
