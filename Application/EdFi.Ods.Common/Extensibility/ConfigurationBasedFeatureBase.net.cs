#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Extensibility
{
    /// <summary>
    /// Provides a base class implementation for a feature activated by a standard configuration value.
    /// </summary>
    public abstract class ConfigurationBasedFeatureBase : ConditionalFeatureBase
    {
        protected readonly IConfigValueProvider ConfigValueProvider;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationBasedFeatureBase"/>
        /// </summary>
        /// <param name="configValueProvider">
        /// An instance of <see cref="IConfigValueProvider"/>, which is used to determine if the feature is enabled.
        /// </param>
        /// <param name="apiConfigurationProvider">An instance of a service providing API configuration details.</param>
        protected ConfigurationBasedFeatureBase(
            IConfigValueProvider configValueProvider,
            IApiConfigurationProvider apiConfigurationProvider)
            : base(configValueProvider, apiConfigurationProvider)
        {
            ConfigValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));

            Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
        }

        public string ConfigKey => $"{FeatureName.ToCamelCase()}:featureIsEnabled";

        protected override Func<IApiConfigurationProvider, IConfigValueProvider, bool> ActivationPredicate
            => (apiConfig, config) => ConfigValueProvider.GetValue(ConfigKey).ToBoolean();
    }
}
#endif