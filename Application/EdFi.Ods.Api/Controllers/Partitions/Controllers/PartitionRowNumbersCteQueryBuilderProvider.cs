// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Providers.Queries.Criteria;
using EdFi.Ods.Common.Security;
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
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IApiClientContextProvider _apiClientContextProvider;
    private readonly IAuthorizationContextProvider _authorizationContextProvider;
    private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
    private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;
    private readonly IAuthorizationFilterContextProvider _authorizationFilterContextProvider;
    private readonly ISecurityRepository _securityRepository;
    private readonly IResourceClaimUriProvider _resourceClaimUriProvider;

    public PartitionRowNumbersCteQueryBuilderProvider(
        Dialect dialect,
        DatabaseEngine databaseEngine,
        IAggregateRootQueryCriteriaApplicator[] additionalParametersCriteriaApplicator,

        // Security dependencies
        IApiClientContextProvider apiClientContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IAuthorizationContextProvider authorizationContextProvider,
        IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
        IAuthorizationFilteringProvider authorizationFilteringProvider,
        IAuthorizationFilterContextProvider authorizationFilterContextProvider,
        ISecurityRepository securityRepository,
        IResourceClaimUriProvider resourceClaimUriProvider)
    {
        _dialect = dialect;
        _databaseEngine = databaseEngine;
        _additionalParametersCriteriaApplicator = additionalParametersCriteriaApplicator;
        _apiClientContextProvider = apiClientContextProvider;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _authorizationContextProvider = authorizationContextProvider;
        _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
        _authorizationFilteringProvider = authorizationFilteringProvider;
        _authorizationFilterContextProvider = authorizationFilterContextProvider;
        _securityRepository = securityRepository;
        _resourceClaimUriProvider = resourceClaimUriProvider;
    }

    public QueryBuilder GetQueryBuilder(
        Entity entity,
        AggregateRootWithCompositeKey specification,
        IQueryParameters queryParameters,
        IDictionary<string, string> additionalParameters)
    {
        // TODO: ODS-6432 - This needs to be invokes an authorization decorator of some sort -- copied from the data management controller pipeline. Also, look for approach to DRY here.
        EstablishAuthorizationFilteringContext(entity);

        var rowNumbersQueryBuilder = new QueryBuilder(_dialect);

        // Get the fully qualified physical table name
        var schemaTableName = $"{entity.Schema}.{entity.TableName(_databaseEngine)}";

        string rootTableAlias = entity.IsDerived ? "b" : "r";

        rowNumbersQueryBuilder
            .From(schemaTableName.Alias("r"))
            .Select($"{rootTableAlias}.AggregateId")
            .SelectRaw($"ROW_NUMBER() OVER (ORDER BY {rootTableAlias}.AggregateId) AS RowNumber");

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
        AggregateQueryBuilderHelpers.ProcessCommonQueryParameters(rowNumbersQueryBuilder, queryParameters);

        // Apply additional parameters, as applicable
        foreach (var applicator in _additionalParametersCriteriaApplicator)
        {
            applicator.ApplyAdditionalParameters(rowNumbersQueryBuilder, entity, specification, additionalParameters);
        }

        return rowNumbersQueryBuilder;
    }

    // TODO: ODS-6432 - ALL OF THIS NEEDS TO REFACTORED OUT INTO A SECURITY COMPONENT SOMEWHERE - Pay attention to DRY
    private void EstablishAuthorizationFilteringContext(dynamic aggregateRootEntity)
    {
        // Establish the authorization context -- currently done in SetAuthorizationContext pipeline step, not accessible here
        _authorizationContextProvider.SetResourceUris(
            _resourceClaimUriProvider.GetResourceClaimUris(aggregateRootEntity));

        _authorizationContextProvider.SetAction(_securityRepository.GetActionByName("Read").ActionUri);

        // Make sure Authorization context is present before proceeding
        _authorizationContextProvider.VerifyAuthorizationContextExists();

        // Build the AuthorizationContext
        var apiClientContext = _apiClientContextProvider.GetApiClientContext();
        var resource = _dataManagementResourceContextProvider.Get().Resource;
        string[] resourceClaimUris = _authorizationContextProvider.GetResourceUris();
        string requestActionUri = _authorizationContextProvider.GetAction();

        var authorizationContext = new EdFiAuthorizationContext(
            apiClientContext,
            resource,
            resourceClaimUris,
            requestActionUri,
            aggregateRootEntity.NHibernateEntityType);

        // Get authorization filters
        var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
            apiClientContext.ClaimSetName,
            resourceClaimUris,
            requestActionUri);

        var authorizationFiltering = _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);

        _authorizationFilterContextProvider.SetFilterContext(authorizationFiltering);
    }
}
