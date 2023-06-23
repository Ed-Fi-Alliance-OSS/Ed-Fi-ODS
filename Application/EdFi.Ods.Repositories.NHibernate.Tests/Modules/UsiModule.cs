﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Repositories.NHibernate.Tests.Modules
{
    public class UsiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UniqueIdToUsiValueMapper>().As<IUniqueIdToUsiValueMapper>().PreserveExistingDefaults()
                .SingleInstance();

            var cacheSuppression = new Dictionary<string, bool>()
            {
                { "Student", false },
                { "Staff", false },
                { "Parent", false },
                { "Contact", false },
            };
            
            builder.RegisterType<PersonUniqueIdToUsiCache>()
                .WithParameter(new NamedParameter("synchronousInitialization", false))
                .WithParameter(new NamedParameter("slidingExpiration", TimeSpan.FromSeconds(14400)))
                .WithParameter(new NamedParameter("absoluteExpirationPeriod", TimeSpan.FromSeconds(86400)))
                .WithParameter(new NamedParameter("cacheSuppression", cacheSuppression))
                .As<IPersonUniqueIdToUsiCache>().SingleInstance();
        }
    }
}