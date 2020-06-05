// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using Autofac;
using Autofac.Core;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Security.Authorization.Repositories;

namespace EdFi.Ods.Security.Container.Modules
{
    public class NHibernateFilterTextModule : ConditionalModule
    {
        public NHibernateFilterTextModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(NHibernateFilterTextModule)) { }

        public override bool IsSelected() => !ApiSettings.DisableSecurity;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
            => builder.RegisterType<NHibernateFilterTextProvider>()
                .WithParameter(new ResolvedParameter((p,c) => p.GetType() == typeof(NHibernate.Cfg.Configuration),
                    (p, c) => c.Resolve<NHibernate.Cfg.Configuration>()))
                .As<INHibernateFilterTextProvider>();
    }
}
#endif
