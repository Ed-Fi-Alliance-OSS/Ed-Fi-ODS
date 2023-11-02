// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.Person;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;
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

            RegisterPersonIdentifierCaching(builder);
        }

        private static void RegisterPersonIdentifierCaching(ContainerBuilder builder)
        {
            var cacheSuppression = new Dictionary<string, bool>()
            {
                { "Student", false },
                { "Staff", false },
                { "Parent", false },
                { "Contact", false },
            };

            builder
                .RegisterType<InMemoryMapCache<(ulong odsInstanceHashId, string personType, PersonMapType personMapType), string, int>>()
                .WithParameter(new NamedParameter("slidingExpiration", TimeSpan.FromSeconds(14400)))
                .WithParameter(new NamedParameter("absoluteExpirationPeriod", TimeSpan.FromSeconds(86400)))
                .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int>>()
                .SingleInstance();

            builder
                .RegisterType<InMemoryMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>>()
                .WithParameter(new NamedParameter("slidingExpiration", TimeSpan.FromSeconds(14400)))
                .WithParameter(new NamedParameter("absoluteExpirationPeriod", TimeSpan.FromSeconds(86400)))
                .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>>()
                .SingleInstance();

            builder.RegisterType<PersonMapCacheInitializer>().As<IPersonMapCacheInitializer>().SingleInstance();

            builder.RegisterType<PersonUniqueIdResolver>()
                .WithParameter(new NamedParameter("cacheSuppressionByPersonType", cacheSuppression))
                .As<IPersonUniqueIdResolver>()
                .SingleInstance();

            builder.RegisterType<PersonUsiResolver>()
                .WithParameter(new NamedParameter("cacheSuppressionByPersonType", cacheSuppression))
                .As<IPersonUsiResolver>()
                .SingleInstance();
        }
    }
}
