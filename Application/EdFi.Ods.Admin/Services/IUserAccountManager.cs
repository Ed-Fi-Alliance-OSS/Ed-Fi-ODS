// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Admin.Models;
using EdFi.Ods.Admin.Models.Results;
using System.Threading.Tasks;

namespace EdFi.Ods.Admin.Services
{
    public interface IUserAccountManager
    {
        CreateLoginResult Create(CreateLoginModel model);

        PasswordResetResult ResetPassword(PasswordResetModel model);

        ChangePasswordResult ChangePassword(ChangePasswordModel model);

        ForgotPasswordResetResult ForgotPassword(ForgotPasswordModel model);

        Task<ForgotPasswordResetResult> ResendConfirmationAsync(ForgotPasswordModel model);
    }
}
