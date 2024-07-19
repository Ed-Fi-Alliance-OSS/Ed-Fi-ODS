// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using log4net;

namespace EdFi.Ods.Standard.Container.Modules
{
    public class RelationshipsAuthorizationContextDataProviderModule : Module
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(RelationshipsAuthorizationContextDataProviderModule));

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Marker_EdFi_Ods_Standard).Assembly)
                .Where(t =>
                    t.Namespace?.Contains(".Overrides") != true
                    && t.IsAssignableTo<IRelationshipsAuthorizationContextDataProvider>())
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
