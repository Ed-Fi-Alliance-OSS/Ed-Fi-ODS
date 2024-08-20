// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Dapper;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using log4net;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace EdFi.Ods.Common.Descriptors;

/// <summary>
/// Loads descriptor details using NHibernate queries against the ODS.
/// </summary>
public class DescriptorDetailsProvider : IDescriptorDetailsProvider
{
    private readonly IContextStorage _contextStorage;
    private readonly Dialect _dialect;
    private readonly ISessionFactory _sessionFactory;
    
    private readonly Lazy<Dictionary<string, string>> _discriminatorByDescriptorName;

    private readonly ILog _logger = LogManager.GetLogger(typeof(DescriptorDetailsProvider));
    
    public DescriptorDetailsProvider(
        ISessionFactory sessionFactory,
        IDomainModelProvider domainModelProvider,
        IContextStorage contextStorage,
        Dialect dialect)
    {
        _contextStorage = contextStorage;
        _dialect = dialect;
        _sessionFactory = sessionFactory;
        
        _discriminatorByDescriptorName = new Lazy<Dictionary<string, string>>(
            () => domainModelProvider.GetDomainModel()
                .Entities.Where(e => e.IsDescriptorEntity)
                .ToDictionary(
                    e => e.Name, 
                    e => e.FullName.ToString()));
    }

    /// <inheritdoc cref="IDescriptorDetailsProvider.GetAllDescriptorDetails" />
    public IList<DescriptorDetails> GetAllDescriptorDetails()
    {
        try
        {
            _contextStorage.SetValue(NHibernateOdsConnectionProvider.UseReadWriteConnectionCacheKey, true);

            using (var session = _sessionFactory.OpenSession())
            {
                var qb = GetDescriptorQueryBuilder();
                var template = qb.BuildTemplate();

                var records = session.Connection.Query<DescriptorRecord>(template.RawSql);

                var results = records.Select(
                        r => new DescriptorDetails()
                        {
                            DescriptorId = r.DescriptorId,
                            DescriptorName = r.Discriminator?.Substring(r.Discriminator.IndexOf('.') + 1),
                            CodeValue = r.CodeValue,
                            Namespace = r.Namespace
                        })
                    .ToList();

                return results;
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

    private QueryBuilder GetDescriptorQueryBuilder()
    {
        var qb = new QueryBuilder(_dialect)
            .From("edfi.Descriptor")
            .Select("DescriptorId", "CodeValue", "Namespace", "Discriminator");

        return qb;
    }

    /// <inheritdoc cref="IDescriptorDetailsProvider.GetDescriptorDetails(string,int)" />
    public DescriptorDetails GetDescriptorDetails(string descriptorName, int descriptorId)
    {
        using var session = _sessionFactory.OpenSession();

        var qb = GetFilteredDescriptorQueryBuilder(descriptorName, descriptorId);
        var template = qb.BuildTemplate();

        return session.Connection.QuerySingleOrDefault<DescriptorDetails>(template.RawSql, template.Parameters);
    }

    /// <inheritdoc cref="IDescriptorDetailsProvider.GetDescriptorDetails(string,string)" />
    public DescriptorDetails GetDescriptorDetails(string descriptorName, string uri)
    {
        using var session = _sessionFactory.OpenSession();

        var qb = GetFilteredDescriptorQueryBuilder(descriptorName, uri: uri);
        var template = qb.BuildTemplate();

        return session.Connection.QuerySingleOrDefault<DescriptorDetails>(template.RawSql, template.Parameters);
    }

    private QueryBuilder GetFilteredDescriptorQueryBuilder(
        string descriptorName,
        int? descriptorId = null,
        string uri = null)
    {
        if (!_discriminatorByDescriptorName.Value.TryGetValue(descriptorName, out string discriminator))
        {
            throw new ArgumentException($"Descriptor '{descriptorName}' is not a known descriptor entity name.");
        }

        var qb = GetDescriptorQueryBuilder().Where("Discriminator", discriminator);

        if (descriptorId.HasValue)
        {
            qb.Where("DescriptorId", descriptorId.Value);
        }

        if (uri != null)
        {
            int pos = uri.IndexOf('#');

            if (pos < 0)
            {
                throw new ValidationException($"{descriptorName} value '{uri}' is not a valid value for use as a descriptor (a '#' is expected to delineate the namespace and code value portions).");
            }

            qb.Where("Namespace", uri.Substring(0, pos));
            qb.Where("CodeValue", uri.Substring(pos + 1));
        }

        return qb;
    }

    private class DescriptorRecord
    {
        public int DescriptorId { get; set; }
        public string Discriminator { get; set; }
        public string Namespace { get; set; }
        public string CodeValue { get; set; }
    }
}
