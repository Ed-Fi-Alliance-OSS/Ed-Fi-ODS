// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Admin.DataAccess.Models;

namespace EdFi.Admin.DataAccess.Utils
{
    public interface IDefaultApplicationCreator
    {
        Application FindOrCreateUpdatedDefaultSandboxApplication(int vendorId, SandboxType sandboxType);

        void AddLeaIdsToApplication(IList<int> localEducationAgencyIds, int applicationId);
    }
}
