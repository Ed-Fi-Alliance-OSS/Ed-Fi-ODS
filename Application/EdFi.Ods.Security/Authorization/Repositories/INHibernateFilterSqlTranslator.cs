// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Security.Authorization.Repositories
{
    /// <summary>
    /// Defines a method for translating the NHibernate filter definition (expressed in SQL) to
    /// HQL for incorporation into the query.
    /// </summary>
    /// <remarks>This component is necessary because NHibernate filters only seem to work on 
    /// the top level entities.  Once a join occurs to another entity, filters are not applied
    /// and must be incorporated explicitly into the queries.</remarks>
    public interface INHibernateFilterSqlTranslator
    {
        string TranslateToHql(string filterSql);
    }
}
