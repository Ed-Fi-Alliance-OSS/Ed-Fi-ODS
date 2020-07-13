// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Admin.DataAccess.Extensions;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Sandbox.Provisioners;

namespace EdFi.Ods.Sandbox.Repositories
{
    public class ClientAppRepo : IClientAppRepo
    {
        private const int DefaultDuration = 60;
        private readonly IConfigValueProvider _configValueProvider;
        private readonly IUsersContextFactory _contextFactory;
        private readonly ISandboxProvisioner _provisioner;

        public ClientAppRepo(
            IUsersContextFactory contextFactory,
            ISandboxProvisioner provisioner,
            IConfigValueProvider configValueProvider)
        {
            _contextFactory = Preconditions.ThrowIfNull(contextFactory, nameof(contextFactory));
            _provisioner = Preconditions.ThrowIfNull(provisioner, nameof(provisioner));
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
        }


        private Profile GetOrCreateProfile(string profileName)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var profiles = context.Profiles.FirstOrDefault(s => s.ProfileName == profileName);

                if (profiles == null)
                {
                    context.Profiles.Add(new Profile { ProfileName = profileName });
                    context.SaveChanges();
                }

                return context.Profiles.FirstOrDefault(s => s.ProfileName == profileName);
            }
        }

        public void AddProfilesToApplication(List<string> profileNames, int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                foreach (var profileName in profileNames)
                {
                    var profile = GetOrCreateProfile(profileName);

                    var currentProfile = context.Profiles
                              .Include(u => u.Applications)
                              .FirstOrDefault(u => u.ProfileId == profile.ProfileId);

                    if (!currentProfile.Applications.Any(a => a.ApplicationId == applicationId))
                    {
                        var application = context.Applications.FirstOrDefault(a => a.ApplicationId == applicationId);
                        currentProfile.Applications.Add(application);
                    }

                }

                context.SaveChanges();
            }
        }

        public async Task<string> GetUserNameFromTokenAsync(string token)
        {
            using (var context = _contextFactory.CreateContext())
            {
                // Used by Sandbox Admin only, therefore PostgreSQL support is not needed
                var emailResult = await context.ExecuteQueryAsync<EmailResult>(
                    @"select top 1 U.Email from webpages_Membership M join Users U on M.UserId = U.UserId and M.ConfirmationToken = {0}",
                    token);

                var result = emailResult.FirstOrDefault();
                return result == null
                    ? null
                    : result.Email;
            }
        }

        public async Task<string> GetTokenFromUserNameAsync(string userName)
        {
            using (var context = _contextFactory.CreateContext())
            {
                // Used by Sandbox Admin only, therefore PostgreSQL support is not needed
                var confirmationTokenResult = await context.ExecuteQueryAsync<ConfirmationTokenResult>(
                    @"select top 1 M.ConfirmationToken from webpages_Membership M join Users U on M.UserId = U.UserId and U.Email = {0}",
                    userName);

                var result = confirmationTokenResult.FirstOrDefault();
                return result == null
                    ? null
                    : result.ConfirmationToken;
            }
        }

        public User CreateUser(User user)
        {
            using (var context = _contextFactory.CreateContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Users.Include(u => u.ApiClients.Select(ac => ac.Application))
                              .ToList();
            }
        }

        public User GetUser(int userId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return
                    context.Users.Include(u => u.ApiClients.Select(ac => ac.Application))
                           .FirstOrDefault(u => u.UserId == userId);
            }
        }

        public User GetUser(string userName)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return
                    context.Users.Include(u => u.ApiClients.Select(ac => ac.Application))
                           .Include(u => u.Vendor)
                           .FirstOrDefault(x => x.Email == userName);
            }
        }

        public void DeleteUser(User userProfile)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var user =
                    context.Users.Include(u => u.ApiClients.Select(ac => ac.Application))
                           .FirstOrDefault(x => x.UserId == userProfile.UserId);

                if (user == null)
                {
                    return;
                }

                var arraySoThatUnderlyingCollectionCanBeModified = user.ApiClients.ToArray();

                foreach (var client in arraySoThatUnderlyingCollectionCanBeModified)
                {
                    context.Clients.Remove(client);
                }

                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public ApiClient GetClient(string key)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Clients.Include(c => c.Application)
                              .Include(c => c.Application.Vendor)
                              .Include(c => c.Application.Vendor.VendorNamespacePrefixes)
                              .Include(c => c.Application.Profiles)
                              .Include(c => c.ApplicationEducationOrganizations)
                              .Include(c => c.CreatorOwnershipTokenId)
                              .FirstOrDefault(c => c.Key == key);
            }
        }

        public ApiClient GetClient(string key, string secret)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Clients.FirstOrDefault(c => c.Key == key && c.Secret == secret);
            }
        }

        public ApiClient UpdateClient(ApiClient client)
        {
            using (var context = _contextFactory.CreateContext())
            {
                context.Clients.AddOrUpdate(client);
                context.SaveChanges();
                return client;
            }
        }

        public void DeleteClient(string key)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = context.Clients.First(x => x.Key == key);

                // TODO SF: AA-518
                // Assuming that this is used by Admin App, although that will not actually be clear
                // until we are able to start testing Admin App thoroughly.
                // Convert this to ANSI SQL for PostgreSql support and don't use a SqlParameter.
                // Be sure to write integration tests in project EdFi.Ods.Admin.Models.IntegrationTests.
                context.ExecuteSqlCommandAsync(
                    @"delete ClientAccessTokens where ApiClient_ApiClientId = @clientId; 
delete ApiClients where ApiClientId = @clientId",
                    new SqlParameter("@clientId", client.ApiClientId))
                    .Wait();

                if (client.UseSandbox)
                {
                    _provisioner.DeleteSandboxes(key);
                }
            }
        }

        public ClientAccessToken AddClientAccessToken(int apiClientId, string tokenRequestScope = null)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = context.Clients
                    .FirstOrDefault(c => c.ApiClientId == apiClientId);

                if (client == null)
                {
                    throw new InvalidOperationException("Cannot add client access token when the client does not exist.");
                }

                // Get the config value, defaulting to 1 hour
                if (!int.TryParse(_configValueProvider.GetValue("BearerTokenTimeoutMinutes"), out int duration))
                {
                    duration = DefaultDuration;
                }

                var token = new ClientAccessToken(TimeSpan.FromMinutes(duration))
                {
                    Scope = string.IsNullOrEmpty(tokenRequestScope)
                        ? null
                        : tokenRequestScope.Trim()
                };

                client.ClientAccessTokens.Add(token);
                context.SaveChanges();
                return token;
            }
        }

        public Application[] GetVendorApplications(int vendorId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Applications.Where(a => a.Vendor.VendorId == vendorId)
                              .ToArray();
            }
        }

        public void AddApiClientToUserWithVendorApplication(int userId, ApiClient client)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var user = context.Users
                                  .Include(u => u.Vendor)
                                  .Include(v => v.Vendor.Applications)
                                  .SingleOrDefault(u => u.UserId == userId);

                if (user == null)
                {
                    return;
                }

                if (user.Vendor != null)
                {
                    client.Application = user.Vendor.Applications.FirstOrDefault();
                }

                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        public ApiClient CreateApiClient(int userId, string name, string key, string secret)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = CreateApiClient(context, userId, name, SandboxType.Sample, key, secret);

                context.SaveChanges();

                return client;
            }
        }

        public void SetupKeySecret(string name, SandboxType sandboxType, string key, string secret, int userId, int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = CreateApiClient(context, userId, name, sandboxType, key, secret);

                AddApplicationEducationOrganizations(context, applicationId, client);

                context.SaveChanges();
            }
        }

        private ApiClient CreateApiClient(IUsersContext context, int userId, string name, SandboxType sandboxType, string key, string secret)
        {
            var attachedUser = context.Users.Find(userId);

            return attachedUser.AddSandboxClient(name, sandboxType, key, secret);

        }

        public void AddLeaIdsToApiClient(int userId, int apiClientId, IList<int> leaIds, int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var application = context.Applications
                    .Include(a => a.ApplicationEducationOrganizations)
                    .Single(a => a.ApplicationId == applicationId);

                var user = context.Users.FirstOrDefault(u => u.UserId == userId);

                var client = user?.ApiClients.FirstOrDefault(c => c.ApiClientId == apiClientId);

                if (client == null)
                {
                    return;
                }

                client.Application = application;

                foreach (var applicationEducationOrganization in application.ApplicationEducationOrganizations.Where(s => leaIds.Contains(s.EducationOrganizationId)))
                {
                    client.ApplicationEducationOrganizations.Add(applicationEducationOrganization);
                }

                context.SaveChanges();
            }
        }

        private void AddApplicationEducationOrganizations(IUsersContext context, int applicationId, ApiClient client)
        {
            var defaultApplication = context.Applications
                .Include(a => a.ApplicationEducationOrganizations)
                .First(a => a.ApplicationId == applicationId);

            client.Application = defaultApplication;

            foreach (var applicationEducationOrganization in defaultApplication.ApplicationEducationOrganizations)
            {
                client.ApplicationEducationOrganizations.Add(applicationEducationOrganization);
            }
        }

        public ApiClient SetupDefaultSandboxClient(string name, SandboxType sandboxType, string key, string secret, int userId, int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = CreateApiClient(context, userId, name, sandboxType, key, secret);

                AddApplicationEducationOrganizations(context, applicationId, client);

                _provisioner.AddSandbox(client.Key, sandboxType);

                context.SaveChanges();

                return client;
            }
        }

        public void Reset()
        {
            try
            {
                using (var context = _contextFactory.CreateContext())
                {
                    var dbContext = context as DbContext;

                    try
                    {
                        //Admin.Web Creates table webpages_UsersInRoles.
                        //If exists remove rows, if not swallow exception.
                        dbContext.DeleteAll<WebPagesUsersInRoles>();
                        context.SaveChanges();
                    }
                    catch(Exception) { }

                    dbContext.DeleteAll<ClientAccessToken>();
                    dbContext.DeleteAll<ApiClient>();
                    dbContext.DeleteAll<User>();
                    dbContext.DeleteAll<ApplicationEducationOrganization>();
                    dbContext.DeleteAll<Application>();
                    dbContext.DeleteAll<Vendor>();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while attempting to reset Admin database.", ex);
            }
        }


        public void SetDefaultVendorOnUserFromEmailAndName(string userEmail, string userName)
        {
            var namePrefix = "uri://" + userEmail.Split('@')[1]
                                                 .ToLower();

            var vendorName = userName.Split(',')[0]
                                     .Trim();

            using (var context = _contextFactory.CreateContext())
            {
                var vendor = FindOrCreateVendorByDomainName(context, vendorName, namePrefix);
                var usr = context.Users.Single(u => u.Email == userEmail);
                usr.Vendor = vendor;
                context.SaveChanges();
            }
        }

        public void SetDefaultVendorOnUserFromEmailAndName(string userEmail, string userName, IEnumerable<string> namespacePrefixes)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var vendor = CreateOrGetVendor(userEmail, userName, namespacePrefixes);
                var user = context.Users.Single(u => u.Email.Equals(userEmail));

                user.Vendor = vendor;
                context.SaveChanges();
            }
        }

        public Vendor CreateOrGetVendor(string userEmail, string userName, IEnumerable<string> namespacePrefixes)
        {
            var vendorName = userName.Split(',')[0]
                .Trim();

            using (var context = _contextFactory.CreateContext())
            {
                var vendor = context.Vendors.SingleOrDefault(v => v.VendorName == vendorName);

                    if (vendor == null)
                    {
                        vendor = new Vendor
                        {
                            VendorName = vendorName
                        };

                        foreach (string namespacePrefix in namespacePrefixes)
                        {
                            vendor.VendorNamespacePrefixes.Add(
                                new VendorNamespacePrefix
                                {
                                    Vendor = vendor,
                                    NamespacePrefix = namespacePrefix
                                });
                        }
                        context.SaveChanges();
                    }

                    return vendor;
            }
        }

        private Vendor FindOrCreateVendorByDomainName(IUsersContext context, string vendorName, string namePrefix)
        {
            var vendor = context.Vendors.SingleOrDefault(v => v.VendorName == vendorName);

            if (vendor == null)
            {
                vendor = new Vendor
                         {
                             VendorName = vendorName
                         };

                vendor.VendorNamespacePrefixes.Add(
                    new VendorNamespacePrefix
                    {
                        Vendor = vendor, NamespacePrefix = namePrefix
                    });

                context.Vendors.AddOrUpdate(vendor);

                //TODO: DEA - Move this behavior to happen during client creation.  No need to do this in two places.  At a minimum, remove the duplicated code.
                CreateDefaultApplicationForVendor(context, vendor);
            }

            return vendor;
        }

        public Application CreateApplicationForVendor(int vendorId, string applicationName, string claimSetName)
        {
            var defaultOperationalContextUri = _configValueProvider.GetValue("DefaultOperationalContextUri");

            using (var context = _contextFactory.CreateContext())
            {
                var app =
                    context.Applications.SingleOrDefault(
                        a => a.ApplicationName == applicationName && a.Vendor.VendorId == vendorId);

                if (app != null)
                {
                    return app;
                }

                var vendor = context.Vendors.FirstOrDefault(v => v.VendorId == vendorId);

                app = new Application
                {
                    ApplicationName = applicationName,
                    Vendor = vendor,
                    ClaimSetName = claimSetName,
                    OperationalContextUri = defaultOperationalContextUri
                };

                context.Applications.AddOrUpdate(app);

                context.SaveChanges();

                return app;
            }
        }

        private void CreateDefaultApplicationForVendor(IUsersContext context, Vendor vendor)
        {
            var defaultAppName = _configValueProvider.GetValue("DefaultApplicationName");
            var defaultClaimSetName = _configValueProvider.GetValue("DefaultClaimSetName");
            var defaultOperationalContextUri = _configValueProvider.GetValue("DefaultOperationalContextUri");

            var app =
                context.Applications.SingleOrDefault(
                    a => a.ApplicationName == defaultAppName && a.Vendor.VendorId == vendor.VendorId);

            if (app != null)
            {
                return;
            }

            context.Applications.AddOrUpdate(
                new Application
                {
                    ApplicationName = defaultAppName, Vendor = vendor, ClaimSetName = defaultClaimSetName,
                    OperationalContextUri = defaultOperationalContextUri
                });
        }

        internal class EmailResult
        {
            public string Email { get; set; }
        }

        internal class ConfirmationTokenResult
        {
            public string ConfirmationToken { get; set; }
        }
    }
}
