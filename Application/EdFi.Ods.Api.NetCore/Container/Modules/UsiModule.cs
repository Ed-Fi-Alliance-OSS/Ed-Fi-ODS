// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Api.NetCore.Container.Modules
{
    public class UsiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UniqueIdToUsiValueMapper>().As<IUniqueIdToUsiValueMapper>().PreserveExistingDefaults()
                .SingleInstance();

            builder.RegisterType<PersonUniqueIdToUsiCache>().WithParameter(new NamedParameter("synchronousInitialization", false))
                .As<IPersonUniqueIdToUsiCache>().SingleInstance();
        }
    }
}
