// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Ods.Sandbox.Admin.Services.Initialization;
using log4net;
using Microsoft.Extensions.Configuration;
using EdFi.Ods.SandboxAdmin.Services;
using EdFi.Ods.Sandbox.Provisioners;
namespace EdFi.Ods.Sandbox.Admin.Services
{
    public class ClientCreator : IClientCreator
    {
        private readonly ISandboxProvisioner _sandboxProvisioner;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ClientCreator));

        private const string MaximumSandboxesPerUserConfigKey = "MaximumSandboxesPerUser";
        private readonly int _maximumSandboxesPerUser;
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;

        private readonly IConfiguration _configuration;
        private readonly IClientAppRepo _clientAppRepo;
        private readonly IDefaultApplicationCreator _defaultApplicationCreator;
        private readonly ITemplateDatabaseLeaQuery _templateDatabaseLeaQuery;
        private readonly IDatabaseNameBuilder _databaseNameBuilder;
        private readonly IDbConnectionStringBuilderAdapterFactory _dbConnectionStringBuilderAdapterFactory;

        public ClientCreator(
            IConfiguration configValueProvider,
            IClientAppRepo clientAppRepo,
            IDefaultApplicationCreator defaultApplicationCreator,
            ITemplateDatabaseLeaQuery templateDatabaseLeaQuery,
            ISandboxProvisioner sandboxProvisioner,
            IConfigConnectionStringsProvider configConnectionStringsProvider,
            IDatabaseNameBuilder databaseNameBuilder,
            IDbConnectionStringBuilderAdapterFactory dbConnectionStringBuilderAdapterFactory)
        {
            _sandboxProvisioner = sandboxProvisioner;
            _configuration = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
            _maximumSandboxesPerUser = GetMaximumSandboxesPerUserOrDefault();
            _templateDatabaseLeaQuery = Preconditions.ThrowIfNull(templateDatabaseLeaQuery, nameof(templateDatabaseLeaQuery));
            _clientAppRepo = Preconditions.ThrowIfNull(clientAppRepo, nameof(clientAppRepo));
            _defaultApplicationCreator = Preconditions.ThrowIfNull(defaultApplicationCreator, nameof(defaultApplicationCreator));
            _configConnectionStringsProvider = configConnectionStringsProvider;
            _databaseNameBuilder = databaseNameBuilder;
            _dbConnectionStringBuilderAdapterFactory = dbConnectionStringBuilderAdapterFactory;
        }

        private int GetMaximumSandboxesPerUserOrDefault()
        {
            string configValue = _configuration.GetValue<string>(MaximumSandboxesPerUserConfigKey);

            return Int32.Parse(configValue);
        }

        public ApiClient CreateNewSandboxClient(string sandboxName, SandboxOptions sandboxOptions, User user, int? applicationId = null, bool addRestoredEdOrgIdsToApplication = true)
        {
            if (user.ApiClients.Count >= _maximumSandboxesPerUser)
            {
                var message = $"The maximum of {_maximumSandboxesPerUser} sandboxes for user {user.FullName} has been reached!";
                message += " To configure please update the 'MaximumSandboxesPerUser' app setting in the web.config.";
                _log.Error(message);
                throw new ArgumentOutOfRangeException(message);
            }

            var apiClient = ResetSandboxClient(sandboxName, sandboxOptions, user, applicationId, addRestoredEdOrgIdsToApplication);

            var connectionStringBuilder = _dbConnectionStringBuilderAdapterFactory.Get();

            connectionStringBuilder.ConnectionString = _configConnectionStringsProvider.GetConnectionString("EdFi_Ods");
            connectionStringBuilder.ApplicationName = "EdFi.Ods.WebApi";
            connectionStringBuilder.DatabaseName = _databaseNameBuilder.SandboxNameForKey(apiClient.Key);

            var odsInstance = _clientAppRepo.CreateOdsInstance(new OdsInstance
            {
                Name = sandboxName,
                InstanceType = "Sandbox",
                ConnectionString = connectionStringBuilder.ConnectionString
            });

            _clientAppRepo.AddOdsInstanceToApiClient(apiClient.ApiClientId, odsInstance.OdsInstanceId);

            return apiClient;
        }

        public ApiClient ResetSandboxClient(string sandboxName, SandboxOptions sandboxOptions, User user, int? applicationId = null, bool addRestoredEdOrgIdsToApplication = true)
        {
            var client = SetupDefaultSandboxClient(sandboxName, sandboxOptions, user, applicationId);

            ProvisionSandbox(client);

            if (addRestoredEdOrgIdsToApplication)
            {
                var edOrgIds = _templateDatabaseLeaQuery.GetLocalEducationAgencyIds(client.Key)
                    .Concat(_templateDatabaseLeaQuery.GetCommunityProviderIds(client.Key))
                    .Distinct()
                    .ToList();

                _defaultApplicationCreator.AddEdOrgIdsToApplication(edOrgIds, client.Application.ApplicationId);
            }

            return client;
        }

        private ApiClient SetupDefaultSandboxClient(string sandboxName, SandboxOptions sandboxOptions, User user, int? applicationId = null)
        {
            Application application;
            if (applicationId == null)
            {
                application = _defaultApplicationCreator
                    .FindOrCreateUpdatedDefaultSandboxApplication(user.Vendor.VendorId, sandboxOptions.Type);
            }
            else
            {
                application = _clientAppRepo.GetApplication((int)applicationId);
            }

            return _clientAppRepo.SetupDefaultSandboxClient(
                sandboxName,
                sandboxOptions.Type,
                sandboxOptions.Key,
                sandboxOptions.Secret,
                user.UserId,
                application.ApplicationId);
        }

        private void ProvisionSandbox(ApiClient client)
        {
            _log.Debug($"Creating {client.SandboxType.ToString()} sandbox for {client.Key}");
            _sandboxProvisioner.AddSandbox(client.Key, client.SandboxType);
        }
    }
}