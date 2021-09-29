// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Generator.Database.NamingConventions;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesQueryFactory : IKeyChangesQueryFactory
    {
        private readonly IDatabaseNamingConvention _namingConvention;

        private readonly ConcurrentDictionary<FullName, Query> _templateQueryByResourceName = new ConcurrentDictionary<FullName, Query>();

        public KeyChangesQueryFactory(IDatabaseNamingConvention namingConvention)
        {
            _namingConvention = namingConvention;
        }

        public Query CreateMainQuery(Resource resource)
        {
            // Optimize by caching the constructed query
            var templateQuery = _templateQueryByResourceName.GetOrAdd(resource.FullName, fn => CreateTemplateQuery(resource));

            // Copy the query before returning it (to preserve original)
            return templateQuery.Clone();
        }

        private Query CreateTemplateQuery(Resource resource)
        {
            /*
            var changeWindow = new Query("tracked_changes_edfi.studentschoolassociation AS c")
                .Select("c.id")
                .SelectRaw("MIN(c.ChangeVersion) as initialchangeversion")
                .SelectRaw("MAX(c.ChangeVersion) as finalchangeversion")
                .GroupBy("c.id");

            var query = new Query("changewindow as cw")
                .With("changewindow", changeWindow)
                .Join("tracked_changes_edfi.studentschoolassociation as c_old", 
                    j => j.On("cw.id", "c_old.id")
                            .On("cw.initialchangeversion", "c_old.changeversion"))
                .Join("tracked_changes_edfi.studentschoolassociation as c_new", 
                    j => j.On("cw.id", "c_new.id")
                            .On("cw.finalchangeversion", "c_new.changeversion"))
                .Select("cw.id", "cw.finalchangeversion as changeversion",
                    "c_old.oldentrydate AS oldentrydate", "c_new.newentrydate AS newentrydate",
                    "c_old.oldschoolid AS oldschoolid", "c_new.newschoolid AS newschoolid",        
                    "c_old.oldstudentuniqueid AS oldstudentuniqueid", "c_new.newstudentuniqueid AS newstudentuniqueid"
                    )
                .OrderBy("cw.finalchangeversion")
                .Skip(0)
                .Limit(25)
             */

            // Derive column names
            string idColumnFqn = $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Id")}";
            var changeVersionColumnFqn = $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}";
            string initialChangeVersionColumnName = _namingConvention.ColumnName("InitialChangeVersion");
            string finalChangeVersionColumnName = _namingConvention.ColumnName("FinalChangeVersion");

            var entity = resource.Entity;

            // Build the CTE query
            var changeWindowVersionsCteQuery = QueryFactoryHelper.CreateBaseTrackedChangesQuery(_namingConvention, entity)
                .Select(idColumnFqn)
                .SelectRaw( $"MIN({changeVersionColumnFqn}) AS {initialChangeVersionColumnName}")
                .SelectRaw( $"MAX({changeVersionColumnFqn}) AS {finalChangeVersionColumnName}")
                .GroupBy(idColumnFqn);

            QueryFactoryHelper.ApplyDiscriminatorCriteriaForDerivedEntities(
                changeWindowVersionsCteQuery,
                entity,
                _namingConvention);

            // Apply criteria for only including key changes
            var firstIdentifierProperty = (entity.IsDerived ? entity.BaseEntity : entity)
                .Identifier.Properties.First();

            string columnName = _namingConvention.ColumnName(
                $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{firstIdentifierProperty.PropertyName}");

            changeWindowVersionsCteQuery.WhereNotNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{columnName}");

            return changeWindowVersionsCteQuery;
        }
    }
}
