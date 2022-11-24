// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Common.Security;
using EdFi.Common.Security.Authentication;

namespace EdFi.Admin.DataAccess.Security
{
    public class EdFiAdminApiClientIdentityProvider : IApiClientSecretProvider, IApiClientIdentityProvider
    {
        private readonly IApiClientDetailsProvider _apiClientDetailsProvider;
        private readonly IClientAppRepo _clientAppRepo;

        public EdFiAdminApiClientIdentityProvider(
            IApiClientDetailsProvider apiClientDetailsProvider,
            IClientAppRepo clientAppRepo)
        {
            _apiClientDetailsProvider = apiClientDetailsProvider;
            _clientAppRepo = clientAppRepo;
        }

        public ApiClientIdentity GetApiClientIdentity(string key)
        {
            var apiClientDetails = _apiClientDetailsProvider.GetApiClientDetailsForKeyAsync(key)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new ApiClientIdentity
                   {
                       ClaimSetName = apiClientDetails.ClaimSetName,
                       EducationOrganizationIds = apiClientDetails.EducationOrganizationIds,
                       Key = apiClientDetails.ApiKey,
                       NamespacePrefixes = apiClientDetails.NamespacePrefixes,
                       Profiles = apiClientDetails.Profiles
                   };
        }

        public async Task<ApiClientIdentity> GetApiClientIdentityAsync(string key)
        {
            var apiClientDetails = await _apiClientDetailsProvider.GetApiClientDetailsForKeyAsync(key);
            
            return new ApiClientIdentity
            {
                ClaimSetName = apiClientDetails.ClaimSetName,
                EducationOrganizationIds = apiClientDetails.EducationOrganizationIds,
                Key = apiClientDetails.ApiKey,
                NamespacePrefixes = apiClientDetails.NamespacePrefixes,
                Profiles = apiClientDetails.Profiles,
                ApiClientId = apiClientDetails.ApiClientId,
                Secret = apiClientDetails.Secret,
                IsHashed = apiClientDetails.SecretIsHashed
            };
        }

        public ApiClientSecret GetSecret(string key)
        {
            var apiClientDetails = _apiClientDetailsProvider.GetApiClientDetailsForKeyAsync(key)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();;

            return new ApiClientSecret
                   {
                       Secret = apiClientDetails.Secret, IsHashed = apiClientDetails.SecretIsHashed
                   };
        }

        public void SetSecret(string key, ApiClientSecret secret)
        {
            var client = GetClientByKey(key);

            client.Secret = secret.Secret;
            client.SecretIsHashed = secret.IsHashed;
            _clientAppRepo.UpdateClient(client);
        }

        private ApiClient GetClientByKey(string key)
        {
            var client =  _clientAppRepo.GetClientByKey(key);

            if (client == null)
            {
                throw new ArgumentException($"Invalid key:'{key}'");
            }

            return client;
        }
    }
}