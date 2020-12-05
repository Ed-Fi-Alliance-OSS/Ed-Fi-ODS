// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.LoadTools;
using EdFi.LoadTools.ApiClient;

namespace EdFi.SmokeTest.Console
{
    public class SmokeTestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SmokeTestApplicationNoBlocks>()
                .As<ISmokeTestApplication>();

            builder.RegisterType<TokenRetriever>()
                .As<ITokenRetriever>()
                .SingleInstance();

            builder.RegisterType<OAuthTokenHandler>()
                .As<IOAuthTokenHandler>()
                .SingleInstance();

            builder.RegisterType<SwaggerRetriever>()
                .AsSelf();
        }
    }
}
