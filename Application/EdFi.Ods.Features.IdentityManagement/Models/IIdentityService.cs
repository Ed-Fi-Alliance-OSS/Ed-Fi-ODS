﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    /// <summary>
    /// Implement this interface if the supporting service supports synchronous methods
    /// </summary>
    public interface IIdentityService<in TCreateRequest, in TSearchRequest, TSearchResponse, TIdentityResponse>
        where TCreateRequest : IdentityCreateRequest
        where TSearchRequest : IdentitySearchRequest
        where TSearchResponse : IdentitySearchResponse<TIdentityResponse>
        where TIdentityResponse : IdentityResponse
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
        Task<IdentityResponseStatus<string>> Create(TCreateRequest createRequest);

        /// <summary>
        /// Find existing identities by their identifiers
        /// </summary>
        /// <param name="findRequest">Unique person identifiers to look up</param>
        /// <returns>An identity response status of: Success with IdentityResponse[]</returns>
        Task<IdentityResponseStatus<TSearchResponse>> Find(params string[] findRequest);

        /// <summary>
        /// Search for exact and potential identity matches
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<TSearchResponse>> Search(params TSearchRequest[] searchRequest);
    }
}
