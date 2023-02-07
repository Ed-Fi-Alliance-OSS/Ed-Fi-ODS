// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.Ods.Features.ChangeQueries.Providers
{
    /// <summary>
    /// Defines a method for obtaining the ids of the earliest (oldest) and most recent (newest) change events available.
    /// </summary>
    public interface IAvailableChangeVersionProvider
    {
        /// <summary>
        /// Gets the ids of the earliest (oldest) and most recent (newest) change events available.
        /// </summary>
        /// <returns><see cref="AvailableChangeVersion"/></returns>
        Task<AvailableChangeVersion> GetAvailableChangeVersion();
    }
}
