// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using log4net;

namespace EdFi.Ods.Api.Common.Container
{
    public abstract class ConditionalModule : Module
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ConditionalModule));

        protected readonly ApiSettings ApiSettings;
        private readonly string _moduleName;

        protected ConditionalModule(ApiSettings apiSettings, string moduleName)
        {
            ApiSettings = apiSettings;
            _moduleName = moduleName;
        }

        public abstract bool IsSelected();

        public abstract void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder);

        protected override void Load(ContainerBuilder builder)
        {
            if (IsSelected())
            {
                ApplyConfigurationSpecificRegistrations(builder);
            }
            else
            {
                _logger.Debug($"{_moduleName} Module is disabled and will not be installed.");
            }
        }
        protected bool IsFeatureEnabled(ApiFeature feature) => ApiSettings.IsFeatureEnabled(feature.GetConfigKeyName());
    }
}
#endif
