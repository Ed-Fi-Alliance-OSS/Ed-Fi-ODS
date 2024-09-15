// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Logging;
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
    private const int MinPartitions = 1;
    private const int MaxPartitions = 200;
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
    public async Task<IActionResult> Get([FromQuery] int number = 1)
    {
        if (number is < 1 or > 200)
        {
            var problemDetails = new BadRequestParameterException(
                "The number parameter is incorrect.",
                new[] { $"Number of partitions must be between {MinPartitions} and {MaxPartitions}." })
            {
                CorrelationId = _logContextAccessor.GetCorrelationId()
            }.AsSerializableModel();

            return BadRequest(problemDetails);
        }

        // Build the query
        var resourceEntity = _dataManagementResourceContextProvider.Get().Resource.Entity;
        var queryBuilder = _partitionsQueryBuilderProvider.GetQueryBuilder(resourceEntity, number);
        var template = queryBuilder.BuildTemplate();

        // Open the connection
        await using var conn = _dbProviderFactory.CreateConnection();
        conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();
        await conn.OpenAsync();

        // Execute the query
        var aggregateIds = await conn.QueryAsync<int>(template.RawSql, template.Parameters);

        // Process the results
        List<string> pageTokens = new();

        int rangeMin = int.MinValue;

        foreach (var aggregateId in aggregateIds)
        {
            int rangeMaxExclusive = aggregateId;

            string pageToken = PagingHelpers.GetPageToken(rangeMin, rangeMaxExclusive - 1);
            pageTokens.Add(pageToken);

            rangeMin = rangeMaxExclusive;
        }

        pageTokens.Add(PagingHelpers.GetPageToken(rangeMin, int.MaxValue));

        var responseBody = new { pageTokens = pageTokens.ToArray() };

        return new ObjectResult(responseBody) { StatusCode = StatusCodes.Status200OK };
    }
}
