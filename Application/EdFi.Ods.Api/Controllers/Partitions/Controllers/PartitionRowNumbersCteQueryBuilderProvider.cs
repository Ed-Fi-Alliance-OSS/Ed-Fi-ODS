// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Providers.Queries.Criteria;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

public class PartitionRowNumbersCteQueryBuilderProvider : IAggregateRootQueryBuilderProvider
{
    public const string RegistrationKey = "PartitionRowNumbersCte";

    private readonly Dialect _dialect;
    private readonly DatabaseEngine _databaseEngine;
    private readonly IAggregateRootQueryCriteriaApplicator[] _additionalParametersCriteriaApplicator;

    // Security dependencies
    private readonly IAuthorizationContextProvider _authorizationContextProvider;
    private readonly IDataManagementAuthorizationPlanFactory _dataManagementAuthorizationPlanFactory;
    private readonly IContextProvider<DataManagementAuthorizationPlan> _authorizationPlanContextProvider;
    private readonly ISecurityRepository _securityRepository;
    private readonly IResourceClaimUriProvider _resourceClaimUriProvider;

    public PartitionRowNumbersCteQueryBuilderProvider(
        Dialect dialect,
        DatabaseEngine databaseEngine,
        IAggregateRootQueryCriteriaApplicator[] additionalParametersCriteriaApplicator,

        // Security dependencies
        IAuthorizationContextProvider authorizationContextProvider,
        IDataManagementAuthorizationPlanFactory dataManagementAuthorizationPlanFactory,
        IContextProvider<DataManagementAuthorizationPlan> authorizationPlanContextProvider,
        ISecurityRepository securityRepository,
        IResourceClaimUriProvider resourceClaimUriProvider)
    {
        _dialect = dialect;
        _databaseEngine = databaseEngine;
        _additionalParametersCriteriaApplicator = additionalParametersCriteriaApplicator;
        _authorizationContextProvider = authorizationContextProvider;
        _dataManagementAuthorizationPlanFactory = dataManagementAuthorizationPlanFactory;
        _authorizationPlanContextProvider = authorizationPlanContextProvider;
        _securityRepository = securityRepository;
        _resourceClaimUriProvider = resourceClaimUriProvider;
    }

    public QueryBuilder GetQueryBuilder(
        Entity entity,
        AggregateRootWithCompositeKey specification,
        IQueryParameters queryParameters,
        IDictionary<string, string> additionalParameters)
    {
        // TODO: ODS-6510 - This needs to be invokes an authorization decorator of some sort -- copied from the data management controller pipeline. Also, look for approach to DRY here.
        EstablishAuthorizationPlan(entity);

        var rowNumbersQueryBuilder = new QueryBuilder(_dialect)
        {
            // For partitions queries use the EXISTS subquery authorization filtering strategy
            Context = { { nameof(QueryBuilderFilterStrategy), QueryBuilderFilterStrategy.ExistsSubquery }},
        };

        // Get the fully qualified physical table name
        var schemaTableName = $"{entity.Schema}.{entity.TableName(_databaseEngine)}";

        string rootTableAlias = entity.IsDerived ? "b" : "r";

        rowNumbersQueryBuilder
            .From(schemaTableName.Alias("r"))
            .Select($"{rootTableAlias}.AggregateId")
            .SelectRaw($"ROW_NUMBER() OVER (ORDER BY {rootTableAlias}.AggregateId) AS RowNumber")
            .SelectRaw($"COUNT(*) OVER () AS CountOfRows");

        // Add the join to the base type
        if (entity.IsDerived)
        {
            rowNumbersQueryBuilder.Join(
                $"{entity.BaseEntity.Schema}.{entity.BaseEntity.TableName(_databaseEngine)} AS b",
                j =>
                {
                    foreach (var propertyMapping in entity.BaseAssociation.PropertyMappings)
                    {
                        j.On(
                            $"r.{propertyMapping.ThisProperty.ColumnNameByDatabaseEngine[_databaseEngine]}",
                            $"b.{propertyMapping.OtherProperty.ColumnNameByDatabaseEngine[_databaseEngine]}");
                    }

                    return j;
                });
        }

        // Add special query fields
        QueryBuilderExtensions.ApplyQueryParameterCriteria(rowNumbersQueryBuilder, queryParameters);

        // Apply additional parameters, as applicable
        foreach (var applicator in _additionalParametersCriteriaApplicator)
        {
            applicator.ApplyAdditionalParameters(rowNumbersQueryBuilder, entity, specification, additionalParameters);
        }

        return rowNumbersQueryBuilder;
    }

    // TODO: ODS-6510 - THIS NEEDS TO REFACTORED OUT INTO A SECURITY COMPONENT SOMEWHERE - Pay attention to DRY
    private void EstablishAuthorizationPlan(dynamic aggregateRootEntity)
    {
        // Establish the authorization context -- currently done in SetAuthorizationContext pipeline step, but not accessible here
        _authorizationContextProvider.SetResourceUris(_resourceClaimUriProvider.GetResourceClaimUris(aggregateRootEntity));

        string actionUri = _securityRepository.GetActionByName("Read").ActionUri;
        _authorizationContextProvider.SetAction(actionUri); // TODO: This may not be needed as action is passed.

        // Establish the authorization plan
        var authorizationPlan = _dataManagementAuthorizationPlanFactory.CreateAuthorizationPlan(actionUri);
        _authorizationPlanContextProvider.Set(authorizationPlan);
    }
}
