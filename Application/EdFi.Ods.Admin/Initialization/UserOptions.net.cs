// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
namespace EdFi.Ods.Admin.Initialization
{
    public class UserOptions
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }

        public string[] NamespacePrefixes { get; set; }

        public SandboxOptions[] Sandboxes { get; set; }
    }
}
#endif