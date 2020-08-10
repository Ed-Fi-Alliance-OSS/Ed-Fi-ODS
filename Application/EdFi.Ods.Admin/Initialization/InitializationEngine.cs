// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Web.Security;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Admin.Security;
using EdFi.Ods.Admin.Services;
using EdFi.Ods.Sandbox.Repositories;
using log4net;
using WebMatrix.WebData;

namespace EdFi.Ods.Admin.Initialization
{
    public class InitializationEngine
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(InitializationEngine));
        private readonly IClientAppRepo _clientAppRepo;
        private readonly IClientCreator _clientCreator;
        private readonly ITemplateDatabaseLeaQuery _templateDatabaseLeaQuery;
        private readonly IDefaultApplicationCreator _applicationCreator;

        private readonly InitializationModel _settings;

        public InitializationEngine(
            InitializationModel initializationModel,
            IClientAppRepo clientAppRepo,
            IClientCreator clientCreator,
            ITemplateDatabaseLeaQuery templateDatabaseLeaQuery,
            IDefaultApplicationCreator applicationCreator
            )
        {
            _settings = initializationModel;
            _clientAppRepo = clientAppRepo;
            _clientCreator = clientCreator;
            _templateDatabaseLeaQuery = templateDatabaseLeaQuery;
            _applicationCreator = applicationCreator;
        }

        public void CreateIdentityRoles()
        {
            try
            {
                foreach (var role in SecurityRoles.AllRoles)
                {
                    if (!Roles.RoleExists(role))
                    {
                        _log.Debug($"Adding role: {role} to asp net security.");
                        Roles.CreateRole(role);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void CreateIdentityUsers()
        {
            try
            {
                foreach (var user in _settings.Users)
                {
                    if (WebSecurity.UserExists(user.UserName))
                    {
                        continue;
                    }

                    _log.Debug($"Adding user: {user} to asp net security.");
                    WebSecurity.CreateUserAndAccount(user.UserName, user.Password, new {FullName = user.Name});

                    foreach (var role in user.Roles)
                    {
                        _log.Debug($"Adding user: {user} to role: {role} in asp net security.");
                        Roles.AddUserToRole(user.Email, role);
                    }

                    _log.Debug($"Applying password to  user: {user} in asp net security.");
                    WebSecurityService.UpdatePasswordAndActivate(user.UserName, user.Password);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void CreateVendors()
        {
            try
            {
                foreach (var user in _settings.Users)
                {
                    var namespacePrefixes = user.NamespacePrefixes.Select(nsp => nsp.NamespacePrefix).ToList();

                    _log.Info($"Creating vendor {user} with namespace prefixes {string.Join(",", namespacePrefixes)}");
                    _clientAppRepo.SetDefaultVendorOnUserFromEmailAndName(user.Email, user.UserName, namespacePrefixes);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void CreateSandboxes()
        {
            try
            {
                foreach (var user in _settings.Users)
                {
                    var clientProfile = _clientAppRepo.GetUser(user.Email);

                    foreach (var sandbox in user.Sandboxes)
                    {
                        if (clientProfile.ApiClients.Any(c => c.Key == sandbox.Key))
                        {
                            continue;
                        }

                        _log.Info($"Creating sandbox {sandbox.Key} for user {user.UserName}");
                        _clientCreator.CreateNewSandboxClient(sandbox, clientProfile);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void RebuildSandboxes()
        {
            try
            {
                foreach (var user in _settings.Users)
                {
                    var clientProfile = _clientAppRepo.GetUser(user.Email);

                    foreach (var sandbox in user.Sandboxes.Where(x => x.Refresh))
                    {
                        _log.Debug($"Resetting sandbox {sandbox} for {clientProfile.Vendor.VendorName}");
                        _clientCreator.ResetSandboxClient(sandbox, clientProfile);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void UpdateClientWithLEAIdsFromPopulatedSandbox()
        {
            foreach (var user in _settings.Users)
            {
                var clientProfile = _clientAppRepo.GetUser(user.Email);

                // look through all the sandboxes that are populated so we can get the lea ids from the created sandbox.
                // note our current template process has the populated data with lea's installed in it.
                foreach (var apiClient in clientProfile.ApiClients)
                {
                    var leaIds = _templateDatabaseLeaQuery.GetLocalEducationAgencyIds(apiClient.Key).ToList();

                    _applicationCreator.AddLeaIdsToApplication(leaIds, apiClient.Application.ApplicationId);
                }
            }
        }
    }
}
