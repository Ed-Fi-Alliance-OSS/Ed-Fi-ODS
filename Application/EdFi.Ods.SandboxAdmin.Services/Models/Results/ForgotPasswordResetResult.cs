// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using EdFi.Ods.SandboxAdmin.Services.Models.Account;
namespace EdFi.Ods.SandboxAdmin.Services.Models.Results
{
    public class ForgotPasswordResetResult : AdminActionResult<ForgotPasswordResetResult, ForgotPasswordModel>
    {
        public static ForgotPasswordResetResult Successful = new ForgotPasswordResetResult
        {
            Success = true
        };

        public static ForgotPasswordResetResult BadEmail(string email)
        {
            var message = string.Format("Could not locate an account with email address '{0}'.", email);

            return new ForgotPasswordResetResult
            {
                Success = false,
                Message = message
            };
        }
    }
}