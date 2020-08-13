﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;

namespace EdFi.Ods.Api.Container.Modules
{
    public class OAuthModule : ConditionalModule
    {
        public OAuthModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(OAuthModule)) { }

        public override bool IsSelected() => !ApiSettings.DisableSecurity;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<ClientCredentialsTokenRequestProvider>().As<ITokenRequestProvider>();
            builder.RegisterType<OAuthTokenValidator>().As<IOAuthTokenValidator>();
            builder.RegisterDecorator<CachingOAuthTokenValidatorDecorator, IOAuthTokenValidator>();
            builder.RegisterType<AuthenticationProvider>().As<IAuthenticationProvider>();
        }
    }
}
#endif