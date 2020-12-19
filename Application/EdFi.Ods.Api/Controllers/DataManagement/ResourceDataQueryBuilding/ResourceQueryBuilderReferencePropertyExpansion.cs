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
    public class ResourceQueryBuilderReferencePropertyExpansion : IResourceQueryBuilderPropertyExpansion
    {
        public void Process(ResourceClassBase resourceClass, string resourceAlias, SqlBuilder sqlBuilder, AliasGenerator aliasGenerator)
        {
            // Process joins for references from this entity/class only (for identifying properties and resource Ids)
            foreach (var reference in resourceClass.References.Where(r => !r.IsInherited))
            {
                string referenceAlias = aliasGenerator.GetNextAlias();

                string join;

                if (reference.Association.OtherEntity.IsDerived)
                {
                    string joinCriteria = string.Join(
                        " AND ",
                        reference.Association.PropertyMappings.Select(
                            (pm, i)
                                => $"{resourceAlias}.{pm.ThisProperty.PropertyName} = {referenceAlias}.{reference.Association.OtherEntity.BaseAssociation.PropertyMappingByThisName[pm.OtherProperty.PropertyName].OtherProperty.PropertyName}"));

                    @join = $"{reference.Association.OtherEntity.BaseEntity.FullName} AS {referenceAlias} ON {joinCriteria}";

                    sqlBuilder.Select($"{referenceAlias}.Id AS {reference.PropertyName}_Id");
                    sqlBuilder.Select($"{referenceAlias}.Discriminator AS {reference.PropertyName}_Discriminator");
                }
                else
                {
                    string joinCriteria = string.Join(
                        " AND ",
                        reference.Association.PropertyMappings.Select(
                            pm
                                => $"{resourceAlias}.{pm.ThisProperty.PropertyName} = {referenceAlias}.{pm.OtherProperty.PropertyName}"));

                    @join = $"{reference.Association.OtherEntity.FullName} AS {referenceAlias} ON {joinCriteria}";

                    sqlBuilder.Select($"{referenceAlias}.Id AS {reference.PropertyName}_Id");

                    if (reference.Association.OtherEntity.IsBase)
                    {
                        sqlBuilder.Select($"{referenceAlias}.Discriminator AS {reference.PropertyName}_Discriminator");
                    }
                }

                if (reference.IsRequired)
                {
                    sqlBuilder.InnerJoin(join);
                }
                else
                {
                    sqlBuilder.LeftJoin(join);
                }
            }
        }
    }
}
