// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Admin.Initialization;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using log4net;
using EdFi.Ods.Sandbox.Repositories;


namespace EdFi.Ods.Admin.Services
{
    public class ClientCreator : IClientCreator
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ClientCreator));

        private const string MaximumSandboxesPerUserConfigKey = "MaximumSandboxesPerUser";
        private const int MaximumSandboxesPerUserDefault = 5;

        private readonly int _maximumSandboxesPerUser;

        private readonly IConfigValueProvider _configValueProvider;
        private readonly IClientAppRepo _clientAppRepo;
        private readonly IDefaultApplicationCreator _defaultApplicationCreator;

        public ClientCreator(
            IConfigValueProvider configValueProvider,
            IClientAppRepo clientAppRepo,
            IDefaultApplicationCreator defaultApplicationCreator)
        {
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
            _maximumSandboxesPerUser = GetMaximumSandboxesPerUserOrDefault();

            _clientAppRepo = Preconditions.ThrowIfNull(clientAppRepo, nameof(clientAppRepo));
            _defaultApplicationCreator = Preconditions.ThrowIfNull(defaultApplicationCreator, nameof(defaultApplicationCreator));
        }

        private int GetMaximumSandboxesPerUserOrDefault()
        {
            string configValue = _configValueProvider.GetValue(MaximumSandboxesPerUserConfigKey);

            return int.TryParse(configValue, out int configResult)
                ? configResult
                : MaximumSandboxesPerUserDefault;
        }

        public ApiClient CreateNewSandboxClient(SandboxInitializationModel createModel, User user)
        {
            if (user.ApiClients.Count >= _maximumSandboxesPerUser)
            {
                var message = $"The maximum of {_maximumSandboxesPerUser} sandboxes for user id {user.UserId} has been reached!";
                message += " To configure please update the 'MaximumSandboxesPerUser' app setting in the web.config.";
                _log.Error(message);
                throw new ArgumentOutOfRangeException(message);
            }

            var defaultApplication = _defaultApplicationCreator
                .FindOrCreateUpdatedDefaultSandboxApplication(user.Vendor.VendorId, createModel.SandboxType);

            return _clientAppRepo.SetupDefaultSandboxClient(
                createModel.Name,
                createModel.SandboxType,
                createModel.Key,
                createModel.Secret,
                user.UserId,
                defaultApplication.ApplicationId);
        }

        public ApiClient ResetSandboxClient(SandboxInitializationModel createModel, User user)
        {
            var defaultApplication = _defaultApplicationCreator
                .FindOrCreateUpdatedDefaultSandboxApplication(user.Vendor.VendorId, createModel.SandboxType);

            return _clientAppRepo.SetupDefaultSandboxClient(
                createModel.Name,
                createModel.SandboxType,
                createModel.Key,
                createModel.Secret,
                user.UserId,
                defaultApplication.ApplicationId);
        }
    }
}
