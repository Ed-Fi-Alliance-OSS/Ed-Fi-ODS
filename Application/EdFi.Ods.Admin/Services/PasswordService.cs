// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Admin.Extensions;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Admin.Models.Results;
using EdFi.Ods.Sandbox.Repositories;
using WebMatrix.WebData;

namespace EdFi.Ods.Admin.Services
{
    public class PasswordService : IPasswordService
    {
        private const int PasswordResetTimeoutMinutes = 2 * 24 * 60;

        private readonly IClientAppRepo _clientAppRepository;

        public PasswordService(IClientAppRepo clientAppRepository)
        {
            _clientAppRepository = clientAppRepository;
        }

        public async Task<ConfirmationResult> ConfirmAccountAsync(string secret)
        {
            var userName = await _clientAppRepository.GetUserNameFromTokenAsync(secret);

            if (userName == null)
            {
                return ConfirmationResult.Failure;
            }

            if (WebSecurity.IsConfirmed(userName))
            {
                return ConfirmationResult.UserAlreadyConfirmed;
            }

            var success = WebSecurity.ConfirmAccount(secret);

            if (success)
            {
                var passwordResetToken = WebSecurity.GeneratePasswordResetToken(userName);
                var result = ConfirmationResult.Successful(userName, passwordResetToken);
                return result;
            }

            return ConfirmationResult.Failure;
        }

        public User GetUserForPasswordResetToken(string secret)
        {
            var userId = WebSecurity.GetUserIdFromPasswordResetToken(secret);
            return _clientAppRepository.GetUser(userId);
        }

        public PasswordResetResult ValidateRequest(string userName, string secret)
        {
            if (!WebSecurity.UserExists(userName))
            {
                return PasswordResetResult.BadUsername;
            }

            if (!WebSecurity.IsConfirmed(userName))
            {
                if (!WebSecurity.ConfirmAccount(userName, secret))
                {
                    return PasswordResetResult.Expired(userName);
                }
            }

            return PasswordResetResult.Successful;
        }

        public string SetPasswordResetSecret(string userName)
        {
            if (!WebSecurity.IsConfirmed(userName))
            {
                throw new InvalidOperationException(string.Format("User '{0}' has not been confirmed.  Cannot reset password", userName));
            }

            var resetToken = WebSecurity.GeneratePasswordResetToken(userName, PasswordResetTimeoutMinutes);

            return resetToken;
        }

        public bool PasswordIsStrong(string password)
        {
            return password.IsStrongPassword();
        }
    }
}
