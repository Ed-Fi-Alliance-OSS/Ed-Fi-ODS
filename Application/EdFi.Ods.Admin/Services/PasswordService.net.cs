// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using EdFi.Ods.Admin.Extensions;
using EdFi.Ods.Admin.Models.Results;
using EdFi.Ods.Admin.Security;
using EdFi.Ods.Sandbox.Repositories;

namespace EdFi.Ods.Admin.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IIdentityProvider _identityProvider;

        public PasswordService(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        public ConfirmationResult ConfirmAccount(string userEmail, string secret)
        {

            if (_identityProvider.VerifyUserEmailConfirmed(userEmail))
            {
                return ConfirmationResult.UserAlreadyConfirmed;
            }

            var success = _identityProvider.ConfirmEmailWithToken(userEmail, secret);

            if (success)
            {
                var passwordResetToken = _identityProvider.GeneratePasswordResetToken(userEmail);
                var result = ConfirmationResult.Successful(userEmail, passwordResetToken);
                return result;
            }

            return ConfirmationResult.Failure;
        }


        public PasswordResetResult ValidateRequest(string userEmail, string secret)
        {
            if (!_identityProvider.VerifyUserExists(userEmail))
            {
                return PasswordResetResult.BadUsername;
            }

            if (!_identityProvider.VerifyUserEmailConfirmed(userEmail))
            {
                if (!_identityProvider.VerifyUserPassword(userEmail, secret))
                {
                    return PasswordResetResult.Expired(userEmail);
                }
            }

            return PasswordResetResult.Successful;
        }

        public string SetPasswordResetSecret(string userEmail)
        {
            if (!_identityProvider.VerifyUserEmailConfirmed(userEmail))
            {
                throw new InvalidOperationException(string.Format("User '{0}' has not been confirmed.  Cannot reset password", userEmail));
            }

            var resetToken = _identityProvider.GeneratePasswordResetToken(userEmail);

            return resetToken;
        }

        public bool PasswordIsStrong(string password)
        {
            return password.IsStrongPassword();
        }
    }
}
#endif