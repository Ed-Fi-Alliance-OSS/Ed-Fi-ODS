// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Models;

namespace EdFi.Ods.Sandbox.Repositories
{
    public interface IClientAppRepo
    {

        void AddProfilesToApplication(List<string> profileNames, int applicationId);

        Task<string> GetTokenFromUserNameAsync(string userName);

        Task<string> GetUserNameFromTokenAsync(string token);

        IEnumerable<User> GetUsers();

        User GetUser(int userId);

        User GetUser(string userName);

        User CreateUser(User user);

        void DeleteUser(User userProfile);

        ApiClient GetClient(string key);

        Task<ApiClient> GetClientAsync(string key);

        ApiClient GetClient(string key, string secret);

        ApiClient UpdateClient(ApiClient client);

        void DeleteClient(string key);

        ClientAccessToken AddClientAccessToken(int apiClientId, string tokenRequestScope = null);

        Task<ClientAccessToken> AddClientAccessTokenAsync(int apiClientId, string tokenRequestScope = null);

        void SetDefaultVendorOnUserFromEmailAndName(string userEmail, string userName);

        Application[] GetVendorApplications(int vendorId);

        void AddApiClientToUserWithVendorApplication(int userId, ApiClient client);

        ApiClient SetupDefaultSandboxClient(string name, SandboxType sandboxType, string key, string secret, int userId, int applicationId);

        void SetupKeySecret(string name, SandboxType sandboxType, string key, string secret, int userId, int applicationId);

        Vendor CreateOrGetVendor(string userEmail, string userName);

        Application CreateApplicationForVendor(int vendorId, string applicationName, string claimSetName);

        ApiClient CreateApiClient(int userId, string name, string key, string secret);

        void AddLeaIdsToApiClient(int userId, int apiClientId, IList<int> leaIds, int applicationId);

        void Reset();
    }
}
