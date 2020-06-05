#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.MicroKernel.Registration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Extensibility
{
    /// <summary>
    /// Provides an abstract base class implementation for a feature that is activated
    /// conditionally based on a delegate that provides access to the <see cref="IConfigValueProvider" />
    /// and the <see cref="IApiConfigurationProvider" /> services.
    /// </summary>
    public abstract class ConditionalFeatureBase : IFeature
    {
        private readonly IConfigValueProvider _configValueProvider;
        private readonly IApiConfigurationProvider _apiConfigurationProvider;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationBasedFeatureBase"/>
        /// </summary>
        /// <param name="configValueProvider">
        /// An instance of <see cref="IConfigValueProvider"/>, which is used to determine if the feature is enabled.
        /// </param>
        protected ConditionalFeatureBase(IConfigValueProvider configValueProvider, IApiConfigurationProvider apiConfigurationProvider)
        {
            _apiConfigurationProvider = Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
        }

        /// <summary>
        /// Gets the feature name for the feature using a convention of removing the "Feature" suffix from the class name.
        /// </summary>
        public virtual string FeatureName => this.GetType().Name.TrimSuffix("Feature");

        protected abstract Func<IApiConfigurationProvider, IConfigValueProvider, bool> ActivationPredicate { get; }

        /// <summary>
        /// Gets the associated <see cref="WindsorInstaller"/> for this feature.
        /// </summary>
        public abstract IWindsorInstaller Installer { get; }

        /// <summary>
        /// Indicates whether the feature is enabled.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the feature is enabled; otherwise false.
        /// </returns>
        public bool IsEnabled() => ActivationPredicate(_apiConfigurationProvider, _configValueProvider);
    }
}
#endif