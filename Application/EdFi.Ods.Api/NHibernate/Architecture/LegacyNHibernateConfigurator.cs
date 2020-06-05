// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.Activities;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.SqlServer;
using EdFi.Ods.Api.Common.Infrastructure.Configuration;
using EdFi.Ods.Api.Common.Infrastructure.ConnectionProviders;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Api.Common.Infrastructure.Filtering;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Common.Providers.Criteria;
using EdFi.Ods.Common;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping;
using Component = Castle.MicroKernel.Registration.Component;
using Environment = NHibernate.Cfg.Environment;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    [Obsolete("Replaced with NHibernateConfigurator.cs to be used with Startup.cs")]
    public class LegacyNHibernateConfigurator
    {
        private const string EntityExtensionMemberName = "Extensions";
        private const string AggregateExtensionMemberName = "AggregateExtensions";

        private IDictionary<string, HbmBag[]> _aggregateExtensionHbmBagsByEntityName;
        private INHibernateBeforeBindMappingActivity[] _beforeBindMappingActivities;
        private IDictionary<string, HbmBag[]> _entityExtensionHbmBagsByEntityName;
        private IDictionary<string, HbmSubclass[]> _extensionDerivedEntityByEntityName;
        private IDictionary<string, HbmJoinedSubclass[]> _extensionDescriptorByEntityName;

        public Configuration Configure(IWindsorContainer container)
        {
            //Resolve all extensions to include in core mapping
            var extensionConfigurationProviders = Enumerable.ToList(container.ResolveAll<IExtensionNHibernateConfigurationProvider>());

            _entityExtensionHbmBagsByEntityName = extensionConfigurationProviders
                .SelectMany(x => x.EntityExtensionHbmBagByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.Select(y => y.Value)
                        .ToArray());

            _aggregateExtensionHbmBagsByEntityName = extensionConfigurationProviders
                .SelectMany(x => x.AggregateExtensionHbmBagsByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.SelectMany(y => y.Value)
                        .ToArray());

            _extensionDescriptorByEntityName = extensionConfigurationProviders
                .SelectMany(x => x.NonDiscriminatorBasedHbmJoinedSubclassesByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.SelectMany(y => y.Value)
                        .ToArray());

            _extensionDerivedEntityByEntityName = extensionConfigurationProviders
                .SelectMany(x => x.DiscriminatorBasedHbmSubclassesByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.SelectMany(y => y.Value).ToArray());

            _beforeBindMappingActivities = container.ResolveAll<INHibernateBeforeBindMappingActivity>();

            // Start the NHibernate configuration
            var configuration = new Configuration();

            // Add the configuration to the container
            container.Register(
                Component.For<Configuration>()
                    .Instance(configuration));

            configuration.BeforeBindMapping += Configuration_BeforeBindMapping;

            // Get all the authorization strategy configurators
            var authorizationStrategyConfigurators = container.ResolveAll<INHibernateFilterConfigurator>();

            // Get all the filter definitions from all the configurators
            var allFilterDetails =
                (from c in authorizationStrategyConfigurators
                    from f in c.GetFilters()
                    select f)
                .Distinct()
                .ToList();

            // Group the filters by name first (there can only be 1 "default" filter, but flexibility 
            // to apply same filter name with same parameters to different entities should be supported
            // (and is in fact supported below when filters are applied to individual entity mappings)
            var allFilterDetailsGroupedByName =
                from f in allFilterDetails
                group f by f.FilterDefinition.FilterName
                into g
                select g;

            // Add all the filter definitions to the NHibernate configuration
            foreach (var filterDetails in allFilterDetailsGroupedByName)
            {
                configuration.AddFilterDefinition(
                    filterDetails.First()
                        .FilterDefinition);
            }

            // Configure the mappings
            var ormMappingFileData = container.Resolve<IOrmMappingFileDataProvider>().OrmMappingFileData();
            configuration.AddResources(ormMappingFileData.MappingFileFullNames, ormMappingFileData.Assembly);

            //Resolve all extension assemblies and add to NHibernate configuration
            extensionConfigurationProviders
                .ForEach(
                    e => configuration.AddResources(e.OrmMappingFileData.MappingFileFullNames, e.OrmMappingFileData.Assembly));

            var filterCriteriaApplicatorProvider = container.Resolve<IFilterCriteriaApplicatorProvider>();

            // Invoke configuration activities
            var configurationActivities = container.ResolveAll<INHibernateConfigurationActivity>();

            foreach (var configurationActivity in configurationActivities)
            {
                configurationActivity.Execute(configuration);
            }

            // Apply the previously defined filters to the mappings
            foreach (var mapping in configuration.ClassMappings)
            {
                Type entityType = mapping.MappedClass;
                var properties = entityType.GetProperties();

                var applicableFilters = allFilterDetails
                    .Where(filterDetails => filterDetails.ShouldApply(entityType, properties))
                    .ToList();

                foreach (var filter in applicableFilters)
                {
                    var filterDefinition = filter.FilterDefinition;

                    // Save the filter criteria applicators
                    filterCriteriaApplicatorProvider.AddCriteriaApplicator(
                        filterDefinition.FilterName,
                        entityType,
                        filter.CriteriaApplicator);

                    mapping.AddFilter(
                        filterDefinition.FilterName,
                        filterDefinition.DefaultFilterCondition);

                    var metaAttribute = new MetaAttribute(filterDefinition.FilterName);
                    metaAttribute.AddValue(filter.HqlConditionFormatString);

                    mapping.MetaAttributes.Add(
                        "HqlFilter_" + filterDefinition.FilterName,
                        metaAttribute);
                }
            }

            // NHibernate Dependency Injection
            Environment.ObjectsFactory = new WindsorObjectsFactory(container);

            configuration.AddCreateDateHooks();

            // Build and register the session factory with the container
            container.Register(
                Component
                    .For<ISessionFactory>()
                    .UsingFactoryMethod(configuration.BuildSessionFactory)
                    .LifeStyle.Singleton);

            container.Register(
                Component
                    .For<Func<IStatelessSession>>()
                    .UsingFactoryMethod<Func<IStatelessSession>>(
                        kernel => () => kernel.Resolve<ISessionFactory>().OpenStatelessSession())
                    .LifestyleSingleton()); // The function is a singleton, not the session

            container.Register(
                Component
                    .For<EdFiOdsConnectionProvider>()
                    .DependsOn(
                        Dependency
                            .OnComponent(
                                typeof(IDatabaseConnectionStringProvider),
                                typeof(IDatabaseConnectionStringProvider).GetServiceNameWithSuffix(
                                    Databases.Ods.ToString()))));

            // Register the SQL Server version of the parameter list setter
            // This is registered with the API by the SqlServerSupportConditionalFeature
            // in the non-legacy code.
            container.Register(
                Component
                    .For<IParameterListSetter>()
                    .ImplementedBy<SqlServerTableValuedParameterListSetter>());
            
            return configuration;
        }

        private void Configuration_BeforeBindMapping(object sender, BindMappingEventArgs e)
        {
            // When core mapping file loaded, attach any extensions to their core entity counterpart
            if (IsEdFiStandardMappingEvent(e))
            {
                var classMappingByEntityName = e.Mapping.Items.OfType<HbmClass>()
                    .ToDictionary(
                        x => Enumerable.Last<string>(x.Name.Split('.')),
                        x => x);

                var joinedSubclassMappingByEntityName = e.Mapping.Items.OfType<HbmClass>()
                    .SelectMany(i => i.JoinedSubclasses)
                    .ToDictionary(
                        x => Enumerable.Last<string>(x.Name.Split('.')),
                        x => x);

                var subclassJoinMappingByEntityName = e.Mapping.Items.OfType<HbmClass>()
                    .SelectMany(i => i.Subclasses)
                    .Where(sc => sc.Joins.Count() == 1)
                    .ToDictionary(
                        x => Enumerable.Last<string>(x.Name.Split('.')),
                        x => x.Joins.Single());

                MapExtensionsToCoreEntity(
                    classMappingByEntityName, joinedSubclassMappingByEntityName, subclassJoinMappingByEntityName);

                MapJoinedSubclassesToCoreEntity(
                    classMappingByEntityName, joinedSubclassMappingByEntityName, subclassJoinMappingByEntityName);

                MapDescriptorToCoreDescriptorEntity(classMappingByEntityName);

                MapDerivedEntityToCoreEntity(classMappingByEntityName);
            }

            foreach (var beforeBindMappingActivity in _beforeBindMappingActivities)
            {
                beforeBindMappingActivity.Execute(sender, e);
            }
        }

        private void MapDerivedEntityToCoreEntity(Dictionary<string, HbmClass> classMappingByEntityName)
        {
            foreach (string entityName in _extensionDerivedEntityByEntityName.Keys)
            {
                HbmClass classMapping;

                if (!classMappingByEntityName.TryGetValue(entityName, out classMapping))
                {
                    throw new MappingException(
                        $"The subclass extension to entity '{entityName}' could not be applied because the class mapping could not be found.");
                }

                var hbmSubclasses = Enumerable.ToArray<object>(_extensionDerivedEntityByEntityName[entityName].Select(x => (object) x));

                classMapping.Items1 = (classMapping.Items1 ?? new object[0]).Concat(hbmSubclasses).ToArray();
            }
        }

        private void MapDescriptorToCoreDescriptorEntity(Dictionary<string, HbmClass> classMappingByEntityName)
        {
            // foreach entity name, look in core mapping file (e.mapping) for core entity mapping and if found
            // concat new extension HbmJoinedSubclass to current set of Ed-Fi entity HbmJoinedSubclasses.
            foreach (string entityName in _extensionDescriptorByEntityName.Keys)
            {
                HbmClass classMapping;

                if (!classMappingByEntityName.TryGetValue(entityName, out classMapping))
                {
                    throw new MappingException(
                        $"The subclass extension to entity '{entityName}' could not be applied because the class mapping could not be found.");
                }

                var hbmJoinedSubclasses = Enumerable.ToArray<object>(
                        _extensionDescriptorByEntityName[entityName]
                            .Select(x => (object) x));

                classMapping.Items1 = (classMapping.Items1 ?? new object[0]).Concat(hbmJoinedSubclasses)
                    .ToArray();
            }
        }

        private void MapJoinedSubclassesToCoreEntity(Dictionary<string, HbmClass> classMappingByEntityName,
            Dictionary<string, HbmJoinedSubclass> joinedSubclassMappingByEntityName,
            Dictionary<string, HbmJoin> subclassJoinMappingByEntityName)
        {
            // foreach entity name, look in core mapping file (e.mapping) for core entity mapping and if found
            // concat new extension HbmDynamicComponent to current set of items.
            foreach (string entityName in _aggregateExtensionHbmBagsByEntityName.Keys)
            {
                HbmClass classMapping;
                HbmJoinedSubclass joinedSubclassMapping = null;
                HbmJoin subclassJoinMapping = null;

                if (!classMappingByEntityName.TryGetValue(entityName, out classMapping)
                    && !joinedSubclassMappingByEntityName.TryGetValue(entityName, out joinedSubclassMapping)
                    && !subclassJoinMappingByEntityName.TryGetValue(entityName, out subclassJoinMapping))
                {
                    throw new MappingException(
                        $"The aggregate extensions to entity '{entityName}' could not be applied because the class mapping could not be found.");
                }

                var extensionComponent = new HbmDynamicComponent
                {
                    name = AggregateExtensionMemberName,
                    Items = Enumerable.ToArray<object>(
                            _aggregateExtensionHbmBagsByEntityName[entityName]
                                .Select(x => (object) x))
                };

                if (classMapping != null)
                {
                    classMapping.Items = Enumerable.ToArray<object>(classMapping.Items.Concat(extensionComponent));
                }
                else if (joinedSubclassMapping != null)
                {
                    joinedSubclassMapping.Items = Enumerable.ToArray<object>(joinedSubclassMapping.Items.Concat(extensionComponent));
                }
                else
                {
                    subclassJoinMapping.Items = Enumerable.ToArray<object>(subclassJoinMapping.Items.Concat(extensionComponent));
                }
            }
        }

        private void MapExtensionsToCoreEntity(Dictionary<string, HbmClass> classMappingByEntityName,
            Dictionary<string, HbmJoinedSubclass> joinedSubclassMappingByEntityName,
            Dictionary<string, HbmJoin> subclassJoinMappingByEntityName)
        {
            // foreach entity name, look in core mapping file (e.mapping) for core entity mapping and if found
            // concat new extension HbmDynamicComponent to current set of items.
            foreach (string entityName in _entityExtensionHbmBagsByEntityName.Keys)
            {
                HbmClass classMapping;
                HbmJoinedSubclass joinedSubclassMapping = null;
                HbmJoin subclassJoinMapping = null;

                if (!classMappingByEntityName.TryGetValue(entityName, out classMapping)
                    && !joinedSubclassMappingByEntityName.TryGetValue(entityName, out joinedSubclassMapping)
                    && !subclassJoinMappingByEntityName.TryGetValue(entityName, out subclassJoinMapping))
                {
                    throw new MappingException(
                        $"The entity extension to entity '{entityName}' could not be applied because the class mapping could not be found.");
                }

                var extensionComponent = new HbmDynamicComponent
                {
                    name = EntityExtensionMemberName,
                    Items = Enumerable.ToArray<object>(
                            _entityExtensionHbmBagsByEntityName[entityName]
                                .Select(x => (object) x))
                };

                if (classMapping != null)
                {
                    classMapping.Items = Enumerable.ToArray<object>(classMapping.Items.Concat(extensionComponent));
                }
                else if (joinedSubclassMapping != null)
                {
                    joinedSubclassMapping.Items = Enumerable.ToArray<object>(joinedSubclassMapping.Items.Concat(extensionComponent));
                }
                else
                {
                    subclassJoinMapping.Items = Enumerable.ToArray<object>(subclassJoinMapping.Items.Concat(extensionComponent));
                }
            }
        }

        private static bool IsEdFiStandardMappingEvent(BindMappingEventArgs e)
        {
            return e.Mapping.@namespace.Equals(Namespaces.Entities.NHibernate.BaseNamespace)
                   && e.Mapping.assembly.Equals(Namespaces.Standard.BaseNamespace);
        }
    }
}
