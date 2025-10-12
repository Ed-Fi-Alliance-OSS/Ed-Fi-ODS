// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EdFi.Ods.SandboxAdmin.Services.Security
{
    public interface IIdentityProvider
    {
        Task<bool> VerifyUserExists(string userEmail);

        Task<bool> VerifyUserEmailConfirmed(string userEmail);

        Task<bool> VerifyUserPassword(string userName, string password);

        Task<IdentityUser> FindUser(string userName);

        Task<IdentityUser> FindUserByEmail(string userEmail);

        Task<bool> Login(string userEmail, string password, bool isPersistent);

        Task CreateRole(string role);

        Task<bool> ResetUserPassword(string userName, string newPassword);

        Task<bool> CreateUser(string userName, string email, string password, bool confirm = false);

        Task<string> GenerateEmailConfirmationToken(string email);

        Task<bool> ConfirmEmailWithToken(string email, string token);

        Task<string> GeneratePasswordResetToken(string email);

        Task AddToRoles(string userId, IEnumerable<string> roles);
    }
}
