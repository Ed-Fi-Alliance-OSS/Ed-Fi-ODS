// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Common.Security.Authentication;

namespace EdFi.Admin.DataAccess.Authentication
{
    public interface IEdFiAdminRawApiClientDetailsProvider
    {
        Task<IReadOnlyList<RawApiClientDetailsDataRow>> GetRawClientDetailsDataAsync(Guid accessToken);

        Task<IReadOnlyList<RawApiClientDetailsDataRow>> GetRawClientDetailsDataAsync(string key);
    }
}