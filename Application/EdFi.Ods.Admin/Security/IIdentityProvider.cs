// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Admin.Security
{
    public interface IIdentityProvider
    {
        bool VerifyUserExists(string userEmail);

        bool VerifyUserEmailConfirmed(string userEmail);

        bool VerifyUserPassword(string userName, string password);

        bool Login(string userEmail, string password);

        bool ResetUserPassword(string userName, string newPassword);

        bool CreateUser(string userName, string email, string password, bool confirm = false);

        string GenerateEmailConfirmationToken(string email);

        bool ConfirmEmailWithToken(string email, string token);

        string GeneratePasswordResetToken(string email);
    }
}