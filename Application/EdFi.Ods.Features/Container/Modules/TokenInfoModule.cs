// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.TokenInfo;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.Container.Modules
{
    public class TokenInfoModule :ConditionalModule
    {
        public TokenInfoModule(IFeatureManager featureManager)
            : base(featureManager) { }

        protected override bool IsSelected() => IsFeatureEnabled(ApiFeature.TokenInfo);

        protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<TokenInfoProvider>()
                .As<ITokenInfoProvider>()
                .SingleInstance();
        }
    }
}
