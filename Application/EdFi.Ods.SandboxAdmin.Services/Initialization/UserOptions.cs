// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Ods.Sandbox.Admin.Services.Initialization
{
    [NotMapped]
    public class UserOptions
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }

        public string[] NamespacePrefixes { get; set; }

        public Dictionary<string, SandboxOptions> Sandboxes { get; set; } = new Dictionary<string, SandboxOptions>();
    }
}
