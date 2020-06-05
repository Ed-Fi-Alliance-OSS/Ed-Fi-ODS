#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using EdFi.Ods.ChangeQueries.Container.Installers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;

namespace EdFi.Ods.ChangeQueries
{
    /// <summary>
    /// Provides Windsor installers for the Change Queries feature.
    /// </summary>
    public class ChangeQueriesFeature : ConfigurationBasedFeatureBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ChangeQueriesFeature"/>
        /// </summary>
        /// <param name="configValueProvider">
        /// An instance of <see cref="IConfigValueProvider"/>, which is used to determine if the feature is enabled.
        /// </param>
        /// <param name="apiConfigurationProvider">An instance of a service providing API configuration details.</param>
        public ChangeQueriesFeature(
            IConfigValueProvider configValueProvider,
            IApiConfigurationProvider apiConfigurationProvider)
            : base(configValueProvider, apiConfigurationProvider) { }

        public override string FeatureName => ChangeQueriesConstants.FeatureName;

        public override IWindsorInstaller Installer => new ChangeQueriesInstaller();
    }
}
#endif