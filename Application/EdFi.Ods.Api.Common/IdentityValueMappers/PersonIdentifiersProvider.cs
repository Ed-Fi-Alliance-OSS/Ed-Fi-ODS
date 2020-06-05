// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    /// Implements an <see cref="IPersonIdentifiersProvider"/> that is optimized around retrieving only
    /// the USI and UniqueId from the ODS (leaving the Id out of the payload and subsequent initialization).
    /// </summary>
    public class PersonIdentifiersProvider : IPersonIdentifiersProvider
    {
        private readonly Func<IStatelessSession> _openStatelessSession;

        public PersonIdentifiersProvider(Func<IStatelessSession> openStatelessSession)
        {
            _openStatelessSession = Preconditions.ThrowIfNull(openStatelessSession, nameof(openStatelessSession));
        }

        /// <summary>
        /// Gets the identifier values available for all members of the specified Person type as a streaming enumerable.
        /// </summary>
        /// <param name="personType">The type of person whose UniqueId is being requested (e.g. Student, Staff or Parent).</param>
        /// <returns>An enumerable collection of <see cref="PersonIdentifiersValueMap"/> instances containing the available identifiers 
        /// for UniqueId and the corresponding Id and/or USI values (depending on the implementation).</returns>
        /// <remarks>Consumers should read all the data immediately because implementations should "stream" the 
        /// data back for efficiency reasons, holding on resources such as a database connection until reading is
        /// complete.
        /// </remarks>
        public async Task<IEnumerable<PersonIdentifiersValueMap>> GetAllPersonIdentifiers(string personType)
        {
            Preconditions.ThrowIfNull(personType, nameof(personType));
            
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
                    )
                    .SetResultTransformer(Transformers.AliasToBean<PersonIdentifiersValueMap>());

                return await criteria.ListAsync<PersonIdentifiersValueMap>();
            }
        }
    }
}
