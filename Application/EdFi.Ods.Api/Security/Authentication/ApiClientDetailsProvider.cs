// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Common.Security;
using EdFi.Common.Security.Authentication;

namespace EdFi.Ods.Api.Security.Authentication
{
    /// <summary>
    /// Retrieves the API client's details from the EdFi_Admin database.
    /// </summary>
    public class ApiClientDetailsProvider : IApiClientDetailsProvider
    {
        private readonly IEdFiAdminRawApiClientDetailsProvider _edFiAdminRawApiClientDetailsProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientDetailsProvider"/> class.
        /// </summary>
        /// <param name="edFiAdminRawApiClientDetailsProvider">The access token client repository</param>
        public ApiClientDetailsProvider(IEdFiAdminRawApiClientDetailsProvider edFiAdminRawApiClientDetailsProvider)
        {
            _edFiAdminRawApiClientDetailsProvider = edFiAdminRawApiClientDetailsProvider ?? throw new ArgumentNullException(nameof(edFiAdminRawApiClientDetailsProvider));
        }

        /// <summary>
        /// Loads the API client details for the supplied API client key from the Admin database.
        /// </summary>
        /// <param name="key">The key of the API client for which details should be retrieved.</param>
        /// <returns>A <see cref="ApiClientDetails"/> instance if a matching key is found; otherwise <b>null</b>.</returns>
        public async Task<ApiClientDetails> GetApiClientDetailsForKeyAsync(string key)
        {
            var rawApiClientDetailsData = await _edFiAdminRawApiClientDetailsProvider.GetRawClientDetailsDataAsync(key);

            return CreateApiClientDetails(rawApiClientDetailsData);
        }

        /// <summary>
        /// Loads the API client details for the supplied token from the Admin database.
        /// </summary>
        /// <param name="token">The OAuth security token for which API client details should be retrieved.</param>
        /// <returns>A <see cref="ApiClientDetails"/> instance if a matching token is found; otherwise <b>null</b>.</returns>
        /// <exception cref="FormatException">Occurs when the token is not a parseable as a GUID.</exception>
        public async Task<ApiClientDetails> GetApiClientDetailsForTokenAsync(string token)
        {
            if (!Guid.TryParse(token, out Guid tokenAsGuid))
            {
                return null;
            }

            var rawApiClientDetailsData = await _edFiAdminRawApiClientDetailsProvider.GetRawClientDetailsDataAsync(tokenAsGuid);

            return CreateApiClientDetails(rawApiClientDetailsData);
        }
        
        private ApiClientDetails CreateApiClientDetails(IReadOnlyList<RawApiClientDetailsDataRow> apiClientRawDataRows)
        {
            ArgumentNullException.ThrowIfNull(apiClientRawDataRows);

            var firstRow = apiClientRawDataRows.FirstOrDefault();
            
            if (firstRow == null)
            {
                return null;
            }

            var apiClientDetails = new ApiClientDetails
            (
                // Initialize properties
                apiClientId: firstRow.ApiClientId,
                apiKey: firstRow.Key,
                secret: firstRow.Secret,
                secretIsHashed: firstRow.SecretIsHashed,
                isSandboxClient: firstRow.UseSandbox,
                studentIdentificationSystemDescriptor: firstRow.StudentIdentificationSystemDescriptor,
                creatorOwnershipTokenId: firstRow.CreatorOwnershipTokenId,
                claimSetName: firstRow.ClaimSetName,
                expiresUtc: firstRow.Expiration,
                // Reconstitute raw rows into individual collections
                educationOrganizationIds: GetEducationOrganizationIds().ToArray(),
                namespacePrefixes: GetVendorNamespacePrefixes().ToArray(),
                profiles: GetProfileNames().ToArray(),
                ownershipTokenIds: GetOwnershipTokenIds().ToArray()
            );

            return apiClientDetails;

           
            IEnumerable<int> GetEducationOrganizationIds()
            {
                return apiClientRawDataRows
                    .Where(x => x.EducationOrganizationId.HasValue)
                    .Select(x => x.EducationOrganizationId.Value)
                    .Distinct();
            }

            IEnumerable<string> GetVendorNamespacePrefixes()
            {
                return apiClientRawDataRows
                    .Where(x => !string.IsNullOrWhiteSpace(x.NamespacePrefix))
                    .Select(x => x.NamespacePrefix)
                    .Distinct();
            }

            IEnumerable<string> GetProfileNames()
            {
                return apiClientRawDataRows
                    .Where(x =>! string.IsNullOrWhiteSpace(x.ProfileName))
                    .Select(x => x.ProfileName)
                    .Distinct();
            }

            IEnumerable<short> GetOwnershipTokenIds()
            {
                return apiClientRawDataRows
                    .Where(x => x.OwnershipTokenId.HasValue)
                    .Select(x => x.OwnershipTokenId.Value)
                    .Distinct();
            }
        }
    }
}
