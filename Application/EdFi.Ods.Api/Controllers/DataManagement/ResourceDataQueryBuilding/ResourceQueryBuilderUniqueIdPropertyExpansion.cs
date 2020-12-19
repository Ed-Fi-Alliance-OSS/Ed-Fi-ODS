// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Dapper;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourceDataQueryBuilding
{
    public class ResourceQueryBuilderUniqueIdPropertyExpansion : IResourceQueryBuilderPropertyExpansion
    {
        public void Process(ResourceClassBase resourceClass, string resourceAlias, SqlBuilder sqlBuilder, AliasGenerator aliasGenerator)
        {
            // Process UniqueIds
            var uniqueIdProperties = resourceClass.AllProperties.Where(p => !p.IsInherited)
                .Where(p => IsUniqueId(p) && !IsDefiningUniqueId(p));

            foreach (var uniqueIdProperty in uniqueIdProperties)
            {
                string personType = UniqueIdSpecification.GetUniqueIdPersonType(uniqueIdProperty.PropertyName);

                string personAlias = aliasGenerator.GetNextAlias();

                string join =
                    $"edfi.{personType} AS {personAlias} ON {resourceAlias}.{uniqueIdProperty.EntityProperty.PropertyName} = {personAlias}.{personType}USI";

                sqlBuilder.Select($"{personAlias}.{personType}UniqueId AS {uniqueIdProperty.PropertyName}");

                if (uniqueIdProperty.PropertyType.IsNullable)
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

            bool IsDefiningUniqueId(ResourceProperty property)
            {
                return UniqueIdSpecification.IsUniqueId(property.PropertyName)
                    && PersonEntitySpecification.IsPersonEntity(resourceClass.Name);
            }
        }
    }
}
