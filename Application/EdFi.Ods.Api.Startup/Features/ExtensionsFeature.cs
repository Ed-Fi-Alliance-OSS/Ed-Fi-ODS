﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using EdFi.Ods.Api.Startup.Features.Installers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;

namespace EdFi.Ods.Api.Startup.Features
{
    public class ExtensionsFeature : ConfigurationBasedFeatureBase
    {
        private readonly IAssembliesProvider _assembliesProvider;

        public ExtensionsFeature(
            IConfigValueProvider configValueProvider, 
            IApiConfigurationProvider apiConfigurationProvider, 
            IAssembliesProvider assembliesProvider)
            : base(configValueProvider, apiConfigurationProvider)
        {
            _assembliesProvider = Preconditions.ThrowIfNull(assembliesProvider, nameof(assembliesProvider));
        }

        public override string FeatureName => ExtensionsConstants.FeatureName;

        public override IWindsorInstaller Installer => new ExtensionsInstaller(_assembliesProvider);
    }
}
