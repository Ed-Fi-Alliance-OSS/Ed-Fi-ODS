// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using log4net;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Common.Container
{
    public abstract class ConditionalModule : Module
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ConditionalModule));

        private readonly string _moduleName;
        private readonly IFeatureManager _featureManager;

        protected ConditionalModule(IFeatureManager featureManager)
        {
            _moduleName = GetType().Name;
            _featureManager = featureManager;
        }

        protected abstract bool IsSelected();

        protected abstract void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder);

        /// <summary>
        /// Register implementations needed to prevent dependency injection failures (often on controllers)
        /// due to lack of registered dependencies. The components registered should throw a `FeatureDisabledException`
        /// when its members are invoked.
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void ApplyFeatureDisabledRegistrations(ContainerBuilder builder)
        {
            // Nothing to do, by default
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (IsSelected())
            {
                _logger.Info($"Loading registrations from conditional module '{_moduleName}'...");
                ApplyConfigurationSpecificRegistrations(builder);
            }
            else
            {
                ApplyFeatureDisabledRegistrations(builder);
                _logger.Debug($"{_moduleName} Module is disabled and will not be installed.");
            }
        }

        protected bool IsFeatureEnabled(ApiFeature feature) => _featureManager.IsFeatureEnabled(feature);
    }
}
