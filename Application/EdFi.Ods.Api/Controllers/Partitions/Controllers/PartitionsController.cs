// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Helpers;
using EdFi.Ods.Api.Security.AuthorizationStrategies;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
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

    public PartitionsController(
        DbProviderFactory dbProviderFactory,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
        ILogContextAccessor logContextAccessor,
        IPartitionsQueryBuilderProvider partitionsQueryBuilderProvider)
    {
        _dbProviderFactory = dbProviderFactory;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        _logContextAccessor = logContextAccessor;
        _partitionsQueryBuilderProvider = partitionsQueryBuilderProvider;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] int number = 1,
        [FromQuery] Dictionary<string, string> additionalParameters = default)
    {
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

            // Map the request model to the resource model
            var resourceInstance = (IMappable)DynamicMapper.MapToTarget(
                requestModel,
                Activator.CreateInstance(resourceModelType),
                mappingInterfaceType);

            // Create the entity instance and map the resource to the entity
            var aggregateRootWithCompositeKey = (AggregateRootWithCompositeKey) Activator.CreateInstance(entityType);
            resourceInstance.Map(aggregateRootWithCompositeKey);

            return aggregateRootWithCompositeKey;
        }

        async Task<int[]> GetPartitionStartingAggregateIds()
        {
            // Build the query
            var entity = resource.Entity;
            var queryBuilder = _partitionsQueryBuilderProvider.GetQueryBuilder(number, entity, entityInstance, additionalParameters);
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
            if (rangeMin != null && list.Count < number)
            {
                string finalPageToken = PagingHelpers.GetPageToken(rangeMin.Value, int.MaxValue);
                list.Add(finalPageToken);
            }

            return list.ToArray();
        }
    }
}
