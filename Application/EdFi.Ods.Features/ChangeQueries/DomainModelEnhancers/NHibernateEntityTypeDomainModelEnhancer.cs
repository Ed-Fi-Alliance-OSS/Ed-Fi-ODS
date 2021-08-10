// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Models.Domain;
using log4net;
using NHibernate;
using NHibernate.Metadata;

namespace EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers
{
    public interface IDomainModelEnhancer
    {
        void Enhance(DomainModel domainModel);
    }
    
    public class NHibernateEntityTypeDomainModelEnhancer : IDomainModelEnhancer
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(NHibernateEntityTypeDomainModelEnhancer));
        
        private readonly ISessionFactory _sessionFactory;

        public NHibernateEntityTypeDomainModelEnhancer(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        
        public void Enhance(DomainModel domainModel)
        {
            var allClassMetadata = _sessionFactory.GetAllClassMetadata();

            foreach (KeyValuePair<string,IClassMetadata> classMetadata in allClassMetadata)
            {
                var mappedEntityType = classMetadata.Value.MappedClass;
                string schema = mappedEntityType.GetCustomAttribute<SchemaAttribute>()?.Schema;

                var expectedFullName = new FullName(schema, mappedEntityType.Name);

                if (domainModel.EntityByFullName.TryGetValue(expectedFullName, out var entity))
                {
                    (entity as dynamic).NHibernateEntityType = mappedEntityType;
                }
                else
                {
                    _logger.Warn($"Unable to locate entity '{expectedFullName}' for NHibernate entity type '{mappedEntityType.FullName}'. .NET Type will not be available on the entity in the model.");
                }
            }
        }
    }
}
