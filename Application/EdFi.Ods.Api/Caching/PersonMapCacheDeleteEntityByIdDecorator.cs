// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Caching;

/// <summary>
/// Implements a decorator around the delete operation that removes the associated UniqueId/USI cache entries
/// when a person entity is deleted.
/// </summary>
/// <typeparam name="TEntity">The type of entity (intended to be a person type).</typeparam>
public class PersonMapCacheDeleteEntityByIdDecorator<TEntity> : IDeleteEntityById<TEntity>
    where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
{
    private readonly IDeleteEntityById<TEntity> _next;
    private readonly IMapCache<(ulong, string, PersonMapType), string, int> _usiByUniqueIdByPersonType;
    private readonly IMapCache<(ulong, string, PersonMapType), int, string> _uniqueIdByUsiByPersonType;
    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationProvider;
    private readonly string _personType;
    private readonly Func<TEntity, int> _usiPropertyAccessor;

    /// <summary>
    /// Initializes a new instance of <see cref="PersonMapCacheDeleteEntityByIdDecorator{T}"/>.
    /// </summary>
    /// <param name="next">The decorated instance for which authorization is being performed.</param>
    /// <param name="personEntitySpecification"></param>
    /// <param name="usiByUniqueIdByPersonType"></param>
    /// <param name="uniqueIdByUsiByPersonType"></param>
    /// <param name="odsInstanceConfigurationProvider"></param>
    public PersonMapCacheDeleteEntityByIdDecorator(
        IDeleteEntityById<TEntity> next,
        IPersonEntitySpecification personEntitySpecification,
        IMapCache<(ulong, string, PersonMapType), string, int> usiByUniqueIdByPersonType,
        IMapCache<(ulong, string, PersonMapType), int, string> uniqueIdByUsiByPersonType,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationProvider)
    {
        _next = next;
        _usiByUniqueIdByPersonType = usiByUniqueIdByPersonType;
        _uniqueIdByUsiByPersonType = uniqueIdByUsiByPersonType;
        _odsInstanceConfigurationProvider = odsInstanceConfigurationProvider;

        // Perform a defensive check (registration logic should already not apply the decorator to non-person types)
        if (personEntitySpecification.IsPersonEntity(typeof(TEntity)))
        {
            _personType = typeof(TEntity).Name;

            // Build and compile a function for extracting the USI from the entity
            var usiProperty = typeof(TEntity).GetTypeInfo().GetDeclaredProperty($"{_personType}USI");
            _usiPropertyAccessor = BuildUsiPropertyAccessor(usiProperty);
        }
        
        static Func<TEntity, int> BuildUsiPropertyAccessor(PropertyInfo propertyInfo)
        {
            // Input parameter for the instance of type T
            ParameterExpression instanceParam = Expression.Parameter(typeof(TEntity), "instance");

            // Expression to access the property on the instance
            Expression propertyAccess = Expression.Property(instanceParam, propertyInfo);

            // Build the lambda expression
            LambdaExpression lambda = Expression.Lambda<Func<TEntity, int>>(propertyAccess, instanceParam);

            // Compile and return the lambda as a delegate
            return (Func<TEntity, int>) lambda.Compile();
        }
    }

    public async Task<TEntity> DeleteByIdAsync(Guid id, string etag, CancellationToken cancellationToken)
    {
        var deletedEntity = await _next.DeleteByIdAsync(id, etag, cancellationToken);
        
        // If we're still here (no errors), remove the associated cached map entry
        if (_personType != null && deletedEntity is IIdentifiablePerson person)
        {
            ulong odsInstanceHashId = _odsInstanceConfigurationProvider.Get().OdsInstanceHashId;

            int usi = _usiPropertyAccessor.Invoke(deletedEntity);

            // Remove the USI from the cached map by UniqueId
            _usiByUniqueIdByPersonType.DeleteMapEntry(
                (odsInstanceHashId, _personType, PersonMapType.UsiByUniqueId),
                person.UniqueId);

            // Remove the UniqueId from the cached map by USI
            _uniqueIdByUsiByPersonType.DeleteMapEntry(
                (odsInstanceHashId, _personType, PersonMapType.UniqueIdByUsi),
                usi);
        }

        return deletedEntity;
    }
}
