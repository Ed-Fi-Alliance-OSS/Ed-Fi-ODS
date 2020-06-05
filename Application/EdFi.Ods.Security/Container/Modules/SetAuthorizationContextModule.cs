// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Security.Authorization.Pipeline;

namespace EdFi.Ods.Security.Container.Modules {
    public class SetAuthorizationContextModule : ConditionalModule
    {
        public override bool IsSelected() => !ApiSettings.DisableSecurity;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(SetAuthorizationContextForGet<,,,>)).AsSelf();
            builder.RegisterGeneric(typeof(SetAuthorizationContextForPut<,,,>)).AsSelf();
            builder.RegisterGeneric(typeof(SetAuthorizationContextForDelete<,,,>)).AsSelf();
            builder.RegisterGeneric(typeof(SetAuthorizationContextForPost<,,,>)).AsSelf();
        }

        public SetAuthorizationContextModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(SetAuthorizationContextModule)) { }
    }
}
#endif