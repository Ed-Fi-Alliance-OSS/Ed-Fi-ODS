﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Extensibility;
using EdFi.Ods.Api.NHibernate.Architecture.Criteria;
using EdFi.Ods.Api.NHibernate.Filtering;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Utils.Extensions;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    public class NHibernateConfigurator : INHibernateConfigurator
    {
        private const string EntityExtensionMemberName = "Extensions";
        private const string AggregateExtensionMemberName = "AggregateExtensions";

        private readonly IDictionary<string, HbmBag[]> _aggregateExtensionHbmBagsByEntityName;
        private readonly INHibernateFilterConfigurator[] _authorizationStrategyConfigurators;
        private readonly INHibernateBeforeBindMappingActivity[] _beforeBindMappingActivities;
        private readonly INHibernateConfigurationActivity[] _configurationActivities;
        private readonly IDictionary<string, HbmBag[]> _entityExtensionHbmBagsByEntityName;
        private readonly IExtensionNHibernateConfigurationProvider[] _extensionConfigurationProviders;
        private readonly IDictionary<string, HbmSubclass[]> _extensionDerivedEntityByEntityName;
        private readonly IDictionary<string, HbmJoinedSubclass[]> _extensionDescriptorByEntityName;
        private readonly IFilterCriteriaApplicatorProvider _filterCriteriaApplicatorProvider;
        private readonly IOrmMappingFileDataProvider _ormMappingFileDataProvider;

        public NHibernateConfigurator(IExtensionNHibernateConfigurationProvider[] extensionConfigurationProviders,
            INHibernateBeforeBindMappingActivity[] beforeBindMappingActivities,
            INHibernateFilterConfigurator[] authorizationStrategyConfigurators,
            IFilterCriteriaApplicatorProvider filterCriteriaApplicatorProvider,
            INHibernateConfigurationActivity[] configurationActivities,
            IOrmMappingFileDataProvider ormMappingFileDataProvider)
        {
            _ormMappingFileDataProvider = Preconditions.ThrowIfNull(
                ormMappingFileDataProvider, nameof(ormMappingFileDataProvider));

            _extensionConfigurationProviders = Preconditions.ThrowIfNull(
                extensionConfigurationProviders, nameof(extensionConfigurationProviders));

            _beforeBindMappingActivities = Preconditions.ThrowIfNull(
                beforeBindMappingActivities, nameof(beforeBindMappingActivities));

            _authorizationStrategyConfigurators = Preconditions.ThrowIfNull(
                authorizationStrategyConfigurators, nameof(authorizationStrategyConfigurators));

            _filterCriteriaApplicatorProvider = Preconditions.ThrowIfNull(
                filterCriteriaApplicatorProvider, nameof(filterCriteriaApplicatorProvider));

            _configurationActivities = Preconditions.ThrowIfNull(configurationActivities, nameof(configurationActivities));

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

        public Configuration Configure()
        {
            var configuration = new Configuration();

            // Add the configuration to the container
            configuration.BeforeBindMapping += Configuration_BeforeBindMapping;

            // Get all the filter definitions from all the configurators
            var allFilterDetails = _authorizationStrategyConfigurators
                .SelectMany(c => c.GetFilters())
                .Distinct()
                .ToList();

            // Group the filters by name first (there can only be 1 "default" filter, but flexibility 
            // to apply same filter name with same parameters to different entities should be supported
            // (and is in fact supported below when filters are applied to individual entity mappings)
            var allFilterDetailsGroupedByName = allFilterDetails
                .GroupBy(f => f.FilterDefinition.FilterName)
                .Select(g => g);

            // Add all the filter definitions to the NHibernate configuration
            foreach (var filterDetails in allFilterDetailsGroupedByName)
            {
                configuration.AddFilterDefinition(
                    filterDetails.First()
                        .FilterDefinition);
            }

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
                    _filterCriteriaApplicatorProvider.AddCriteriaApplicator(
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

            configuration.AddCreateDateHooks();

            return configuration;
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
