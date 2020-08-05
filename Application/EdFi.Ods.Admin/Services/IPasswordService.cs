// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Admin.Models.Results;

namespace EdFi.Ods.Admin.Services
{
    public interface IPasswordService
    {
        PasswordResetResult ValidateRequest(string userName, string secret);

        Task<ConfirmationResult> ConfirmAccountAsync(string secret); 

        string SetPasswordResetSecret(string userName);

        bool PasswordIsStrong(string password);

        User GetUserForPasswordResetToken(string secret);
    }
}
