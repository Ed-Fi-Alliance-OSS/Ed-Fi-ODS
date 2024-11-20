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
using log4net;
using Microsoft.AspNetCore.Http;
using NHibernate;

namespace EdFi.Ods.Common.Repositories;

public class EntityDeserializer : IEntityDeserializer
{
    private readonly ISurrogateIdMutator[] _surrogateIdMutators;
    private readonly ISessionFactory _sessionFactory;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

    private readonly ILog _logger = LogManager.GetLogger(typeof(EntityDeserializer));
    
    public EntityDeserializer(
        ISurrogateIdMutator[] surrogateIdMutators,
        ISessionFactory sessionFactory,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
    {
        _surrogateIdMutators = surrogateIdMutators;
        _sessionFactory = sessionFactory;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
    }
        
    public async Task<TEntity> DeserializeAsync<TEntity>(IItemRawData itemRawData)
    {
        TEntity entity = default;

        // TODO: ODS-6551 - Restore to fallback to NHibernate-based load once code is stable and known tests pass without suppressing deserialization failures 
        // try
        {
            // Deserialize the entity
            entity = MessagePackHelper.DecompressAndDeserializeAggregate<TEntity>(itemRawData.AggregateData);
        }
        // catch (Exception ex)
        // {
        //     // Prevent exceptions during deserialization from failing the processing -- revert to returning a null instance
        //     _logger.Warn($"Unable to deserialize entity of type '{typeof(TEntity).Name}' (with AggregateId of {itemRawData.AggregateId}). Falling back to load through NHibernate repository...", ex);
        //     return default;
        // }

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
