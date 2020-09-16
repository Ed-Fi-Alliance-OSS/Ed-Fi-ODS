// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security;
using NHibernate;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Common.Infrastructure.Listeners
{
    public class EdFiOdsPostInsertListener : IPostInsertEventListener
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;

        public EdFiOdsPostInsertListener(IApiKeyContextProvider apiKeyContextProvider)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
        }
        
        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            return Task.Run(() => OnPostInsert(@event), cancellationToken);
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            var domainEntity = @event.Entity as DomainObjectBase;

            if (domainEntity == null)
            {
                return;
            }

            DateTime createDateValue = Get<DateTime>(@event.Persister, @event.State, "CreateDate");

            if (!createDateValue.Equals(default(DateTime)))
            {
                domainEntity.CreateDate = createDateValue;
            }

            var aggregateRoot = @event.Entity as AggregateRootWithCompositeKey;

            if (aggregateRoot != null)
            {
                // Assign the server-assigned Id back to the aggregate root entity
                if (aggregateRoot.Id.Equals(Guid.Empty))
                {
                    aggregateRoot.Id = Get<Guid>(@event.Persister, @event.State, "Id");
                }
            }

            if (aggregateRoot is IIdentifiablePerson)
            {
                // We only support Student right now - should redesign for extensibility
                if (aggregateRoot.GetType().Name == "Student")
                {
                    int studentUsi = (int) aggregateRoot.GetType().GetProperty("StudentUSI").GetValue(aggregateRoot);
                    
                    CreateIdentifier(
                        @event.Session,
                        studentUsi,
                        (aggregateRoot as IIdentifiablePerson).UniqueId);
                }
            }
        }

        private void CreateIdentifier(ISession session, int studentUsi, string uniqueId)
        {
            using (var cmd = session.Connection.CreateCommand())
            {
                cmd.CommandText = 
                    @"INSERT INTO Identification.StudentIdentifier (StudentUSI, Identifier, Namespace) VALUES (@usi, @identifier, @namespace)";

                var usiParm = cmd.CreateParameter();
                usiParm.ParameterName = "@usi";
                usiParm.DbType = DbType.Int32;
                usiParm.Value = studentUsi;
                cmd.Parameters.Add(usiParm);
                
                var identifierParm = cmd.CreateParameter();
                identifierParm.ParameterName = "@identifier";
                identifierParm.DbType = DbType.String;
                identifierParm.Value = uniqueId;
                cmd.Parameters.Add(identifierParm);
                
                var namespaceParm = cmd.CreateParameter();
                namespaceParm.ParameterName = "@namespace";
                namespaceParm.DbType = DbType.String;
                namespaceParm.Value = _apiKeyContextProvider.GetApiKeyContext().StudentIdentificationOperationalContextUri;
                cmd.Parameters.Add(namespaceParm);
                
                session.Transaction.Enlist(cmd);
                cmd.ExecuteNonQuery();
            }
        }
        
        private T Get<T>(IEntityPersister persister, object[] state, string propertyName)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);

            if (index == -1)
            {
                return default(T);
            }

            return (T) state[index];
        }
    }
}
