﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Providers.Criteria;

namespace EdFi.Ods.Repositories.NHibernate.Tests.Modules
{
    public class RepositoryFilterProvidersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(PagedAggregateIdsCriteriaProvider<>))
                .As(typeof(IPagedAggregateIdsCriteriaProvider<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(TotalCountCriteriaProvider<>))
                .As(typeof(ITotalCountCriteriaProvider<>))
                .SingleInstance();
        }
    }
}