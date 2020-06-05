// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Web.Security;
using EdFi.Ods.Admin.Security;
using EdFi.Ods.Admin.Services;
using EdFi.Ods.Sandbox.Repositories;
using log4net;
using WebMatrix.WebData;

namespace EdFi.Ods.Admin.Initialization
{
    public class InitializationEngine
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InitializationEngine));
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
                        Roles.CreateRole(role);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }

        public void CreateUsers()
        {
            if (!_settings.Enabled)
            {
                return;
            }

            try
            {
                foreach (var user in _settings.Users)
                {
                    if (WebSecurity.UserExists(user.UserName))
                    {
                        continue;
                    }

                    CreateUser(user);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }

        private void CreateUser(UserInitializationModel user)
        {
            WebSecurity.CreateUserAndAccount(
                user.UserName,
                user.Password,
                new
                {
                    FullName = user.Name
                });

            foreach (var role in user.Roles)
            {
                Roles.AddUserToRole(user.Email, role);
            }

            WebSecurityService.UpdatePasswordAndActivate(user.UserName, user.Password);
            _clientAppRepo.SetDefaultVendorOnUserFromEmailAndName(user.Email, user.Name);
        }

        public void EnsureMinimalTemplateEducationOrganizationsExist()
        {
            if (!_settings.Enabled)
            {
                return;
            }

            try
            {
                _educationOrganizationsInitializer.EnsureMinimalTemplateEducationOrganizationsInitialized();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }
        
        public void CreateSandboxes()
        {
            if (!_settings.Enabled)
            {
                return;
            }

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

                        _clientCreator.CreateNewSandboxClient(sandbox, clientProfile);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }

        public void RebuildSandboxes()
        {
            if (!_settings.Enabled)
            {
                return;
            }

            try
            {
                foreach (var user in _settings.Users)
                {
                    var clientProfile = _clientAppRepo.GetUser(user.Email);

                    foreach (var sandbox in user.Sandboxes.Where(x => x.Refresh))
                    {
                        _clientCreator.ResetSandboxClient(sandbox, clientProfile);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }
    }
}
