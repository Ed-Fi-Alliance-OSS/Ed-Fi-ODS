// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public class TrackedChangesIdentifierProjectionsProvider : ITrackedChangesIdentifierProjectionsProvider
    {
        private readonly IDatabaseNamingConvention _namingConvention;

        public TrackedChangesIdentifierProjectionsProvider(IDatabaseNamingConvention namingConvention)
        {
            _namingConvention = namingConvention;
        }

        private readonly ConcurrentDictionary<FullName, QueryProjection[]> _queryProjectionsByResourceFullName =
            new ConcurrentDictionary<FullName, QueryProjection[]>();

        public QueryProjection[] GetIdentifierProjections(Resource resource)
        {
            return _queryProjectionsByResourceFullName.GetOrAdd(resource.FullName, 
                _ => CreateIdentifierProjections(resource));
        }
        
        private QueryProjection[] CreateIdentifierProjections(Resource resource)
        {
            var entity = resource.Entity;
            
            var projections = resource
                .IdentifyingProperties
                .Select(
                    rp =>
                    {
                        var changeTableJoinProperty = (entity.IsDerived ? rp.EntityProperty.BaseProperty : rp.EntityProperty);

                        return new QueryProjection
                        {
                            JsonPropertyName = rp.JsonPropertyName,
                            SelectColumns = GetSelectColumns(rp).ToArray(),
                            IsDescriptorUsage = rp.IsDescriptorUsage,

                            // Columns for performing join to source table (if necessary)
                            ChangeTableJoinColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeTableJoinProperty.PropertyName}"),
                            SourceTableJoinColumnName = _namingConvention.ColumnName(rp.EntityProperty),
                        };
                    })
                .ToArray();

            return projections;
            
            IEnumerable<SelectColumn> GetSelectColumns(ResourceProperty resourceProperty)
            {
                var entityProperty = resourceProperty.EntityProperty;

                // This handles usages of DescriptorIds and USIs
                if (entityProperty.IsSurrogateIdentifierUsage())
                {
                    string[] SplitTerms(string text) => Regex.Matches(text, "([A-Z][^A-Z]+|[A-Z]+(?![^A-Z]))").SelectMany(m => m.Captures.Select(c => c.Value)).ToArray();
                    string[] TrimFinalTerm(string[] terms) => terms.Take(terms.Length - 1).ToArray(); 
                        
                    var allTerms = SplitTerms(entityProperty.PropertyName);
                    var baseTerms = TrimFinalTerm(allTerms);
                    
                    // For Descriptors, this returns Namespace/CodeValue, for Student/Staff/Parent it returns the UniqueId
                    var naturalIdentifyingProperties = entityProperty.DefiningProperty.Entity.NaturalIdentifyingProperties();

                    foreach (var naturalIdentifyingProperty in naturalIdentifyingProperties)
                    {
                        var naturalTerms = SplitTerms(naturalIdentifyingProperty.PropertyName);

                        var changeQueryColumnName = 
                            string.Join(string.Empty, baseTerms.TakeWhile(t => t != naturalTerms[0]).Concat(naturalTerms));

                        yield return new SelectColumn
                        {
                            ColumnGroup = ColumnGroups.OldValue,
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeQueryColumnName}"),
                            JsonPropertyName = changeQueryColumnName.ToCamelCase(),
                        };

                        yield return new SelectColumn
                        {
                            ColumnGroup = ColumnGroups.NewValue,
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{changeQueryColumnName}"),
                            JsonPropertyName = changeQueryColumnName.ToCamelCase(),
                        };
                    }

                    yield break;
                }

                // Handle identifying properties that are surrogate ids by performing column expansion to use the alternate identifier
                // (e.g. Student/Staff/Parent USI -> UniqueId, concrete Descriptors -> Namespace, CodeValue)
                if (entityProperty.IsSurrogateIdentifier())
                {
                    var naturalIdentifyingProperties = entityProperty.Entity.NaturalIdentifyingProperties();

                    foreach (var naturalIdentifyingProperty in naturalIdentifyingProperties)
                    {
                        yield return new SelectColumn
                        {
                            ColumnGroup = ColumnGroups.OldValue,
                            ColumnName = _namingConvention.ColumnName(
                                $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),

                            JsonPropertyName = naturalIdentifyingProperty.PropertyName.ToCamelCase(),
                        };

                        yield return new SelectColumn
                        {
                            ColumnGroup = ColumnGroups.NewValue,
                            ColumnName = _namingConvention.ColumnName(
                                $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),

                            JsonPropertyName = naturalIdentifyingProperty.PropertyName.ToCamelCase(),
                        };
                    }
                    
                    yield break;
                }
             
                if (IsDerivedFromEntityWithDiscriminator(entityProperty.Entity))
                {
                    yield return new SelectColumn
                    {
                        ColumnGroup = ColumnGroups.OldValue,
                        ColumnName = _namingConvention.ColumnName(
                            $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),

                        JsonPropertyName = resourceProperty.JsonPropertyName,
                    };

                    yield return new SelectColumn
                    {
                        ColumnGroup = ColumnGroups.NewValue,
                        ColumnName = _namingConvention.ColumnName(
                            $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),

                        JsonPropertyName = resourceProperty.JsonPropertyName,
                    };

                    yield break;
                }

                // Just return the raw columns
                yield return new SelectColumn
                {
                    ColumnGroup = ColumnGroups.OldValue,
                    ColumnName = _namingConvention.ColumnName(
                        $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.PropertyName}"),

                    JsonPropertyName = resourceProperty.JsonPropertyName,
                };

                yield return new SelectColumn
                {
                    ColumnGroup = ColumnGroups.NewValue,
                    ColumnName = _namingConvention.ColumnName(
                        $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.PropertyName}"),

                    JsonPropertyName = resourceProperty.JsonPropertyName,
                };
            }
            
            bool IsDerivedFromEntityWithDiscriminator(Entity entity) => entity.BaseEntity?.HasDiscriminator() == true;
        }
    }
}
