// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using NHibernate;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Api.Common.Infrastructure.Listeners
{
    public class EdFiOdsPostUpdateEventListener : IPostUpdateEventListener
    {
        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            return Task.Run(() => OnPostUpdate(@event), cancellationToken);
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            ProcessCascadingKeyValues(@event);
        }

        private static void ProcessCascadingKeyValues(PostUpdateEvent @event)
        {
            // Quit if this is not an entity that supports cascading updates
            var cascadableEntity = @event.Entity as IHasCascadableKeyValues;

            if (cascadableEntity == null)
            {
                return;
            }

            // Quit if there are no modified key values to cascade
            var newKeyValues = cascadableEntity.NewKeyValues;

            if (newKeyValues == null)
            {
                return;
            }

            // Make sure the identity has an identifier for performing the update
            var hasIdentifier = @event.Entity as IHasIdentifier;

            if (hasIdentifier == null)
            {
                throw new NotSupportedException(
                    "Cascading updates are only supported for 'aggregate root' entities that implement IHasIdentifier (i.e. entities that have a GUID-based identifier property).");
            }

            string tableName;
            string[] updateTargetColumnNames;
            string[] valueSourceColumnNames;

            // Get the entity's metadata
            var classMetadata = (AbstractEntityPersister) @event.Session.SessionFactory.GetClassMetadata(@event.Entity.GetType());

            // If there is no root table, update using the class' metadata
            if (classMetadata.TableName == classMetadata.RootTableName)
            {
                tableName = classMetadata.TableName;
                updateTargetColumnNames = classMetadata.IdentifierColumnNames;
                valueSourceColumnNames = classMetadata.IdentifierColumnNames;
            }
            else
            {
                var rootClassMetadata = (AbstractEntityPersister) @event.Session.SessionFactory.GetClassMetadata(classMetadata.RootEntityName);
                tableName = rootClassMetadata.RootTableName;
                updateTargetColumnNames = rootClassMetadata.IdentifierColumnNames;
                valueSourceColumnNames = classMetadata.IdentifierColumnNames;
            }

            var query = CreateUpdateQuery(
                @event.Session,
                hasIdentifier.Id,
                tableName,
                updateTargetColumnNames,
                valueSourceColumnNames,
                newKeyValues);

            // Execute the update of the primary key
            query.ExecuteUpdate();
        }

        private static IQuery CreateUpdateQuery(
            ISession session,
            Guid id,
            string tableName,
            string[] updateTargetColumnNames,
            string[] valueSourceColumnNames,
            OrderedDictionary newKeyValues)
        {
            // Build the SET clause
            string setClause = GetSetClause(updateTargetColumnNames, valueSourceColumnNames);

            // Build the UPDATE sql query
            string sql = string.Format(
                @"
                    UPDATE  {0} 
                    SET     {1} 
                    WHERE   Id = :id",
                tableName,
                setClause);

            var query = session.CreateSQLQuery(sql)
                               .SetGuid("id", id);

            // Create parameters for updating the primary key with the new values
            for (int i = 0; i < updateTargetColumnNames.Length; i++)
            {
                //var sqlType = classMetadata.IdAndVersionSqlTypes[i];
                string targetColumnName = updateTargetColumnNames[i];
                string valueSourceColumnName = valueSourceColumnNames[i];

                query.SetParameter(targetColumnName, newKeyValues[valueSourceColumnName]);
            }

            return query;
        }

        private static string GetSetClause(string[] updateTargetColumnNames, string[] sourceValueColumnNames)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < updateTargetColumnNames.Length; i++)
            {
                string targetColumnName = updateTargetColumnNames[i];
                string sourceValueColumnName = sourceValueColumnNames[i];

                sb.AppendLine(targetColumnName + " = :" + sourceValueColumnName + ",");
            }

            string setClause = sb.ToString()
                                 .TrimEnd(',', '\r', '\n');

            return setClause;
        }
    }
}
