// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;
using NHibernate;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Common.Infrastructure.Interceptors
{
    public class EdFiOdsInterceptor : EmptyInterceptor
    {
        private readonly DatabaseEngine _databaseEngine;
        private bool _changeQueriesEnabled;
        private readonly IContextProvider<DataManagementResourceContext> _resourceContextProvider;

        private readonly ConcurrentDictionary<Entity, string> _updateTextByEntity = new();

        /// <summary>
        /// Gets the database schema name for the Change Queries supporting artifacts.
        /// </summary>
        private const string ChangesSchema = "changes";

        /// <summary>
        /// Gets the column name used for tracking changed records
        /// </summary>
        private const string ChangeVersionColumnName = "ChangeVersion";

        /// <summary>
        /// Gets the name used for the sequence.
        /// </summary>
        private const string ChangeVersionSequence = "ChangeVersionSequence";

        private readonly SqlString _changeVersionSetClause;

        public EdFiOdsInterceptor(
            DatabaseEngine databaseEngine,
            Dialect dialect,
            IContextProvider<DataManagementResourceContext> resourceContextProvider,
            IFeatureManager featureManager)
        {
            _databaseEngine = databaseEngine;
            _resourceContextProvider = resourceContextProvider;

            _changeVersionSetClause = new SqlString($"{ChangeVersionColumnName} = {dialect.GetNextSequenceValueString(ChangesSchema, ChangeVersionSequence)}, ");

            _changeQueriesEnabled = featureManager.IsFeatureEnabled(ApiFeature.ChangeQueries);
        }

        public override bool? IsTransient(object entity)
        {
            // New implementation -- avoid reflection if possible
            if (entity is DomainObjectBase domainObject)
            {
                return domainObject.CreateDate == default;
            }

            // Fallback legacy logic (kept intact here, just in case)
            var property = entity.GetType().GetProperty("CreateDate");

            if (property != null)
            {
                bool isTransient = Convert.ToDateTime(property.GetValue(entity)) == default;

                return isTransient;
            }

            return base.IsTransient(entity);
        }

        public override SqlString OnPrepareStatement(SqlString sql)
        {
            if (!_changeQueriesEnabled)
            {
                return sql;
            }

            var resourceContext = _resourceContextProvider.Get();

            if (resourceContext != null)
            {
                var entity = resourceContext.Resource.Entity;
                var requestHttpMethod = resourceContext.HttpMethod;

                // If we're possibly updating, and we're processing an aggregate root entity, then try to process the SQL to inject ChangeVersion update
                if (requestHttpMethod == HttpMethods.Post || requestHttpMethod == HttpMethods.Put)
                {
                    // Get the text for identifying the UPDATE statement we need to modify
                    string updateText = _updateTextByEntity.GetOrAdd(
                        entity,
                        static (e, databaseEngine) => 
                            e.IsDerived 
                                ? $"update {e.BaseEntity.Schema}.{e.BaseEntity.TableName(databaseEngine)} set "
                                : $"update {e.Schema}.{e.TableName(databaseEngine)} set ",
                        _databaseEngine);

                    // Look for the presence of the UPDATE statement
                    if (sql.StartsWithCaseInsensitive(updateText))
                    {
                        // Add the ChangeVersion column update clause immediately after the SET keyword
                        SqlString updatedSql = sql.Insert(updateText.Length, _changeVersionSetClause);
                        return updatedSql;
                    }
                }
            }

            return sql;
        }
    }
}
