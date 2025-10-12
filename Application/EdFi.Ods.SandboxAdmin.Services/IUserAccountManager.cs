// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.SandboxAdmin.Services.Models.Account;
using EdFi.Ods.SandboxAdmin.Services.Models.Results;

namespace EdFi.Ods.SandboxAdmin.Services
{
    public interface IUserAccountManager
    {
        Task<CreateLoginResult> Create(CreateLoginModel model);

        Task<bool> Login(string userName, string password, bool isPersistent);

        Task<PasswordResetResult> ResetPassword(PasswordResetModel model);

        Task<ChangePasswordResult> ChangePassword(ChangePasswordModel model);

        Task<ForgotPasswordResetResult> ForgotPassword(ForgotPasswordModel model);

        Task<ForgotPasswordResetResult> ResendConfirmationAsync(ForgotPasswordModel model);
    }
}