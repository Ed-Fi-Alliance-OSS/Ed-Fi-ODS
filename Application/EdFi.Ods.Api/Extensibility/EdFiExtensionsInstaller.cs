// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Extensibility
{
    public class EdFiExtensionsInstaller : IWindsorInstaller
    {
        private const string ExcludedExtensionSourcesKey = "ExcludedExtensionSources";
        private readonly IEntityExtensionRegistrar _registrar;

        public EdFiExtensionsInstaller(IAssembliesProvider assembliesProvider, IEntityExtensionRegistrar registrar)
        {
            _registrar = registrar;

            Assemblies = assembliesProvider.GetAssemblies();
        }

        protected IList<Assembly> Assemblies { get; }

        public virtual void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register extension assemblies based on naming convention
            var extensionAssemblies = Assemblies.Where(ExtensionsConventions.IsExtensionAssembly)
                                                .ToList();

            // Exclude any extension assemblies specified by configuration
            var excludedExtensionSourcesValue = container.Resolve<IConfigValueProvider>()
                                                         .GetValue(ExcludedExtensionSourcesKey);

            if (!string.IsNullOrWhiteSpace(excludedExtensionSourcesValue))
            {
                extensionAssemblies = extensionAssemblies
                                     .Where(
                                          a => !excludedExtensionSourcesValue.Split(',')
                                                                             .Contains(
                                                                                  ExtensionsConventions.GetProperCaseNameFromAssemblyName(
                                                                                      a.GetName()
                                                                                       .Name)))
                                     .ToList();
            }

            // Ensure all the domain model definitions are registered before handling any other extension concerns
            extensionAssemblies.ForEach(a => RegisterIDomainModelDefinitionsProvider(a, container));

            extensionAssemblies.ForEach(
                a =>
                {
                    RegisterExtensions(a, _registrar, container);
                    RegisterExtensionNHibernateConfigurationProvider(a, container);
                    RegisterControllers(a, container);
                }
            );
        }

        private void RegisterExtensions(Assembly assembly, IEntityExtensionRegistrar registrar, IWindsorContainer container)
        {
            string extensionAssemblyName = assembly.GetName()
                                                   .Name;

            var extensionSchemaProperCaseName = ExtensionsConventions.GetProperCaseNameFromAssemblyName(extensionAssemblyName);

            var domainModel = container.Resolve<IDomainModelProvider>()
                                       .GetDomainModel();

            string schemaPhysicalName = domainModel.SchemaNameMapProvider
                                                   .GetSchemaMapByProperCaseName(extensionSchemaProperCaseName)
                                                   .PhysicalName;

            var extensionsByStandardEntity = domainModel
                                            .Entities
                                            .Where(e => e.Schema.Equals(schemaPhysicalName) && (e.IsEntityExtension || e.IsAggregateExtensionTopLevelEntity))
                                            .Select(
                                                 e => new
                                                      {
                                                          Parent = e.Parent, Entity = e, IsAggregateExtension = e.IsAggregateExtension,
                                                          IsEntityExtension = e.IsEntityExtension
                                                      })
                                            .GroupBy(x => x.Parent, x => x)
                                            .ToList();

            var aggregateExtensionEntities = extensionsByStandardEntity
                                            .SelectMany(x => x)
                                            .Where(x => x.IsAggregateExtension)
                                            .Select(x => x.Entity);

            var entityExtensions = extensionsByStandardEntity
                .SelectMany(x => x)
                .Where(x => x.IsEntityExtension)
                .Select(
                    x => new
                    {
                        Entity = x.Entity,
                        IsRequired = x.Entity.ParentAssociation.Association.Cardinality == Cardinality.OneToOneExtension
                    });

            // Register aggregate extensions
            foreach (var aggregateExtensionEntity in aggregateExtensionEntities)
            {
                string standardTypeName = aggregateExtensionEntity.Parent.EntityTypeFullName(EdFiConventions.ProperCaseName);
                var standardType = Type.GetType($"{standardTypeName}, {Namespaces.Standard.BaseNamespace}");

                registrar.RegisterAggregateExtensionEntity(standardType, aggregateExtensionEntity);
            }

            // Register explicit entity extensions
            foreach (var entityExtension in entityExtensions)
            {
                string standardTypeName = entityExtension.Entity.EdFiStandardEntity.EntityTypeFullName(EdFiConventions.ProperCaseName);
                var standardType = Type.GetType($"{standardTypeName}, {Namespaces.Standard.BaseNamespace}");

                string extensionTypeName = entityExtension.Entity.EntityTypeFullName(extensionSchemaProperCaseName);
                var extensionType = Type.GetType($"{extensionTypeName}, {extensionAssemblyName}");

                registrar.RegisterEntityExtensionType(standardType, extensionSchemaProperCaseName, extensionType, entityExtension.IsRequired);
            }

            // Register implicit entity extensions
            // Filter down to just the standard entities that have aggregate extensions, but no entity extensions (need implicit extension classes registered)
            var implicitlyExtendedEntities = extensionsByStandardEntity
               .Where(p => p.Any(x => x.IsAggregateExtension) && !p.Any(x => x.IsEntityExtension));

            foreach (var implicitlyExtendedEntity in implicitlyExtendedEntities)
            {
                string standardTypeName = implicitlyExtendedEntity.Key.EntityTypeFullName(EdFiConventions.ProperCaseName);
                var standardType = Type.GetType($"{standardTypeName}, {Namespaces.Standard.BaseNamespace}");

                string extensionClassAssemblyQualifiedName =
                    ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(standardType, extensionSchemaProperCaseName);

                var extensionType = Type.GetType(extensionClassAssemblyQualifiedName);

                registrar.RegisterEntityExtensionType(standardType, extensionSchemaProperCaseName, extensionType, isRequired: true);
            }
        }

        protected virtual void RegisterExtensionNHibernateConfigurationProvider(Assembly assembly, IWindsorContainer container)
        {
            var assemblyName = assembly.GetName()
                                       .Name;

            // to avoid collisions between assemblies we need to mark them as named in the container
            container.Register(
                Component.For<IExtensionNHibernateConfigurationProvider>()
                         .ImplementedBy<ExtensionNHibernateConfigurationProvider>()
                         .DependsOn(Dependency.OnValue("assemblyName", assemblyName))
                         .Named(typeof(ExtensionNHibernateConfigurationProvider).FullName + "_" + assemblyName));
        }

        protected virtual void RegisterControllers(Assembly assembly, IWindsorContainer container)
        {
            // Controllers
            // These are api controllers so they need to be scoped to fit the Windsor integration for resolving dependencies
            container.Register(
                Classes.FromAssembly(assembly)
                       .BasedOn<ApiController>()
                       .LifestyleScoped());
        }

        private void RegisterIDomainModelDefinitionsProvider(Assembly assembly, IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IDomainModelDefinitionsProvider>()
                   .ImplementedBy<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                   .Named($"{assembly.FullName}.{typeof(DomainModelDefinitionsJsonEmbeddedResourceProvider).Name}")
                   .DependsOn(Dependency.OnValue("sourceAssembly", assembly)));
        }
    }
}
