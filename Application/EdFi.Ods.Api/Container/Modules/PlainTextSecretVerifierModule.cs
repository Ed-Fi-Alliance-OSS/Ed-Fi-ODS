// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Common.Security;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.Container.Modules
{
    public class PlainTextSecretVerifierModule : ConditionalModule
    {
        public PlainTextSecretVerifierModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(PlainTextSecretVerifierModule)) { }

        public override bool IsSelected() => ApiSettings.PlainTextSecrets;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<PlainTextSecretVerifier>()
                .As<ISecretVerifier>()
                .SingleInstance();
        }
    }
}