// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess;

namespace EdFi.Ods.SandboxAdmin.Services.Models.Client
{
    public class SandboxClientCreateModel
    {
        public string Name { get; set; }

        public SandboxType SandboxType { get; set; }

        public int ApplicationId { get; set; }

    }
}