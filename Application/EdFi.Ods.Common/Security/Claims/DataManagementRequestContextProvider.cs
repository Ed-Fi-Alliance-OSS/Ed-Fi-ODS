// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Security.Claims;

public class DataManagementRequestContextProvider : IDataManagementRequestContextProvider
{
    private readonly IContextStorage _contextStorage;

    private const string ResourceContextKey = "DataManagementRequestContextProvider.Resource";
    
    public DataManagementRequestContextProvider(IContextStorage contextStorage)
    {
        _contextStorage = contextStorage;
    }

    /// <inheritdoc cref="IDataManagementRequestContextProvider.GetResource"/>
    public Resource GetResource() => _contextStorage.GetValue<Resource>(ResourceContextKey);

    /// <inheritdoc cref="IDataManagementRequestContextProvider.SetResource"/>
    public void SetResource(Resource resource) => _contextStorage.SetValue(ResourceContextKey, resource);
}
