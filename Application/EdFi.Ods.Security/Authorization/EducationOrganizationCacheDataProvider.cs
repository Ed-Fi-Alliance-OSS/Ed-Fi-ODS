// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.Security.Authorization
{
    public class EducationOrganizationCacheDataProvider
        : IEducationOrganizationCacheDataProvider,
            IEducationOrganizationIdentifiersValueMapper
    {
        private const string Sql = @"SELECT * FROM auth.EducationOrganizationIdentifiers";
        private readonly ISessionFactory _sessionFactory;

        public EducationOrganizationCacheDataProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = Preconditions.ThrowIfNull(sessionFactory, nameof(sessionFactory));
        }

        public async Task<IEnumerable<EducationOrganizationIdentifiers>> GetAllEducationOrganizationIdentifiers()
        {
            using (var session = _sessionFactory.OpenStatelessSession())
            {
                return await session.CreateSQLQuery(Sql + " ORDER BY EducationOrganizationId;")
                    .SetResultTransformer(Transformers.AliasToBean<EducationOrganizationIdentifiers>())
                    .ListAsync<EducationOrganizationIdentifiers>()
                    .ConfigureAwait(false);
            }
        }

        public EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(string stateOrganizationId)
        {
            throw new NotSupportedException();
        }

        public EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(int educationOrganizationId)
        {
            using (var session = _sessionFactory.OpenStatelessSession())
            {
                return session.CreateSQLQuery(Sql + " WHERE EducationOrganizationId = :edOrgId;")
                    .SetParameter("edOrgId", educationOrganizationId)
                    .SetResultTransformer(Transformers.AliasToBean<EducationOrganizationIdentifiers>())
                    .UniqueResult<EducationOrganizationIdentifiers>();
            }
        }
    }
}
