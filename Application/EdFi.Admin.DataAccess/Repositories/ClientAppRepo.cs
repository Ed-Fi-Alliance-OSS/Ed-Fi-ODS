// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Extensions;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EdFi.Admin.DataAccess.Repositories
{
    public class ClientAppRepo : IClientAppRepo
    {
        private const int DefaultDuration = 60;
        private readonly IUsersContextFactory _contextFactory;
        private readonly Lazy<string> _defaultAppName;
        private readonly Lazy<string> _defaultClaimSetName;
        private readonly Lazy<string> _defaultOperationalContextUri;
        private readonly Lazy<int> _duration;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ClientAppRepo));

        public ClientAppRepo(IUsersContextFactory contextFactory, IConfigurationRoot config)
        {
            _contextFactory = Preconditions.ThrowIfNull(contextFactory, nameof(contextFactory));
            Preconditions.ThrowIfNull(config, nameof(config));

            _duration = new Lazy<int>(
                () =>
                {
                    // Get the config value, defaulting to 1 hour
                    if (!int.TryParse(
                            config.GetSection("BearerTokenTimeoutMinutes")
                                .Value,
                            out int duration))
                    {
                        duration = DefaultDuration;
                    }

                    return duration;
                });

            _defaultOperationalContextUri = new Lazy<string>(
                () => config.GetSection("DefaultOperationalContextUri")
                    .Value);

            _defaultAppName = new Lazy<string>(
                () => config.GetSection("DefaultApplicationName")
                    .Value);

            _defaultClaimSetName = new Lazy<string>(
                () => config.GetSection("DefaultClaimSetName")
                    .Value);
        }

        public void CreateProfilesWithProfileDefinition(List<Profile> profiles)
        {
            using (var context = _contextFactory.CreateContext())
            {
                foreach (var profile in profiles)
                {
                    var profileExists = context.Profiles.FirstOrDefault(s => s.ProfileName == profile.ProfileName);

                    if (profileExists == null)
                    {
                        context.Profiles.Add(
                            new Profile
                            {
                                ProfileName = profile.ProfileName,
                                ProfileDefinition = profile.ProfileDefinition
                            });
                    }
                }

                context.SaveChanges();
            }
        }

        public void AddOwnershipTokensToApiClient(string ownershipToken, int apiClientId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var ownershiptoken = GetOrCreateOwnershipToken(ownershipToken);

                var currentOwnershipToken = context.OwnershipTokens
                    .Include(u => u.ApiClients)
                    .FirstOrDefault(u => u.OwnershipTokenId == ownershiptoken.OwnershipTokenId);

                if (!currentOwnershipToken.ApiClients.Any(a => a.ApiClientId == apiClientId))
                {
                    var apiClient = context.ApiClients.FirstOrDefault(a => a.ApiClientId == apiClientId);
                    currentOwnershipToken.ApiClients.Add(apiClient);
                }

                context.SaveChanges();
            }
        }

        public void AddApiClientOwnershipTokens(List<string> ownershipTokens, int apiClientId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var apiClientOwnershipTokenList = new List<ApiClientOwnershipToken>();

                foreach (var ownershipToken in ownershipTokens)
                {
                    var ownershiptoken = context.OwnershipTokens.FirstOrDefault(x => x.Description == ownershipToken);
                    var apiClient = context.ApiClients.FirstOrDefault(u => u.ApiClientId == apiClientId);

                    apiClientOwnershipTokenList.Add(
                        new ApiClientOwnershipToken
                        {
                            ApiClientId = apiClient.ApiClientId,
                            OwnershipTokenId = ownershiptoken.OwnershipTokenId
                        });
                }

                context.ApiClientOwnershipTokens.AddRange(apiClientOwnershipTokenList);
                context.SaveChanges();
            }
        }

        public void AddProfilesToApplication(List<Profile> profiles, int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                foreach (var _profile in profiles)
                {
                    var profile = GetOrCreateProfile(_profile.ProfileName, _profile.ProfileDefinition);

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
                return context.Users.Include(u => u.ApiClients).ThenInclude(ac => ac.Application)
                    .ToList();
            }
        }

        public User GetUser(int userId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return
                    context.Users.Include(u => u.ApiClients).ThenInclude(ac => ac.Application)
                        .FirstOrDefault(u => u.UserId == userId);
            }
        }

        public User GetUser(string userName)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return
                    context.Users.Include(u => u.ApiClients).ThenInclude(a => a.Application)
                        .Include(u => u.Vendor)
                        .FirstOrDefault(x => x.Email == userName);
            }
        }

        public void DeleteUser(User userProfile)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var user =
                    context.Users.Include(u => u.ApiClients).ThenInclude(ac => ac.Application)
                        .FirstOrDefault(x => x.UserId == userProfile.UserId);

                if (user == null)
                {
                    return;
                }

                var arraySoThatUnderlyingCollectionCanBeModified = user.ApiClients.ToArray();

                foreach (var client in arraySoThatUnderlyingCollectionCanBeModified)
                {
                    context.ApiClients.Remove(client);
                }

                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public ApiClient GetClient(string key)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.ApiClients.Include(c => c.Application)
                    .ThenInclude(c => c.Vendor)
                    .ThenInclude(c => c.VendorNamespacePrefixes)
                    .Include(c => c.ApplicationEducationOrganizations)
                    .Include(c => c.CreatorOwnershipToken)
                    .FirstOrDefault(c => c.Key == key);
            }
        }

        public async Task<ApiClient> GetClientAsync(string key)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.ApiClients.Include(c => c.Application)
                    .ThenInclude(a => a.Vendor)
                    .ThenInclude(v => v.VendorNamespacePrefixes)
                    .Include(c => c.ApplicationEducationOrganizations)
                    .Include(c => c.CreatorOwnershipTokenId)
                    .FirstOrDefaultAsync(c => c.Key == key);
            }
        }

        public ApiClient GetClient(string key, string secret)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.ApiClients.FirstOrDefault(c => c.Key == key && c.Secret == secret);
            }
        }

        public ApiClient GetClientByKey(string key)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.ApiClients.FirstOrDefault(c => c.Key == key);
            }
        }

        public ApiClient UpdateClient(ApiClient client)
        {
            using (var context = _contextFactory.CreateContext())
            {
                context.ApiClients.Update(client);
                context.SaveChanges();
                return client;
            }
        }

        public void DeleteClient(string key)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = context.ApiClients.Include(x => x.ClientAccessTokens).First(x => x.Key == key);

                var apiClientOdsInstances = context.ApiClientOdsInstances.Include(x => x.ApiClient).Include(x => x.OdsInstance)
                    .Where(x => x.ApiClient.ApiClientId == client.ApiClientId);

                foreach (var clientAccessToken in client.ClientAccessTokens)
                {
                    context.ClientAccessTokens.Remove(clientAccessToken);
                }

                foreach (var apiClientOdsInstance in apiClientOdsInstances)
                {
                    context.OdsInstances.Remove(apiClientOdsInstance.OdsInstance);
                    context.ApiClientOdsInstances.Remove(apiClientOdsInstance);
                }

                context.ApiClients.Remove(client);

                context.SaveChanges();
            }
        }

        public IEnumerable<Vendor> GetVendors()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Vendors.Include(u => u.VendorNamespacePrefixes).Include(a=>a.Applications)
                    .ToList();
            }
        }

        public IEnumerable<Application> GetApplications()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Applications.Include(u => u.ApplicationEducationOrganizations).Include(a=>a.Vendor).ToList();
            }
        }

        public Vendor GetVendor(int vendorId)
        {
            using var context = _contextFactory.CreateContext();
            return context.Vendors.FirstOrDefault(c => c.VendorId == vendorId);
        }

        public Application GetApplication(int applicationId)
        {
            using var context = _contextFactory.CreateContext();
            return context.Applications.FirstOrDefault(c => c.ApplicationId == applicationId);
        }

        public void DeleteApplication(int applicationId)
        {
            using var context = _contextFactory.CreateContext();
            var application = context.Applications.First(x => x.ApplicationId == applicationId);

            var applicationEducationOrganizations = context.ApplicationEducationOrganizations.Include(x => x.Application)
                .Where(x => x.Application.ApplicationId == application.ApplicationId);

            foreach (var applicationEducationOrganization in applicationEducationOrganizations)
            {
                context.ApplicationEducationOrganizations.Remove(applicationEducationOrganization);
            }

            context.Applications.Remove(application);

            context.SaveChanges();
        }

        public void DeleteVendor(int vendorId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var vendor = context.Vendors.First(x => x.VendorId == vendorId);

                var vendorNamespacePrefixes = context.VendorNamespacePrefixes.Include(x=>x.Vendor)
                    .Where(x => x.Vendor.VendorId == vendor.VendorId);

                foreach (var vendorNamespacePrefix in vendorNamespacePrefixes)
                {
                    context.VendorNamespacePrefixes.Remove(vendorNamespacePrefix);
                }

                var applications = context.Applications.Include(x => x.Vendor)
                        .Where(x => x.Vendor.VendorId == vendor.VendorId);

                foreach (var application in applications)
                {
                    context.Applications.Remove(application);
                }

                context.Vendors.Remove(vendor);
                context.SaveChanges();
            }
        }

        public Vendor UpdateVendor(Vendor vendor)
        {
            using var context = _contextFactory.CreateContext();
            context.Vendors.Update(vendor);
            context.SaveChanges();
            return vendor;
        }

        public Application CreateOrGetApplication(int vendorId, string applicationName, long educationOrganizationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var application = context.Applications.SingleOrDefault(v => v.ApplicationName == applicationName);

                if (application == null)
                {
                    var vendor = context.Vendors.SingleOrDefault(v => v.VendorId == vendorId);
                    application = Application.Create(applicationName, educationOrganizationId, vendor);
                }

                context.Applications.Update(application);
                context.SaveChanges();
                return application;
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
                    .ThenInclude(v => v.Applications)
                    .SingleOrDefault(u => u.UserId == userId);

                if (user == null)
                {
                    return;
                }

                if (user.Vendor != null)
                {
                    client.Application = user.Vendor.Applications.FirstOrDefault();
                }

                context.ApiClients.Add(client);
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

        public void SetupKeySecret(
            string name,
            SandboxType sandboxType,
            string key,
            string secret,
            int userId,
            int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = CreateApiClient(context, userId, name, sandboxType, key, secret);

                AddApplicationEducationOrganizations(context, applicationId, client);

                context.SaveChanges();
            }
        }

        public void AddEdOrgIdsToApiClient(int userId, int apiClientId, IList<long> edOrgIds, int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var application = context.Applications
                    .Include(a => a.ApplicationEducationOrganizations)
                    .Single(a => a.ApplicationId == applicationId);

                var user = context.Users.Include(u => u.ApiClients).FirstOrDefault(u => u.UserId == userId);

                var client = user?.ApiClients.FirstOrDefault(c => c.ApiClientId == apiClientId);

                if (client == null)
                {
                    return;
                }

                client.Application = application;

                foreach (var applicationEducationOrganization in application.ApplicationEducationOrganizations.Where(
                             s => edOrgIds.Contains(s.EducationOrganizationId)))
                {
                    client.ApplicationEducationOrganizations.Add(applicationEducationOrganization);
                }

                context.SaveChanges();
            }
        }

        public ApiClient SetupDefaultSandboxClient(
            string name,
            SandboxType sandboxType,
            string key,
            string secret,
            int userId,
            int applicationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                _logger.Debug($"Creating API Client");
                var client = GetClient(key, secret) ?? CreateApiClient(context, userId, name, sandboxType, key, secret);

                _logger.Debug($"Adding Education Organization to client");
                AddApplicationEducationOrganizations(context, applicationId, client);

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
                    catch (Exception) { }

                    dbContext.DeleteAll<ClientAccessToken>();
                    dbContext.DeleteAll<ApiClientOdsInstance>();
                    dbContext.DeleteAll<ApiClient>();
                    dbContext.DeleteAll<OdsInstance>();
                    dbContext.DeleteAll<User>();
                    dbContext.DeleteAll<ApplicationEducationOrganization>();
                    dbContext.DeleteAll<Application>();
                    dbContext.DeleteAll<Vendor>();
                    dbContext.DeleteAll<OwnershipToken>();
                    dbContext.DeleteAll<Profile>();
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
            var namespacePrefix = "uri://" + userEmail.Split('@')[1].ToLower();

            SetDefaultVendorOnUserFromEmailAndName(userEmail, userName, new List<string> { namespacePrefix });
        }

        public void SetDefaultVendorOnUserFromEmailAndName(string userEmail, string userName,
            IEnumerable<string> namespacePrefixes)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var vendor = FindOrCreateVendorByDomainName(userName, namespacePrefixes);

                var user = context.Users.FirstOrDefault(u => u.Email.Equals(userEmail));

                if (user == null)
                {
                    user = User.Create(userEmail, userName, vendor);
                }
                else
                {
                    user.Vendor = vendor;
                }

                context.Vendors.Update(vendor);
                context.Users.Update(user);
                context.SaveChanges();
            }
        }

        public Vendor CreateOrGetVendor(string vendorName, IEnumerable<string> namespacePrefixes)
        {
            string name = vendorName.Split(',')[0].Trim();

            using (var context = _contextFactory.CreateContext())
            {
                var vendor = context.Vendors.SingleOrDefault(v => v.VendorName == vendorName);

                if (vendor == null)
                {
                    vendor = Vendor.Create(vendorName, namespacePrefixes);
                }
                context.Vendors.Update(vendor);
                context.SaveChanges();
                return vendor;
            }
        }

        public Application CreateApplicationForVendor(int vendorId, string applicationName, string claimSetName)
        {
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
                    OperationalContextUri = _defaultOperationalContextUri.Value
                };

                context.Applications.Update(app);

                context.SaveChanges();

                return app;
            }
        }

        public OdsInstance CreateOdsInstance(OdsInstance odsInstance)
        {
            using (var context = _contextFactory.CreateContext())
            {
                context.OdsInstances.Add(odsInstance);
                context.SaveChanges();
                return odsInstance;
            }
        }

        public void AddOdsInstanceToApiClient(int apiClientId, int odsInstanceId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var apiClient = context.ApiClients.Single(a => a.ApiClientId == apiClientId);
                var odsInstance = context.OdsInstances.Single(o => o.OdsInstanceId == odsInstanceId);

                var apiClientOdsInstance = new ApiClientOdsInstance()
                {
                    ApiClient = apiClient,
                    OdsInstance = odsInstance
                };

                context.ApiClientOdsInstances.Add(apiClientOdsInstance);
                context.SaveChanges();
            }
        }

        private Profile GetOrCreateProfile(string profileName, string profileDefinition)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var profiles = context.Profiles.FirstOrDefault(s => s.ProfileName == profileName);

                if (profiles == null)
                {
                    context.Profiles.Add(
                        new Profile
                        {
                            ProfileName = profileName,
                            ProfileDefinition = profileDefinition
                        });

                    context.SaveChanges();
                }

                return context.Profiles.FirstOrDefault(s => s.ProfileName == profileName);
            }
        }

        private OwnershipToken GetOrCreateOwnershipToken(string ownershipToken)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var ownershipTokens = context.OwnershipTokens.FirstOrDefault(s => s.Description == ownershipToken);

                if (ownershipTokens == null)
                {
                    context.OwnershipTokens.Add(new OwnershipToken { Description = ownershipToken });
                    context.SaveChanges();
                }

                return context.OwnershipTokens.FirstOrDefault(s => s.Description == ownershipToken);
            }
        }

        private ApiClient CreateApiClient(
            IUsersContext context,
            int userId,
            string name,
            SandboxType sandboxType,
            string key,
            string secret)
        {
            var attachedUser = context.Users.Find(userId);

            return attachedUser.AddSandboxClient(name, sandboxType, key, secret);
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
                context.ApplicationEducationOrganizations.Update(applicationEducationOrganization);
            }
        }

        private Vendor FindOrCreateVendorByDomainName(string vendorName, IEnumerable<string> namespacePrefixes)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var vendor = context.Vendors.FirstOrDefault(v => v.VendorName == vendorName);

                if (vendor != null)
                {
                    return vendor;
                }

                var newVendor = Vendor.Create(vendorName, namespacePrefixes);

                context.Vendors.Update(newVendor);

                //TODO: DEA - Move this behavior to happen during client creation.  No need to do this in two places.  At a minimum, remove the duplicated code.
                CreateDefaultApplicationForVendor(newVendor);

                return newVendor;
            }
        }

        private void CreateDefaultApplicationForVendor(Vendor vendor)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var app = context.Applications.SingleOrDefault(
                    a => a.ApplicationName == _defaultAppName.Value && a.Vendor.VendorId == vendor.VendorId);

                if (app != null)
                {
                    return;
                }

                context.Applications.Update(
                    new Application
                    {
                        ApplicationName = _defaultAppName.Value,
                        Vendor = vendor,
                        ClaimSetName = _defaultClaimSetName.Value,
                        OperationalContextUri = _defaultOperationalContextUri.Value
                    });
            }
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
