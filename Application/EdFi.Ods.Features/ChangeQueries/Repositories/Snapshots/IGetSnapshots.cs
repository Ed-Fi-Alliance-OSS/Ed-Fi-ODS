// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Features.ChangeQueries.Resources;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Snapshots
{
    public interface IGetSnapshots
    {
        Task<IList<Snapshot>> GetAllAsync(IQueryParameters queryParameters);

        Task<Snapshot> GetByIdAsync(Guid id);
    }
}
