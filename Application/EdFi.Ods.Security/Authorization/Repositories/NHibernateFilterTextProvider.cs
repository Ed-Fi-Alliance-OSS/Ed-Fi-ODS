// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NHibernate.Cfg;
using NHibernate.Mapping;

namespace EdFi.Ods.Security.Authorization.Repositories
{
    /// <summary>
    /// Provides SQL and HQL filter text for filters defined on NHibernate entities.
    /// </summary>
    public class NHibernateFilterTextProvider : INHibernateFilterTextProvider
    {
        private readonly Configuration _configuration;

        public NHibernateFilterTextProvider(Configuration configuration)
        {
            _configuration = configuration;
        }

        public bool TryGetSqlFilterText(string entityName, string filterName, out string filterText)
        {
            var classMapping = _configuration.GetClassMapping(entityName);
            return classMapping.FilterMap.TryGetValue(filterName, out filterText);
        }

        public bool TryGetSqlFilterText(Type entityType, string filterName, out string filterText)
        {
            var classMapping = _configuration.GetClassMapping(entityType);
            return classMapping.FilterMap.TryGetValue(filterName, out filterText);
        }

        public bool TryGetHqlFilterText(string entityName, string filterName, out string filterText)
        {
            var classMapping = _configuration.GetClassMapping(entityName);
            return GetFilterTextWithAliasContext(classMapping, filterName, out filterText);
        }

        public bool TryGetHqlFilterText(Type entityType, string filterName, out string filterText)
        {
            var classMapping = _configuration.GetClassMapping(entityType);
            return GetFilterTextWithAliasContext(classMapping, filterName, out filterText);
        }

        private static bool GetFilterTextWithAliasContext(
            PersistentClass classMapping,
            string filterName,
            out string filterText)
        {
            filterText = null;

            var metaAttribute = classMapping.GetMetaAttribute("HqlFilter_" + filterName);

            if (metaAttribute == null)
            {
                return false;
            }

            filterText = metaAttribute.Value;
            return true;
        }
    }
}
