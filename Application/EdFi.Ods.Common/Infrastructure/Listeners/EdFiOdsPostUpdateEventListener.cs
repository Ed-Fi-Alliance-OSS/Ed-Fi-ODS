// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using log4net;
using Microsoft.Extensions.Primitives;
using NHibernate;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Common.Infrastructure.Listeners
{
    public class EdFiOdsPostUpdateEventListener : IPostUpdateEventListener
    {
        private readonly Lazy<IEntityAuthorizer> _entityAuthorizer;
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly bool _serializationEnabled;

        private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsPostUpdateEventListener));
        
        public EdFiOdsPostUpdateEventListener(
            Func<IEntityAuthorizer> entityAuthorizerResolver,
            IAuthorizationContextProvider authorizationContextProvider,
            ApiSettings apiSettings)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _entityAuthorizer = new Lazy<IEntityAuthorizer>(entityAuthorizerResolver);
            _serializationEnabled = apiSettings.IsFeatureEnabled(ApiFeature.SerializedData.GetConfigKeyName());
        }

        public async Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            await ProcessCascadingKeyValuesAsync(@event, cancellationToken);
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            ProcessCascadingKeyValuesAsync(@event, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task ProcessCascadingKeyValuesAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
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

            // Apply the new key values to the entity and then perform validation before proceeding
            ApplyNewKeyValuesToEntity();

            // Authorize the entity
            var action = _authorizationContextProvider.GetAction();
            await _entityAuthorizer.Value.AuthorizeEntityAsync(@event.Entity, action, AuthorizationPhase.ProposedData, cancellationToken);

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

            byte[] aggregateData = null;
            DateTime? lastModifiedDate = null;

            if (_serializationEnabled && @event.Entity is AggregateRootWithCompositeKey aggregateRoot)
            {
                // Produce a new LastModifiedDate so that newly serialized data (with key change) isn't treated as stale
                aggregateRoot.LastModifiedDate = aggregateRoot.LastModifiedDate.AddMicroseconds(1); // DateTime.UtcNow;

                _logger.Debug("Serializing aggregate data for storage (KEY CHANGE)...");

                // Produce the serialized data
                aggregateData = MessagePackHelper.SerializeAndCompressAggregateData(aggregateRoot);
                aggregateRoot.AggregateData = aggregateData;
                lastModifiedDate = aggregateRoot.LastModifiedDate;
            }

            var query = CreateUpdateQuery(
                @event.Session,
                hasIdentifier.Id,
                tableName,
                updateTargetColumnNames,
                valueSourceColumnNames,
                newKeyValues,
                aggregateData,
                lastModifiedDate);

            // Execute the update of the primary key
            await query.ExecuteUpdateAsync(cancellationToken).ConfigureAwait(false);

            void ApplyNewKeyValuesToEntity()
            {
                var typeInfo = @event.Entity.GetType().GetTypeInfo();

                foreach (var keyAsObject in newKeyValues.Keys)
                {
                    var property = typeInfo.GetProperty((string) keyAsObject);
                    property.SetValue(@event.Entity, newKeyValues[keyAsObject]);
                }
            }
        }

        private static IQuery CreateUpdateQuery(
            ISession session,
            Guid id,
            string tableName,
            string[] updateTargetColumnNames,
            string[] valueSourceColumnNames,
            OrderedDictionary newKeyValues,
            byte[] aggregateData,
            DateTime? lastModifiedDate)
        {
            // Build the SET clause
            string setClause = GetSetClause(
                updateTargetColumnNames,
                valueSourceColumnNames,
                aggregateData != null,
                lastModifiedDate != null);

            // Build the UPDATE sql query
            string sql = $@"UPDATE {tableName} SET {setClause} WHERE Id = :id";

            var query = session.CreateSQLQuery(sql).SetGuid("id", id);

            if (aggregateData != null)
            {
                query.SetBinary("aggregateData", aggregateData);
            }

            if (lastModifiedDate != null)
            {
                query.SetDateTime("lastModifiedDate", lastModifiedDate.Value);
            }

            // Create parameters for updating the primary key with the new values
            for (int i = 0; i < updateTargetColumnNames.Length; i++)
            {
                string targetColumnName = updateTargetColumnNames[i];
                string valueSourceColumnName = valueSourceColumnNames[i];

                query.SetParameter(targetColumnName, newKeyValues[valueSourceColumnName]);
            }

            return query;
        }

        private static string GetSetClause(string[] updateTargetColumnNames, string[] sourceValueColumnNames, bool hasAggregateData, bool hasLastModifiedDate)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < updateTargetColumnNames.Length; i++)
            {
                string targetColumnName = updateTargetColumnNames[i];
                string sourceValueColumnName = sourceValueColumnNames[i];

                if (i > 0)
                {
                    sb.Append(',');
                }

                sb.Append(targetColumnName);
                sb.Append(" = :");
                sb.Append(sourceValueColumnName);
            }

            if (hasAggregateData)
            {
                sb.Append(", AggregateData = :aggregateData");
            }

            if (hasLastModifiedDate)
            {
                sb.Append(", LastModifiedDate = :lastModifiedDate");
            }

            string setClause = sb.ToString();

            return setClause;
        }
    }
}
