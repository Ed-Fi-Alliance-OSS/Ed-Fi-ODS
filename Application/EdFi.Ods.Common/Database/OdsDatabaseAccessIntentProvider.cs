// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Common.Database;

public class OdsDatabaseAccessIntentProvider : IOdsDatabaseAccessIntentProvider
{
    public const string UseReadWriteConnectionCacheKey = "UseReadWriteConnection";

    private readonly IAuthorizationContextProvider _authorizationContextProvider;
    private readonly IContextStorage _contextStorage;

    public OdsDatabaseAccessIntentProvider(IAuthorizationContextProvider authorizationContextProvider, IContextStorage contextStorage)
    {
        _authorizationContextProvider = authorizationContextProvider;
        _contextStorage = contextStorage;
    }

    public DatabaseAccessIntent GetDatabaseAccessIntent()
    {
        if (IsReadRequest(_authorizationContextProvider.GetAction())
            && !(_contextStorage.GetValue<bool?>(UseReadWriteConnectionCacheKey) ?? false))
        {
            return DatabaseAccessIntent.ReadOnly;
        }
        else
        {
            return DatabaseAccessIntent.ReadWrite;
        }
    }

    private bool IsReadRequest(string actionUri)
    {
        if (actionUri == null)
        {
            return false;
        }

        int lastSlashPos = actionUri.LastIndexOf('/');

        // Use a convention of the action URI name starting with "read" for all read-related operations (e.g. read, readChange, readHistory, etc)
        return lastSlashPos >= 0 && actionUri.AsSpan(lastSlashPos + 1).StartsWith("read");
    }
}
