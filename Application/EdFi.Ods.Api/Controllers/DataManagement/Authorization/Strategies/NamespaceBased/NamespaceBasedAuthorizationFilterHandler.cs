// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Dapper;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.NamespaceBased
{
    public class NamespaceBasedAuthorizationFilterHandler : IAuthorizationFilterHandler
    {
        private readonly IPhysicalNamesProvider _physicalNamesProvider;
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        
        private const string NamespaceBasedAuthorizationStrategyName = "NamespaceBased";

        public NamespaceBasedAuthorizationFilterHandler(
            IPhysicalNamesProvider physicalNamesProvider,
            IApiKeyContextProvider apiKeyContextProvider)
        {
            _physicalNamesProvider = physicalNamesProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
        }
        
        public bool CanHandle(string authorizationStrategyName) 
            => authorizationStrategyName == NamespaceBasedAuthorizationStrategyName;

        public void ApplyFilter(string authorizationStrategyName, SqlBuilder sqlBuilder, Entity entity)
        {
            if (entity.PropertyByName.TryGetValue("Namespace", out var namespaceProperty))
            {
                string namespaceColumnName = _physicalNamesProvider.Column(namespaceProperty);

                var namespacePrefixes = _apiKeyContextProvider.GetApiKeyContext().NamespacePrefixes;

                var namespaceClauses = namespacePrefixes.Select((ns, i) 
                    => $"e.{namespaceColumnName} LIKE @namespacePrefix{i}");

                sqlBuilder.Where($"({string.Join(" OR ", namespaceClauses)})");
            }
            else
            {
                // TODO: API Simplification - Review existing implementation for appropriate exception message
                throw new ApiSecurityConfigurationException($"Entity '{entity.FullName}' was configured to use authorization strategy '{NamespaceBasedAuthorizationStrategyName}', but the entity does not contain a 'Namespace' property.");
            }
        }

        public void ApplyParameters(string authorizationStrategyName, DynamicParameters parameters, IQueryCollection query)
        {
            var namespacePrefixes = _apiKeyContextProvider.GetApiKeyContext().NamespacePrefixes;

            namespacePrefixes.ForEach((ns, i) 
                => parameters.Add($"namespacePrefix{i}", $"{ns}%"));
        }
    }
}
