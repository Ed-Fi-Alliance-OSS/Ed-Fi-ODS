// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    /// <summary>
    /// Provides an implementation of the person identifier value mappers that treats all incoming
    /// UniqueId values as pure data elements and loads them from the ODS person-type tables directly,
    /// intended for use with API deployments with no integration with an external UniqueId system.
    /// </summary>
    public class UniqueIdToUsiValueMapper : IUniqueIdToUsiValueMapper
    {
        private readonly Func<IStatelessSession> _openStatelessSession;

        public UniqueIdToUsiValueMapper(Func<IStatelessSession> openStatelessSession)
        {
            _openStatelessSession = Preconditions.ThrowIfNull(openStatelessSession, nameof(openStatelessSession));
        }

        public PersonIdentifiersValueMap GetUsi(string personType, string uniqueId)
        {
            Preconditions.ThrowIfNull(personType, nameof(personType));
            
            return GetPersonIdentifiersValueMap(personType, personType + "UniqueId", uniqueId)
                      .FirstOrDefault() ?? new PersonIdentifiersValueMap();
        }

        public PersonIdentifiersValueMap GetUniqueId(string personType, int usi)
        {
            Preconditions.ThrowIfNull(personType, nameof(personType));
            
            return GetPersonIdentifiersValueMap(personType, personType + "USI", usi)
                      .FirstOrDefault() ?? new PersonIdentifiersValueMap();
        }

        private IEnumerable<PersonIdentifiersValueMap> GetPersonIdentifiersValueMap(
            string personType, 
            string searchField, 
            object searchValue)
        {
            // Validate Person type
            if (!PersonEntitySpecification.IsPersonEntity(personType))
            {
                string validPersonTypes = string.Join("','", PersonEntitySpecification.ValidPersonTypes)
                    .SingleQuoted();
                
                throw new ArgumentException($"Invalid person type '{personType}'. Valid person types are: {validPersonTypes}");
            }

            using (var session = _openStatelessSession())
            {
                string aggregateNamespace = Namespaces.Entities.NHibernate.GetAggregateNamespace(
                    personType, EdFiConventions.ProperCaseName);

                string entityName = $"{aggregateNamespace}.{personType}";

                var criteria = session.CreateCriteria(entityName)
                    .SetProjection(
                        Projections.ProjectionList()
                            .Add(Projections.Alias(Projections.Property($"{personType}USI"), "Usi"))
                            .Add(Projections.Alias(Projections.Property($"{personType}UniqueId"), "UniqueId"))
                    );

                if (searchField != null)
                {
                    criteria.Add(Expression.Eq($"{searchField}", searchValue));
                }

                criteria.SetResultTransformer(Transformers.AliasToBean<PersonIdentifiersValueMap>());

                return criteria.List<PersonIdentifiersValueMap>();
            }
        }
    }
}
