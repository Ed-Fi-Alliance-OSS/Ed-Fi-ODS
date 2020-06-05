// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Models.Identity;

namespace EdFi.Ods.Api.Services.Controllers.IdentityManagement
{
    public class UnimplementedIdentityService : IIdentityService, IIdentityServiceAsync
    {
        public IdentityServiceCapabilities IdentityServiceCapabilities
        {
            get { return IdentityServiceCapabilities.None; }
        }

        public Task<IdentityResponseStatus<string>> Create(IdentityCreateRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Find(params string[] findRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Search(params IdentitySearchRequest[] searchRequest)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Search(params IdentitySearchRequest[] searchRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Response(string requestToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Find(params string[] findRequest)
        {
            throw new NotImplementedException();
        }
    }
}
