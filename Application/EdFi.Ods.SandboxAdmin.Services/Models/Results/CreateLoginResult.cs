// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using EdFi.Ods.SandboxAdmin.Services.Models.Account;

namespace EdFi.Ods.SandboxAdmin.Services.Models.Results
{
    public class CreateLoginResult : AdminActionResult<CreateLoginResult, CreateLoginModel>
    {
        public static CreateLoginResult Fail
        {
            get
            {
                return new CreateLoginResult
                {
                    UserStatus = UserStatus.Failed,
                    Success = false
                };
            }
        }

        public UserStatus UserStatus { get; set; }

        public string UserStatusMessage
        {
            get { return UserStatus.ToString(); }
        }
    }
}