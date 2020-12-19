// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Dapper;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourceDataQueryBuilding
{
    public class ResourceQueryBuilderDescriptorPropertyExpansion : IResourceQueryBuilderPropertyExpansion
    {
        public void Process(ResourceClassBase resourceClass, string resourceAlias, SqlBuilder sqlBuilder, AliasGenerator aliasGenerator)
        {
            // Process descriptors (from this entity/resource class only)
            var descriptorProperties = resourceClass.AllProperties.Where(p => !p.IsInherited).Where(p => p.IsLookup);

            foreach (var descriptorProperty in descriptorProperties)
            {
                string descriptorAlias = aliasGenerator.GetNextAlias();

                // var lookupEntityFullName = descriptorProperty.EntityProperty.LookupEntity.FullName;
                // string otherDescriptorId = descriptorProperty.EntityProperty.LookupEntity.Identifier.Properties.Single().PropertyName;

                string thisDescriptorId = descriptorProperty.EntityProperty.PropertyName;

                string join =
                    $"edfi.Descriptor AS {descriptorAlias} ON {resourceAlias}.{thisDescriptorId} = {descriptorAlias}.DescriptorId";

                sqlBuilder.Select($"{descriptorAlias}.Namespace AS {descriptorProperty.PropertyName}_Namespace");
                sqlBuilder.Select($"{descriptorAlias}.CodeValue AS {descriptorProperty.PropertyName}_CodeValue");

                if (descriptorProperty.PropertyType.IsNullable)
                {
                    sqlBuilder.LeftJoin(join);
                }
                else
                {
                    sqlBuilder.InnerJoin(join);
                }
            }
        }
    }
}
