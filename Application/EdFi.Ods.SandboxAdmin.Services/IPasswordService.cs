// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.SandboxAdmin.Services.Models.Results;

namespace EdFi.Ods.SandboxAdmin.Services
{
    public interface IPasswordService
    {
        Task<PasswordResetResult> ValidateRequest(string userEmail, string secret);

        Task<ConfirmationResult> ConfirmAccount(string userEmail, string secret);

        Task<string> SetPasswordResetSecret(string userEmail);

        bool PasswordIsStrong(string password);
    }
}