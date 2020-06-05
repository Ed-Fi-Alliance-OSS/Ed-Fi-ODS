// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Features.Container.Modules
{
    public class EnabledExtensionModule : ConditionalModule
    {
        public EnabledExtensionModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(EnabledExtensionModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Extensions);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            var installedExtensionAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(
                    a => a.IsExtensionAssembly()
                         && !ApiSettings.ExcludedExtensions.Contains(
                             ExtensionsConventions.GetProperCaseNameFromAssemblyName(a.GetName().Name), StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            builder.RegisterType<EntityExtensionsFactory>().As<IEntityExtensionsFactory>().SingleInstance();

            builder.RegisterType<EntityExtensionRegistrar>()
                .WithParameter(new TypedParameter(typeof(IEnumerable<Assembly>), installedExtensionAssemblies))
                .As<IEntityExtensionRegistrar>()
                .SingleInstance();

            installedExtensionAssemblies.ForEach(
                assembly =>
                {
                    var assemblyName = assembly.GetName().Name;

                    builder.RegisterType<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                        .WithParameter("sourceAssembly", assembly)
                        .As<IDomainModelDefinitionsProvider>();

                    builder.RegisterType<ExtensionNHibernateConfigurationProvider>()
                        .WithParameter("assemblyName", assemblyName)
                        .As<IExtensionNHibernateConfigurationProvider>();
                });
        }
    }
}
#endif
