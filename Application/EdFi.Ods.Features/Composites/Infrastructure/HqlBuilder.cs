// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Dapper;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using log4net;

namespace EdFi.Ods.Features.Composites.Infrastructure
{
    public class HqlBuilder : ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>
    {
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;
        
        private const string BaseEntityIdName = "__BaseEntityId__";

        private static readonly Dictionary<string, string> RangeOperatorBySymbol = new Dictionary<string, string>
        {
            {"[", ">="},
            {"{", ">"},
            {"]", "<="},
            {"}", "<"}
        };

        // Support date and numeric ranges (e.g. [2016-05-23..2016-06-30])
        private static readonly Regex _rangeRegex = new Regex(
            @"(?<PropertyName>\w+):(?<BeginRangeSymbol>[\[\{])((?<BeginValue>[0-9]{4}-[0-9]{1,2}-[0-9]{1,2})(\.\.\.|\.\.|…)(?<EndValue>[0-9]{4}-[0-9]{1,2}-[0-9]{1,2})|(?<BeginValue>[0-9\.]+?)(\.\.\.|\.\.|…)(?<EndValue>[0-9\.]+?))(?<EndRangeSymbol>[\}\]])",
            RegexOptions.Compiled);

        private readonly ILog _logger = LogManager.GetLogger(typeof(HqlBuilder));
        private readonly IResourceJoinPathExpressionProcessor _resourceJoinPathExpressionProcessor;

        public HqlBuilder(
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IResourceJoinPathExpressionProcessor resourceJoinPathExpressionProcessor
            )
        {
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;

            _resourceJoinPathExpressionProcessor = Preconditions.ThrowIfNull(
                resourceJoinPathExpressionProcessor,
                nameof(resourceJoinPathExpressionProcessor));
        }

        /// <summary>
        /// Applies the composite resource's root resource to the build result using the supplied builder context.
        /// </summary>
        /// <param name="processorContext"></param>
        /// <param name="builderContext">The builder context.</param>
        public void ApplyRootResource(CompositeDefinitionProcessorContext processorContext, HqlBuilderContext builderContext)
        {
            var resource = (Resource) processorContext.CurrentResourceClass;

            builderContext.CurrentAlias = builderContext.AliasGenerator.GetNextAlias();

            builderContext.SpecificationFrom = new StringBuilder();
            builderContext.SpecificationWhere = new StringBuilder();

            builderContext.From.Append(
                $"\r\n\t{resource.Entity.Schema}.{resource.Entity.Name} AS {builderContext.CurrentAlias}");

            // Add the selection of the main query Id
            if (resource.IdentifyingProperties.Count > 1)
            {
                builderContext.Select.Append($"{builderContext.CurrentAlias}.Id As {BaseEntityIdName}");
            }
            else
            {
                builderContext.Select.Append(
                    $"{builderContext.CurrentAlias}.{resource.Entity.Identifier.Properties.Single()} As {BaseEntityIdName}");
            }

            if (builderContext.FilterCriteria.Count > 0)
            {
                // Process specification parameters
                foreach (var kvp in builderContext.FilterCriteria)
                {
                    string key = kvp.Key;
                    object value = kvp.Value.Value;
                    string filterJoinPath = kvp.Value.FilterPath;

                    string thisFilterJoinAlias = builderContext.CurrentAlias;

                    string parentFilterJoinAlias = thisFilterJoinAlias;

                    // Assumption: "id" in the filter criteria represents a GetById pattern in the route.
                    if (key.EqualsIgnoreCase("id"))
                    {
                        builderContext.IsSingleItemResult = true;
                    }

                    _resourceJoinPathExpressionProcessor.ProcessPath(
                        resource,
                        kvp.Key,
                        filterJoinPath,
                        (prop, pathPart) =>
                        {
                            parentFilterJoinAlias = thisFilterJoinAlias;

                            // Add property to where clause
                            string parameterName = key.Replace(".", "_");

                            builderContext.SpecificationWhere.Append(
                                $"{AndIfNeeded(builderContext.SpecificationWhere)}{parentFilterJoinAlias}.{pathPart} = @{parameterName}");

                            builderContext.ParameterValueByName.Add(parameterName, value);
                        },
                        (reference, pathPart) =>
                        {
                            parentFilterJoinAlias = thisFilterJoinAlias;

                            // Add a join
                            thisFilterJoinAlias = builderContext.AliasGenerator.GetNextAlias();

                            builderContext.SpecificationFrom.Append(
                                // $"\r\n\tinner join {parentFilterJoinAlias}.{reference.Association.Name} AS {thisFilterJoinAlias}");
                                $"\r\n\tinner join {reference.Association.OtherEntity.Schema}.{reference.Association.OtherEntity.Name} AS {thisFilterJoinAlias}"
                                + $" ON {CreateJoinCriteria(reference.Association, parentFilterJoinAlias, thisFilterJoinAlias)}");
                        },
                        (collection, pathPart) =>
                        {
                            parentFilterJoinAlias = thisFilterJoinAlias;
                            builderContext.NeedDistinct = true;

                            // Add a join
                            thisFilterJoinAlias = builderContext.AliasGenerator.GetNextAlias();

                            builderContext.SpecificationFrom.Append(
                                $"\r\n\tinner join {collection.Association.OtherEntity.Schema}.{collection.Association.OtherEntity.Name} AS {thisFilterJoinAlias}"
                                + $" ON {CreateJoinCriteria(collection.Association, parentFilterJoinAlias, thisFilterJoinAlias)}");
                        },
                        (linkedCollection, pathPart) =>
                        {
                            parentFilterJoinAlias = thisFilterJoinAlias;
                            builderContext.NeedDistinct = true;

                            // Add a join
                            thisFilterJoinAlias = builderContext.AliasGenerator.GetNextAlias();

                            builderContext.SpecificationFrom.Append(
                                $"\r\n\tinner join {linkedCollection.Association.OtherEntity.Schema}.{linkedCollection.Association.OtherEntity.Name} AS {thisFilterJoinAlias}"
                                + $" ON {CreateJoinCriteria(linkedCollection.Association, parentFilterJoinAlias, thisFilterJoinAlias)}");
                        },
                        (embeddedObject, pathPart) =>
                        {
                            parentFilterJoinAlias = thisFilterJoinAlias;

                            // Add a join
                            thisFilterJoinAlias = builderContext.AliasGenerator.GetNextAlias();

                            builderContext.SpecificationFrom.Append(
                                $"\r\n\tinner join {embeddedObject.Association.OtherEntity.Schema}.{embeddedObject.Association.OtherEntity.Name} AS {thisFilterJoinAlias}"
                                + $" ON {CreateJoinCriteria(embeddedObject.Association, parentFilterJoinAlias, thisFilterJoinAlias)}");
                        });
                }
            }

            if (builderContext.QueryStringParameters.Any())
            {
                object queryExpressionObject;

                if (builderContext.QueryStringParameters.TryGetValue(SpecialQueryStringParameters.Q, out queryExpressionObject))
                {
                    ProcessQueryExpressions(builderContext, processorContext, queryExpressionObject.ToString());
                }

                ProcessQueryStringParameters(builderContext, processorContext);

                // Perform root level processing related to GetById and GetByKey request patterns
                builderContext.IsSingleItemResult =
                    processorContext.CurrentResourceClass.IsSingleItemRequest(GetCriteriaQueryStringParameters(builderContext));
            }
        }

        private string CreateJoinCriteria(AssociationView association, string parentJoinAlias, string thisJoinAlias)
        {
            return string.Join(" AND ", association.PropertyMappings.Select(
                pm
                    => $"{parentJoinAlias}.{pm.ThisProperty.PropertyName} = {thisJoinAlias}.{pm.OtherProperty.PropertyName}"));
        }

        private string CreateJoinCriteria(string parentJoinAlias, string thisJoinAlias, params PropertyMapping[] propertyMappings)
        {
            return string.Join(" AND ", propertyMappings.Select(
                pm
                    => $"{parentJoinAlias}.{pm.ThisProperty.PropertyName} = {thisJoinAlias}.{pm.OtherProperty.PropertyName}"));
        }

        public void ApplyChildResource(HqlBuilderContext builderContext, CompositeDefinitionProcessorContext processorContext)
        {
            builderContext.CurrentAlias = builderContext.AliasGenerator.GetNextAlias();

            builderContext.From.Append(
                $"\r\n\tinner join {processorContext.JoinAssociation.OtherEntity.Schema}.{processorContext.JoinAssociation.OtherEntity.Name} AS {builderContext.CurrentAlias}"
                + $" ON {CreateJoinCriteria(processorContext.JoinAssociation, builderContext.ParentAlias, builderContext.CurrentAlias)}");

            var collection = processorContext.CurrentResourceMember as Collection;

            if (collection != null && collection.ValueFilters.Length > 0)
            {
                StringBuilder filterWhere = new StringBuilder();

                foreach (var valueFilter in collection.ValueFilters)
                {
                    // TODO: API Simplification - Implement support for collection value filtering
                    // // Get the actual filter to which the property applies
                    // var filterProperty = collection.ItemType.AllPropertyByName[valueFilter.PropertyName];
                    //
                    // string parameterName = builderContext.CurrentAlias
                    //     + "_"
                    //     + valueFilter.PropertyName
                    //     + "_"
                    //     + (valueFilter.FilterMode == ItemFilterMode.ExcludeOnly
                    //         ? "0"
                    //         : "1");

                    // Set the filter values
                    // object parametersAsObject;

                    // ------------------------------------------------------------------------
                    // TODO: API Simplification - Need to replace use of descriptor cache here
                    // ------------------------------------------------------------------------
                    // Is this a first time parameter value assignment?
                    // if (!builderContext.CurrentQueryFilterParameterValueByName.TryGetValue(parameterName, out parametersAsObject))
                    // {
                    //     // Process filters into the query
                    //     filterWhere.Append(
                    //         $"{OrIfNeeded(filterWhere)}{builderContext.CurrentAlias}.{valueFilter.PropertyName}Id {(valueFilter.FilterMode == ItemFilterMode.ExcludeOnly ? "NOT IN" : "IN")} (@{parameterName})");
                    //
                    //     // Set the parameter values
                    //     builderContext.CurrentQueryFilterParameterValueByName[parameterName] = valueFilter.Values
                    //         .Select(x => _descriptorsCache.GetId(filterProperty.LookupTypeName, x))
                    //         .ToArray();
                    // }
                    // else
                    // {
                    //     // Concatenate the current filter's values to the existing parameter list
                    //     builderContext.CurrentQueryFilterParameterValueByName[parameterName] = (parametersAsObject as int[])
                    //         .Concat(valueFilter.Values.Select(x => _descriptorsCache.GetId(filterProperty.LookupTypeName, x)))
                    //         .ToArray();
                    // }
                    // ------------------------------------------------------------------------
                }

                // Apply all the filters using an AND clause
                builderContext.Where.Append($"{AndIfNeeded(builderContext.Where)}({filterWhere})");
            }
        }

        /// <summary>
        /// Builds a new context from the current builder context for use in processing a flattened reference.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <returns>The new builder context for use in processing a flattened reference.</returns>
        public HqlBuilderContext CreateFlattenedMemberContext(HqlBuilderContext builderContext)
        {
            var flattenedBuilderContext = new HqlBuilderContext(
                builderContext.Select,
                builderContext.From,
                null,
                null,
                null,
                builderContext.CurrentAlias,
                int.MinValue,
                null,
                null,
                null,
                builderContext.AliasGenerator);

            flattenedBuilderContext.PropertyProjections = builderContext.PropertyProjections;

            return flattenedBuilderContext;
        }

        /// <summary>
        /// Applies the provided flattened resource reference to the build result using the suplied builder context.
        /// </summary>
        /// <param name="member">The flattened ReferencedResource or EmbeddedObject to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        public void ApplyFlattenedMember(ResourceMemberBase member, HqlBuilderContext builderContext)
        {
            var downCastedReference = member as Reference;
            var downCastedEmbeddedObject = member as EmbeddedObject;
            var downCastedResourceProperty = member as ResourceProperty;

            var association = downCastedReference != null
                ? downCastedReference.Association
                : downCastedEmbeddedObject.Association;

            // Create a new alias
            builderContext.CurrentAlias = builderContext.AliasGenerator.GetNextAlias();

            // Add the connective HQL join for processing the flattened reference
            builderContext.From.Append(
                $"\r\n\tinner join {association.OtherEntity.Schema}.{association.OtherEntity.Name} AS {builderContext.CurrentAlias}" 
                + $" ON {CreateJoinCriteria(association, builderContext.ParentAlias, builderContext.CurrentAlias)}");
        }

        /// <summary>
        /// Applies the provided flattened resource reference to the build result using the suplied builder context.
        /// </summary>
        /// <param name="locallyDefinedIdentifyingProperties">The list of local identifying properties to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ApplyLocalIdentifyingProperties(
            IReadOnlyList<EntityProperty> locallyDefinedIdentifyingProperties,
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            // Add selects for local PK fields, (Note: May be able to optimize this by only doing this if it has children in composite definition.)
            locallyDefinedIdentifyingProperties.ForEach(
                pk =>
                {
                    string commaIfNeeded = CommaIfNeeded(builderContext.Select);
                    int depth = builderContext.Depth;
                    char depthModifier = (char) (processorContext.ChildIndex + 'a');

                    builderContext.Select.Append(
                        $"{commaIfNeeded}{builderContext.CurrentAlias}.{pk.PropertyName} as PK{depth}{depthModifier}_{pk.PropertyName}");
                });

            // Add ORDER BY for the primary keys
            locallyDefinedIdentifyingProperties.ForEach(
                pk =>
                {
                    string commaIfNeeded = CommaIfNeeded(builderContext.OrderBy);
                    
                    builderContext.OrderBy.Append($"{commaIfNeeded}{builderContext.CurrentAlias}.{pk.PropertyName}");
                });
        }

        /// <summary>
        /// Captures context from the current builder context to be used as the baseline for processing children
        /// while allowing additional changes to be made to the current context.
        /// </summary>
        /// <seealso cref="CreateParentingContext"/>
        /// <param name="builderContext">The current build context.</param>
        /// <remarks>Implementations should use this as a means for preserving part of the current
        /// context for future use by storing the snapshotted context within the current context.</remarks>
        public void SnapshotParentingContext(HqlBuilderContext builderContext)
        {
            // Capture the base SELECT, FROM, ORDER BY for subsequent child queries into the current context
            var baseSelect = new StringBuilder(builderContext.Select.ToString());
            var baseFrom = new StringBuilder(builderContext.From.ToString());
            var baseWhere = new StringBuilder(builderContext.Where.ToString());
            var baseOrderBy = new StringBuilder(builderContext.OrderBy.ToString());

            var snapshotContext = new HqlBuilderContext(baseSelect, baseFrom, baseWhere, baseOrderBy);

            builderContext.ParentingContext = snapshotContext;
        }

        /// <summary>
        /// Creates a new builder context by applying previously snapshotted parental context.
        /// </summary>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns>The new builder context to be used for child processing.</returns>
        public HqlBuilderContext CreateParentingContext(HqlBuilderContext builderContext)
        {
            return new HqlBuilderContext(
                builderContext.ParentingContext.Select,
                builderContext.ParentingContext.From,
                builderContext.ParentingContext.Where,
                builderContext.ParentingContext.OrderBy,
                builderContext.ParameterValueByName,
                builderContext.CurrentAlias,
                builderContext.Depth,
                builderContext.FilterCriteria,
                builderContext.QueryStringParameters,
                builderContext.QueryRangeParameters,
                builderContext.AliasGenerator);
        }

        /// <summary>
        /// Creates a new builder context to be used for processing a child element.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent context to be used to derive the new child context.</param>
        /// <param name="childProcessorContext"></param>
        /// <returns>The new builder context.</returns>
        public HqlBuilderContext CreateChildContext(
            HqlBuilderContext parentingBuilderContext,
            CompositeDefinitionProcessorContext childProcessorContext)
        {
            return new HqlBuilderContext(
                new StringBuilder(parentingBuilderContext.Select.ToString()),
                new StringBuilder(parentingBuilderContext.From.ToString()),
                new StringBuilder(parentingBuilderContext.Where.ToString()),
                new StringBuilder(parentingBuilderContext.OrderBy.ToString()),
                parentingBuilderContext.ParameterValueByName,
                parentingBuilderContext.ParentAlias,
                parentingBuilderContext.Depth + 1,
                parentingBuilderContext.FilterCriteria,
                parentingBuilderContext.QueryStringParameters,
                parentingBuilderContext.QueryRangeParameters,
                parentingBuilderContext.AliasGenerator);
        }

        /// <summary>
        /// Creates a new builder context to be used for processing a flattened reference.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent builder context.</param>
        /// <returns>The new builder context.</returns>
        public HqlBuilderContext CreateFlattenedReferenceChildContext(HqlBuilderContext parentingBuilderContext)
        {
            return new HqlBuilderContext(
                parentingBuilderContext.Select,
                parentingBuilderContext.From,
                parentingBuilderContext.Where,
                parentingBuilderContext.OrderBy,
                parentingBuilderContext.ParameterValueByName,
                parentingBuilderContext.CurrentAlias,
                parentingBuilderContext.Depth,
                parentingBuilderContext.FilterCriteria,
                parentingBuilderContext.QueryStringParameters,
                parentingBuilderContext.QueryRangeParameters,
                parentingBuilderContext.AliasGenerator);
        }

        /// <summary>
        /// Applies processing related to the usage/entry to another top-level resource (e.g. applying authorization concerns).
        /// </summary>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns><b>true</b> if the resource can be processed; otherwise <b>false</b>.</returns>
        public bool TryIncludeResource(CompositeDefinitionProcessorContext processorContext, HqlBuilderContext builderContext)
        {
            return true;
        }

        /// <summary>
        /// Apply the provided property projections onto the build result with the provided builder and composite
        /// definition processor contexts.
        /// </summary>
        /// <param name="propertyProjections">A list of property projections to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ProjectProperties(
            IReadOnlyList<CompositePropertyProjection> propertyProjections,
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            if (builderContext.PropertyProjections == null)
            {
                builderContext.PropertyProjections = new List<CompositePropertyProjection>();
            }

            // in the case where we have an abstract reference, we add the discriminator to the query
            if (processorContext.ShouldIncludeResourceSubtype())
            {
                string discriminatorDisplayName = processorContext.CurrentResourceClass.Name.ToCamelCase() + "Type";

                string commaIfNeeded = CommaIfNeeded(builderContext.Select);

                builderContext.Select.Append(
                    $"{commaIfNeeded}{builderContext.CurrentAlias}.Discriminator as {discriminatorDisplayName}__PassThrough");
            }

            propertyProjections.ForEach(
                p =>
                {
                    builderContext.PropertyProjections.Add(p);

                    if (p.ResourceProperty.EntityProperty.IsLookup)
                    {
                        string lookupAlias = builderContext.AliasGenerator.GetNextAlias();
                        string commaIfNeeded = CommaIfNeeded(builderContext.Select);
                        string namespaceColumnAlias = p.DisplayName.ToCamelCase() ?? p.ResourceProperty.PropertyName.ToCamelCase();

                        builderContext.Select.Append(
                            $"{commaIfNeeded}{lookupAlias}.Namespace as {namespaceColumnAlias}__Namespace");

                        string columnIfNeeded2 = CommaIfNeeded(builderContext.Select);
                        string codeValueAlias = p.DisplayName.ToCamelCase() ?? p.ResourceProperty.PropertyName.ToCamelCase();

                        builderContext.Select.Append($"{columnIfNeeded2}{lookupAlias}.CodeValue as {codeValueAlias}");

                        var descriptorEntity = p.ResourceProperty.EntityProperty.LookupEntity.BaseEntity;

                        builderContext.From.Append(
                            $"\r\n\t\tleft join {descriptorEntity.Schema}.{descriptorEntity.Name} AS {lookupAlias}"
                            + $" ON {CreateJoinCriteria(builderContext.CurrentAlias, lookupAlias, new PropertyMapping(p.ResourceProperty.EntityProperty, descriptorEntity.Identifier.Properties.Single()))}");
                    }
                    else
                    {
                        string commaIfNeeded = CommaIfNeeded(builderContext.Select);

                        string columnName = p.ResourceProperty.EntityProperty.PropertyName;
                        string columnAlias = p.DisplayName.ToCamelCase() ?? p.ResourceProperty.EntityProperty.PropertyName.ToCamelCase();

                        builderContext.Select.Append(
                            $"{commaIfNeeded}{builderContext.CurrentAlias}.{columnName} as {columnAlias}");
                    }
                });
        }

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="rootCompositeQuery">The root composite query, if any records could be found.</param>
        /// <returns><b>true</b> if the root/base query returned records; otherwise <b>false</b>.</returns>
        public bool TryBuildForRootResource(
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext,
            out CompositeQuery rootCompositeQuery)
        {
            rootCompositeQuery = null;

            // If this is the main query, execute the query and get the Ids and use as criteria for child queries.
            string hql = "select "
                + (builderContext.NeedDistinct
                    ? "distinct "
                    : string.Empty)
                + "\r\n\t"
                + builderContext.Select
                + "\r\nfrom "
                + builderContext.From
                + builderContext.SpecificationFrom
                + (builderContext.SpecificationWhere.Length > 0 || builderContext.Where.Length > 0
                    ? "\r\nwhere "
                    + builderContext.SpecificationWhere
                    + ConnectingAndIfNeeded(builderContext.SpecificationWhere, builderContext.Where)
                    + builderContext.Where
                    : string.Empty)
                + (builderContext.OrderBy.Length > 0
                    ? "\r\norder by " + builderContext.OrderBy
                    : string.Empty);

            if (_logger.IsDebugEnabled)
            {
                object correlationId;

                if (builderContext.QueryStringParameters.TryGetValue(
                    SpecialQueryStringParameters.CorrelationId,
                    out correlationId))
                {
                    _logger.DebugFormat("SQL[{0}]:\r\n{1}", correlationId, hql);
                }
                else
                {
                    _logger.DebugFormat("SQL:\r\n{0}", hql);
                }
            }

            // var session = _sessionFactory.GetCurrentSession();
            // var query = session.CreateQuery(hql);

            object offsetParameterObject = 0;
            object limitParameterObject = 0;

            int limit = 0;
            int offset = 0;

            if (builderContext.QueryStringParameters.TryGetValue("Limit", out limitParameterObject))
            {
                if (!int.TryParse(limitParameterObject.ToString(), out limit))
                {
                    throw new BadRequestException("Invalid limit specified.");
                }
            }

            if (builderContext.QueryStringParameters.TryGetValue("Offset", out offsetParameterObject))
            {
                if (!int.TryParse(offsetParameterObject.ToString(), out offset))
                {
                    throw new BadRequestException("Invalid offset specified.");
                }
            }

            int actualLimit = (limit == 0)
                ? 25
                : limit;
            
            hql += $" OFFSET {offset} ROWS FETCH NEXT {actualLimit} ROWS ONLY";

            using (var conn = new SqlConnection(_odsDatabaseConnectionStringProvider.GetConnectionString()))
            {
                conn.Open();

                DynamicParameters parameters = new DynamicParameters();
            
                // parameters.AddDynamicParams(builderContext.ParameterValueByName);
                // parameters.AddDynamicParams(builderContext.CurrentQueryFilterParameterValueByName);
                SetQueryParameters(parameters, builderContext.ParameterValueByName);
                SetQueryParameters(parameters, builderContext.CurrentQueryFilterParameterValueByName);

                // SetQueryParameters(query, builderContext.ParameterValueByName);
                // SetQueryParameters(query, builderContext.CurrentQueryFilterParameterValueByName);

                // Append the where clause for Id selection
                // Add the selection of the main query Id
                if (processorContext.CurrentResourceClass.IdentifyingProperties.Count > 1)
                {
                    builderContext.ParentingContext.Where.AppendFormat(
                        "{0}{1}.Id IN @BaseEntityId",
                        AndIfNeeded(builderContext.ParentingContext.Where),
                        builderContext.CurrentAlias);
                }
                else
                {
                    builderContext.ParentingContext.Where.AppendFormat(
                        "{0}{1}.{2} IN @BaseEntityId",
                        AndIfNeeded(builderContext.ParentingContext.Where),
                        builderContext.CurrentAlias,
                        processorContext.CurrentResourceClass.Entity.Identifier.Properties.Single().PropertyName);
                }

                // This is the main/base query, so execute the query and get the Ids and use as criteria for child queries.

                List<IDictionary<string, object>> queryResults = null;

                try
                {
                    var queryResults1 = conn.Query(hql, parameters);

                    queryResults = queryResults1.Cast<IDictionary<string, object>>().ToList();

                    // queryResults = query.SetResultTransformer(Transformers.AliasToEntityMap).List<object>();
                }
                catch (Exception ex)
                {
                    _logger.Error("Query execution failed (likely due to invalid parameter values). ", ex);

                    throw new ArgumentException("Query execution failed (likely due to invalid parameter values).", ex);
                }

                // Get the Ids and assign to the parameters
                var mainQueryIds = queryResults.Cast<IDictionary<string, object>>().Select(ht => ht[BaseEntityIdName]).ToList();

                if (!mainQueryIds.Any())
                {
                    return false;
                }

                builderContext.ParameterValueByName[BaseEntityIdName] = mainQueryIds;

                var thisQuery = new CompositeQuery(
                    processorContext.MemberDisplayName,
                    builderContext.PropertyProjections
                        .Select(x => x.DisplayName.ToCamelCase() ?? x.ResourceProperty.PropertyName.ToCamelCase())
                        .ToArray(),
                    queryResults,
                    builderContext.IsSingleItemResult);

                rootCompositeQuery = thisQuery;

                return true;
            }
        }

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="parentResult">The parent build result, for compositional behavior (if applicable).</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <returns>The build result.</returns>
        public CompositeQuery BuildForChildResource(
            CompositeQuery parentResult,
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            string hql = "select \r\n\t"
                + builderContext.Select
                + "\r\nfrom "
                + builderContext.From
                + (builderContext.Where.Length > 0
                    ? "\r\nwhere " + builderContext.Where
                    : string.Empty)
                + "\r\norder by "
                + builderContext.OrderBy;

            if (_logger.IsDebugEnabled)
            {
                object correlationId;

                if (builderContext.QueryStringParameters.TryGetValue(
                    SpecialQueryStringParameters.CorrelationId,
                    out correlationId))
                {
                    _logger.DebugFormat("SQL[{0}]:\r\n{1}", correlationId, hql);
                }
                else
                {
                    _logger.DebugFormat("SQL:\r\n{0}", hql);
                }
            }

            // var session = _sessionFactory.GetCurrentSession();
            // var query = session.CreateQuery(hql);
            using (var conn = new SqlConnection(_odsDatabaseConnectionStringProvider.GetConnectionString()))
            {
                conn.Open();
                
                object idValues;

                DynamicParameters parameters = new DynamicParameters();
                
                if (builderContext.ParameterValueByName.TryGetValue(BaseEntityIdName, out idValues))
                {
                    parameters.Add("BaseEntityId", idValues as IEnumerable);
                    // _parameterListSetter.SetParameterList(query, "BaseEntityId", idValues as IEnumerable);
                }

                // Apply current query's filter parameters.
                // parameters.AddDynamicParams(builderContext.CurrentQueryFilterParameterValueByName);
                SetQueryParameters(parameters, builderContext.CurrentQueryFilterParameterValueByName);
                // SetQueryParameters(query, builderContext.CurrentQueryFilterParameterValueByName);

                bool isSingleItemResult = processorContext.IsReferenceResource() || processorContext.IsEmbeddedObject();

                var thisQuery = new CompositeQuery(
                    parentResult,
                    processorContext.MemberDisplayName.ToCamelCase(),
                    builderContext.PropertyProjections
                        .Select(x => x.DisplayName.ToCamelCase() ?? x.ResourceProperty.PropertyName.ToCamelCase())
                        .ToArray(),
                    //query.SetResultTransformer(Transformers.AliasToEntityMap).Future<object>(),
                    conn.Query(hql, parameters).Cast<IDictionary<string, object>>(),
                    isSingleItemResult);

                parentResult.ChildQueries.Add(thisQuery);

                return thisQuery;
            }
        }

        private void ProcessQueryStringParameters(
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            // Get all non "special" query string parameter for property value equality processing
            var queryStringParameters = GetCriteriaQueryStringParameters(builderContext);

            foreach (var queryStringParameter in queryStringParameters)
            {
                ResourceProperty targetProperty;

                // TODO: Embedded convention. Types and descriptors at the top level
                if (processorContext.CurrentResourceClass.AllPropertyByName.TryGetValue(
                    queryStringParameter.Key,
                    out targetProperty))
                {
                    string criteriaPropertyName = null;
                    object parameterValue = null;
                    string personType;

                    // Handle Lookup conversions
                    if (targetProperty.IsLookup)
                    {
                        // ---------------------------------------------------------------------------------------------------------------------------------
                        // TODO: API Simplification - Need to eliminate use of descriptor cache here for descriptor criteria, using instead the URI format
                        // ---------------------------------------------------------------------------------------------------------------------------------
                        // var id = _descriptorsCache.GetId(targetProperty.LookupTypeName, (string) queryStringParameter.Value);
                        //
                        // criteriaPropertyName = targetProperty.EntityProperty.PropertyName;
                        // parameterValue = id;
                    }

                    // Handle UniqueId conversions
                    else if (UniqueIdSpecification.TryGetUniqueIdPersonType(targetProperty.PropertyName, out personType))
                    {
                        // ---------------------------------------------------------------------------------------------------------------
                        // TODO: API Simplification - Need to replace use of Person cache here and apply criteria using UniqueId values
                        // ---------------------------------------------------------------------------------------------------------------
                        // int usi = _personUniqueIdToUsiCache.GetUsi(personType, (string) queryStringParameter.Value);
                        //
                        // // TODO: Embedded convention - Convert UniqueId to USI from Resource model to query Entity model on Person entities
                        // // The resource model maps uniqueIds to uniqueIds on the main entity(Student,Staff,Parent)
                        // if (PersonEntitySpecification.IsPersonEntity(targetProperty.ParentFullName.Name))
                        // {
                        //     criteriaPropertyName = targetProperty.EntityProperty.PropertyName.Replace("UniqueId", "USI");
                        // }
                        // else
                        // {
                        //     criteriaPropertyName = targetProperty.EntityProperty.PropertyName;
                        // }
                        //
                        // parameterValue = usi;
                    }
                    else
                    {
                        criteriaPropertyName = targetProperty.PropertyName;
                        parameterValue = ConvertParameterValueForProperty(targetProperty, Convert.ToString(queryStringParameter.Value));
                    }

                    // TODO: API Simplification - This is guard condition to prevent unsupported scenarios from commented sections above from blowing up, and should eventually be removed
                    if (criteriaPropertyName == null || parameterValue == null)
                        return;
                    
                    // Add criteria to the query
                    string andIfNeeded = AndIfNeeded(builderContext.SpecificationWhere);

                    builderContext.SpecificationWhere.Append(
                        $"{andIfNeeded}{builderContext.CurrentAlias}.{criteriaPropertyName} = @{criteriaPropertyName}");

                    if (builderContext.CurrentQueryFilterParameterValueByName.ContainsKey(criteriaPropertyName))
                    {
                        throw new ArgumentException(
                            string.Format(
                                "The value for parameter '{0}' was already assigned and cannot be reassigned using the query string.",
                                criteriaPropertyName));
                    }

                    builderContext.CurrentQueryFilterParameterValueByName[criteriaPropertyName] = parameterValue;
                }
                else
                {
                    ThrowPropertyNotFoundException(queryStringParameter.Key);
                }
            }
        }

        private static List<KeyValuePair<string, object>> GetCriteriaQueryStringParameters(HqlBuilderContext builderContext)
        {
            var queryStringParameters = builderContext.QueryStringParameters
                .Where(p => !SpecialQueryStringParameters.Names.Contains(p.Key))
                .ToList();

            return queryStringParameters;
        }

        private static object ConvertParameterValueForProperty(ResourceProperty targetProperty, object rawValue)
        {
            try
            {
                Type targetType = targetProperty.PropertyType.ToUnderlyingSystemType();

                if (targetType == typeof(Guid))
                {
                    Guid convertedGuid;

                    if (Guid.TryParse(rawValue.ToString(), out convertedGuid))
                    {
                        return convertedGuid;
                    }

                    throw new BadRequestException(
                        $"Invalid query string parameter value provided.  The value for parameter '{targetProperty.PropertyName}' could not be processed as a GUID.");
                }

                var convertedValue = Convert.ChangeType(rawValue, targetType);

                return convertedValue;
            }
            catch (FormatException ex)
            {
                throw new BadRequestException(
                    $"Invalid query string parameter value provided.  The value for parameter '{targetProperty.PropertyName}' could not be processed. {ex.Message}");
            }
        }

        private static void ThrowPropertyNotFoundException(string attemptedPropertyName)
        {
            // Prevent any sort of nefarious injection into the response message, while still providing a helpful message to the caller
            if (Regex.IsMatch(attemptedPropertyName, @"^\w+$"))
            {
                throw new BadRequestException($"The property '{attemptedPropertyName}' does not exist or is not available.");
            }

            throw new BadRequestException("Invalid query string parameter.");
        }

        private static void ProcessQueryExpressions(
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext,
            string queryExpressionText)
        {
            var queryExpressions = queryExpressionText.Split(',');

            int n = 0;

            foreach (var queryExpression in queryExpressions)
            {
                var rangeQueryMatch = _rangeRegex.Match(queryExpression);

                if (!rangeQueryMatch.Success)
                {
                    throw new BadRequestException(
                        "The query filter expression was invalid. Currently, only numeric and date range expressions are supported.");
                }

                string targetPropertyName = rangeQueryMatch.Groups["PropertyName"].Value;

                ResourceProperty targetProperty;

                if (!processorContext.CurrentResourceClass.AllPropertyByName.TryGetValue(targetPropertyName, out targetProperty))
                {
                    ThrowPropertyNotFoundException(targetPropertyName);
                }

                string rangeBeginParameterName = "Range" + n + "Begin";
                string rangeEndParameterName = "Range" + n + "End";

                // Add the value to the parameter value collection
                builderContext.CurrentQueryFilterParameterValueByName.Add(
                    rangeBeginParameterName,
                    ConvertParameterValueForProperty(targetProperty, rangeQueryMatch.Groups["BeginValue"].Value));

                builderContext.CurrentQueryFilterParameterValueByName.Add(
                    rangeEndParameterName,
                    ConvertParameterValueForProperty(targetProperty, rangeQueryMatch.Groups["EndValue"].Value));

                // Add the query criteria to the HQL query
                builderContext.SpecificationWhere.AppendFormat(
                    "{0}{1}.{2} {3} :{4} and {1}.{2} {5} :{6}",
                    AndIfNeeded(builderContext.SpecificationWhere),
                    builderContext.CurrentAlias,
                    targetProperty.PropertyName,
                    RangeOperatorBySymbol[rangeQueryMatch.Groups["BeginRangeSymbol"].Value],
                    rangeBeginParameterName,
                    RangeOperatorBySymbol[rangeQueryMatch.Groups["EndRangeSymbol"].Value],
                    rangeEndParameterName);

                n++;
            }
        }

        private void SetQueryParameters(DynamicParameters parameters, IDictionary<string, object> parameterValueByName)
        {
            foreach (var kvp in parameterValueByName)
            {
                string parameterName = kvp.Key;
                object value = kvp.Value;

                if (parameterName.EndsWith("_Id"))
                {
                    // Parameter is a GUID resource Id
                    parameters.Add(parameterName, new Guid((string) value));
                    //query.SetParameter(parameterName, new Guid((string) value));
                }
                else if (!(value is string) && value is IEnumerable)
                {
                    parameters.Add(parameterName, value as IEnumerable);
                    // _parameterListSetter.SetParameterList(query, parameterName, value as IEnumerable);
                }
                else
                {
                    parameters.Add(parameterName, value);
                    // query.SetParameter(parameterName, value);
                }
            }
        }

        private static string AndIfNeeded(StringBuilder where)
        {
            return where.Length > 0
                ? " AND "
                : string.Empty;
        }

        private static string OrIfNeeded(StringBuilder where)
        {
            return where.Length > 0
                ? " OR "
                : string.Empty;
        }

        private static string CommaIfNeeded(StringBuilder orderBy)
        {
            return orderBy.Length > 0
                ? $",{Environment.NewLine}\t"
                : string.Empty;
        }

        private static string ConnectingAndIfNeeded(StringBuilder where1, StringBuilder where2)
        {
            return where1.Length > 0 && where2.Length > 0
                ? " AND "
                : string.Empty;
        }
    }
}
