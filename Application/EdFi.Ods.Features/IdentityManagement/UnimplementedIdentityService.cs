// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Features.IdentityManagement.Models;

namespace EdFi.Ods.Features.IdentityManagement
{
    /// <summary>
    /// Implements the Identities service such that it exhibits no capabilities and each method throws <see cref="NotImplementedException" />. 
    /// </summary>
    public class UnimplementedIdentityService : IIdentityServiceWithDefaultModels, IIdentityServiceWithDefaultModelsAsync
    {
        public IdentityServiceCapabilities IdentityServiceCapabilities
        {
            get { return IdentityServiceCapabilities.None; }
        }

        public Task<IdentityResponseStatus<string>> Create(IdentityCreateRequest createRequest)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResponseStatus<IdentitySearchResponse<IdentityResponse>>> IIdentityService<IdentityCreateRequest, IdentitySearchRequest, IdentitySearchResponse<IdentityResponse>, IdentityResponse>.Find(params string[] findRequest)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync<IdentitySearchRequest, IdentitySearchResponse<IdentityResponse>, IdentityResponse>.Search(params IdentitySearchRequest[] searchRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse<IdentityResponse>>> Response(string requestToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync<IdentitySearchRequest, IdentitySearchResponse<IdentityResponse>, IdentityResponse>.Find(params string[] findRequest)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResponseStatus<IdentitySearchResponse<IdentityResponse>>> IIdentityService<IdentityCreateRequest, IdentitySearchRequest, IdentitySearchResponse<IdentityResponse>, IdentityResponse>.Search(params IdentitySearchRequest[] searchRequest)
        {
            throw new NotImplementedException();
        }
    }
}
