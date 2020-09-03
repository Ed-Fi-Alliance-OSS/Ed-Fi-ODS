// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Admin.Models.Results;

namespace EdFi.Ods.Admin.Services
{
    public interface IPasswordService
    {
        PasswordResetResult ValidateRequest(string userEmail, string secret);

        ConfirmationResult ConfirmAccount(string userEmail, string secret);

        string SetPasswordResetSecret(string userEmail);

        bool PasswordIsStrong(string password);
    }
}
#endif