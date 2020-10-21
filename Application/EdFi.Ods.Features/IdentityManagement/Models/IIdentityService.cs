// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    /// <summary>
    /// Implement this interface if the supporting service supports synchronous methods
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Which IdentityServices does the supporting service implement
        /// </summary>
        IdentityServiceCapabilities IdentityServiceCapabilities { get; }

        /// <summary>
        /// Create one or more identities
        /// </summary>
        /// <param name="createRequest">an array of identities to be created</param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<string>> Create(IdentityCreateRequest createRequest);

        /// <summary>
        /// Find existing identities by their identifiers
        /// </summary>
        /// <param name="findRequest">Unique person identifiers to look up</param>
        /// <returns>An identity response status of: Success with IdentityResponse[]</returns>
        Task<IdentityResponseStatus<IdentitySearchResponse>> Find(params string[] findRequest);

        /// <summary>
        /// Search for exact and potential identity matches
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<IdentitySearchResponse>> Search(params IdentitySearchRequest[] searchRequest);
    }
}
