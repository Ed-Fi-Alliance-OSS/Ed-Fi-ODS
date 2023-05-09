// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Providers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class NHibernateConfigurator : INHibernateConfigurator
    {
        private const string EntityExtensionMemberName = "Extensions";
        private const string AggregateExtensionMemberName = "AggregateExtensions";

        private readonly IDictionary<string, HbmBag[]> _aggregateExtensionHbmBagsByEntityName;
        private readonly IAuthorizationFilterDefinitionsFactory[] _authorizationStrategyConfigurators;
        private readonly INHibernateBeforeBindMappingActivity[] _beforeBindMappingActivities;
        private readonly INHibernateConfigurationActivity[] _configurationActivities;
        private readonly IDictionary<string, HbmBag[]> _entityExtensionHbmBagsByEntityName;
        private readonly IExtensionNHibernateConfigurationProvider[] _extensionConfigurationProviders;
        private readonly IDictionary<string, HbmSubclass[]> _extensionDerivedEntityByEntityName;
        private readonly IDictionary<string, HbmJoinedSubclass[]> _extensionDescriptorByEntityName;
        private readonly IOrmMappingFileDataProvider _ormMappingFileDataProvider;

        public NHibernateConfigurator(IEnumerable<IExtensionNHibernateConfigurationProvider> extensionConfigurationProviders,
            IEnumerable<INHibernateBeforeBindMappingActivity> beforeBindMappingActivities,
            IEnumerable<IAuthorizationFilterDefinitionsFactory> authorizationStrategyConfigurators,
            IEnumerable<INHibernateConfigurationActivity> configurationActivities,
            IOrmMappingFileDataProvider ormMappingFileDataProvider,
            IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _ormMappingFileDataProvider = Preconditions.ThrowIfNull(
                ormMappingFileDataProvider, nameof(ormMappingFileDataProvider));

            _extensionConfigurationProviders = Preconditions.ThrowIfNull(
                extensionConfigurationProviders.ToArray(), nameof(extensionConfigurationProviders));

            _beforeBindMappingActivities = Preconditions.ThrowIfNull(
                beforeBindMappingActivities.ToArray(), nameof(beforeBindMappingActivities));

            _authorizationStrategyConfigurators = Preconditions.ThrowIfNull(
                authorizationStrategyConfigurators.ToArray(), nameof(authorizationStrategyConfigurators));

            _configurationActivities = Preconditions.ThrowIfNull(
                configurationActivities.ToArray(), nameof(configurationActivities));

            //Resolve all extensions to include in core mapping
            _entityExtensionHbmBagsByEntityName = _extensionConfigurationProviders
                .SelectMany(x => x.EntityExtensionHbmBagByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.Select(y => y.Value)
                        .ToArray());

            _aggregateExtensionHbmBagsByEntityName = _extensionConfigurationProviders
                .SelectMany(x => x.AggregateExtensionHbmBagsByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.SelectMany(y => y.Value)
                        .ToArray());

            _extensionDescriptorByEntityName = _extensionConfigurationProviders
                .SelectMany(x => x.NonDiscriminatorBasedHbmJoinedSubclassesByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.SelectMany(y => y.Value)
                        .ToArray());

            _extensionDerivedEntityByEntityName = _extensionConfigurationProviders
                .SelectMany(x => x.DiscriminatorBasedHbmSubclassesByEntityName)
                .GroupBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.SelectMany(y => y.Value).ToArray());
        }

        public NHibernate.Cfg.Configuration Configure()
        {
            SetAssemblyBinding();

            var configuration = new NHibernate.Cfg.Configuration();

            // NOTE: the NHibernate documentation states that this file would be automatically loaded, however in testings this was not the case.
            // The expectation is that this file will be in the binaries location.
            configuration.Configure(
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "hibernate.cfg.xml"));

            // Add the configuration to the container
            configuration.BeforeBindMapping += Configuration_BeforeBindMapping;

            // Configure the mappings
            var ormMappingFileData = _ormMappingFileDataProvider.OrmMappingFileData();
            configuration.AddResources(ormMappingFileData.MappingFileFullNames, ormMappingFileData.Assembly);

            //Resolve all extension assemblies and add to NHibernate configuration
            _extensionConfigurationProviders.ForEach(
                e => configuration.AddResources(e.OrmMappingFileData.MappingFileFullNames, e.OrmMappingFileData.Assembly));

            // Invoke configuration activities
            foreach (var configurationActivity in _configurationActivities)
            {
                configurationActivity.Execute(configuration);
            }

            configuration.AddCreateDateHooks();

            return configuration;

            void SetAssemblyBinding()
            {
                // NHibernate does not behave nicely with assemblies that are loaded from another folder.
                // By default NHibernate tries to load the assembly from the execution folder.
                // In our case we have pre loaded the assemblies into the domain, so we just need to tell NHibernate to pull the loaded
                // assembly. Setting the AssemblyResolve event fixes this. c.f. https://nhibernate.jira.com/browse/NH-2063 for further details.
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
                {
                    var assemblyName = e.Name.Split(",")[0];

                    return assemblies.FirstOrDefault(a => a.GetName().Name.EqualsIgnoreCase(assemblyName));
                };
            }
        }

        private void Configuration_BeforeBindMapping(object sender, BindMappingEventArgs e)
        {
            // When core mapping file loaded, attach any extensions to their core entity counterpart
            if (IsEdFiStandardMappingEvent())
            {
                var classMappingByEntityName = e.Mapping.Items.OfType<HbmClass>()
                    .ToDictionary(
                        x => x.Name.Split('.')
                            .Last(),
                        x => x);

                var joinedSubclassMappingByEntityName = e.Mapping.Items.OfType<HbmClass>()
                    .SelectMany(i => i.JoinedSubclasses)
                    .ToDictionary(
                        x => x.Name.Split('.')
                            .Last(),
                        x => x);

                var subclassJoinMappingByEntityName = e.Mapping.Items.OfType<HbmClass>()
                    .SelectMany(i => i.Subclasses)
                    .Where(sc => sc.Joins.Count() == 1)
                    .ToDictionary(
                        x => x.Name.Split('.')
                            .Last(),
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

            void MapDerivedEntityToCoreEntity(Dictionary<string, HbmClass> classMappingByEntityName)
            {
                foreach (string entityName in _extensionDerivedEntityByEntityName.Keys)
                {
                    if (!classMappingByEntityName.TryGetValue(entityName, out HbmClass classMapping))
                    {
                        throw new MappingException(
                            $"The subclass extension to entity '{entityName}' could not be applied because the class mapping could not be found.");
                    }

                    var hbmSubclasses = _extensionDerivedEntityByEntityName[entityName].Select(x => (object) x).ToArray();

                    classMapping.Items1 = (classMapping.Items1 ?? new object[0]).Concat(hbmSubclasses).ToArray();
                }
            }

            void MapDescriptorToCoreDescriptorEntity(Dictionary<string, HbmClass> classMappingByEntityName)
            {
                // foreach entity name, look in core mapping file (e.mapping) for core entity mapping and if found
                // concat new extension HbmJoinedSubclass to current set of Ed-Fi entity HbmJoinedSubclasses.
                foreach (string entityName in _extensionDescriptorByEntityName.Keys)
                {
                    if (!classMappingByEntityName.TryGetValue(entityName, out HbmClass classMapping))
                    {
                        throw new MappingException(
                            $"The subclass extension to entity '{entityName}' could not be applied because the class mapping could not be found.");
                    }

                    var hbmJoinedSubclasses = _extensionDescriptorByEntityName[entityName]
                        .Select(x => (object) x)
                        .ToArray();

                    classMapping.Items1 = (classMapping.Items1 ?? new object[0]).Concat(hbmJoinedSubclasses)
                        .ToArray();
                }
            }

            void MapJoinedSubclassesToCoreEntity(Dictionary<string, HbmClass> classMappingByEntityName,
                Dictionary<string, HbmJoinedSubclass> joinedSubclassMappingByEntityName,
                Dictionary<string, HbmJoin> subclassJoinMappingByEntityName)
            {
                // foreach entity name, look in core mapping file (e.mapping) for core entity mapping and if found
                // concat new extension HbmDynamicComponent to current set of items.
                foreach (string entityName in _aggregateExtensionHbmBagsByEntityName.Keys)
                {
                    HbmJoinedSubclass joinedSubclassMapping = null;
                    HbmJoin subclassJoinMapping = null;

                    if (!classMappingByEntityName.TryGetValue(entityName, out HbmClass classMapping)
                        && !joinedSubclassMappingByEntityName.TryGetValue(entityName, out joinedSubclassMapping)
                        && !subclassJoinMappingByEntityName.TryGetValue(entityName, out subclassJoinMapping))
                    {
                        throw new MappingException(
                            $"The aggregate extensions to entity '{entityName}' could not be applied because the class mapping could not be found.");
                    }

                    var extensionComponent = new HbmDynamicComponent
                    {
                        name = AggregateExtensionMemberName,
                        Items = _aggregateExtensionHbmBagsByEntityName[entityName]
                            .Select(x => (object) x)
                            .ToArray()
                    };

                    if (classMapping != null)
                    {
                        classMapping.Items = classMapping.Items.Concat(extensionComponent)
                            .ToArray();
                    }
                    else if (joinedSubclassMapping != null)
                    {
                        joinedSubclassMapping.Items = joinedSubclassMapping.Items.Concat(extensionComponent)
                            .ToArray();
                    }
                    else if (subclassJoinMapping != null)
                    {
                        subclassJoinMapping.Items = subclassJoinMapping.Items.Concat(extensionComponent)
                            .ToArray();
                    }
                }
            }

            void MapExtensionsToCoreEntity(Dictionary<string, HbmClass> classMappingByEntityName,
                Dictionary<string, HbmJoinedSubclass> joinedSubclassMappingByEntityName,
                Dictionary<string, HbmJoin> subclassJoinMappingByEntityName)
            {
                // foreach entity name, look in core mapping file (e.mapping) for core entity mapping and if found
                // concat new extension HbmDynamicComponent to current set of items.
                foreach (string entityName in _entityExtensionHbmBagsByEntityName.Keys)
                {
                    HbmJoinedSubclass joinedSubclassMapping = null;
                    HbmJoin subclassJoinMapping = null;

                    if (!classMappingByEntityName.TryGetValue(entityName, out HbmClass classMapping)
                        && !joinedSubclassMappingByEntityName.TryGetValue(entityName, out joinedSubclassMapping)
                        && !subclassJoinMappingByEntityName.TryGetValue(entityName, out subclassJoinMapping))
                    {
                        throw new MappingException(
                            $"The entity extension to entity '{entityName}' could not be applied because the class mapping could not be found.");
                    }

                    var extensionComponent = new HbmDynamicComponent
                    {
                        name = EntityExtensionMemberName,
                        Items = _entityExtensionHbmBagsByEntityName[entityName]
                            .Select(x => (object) x)
                            .ToArray()
                    };

                    if (classMapping != null)
                    {
                        classMapping.Items = classMapping.Items.Concat(extensionComponent)
                            .ToArray();
                    }
                    else if (joinedSubclassMapping != null)
                    {
                        joinedSubclassMapping.Items = joinedSubclassMapping.Items.Concat(extensionComponent)
                            .ToArray();
                    }
                    else if (subclassJoinMapping != null)
                    {
                        subclassJoinMapping.Items = subclassJoinMapping.Items.Concat(extensionComponent)
                            .ToArray();
                    }
                }
            }

            bool IsEdFiStandardMappingEvent()
            {
                return e.Mapping.@namespace.Equals(Namespaces.Entities.NHibernate.BaseNamespace)
                       && e.Mapping.assembly.Equals(Namespaces.Standard.BaseNamespace);
            }
        }
    }
}
