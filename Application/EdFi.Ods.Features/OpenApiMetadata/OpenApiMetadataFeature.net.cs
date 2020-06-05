#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;
using EdFi.Ods.Features.Container.Installers;

namespace EdFi.Ods.Features.OpenApiMetadata
{
    public class OpenApiMetadataFeature : ConfigurationBasedFeatureBase
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;

        public OpenApiMetadataFeature(
            IConfigValueProvider configValueProvider,
            IApiConfigurationProvider apiConfigurationProvider)
            : base(configValueProvider, apiConfigurationProvider)
        {
            _apiConfigurationProvider = apiConfigurationProvider;
        }

        public override string FeatureName
        {
            get => OpenApiMetadataConstants.FeatureName;
        }

        public override IWindsorInstaller Installer
        {
            get => new OpenApiMetadataInstaller(_apiConfigurationProvider);
        }
    }
}
#endif