// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Security.Authorization.Repositories
{
    /// <summary>
    /// Defines methods for obtaining SQL and HQL filter text for filters defined on entities.
    /// </summary>
    public interface INHibernateFilterTextProvider
    {
        bool TryGetSqlFilterText(string entityName, string filterName, out string filterText);

        bool TryGetSqlFilterText(Type entityType, string filterName, out string filterText);

        bool TryGetHqlFilterText(string entityName, string filterName, out string filterText);

        bool TryGetHqlFilterText(Type entityType, string filterName, out string filterText);
    }
}
