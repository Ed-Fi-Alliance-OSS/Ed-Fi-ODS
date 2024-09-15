// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
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
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

public class PartitionRowNumbersCteQueryBuilderProvider : IAggregateRootQueryBuilderProvider
{
    public const string RegistrationKey = "PartitionRowNumbersCte";

    private readonly Dialect _dialect;
    private readonly IDomainModelProvider _domainModelProvider;
    private readonly DatabaseEngine _databaseEngine;

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
        IDomainModelProvider domainModelProvider,
        DatabaseEngine databaseEngine,
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
        _domainModelProvider = domainModelProvider;
        _databaseEngine = databaseEngine;
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
        Entity aggregateRootEntity,
        AggregateRootWithCompositeKey specification,
        IQueryParameters queryParameters)
    {
        // TODO: ODS-6432 - This needs to be invokes an authorization decorator of some sort -- copied from the data management controller pipeline. Also, look for approach to DRY here.
        EstablishAuthorizationFilteringContext(aggregateRootEntity);

        // -----------------------------------------------------------------------------
        // BEGIN potentially shared code
        // -----------------------------------------------------------------------------
        var rowNumbersQueryBuilder = new QueryBuilder(_dialect);

        var entityFullName = aggregateRootEntity.FullName;
        
        if (!_domainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(entityFullName, out var entity))
        {
            throw new Exception($"Unable to find API model entity for '{entityFullName}'.");
        }

        string rootTableAlias = entity.IsDerived ? "b" : "r";

        // Get the fully qualified physical table name
        var schemaTableName = $"{entity.Schema}.{entity.TableName(_databaseEngine)}";

        // -----------------------------------------------------------------------------
        // END potentially shared code
        // -----------------------------------------------------------------------------

        // POTENTIAL Template method -- Build initial query with SELECT
        rowNumbersQueryBuilder.From(schemaTableName.Alias("r"));

        rowNumbersQueryBuilder
            .Select($"{rootTableAlias}.AggregateId")
            .SelectRaw($"ROW_NUMBER() OVER (ORDER BY {rootTableAlias}.AggregateId) AS RowNumber");

        // TODO: ODS-6432 - Derived entity may not be needed unless there is criteria to be applied that uses the derived type. This would eliminate a join with every page. Will need to include Discriminator value in join in lieu of join to base.

        // Add the join to the base type (TODO: Determine if needed, with caching considerations)
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

        // -----------------------------------------------------------------------------
        // END ALL potentially shared code
        // -----------------------------------------------------------------------------

        return rowNumbersQueryBuilder;
    }

    // TODO: ODS-6432 - ALL OF THIS NEEDS TO FACTORED OUT INTO A SECURITY COMPONENT SOMEWHERE
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
