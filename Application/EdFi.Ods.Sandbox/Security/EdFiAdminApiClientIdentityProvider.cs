// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Sandbox.Security
{
    public class EdFiAdminApiClientIdentityProvider : IApiClientSecretProvider, IApiClientIdentityProvider
    {
        private readonly IClientAppRepo _clientAppRepo;

        public EdFiAdminApiClientIdentityProvider(IClientAppRepo clientAppRepo)
        {
            _clientAppRepo = clientAppRepo;
        }

        public ApiClientIdentity GetApiClientIdentity(string key)
        {
            var client = GetClient(key);

            var edOrgs = client.ApplicationEducationOrganizations.Select(aeo => aeo.EducationOrganizationId)
                               .ToList();

            var profiles = client.Application.Profiles.Select(p => p.ProfileName)
                                 .ToList();

            var namespacePrefixes = client.Application.Vendor.VendorNamespacePrefixes.Select(vnp => vnp.NamespacePrefix)
                                          .ToList();

            return new ApiClientIdentity
                   {
                       ClaimSetName = client.Application.ClaimSetName, EducationOrganizationIds = edOrgs, Key = key,
                       NamespacePrefixes = namespacePrefixes, Profiles = profiles
                   };
        }

        public async Task<ApiClientIdentity> GetApiClientIdentityAsync(string key)
        {
            var client = await GetClientAsync(key);

            var edOrgs = client.ApplicationEducationOrganizations.Select(aeo => aeo.EducationOrganizationId)
                .ToList();

            var profiles = client.Application.Profiles.Select(p => p.ProfileName)
                .ToList();

            var namespacePrefixes = client.Application.Vendor.VendorNamespacePrefixes.Select(vnp => vnp.NamespacePrefix)
                .ToList();

            return new ApiClientIdentity
            {
                ClaimSetName = client.Application.ClaimSetName,
                EducationOrganizationIds = edOrgs,
                Key = key,
                NamespacePrefixes = namespacePrefixes,
                Profiles = profiles
            };
        }

        public async Task<ApiClientSecret> GetSecretAsync(string key)
        {
            var client = await GetClientAsync(key);

            return new ApiClientSecret
            {
                Secret = client.Secret, IsHashed = client.SecretIsHashed
            };
        }

        public ApiClientSecret GetSecret(string key)
        {
            var client = GetClient(key);

            return new ApiClientSecret
                   {
                       Secret = client.Secret, IsHashed = client.SecretIsHashed
                   };
        }

        public void SetSecret(string key, ApiClientSecret secret)
        {
            var client = GetClient(key);

            client.Secret = secret.Secret;
            client.SecretIsHashed = secret.IsHashed;
            _clientAppRepo.UpdateClient(client);
        }

        private ApiClient GetClient(string key)
        {
            var client = _clientAppRepo.GetClient(key);

            if (client == null)
            {
                throw new ArgumentException($"Invalid key:'{key}'");
            }

            return client;
        }

        private async Task<ApiClient> GetClientAsync(string key)
        {
            var client = await _clientAppRepo.GetClientAsync(key);

            if (client == null)
            {
                throw new ArgumentException($"Invalid key:'{key}'");
            }

            return client;
        }
    }
}
