// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security
{
    /// <summary>
    /// Defines methods for getting and setting the contextual details for the current authenticated API client.
    /// </summary>
    public interface IApiClientContextProvider
    {
        /// <summary>
        /// Gets the details of the current authenticated API client from context.
        /// </summary>
        /// <returns>An <see cref="ApiClientContext"/> instance.</returns>
        ApiClientContext GetApiClientContext();

        /// <summary>
        /// Sets the details of the current authenticated API client into context.
        /// </summary>
        /// <param name="apiClientContext">The <see cref="ApiClientContext"/> instance to be stored.</param>
        void SetApiClientContext(ApiClientContext apiClientContext);
    }
}
