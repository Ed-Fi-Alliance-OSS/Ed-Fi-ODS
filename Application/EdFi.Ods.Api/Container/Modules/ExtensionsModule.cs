﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Common.Dependencies;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Api.Container.Modules
{
    public class ExtensionsModule : ConditionalModule
    {
        private readonly ApiSettings _apiSettings;

        public ExtensionsModule(IFeatureManager featureManager, ApiSettings apiSettings)
            : base(featureManager)
        {
            _apiSettings = apiSettings;
        }

        protected override bool IsSelected() => IsFeatureEnabled(ApiFeature.Extensions);

        protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            var installedExtensionAssemblies =
                AssemblyLoadContext.Default.Assemblies
                .Where(
                    a => a.IsExtensionAssembly()
                         && !_apiSettings.ExcludedExtensions.Contains(
                             ExtensionsConventions.GetProperCaseNameFromAssemblyName(a.GetName().Name), StringComparer.InvariantCultureIgnoreCase))
                .Distinct(new AssemblyComparer())
                .ToList();

            builder.RegisterType<EntityExtensionsFactory>()
                .As<IEntityExtensionsFactory>()
                .SingleInstance();

            builder.RegisterType<EntityExtensionContainingCollectionInitializer>()
                .As<IEntityExtensionContainingCollectionInitializer>()
                .SingleInstance();

            builder.RegisterType<EntityExtensionRegistrar>()
                .WithParameter(new TypedParameter(typeof(IEnumerable<Assembly>), installedExtensionAssemblies))
                .As<IEntityExtensionRegistrar>()
                .SingleInstance();

            // Set feature-specific static resolvers
            builder.RegisterBuildCallback(container =>
            {
                GeneratedArtifactStaticDependencies.Resolvers.Set(container.Resolve<IEntityExtensionsFactory>);
                GeneratedArtifactStaticDependencies.Resolvers.Set(container.Resolve<IEntityExtensionRegistrar>);
            });

            installedExtensionAssemblies.ForEach(
                assembly =>
                {
                    var assemblyName = assembly.GetName().Name;

                    builder.RegisterType<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                        .WithParameter("sourceAssembly", assembly)
                        .As<IDomainModelDefinitionsProvider>()
                        .SingleInstance();

                    builder.RegisterType<ExtensionNHibernateConfigurationProvider>()
                        .WithParameter("assemblyName", assemblyName)
                        .As<IExtensionNHibernateConfigurationProvider>()
                        .SingleInstance();

                    var relationshipContextDataProviderTypes = assembly.GetTypes()
                        .Where(
                            t => !t.IsAbstract && typeof(IRelationshipsAuthorizationContextDataProvider<>).IsAssignableFromGeneric(t))
                        .ToList();

                    foreach (var providerType in relationshipContextDataProviderTypes)
                    {
                        var partiallyClosedInterfaceType =
                            providerType.GetInterfaces()
                                .SingleOrDefault(i => i.Name == typeof(IRelationshipsAuthorizationContextDataProvider<>).Name);

                        var modelType = partiallyClosedInterfaceType?.GetGenericArguments()[0];

                        var closedInterfaceType =
                            typeof(IRelationshipsAuthorizationContextDataProvider<>)
                                .MakeGenericType(modelType);

                        builder.RegisterType(providerType).As(closedInterfaceType)
                            .SingleInstance();
                    }
                });
        }
    }

    internal class AssemblyComparer : IEqualityComparer<Assembly>
    {
        public bool Equals(Assembly x, Assembly y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (x is null || ReferenceEquals(y, null))
                return false;

            return x.FullName == y.FullName;
        }

        public int GetHashCode(Assembly assembly)
        {
            if (ReferenceEquals(assembly, null)) return 0;

            var fullNameHashCode = assembly.FullName == null
                ? 0
                : assembly.FullName.GetHashCode();
            return fullNameHashCode ^ 32;
        }
    }
}
