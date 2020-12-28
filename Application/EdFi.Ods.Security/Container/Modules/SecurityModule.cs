// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Claims;
using EdFi.Ods.Security.Utilities;

namespace EdFi.Ods.Security.Container.Modules
{
    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationContextProvider>()
                .As<IAuthorizationContextProvider>()
                .SingleInstance();

            builder.RegisterType<AuthorizationSegmentsVerifier>()
                .As<IAuthorizationSegmentsVerifier>()
                .SingleInstance();

            builder.RegisterType<AuthorizationViewsProvider>()
                .As<IAuthorizationViewsProvider>()
                .SingleInstance();

            builder.RegisterType<ClaimsIdentityProvider>()
                .As<IClaimsIdentityProvider>()
                .SingleInstance();

            builder.RegisterType<ResourceClaimUriProvider>()
                .As<IResourceClaimUriProvider>()
                .SingleInstance();
        }
    }
}
