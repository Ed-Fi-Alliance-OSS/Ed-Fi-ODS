// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace EdFi.Ods.Api.IdentityValueMappers
{
    /// <summary>
    /// Provides an implementation of the person identifier value mappers that treats all incoming
    /// UniqueId values as pure data elements and loads them from the ODS person-type tables directly,
    /// intended for use with API deployments with no integration with an external UniqueId system.
    /// </summary>
    public class UniqueIdToUsiValueMapper : IUniqueIdToUsiValueMapper
    {
        private readonly IContextStorage _contextStorage;
        private readonly IPersonEntitySpecification _personEntitySpecification;
        private readonly IPersonTypesProvider _personTypesProvider;
        private readonly Func<IStatelessSession> _openStatelessSession;

        private readonly ConcurrentDictionary<string, (string entityName, string usiName, string uniqueIdName)>
            _artifactNamesByPersonType = new();

        public UniqueIdToUsiValueMapper(
            Func<IStatelessSession> openStatelessSession,
            IContextStorage contextStorage,
            IPersonEntitySpecification personEntitySpecification,
            IPersonTypesProvider personTypesProvider)
        {
            _contextStorage = contextStorage;
            _personEntitySpecification = personEntitySpecification;
            _personTypesProvider = personTypesProvider;
            _openStatelessSession = Preconditions.ThrowIfNull(openStatelessSession, nameof(openStatelessSession));
        }

        public PersonIdentifiersValueMap GetUsi(string personType, string uniqueId)
        {
            Preconditions.ThrowIfNull(personType, nameof(personType));

            if (uniqueId == null)
            {
                return PersonIdentifiersValueMap.Default;
            }

            return GetPersonIdentifiersValueMap(personType, uniqueId)
                      .FirstOrDefault() ?? PersonIdentifiersValueMap.Default;
        }

        public PersonIdentifiersValueMap GetUniqueId(string personType, int usi)
        {
            Preconditions.ThrowIfNull(personType, nameof(personType));

            return GetPersonIdentifiersValueMap(personType, usi)
                      .FirstOrDefault() ?? PersonIdentifiersValueMap.Default;
        }

        private IEnumerable<PersonIdentifiersValueMap> GetPersonIdentifiersValueMap(string personType, object searchValue)
        {
            // Validate Person type
            if (!_personEntitySpecification.IsPersonEntity(personType))
            {
                string validPersonTypes = string.Join("','", _personTypesProvider.PersonTypes)
                    .SingleQuoted();

                throw new ArgumentException($"Invalid person type '{personType}'. Valid person types are: {validPersonTypes}");
            }

            try
            {
                _contextStorage.SetValue(NHibernateOdsConnectionProvider.UseReadWriteConnectionCacheKey, true);

                using var session = _openStatelessSession();

                var (entityName, usiName, uniqueIdName) = _artifactNamesByPersonType.GetOrAdd(personType,
                    pt =>
                    {
                        string aggregateNamespace = Namespaces.Entities.NHibernate.GetAggregateNamespace(pt, EdFiConventions.ProperCaseName);

                        return ($"{aggregateNamespace}.{pt}", $"{pt}USI", $"{pt}UniqueId");
                    });
                
                var criteria = session.CreateCriteria(entityName)
                    .SetProjection(
                        Projections.ProjectionList()
                            .Add(Projections.Alias(Projections.Property(usiName), "Usi"))
                            .Add(Projections.Alias(Projections.Property(uniqueIdName), "UniqueId"))
                    );

                if (searchValue != null)
                {
                    if (searchValue is string)
                    {
                        criteria.Add(Expression.Eq(uniqueIdName, searchValue));    
                    }
                    else
                    {
                        criteria.Add(Expression.Eq(usiName, searchValue));    
                    }
                }

                criteria.SetResultTransformer(Transformers.AliasToBean<PersonIdentifiersValueMap>());

                return criteria.List<PersonIdentifiersValueMap>();
            }
            finally
            {
                _contextStorage.SetValue(NHibernateOdsConnectionProvider.UseReadWriteConnectionCacheKey, null);
            }
        }
    }
}
