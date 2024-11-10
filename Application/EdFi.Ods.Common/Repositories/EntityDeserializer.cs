// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Listeners;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Http;
using NHibernate;

namespace EdFi.Ods.Common.Repositories;

public class EntityDeserializer : IEntityDeserializer
{
    private readonly ISurrogateIdMutator[] _surrogateIdMutators;
    private readonly ISessionFactory _sessionFactory;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

    public EntityDeserializer(
        ISurrogateIdMutator[] surrogateIdMutators,
        ISessionFactory sessionFactory,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
    {
        _surrogateIdMutators = surrogateIdMutators;
        _sessionFactory = sessionFactory;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
    }
        
    public async Task<TEntity> DeserializeAsync<TEntity>(ItemRawData itemRawData)
    {
        // Deserialize the entity
        var entity = MessagePackHelper.DecompressAndDeserializeAggregate<TEntity>(itemRawData.AggregateData);

        // Apply surrogate id mutators to set the surrogate id value onto the entity if not already assigned yet
        foreach (var mutator in _surrogateIdMutators)
        {
            if (mutator.TrySetSurrogateId(entity, itemRawData))
            {
                break;
            }
        }

        // If we're going to use the deserialized entity with NHibernate, bring it into the current session
        if (_dataManagementResourceContextProvider.Get().HttpMethod != HttpMethods.Get)
        {
            // Add the entity to the current session and, importantly, snapshot it.
            using var scope = new SessionScope(_sessionFactory);
            await scope.Session.LockAsync(entity, LockMode.None).ConfigureAwait(false);
        }

        return entity;
    }
}
