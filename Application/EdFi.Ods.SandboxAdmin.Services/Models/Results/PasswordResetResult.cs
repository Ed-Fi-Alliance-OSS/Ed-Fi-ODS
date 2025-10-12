// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using EdFi.Ods.SandboxAdmin.Services.Models.Account;

namespace EdFi.Ods.SandboxAdmin.Services.Models.Results
{
    public enum PasswordResetStatus
    {
        Success,
        RequestExpired,
        BadUsername,
        BadPassword
    }

    public class PasswordResetResult : AdminActionResult<PasswordResetResult, PasswordResetModel>
    {
        public static PasswordResetResult Successful = new PasswordResetResult
        {
            Success = true
        };
        public static PasswordResetResult BadUsername = new PasswordResetResult
        {
            Success = false,
            ResetStatus = PasswordResetStatus.BadUsername,
            Message =
                                                                "We are having some trouble looking up your account.  Please enter your email address to send a verification link."
        };
        public static PasswordResetResult BadPassword = new PasswordResetResult
        {
            Success = false,
            ResetStatus = PasswordResetStatus.BadPassword,
            Message = "The password you entered is invalid."
        }
                                                       .AddFailingField(x => x.Password)
                                                       .AddFailingField(x => x.ConfirmPassword);

        public PasswordResetStatus ResetStatus { get; private set; }

        public string AccountEmail { get; private set; }

        public static PasswordResetResult Expired(string email)
        {
            return new PasswordResetResult
            {
                AccountEmail = email,
                Success = false,
                ResetStatus = PasswordResetStatus.RequestExpired,
                Message =
                           "It looks like your password request has expired.  Email verification must happen within 48 hours. Use the box below to try again."
            };
        }
    }
}