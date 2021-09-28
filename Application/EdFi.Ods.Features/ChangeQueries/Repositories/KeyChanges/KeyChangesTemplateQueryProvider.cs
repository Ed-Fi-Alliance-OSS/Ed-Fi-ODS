// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.NamingConventions;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesTemplateQueryProvider : TrackedChangesTemplateQueryProviderBase, IKeyChangesTemplateQueryProvider
    {
        private readonly IDatabaseNamingConvention _namingConvention;

        public KeyChangesTemplateQueryProvider(IDatabaseNamingConvention namingConvention)
            : base(namingConvention)
        {
            _namingConvention = namingConvention;
        }

        protected override void ApplyScenarioSpecificFilters(
            Query templateQuery,
            Entity entity,
            QueryProjection[] identifierProjections)
        {
            // Key changes-specific query filters
            var firstIdentifierProperty = (entity.IsDerived
                ? entity.BaseEntity
                : entity).Identifier.Properties.First();

            string columnName = _namingConvention.ColumnName(
                $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{firstIdentifierProperty.PropertyName}");

            templateQuery.WhereNotNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{columnName}");
        }
    }
}
