// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Identity;

namespace EdFi.Ods.SandboxAdmin.Services.Security
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILog _log = LogManager.GetLogger(typeof(IdentityProvider));

        public IdentityProvider(SignInManager<IdentityUser> signInManager
            , UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> VerifyUserExists(string userEmail)
        {
            var identityUser = await _userManager.FindByEmailAsync(userEmail);
            return identityUser != null;
        }

        public async Task<bool> VerifyUserEmailConfirmed(string userEmail)
        {
            var identityUser = await _userManager.FindByEmailAsync(userEmail);
            return identityUser != null && identityUser.EmailConfirmed;
        }

        public async Task<bool> VerifyUserPassword(string userName, string password)
        {
            var identityUser = await _userManager.FindByNameAsync(userName);

            if (identityUser == null)
            {
                return false;
            }

            var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<IdentityUser> FindUser(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityUser> FindUserByEmail(string userEmail)
        {
            return await _userManager.FindByEmailAsync(userEmail);
        }

        public async Task<bool> Login(string userEmail, string password, bool isPersistent = false)
        {
            var identityUser = await _userManager.FindByEmailAsync(userEmail);

            if (identityUser == null)
            {
                return false;
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(
                identityUser.UserName, password, isPersistent, false);

            return signInResult.Succeeded;
        }

        public async Task<bool> ResetUserPassword(string userName, string newPassword)
        {
            var identityUser = await _userManager.FindByNameAsync(userName);

            if (identityUser == null)
            {
                return false;
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(identityUser);
            var result = await _userManager.ResetPasswordAsync(identityUser, token, newPassword);

            if (!result.Succeeded)
            {
                _log.Error($"Failed resetting password for: {userName}. {string.Join(",", result.Errors)}");
            }

            return result.Succeeded;
        }

        public async Task<bool> CreateUser(string userName, string email, string password, bool confirm = false)
        {
            IdentityResult result = await _userManager.CreateAsync(
                    new IdentityUser
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

        public async Task<string> GenerateEmailConfirmationToken(string email)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);
            return await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
        }

        public async Task<bool> ConfirmEmailWithToken(string email, string token)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);

            if (identityUser != null)
            {
                var result = await _userManager.ConfirmEmailAsync(identityUser, token);

                if (!result.Succeeded)
                {
                    _log.Error($"Failed confirming token user: {identityUser.Email}. {string.Join(",", result.Errors)}");
                }

                return result.Succeeded;
            }

            return false;
        }

        public async Task<string> GeneratePasswordResetToken(string email)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);
            return await _userManager.GeneratePasswordResetTokenAsync(identityUser);
        }

        public async Task CreateRole(string role)
        {
            if (await _roleManager.FindByNameAsync(role) == null)
            {
                _log.Debug($"Adding role: {role} to asp net security.");
                await _roleManager.CreateAsync(new IdentityRole { Name = role });
            }
        }

        public async Task AddToRoles(string userId, IEnumerable<string> roles)
        {
            var identityUser = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRolesAsync(identityUser, roles.ToArray());
        }

    }
}