// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace EdFi.Ods.Api.IdentityValueMappers
{
    /// <summary>
    /// Implements an <see cref="IPersonIdentifiersProvider"/> that is optimized around retrieving only
    /// the USI and UniqueId from the ODS (leaving the Id out of the payload and subsequent initialization).
    /// </summary>
    public class PersonIdentifiersProvider : IPersonIdentifiersProvider
    {
        private readonly IContextStorage _contextStorage;
        private readonly IPersonEntitySpecification _personEntitySpecification;
        private readonly IPersonTypesProvider _personTypesProvider;
        private readonly Func<IStatelessSession> _openStatelessSession;
        private readonly Lazy<Dictionary<string, string>> _uniqueIdNameByPersonType;
        private readonly Lazy<Dictionary<string, string>> _usiNameByPersonType;

        public PersonIdentifiersProvider(
            Func<IStatelessSession> openStatelessSession,
            IContextStorage contextStorage,
            IPersonEntitySpecification personEntitySpecification,
            IPersonTypesProvider personTypesProvider)
        {
            _contextStorage = contextStorage;
            _personEntitySpecification = personEntitySpecification;
            _personTypesProvider = personTypesProvider;
            _openStatelessSession = Preconditions.ThrowIfNull(openStatelessSession, nameof(openStatelessSession));

            _uniqueIdNameByPersonType = new Lazy<Dictionary<string, string>>(
                () => _personTypesProvider.PersonTypes.ToDictionary(pt => pt, pt => $"{pt}UniqueId"));

            _usiNameByPersonType = new Lazy<Dictionary<string, string>>(
                () => _personTypesProvider.PersonTypes.ToDictionary(pt => pt, pt => $"{pt}USI"));
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
        public async Task<IEnumerable<PersonIdentifiersValueMap>> GetAllPersonIdentifiersAsync(string personType)
        {
            return await GetPersonIdentifiers(personType);
        }

        public async Task<IEnumerable<PersonIdentifiersValueMap>> GetPersonUniqueIdsAsync(string personType, int[] usis)
        {
            return await GetPersonIdentifiers(personType, usis: usis);
        }

        public async Task<IEnumerable<PersonIdentifiersValueMap>> GetPersonUsisAsync(string personType, string[] uniqueIds)
        {
            return await GetPersonIdentifiers(personType, uniqueIds: uniqueIds);
        }

        private async Task<IEnumerable<PersonIdentifiersValueMap>> GetPersonIdentifiers(
            string personType,
            string[] uniqueIds = null,
            int[] usis = null)
        {
            ArgumentNullException.ThrowIfNull(personType, nameof(personType));

            // Validate Person type
            if (!_personEntitySpecification.IsPersonEntity(personType))
            {
                string validPersonTypes = string.Join("','", _personTypesProvider.PersonTypes).SingleQuoted();

                throw new ArgumentException($"Invalid person type '{personType}'. Valid person types are: {validPersonTypes}");
            }

            try
            {
                _contextStorage.SetValue(NHibernateOdsConnectionProvider.UseReadWriteConnectionCacheKey, true);

                using var session = _openStatelessSession();

                string aggregateNamespace = Namespaces.Entities.NHibernate.GetAggregateNamespace(
                    personType,
                    EdFiConventions.ProperCaseName);

                string entityName = $"{aggregateNamespace}.{personType}";

                var criteria = session.CreateCriteria(entityName)
                    .SetProjection(
                        Projections.ProjectionList()
                            .Add(Projections.Alias(Projections.Property(_usiNameByPersonType.Value[personType]), "Usi"))
                            .Add(Projections.Alias(Projections.Property(_uniqueIdNameByPersonType.Value[personType]), "UniqueId")))
                    .SetResultTransformer(Transformers.AliasToBean<PersonIdentifiersValueMap>());

                // TODO: Need to review possible usage of TVP here for SQL Server
                if (uniqueIds != null)
                {
                    criteria.Add(Restrictions.In(_uniqueIdNameByPersonType.Value[personType], uniqueIds));
                }
                else if (usis != null)
                {
                    criteria.Add(Restrictions.In(_usiNameByPersonType.Value[personType], usis));
                }
                
                return await criteria.ListAsync<PersonIdentifiersValueMap>();
            }
            finally
            {
                _contextStorage.SetValue(NHibernateOdsConnectionProvider.UseReadWriteConnectionCacheKey, null);
            }
        }
    }
}
