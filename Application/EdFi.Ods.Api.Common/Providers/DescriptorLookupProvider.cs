// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Common.Specifications;
using log4net;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace EdFi.Ods.Api.Common.Providers
{
    public class DescriptorLookupProvider : IDescriptorLookupProvider
    {
        private readonly Lazy<ConcurrentDictionary<string, string>> _descriptorFullNameByName;
        private readonly ILog _log = LogManager.GetLogger(typeof(DescriptorLookupProvider));
        private readonly ISessionFactory _sessionFactory;

        public DescriptorLookupProvider(ISessionFactory sessionFactory, IEdFiDescriptorReflectionProvider edFiDescriptorReflectionProvider)
        {
            _sessionFactory = sessionFactory;

            _descriptorFullNameByName = new Lazy<ConcurrentDictionary<string, string>>(
                () => new ConcurrentDictionary<string, string>(edFiDescriptorReflectionProvider.GetDescriptorEntityNameMapping()));
        }

        public DescriptorLookup GetSingleDescriptorLookupById(string descriptorName, int id)
        {
            return GetDescriptorCacheData(descriptorName, id)
               .SingleOrDefault();
        }

        public IList<DescriptorLookup> GetDescriptorLookupsByDescriptorName(string descriptorName)
        {
            return GetDescriptorCacheData(descriptorName);
        }

        public IDictionary<string, IList<DescriptorLookup>> GetAllDescriptorLookups()
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                {
                    var queries = new List<IEnumerable<DescriptorEntry>>();
                    var descriptorNames = _descriptorFullNameByName.Value.Keys.ToArray();

                    foreach (string descriptorName in descriptorNames)
                    {
                        string typeName = _descriptorFullNameByName.Value[descriptorName];

                        var descriptorIdColumnName = descriptorName + "Id";

                        var query = session.CreateCriteria(typeName)
                                           .SetProjection(
                                                Projections.ProjectionList()
                                                           .Add(Projections.Property(descriptorIdColumnName), "Id")
                                                           .Add(Projections.Property("Namespace"), "Namespace")
                                                           .Add(Projections.Property("CodeValue"), "CodeValue"))
                                           .SetResultTransformer(Transformers.AliasToBean<DescriptorEntry>())
                                           .Future<DescriptorEntry>();

                        queries.Add(query);
                    }

                    return queries
                          .Select(
                               (q, i) =>
                                   new
                                   {
                                       TypeName = descriptorNames[i], Data =
                                           TransformToDescriptorLookups(descriptorNames[i], q.ToList())
                                              .ToList() as IList<DescriptorLookup>
                                   })
                          .ToDictionary(x => x.TypeName, x => x.Data);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Error retrieving all Ed-Fi Descriptor data.", ex);
                throw;
            }
        }

        private IList<DescriptorLookup> GetDescriptorCacheData(string descriptorName, int? id = null)
        {
            if (!DescriptorEntitySpecification.IsEdFiDescriptorEntity(descriptorName))
            {
                _log.Error($"{descriptorName} is not a descriptor, but is being passed as one");
                throw new ArgumentException($"{descriptorName} is not a descriptor, but is being passed as one");
            }

            try
            {
                string descriptorFullName;

                if (!_descriptorFullNameByName.Value.TryGetValue(descriptorName, out descriptorFullName))
                {
                    throw new KeyNotFoundException($"descriptorName {descriptorName} is not a known descriptor entity name.");
                }

                using (var session = _sessionFactory.OpenSession())
                {
                    var descriptorIdColumnName = descriptorName + "Id";

                    var criteria = session.CreateCriteria(descriptorFullName)
                                          .SetProjection(
                                               Projections.ProjectionList()
                                                          .Add(Projections.Property(descriptorIdColumnName), "Id")
                                                          .Add(Projections.Property("Namespace"), "Namespace")
                                                          .Add(Projections.Property("CodeValue"), "CodeValue"));

                    if (id.HasValue)
                    {
                        criteria.Add(Restrictions.Eq(descriptorIdColumnName, id.Value));
                    }

                    return TransformToDescriptorLookups(
                            descriptorName,
                            criteria.SetResultTransformer(Transformers.AliasToBean<DescriptorEntry>())
                                    .List<DescriptorEntry>())
                       .ToList();
                }
            }
            catch (Exception ex)
            {
                _log.Error($"Error creating hql query for {descriptorName}.", ex);
                throw;
            }
        }

        private static IEnumerable<DescriptorLookup> TransformToDescriptorLookups(
            string descriptorName,
            IEnumerable<DescriptorEntry> descriptorEntries)
        {
            return descriptorEntries.Select(
                d => new DescriptorLookup
                     {
                         DescriptorName = descriptorName, DescriptorValue =
                             EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                                 d.Namespace,
                                 d.CodeValue),
                         Id = d.Id
                     });
        }

        /// <summary>
        /// Internal class for projecting from nHibernate Query
        /// </summary>
        private class DescriptorEntry
        {
            public int Id { get; set; }

            public string Namespace { get; set; }

            public string CodeValue { get; set; }
        }
    }
}
