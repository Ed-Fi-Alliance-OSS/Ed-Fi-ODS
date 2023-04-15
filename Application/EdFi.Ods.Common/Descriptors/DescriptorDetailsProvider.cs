// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using log4net;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace EdFi.Ods.Common.Descriptors;

public class DescriptorDetailsProvider : IDescriptorDetailsProvider
{
    private readonly IContextStorage _contextStorage;
    private readonly ISessionFactory _sessionFactory;
    
    private readonly Lazy<Dictionary<string, string>> _descriptorTypeNameByEntityName;

    private readonly ILog _logger = LogManager.GetLogger(typeof(DescriptorDetailsProvider));
    
    public DescriptorDetailsProvider(
        ISessionFactory sessionFactory,
        IDomainModelProvider domainModelProvider,
        IContextStorage contextStorage)
    {
        _contextStorage = contextStorage;
        _sessionFactory = sessionFactory;
        
        _descriptorTypeNameByEntityName = new Lazy<Dictionary<string, string>>(
            () => domainModelProvider.GetDomainModel()
                .Entities.Where(e => e.IsDescriptorEntity)
                .ToDictionary(
                    e => e.Name, 
                    e => e.EntityTypeFullName(e.SchemaProperCaseName())));
    }

    // public IDictionary<string, IList<DescriptorDetails>> GetAllDescriptorDetails()
    public IList<DescriptorDetails> GetAllDescriptorDetails()
    {
        try
        {
            _contextStorage.SetValue(NHibernateOdsConnectionProvider.UseReadWriteConnectionCacheKey, true);

            using (var session = _sessionFactory.OpenSession())
            {
                var queries = GetQueries(session).ToList();

                var results = queries.SelectMany(x => x.futureQuery.ToList()).ToList();

                return results;

                //     {
                //         DescriptorName = queryTuple.descriptorName,
                //         Data = queryTuple.futureQuery.ToList().ToList() as IList<DescriptorDetails>
                //     })
                // .ToDictionary(x => x.DescriptorName, x => x.Data);
            }

            IEnumerable<(string descriptorName, IEnumerable<DescriptorDetails> futureQuery)> GetQueries(ISession session)
            {
                foreach (string descriptorName in _descriptorTypeNameByEntityName.Value.Keys)
                {
                    var query = 
                        GetDescriptorCriteria(descriptorName, session)
                        .Future<DescriptorDetails>();

                    yield return (descriptorName, query);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Error("Error retrieving all Ed-Fi Descriptor data.", ex);

            throw;
        }
        finally
        {
            _contextStorage.SetValue(NHibernateOdsConnectionProvider.UseReadWriteConnectionCacheKey, null);
        }
    }

    public DescriptorDetails GetDescriptorDetails(string descriptorName, int id)
    {
        using var session = _sessionFactory.OpenSession();
        
        return GetDescriptorCriteria(descriptorName, session, id).UniqueResult<DescriptorDetails>();
    }

    public DescriptorDetails GetDescriptorDetails(string descriptorName, string uri)
    {
        using var session = _sessionFactory.OpenSession();
        
        return GetDescriptorCriteria(descriptorName, session, uri: uri).UniqueResult<DescriptorDetails>();
    }

    private ICriteria GetDescriptorCriteria(
        string descriptorName,
        ISession session,
        int? descriptorId = null,
        string uri = null)
    {
        if (!_descriptorTypeNameByEntityName.Value.TryGetValue(descriptorName, out string descriptorTypeName))
        {
            throw new ArgumentException($"Descriptor '{descriptorName}' is not a known descriptor entity name.");
        }

        var descriptorIdColumnName = descriptorName + "Id";

        var criteria = session.CreateCriteria(descriptorTypeName)
            .SetProjection(
                Projections.ProjectionList()
                    .Add(Projections.Property(descriptorIdColumnName), "DescriptorId")
                    .Add(Projections.Property("Namespace"), "Namespace")
                    .Add(Projections.Property("CodeValue"), "CodeValue"));

        if (descriptorId.HasValue)
        {
            criteria.Add(Restrictions.Eq(descriptorIdColumnName, descriptorId.Value));
        }

        if (uri != null)
        {
            int pos = uri.IndexOf('#');

            if (pos < 0)
            {
                throw new ArgumentException("Descriptor value is not in the correct format ('#' not found).", nameof(uri));
            }
            
            criteria.Add(Restrictions.Eq("Namespace", uri.Substring(0, pos)));
            criteria.Add(Restrictions.Eq("CodeValue", uri.Substring(pos + 1)));
        }

        criteria.SetResultTransformer(Transformers.AliasToBean<DescriptorDetails>());

        return criteria;
    }
}
