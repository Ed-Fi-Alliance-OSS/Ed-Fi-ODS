// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure;
using log4net;
using NHibernate;

namespace EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;

public interface IEntityAuthorizationQueryExecutor
{
    Task<int?> ExecuteAsync(
        string sql,
        KeyValuePair<string, object>[] parameterDetails,
        AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks,
        IList<long> claimEducationOrganizationIds);
}

public class EntityAuthorizationQueryExecutor : IEntityAuthorizationQueryExecutor
{
    private readonly ISessionFactory _sessionFactory;
    private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
    private readonly IRedundantAuthorizationContextManager _redundantAuthorizationContextManager;

    private readonly ILog _logger = LogManager.GetLogger(typeof(EntityAuthorizationQueryExecutor));

    public EntityAuthorizationQueryExecutor(
        ISessionFactory sessionFactory,
        IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
        IRedundantAuthorizationContextManager redundantAuthorizationContextManager
    )
    {
        _sessionFactory = sessionFactory;
        _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        _redundantAuthorizationContextManager = redundantAuthorizationContextManager;
    }

    public async Task<int?> ExecuteAsync(
        string sql,
        KeyValuePair<string, object>[] parameterDetails,
        AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks,
        IList<long> claimEducationOrganizationIds)
    {
        // Execute the query
        using var sessionScope = new SessionScope(_sessionFactory);

        await using var cmd = sessionScope.Session.Connection.CreateCommand();
        sessionScope.Session.GetCurrentTransaction()?.Enlist(cmd);

        // Assign the command text
        cmd.CommandText = sql;

        // Assign all parameters
        var parameters = parameterDetails
            .Select(pd => 
            {
                var parameter = cmd.CreateParameter();
                parameter.ParameterName = pd.Key;
                parameter.Value = pd.Value;

                return parameter;
            })
            .ToArray();

        cmd.Parameters.AddRange(parameters);

        // Check for previous identical execution in current context
        if (_redundantAuthorizationContextManager.IsAuthorizationQueryRedundant(cmd.CommandText, parameters))
        {
            return null;
        }

        if (resultsWithPendingExistenceChecks.Any(
                res => res.FilterResults.Any(far => far.FilterContext.ClaimParameterName != null)))
        {
            _viewBasedSingleItemAuthorizationQuerySupport.ApplyEducationOrganizationIdClaimsToCommand(
                cmd,
                claimEducationOrganizationIds);
        }

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug($"Single Item SQL: {sql}");
        }

        // Process the pending AND SQL checks to get a result (0 for failure, 1 for success)
        int validationResult = (int?) await cmd.ExecuteScalarAsync() ?? 0;

        _redundantAuthorizationContextManager.StoreAuthorizationQueryContext(cmd.CommandText, parameters);

        return validationResult;
    }
}
