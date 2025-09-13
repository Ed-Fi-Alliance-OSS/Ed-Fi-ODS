// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using Autofac.Core;
using Autofac.Features.AttributeFilters;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Providers.Queries;

namespace EdFi.Ods.Api.Container.Modules;

public class KeySetPagingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PartitionsQueryBuilderProvider>()
            .As<IPartitionsQueryBuilderProvider>()
            .SingleInstance()
            .WithAttributeFiltering();

        builder.RegisterType<PartitionRowNumbersCteQueryBuilderProvider>()
            .Keyed<IAggregateRootQueryBuilderProvider>(PartitionRowNumbersCteQueryBuilderProvider.RegistrationKey)
            .AsSelf()
            .SingleInstance();
    }
}
