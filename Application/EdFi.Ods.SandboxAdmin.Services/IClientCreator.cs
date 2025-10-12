// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Sandbox.Admin.Services.Initialization;

namespace EdFi.Ods.SandboxAdmin.Services
{
    public interface IClientCreator
    {
        ApiClient CreateNewSandboxClient(string sandboxName, SandboxOptions sandboxOptions, User user, int? applicationId = null, bool addRestoredEdOrgIdsToApplication = true);

        ApiClient ResetSandboxClient(string sandboxName, SandboxOptions sandboxOptions, User user, int? applicationId = null, bool addRestoredEdOrgIdsToApplication = true);
    }
}
