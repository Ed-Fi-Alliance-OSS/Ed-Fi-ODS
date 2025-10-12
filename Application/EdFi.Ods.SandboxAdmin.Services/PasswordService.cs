// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.SandboxAdmin.Services.Models.Results;
using EdFi.Ods.SandboxAdmin.Services.Security;
using EdFi.Ods.SandboxAdmin.Services.Extensions;

namespace EdFi.Ods.SandboxAdmin.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IIdentityProvider _identityProvider;

        public PasswordService(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        public async Task<ConfirmationResult> ConfirmAccount(string userEmail, string secret)
        {

            if (await _identityProvider.VerifyUserEmailConfirmed(userEmail))
            {
                return ConfirmationResult.UserAlreadyConfirmed;
            }

            var success = await _identityProvider.ConfirmEmailWithToken(userEmail, secret);

            if (success)
            {
                var passwordResetToken = await _identityProvider.GeneratePasswordResetToken(userEmail);
                var result = ConfirmationResult.Successful(userEmail, passwordResetToken);
                return result;
            }

            return ConfirmationResult.Failure;
        }


        public async Task<PasswordResetResult> ValidateRequest(string userEmail, string secret)
        {
            if (!await _identityProvider.VerifyUserExists(userEmail))
            {
                return PasswordResetResult.BadUsername;
            }

            if (!await _identityProvider.VerifyUserEmailConfirmed(userEmail))
            {
                if (!await _identityProvider.VerifyUserPassword(userEmail, secret))
                {
                    return PasswordResetResult.Expired(userEmail);
                }
            }

            return PasswordResetResult.Successful;
        }

        public async Task<string> SetPasswordResetSecret(string userEmail)
        {
            if (!await _identityProvider.VerifyUserEmailConfirmed(userEmail))
            {
                throw new InvalidOperationException(string.Format("User '{0}' has not been confirmed.  Cannot reset password", userEmail));
            }

            var resetToken = await _identityProvider.GeneratePasswordResetToken(userEmail);

            return resetToken;
        }

        public bool PasswordIsStrong(string password)
        {
            return password.IsStrongPassword();
        }
    }
}