// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using EdFi.Admin.DataAccess.Models;
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
        private readonly IEducationOrganizationsInitializer _educationOrganizationsInitializer;

        private readonly InitializationModel _settings;

        public InitializationEngine(
            InitializationModel initializationModel,
            IClientAppRepo clientAppRepo,
            IClientCreator clientCreator,
            IEducationOrganizationsInitializer educationOrganizationsInitializer
            )
        {
            _settings = initializationModel;
            _clientAppRepo = clientAppRepo;
            _clientCreator = clientCreator;
            _educationOrganizationsInitializer = educationOrganizationsInitializer;
        }

        public void CreateRoles()
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

        public void CreateUsers()
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
    }
}
