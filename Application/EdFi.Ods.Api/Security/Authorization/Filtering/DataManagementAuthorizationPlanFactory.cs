// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.Filtering;

/// <summary>
/// Provides authorization filtering for the current authorization decision.
/// </summary>
public class DataManagementAuthorizationPlanFactory : IDataManagementAuthorizationPlanFactory
{
    private readonly IApiClientContextProvider _apiClientContextProvider;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
    private readonly IResourceClaimUriProvider _resourceClaimUriProvider;

    public DataManagementAuthorizationPlanFactory(
        IApiClientContextProvider apiClientContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
        IResourceClaimUriProvider resourceClaimUriProvider)
    {
        // _authorizationContextProvider = authorizationContextProvider;
        _apiClientContextProvider = apiClientContextProvider;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
        _resourceClaimUriProvider = resourceClaimUriProvider;
    }

    /// <inheritdoc cref="IDataManagementAuthorizationPlanFactory.CreateAuthorizationPlan(string)" />
    public DataManagementAuthorizationPlan CreateAuthorizationPlan(string actionUri)
    {
        // Build the request context
        var resource = _dataManagementResourceContextProvider.Get().Resource;

        return CreateAuthorizationPlan(resource, actionUri);
    }

    /// <inheritdoc cref="IDataManagementAuthorizationPlanFactory.CreateAuthorizationPlan(EdFi.Ods.Common.Models.Resource.Resource,string)" />
    public DataManagementAuthorizationPlan CreateAuthorizationPlan(Resource resource, string actionUri)
    {
        var dataManagementRequestContext = CreateDataManagementRequestContext(resource, actionUri);

        return CreateAuthorizationPlan(dataManagementRequestContext);
    }

    /// <inheritdoc cref="IDataManagementAuthorizationPlanFactory.CreateAuthorizationPlan(string,object,EdFi.Ods.Common.Security.Claims.AuthorizationPhase)" />
    public DataManagementAuthorizationPlan CreateAuthorizationPlan(
        string actionUri,
        object entity,
        AuthorizationPhase authorizationPhase)
    {
        // Build the request context
        var resource = _dataManagementResourceContextProvider.Get().Resource;

        var dataManagementRequestContext = CreateDataManagementRequestContext(resource, actionUri, entity, authorizationPhase);

        return CreateAuthorizationPlan(dataManagementRequestContext);
    }

    private DataManagementAuthorizationPlan CreateAuthorizationPlan(DataManagementRequestContext dataManagementRequestContext)
    {
        var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
            dataManagementRequestContext.ApiClientContext.ClaimSetName,
            dataManagementRequestContext.ResourceClaimUris,
            dataManagementRequestContext.Action);

        var relevantClaims = new[] { authorizationBasisMetadata.RelevantClaim };

        // Get authorization filters
        var authorizationFiltering = authorizationBasisMetadata.AuthorizationStrategies
            .Distinct()
            .Select(x => x.GetAuthorizationStrategyFiltering(relevantClaims, dataManagementRequestContext))
            // Sort authorizations so that those that use system-assigned values are processed after others to avoid disclosing item existence to otherwise unauthorized clients
            .OrderBy(x => x.UsesSystemAssignedValues)
            .ToArray();

        return new DataManagementAuthorizationPlan()
        {
            RequestContext = dataManagementRequestContext,
            AuthorizationBasisMetadata = authorizationBasisMetadata,
            Filtering = authorizationFiltering
        };
    }

    private DataManagementRequestContext CreateDataManagementRequestContext(Resource resource, string actionUri)
    {
        string[] resourceClaimUris = _resourceClaimUriProvider.GetResourceClaimUris(resource);
        var apiClientContext = _apiClientContextProvider.GetApiClientContext();

        return new DataManagementRequestContext(
            apiClientContext,
            resource,
            resourceClaimUris,
            actionUri,
            (Type)(resource.Entity as dynamic).NHibernateEntityType);
    }
    
    private DataManagementRequestContext CreateDataManagementRequestContext(
        Resource resource,
        string actionUri,
        object entity,
        AuthorizationPhase authorizationPhase)
    {
        string[] resourceClaimUris = _resourceClaimUriProvider.GetResourceClaimUris(resource);
        var apiClientContext = _apiClientContextProvider.GetApiClientContext();

        return  new DataManagementRequestContext(
            apiClientContext,
            resource,
            resourceClaimUris,
            actionUri,
            entity,
            authorizationPhase);
    }
}

public class DataManagementAuthorizationPlan
{
    public DataManagementRequestContext RequestContext { get; set; }

    public AuthorizationBasisMetadata AuthorizationBasisMetadata { get; set; }

    public IReadOnlyList<AuthorizationStrategyFiltering> Filtering { get; set; }
}
