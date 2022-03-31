// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Repositories;


namespace EdFi.Ods.Repositories.NHibernate.Tests.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(CreateEntity<>))
                .As(typeof(ICreateEntity<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(DeleteEntityById<>))
                .As(typeof(IDeleteEntityById<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(DeleteEntityByKey<>))
                .As(typeof(IDeleteEntityByKey<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntitiesByIds<>))
                .As(typeof(IGetEntitiesByIds<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntitiesBySpecification<>))
                .As(typeof(IGetEntitiesBySpecification<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntityById<>))
                .As(typeof(IGetEntityById<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntityByKey<>))
                .As(typeof(IGetEntityByKey<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(UpdateEntity<>))
                .As(typeof(IUpdateEntity<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(UpsertEntity<>))
                .As(typeof(IUpsertEntity<>))
                .SingleInstance();
        }
    }
}