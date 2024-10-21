// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

public interface IRedundantAuthorizationContextManager
{
    void StoreAuthorizationQueryContext(string sql, DbParameter[] parameters);

    bool IsAuthorizationQueryRedundant(string sql, DbParameter[] parameters);
}

public class RedundantAuthorizationContextManager : IRedundantAuthorizationContextManager
{
    private readonly IContextProvider<ViewBasedAuthorizationQueryContext> _viewBasedAuthorizationQueryContextProvider;

    public RedundantAuthorizationContextManager(
        IContextProvider<ViewBasedAuthorizationQueryContext> viewBasedAuthorizationQueryContextProvider)
    {
        _viewBasedAuthorizationQueryContextProvider = viewBasedAuthorizationQueryContextProvider;
    }

    public bool IsAuthorizationQueryRedundant(string sql, DbParameter[] parameters)
    {
        // Check for previous identical execution in current context
        var viewBasedAuthorizationQueryContext = _viewBasedAuthorizationQueryContextProvider.Get();

        // Has the context been set (indicating we're upserting) and is the current SQL already present? 
        if (viewBasedAuthorizationQueryContext != null && viewBasedAuthorizationQueryContext.Sql == sql)
        {
            // Check the parameters for equality
            for (int i = 0; i < parameters.Length; i++)
            {
                // Do parameter values differ?
                if (!parameters[i].Value.Equals(viewBasedAuthorizationQueryContext.Parameters[i].Value))
                {
                    // Authorization is not redundant
                    return false;
                }
            }

            // SQL and parameters match - authorization is redundant
            return true;
        }

        // No context present, or SQL doesn't match -- not redundant
        return false;
    }

    public void StoreAuthorizationQueryContext(string sql, DbParameter[] parameters)
    {
        var viewBasedAuthorizationQueryContext = _viewBasedAuthorizationQueryContextProvider.Get();

        // Save the SQL and parameters for this query execution into the current context (if context is present but uninitialized)
        if (viewBasedAuthorizationQueryContext is { Sql: null })
        {
            viewBasedAuthorizationQueryContext.Sql = sql;
            viewBasedAuthorizationQueryContext.Parameters = parameters;
        }
    }
}
