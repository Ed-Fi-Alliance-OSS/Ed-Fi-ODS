#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;
using EdFi.Ods.Features.Container.Installers;

namespace EdFi.Ods.Features.Composites
{
    /// <summary>
    /// Provides Windsor installers for the Composites feature.
    /// </summary>
    public class CompositesFeature : ConfigurationBasedFeatureBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CompositesFeature"/>
        /// </summary>
        /// <param name="configValueProvider">
        /// An instance of <see cref="EdFi.Ods.Common.Configuration.IConfigValueProvider"/>, which is used to determine if the feature is enabled.
        /// </param>
        /// <param name="apiConfigurationProvider">An instance of a service providing API configuration details.</param>
        public CompositesFeature(IConfigValueProvider configValueProvider, IApiConfigurationProvider apiConfigurationProvider)
            : base(configValueProvider, apiConfigurationProvider) { }

        public override string FeatureName => CompositesConstants.FeatureName;

        /// <inheritdoc cref="ConditionalFeatureBase.Installer" />
        public override IWindsorInstaller Installer => new CompositesInstaller();
    }
}
#endif