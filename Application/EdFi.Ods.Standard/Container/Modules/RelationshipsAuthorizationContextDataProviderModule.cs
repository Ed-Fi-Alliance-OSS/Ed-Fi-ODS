// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

namespace EdFi.Ods.Standard.Container.Modules
{
    public class RelationshipsAuthorizationContextDataProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyOpenGenericTypes(typeof(Marker_EdFi_Ods_Standard).Assembly)
                .Where(t =>
                    // Avoid registering any overrides here
                    t.Namespace?.Contains(".Overrides") != true
                        && t.IsAssignableTo<IRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>>())
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
