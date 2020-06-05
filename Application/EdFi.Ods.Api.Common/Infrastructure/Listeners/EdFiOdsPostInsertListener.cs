// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Dtos;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Api.Common.Infrastructure.Listeners
{
    public class EdFiOdsPostInsertListener : IPostInsertEventListener
    {
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
