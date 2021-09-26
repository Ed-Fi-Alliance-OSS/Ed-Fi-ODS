using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Generator.Database.NamingConventions;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public abstract class TrackedChangesQueryTemplateProviderBase
    {
        private readonly IDatabaseNamingConvention _namingConvention;

        private readonly ConcurrentDictionary<FullName, QueryMetadata> _queryMetadataByResourceName =
            new ConcurrentDictionary<FullName, QueryMetadata>();

        protected TrackedChangesQueryTemplateProviderBase(IDatabaseNamingConvention namingConvention)
        {
            _namingConvention = namingConvention;
        }
        
        public Query GetTemplateQuery(Resource resource)
        {
            // Optimize by caching the constructed query
            var queryMetadata = _queryMetadataByResourceName.GetOrAdd(
                resource.FullName,
                (fn) => CreateTemplateQuery(resource));

            return queryMetadata.TemplateQuery;
        }
        
        public QueryProjection[] GetIdentifierProjections(Resource resource)
        {
            // Optimize by caching the constructed query
            var queryMetadata = _queryMetadataByResourceName.GetOrAdd(
                resource.FullName,
                (fn) => CreateTemplateQuery(resource));

            return queryMetadata.Projections;
        }
        
        private QueryMetadata CreateTemplateQuery(Resource resource)
        {
            var entity = resource.Entity;
            
            var identifierProjections = CreateIdentifierProjections();

            var (changeTableSchema, changeTableName) = entity.IsDerived
                ? (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + _namingConvention.Schema(entity.BaseEntity), _namingConvention.TableName(entity.BaseEntity)) 
                : (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + _namingConvention.Schema(entity), _namingConvention.TableName(entity));

            var templateQuery = new Query($"{changeTableSchema}.{changeTableName} AS {ChangeQueriesDatabaseConstants.TrackedChangesAlias}");

            templateQuery.Select($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Id")}", $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}");
            
            SelectIdentifyingColumns();

            templateQuery.OrderBy($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}");

            ApplyDiscriminatorCriteriaForDerivedEntities();

            ApplyScenarioSpecificFilters(templateQuery, entity, identifierProjections);

            return new QueryMetadata
            {
                TemplateQuery = templateQuery,
                Projections = identifierProjections
            };

            void SelectIdentifyingColumns()
            {
                string[] selectColumns = identifierProjections.SelectMany(x => x.SelectColumns)
                    .Select(sc => $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{sc.ColumnName}")
                    .ToArray();

                templateQuery.Select(selectColumns);
            }

            void ApplyDiscriminatorCriteriaForDerivedEntities()
            {
                // Add discriminator criteria, for derived types with a Discriminator on the base type only
                if (entity.IsDerived)
                {
                    templateQuery.Where($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Discriminator")}", entity.FullName.ToString());
                }
            }

            QueryProjection[] CreateIdentifierProjections()
            {
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

                                // Columns for performing join to source table
                                ChangeTableJoinColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeTableJoinProperty}"),
                                SourceTableJoinColumnName = _namingConvention.ColumnName(rp.EntityProperty),
                            };
                        })
                    .ToArray();

                return projections;
            }
            
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
                    
                    // For Descriptors, this returns Namespace/CodeValue, for Student/Staff/Parent is returns the UniqueId
                    var naturalIdentifyingProperties = entityProperty.DefiningProperty.Entity.NaturalIdentifyingProperties();

                    foreach (var naturalIdentifyingProperty in naturalIdentifyingProperties)
                    {
                        var naturalTerms = SplitTerms(naturalIdentifyingProperty.PropertyName);

                        var changeQueryColumnName = 
                            string.Join(string.Empty, baseTerms.TakeWhile(t => t != naturalTerms[0]).Concat(naturalTerms));
                        
                        yield return new SelectColumn
                        {
                            ColumnGroup = ColumnGroup.OldValue,
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeQueryColumnName}"),
                            // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeQueryColumnName}"),
                            JsonPropertyName = changeQueryColumnName.ToCamelCase(),
                        };
                        
                        yield return new SelectColumn
                        {
                            ColumnGroup = ColumnGroup.NewValue,
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{changeQueryColumnName}"),
                            // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{changeQueryColumnName}"),
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
                            ColumnGroup = ColumnGroup.OldValue,
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            JsonPropertyName = naturalIdentifyingProperty.PropertyName.ToCamelCase(),
                        };
                        
                        // NEW value
                        yield return new SelectColumn
                        {
                            ColumnGroup = ColumnGroup.NewValue,
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            JsonPropertyName = naturalIdentifyingProperty.PropertyName.ToCamelCase(),
                        };
                    }
                    
                    yield break;
                }
             
                if (IsDerivedFromEntityWithDiscriminator(entityProperty.Entity))
                {
                    yield return new SelectColumn
                    {
                        ColumnGroup = ColumnGroup.OldValue,
                        ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        JsonPropertyName = resourceProperty.JsonPropertyName,
                    };
                    
                    yield return new SelectColumn
                    {
                        ColumnGroup = ColumnGroup.NewValue,
                        ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        JsonPropertyName = resourceProperty.JsonPropertyName,
                    };
                    
                    yield break;
                }

                // Just return the column
                yield return new SelectColumn
                {
                    ColumnGroup = ColumnGroup.OldValue,
                    ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    JsonPropertyName = resourceProperty.JsonPropertyName,
                };

                yield return new SelectColumn
                {
                    ColumnGroup = ColumnGroup.NewValue,
                    ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    // ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    JsonPropertyName = resourceProperty.JsonPropertyName,
                };
            }
            
            bool IsDerivedFromEntityWithDiscriminator(Entity entity) => entity.BaseEntity?.HasDiscriminator() == true;
        }

        protected abstract void ApplyScenarioSpecificFilters(
            Query templateQuery,
            Entity entity,
            QueryProjection[] identifierProjections);
        
        private class QueryMetadata
        {
            public Query TemplateQuery { get; set; }
            public QueryProjection[] Projections { get; set; } 
        }
    }
}