// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Helpers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[ApplyOdsRouteRootTemplate]
[Route($"{RouteConstants.DataManagementRoutePrefix}/{{schema}}/{{resource}}/partitions")]
public class PartitionsController : ControllerBase
{
    public const int MinPartitions = 1;
    public const int MaxPartitions = 200;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly ILogContextAccessor _logContextAccessor;

    private readonly ILog _logger = LogManager.GetLogger(typeof(PartitionsController));
    private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;
    private readonly IPartitionsQueryBuilderProvider _partitionsQueryBuilderProvider;
    private readonly IContextProvider<UsiLookupsByUniqueIdContext> _usiLookupsByUniqueIdContextProvider;
    private readonly IContextualPersonUsisResolver _personUsisResolver;
    private readonly (string UniqueId, string PersonType)[] _personUniqueIds;
    private readonly ConcurrentDictionary<Type, PropertyInfo[]> _uniqueIdPropertiesByModelInterfaceType = new ConcurrentDictionary<Type, PropertyInfo[]>();

    private static readonly IContextStorage _contextStorage = new CallContextStorage();

    public PartitionsController(
        DbProviderFactory dbProviderFactory,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
        ILogContextAccessor logContextAccessor,
        IPartitionsQueryBuilderProvider partitionsQueryBuilderProvider,
        IPersonTypesProvider personTypesProvider,
        IContextProvider<UsiLookupsByUniqueIdContext> usiLookupsByUniqueIdContextProvider,
        IContextualPersonUsisResolver personUsisesResolver)
    {
        _dbProviderFactory = dbProviderFactory;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        _logContextAccessor = logContextAccessor;
        _partitionsQueryBuilderProvider = partitionsQueryBuilderProvider;
        _usiLookupsByUniqueIdContextProvider = usiLookupsByUniqueIdContextProvider;
        _personUsisResolver = personUsisesResolver;

        _personUniqueIds = personTypesProvider.PersonTypes.Select(pt => (UniqueId: $"{pt}UniqueId", PersonType: pt)).ToArray();
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] int? number,
        [FromQuery] UrlQueryParametersRequest urlQueryParametersRequest,
        [FromQuery] Dictionary<string, string> additionalParameters)
    {
        // Store alternative auth approach decision into call context
        if (additionalParameters.TryGetValue("useJoinAuth", out string useJoinAuth) == true)
        {
            _contextStorage.SetValue("UseJoinAuth", Convert.ToBoolean(useJoinAuth));
        }

        if (number is < MinPartitions or > MaxPartitions)
        {
            var problemDetails = new BadRequestParameterException(
                BadRequestException.DefaultDetail,
                new[] { $"Number of partitions must be between {MinPartitions} and {MaxPartitions}." })
            {
                CorrelationId = _logContextAccessor.GetCorrelationId()
            }.AsSerializableModel();

            return BadRequest(problemDetails);
        }

        var  queryParameters = new QueryParameters(urlQueryParametersRequest);

        // Bind the request to the corresponding resource class model
        Resource resource = _dataManagementResourceContextProvider.Get()?.Resource;

        // Make sure resource was found
        if (resource == null)
        {
            return ControllerHelpers.NotFound(_logContextAccessor.GetCorrelationId());
        }

        var entityInstance = await ModelBindRequestAndMapToEntity();

        int[] aggregateIds = await GetPartitionStartingAggregateIds();

        // Process the results
        var pageTokens = PreparePageTokens();
        var responseBody = new { pageTokens = pageTokens.ToArray() };

        return new ObjectResult(responseBody) { StatusCode = StatusCodes.Status200OK };

        (Type requestType, Type resourceType, Type entityType) GetModelTypes()
        {
            if (resource.Entity.IsExtensionEntity)
            {
                string assemblyName = $"EdFi.Ods.Extensions.{resource.SchemaProperCaseName}";
            
                string requestTypeName =
                    $"{Namespaces.Requests.BaseNamespace}.{resource.SchemaProperCaseName}.{resource.PluralName}.{resource.Name}GetByExample, {assemblyName}";

                string resourceTypeName =
                    $"{Namespaces.Resources.BaseNamespace}.{resource.Name}.{resource.SchemaProperCaseName}.{resource.Name}, {assemblyName}";

                string entityTypeName =
                    $"{Namespaces.Entities.NHibernate.GetAggregateNamespace(resource.Name, resource.SchemaProperCaseName, isExtensionEntity: true)}.{resource.Name}, {assemblyName}";

                var requestType = Type.GetType(requestTypeName);
                var resourceType = Type.GetType(resourceTypeName);
                var entityType = Type.GetType(entityTypeName);
                
                return (requestType, resourceType, entityType);
            }
            else
            {
                string assemblyName = $"EdFi.Ods.Standard";

                string requestTypeName =
                    $"{Namespaces.Requests.BaseNamespace}.{resource.PluralName}.{resource.SchemaProperCaseName}.{resource.Name}GetByExample, {assemblyName}";

                string resourceTypeName =
                    $"{Namespaces.Resources.BaseNamespace}.{resource.Name}.{resource.SchemaProperCaseName}.{resource.Name}, {assemblyName}";

                string entityTypeName =
                    $"{Namespaces.Entities.NHibernate.GetAggregateNamespace(resource.Name, resource.SchemaProperCaseName, isExtensionEntity: false)}.{resource.Name}, {assemblyName}";
            
                var requestType = Type.GetType(requestTypeName);
                var resourceType = Type.GetType(resourceTypeName);
                var entityType = Type.GetType(entityTypeName);

                return (requestType, resourceType, entityType);
            }
        }

        async Task<AggregateRootWithCompositeKey> ModelBindRequestAndMapToEntity()
        {
            // Get the types for:
            //   * The generated request model (flattened view for model binding query string values)
            //   * The resource model type (the root class of the full resource model representation)
            //   * The entity type (the aggregate root entity representing the ODS aggregate root table)
            var (requestModelType, resourceModelType, entityType) = GetModelTypes();

            // Perform ASP.NET model binding on the request model
            var requestModel = Activator.CreateInstance(requestModelType);
            await TryUpdateModelAsync(requestModel, requestModelType, string.Empty);

            // Identify the interface for the entity/resource model mapping
            var mappingInterfaceType = resourceModelType.GetInterfaces().Single(t => t.Name == $"I{resource.Name}");

            ResolveUniqueIdsInRequestSpecification();

            // Map the request model directly to the entity model
            var aggregateRootInstance = (IMappable) DynamicMapper.MapToTarget(
                requestModel,
                Activator.CreateInstance(entityType),
                mappingInterfaceType);

            return (AggregateRootWithCompositeKey) aggregateRootInstance;

            void ResolveUniqueIdsInRequestSpecification()
            {
                // Get the uniqueId properties for this interface
                var uniqueIdProperties = _uniqueIdPropertiesByModelInterfaceType.GetOrAdd(
                    requestModelType,
                    t => t.GetProperties().Where(p => p.Name.EndsWith("UniqueId")).ToArray());

                UsiLookupsByUniqueIdContext usiLookupsByUniqueIdContext = null;
                
                // Iterate through the properties, marking them for cache resolution in batch
                foreach (var uniqueIdProperty in uniqueIdProperties)
                {
                    var uniqueId = (string) uniqueIdProperty.GetValue(requestModel);

                    if (uniqueId != null)
                    {
                        var personType = _personUniqueIds.First(x => uniqueIdProperty.Name.EndsWith(x.UniqueId)).PersonType;
                        usiLookupsByUniqueIdContext ??= _usiLookupsByUniqueIdContextProvider.Get();
                        usiLookupsByUniqueIdContext.AddLookup(personType, uniqueId);
                    }
                }

                if (usiLookupsByUniqueIdContext != null)
                {
                    _personUsisResolver.ResolveAllUsis();
                }
            }
        }

        async Task<int[]> GetPartitionStartingAggregateIds()
        {
            // Build the query
            var entity = resource.Entity;

            var queryBuilder = _partitionsQueryBuilderProvider.GetQueryBuilder(
                number,
                entity,
                entityInstance,
                queryParameters,
                additionalParameters);

            var template = queryBuilder.BuildTemplate();

            // Open the connection
            await using var conn = _dbProviderFactory.CreateConnection();
            conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();
            await conn.OpenAsync();

            // Execute the query
            var ints = (await conn.QueryAsync<int>(template.RawSql, template.Parameters)).ToArray();

            return ints;
        }

        string[] PreparePageTokens()
        {
            List<string> list = new();

            int? rangeMin = null;

            foreach (var aggregateId in aggregateIds)
            {
                // Establish minimum range of the first partition
                if (rangeMin == null)
                {
                    rangeMin = aggregateId;
                    continue;
                }

                int rangeMaxExclusive = aggregateId;

                // Check if we are about to exceed the allowed number of pageTokens
                if (list.Count + 1 == number)
                {
                    // Modify the last page token to use the second-to-last aggregateId and int.MaxValue
                    string lastPageToken = PagingHelpers.GetPageToken(rangeMin.Value, int.MaxValue);
                    list.Add(lastPageToken);
                    break;
                }

                // Add the normal page token if the limit is not reached yet
                string pageToken = PagingHelpers.GetPageToken(rangeMin.Value, rangeMaxExclusive - 1);
                list.Add(pageToken);

                rangeMin = rangeMaxExclusive;
            }

            // Add the final range only if we haven't reached the limit
            if (rangeMin != null && list.Count < (number ?? int.MaxValue))
            {
                string finalPageToken = PagingHelpers.GetPageToken(rangeMin.Value, int.MaxValue);
                list.Add(finalPageToken);
            }

            return list.ToArray();
        }
    }
}
