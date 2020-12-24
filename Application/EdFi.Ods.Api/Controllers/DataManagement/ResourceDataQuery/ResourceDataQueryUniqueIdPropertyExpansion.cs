// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourceDataQuery
{
    public class ResourceDataQueryUniqueIdPropertyExpansion : IResourceDataQueryPropertyExpansion
    {
        private readonly IPhysicalNamesProvider _physicalNamesProvider;

        public ResourceDataQueryUniqueIdPropertyExpansion(IPhysicalNamesProvider physicalNamesProvider)
        {
            _physicalNamesProvider = physicalNamesProvider;
        }
        
        public void Process(ResourceClassBase resourceClass, string resourceAlias, SqlBuilder sqlBuilder, AliasGenerator aliasGenerator)
        {
            // Process UniqueIds
            var uniqueIdProperties = resourceClass.AllProperties
                .Where(p => !p.IsInherited)
                .Where(p => IsUniqueId(p) && !IsDefiningUniqueId(p));

            foreach (var resourceUniqueIdProperty in uniqueIdProperties)
            {
                var personUsiProperty = resourceUniqueIdProperty.EntityProperty.DefiningProperty;
                var personEntity = personUsiProperty.Entity;
                
                if (!personEntity.PropertyByName.TryGetValue($"{personEntity.Name}UniqueId", out var personUniqueIdProperty))
                {
                    throw new Exception($"Unable to find UniqueId property on entity '{personEntity.FullName}' using expected naming convention.");
                }

                string personAlias = aliasGenerator.GetNextAlias();

                string join =
                    $"{_physicalNamesProvider.FullName(personEntity)} AS {personAlias} ON {resourceAlias}.{resourceUniqueIdProperty.EntityProperty.PropertyName} = {personAlias}.{_physicalNamesProvider.Column(personUsiProperty)}";

                sqlBuilder.Select($"{personAlias}.{_physicalNamesProvider.Column(personUniqueIdProperty)} AS {_physicalNamesProvider.Column(resourceUniqueIdProperty.EntityProperty)}");

                if (resourceUniqueIdProperty.PropertyType.IsNullable)
                {
                    sqlBuilder.LeftJoin(join);
                }
                else
                {
                    sqlBuilder.InnerJoin(join);
                }
            }
            
            bool IsUniqueId(ResourceProperty property)
            {
                return UniqueIdSpecification.IsUniqueId(property.PropertyName);
            }

            bool IsDefiningUniqueId(ResourceProperty resourceProperty)
            {
                return 
                    // Resource property is on a Person entity
                    resourceProperty.EntityProperty.Entity.IsPersonEntity()
                    // Resource property is treated as identifying on the resource model
                    && resourceProperty.IsIdentifying;
            }
        }
    }
}
