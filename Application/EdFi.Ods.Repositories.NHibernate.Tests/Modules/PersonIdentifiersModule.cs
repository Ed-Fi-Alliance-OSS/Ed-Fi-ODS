// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Repositories.NHibernate.Tests.Modules
{
    public class PersonIdentifiersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonIdentifiersProvider>()
                .As<IPersonIdentifiersProvider>()
                .SingleInstance();
            
            builder.RegisterType<PersonEntitySpecification>()
                .As<IPersonEntitySpecification>()
                .SingleInstance();

            builder.RegisterType<FakePersonTypesProvider>()
                .As<IPersonTypesProvider>()
                .SingleInstance();
        }
    }
}