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
    public class HashedSecretVerifierModule : ConditionalModule
    {
        public HashedSecretVerifierModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(HashedSecretVerifierModule)) { }

        public override bool IsSelected() => !ApiSettings.PlainTextSecrets;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<SecureHashAwareSecretVerifier>()
                .As<ISecretVerifier>()
                .SingleInstance();

            builder.RegisterDecorator<AutoUpgradingHashedSecretVerifierDecorator, ISecretVerifier>();

            builder.RegisterType<SecureHasherProvider>()
                .As<ISecureHasherProvider>()
                .SingleInstance();
        }
    }
}