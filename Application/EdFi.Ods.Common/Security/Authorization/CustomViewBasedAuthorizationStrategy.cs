// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Common.Security.Authorization;

public class CustomViewBasedAuthorizationStrategy : IAuthorizationStrategy
{
    private readonly string _authorizationStrategyName;
    private readonly Entity _basisEntity;
    private readonly IResourceClaimUriProvider _resourceClaimUriProvider;
    private readonly IResourceModelProvider _resourceModelProvider;

    public CustomViewBasedAuthorizationStrategy(
        string authorizationStrategyName,
        Entity basisEntity,
        IResourceClaimUriProvider resourceClaimUriProvider,
        IResourceModelProvider resourceModelProvider)
    {
        _authorizationStrategyName = authorizationStrategyName;
        _basisEntity = basisEntity;
        _resourceClaimUriProvider = resourceClaimUriProvider;
        _resourceModelProvider = resourceModelProvider;
    }

    public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
        EdFiResourceClaim[] relevantClaims,
        EdFiAuthorizationContext authorizationContext)
    {
        var subjectEntity = GetAuthorizationSubjectEntity();

        List<string> subjectEndpointNames = GetAuthorizationSubjectEndpointNames();

        return new AuthorizationStrategyFiltering()
        {
            AuthorizationStrategy = this,
            AuthorizationStrategyName = _authorizationStrategyName,
            Filters = new AuthorizationFilterContext[]
            {
                new ()
                {
                    FilterName = _authorizationStrategyName,
                    SubjectEndpointNames = subjectEndpointNames.ToArray(),
                    SubjectEndpointValues = authorizationContext.Data == null
                        ? null 
                        : subjectEndpointNames.Select(
                            n => authorizationContext.Type.GetProperty(n).GetValue(authorizationContext.Data))
                        .ToList(),
                    ClaimParameterName = null,
                    ClaimEndpointValues = null,
                }
            },
            Operator = FilterOperator.And
        };

        List<string> GetAuthorizationSubjectEndpointNames()
        {
            var endpointNames = new List<string>();

            // First try to find properties by name in subject
            foreach (EntityProperty basisProperty in _basisEntity.Identifier.Properties)
            {
                if (subjectEntity.PropertyByName.TryGetValue(basisProperty.PropertyName, out var subjectEntityProperty))
                {
                    endpointNames.Add(subjectEntityProperty.PropertyName);
                    continue;
                }

                // Search for a locally role-named property using the incoming associations in the model back to the basis entity
                var roleNamedSubjectEndpointProperty = subjectEntity.Properties.FirstOrDefault(p => p.DefiningProperty == basisProperty);

                if (roleNamedSubjectEndpointProperty != null)
                {
                    endpointNames.Add(roleNamedSubjectEndpointProperty.PropertyName);
                    continue;
                }

                throw new Exception(
                    $"Unable to find a property on the authorization subject entity type '{subjectEntity.Name}' corresponding to the '{basisProperty.PropertyName}' property on the custom authorization view's basis entity type '{_basisEntity.Name}' in order to perform authorization. Should a different authorization strategy be used?");
            }

            return endpointNames;
        }

        Entity GetAuthorizationSubjectEntity()
        {
            var resourceFullName = _resourceClaimUriProvider.GetResourceFullName(authorizationContext.ResourceClaimUris);
            var subjectResource = _resourceModelProvider.GetResourceModel().GetResourceByFullName(resourceFullName);
            return subjectResource.Entity;
        }
    }

    public Entity BasisEntity
    {
        get => _basisEntity;
    }
}
