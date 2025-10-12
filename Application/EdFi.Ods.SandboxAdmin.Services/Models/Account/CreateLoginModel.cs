// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.SandboxAdmin.Services.Models.Account
{
    public class CreateLoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
    }
}