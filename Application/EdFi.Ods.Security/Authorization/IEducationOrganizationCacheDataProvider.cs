// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Security.Authorization {
    public interface IEducationOrganizationCacheDataProvider
    {
        Task<IEnumerable<EducationOrganizationIdentifiers>> GetAllEducationOrganizationIdentifiers();
    }
}