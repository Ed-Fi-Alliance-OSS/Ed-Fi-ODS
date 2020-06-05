// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess;
using EdFi.Ods.Admin.Models;

namespace EdFi.Ods.Admin.Services
{
    public interface IDatabaseTemplateLeaQuery
    {
        int[] GetLocalEducationAgencyIds(SandboxType sandboxType);
    }
}
